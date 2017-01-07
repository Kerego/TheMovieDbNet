using System.Threading.Tasks;
using TheMovieDbNet.Models.Common;
using TheMovieDbNet.Models.Companies;

namespace TheMovieDbNet.Services
{
	/// <summary>
	/// Represents a service for accessing company-related data.
	/// </summary>
	public class CompanyService : Service, ICompanyService
	{

		/// <summary>
		/// Initializes a new instance of CompanyService.
		/// </summary>
		/// <param name="apiKey">API key from the movie db developer site</param>
		public CompanyService(string apiKey) : base(apiKey)
		{
		}

		/// <summary>
		/// Gets details of a company.
		/// </summary>
		/// <param name="id">Company identifier.</param>
		/// <returns>Object of type Company with fields filled with data.</returns>
		public async Task<Company> GetDetailsAsync(int id)
		{
			var path = $"/3/company/{id}?api_key={apiKey}";
			return await RequestAndDeserialize<Company>(path);
		}

		/// <summary>
		/// Gets a page of companies based on search query.
		/// </summary>
		/// <param name="query">Name of the company.</param>
		/// <returns>Search Result with company and page data.</returns>
		public async Task<SearchResult<CompanySearchItem>> SearchAsync(string query)
			=> await SearchAsync(query, 0);

		/// <summary>
		/// Gets a page of companies based on search query.
		/// </summary>
		/// <param name="query">Name of the company.</param>
		/// <param name="page">Number of page for search</param>
		/// <returns>Search Result with company and page data.</returns>
		public async Task<SearchResult<CompanySearchItem>> SearchAsync(string query, int page)
		{
			var path = $"/3/search/company?api_key={apiKey}&query={query}";
			if (page > 0)
				path += $"&page={page}";
			return await RequestAndDeserialize<SearchResult<CompanySearchItem>>(path);
		}
	}
}