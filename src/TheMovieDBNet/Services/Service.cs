using System;
using System.Net.Http;

namespace TheMovieDbNet.Services
{
    /// <summary>
    /// Represents a base service for making requests to the movie database
    /// </summary>
    public abstract class Service
    {
        /// <summary>
        /// Client for making http requests
        /// </summary>
        protected readonly HttpClient httpClient = new HttpClient();
        
        /// <summary>
        /// PI key from the movie db developer site
        /// </summary>
        protected readonly string apiKey;

        /// <summary>
        /// Initializes a new instance of the Service class.
        /// </summary>
        /// <param name="apiKey">API key from the movie db developer site</param>
        public Service(string apiKey)
        {
            this.apiKey = apiKey;
            httpClient.BaseAddress = new Uri("https://api.themoviedb.org/3/");
        }
    }
}