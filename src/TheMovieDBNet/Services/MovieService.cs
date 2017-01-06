using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TheMovieDbNet.Models;
using TheMovieDbNet.Models.Movies;

namespace TheMovieDbNet.Services
{
    /// <summary>
    /// Represents a service for accessing movie-related data.
    /// </summary>
    public class MovieService : Service, IMovieService
    {
        /// <summary>
        /// Initializes a new instance of MovieService.
        /// </summary>
        /// <param name="apiKey">API key from the movie db developer site</param>
        public MovieService(string apiKey) : base(apiKey)
        {
        }


        /// <summary>
        /// Gets details of the movie.
        /// </summary>
        /// <param name="id">Movie identifier.</param>
        /// <param name="append">Additional info to append to the response (eg: images, videos).</param>
        /// <returns>Object of type Movie with fields filled with data.</returns>
        public async Task<Movie> Get(int id, string append)
        {
            var path = $"/3/movie/{id}?api_key={apiKey}&append_to_response={append}";
            using (var result = await httpClient.GetAsync(path)){
                var content = await result.Content.ReadAsStringAsync();
                if(!result.IsSuccessStatusCode)
                    throw new Exception(content); //TODO use specific exception not the base
                return JsonConvert.DeserializeObject<Movie>(content, new MovieConverter());
            }
        }
        
        /// <summary>
        /// Gets details of the movie.
        /// </summary>
        /// <param name="id">Movie identifier.</param>
        /// <param name="settings">Additional info to append to the response (eg: images, videos).</param>
        /// <returns>Object of type Movie with fields filled with data.</returns>
        public Task<Movie> Get(int id, MovieAppendSettings settings) => Get(id, settings.ToString());
        
        /// <summary>
        /// Gets a page of movies based on search query.
        /// </summary>
        /// <param name="settings">Settings class for detailed search</param>
        /// <returns>Search Result with movies and page data.</returns>
        public async Task<SearchResult<MovieSearchItem>> Search(MovieSearchSettings settings)
        {
            var path = $"/3/search/movie?api_key={apiKey}{settings}";
            using (var result = await httpClient.GetAsync(path)){
                var content = await result.Content.ReadAsStringAsync();
                if(!result.IsSuccessStatusCode)
                    throw new Exception(content); //TODO use specific exception not the base
                return JsonConvert.DeserializeObject<SearchResult<MovieSearchItem>>(content);
            }
        }

        /// <summary>
        /// Gets a page of movies based on search query.
        /// </summary>
        /// <param name="query">Name of the movie.</param>
        /// <returns>Search Result with movies and page data.</returns>
        public async Task<SearchResult<MovieSearchItem>> Search(string query)
        {
            var settings = new MovieSearchSettings
            {
                Query = query,
                Page = 1
            };
            return await Search(settings);
        }

        /// <summary>
        /// Gets a page of movies based on search query.
        /// </summary>
        /// <param name="query">Name of the movie.</param>
        /// <param name="page">Number of page for search</param>
        /// <returns>Search Result with movies and page data.</returns>
        public async Task<SearchResult<MovieSearchItem>> Search(string query, int page)
        {
            var settings = new MovieSearchSettings
            {
                Query = query,
                Page = page
            };
            return await Search(settings);
        }
    }
}