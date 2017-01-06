using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Common
{
    /// <summary>
    /// Represents a title of a media in a specific language.
    /// </summary>
    public class AlternativeTitle
    {
        [JsonConstructor]
        internal AlternativeTitle(string iso_3166_1, string title)
        {
            Iso31661 = iso_3166_1;
            Title = title;
        }
        /// <summary>
        /// Gets the language of the title.
        /// </summary>
        public string Iso31661 { get; }
        /// <summary>
        /// Gets the title of the media.
        /// </summary>
        public string Title { get; }
    }

}