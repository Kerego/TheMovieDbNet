using Newtonsoft.Json;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models.Movies
{
    /// <summary>
    /// Represents the complete movie details 
    /// </summary>
    public class Movie : MovieBase
    {
        /// <summary>
        /// id of the movie on the IMDB Site
        /// </summary>
        [JsonProperty("imdb_id")]
        public string ImdbId { get; set; }

        /// <summary>
        /// budget of the movie
        /// </summary>
        public int Budget { get; set; }

        /// <summary>
        /// homepage of the movie
        /// </summary>
        public string Homepage { get; set; }
        /// <summary>
        /// info about the collection of movies the one belongs to
        /// </summary>
        [JsonProperty("belongs_to_collection")]
        public MoviesCollection MovieCollection { get; set; }

        /// <summary>
        /// info about the genres of the movie
        /// </summary>
        public Genre[] Genres { get; set; }


        /// <summary>
        /// info about the companies that produced the movie
        /// </summary>
        [JsonProperty("production_companies")]
        public ProductionCompany[] ProductionCompanies { get; set; }

        /// <summary>
        /// info about countries that produced the movie
        /// </summary>
        [JsonProperty("production_countries")]
        public ProductionCountry[] ProductionCountries { get; set; }


        /// <summary>
        /// total revenue of the movie in $
        /// </summary>
        public int Revenue { get; set; }

        /// <summary>
        /// total runtime of the movie in minutes
        /// </summary>
        public int? Runtime { get; set; }

        /// <summary>
        /// array of languages that are spoke in the movie
        /// </summary>
        [JsonProperty("spoken_languages")]
        public SpokenLanguage[] SpokenLanguages { get; set; }

        /// <summary>
        /// relese status of the movie
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// tagline of the movie
        /// </summary>
        public string Tagline { get; set; }
        
        /// <summary>
        /// videos of the movie
        /// </summary>
        [JsonIgnore]
        public Video[] Videos { get; set; }

        /// <summary>
        /// backdrop images
        /// </summary>
        [JsonIgnore]
        public Image[] Backdrops { get; set; }

        /// <summary>
        /// poster images
        /// </summary>
        [JsonIgnore]
        public Image[] Posters { get; set; }

        /// <summary>
        /// Gets or Sets the credits for the movie.
        /// </summary>
        public MovieCredits Credits { get; set; }

        /// <summary>
        /// Gets or Sets alternative titles for the movie.
        /// </summary>
        public AlternativeTitles AlternativeTitles { get; set; }
    }
}