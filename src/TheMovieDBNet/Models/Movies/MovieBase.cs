using Newtonsoft.Json;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models.Movies
{
    
    /// <summary>
    /// Represents base class for object containing info about movies.
    /// </summary>
    public class MovieBase : Entity
    {
        /// <summary>
        /// indicates whether the movie is an adult one or not
        /// </summary>
        public bool Adult { get; set; }
        
        /// <summary>
        /// original language of the movie
        /// </summary>
        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        /// <summary>
        /// title of the movie in original language
        /// </summary>
        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }
        
        /// <summary>
        /// popularity of the movie
        /// </summary>
        public double Popularity { get; set; }

        /// <summary>
        /// path to the poster image
        /// </summary>
        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        /// <summary>
        /// path to the backdrop
        /// </summary>
        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        /// <summary>
        /// overview of the movie's plot
        /// </summary>
        public string Overview { get; set; }

        /// <summary>
        /// title of the movie
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// show whether this is a video or movie
        /// </summary>
        public bool Video { get; set; }

        /// <summary>
        /// average rating of the movie
        /// </summary>
        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        /// <summary>
        /// vote counts for the movie
        /// </summary>
        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }
        
        /// <summary>
        /// realease date of the movie
        /// </summary>
        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

    }
}