using Newtonsoft.Json;

namespace TheMovieDbNet.Models.People
{
	/// <summary>
	/// Represents the person's credits.
	/// </summary>
	public class PersonCredits
	{
		[JsonConstructor]
		internal PersonCredits(int id)
		{
			Id = id;
		}

		/// <summary>
		/// Gets the id of the person credits belong to.
		/// </summary>
		public int Id { get; }
		/// <summary>
		/// Gets the movie person participated in cast.
		/// </summary>
		public PersonMovieCast[] MovieCast { get; set; }
		/// <summary>
		/// Gets the movie person participated in as crew.
		/// </summary>
		public PersonMovieCrew[] MovieCrew { get; set; }
		/// <summary>
		/// Gets the tv person participated in cast.
		/// </summary>
		public PersonTVCast[] TVCast { get; set; }
		/// <summary>
		/// Gets the tv person participated in as crew.
		/// </summary>
		public PersonTVCrew[] TVCrew { get; set; }
	}
}