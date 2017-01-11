using Newtonsoft.Json;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models.TVs
{
	/// <summary>
	/// Represents the ids of the entity on external sites;
	/// </summary>
	public class TVExternals : Externals
	{
		[JsonConstructor]
		internal TVExternals(
			int? tvrage_id,
			string freebase_id,
			string imdb_id,
			string freebase_mid,
			int? tvdb_id) : base(tvrage_id, freebase_id, imdb_id, freebase_mid)
		{
			TvdbId = tvdb_id;
		}

		/// <summary>
		/// Gets the id on the tvdb site.
		/// </summary>
		public int? TvdbId { get; }
	}
}