using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Common
{
    /// <summary>
    /// Represents data about release along with country of release.
    /// </summary>
    public class ReleaseInfo 
    {
        [JsonConstructor]
        internal ReleaseInfo(string iso_3166_1, ReleaseDate[] release_dates)
        {
            Iso31661 = iso_3166_1;
            ReleaseDates = release_dates;
        }

        /// <summary>
        /// Gets the iso_3166_1 country.
        /// </summary>
        public string Iso31661 { get; }
        /// <summary>
        /// Gets the release date.
        /// </summary>
        public ReleaseDate[] ReleaseDates { get; }
    }
}