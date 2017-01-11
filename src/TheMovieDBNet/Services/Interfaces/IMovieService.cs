using System;
using System.Threading.Tasks;
using TheMovieDbNet.Models.Common;
using TheMovieDbNet.Models.Movies;

namespace TheMovieDbNet.Services
{

	/// <summary>
	/// Represents abstraction for requesting movie-related data from database.
	/// </summary>
	public interface IMovieService : IDisposable
	{
		/// <summary>
		/// Gets the mosty newly created movie.
		/// </summary>
		/// <param name="language">Language of the result.</param>
		/// <returns>Object of type Movie with filled details.</returns>
		Task<Movie> GetLatestAsync(string language = "");

		/// <summary>
		/// Gets the list of upcoming movies.
		/// </summary>
		/// <param name="page">Page of results.</param>
		/// <param name="region">Region of the theatres.</param>
		/// <param name="language">Language of the result.</param>
		/// <returns>A page of the dated results.</returns>
		Task<DatedPagedResult<MovieSearchItem>> GetUpcomingAsync(int page = 0, string region = "", string language = "");

		/// <summary>
		/// Gets the list of movies in theatres.
		/// </summary>
		/// <param name="page">Page of results.</param>
		/// <param name="region">Region of the theatres.</param>
		/// <param name="language">Language of the result.</param>
		/// <returns>A page of the dated results.</returns>
		Task<DatedPagedResult<MovieSearchItem>> GetNowPlayingAsync(int page = 0, string region = "", string language = "");
		
		/// <summary>
		/// Gets the list of popular movies.
		/// </summary>
		/// <param name="page">Page of results.</param>
		/// <param name="region">Region to search.</param>
		/// <param name="language">Language of the result.</param>
		/// <returns>A page of the dated results.</returns>
		Task<PagedResult<MovieSearchItem>> GetPopularAsync(int page = 0, string region = "", string language = "");

		/// <summary>
		/// Gets the list of top rated movies.
		/// </summary>
		/// <param name="page">Page of results.</param>
		/// <param name="region">Region to search.</param>
		/// <param name="language">Language of the result.</param>
		/// <returns>A page of the dated results.</returns>
		Task<PagedResult<MovieSearchItem>> GetTopRatedAsync(int page = 0, string region = "", string language = "");

		/// <summary>
		/// Gets details of a movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <param name="append">Additional info to append to the response (eg: images, videos).</param>
		/// <returns>Object of type Movie with fields filled with data.</returns>
		Task<Movie> GetDetailsAsync(int id, string append = "");
		
		/// <summary>
		/// Gets details of a movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <param name="settings">Additional info to append to the response (eg: images, videos).</param>
		/// <returns>Object of type Movie with fields filled with data.</returns>
		Task<Movie> GetDetailsAsync(int id, MovieAppendSettings settings);

		/// <summary>
		/// Gets translated titles of the movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <param name="country">Country of translation (eg: es, pt).</param>
		/// <returns>Array of Alternative Titles for movie.</returns>
		Task<AlternativeTitle[]> GetAlternativeTitlesAsync(int id, string country = ""); 

		/// <summary>
		/// Gets the cast and crew of the movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <returns>Credits of the movie.</returns>
		Task<MediaCredits> GetCreditsAsync(int id);

		/// <summary>
		/// Gets the images of the movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <param name="language">Language of the image.</param>
		/// <param name="includeLanguages">Additional Languages to add to the image.</param>
		/// <returns>Collection with the images of the movie.</returns>
		Task<ImageCollection> GetImagesAsync(int id, string language = "", string includeLanguages = "");

		/// <summary>
		/// Gets the keywords of the movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <returns>Array of the keywords.</returns>
		Task<Keyword[]> GetKeywordsAsync(int id);

		/// <summary>
		/// Gets the release info of the movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <returns>Array of release infos.</returns>
		Task<ReleaseInfo[]> GetReleaseInfoAsync(int id);

		/// <summary>
		/// Gets the videos of the movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <param name="language">Video language.</param>
		/// <returns>Array of videos.</returns>
		Task<Video[]> GetVideosAsync(int id, string language = "");

		/// <summary>
		/// Gets the translations of the movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <returns>Array of translations.</returns>
		Task<Translation[]> GetTranslationsAsync(int id);

		/// <summary>
		/// Gets the recommendations for the movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <param name="page">Recommendations page number.</param>
		/// <param name="language">Movie language.</param>
		/// <returns>Collection of recommendations.</returns>
		Task<PagedResult<MovieSearchItem>> GetRecommendationsAsync(int id, int page = 0, string language = "");

		/// <summary>
		/// Gets the similar movies.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <param name="page">Similar movies page number.</param>
		/// <param name="language">Movie language.</param>
		/// <returns>Collection of similar movies.</returns>
		Task<PagedResult<MovieSearchItem>> GetSimilarMoviesAsync(int id, int page = 0, string language = "");

		/// <summary>
		/// Gets a page of movies based on search query.
		/// </summary>
		/// <param name="query">Name of the movie.</param>
		/// <param name="page">Number of page for search</param>
		/// <returns>Search Result with movies and page data.</returns>
		Task<PagedResult<MovieSearchItem>> SearchAsync(string query, int page = 0);

		/// <summary>
		/// Gets a page of movies based on search query.
		/// </summary>
		/// <param name="settings">Settings class for detailed search</param>
		/// <returns>Search Result with movies and page data.</returns>
		Task<PagedResult<MovieSearchItem>> SearchAsync(MovieSearchSettings settings);
	}
}