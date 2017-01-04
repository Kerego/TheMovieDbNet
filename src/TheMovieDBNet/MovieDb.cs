using System;

namespace TheMovieDbNet
{
    /// <summary>
    /// Basic class for doing request to movie database
    /// </summary>
    public class MovieDb
    {
        private readonly string _apiKey;
        
        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="apiKey">Api key from TheMovieDb developer site</param>
        MovieDb(string apiKey)
        {
            _apiKey = apiKey;
        }
    }
}