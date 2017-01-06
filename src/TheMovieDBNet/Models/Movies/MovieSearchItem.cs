using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Movies
{
    /// <summary>
    /// Represents an item from movies search.
    /// </summary>
    public class MovieSearchItem : MovieBase
    {
        /// <summary>
        /// Gets or Sets an array of genre ids movie belongs to.
        /// </summary>
        /// <returns></returns>
        [JsonProperty("genre_ids")]
        public int[] GenreIds { get; set; }
    }
}