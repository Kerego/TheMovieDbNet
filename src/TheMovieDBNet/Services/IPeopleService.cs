using System.Threading.Tasks;
using TheMovieDbNet.Models.Common;
using TheMovieDbNet.Models.People;

namespace TheMovieDbNet.Services
{
	/// <summary>
	/// Represents abstraction for requesting people-related data from database.
	/// </summary>
	public interface IPeopleService
	{
		/// <summary>
		/// Gets a page of people based on search query.
		/// </summary>
		/// <param name="settings">Settings class for detailed search</param>
		/// <returns>Search Result with people and page data.</returns>
		Task<SearchResult<PeopleSearchItem>> SearchAsync(PeopleSearchSettings settings);

		/// <summary>
		/// Gets a page of people based on search query.
		/// </summary>
		/// <param name="query">Name of the person.</param>
		/// <returns>Search Result with people and page data.</returns>
		Task<SearchResult<PeopleSearchItem>> SearchAsync(string query);

		/// <summary>
		/// Gets a page of people based on search query.
		/// </summary>
		/// <param name="query">Name of the person.</param>
		/// <param name="page">Number of page for search</param>
		/// <returns>Search Result with people and page data.</returns>
		Task<SearchResult<PeopleSearchItem>> SearchAsync(string query, int page);
	}
}