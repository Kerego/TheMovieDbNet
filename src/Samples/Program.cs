using System.IO;
using System.Linq;
using TheMovieDbNet.Models.Movies;
using TheMovieDbNet.Services;
using System.Threading.Tasks;
using TheMovieDbNet.Models.People;
using TheMovieDbNet.Models.Common;
using System.Collections.Generic;
using TheMovieDbNet.Models.TVs;

namespace ConsoleApplication
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// MovieServiceScenarioAsync(args).Wait();
			// PeopleServiceScenarioAsync(args).Wait();
			// CompanyServiceScenarioAsync(args).Wait();
			// TVServiceScenarioAsync(args).Wait();
			// SearchServiceScenarioAsync(args).Wait();
			// CollectionServiceScenarioAsync(args).Wait();
			UtilityServiceScenarioAsync().Wait();
		}

		public static async Task UtilityServiceScenarioAsync()
		{
			var api = File.ReadAllText("src/Samples/secrets.txt");
			using(IUtilityService utilityService = new UtilityService(api))
			using(ISearchService searchService = new SearchService(api))
			{
				var configuration = await utilityService.GetConfigurationAsync();
				var movieGenres = await utilityService.GetMovieGenresAsync();
				var tvGenres = await utilityService.GetTVGenresAsync();

				var dicovered = await searchService.DiscoverMovies(new MovieDiscoverSettings 
				{
					Genres = new int[] { movieGenres[0].Id, movieGenres[1].Id }
				});
				var first = dicovered.Results.First();

				var path = $"{configuration.SecureBaseUrl}{configuration.PosterSizes.Last()}{first.PosterPath}";
				System.Console.WriteLine(path);
			}

		}

		public static async Task CollectionServiceScenarioAsync(string[] args)
		{
			var api = File.ReadAllText("src/Samples/secrets.txt");
			using (ISearchService searchService = new SearchService(api))
			using (ICollectionService collectionService = new CollectionService(api))
			{
				var collections = await searchService.SearchCollectionAsync(args.Any() ? args[0] : "harry potter");
				var firstId = collections.Results.First().Id;

				var details = await collectionService.GetDetails(firstId);
				var images = await collectionService.GetImages(firstId);

				System.Console.WriteLine(details.Name);
				System.Console.WriteLine(details.Overview);
			};
		}

		public static async Task SearchServiceScenarioAsync(string[] args)
		{
			var api = File.ReadAllText("src/Samples/secrets.txt");
			using (ISearchService service = new SearchService(api))
			{
				// search by names
				var tvSearch = await service.SearchTVAsync("arrested Development");
				var movieSearch = await service.SearchMovieAsync("harry potter");
				var companySearch = await service.SearchCompanyAsync("Marvel");
				var personSearch = await service.SearchPersonAsync("eva green");
				var collection = await service.SearchCollectionAsync("die hard");
				var keywords = await service.SearchKeywordAsync("self-sacrifice");

				// advanced search by various settings
				var movieSettings = new MovieDiscoverSettings();
				var tvSettings = new TVDiscoverSettings();
				movieSettings.Cast = new int[] { personSearch.Results.First().Id };
				movieSettings.SortOption = MovieSortOption.VoteAverageDescending;
				tvSettings.SortOption = TVSortOption.VoteAverageDescending;

				var movies = await service.DiscoverMovies(movieSettings);
				var tvs = await service.DiscoverTVs(tvSettings);

				IEnumerable<MediaBase> group = movies.Results.Concat<MediaBase>(tvs.Results);

				foreach (var item in @group)
					System.Console.WriteLine($"{item.VoteAverage,3} | {item.VoteCount,5} | { (item is MovieSearchItem ? (item as MovieSearchItem).Title : (item as TVSearchItem).Name),60}");
			}
		}

		public static async Task TVServiceScenarioAsync(string[] args)
		{
			//your api key here
			var api = File.ReadAllText("src/Samples/secrets.txt");
			using (ITVService service = new TVService(api))
			{

				var popular = await service.GetPopularAsync();
				var top = await service.GetTopRatedAsync();
				var upcoming = await service.GetAiringTodayAsync();
				var now = await service.GetOnTheAirAsync();
				var last = await service.GetLatestAsync();

				var best = popular.Results.Aggregate((a, b) => a.VoteAverage > b.VoteAverage ? a : b);

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

				System.Console.WriteLine(details.Name);

			}
		}

		public static async Task CompanyServiceScenarioAsync(string[] args)
		{
			var api = File.ReadAllText("src/Samples/secrets.txt");
			using (ICompanyService companyService = new CompanyService(api))
			using (ISearchService searchService = new SearchService(api))
			{
				var data = await searchService.SearchCompanyAsync("Marvel");
				var details = await companyService.GetDetailsAsync(data.Results.First().Id);
				System.Console.WriteLine(details.Name);
			}
		}

		public static async Task PeopleServiceScenarioAsync(string[] args)
		{
			var api = File.ReadAllText("src/Samples/secrets.txt");
			using (IPersonService service = new PersonService(api))
			{

				var popular = await service.GetPopularAsync();
				var n = await service.GetLatestAsync();

				var best = popular.Results.OrderByDescending(x => x.Popularity).First();

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

				System.Console.WriteLine(best.Name);
			}
		}

		public static async Task MovieServiceScenarioAsync(string[] args)
		{
			//your api key here
			var api = File.ReadAllText("src/Samples/secrets.txt");
			using (IMovieService service = new MovieService(api))
			{

				var popular = await service.GetPopularAsync();
				var top = await service.GetTopRatedAsync();
				var upcoming = await service.GetUpcomingAsync();
				var now = await service.GetNowPlayingAsync();
				var last = await service.GetLatestAsync();

				var best = popular.Results.Aggregate((a, b) => a.VoteAverage > b.VoteAverage ? a : b);

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


				System.Console.WriteLine(details.Title);
			}
		}

	}
}
