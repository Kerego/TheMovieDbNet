using Newtonsoft.Json;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models.Movies
{
    
    /// <summary>
    /// Represents base class for object containing info about movies.
    /// </summary>
    public class MovieBase : Entity
    {
        internal MovieBase(
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
            string release_date        
        ) : base(id)
        {
            Adult = adult;
            OriginalLanguage = original_language;
            OriginalTitle = original_title;
            Popularity = popularity;
            PosterPath = poster_path;
            BackdropPath = backdrop_path;
            Overview = overview;
            Title = title;
            Video = video;
            VoteAverage = vote_average;
            VoteCount = vote_count;
            ReleaseDate = release_date;
        }

        /// <summary>
        /// Gets whether the movie is an adult one or not.
        /// </summary>
        public bool Adult { get; }
        
        /// <summary>
        /// Gets the original language of the movie.
        /// </summary>
        public string OriginalLanguage { get; }

        /// <summary>
        /// Gets the title of the movie in original language.
        /// </summary>
        public string OriginalTitle { get; }
        
        /// <summary>
        /// Gets the popularity of the movie.
        /// </summary>
        public double Popularity { get; }

        /// <summary>
        /// Gets the path to the poster image.
        /// </summary>
        public string PosterPath { get; }

        /// <summary>
        /// Gets the path to the backdrop.
        /// </summary>
        public string BackdropPath { get; }

        /// <summary>
        /// Gets the overview of the movie's plot.
        /// </summary>
        public string Overview { get; }

        /// <summary>
        /// Gets the title of the movie.
        /// </summary>
        public string Title { get; }
        
        /// <summary>
        /// Gets whether this is a video or movie.
        /// </summary>
        public bool Video { get; }

        /// <summary>
        /// Gets the average rating of the movie.
        /// </summary>
        public double VoteAverage { get; }

        /// <summary>
        /// Gets the vote counts for the movie.
        /// </summary>
        public int VoteCount { get; }
        
        /// <summary>
        /// Gets the realease date of the movie.
        /// </summary>
        public string ReleaseDate { get; }

    }
}