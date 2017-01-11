using Newtonsoft.Json;
using TheMovieDbNet.Models.Common;
using TheMovieDbNet.Models.Movies;

namespace TheMovieDbNet.Models.Collections
{
	/// <summary>
	/// Represents a collection of movies.
	/// </summary>
	public class MovieCollection : MovieCollectionSearchItem
	{
		[JsonConstructor]
		internal MovieCollection(
			int id,
			string name,
			string poster_path,
			string backdrop_path,
			string overview,
			MovieSearchItem[] parts) : base(id, name, poster_path, backdrop_path)
		{
			Overview = overview;
			Parts = parts;
		}
		/// <summary>
		/// Gets the overview of the collection.
		/// </summary>
		public string Overview { get; }

		/// <summary>
		/// Gets the movies that belong to the collection.
		/// </summary>
		public MovieSearchItem[] Parts { get; }
	}
}