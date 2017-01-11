using System;
using System.Threading.Tasks;
using TheMovieDbNet.Converters;
using TheMovieDbNet.Models.Common;
using TheMovieDbNet.Models.TVs;

namespace TheMovieDbNet.Services
{
	/// <summary>
	/// Represents a service for accessing movie-related data.
	/// </summary>
	public class TVService : Service, ITVService
	{
		
		private Lazy<TVConverter> _lazyConverter = new Lazy<TVConverter>(() => new TVConverter(), true);
		/// <summary>
		/// Initializes a new instance of PeopleService.
		/// </summary>
		/// <param name="apiKey">API key from the movie db developer site</param>
		public TVService(string apiKey) : base(apiKey)
		{
		}

		/// <summary>
		/// Gets details of a tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="append">Additional info to append to the response (eg: images, videos).</param>
		/// <returns>Object of type tv with fields filled with data.</returns>
		public async Task<TV> GetDetailsAsync(int id, string append = "")
		{
			var path = $"/3/tv/{id}?api_key={apiKey}&append_to_response={append}";
			return await RequestAndDeserialize<TV>(path, _lazyConverter.Value);
		}
		
		/// <summary>
		/// Gets details of a tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="settings">Additional info to append to the response (eg: images, videos).</param>
		/// <returns>Object of type tv with fields filled with data.</returns>
		public async Task<TV> GetDetailsAsync(int id, TVAppendSettings settings)
			=> await GetDetailsAsync(id, settings.ToString());

		/// <summary>
		/// Gets tv identifiers on external sites.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="language">Language of the result.</param>
		/// <returns>External ids for tv.</returns>
		public async Task<TVExternals> GetExternalIdsAsync(int id, string language = "")
		{
			var path = $"/3/tv/{id}/external_ids?api_key={apiKey}";
			if (!String.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			return await RequestAndDeserialize<TVExternals>(path);
		}

		/// <summary>
		/// Gets the latest added tv.
		/// </summary>
		/// <param name="language">Language of the result.</param>
		/// <returns>TV object with filled details.</returns>
		public async Task<TV> GetLatestAsync(string language = "")
		{
			var path = $"/3/tv/latest?api_key={apiKey}";
			if (!String.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			return await RequestAndDeserialize<TV>(path, _lazyConverter.Value);
		}

		/// <summary>
		/// Gets the list of tv shows that are airing today.
		/// </summary>
		/// <param name="page">Page of result.</param>
		/// <param name="language">Language of result.</param>
		/// <returns>Search results along with page data.</returns>
		public async Task<PagedResult<TVSearchItem>> GetAiringTodayAsync(int page = 0, string language = "")
		{
			var path = $"/3/tv/airing_today?api_key={apiKey}";
			if (!String.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			if (page > 0)
				path += $"&page={page}";
			return await RequestAndDeserialize<PagedResult<TVSearchItem>>(path);
		}

		/// <summary>
		/// Gets the list of tv shows that are currently on the air.
		/// </summary>
		/// <param name="page">Page of result.</param>
		/// <param name="language">Language of result.</param>
		/// <returns>Search results along with page data.</returns>
		public async Task<PagedResult<TVSearchItem>> GetOnTheAirAsync(int page = 0, string language = "")
		{
			var path = $"/3/tv/on_the_air?api_key={apiKey}";
			if (!String.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			if (page > 0)
				path += $"&page={page}";
			return await RequestAndDeserialize<PagedResult<TVSearchItem>>(path);
		}

		/// <summary>
		/// Gets the list of tv shows that are popular.
		/// </summary>
		/// <param name="page">Page of result.</param>
		/// <param name="language">Language of result.</param>
		/// <returns>Search results along with page data.</returns>
		public async Task<PagedResult<TVSearchItem>> GetPopularAsync(int page = 0, string language = "")
		{
			var path = $"/3/tv/popular?api_key={apiKey}";
			if (!String.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			if (page > 0)
				path += $"&page={page}";
			return await RequestAndDeserialize<PagedResult<TVSearchItem>>(path);
		}

		/// <summary>
		/// Gets the list of tv shows that are top rated.
		/// </summary>
		/// <param name="page">Page of result.</param>
		/// <param name="language">Language of result.</param>
		/// <returns>Search results along with page data.</returns>
		public async Task<PagedResult<TVSearchItem>> GetTopRatedAsync(int page = 0, string language = "")
		{
			var path = $"/3/tv/top_rated?api_key={apiKey}";
			if (!String.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			if (page > 0)
				path += $"&page={page}";
			return await RequestAndDeserialize<PagedResult<TVSearchItem>>(path);
		}

		/// <summary>
		/// Gets content rating for the tv series.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="language">Language of rating.</param>
		/// <returns>Array of ContentRatings Titles for tv.</returns>
		public async Task<ContentRating[]> GetContentRatingsAsync(int id, string language = "")
		{
			var path = $"/3/tv/{id}/content_ratings?api_key={apiKey}";
			if (!String.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			return await RequestAndSelect<ContentRating[]>(path, "results");
		}

		/// <summary>
		/// Gets translated titles of the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="language">Language of translation (eg: es, pt).</param>
		/// <returns>Array of Alternative Titles for tv.</returns>
		public async Task<AlternativeTitle[]> GetAlternativeTitlesAsync(int id, string language = "")
		{
			var path = $"/3/tv/{id}/alternative_titles?api_key={apiKey}";
			if (!String.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			return await RequestAndSelect<AlternativeTitle[]>(path, "results");
		}
		
		/// <summary>
		/// Gets the cast and crew of the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="language">Language of translation.</param>
		/// <returns>Credits of the tv.</returns>
		public async Task<MediaCredits> GetCreditsAsync(int id, string language = "")
		{
			var path = $"/3/tv/{id}/credits?api_key={apiKey}";
			if (!String.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			return await RequestAndDeserialize<MediaCredits>(path);
		}

		/// <summary>
		/// Gets the images of the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="language">Language of the image.</param>
		/// <returns>Collection with the images of the tv.</returns>
		public async Task<ImageCollection> GetImagesAsync(int id, string language = "")
		{
			var path = $"/3/tv/{id}/images?api_key={apiKey}";
			if (!String.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			return await RequestAndDeserialize<ImageCollection>(path);
		}

		/// <summary>
		/// Gets the keywords of the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <returns>Array of the keywords.</returns>
		public async Task<Keyword[]> GetKeywordsAsync(int id)
		{
			var path = $"/3/tv/{id}/keywords?api_key={apiKey}";
			return await RequestAndSelect<Keyword[]>(path, "results");
		}

		/// <summary>
		/// Gets the videos of the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="language">Video language.</param>
		/// <returns>Array of videos.</returns>
		public async Task<Video[]> GetVideosAsync(int id, string language = "")
		{
			var path = $"/3/tv/{id}/videos?api_key={apiKey}";
			if (!String.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			return await RequestAndSelect<Video[]>(path, "results");
		}

		/// <summary>
		/// Gets the translations of the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <returns>Array of translations.</returns>
		public async Task<Translation[]> GetTranslationsAsync(int id)
		{
			var path = $"/3/tv/{id}/translations?api_key={apiKey}";
			return await RequestAndSelect<Translation[]>(path, "translations");
		}

		/// <summary>
		/// Gets the recommendations for the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="page">Recommendations page number.</param>
		/// <param name="language">Tv language.</param>
		/// <returns>Collection of recommendations.</returns>
		public async Task<PagedResult<TVSearchItem>> GetRecommendationsAsync(int id, int page = 0, string language = "")
		{
			var path = $"/3/tv/{id}/recommendations?api_key={apiKey}";
			if (page > 0)
				path += $"&page={page}";
			if (!String.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			return await RequestAndDeserialize<PagedResult<TVSearchItem>>(path);
		}

		/// <summary>
		/// Gets the similar tvs.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="page">Similar tvs page number.</param>
		/// <param name="language">tv language.</param>
		/// <returns>Collection of similar tvs.</returns>
		public async Task<PagedResult<TVSearchItem>> GetSimilarTVsAsync(int id, int page = 0, string language = "")
		{
			var path = $"/3/tv/{id}/similar?api_key={apiKey}";
			if (page > 0)
				path += $"&page={page}";
			if (!String.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			return await RequestAndDeserialize<PagedResult<TVSearchItem>>(path);
		}

	}
}