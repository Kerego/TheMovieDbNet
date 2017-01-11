using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Common
{
	/// <summary>
	/// Represents an item from the movie collection search.
	/// </summary>
	public class MovieCollectionSearchItem : Entity
	{
		[JsonConstructor]
		internal MovieCollectionSearchItem(int id, string name, string poster_path, string backdrop_path) : base(id)
		{
			Name = name;
			PosterPath = poster_path;
			BackdropPath = backdrop_path;
		}

		/// <summary>
		/// Gets the name of the collection.
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Gets the path to the poster image.
		/// </summary>]
		public string PosterPath { get; }

		/// <summary>
		/// Gets the path to the backdrop.
		/// </summary>
		public string BackdropPath { get; }
	}
}