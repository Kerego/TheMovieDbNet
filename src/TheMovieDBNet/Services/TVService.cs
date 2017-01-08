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
		/// <returns>Object of type tv with fields filled with data.</returns>
		public async Task<TV> GetDetailsAsync(int id)
			=> await GetDetailsAsync(id, string.Empty);

		/// <summary>
		/// Gets details of a tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="append">Additional info to append to the response (eg: images, videos).</param>
		/// <returns>Object of type tv with fields filled with data.</returns>
		public async Task<TV> GetDetailsAsync(int id, string append)
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
		/// Gets content rating for the tv series.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <returns>Array of ContentRatings Titles for tv.</returns>
		public async Task<ContentRating[]> GetContentRatingsAsync(int id)
			=> await GetContentRatingsAsync(id, string.Empty);

		/// <summary>
		/// Gets content rating for the tv series.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="language">Language of rating.</param>
		/// <returns>Array of ContentRatings Titles for tv.</returns>
		public async Task<ContentRating[]> GetContentRatingsAsync(int id, string language)
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
		/// <returns>Array of Alternative Titles for tv.</returns>
		public async Task<AlternativeTitle[]> GetAlternativeTitlesAsync(int id)
			=> await GetAlternativeTitlesAsync(id, string.Empty);

		/// <summary>
		/// Gets translated titles of the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="language">Language of translation (eg: es, pt).</param>
		/// <returns>Array of Alternative Titles for tv.</returns>
		public async Task<AlternativeTitle[]> GetAlternativeTitlesAsync(int id, string language)
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
		/// <returns>Credits of the tv.</returns>
		public async Task<MediaCredits> GetCreditsAsync(int id) 
			=> await GetCreditsAsync(id, string.Empty);
		
		/// <summary>
		/// Gets the cast and crew of the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="language">Language of translation.</param>
		/// <returns>Credits of the tv.</returns>
		public async Task<MediaCredits> GetCreditsAsync(int id, string language)
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
		/// <returns>Collection with the images of the tv.</returns>
		public async Task<ImageCollection> GetImagesAsync(int id)
			=> await GetImagesAsync(id, string.Empty);
		
		/// <summary>
		/// Gets the images of the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="language">Language of the image.</param>
		/// <returns>Collection with the images of the tv.</returns>

		public async Task<ImageCollection> GetImagesAsync(int id, string language)
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
		/// <returns>Array of videos.</returns>
		public async Task<Video[]> GetVideosAsync(int id)
			=> await GetVideosAsync(id, string.Empty);

		/// <summary>
		/// Gets the videos of the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="language">Video language.</param>
		/// <returns>Array of videos.</returns>
		public async Task<Video[]> GetVideosAsync(int id, string language)		
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
		/// <param name="language">tv language.</param>
		/// <returns>Collection of recommendations.</returns>
		public async Task<SearchResult<TVSearchItem>> GetRecommendationsAsync(int id, int page, string language)
		{
			var path = $"/3/tv/{id}/recommendations?api_key={apiKey}";
			if (page > 0)
				path += $"&page={page}";
			if (!String.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			return await RequestAndDeserialize<SearchResult<TVSearchItem>>(path);
		}
		
		/// <summary>
		/// Gets the recommendations for the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="page">Recommendations page number.</param>
		/// <returns>Collection of recommendations.</returns>
		public async Task<SearchResult<TVSearchItem>> GetRecommendationsAsync(int id, int page)
			=> await GetRecommendationsAsync(id, page, string.Empty);

		/// <summary>
		/// Gets the recommendations for the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <returns>Collection of recommendations.</returns>
		public async Task<SearchResult<TVSearchItem>> GetRecommendationsAsync(int id)
			=> await GetRecommendationsAsync(id, 0, string.Empty);

		/// <summary>
		/// Gets the similar tvs.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="page">Similar tvs page number.</param>
		/// <param name="language">tv language.</param>
		/// <returns>Collection of similar tvs.</returns>
		public async Task<SearchResult<TVSearchItem>> GetSimilarTVsAsync(int id, int page, string language)
		{
			var path = $"/3/tv/{id}/similar?api_key={apiKey}";
			if (page > 0)
				path += $"&page={page}";
			if (!String.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			return await RequestAndDeserialize<SearchResult<TVSearchItem>>(path);
		}

		/// <summary>
		/// Gets the similar tvs.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="page">Similar tvs page number.</param>
		/// <returns>Collection of similar tvs.</returns>
		public async Task<SearchResult<TVSearchItem>> GetSimilarTVsAsync(int id, int page)
			=> await GetSimilarTVsAsync(id, page, string.Empty);
		
		/// <summary>
		/// Gets the similar tvs.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <returns>Collection of similar tvs.</returns>
		public async Task<SearchResult<TVSearchItem>> GetSimilarTVsAsync(int id)
			=> await GetSimilarTVsAsync(id, 0, string.Empty);

		/// <summary>
		/// Gets a page of tv based on search query.
		/// </summary>
		/// <param name="query">Name of the tv.</param>
		/// <returns>Search Result with tv and page data.</returns>
		public async Task<SearchResult<TVSearchItem>> SearchAsync(string query)
		{
			return await SearchAsync(new TVSearchSettings
			{
				Query = query,
				Page = 1
			});
		}

		/// <summary>
		/// Gets a page of tv based on search query.
		/// </summary>
		/// <param name="query">Name of the tv.</param>
		/// <param name="page">Number of page for search.</param>
		/// <returns>Search Result with tv and page data.</returns>
		public async Task<SearchResult<TVSearchItem>> SearchAsync(string query, int page)
		{
			return await SearchAsync(new TVSearchSettings
			{
				Query = query,
				Page = page
			});
		}

		/// <summary>
		/// Gets a page of tv based on search query.
		/// </summary>
		/// <param name="settings">Settings class for detailed search.</param>
		/// <returns>Search Result with tv and page data.</returns>
		public async Task<SearchResult<TVSearchItem>> SearchAsync(TVSearchSettings settings)
		{
			var path = $"/3/search/tv?api_key={apiKey}{settings}";
			return await RequestAndDeserialize<SearchResult<TVSearchItem>>(path);
		}
	}
}