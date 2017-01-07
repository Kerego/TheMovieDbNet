using System.IO;
using System.Linq;
using TheMovieDbNet.Models.Movies;
using TheMovieDbNet.Services;
using System;
using TheMovieDbNet.Models.Common;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApplication
{
	public class Program
	{
		static MovieService service;
		public static void Main(string[] args)
		{
			var api = File.ReadAllText("src/Samples/secrets.txt");
			service = new MovieService(api);

			var data = service.SearchAsync(new MovieSearchSettings
			{
				Query = (args.Any() ? args[0] : "harry"),
				Page = 1,
			}).Result;

			var best = data.Results.Aggregate((a, b) => a.VoteAverage > b.VoteAverage ? a : b);

			// var details = service.GetDetailsAsync(best.Id, "recommendations,similar_movies,images,videos,alternative_titles,keywords,credits,release_dates,translations").Result;
			
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

			// var cast = details.Cast.Aggregate("", (a, x) => $"{a}{x.Name, 20} - {x.Character, 20}\r\n");
			// System.Console.WriteLine(cast);
			// System.Console.WriteLine($"{best.Id} {best.Title}");

			// SavePhotos(data.Results).Wait();

			// var credits = service.GetCreditsAsync(best.Id).Result;
			// var images = service.GetImagesAsync(best.Id).Result;
			// var keywords = service.GetKeywordsAsync(best.Id).Result;
			// var releaseDates = service.GetReleaseInfoAsync(best.Id).Result;
			// var translations = service.GetTranslationsAsync(best.Id).Result;
			// var similar = service.GetSimilarMoviesAsync(best.Id, 3, "en").Result;
			// var videos = service.GetVideosAsync(best.Id, "en").Result;
			// var alternative = service.GetAlternativeTitlesAsync(best.Id).Result;
			// var rec = service.GetRecommendationsAsync(best.Id, 2).Result;

			System.Console.WriteLine(details.Title);
		}



		public static async Task SavePhotos(MovieSearchItem[] data)
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
