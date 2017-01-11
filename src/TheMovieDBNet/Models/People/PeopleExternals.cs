using Newtonsoft.Json;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models.People
{
	/// <summary>
	/// Represents the ids of the entity on external sites;
	/// </summary>
	public class PeopleExternals : Externals
	{
		[JsonConstructor]
		internal PeopleExternals(
			int? tvrage_id,
			string freebase_id,
			string imdb_id,
			string freebase_mid,
			string facebook_id,
			string instagram_id,
			string twitter_id) : base(tvrage_id, freebase_id, imdb_id, freebase_mid)
		{
			TwitterId = twitter_id;
			InstagramId = instagram_id;
			FacebookId = facebook_id;
		}

		/// <summary>
		/// Gets the id on the facebook.
		/// </summary>
		public string FacebookId { get; }
		
		/// <summary>
		/// Gets the id on the instagram.
		/// </summary>
		public string InstagramId { get; }
		
		/// <summary>
		/// Gets the id on the twitter.
		/// </summary>
		public string TwitterId { get; }
	}
}