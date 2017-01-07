using Newtonsoft.Json;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models.People
{
	/// <summary>
	/// Represents the base person info.
	/// </summary>
	public class PersonBase : Entity
	{
		[JsonConstructor]
		internal PersonBase(
			int id,
			string profile_path,
			bool adult,
			string name,
			double popularity) : base(id)
		{
			ProfilePath = profile_path;
			Adult = adult;
			Name = name;
			Popularity = popularity;
		}

		/// <summary>
		/// Gets the path to the profile picture.
		/// </summary>
		public string ProfilePath { get; }

		/// <summary>
		/// Gets whether actor was involved in adult industry.
		/// </summary>
		public bool Adult { get; }

		/// <summary>
		/// Gets the name of the person.
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Gets the popularity of the person
		/// </summary>
		public double Popularity { get; }
	}
}