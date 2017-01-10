using System;
using System.Threading.Tasks;
using TheMovieDbNet.Models.Common;
using TheMovieDbNet.Models.TVs;

namespace TheMovieDbNet.Services
{
	/// <summary>
	/// Represents abstraction for requesting people-related data from database.
	/// </summary>
	public interface ITVService : IDisposable
	{
		
		/// <summary>
		/// Gets details of a tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <returns>Object of type tv with fields filled with data.</returns>
		Task<TV> GetDetailsAsync(int id);

		/// <summary>
		/// Gets details of a tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="append">Additional info to append to the response (eg: images, videos).</param>
		/// <returns>Object of type tv with fields filled with data.</returns>
		Task<TV> GetDetailsAsync(int id, string append);
		
		/// <summary>
		/// Gets details of a tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="settings">Additional info to append to the response (eg: images, videos).</param>
		/// <returns>Object of type tv with fields filled with data.</returns>
		Task<TV> GetDetailsAsync(int id, TVAppendSettings settings);

		/// <summary>
		/// Gets content rating for the tv series.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <returns>Array of ContentRatings Titles for tv.</returns>
		Task<ContentRating[]> GetContentRatingsAsync(int id);

		/// <summary>
		/// Gets content rating for the tv series.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="language">Language of rating.</param>
		/// <returns>Array of ContentRatings Titles for tv.</returns>
		Task<ContentRating[]> GetContentRatingsAsync(int id, string language);

		/// <summary>
		/// Gets translated titles of the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <returns>Array of Alternative Titles for tv.</returns>
		Task<AlternativeTitle[]> GetAlternativeTitlesAsync(int id);

		/// <summary>
		/// Gets translated titles of the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="language">Language of translation (eg: es, pt).</param>
		/// <returns>Array of Alternative Titles for tv.</returns>
		Task<AlternativeTitle[]> GetAlternativeTitlesAsync(int id, string language);

		/// <summary>
		/// Gets the cast and crew of the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <returns>Credits of the tv.</returns>
		Task<MediaCredits> GetCreditsAsync(int id);
		
		/// <summary>
		/// Gets the cast and crew of the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="language">Language of translation.</param>
		/// <returns>Credits of the tv.</returns>
		Task<MediaCredits> GetCreditsAsync(int id, string language);

		/// <summary>
		/// Gets the images of the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <returns>Collection with the images of the tv.</returns>
		Task<ImageCollection> GetImagesAsync(int id);
		
		/// <summary>
		/// Gets the images of the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="language">Language of the image.</param>
		/// <returns>Collection with the images of the tv.</returns>
		Task<ImageCollection> GetImagesAsync(int id, string language);

		/// <summary>
		/// Gets the keywords of the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <returns>Array of the keywords.</returns>
		Task<Keyword[]> GetKeywordsAsync(int id);

		/// <summary>
		/// Gets the videos of the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <returns>Array of videos.</returns>
		Task<Video[]> GetVideosAsync(int id);

		/// <summary>
		/// Gets the videos of the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="language">Video language.</param>
		/// <returns>Array of videos.</returns>
		Task<Video[]> GetVideosAsync(int id, string language);

		/// <summary>
		/// Gets the translations of the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <returns>Array of translations.</returns>
		Task<Translation[]> GetTranslationsAsync(int id);

		/// <summary>
		/// Gets the recommendations for the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="page">Recommendations page number.</param>
		/// <param name="language">tv language.</param>
		/// <returns>Collection of recommendations.</returns>
		Task<SearchResult<TVSearchItem>> GetRecommendationsAsync(int id, int page, string language);
		
		/// <summary>
		/// Gets the recommendations for the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="page">Recommendations page number.</param>
		/// <returns>Collection of recommendations.</returns>
		Task<SearchResult<TVSearchItem>> GetRecommendationsAsync(int id, int page);

		/// <summary>
		/// Gets the recommendations for the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <returns>Collection of recommendations.</returns>
		Task<SearchResult<TVSearchItem>> GetRecommendationsAsync(int id);

		/// <summary>
		/// Gets the similar tvs.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="page">Similar tvs page number.</param>
		/// <param name="language">tv language.</param>
		/// <returns>Collection of similar tvs.</returns>
		Task<SearchResult<TVSearchItem>> GetSimilarTVsAsync(int id, int page, string language);

		/// <summary>
		/// Gets the similar tvs.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="page">Similar tvs page number.</param>
		/// <returns>Collection of similar tvs.</returns>
		Task<SearchResult<TVSearchItem>> GetSimilarTVsAsync(int id, int page);
		
		/// <summary>
		/// Gets the similar tvs.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <returns>Collection of similar tvs.</returns>
		Task<SearchResult<TVSearchItem>> GetSimilarTVsAsync(int id);

		/// <summary>
		/// Gets a page of tv based on search query.
		/// </summary>
		/// <param name="query">Name of the tv.</param>
		/// <returns>Search Result with tv and page data.</returns>
		Task<SearchResult<TVSearchItem>> SearchAsync(string query);

		/// <summary>
		/// Gets a page of tv based on search query.
		/// </summary>
		/// <param name="query">Name of the tv.</param>
		/// <param name="page">Number of page for search.</param>
		/// <returns>Search Result with tv and page data.</returns>
		Task<SearchResult<TVSearchItem>> SearchAsync(string query, int page);
		
		/// <summary>
		/// Gets a page of tv based on search query.
		/// </summary>
		/// <param name="settings">Settings class for detailed search.</param>
		/// <returns>Search Result with tv and page data.</returns>
		Task<SearchResult<TVSearchItem>> SearchAsync(TVSearchSettings settings);
	}
}