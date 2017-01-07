using Newtonsoft.Json;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models.People
{
	/// <summary>
	/// Represents data about person crew appearances.
	/// </summary>
	public class PersonCrew : Crew
	{
		
		[JsonConstructor]
		internal PersonCrew(
			int id, 
			string credit_id,
			string department,
			string job,
			string poster_path) : base(id, credit_id, department, job)
		{
			PosterPath = poster_path;
		}


		/// <summary>
		/// Gets the path to the poster image.
		/// </summary>
		public string PosterPath { get; }
		
	}
}