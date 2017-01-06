using Newtonsoft.Json;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models.Movies
{
    /// <summary>
    /// Represents the data about a movie crew member.
    /// </summary>
    public class MovieCrew : Crew
    {
        /// <summary>
        /// Gets or Sets the name of the person.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets the path to the profile of person.
        /// </summary>
        [JsonProperty("profile_path")]
        public string ProfilePath { get; set; }
    }
}