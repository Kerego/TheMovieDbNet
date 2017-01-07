using Newtonsoft.Json;
using TheMovieDbNet.Models.Common;
using TheMovieDbNet.Models.Movies;
using TheMovieDbNet.Models.TVs;

namespace TheMovieDbNet.Models.People
{
	/// <summary>
	/// Represents an item from people search.
	/// </summary>
	public class PeopleSearchItem : Entity
	{
		[JsonConstructor]
		internal PeopleSearchItem(
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
		
		/// <summary>
		/// Gets or Sets the movies person is known for.
		/// </summary>
		[JsonIgnore]
		public MovieSearchItem[] MoviesKnownFor { get; set; }

		/// <summary>
		/// Gets or Sets the tv series person is known for.
		/// </summary>
		[JsonIgnore]
		public TVSearchItem[] TVsKnownFor { get; set; } 
	}
}