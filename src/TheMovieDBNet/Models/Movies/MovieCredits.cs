using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Movies
{
	/// <summary>
	/// Represents the movie credits.
	/// </summary>
	public class MovieCredits
	{
		[JsonConstructor]
		internal MovieCredits(int id, MovieCast[] cast, MovieCrew[] crew)
		{
			Id = id;
			Cast = cast;
			Crew = crew;
		}
		/// <summary>
		/// Gets the id of the movie credits belong to.
		/// </summary>
		public int Id { get; }
		/// <summary>
		/// Gets the cast of the movie.
		/// </summary>
		public MovieCast[] Cast { get; }
		/// <summary>
		/// Gets the crew of the movie.
		/// </summary>
		public MovieCrew[] Crew { get; }
	}
}