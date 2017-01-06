using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Common
{
    /// <summary>
    /// info about a language spoken in a movie
    /// </summary>
    public class SpokenLanguage
    {
        /// <summary>
        /// iso_639_1 name of language
        /// </summary>
        [JsonProperty("iso_639_1")]
        public string Iso6391 { get; set; }

        /// <summary>
        /// human name of language
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}