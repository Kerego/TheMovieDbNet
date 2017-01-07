using System.IO;
using System.Linq;
using TheMovieDbNet.Models.Movies;
using TheMovieDbNet.Services;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace ConsoleApplication
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var api = File.ReadAllText("src/Samples/secrets.txt");
			var service = new PeopleService(api);

			var data = service.SearchAsync((args.Any() ? args[0] : "jennifer")).Result;
			var actorsAndMovies = 
				data.Results
				.Where(x => x.MoviesKnownFor.Any())
				.Take(5)
				.Aggregate(new StringBuilder(), 
					(sb, v) => sb.AppendLine($"{v.Name,20} - {v.MoviesKnownFor.OrderByDescending(x=>x.VoteAverage).First().Title, 20}"))
				.ToString();
			Console.WriteLine(actorsAndMovies);
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

			var best = data.Results.Aggregate((a, b) => a.VoteAverage > b.VoteAverage ? a : b);

			//one request
			var details = service.GetDetailsAsync(best.Id, 
				new MovieAppendSettings() {
					IncludeCredits = true,
					IncludeImages = true,
					IncludeRecommendations = true,
					IncludeSimilarMovies = true,
					IncludeVideos = true,
					IncludeAlternativeTitles = true,
					IncludeKeywords = true,
					IncludeTranslations = true,
					IncludeReleaseInfo = true,
				}).Result;

			//multiple
			var credits = service.GetCreditsAsync(best.Id).Result;
			var images = service.GetImagesAsync(best.Id).Result;
			var keywords = service.GetKeywordsAsync(best.Id).Result;
			var releaseDates = service.GetReleaseInfoAsync(best.Id).Result;
			var translations = service.GetTranslationsAsync(best.Id).Result;
			var similar = service.GetSimilarMoviesAsync(best.Id, 3, "en").Result;
			var videos = service.GetVideosAsync(best.Id, "en").Result;
			var alternative = service.GetAlternativeTitlesAsync(best.Id).Result;
			var rec = service.GetRecommendationsAsync(best.Id, 2).Result;

			System.Console.WriteLine(details.Title);
		}


		public static async Task SavePhotos(MovieSearchItem[] data, MovieService service)
		{
			var httpclient = new HttpClient();
			Directory.CreateDirectory("results");
			foreach (var item in data)
			{
				var title = item.Title;
				if(!Regex.IsMatch(item.Title, @"^[a-zA-Z]+$"))
				{
					title = item.Title.Replace(":", "");
					title = title.Replace("?", "");
				}
				var release = (string.IsNullOrWhiteSpace(item.ReleaseDate) ? "none" : item.ReleaseDate.Substring(0,4));
				title = $"{item.VoteAverage} - {release} - {title}";
				Directory.CreateDirectory($"results/{title}");
				var details = await service.GetDetailsAsync(item.Id, "images");
				var bestPhotos = details.Backdrops.OrderByDescending(x=>x.VoteAverage).Take(10).ToArray();
				for (int i = 0; i < bestPhotos.Length; i++)
				{
					var bytes = await httpclient.GetByteArrayAsync(bestPhotos[i].FullPathOriginal);
					File.WriteAllBytes($"results/{title}/{i}.jpg", bytes);
				}
			}
		}

	}
}
