using Newtonsoft.Json;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models.People
{
	/// <summary>
	/// Represents data about person cast.
	/// </summary>
	public class PersonCast : Cast
	{
		[JsonConstructor]
		internal PersonCast(
			int id,
			string character,
			string credit_id,
			string poster_path) : base(id, character, credit_id)
		{
			PosterPath = poster_path;
		}

		/// <summary>
		/// Gets the path to the poster image.
		/// </summary>
		public string PosterPath { get; }
		
	}
}