using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Common
{
	/// <summary>
	/// Represents a generic class that holds data about paged data.
	/// </summary>
	public class PagedResult<T> where T : Entity
	{
		[JsonConstructor]
		internal PagedResult(T[] results, int total_results, int total_pages, int page)
		{
			Results = results;
			TotalResults = total_results;
			TotalPages = total_pages;
			Page = page;
		}
		/// <summary>
		/// Gets the array of resulting entities.
		/// </summary>
		public T[] Results { get; }

		/// <summary>
		/// Gets the total number of results available.
		/// </summary>
		public int TotalResults { get; }

		/// <summary>
		/// Gets the total number of pages available.
		/// </summary>

		public int TotalPages { get; }
		/// <summary>
		/// Gets the current page of the result.
		/// </summary>
		public int Page { get; }
	}
}