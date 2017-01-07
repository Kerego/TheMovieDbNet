using Newtonsoft.Json;
using TheMovieDbNet.Models.Movies;
using TheMovieDbNet.Models.TVs;

namespace TheMovieDbNet.Models.People
{
	/// <summary>
	/// Represents an item from people search.
	/// </summary>
	public class PeopleSearchItem : PersonBase
	{
		[JsonConstructor]
		internal PeopleSearchItem(
			int id,
			string profile_path,
			bool adult,
			string name,
			double popularity)
		: base(id, profile_path, adult, name, popularity)
		{
		}
		
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