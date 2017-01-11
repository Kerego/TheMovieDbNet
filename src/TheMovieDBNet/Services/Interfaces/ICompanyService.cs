using System;
using System.Threading.Tasks;
using TheMovieDbNet.Models.Common;
using TheMovieDbNet.Models.Companies;

namespace TheMovieDbNet.Services
{
	/// <summary>
	/// Represents abstraction for requesting companies-related data from database.
	/// </summary>
	public interface ICompanyService : IDisposable
	{
		/// <summary>
		/// Gets details of a company.
		/// </summary>
		/// <param name="id">Company identifier.</param>
		/// <returns>Object of type Company with fields filled with data.</returns>
		Task<Company> GetDetailsAsync(int id);

		/// <summary>
		/// Gets a page of companies based on search query.
		/// </summary>
		/// <param name="query">Name of the company.</param>
		/// <param name="page">Number of page for search</param>
		/// <returns>Search Result with company and page data.</returns>
		Task<PagedResult<CompanySearchItem>> SearchAsync(string query, int page = 0);
	}
}