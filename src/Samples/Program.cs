using System.IO;
using System.Linq;
using TheMovieDbNet.Models.Movies;
using TheMovieDbNet.Services;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using TheMovieDbNet.Models.People;
using TheMovieDbNet.Models.Common;
using System.Collections.Generic;
using System;
using TheMovieDbNet.Models.TVs;

namespace ConsoleApplication
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// MovieServiceScenario(args);
			// PeopleServiceScenario(args);
			// CompanyServiceScenario(args);
			// TVServiceScenario(args);
			// SearchServiceScenario(args);
			// GetImdbIds().Wait();
		}

		public static async Task GetImdbIds()
		{
			var api = File.ReadAllText("src/Samples/secrets.txt");
			var service = new MovieService(api);

			using (var stream = File.CreateText("imdb.txt"))
			{
				stream.AutoFlush = true;
				for (int i = 0; i < 10000; i++)
				{
					try {
						var details = await service.GetDetailsAsync(i);
						var pair = $"{details.Id},{details.ImdbId}";
						System.Console.WriteLine(pair);
						await stream.WriteLineAsync(pair);
					}
					catch{
						System.Console.WriteLine($"{i}-missing");
					}
				}
			}
		}
		
		public static void SearchServiceScenario(string[] args)
		{
			var api = File.ReadAllText("src/Samples/secrets.txt");
			var service = new SearchService(api);
			var personService = new PersonService(api);


			var settings = new MovieDiscoverSettings();
			settings.Genres = new int[] { 12, 16 };
			// settings.Cast = new int[] { persons1.Results.First().Id, persons2.Results.First().Id };
			settings.ExcludeGenres = new int[] { 10749 };
			settings.MinVoteAverage = 8;
			settings.MinReleaseDate = new DateTime(2010, 1, 1);

			var movies = service.DiscoverMovies(settings).Result;
			
			foreach (var item in movies.Results)
				System.Console.WriteLine($"{item.VoteAverage, 3} | {item.Title, 60} | { String.Join(",", item.GenreIds) }");

		}

		public static void TVServiceScenario(string[] args)
		{
			var api = File.ReadAllText("src/Samples/secrets.txt");
			var service = new TVService(api);
			//search
			var data = service.SearchAsync("big bang").Result;

			var best = data.Results.OrderByDescending(x=>x.VoteAverage).First();
			//one request
			var settings = new TVAppendSettings();
			settings.IncludeAlternativeTitles = true;
			settings.IncludeContentRatings = true;
			settings.IncludeCredits = true;
			settings.IncludeImages = true;
			settings.IncludeKeywords = true;
			settings.IncludeRecommendations = true;
			settings.IncludeSimilarTVs = true;
			settings.IncludeVideos = true;
			settings.IncludeTranslations = true;

			var details = service.GetDetailsAsync(best.Id, settings).Result;

			//separate requests
			var titles = service.GetAlternativeTitlesAsync(best.Id).Result;
			var ratings = service.GetContentRatingsAsync(best.Id).Result;
			var credits = service.GetCreditsAsync(best.Id).Result;
			var images = service.GetImagesAsync(best.Id).Result;
			var keywords = service.GetKeywordsAsync(best.Id).Result;
			var recommendations = service.GetRecommendationsAsync(best.Id).Result;
			var similar = service.GetSimilarTVsAsync(best.Id).Result;
			var videos = service.GetVideosAsync(best.Id).Result;
			var translations = service.GetTranslationsAsync(best.Id).Result;

			System.Console.WriteLine();
		}


		public static void CompanyServiceScenario(string[] args)
		{
			var api = File.ReadAllText("src/Samples/secrets.txt");
			var service = new CompanyService(api);

			var data = service.SearchAsync("Marvel").Result;
			var details = service.GetDetailsAsync(data.Results.First().Id).Result;
			System.Console.WriteLine();
		}

		public static void PeopleServiceScenario(string[] args)
		{
			var api = File.ReadAllText("src/Samples/secrets.txt");
			var service = new PersonService(api);
			int page = 1;
			var data = service.SearchAsync(
				new PeopleSearchSettings
				{
					Query = (args.Any() ? args[0] : "bateman"),
					AllowAdult = true,
					Page = page
				}).Result;

			// var actorsAndMovies = 
			// 	data.Results
			// 	.Where(x => x.MoviesKnownFor.Any())
			// 	.Aggregate(new StringBuilder(), 
			// 		(sb, v) => sb.AppendLine($"{v.Name,20} - {v.MoviesKnownFor.OrderByDescending(x=>x.VoteAverage).First().Title, 20}"))
			// 	.ToString();
			// Console.WriteLine(actorsAndMovies);

			var best = data.Results.OrderByDescending(x => x.Popularity).First();

			var settings = new PersonAppendSettings();
			settings.IncludeTVCredits = true;
			settings.IncludeImages = true;
			settings.IncludeMovieCredits = true;
			settings.IncludeTaggedImages = true;
			settings.IncludeCombinedCredits = true;

			// //one request
			// var details = service.GetDetailsAsync(best.Id, settings).Result;

			// //multiple
			// var images = service.GetImagesAsync(best.Id).Result;
			// var taggedImages = service.GetTaggedImagesAsync(best.Id, 2).Result;
			var credits = service.GetCreditsAsync(best.Id).Result;

			int currentPage = 1;
			List<Image> images = new List<Image>();
			TaggedImageCollection taggedImages;
			do
			{
				taggedImages = service.GetTaggedImagesAsync(best.Id, currentPage).Result;
				images.AddRange(taggedImages.MovieTaggedImages.Cast<Image>().Concat(taggedImages.TVTaggedImages));
			} while (currentPage++ < taggedImages.TotalPages);

			SaveImages(new Dictionary<string, Image[]>
			{
				[best.Name] = images.ToArray()
			}).Wait();


			// var movieservice = new MovieService(api);
			// var tasks = credits.MovieCast.Select(x => 
			// {
			// 	return Task.Run(async () => {
			// 		return await movieservice.GetDetailsAsync(x.Id);
			// 	});
			// });

			// var movies = Task.WhenAll(tasks).Result;
			// System.Console.WriteLine(best.Name + " " + best.Id);
			// foreach (var item in movies.OrderBy(x=>x.VoteAverage))
			// 	System.Console.WriteLine($"{item.VoteAverage, 2} - {item.Title, -40} - {item.Genres.Select(x=>x.Name).Aggregate("", (a,c) => $"{a} | {c}"), -20}");

		}

		public static async Task SaveImages(Dictionary<string, Image[]> data)
		{
			HttpClient client = new HttpClient();
			foreach (var item in data)
			{
				Directory.CreateDirectory($"results/{item.Key}");
				var tasks = item.Value.Select(x => Task.Run(async () =>
				{
					var bytes = await client.GetByteArrayAsync(x.FullPathOriginal);
					File.WriteAllBytes($"results/{item.Key}/{Guid.NewGuid()}.jpg", bytes);
				}));
				await Task.WhenAll(tasks);
			}
		}

		public static void MovieServiceScenario(string[] args)
		{
			var api = File.ReadAllText("src/Samples/secrets.txt");
			var service = new MovieService(api);

			var data = service.SearchAsync(new MovieSearchSettings
			{
				Query = (args.Any() ? args[0] : "harry"),
				Page = 1,
			}).Result;

			SavePhotos(data.Results.ToArray(), service).Wait();
			// var best = data.Results.Aggregate((a, b) => a.VoteAverage > b.VoteAverage ? a : b);

			//one request
			// var details = service.GetDetailsAsync(best.Id, 
			// 	new MovieAppendSettings() {
			// 		IncludeCredits = true,
			// 		IncludeImages = true,
			// 		IncludeRecommendations = true,
			// 		IncludeSimilarMovies = true,
			// 		IncludeVideos = true,
			// 		IncludeAlternativeTitles = true,
			// 		IncludeKeywords = true,
			// 		IncludeTranslations = true,
			// 		IncludeReleaseInfo = true,
			// 	}).Result;

			//multiple
			// var credits = service.GetCreditsAsync(best.Id).Result;
			// var images = service.GetImagesAsync(best.Id).Result;
			// var keywords = service.GetKeywordsAsync(best.Id).Result;
			// var releaseDates = service.GetReleaseInfoAsync(best.Id).Result;
			// var translations = service.GetTranslationsAsync(best.Id).Result;
			// var similar = service.GetSimilarMoviesAsync(best.Id, 3, "en").Result;
			// var videos = service.GetVideosAsync(best.Id, "en").Result;
			// var alternative = service.GetAlternativeTitlesAsync(best.Id).Result;
			// var rec = service.GetRecommendationsAsync(best.Id, 2).Result;

			// System.Console.WriteLine(details.Title);
		}


		public static async Task SavePhotos(MovieSearchItem[] data, MovieService service)
		{
			var httpclient = new HttpClient();
			Directory.CreateDirectory("results");
			foreach (var item in data)
			{
				var title = item.Title;
				if (!Regex.IsMatch(item.Title, @"^[a-zA-Z]+$"))
				{
					title = item.Title.Replace(":", "");
					title = title.Replace("?", "");
				}
				System.Console.WriteLine(title);
				var release = (string.IsNullOrWhiteSpace(item.ReleaseDate) ? "none" : item.ReleaseDate.Substring(0, 4));
				title = $"{item.VoteAverage} - {release} - {title}";
				Directory.CreateDirectory($"results/{title}");
				var details = await service.GetDetailsAsync(item.Id, "images,credits");
				//photos
				var bestPhotos = details.Backdrops.Concat(details.Posters).OrderByDescending(x => x.VoteAverage).Take(10).ToArray();
				for (int i = 0; i < bestPhotos.Length; i++)
				{
					var bytes = await httpclient.GetByteArrayAsync(bestPhotos[i].FullPathOriginal);
					File.WriteAllBytes($"results/{title}/{i}.jpg", bytes);
				}

				// //cast
				// Directory.CreateDirectory($"results/{title}/cast");
				// foreach (var actor in details.Cast)
				// {
				// 	if(actor.ProfilePath == null)
				// 		continue;
				// 	var bytes = await httpclient.GetByteArrayAsync($"https://image.tmdb.org/t/p/original{actor.ProfilePath}");
				// 	File.WriteAllBytes($"results/{title}/cast/{actor.Name}.jpg", bytes);
				// }
			}
		}

	}
}
