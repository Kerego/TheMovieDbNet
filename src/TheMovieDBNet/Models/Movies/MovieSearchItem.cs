using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Movies
{
	/// <summary>
	/// Represents an item from movies search.
	/// </summary>
	public class MovieSearchItem : MovieBase
	{
		[JsonConstructor]
		internal MovieSearchItem(
			int id, 
			bool adult, 
			string original_language, 
			string original_title, 
			double popularity, 
			string poster_path, 
			string backdrop_path, 
			string overview, 
			string title, 
			bool video, 
			double vote_average, 
			int vote_count, 
			string release_date,
			int[] genre_ids) : base(id, 
										adult, 
										original_language, 
										original_title, 
										popularity, 
										poster_path, 
										backdrop_path, 
										overview, 
										title, 
										video, 
										vote_average, 
										vote_count, 
										release_date)
		{
			GenreIds = genre_ids;
		}

		/// <summary>
		/// Gets the array with genre ids movie belongs to.
		/// </summary>
		public int[] GenreIds { get; }
	}
}