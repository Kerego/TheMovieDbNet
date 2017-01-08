using Newtonsoft.Json;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models.TVs
{
	/// <summary>
	/// Represents a person that creates tv series.
	/// </summary>
	public class TVCreator : Entity
	{
		[JsonConstructor]
		internal TVCreator(int id, string name, string profile_path) : base(id)
		{
			Name = name;
			ProfilePath = profile_path;
		}
		/// <summary>
		/// Gets the name of the creator.
		/// </summary>
		public string Name { get; }
		/// <summary>
		/// Gets the profile photo path of the creator.
		/// </summary>
		public string ProfilePath { get; }

	}
}