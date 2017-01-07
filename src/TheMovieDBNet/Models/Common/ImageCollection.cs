using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Common
{
    /// <summary>
    /// Represents the images collection of media.
    /// </summary>
    public class ImageCollection
    {
        [JsonConstructor]
        internal ImageCollection(int id, Image[] posters, Image[] backdrops)
        {
            Id = id;
            Posters = posters;
            Backdrops = backdrops;
        }

        /// <summary>
        /// Gets the id of the media images belong to.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Gets the poster image collection
        /// </summary>
        public Image[] Posters { get; }
        /// <summary>
        /// Gets the backdrops image collection
        /// </summary>
        public Image[] Backdrops { get; }
    }
}