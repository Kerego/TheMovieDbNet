using Newtonsoft.Json;

namespace TheMovieDbNet.Models.People
{
	/// <summary>
	/// Reprsents the combined credits for both tv and movies for a person.
	/// </summary>
	public class PersonCombinedCredits
	{
		internal PersonCombinedCredits(int id)
		{
			Id = id;
		}

		/// <summary>
		/// Gets the person identifier.
		/// </summary>
		public int Id { get; set; }
		
		/// <summary>
		/// Gets or Sets the persons movie casts.
		/// </summary>
		[JsonIgnore]
		public PersonMovieCast MovieCast { get; set; }
		/// <summary>
		/// Gets or Sets the person tv casts.
		/// </summary>
		[JsonIgnore]
		public PersonTVCast TVCast { get; set; }

		/// <summary>
		/// Gets or Sets the person tv crew appearances.
		/// </summary>
		[JsonIgnore]
		public PersonMovieCrew MovieCrew { get; set; }

		/// <summary>
		/// Gets or Sets the person tv crew appearances.
		/// </summary>
		[JsonIgnore]
		public PersonTVCrew TVCrew { get; set; }
	}
}