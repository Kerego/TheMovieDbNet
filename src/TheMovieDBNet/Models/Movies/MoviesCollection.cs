using Newtonsoft.Json;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models.Movies
{    
    /// <summary>
    /// info about a collection of movies
    /// </summary>
    public class MoviesCollection : Entity
    {
        /// <summary>
        /// name of the collection
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// path to the poster image
        /// </summary>
        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        /// <summary>
        /// path to the backdrop
        /// </summary>
        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }
    }
}