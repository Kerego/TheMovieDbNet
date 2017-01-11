using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Common
{
	/// <summary>
	/// Represents the ids of the entity on external sites;
	/// </summary>
	public class Externals
	{
		[JsonConstructor]
		internal Externals(int? tvrage_id, string freebase_id, string imdb_id, string freebase_mid)
		{
			TvrageId = tvrage_id;
			FreebaseId = freebase_id;
			ImdbId = imdb_id;
			FreebaseMid = freebase_mid;
		}
		/// <summary>
		/// Gets the id on the imdb site.
		/// </summary>
		public string ImdbId { get; }
		/// <summary>
		/// Gets the id on the tvrage site.
		/// </summary>
		public int? TvrageId { get; }
		/// <summary>
		/// Gets the id on the tvrage site.
		/// </summary>
		public string FreebaseId { get; }
		/// <summary>
		/// Gets the id on the tvrage site.
		/// </summary>
		public string FreebaseMid { get; }
	}
}