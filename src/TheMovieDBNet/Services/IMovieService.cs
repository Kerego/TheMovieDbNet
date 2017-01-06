using System.Threading.Tasks;
using TheMovieDbNet.Models;
using TheMovieDbNet.Models.Common;
using TheMovieDbNet.Models.Movies;

namespace TheMovieDbNet.Services
{

    /// <summary>
    /// Represents abstraction for requesting movie-related data from database.
    /// </summary>
    public interface IMovieService
    {
        /// <summary>
        /// Gets details of a movie.
        /// </summary>
        /// <param name="id">Movie identifier.</param>
        /// <param name="append">Additional info to append to the response (eg: images, videos).</param>
        /// <returns>Object of type Movie with fields filled with data.</returns>
        Task<Movie> Get(int id, string append);
        
        /// <summary>
        /// Gets details of a movie.
        /// </summary>
        /// <param name="id">Movie identifier.</param>
        /// <param name="settings">Additional info to append to the response (eg: images, videos).</param>
        /// <returns>Object of type Movie with fields filled with data.</returns>
        Task<Movie> Get(int id, MovieAppendSettings settings);
        /// <summary>
        /// Gets a page of movies based on search query.
        /// </summary>
        /// <param name="query">Name of the movie.</param>
        /// <returns>Search Result with movies and page data.</returns>
        Task<SearchResult<MovieSearchItem>> Search(string query);
        /// <summary>
        /// Gets a page of movies based on search query.
        /// </summary>
        /// <param name="query">Name of the movie.</param>
        /// <param name="page">Number of page for search</param>
        /// <returns>Search Result with movies and page data.</returns>
        Task<SearchResult<MovieSearchItem>> Search(string query, int page);
        /// <summary>
        /// Gets a page of movies based on search query.
        /// </summary>
        /// <param name="settings">Settings class for detailed search</param>
        /// <returns>Search Result with movies and page data.</returns>
        Task<SearchResult<MovieSearchItem>> Search(MovieSearchSettings settings);

    }

}