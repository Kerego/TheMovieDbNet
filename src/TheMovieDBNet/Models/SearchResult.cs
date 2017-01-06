using Newtonsoft.Json;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models
{
    /// <summary>
    /// Represents a generic class that holds data about a search.
    /// </summary>
    public class SearchResult<T> where T : Entity
    {
        /// <summary>
        /// Gets or Sets an array of resulting entities.
        /// </summary>
        public T[] Results { get; set; }

        /// <summary>
        /// Gets or Sets total number of results available.
        /// </summary>
        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        /// <summary>
        /// Gets or Sets total number of pages available.
        /// </summary>
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
        /// <summary>
        /// Gets or Sets current page of the result.
        /// </summary>
        public int Page { get; set; }
    }
}