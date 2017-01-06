namespace TheMovieDbNet.Models.Common
{
    /// <summary>
    /// Represents a collection of alternative titles for a media.
    /// </summary>
    public class AlternativeTitles : Entity
    {
        /// <summary>
        /// Gets or Sets the array of titles translated in different languages
        /// </summary>
        public TranslatedTitle[] Titles { get; set; }
    }

}