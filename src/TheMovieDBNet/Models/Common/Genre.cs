using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Common
{
    /// <summary>
    /// Represents info about genre of movie.
    /// </summary>
    public class Genre : Entity
    {
        [JsonConstructor]
        internal Genre(string name, int id) : base(id)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the name of the genre.
        /// </summary>
        public string Name { get; }
    }
}