using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Movies
{
    /// <summary>
    /// info about country that produces movies
    /// </summary>
    public class ProductionCountry
    {
        /// <summary>
        /// iso_3166_1 name of country
        /// </summary>
        [JsonProperty("iso_3166_1")]
        public string Iso31661 { get; set; }

        /// <summary>
        /// name of the country
        /// </summary>
        public string Name { get; set; }
    }

}