using Newtonsoft.Json;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models.Movies
{
    /// <summary>
    /// Represents the complete movie details.
    /// </summary>
    public class Movie : MovieBase
    {
        [JsonConstructor]
        internal Movie(
            int id, 
            bool adult, 
            string original_language, 
            string original_title, 
            double popularity, 
            string poster_path, 
            string backdrop_path, 
            string overview, 
            string title, 
            bool video, 
            double vote_average, 
            int vote_count, 
            string release_date,
            string imdb_id,
            int budget,
            string homepage,
            MoviesCollection belongs_to_collection,
            Genre[] genres,
            ProductionCompany[] production_companies,
            ProductionCountry[] production_countries,
            int revenue,
            int? runtime,
            SpokenLanguage[] spoken_languages,
            string status,
            string tagline) : base( id, 
                                    adult, 
                                    original_language, 
                                    original_title, 
                                    popularity, 
                                    poster_path, 
                                    backdrop_path, 
                                    overview, 
                                    title, 
                                    video, 
                                    vote_average, 
                                    vote_count, 
                                    release_date)
        {
            ImdbId = imdb_id;
            Budget = budget;
            Homepage = homepage;
            MovieCollection = belongs_to_collection;
            Genres = genres;
            ProductionCompanies = production_companies;
            ProductionCountries = production_countries;
            Revenue = revenue;
            Runtime = runtime;
            SpokenLanguages = spoken_languages;
            Status = status;
            Tagline = tagline;
        }

        /// <summary>
        /// Gets the id of the movie on the IMDB Site.
        /// </summary>
        public string ImdbId { get; }

        /// <summary>
        /// Gets the budget of the movie.
        /// </summary>
        public int Budget { get; }

        /// <summary>
        /// Gets the homepage of the movie.
        /// </summary>
        public string Homepage { get; }
        /// <summary>
        /// Gets the info about the collection of movies the one belongs to.
        /// </summary>
        public MoviesCollection MovieCollection { get; }

        /// <summary>
        /// Gets the info about the genres of the movie.
        /// </summary>
        public Genre[] Genres { get; }

        /// <summary>
        /// Gets the info about the companies that produced the movie.
        /// </summary>
        public ProductionCompany[] ProductionCompanies { get; }

        /// <summary>
        /// Gets the info about countries that produced the movie.
        /// </summary>
        public ProductionCountry[] ProductionCountries { get; }

        /// <summary>
        /// Gets the total revenue of the movie in $.
        /// </summary>
        public int Revenue { get; }

        /// <summary>
        /// Gets the total runtime of the movie in minutes.
        /// </summary>
        public int? Runtime { get; }

        /// <summary>
        /// Gets the array of languages that are spoke in the movie.
        /// </summary>
        public SpokenLanguage[] SpokenLanguages { get; }

        /// <summary>
        /// Gets the relese status of the movie.
        /// </summary>
        public string Status { get; }

        /// <summary>
        /// Gets the tagline of the movie.
        /// </summary>
        public string Tagline { get;}
        

        /// <summary>
        /// Gets or Sets the videos of the movie.
        /// </summary>
        [JsonIgnore]
        public Video[] Videos { get; set; }

        /// <summary>
        /// Gets or Sets the backdrop images.
        /// </summary>
        [JsonIgnore]
        public Image[] Backdrops { get; set; }

        /// <summary>
        /// Gets or Sets the poster images.
        /// </summary>
        [JsonIgnore]
        public Image[] Posters { get; set; }

        /// <summary>
        /// Gets or Sets cast of the movie.
        /// </summary>
        [JsonIgnore]
        public MovieCast[] Cast { get; set; }

        /// <summary>
        /// Gets or Sets crew of the movie.
        /// </summary>
        [JsonIgnore]
        public MovieCrew[] Crew { get; set;}

        /// <summary>
        /// Gets or Sets alternative titles for the movie.
        /// </summary>
        [JsonIgnore]
        public AlternativeTitle[] AlternativeTitles { get; set; }

        /// <summary>
        /// Gets or Sets the keywords of the movie.
        /// </summary>
        [JsonIgnore]
        public Keyword[] Keywords { get; set; }

        /// <summary>
        /// Gets or Sets the release info of the movie.
        /// </summary>
        [JsonIgnore]
        public ReleaseInfo[] ReleaseInfo { get; set; }

        /// <summary>
        /// Gets or Sets available translation for the movie.
        /// </summary>
        [JsonIgnore]
        public Translation[] Translations { get; set; }
    }
}