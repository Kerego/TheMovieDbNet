using Newtonsoft.Json;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models.Movies
{
	/// <summary>
	/// Represents the data about a movie crew member.
	/// </summary>
	public class MovieCrew : Crew
	{
		[JsonConstructor]
		internal MovieCrew(
			int id,
			string credit_id, 
			string department, 
			string job,
			string name,
			string profile_path) : base(id, credit_id, department, job)
		{
			Name = name;
			ProfilePath = profile_path;
		}

		/// <summary>
		/// Gets the name of the person.
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Gets the path to the profile of person.
		/// </summary>
		public string ProfilePath { get; }
	}
}