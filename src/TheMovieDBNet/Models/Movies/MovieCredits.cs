namespace TheMovieDbNet.Models.Movies
{
    /// <summary>
    /// Represents the movie credits.
    /// </summary>
    public class MovieCredits
    {
        /// <summary>
        /// Gets or Sets the id of the movie credits belong to.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or Sets the cast of the movie.
        /// </summary>
        public MovieCast[] Cast { get; set; }
        /// <summary>
        /// Gets or Sets the crew of the movie.
        /// </summary>
        public MovieCrew[] Crew { get; set; }
    }
}