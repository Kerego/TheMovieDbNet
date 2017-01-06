using Newtonsoft.Json;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models.Movies
{
    /// <summary>
    /// Represents data about cast of a movie.
    /// </summary>
    public class MovieCast : Cast
    {
        /// <summary>
        /// Gets or Sets identifier of the cast.
        /// </summary>
        [JsonProperty("cast_id")]
        public int CastId { get; set; }

        /// <summary>
        /// Gets or Sets the name of the person.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets the name of the order.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Gets or Sets the path to the profile of the person
        /// </summary>
        [JsonProperty("profile_path")]
        public string ProfilePath { get; set; }
    }
}