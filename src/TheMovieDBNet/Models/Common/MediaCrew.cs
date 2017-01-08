using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Common
{
	/// <summary>
	/// Represents the data about a media crew member.
	/// </summary>
	public class MediaCrew : Crew
	{
		[JsonConstructor]
		internal MediaCrew(
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