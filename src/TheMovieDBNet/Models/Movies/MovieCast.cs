using Newtonsoft.Json;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models.Movies
{
	/// <summary>
	/// Represents data about cast of a movie.
	/// </summary>
	public class MovieCast : Cast
	{
		
		[JsonConstructor]
		internal MovieCast(
			int id, 
			string character, 
			string credit_id,
			int cast_id,
			string name,
			int order,
			string profile_path) : base(id, character, credit_id)
		{
			CastId = cast_id;
			Name = name;
			Order = order;
			ProfilePath = profile_path;
		}

		/// <summary>
		/// Gets the identifier of the cast.
		/// </summary>
		public int CastId { get; }

		/// <summary>
		/// Gets the name of the person.
		/// </summary>
		public string Name { get;}

		/// <summary>
		/// Gets the order of cast.
		/// </summary>
		public int Order { get;  }

		/// <summary>
		/// Gets the path to profile of the person.
		/// </summary>
		public string ProfilePath { get; }
	}
}