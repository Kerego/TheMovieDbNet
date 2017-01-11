using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models.People
{
	/// <summary>
	/// Represents movie settings used in search.
	/// </summary>
	public class PersonSearchSettings : SearchSettings
	{
		/// <summary>
		/// Gets or Sets language of search query
		/// </summary>
		public string Language { get; set; }
		/// <summary>
		/// Gets or Sets whether to include Adult content in search results
		/// </summary>
		public bool AllowAdult { get; set; }
		/// <summary>
		/// Gets or Sets region of search query
		/// </summary>
		public string Region { get; set; }

		/// <summary>
		/// Converts to string to use in search queries.
		/// </summary>
		/// <returns>String form of query.</returns>
		public override string ToString() 
		{
			var result = base.ToString();
			if (!string.IsNullOrWhiteSpace(Language))
				result += $"&language={Language}";
			if (!string.IsNullOrWhiteSpace(Region))
				result += $"&region={Region}";
			if (AllowAdult)
				result += $"&include_adult={AllowAdult.ToString().ToLower()}";

			return result;
		}
	}
}