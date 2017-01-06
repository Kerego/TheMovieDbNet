using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Common
{
    /// <summary>
    /// Represents a title of a media in a specific language.
    /// </summary>
    public class TranslatedTitle
    {
        /// <summary>
        /// Gets or Sets the language of the title.
        /// </summary>
        [JsonProperty("iso_3166_1")]
        public string Iso31661 { get; set; }
        /// <summary>
        /// Gets or Sets the title of the media.
        /// </summary>
        public string Title { get; set; }
    }

}