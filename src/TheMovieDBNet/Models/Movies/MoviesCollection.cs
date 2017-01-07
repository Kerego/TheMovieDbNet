using Newtonsoft.Json;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models.Movies
{    
	/// <summary>
	/// info about a collection of movies
	/// </summary>
	public class MoviesCollection : Entity
	{
		[JsonConstructor]
		internal MoviesCollection(int id, string name, string poster_path, string backdrop_path) : base(id)
		{
			Name = name;
			PosterPath = poster_path;
			BackdropPath = backdrop_path;
		}

		/// <summary>
		/// Gets the name of the collection
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Gets the path to the poster image
		/// </summary>]
		public string PosterPath { get; }

		/// <summary>
		/// Gets the path to the backdrop
		/// </summary>
		public string BackdropPath { get; }
	}
}