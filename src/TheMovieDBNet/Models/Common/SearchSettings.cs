namespace TheMovieDbNet.Models.Common
{
	/// <summary>
	/// Represents base settings used in search.
	/// </summary>
	public class SearchSettings
	{
		/// <summary>
		/// Gets and Sets query parameters of the search.
		/// </summary>
		public string Query { get; set; }
		/// <summary>
		/// Gets and Sets the page of the search.
		/// </summary>
		public int Page { get; set; }

		/// <summary>
		/// Converts to string to use in search queries.
		/// </summary>
		/// <returns>String form of query.</returns>
		public override string ToString()
		{
			var result = $"&query={Query}";
			if(Page > 0)
				result += $"&page={Page}";
			return result;
		}
	}
}