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
			// MovieServiceScenarioAsync(args).Wait();
			PeopleServiceScenarioAsync(args).Wait();
			// CompanyServiceScenario(args);
			// TVServiceScenarioAsync(args).Wait();
			// SearchServiceScenario(args);
			// GetImdbIds().Wait();
		}

		public static void SearchServiceScenario(string[] args)
		{
			var api = File.ReadAllText("src/Samples/secrets.txt");
			var service = new SearchService(api);
			var settings = new MovieDiscoverSettings();

			var movies = service.DiscoverMovies(settings).Result;

			foreach (var item in movies.Results)
				System.Console.WriteLine($"{item.VoteAverage,3} | {item.VoteCount,5} | {item.Title,60}");
		}

		public static async Task TVServiceScenarioAsync(string[] args)
		{
			//your api key here
			var api = File.ReadAllText("src/Samples/secrets.txt");
			var service = new TVService(api);

			var data = await service.SearchAsync(new TVSearchSettings
			{
				Query = (args.Any() ? args[0] : "arrested development"),
				Page = 1,
			});

			var best = data.Results.Aggregate((a, b) => a.VoteAverage > b.VoteAverage ? a : b);

			// details in one request
			var details = await service.GetDetailsAsync(best.Id,
				new TVAppendSettings()
				{
					IncludeAlternativeTitles = true,
					IncludeContentRatings = true,
					IncludeCredits = true,
					IncludeImages = true,
					IncludeKeywords = true,
					IncludeRecommendations = true,
					IncludeSimilarTVs = true,
					IncludeVideos = true,
					IncludeTranslations = true,
					IncludeExternalIds = true
				});

			//details in multiple erquests
			var titles = await service.GetAlternativeTitlesAsync(best.Id);
			var ratings = await service.GetContentRatingsAsync(best.Id);
			var credits = await service.GetCreditsAsync(best.Id);
			var images = await service.GetImagesAsync(best.Id);
			var keywords = await service.GetKeywordsAsync(best.Id);
			var translations = await service.GetTranslationsAsync(best.Id);
			var videos = await service.GetVideosAsync(best.Id);
			var recommendations = await service.GetRecommendationsAsync(best.Id);
			var similar = await service.GetSimilarTVsAsync(best.Id);
			var ids = await service.GetExternalIdsAsync(best.Id);

			var popular = await service.GetPopularAsync();
			var top = await service.GetTopRatedAsync();
			var upcoming = await service.GetAiringTodayAsync();
			var now = await service.GetOnTheAirAsync();
			var last = await service.GetLatestAsync();

			System.Console.WriteLine(details.Name);
		}


		public static void CompanyServiceScenario(string[] args)
		{
			var api = File.ReadAllText("src/Samples/secrets.txt");
			var service = new CompanyService(api);

			var data = service.SearchAsync("Marvel").Result;
			var details = service.GetDetailsAsync(data.Results.First().Id).Result;
			System.Console.WriteLine();
		}

		public static async Task PeopleServiceScenarioAsync(string[] args)
		{
			var api = File.ReadAllText("src/Samples/secrets.txt");
			var service = new PersonService(api);
			int page = 1;
			var data = await service.SearchAsync(
				new PeopleSearchSettings
				{
					Query = (args.Any() ? args[0] : "bateman"),
					AllowAdult = true,
					Page = page
				});

			// var actorsAndMovies = 
			// 	data.Results
			// 	.Where(x => x.MoviesKnownFor.Any())
			// 	.Aggregate(new StringBuilder(), 
			// 		(sb, v) => sb.AppendLine($"{v.Name,20} - {v.MoviesKnownFor.OrderByDescending(x=>x.VoteAverage).First().Title, 20}"))
			// 	.ToString();
			// Console.WriteLine(actorsAndMovies);

			var best = data.Results.OrderByDescending(x => x.Popularity).First();

			//one request
			var details = await service.GetDetailsAsync(best.Id, 
				new PersonAppendSettings
				{
					IncludeTVCredits = true,
					IncludeImages = true,
					IncludeMovieCredits = true,
					IncludeTaggedImages = true,
					IncludeCombinedCredits = true,
					IncludeExternalIds = true
				});

			// multiple
			var images = await service.GetImagesAsync(best.Id);
			var taggedImages = await service.GetTaggedImagesAsync(best.Id, 2);
			var credits = await service.GetCreditsAsync(best.Id);
			var ids = await service.GetExternalIdsAsync(best.Id);


			var popular = await service.GetPopularAsync();
			var n = await service.GetLatestAsync();

			System.Console.WriteLine(best.Name);
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

		public static async Task MovieServiceScenarioAsync(string[] args)
		{
			//your api key here
			var api = File.ReadAllText("src/Samples/secrets.txt");
			var service = new MovieService(api);

			var data = await service.SearchAsync(new MovieSearchSettings
			{
				Query = (args.Any() ? args[0] : "harry"),
				Page = 1,
			});

			var best = data.Results.Aggregate((a, b) => a.VoteAverage > b.VoteAverage ? a : b);

			// details in one request
			var details = await service.GetDetailsAsync(best.Id,
				new MovieAppendSettings()
				{
					IncludeCredits = true,
					IncludeImages = true,
					IncludeRecommendations = true,
					IncludeSimilarMovies = true,
					IncludeVideos = true,
					IncludeAlternativeTitles = true,
					IncludeKeywords = true,
					IncludeTranslations = true,
					IncludeReleaseInfo = true,
				});

			//details in multiple erquests
			var credits = await service.GetCreditsAsync(best.Id);
			var images = await service.GetImagesAsync(best.Id);
			var keywords = await service.GetKeywordsAsync(best.Id);
			var releaseDates = await service.GetReleaseInfoAsync(best.Id);
			var translations = await service.GetTranslationsAsync(best.Id);
			var similar = await service.GetSimilarMoviesAsync(best.Id);
			var videos = await service.GetVideosAsync(best.Id);
			var alternative = await service.GetAlternativeTitlesAsync(best.Id);
			var rec = await service.GetRecommendationsAsync(best.Id);

			var popular = await service.GetPopularAsync();
			var top = await service.GetTopRatedAsync();
			var upcoming = await service.GetUpcomingAsync();
			var now = await service.GetNowPlayingAsync();
			var last = await service.GetLatestAsync();

			System.Console.WriteLine(details.Title);
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
				var release = item.ReleaseDate.Year;
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
