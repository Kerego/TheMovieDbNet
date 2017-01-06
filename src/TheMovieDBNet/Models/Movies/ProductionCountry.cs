using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Movies
{
    /// <summary>
    /// Represents a country that produces movies
    /// </summary>
    public class ProductionCountry
    {
        [JsonConstructor]
        internal ProductionCountry(string iso_3166_1, string name)
        {
            Iso31661 = iso_3166_1;
            Name = name;
        }
        /// <summary>
        /// Gets the iso_3166_1 name of country
        /// </summary>
        public string Iso31661 { get; }

        /// <summary>
        /// Gets the name of the country
        /// </summary>
        public string Name { get; }
    }

}