using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TheMovieDbNet.Models;

namespace TheMovieDbNet
{
    /// <summary>
    /// Basic class for doing request to movie database
    /// </summary>
    public class MovieDb
    {
        private readonly string _baseAddress = "https://api.themoviedb.org/3/";
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;
        
        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="apiKey">Api key from TheMovieDb developer site</param>
        public MovieDb(string apiKey)
        {
            _apiKey = apiKey;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseAddress);
        }
        /// <summary>
        /// Method to get details of a movie
        /// </summary>
        /// <param name="id">id of the movie</param>
        /// <returns>Details of the movie</returns>
        public async Task<Movie> GetDetailsAsync(int id) 
        {
            var path = $"/3/movie/{id}?api_key={_apiKey}&append_to_response=images,videos";
            var json = await _httpClient.GetStringAsync(path);
            var movie = JsonConvert.DeserializeObject<Movie>(json, new MovieConverter());
            return movie;
        }

    }
}