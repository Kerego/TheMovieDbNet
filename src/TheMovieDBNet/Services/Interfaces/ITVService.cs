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
		/// Gets the latest added tv
		/// </summary>
		/// <param name="language">Language of the result.</param>
		/// <returns>TV object with filled details.</returns>
		Task<TV> GetLatestAsync(string language = "");

		/// <summary>
		/// Gets the list of tv shows that are airing today.
		/// </summary>
		/// <param name="page">Page of result.</param>
		/// <param name="language">Language of result.</param>
		/// <returns>Search results along with page data.</returns>
		Task<PagedResult<TVSearchItem>> GetAiringTodayAsync(int page = 0, string language = "");

		/// <summary>
		/// Gets the list of tv shows that are currently on the air.
		/// </summary>
		/// <param name="page">Page of result.</param>
		/// <param name="language">Language of result.</param>
		/// <returns>Search results along with page data.</returns>
		Task<PagedResult<TVSearchItem>> GetOnTheAirAsync(int page = 0, string language = "");

		/// <summary>
		/// Gets the list of tv shows that are popular.
		/// </summary>
		/// <param name="page">Page of result.</param>
		/// <param name="language">Language of result.</param>
		/// <returns>Search results along with page data.</returns>
		Task<PagedResult<TVSearchItem>> GetPopularAsync(int page = 0, string language = "");
		/// <summary>
		/// Gets the list of tv shows that are top rated.
		/// </summary>
		/// <param name="page">Page of result.</param>
		/// <param name="language">Language of result.</param>
		/// <returns>Search results along with page data.</returns>
		Task<PagedResult<TVSearchItem>> GetTopRatedAsync(int page = 0, string language = "");

		/// <summary>
		/// Gets details of a tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="append">Additional info to append to the response (eg: images, videos).</param>
		/// <returns>Object of type tv with fields filled with data.</returns>
		Task<TV> GetDetailsAsync(int id, string append = "");
		
		/// <summary>
		/// Gets details of a tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="settings">Additional info to append to the response (eg: images, videos).</param>
		/// <returns>Object of type tv with fields filled with data.</returns>
		Task<TV> GetDetailsAsync(int id, TVAppendSettings settings);

		/// <summary>
		/// Gets tv identifiers on external sites.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="language">Language of the result.</param>
		/// <returns>External ids for tv.</returns>
		Task<TVExternals> GetExternalIdsAsync(int id, string language = "");

		/// <summary>
		/// Gets content rating for the tv series.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="language">Language of the result.</param>
		/// <returns>Array of ContentRatings Titles for tv.</returns>
		Task<ContentRating[]> GetContentRatingsAsync(int id, string language = "");

		/// <summary>
		/// Gets translated titles of the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="language">Language of the result.</param>
		/// <returns>Array of Alternative Titles for tv.</returns>
		Task<AlternativeTitle[]> GetAlternativeTitlesAsync(int id, string language = "");
		
		/// <summary>
		/// Gets the cast and crew of the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="language">Language of the result.</param>
		/// <returns>Credits of the tv.</returns>
		Task<MediaCredits> GetCreditsAsync(int id, string language = "");
		
		/// <summary>
		/// Gets the images of the tv.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="language">Language of the result.</param>
		/// <returns>Collection with the images of the tv.</returns>
		Task<ImageCollection> GetImagesAsync(int id, string language = "");

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
		/// <param name="language">Video language.</param>
		/// <returns>Array of videos.</returns>
		Task<Video[]> GetVideosAsync(int id, string language = "");

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
		/// <param name="language">Language of result.</param>
		/// <returns>Collection of recommendations.</returns>
		Task<PagedResult<TVSearchItem>> GetRecommendationsAsync(int id, int page = 0, string language = "");

		/// <summary>
		/// Gets the similar tvs.
		/// </summary>
		/// <param name="id">Tv identifier.</param>
		/// <param name="page">Similar tvs page number.</param>
		/// <param name="language">Language of the result.</param>
		/// <returns>Collection of similar tvs.</returns>
		Task<PagedResult<TVSearchItem>> GetSimilarTVsAsync(int id, int page = 0, string language = "");
	}
}