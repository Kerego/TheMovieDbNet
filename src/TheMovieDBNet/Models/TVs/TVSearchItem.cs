using Newtonsoft.Json;

namespace TheMovieDbNet.Models.TVs
{
	/// <summary>
	/// Represents an item from tv search.
	/// </summary>
	public class TVSearchItem : TVBase
	{
		[JsonConstructor]
		internal TVSearchItem(
			int id,
			double popularity,
			string poster_path,
			string backdrop_path,
			string overview,
			double vote_average,
			int vote_count,
			string first_air_date,
			string[] origin_country,
			string name,
			string original_name,
			int[] genre_ids)
		: base(
			id,
			popularity,
			poster_path,
			backdrop_path,
			overview,
			vote_average,
			vote_count,
			first_air_date,
			origin_country,
			name,
			original_name)
		{
			GenreIds = genre_ids;
		}

		/// <summary>
		/// Gets the array with id of the genres of tv.
		/// </summary>
		public int[] GenreIds { get; }
	}
}