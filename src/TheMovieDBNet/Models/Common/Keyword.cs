using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Common
{
    /// <summary>
    /// Represents a keyword from a media.
    /// </summary>
    public class Keyword : Entity
    {
        [JsonConstructor]
        internal Keyword(string name, int id) : base(id)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the value of keyword.
        /// </summary>
        public string Name { get; }
    }
}