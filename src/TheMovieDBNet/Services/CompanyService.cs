using System.Threading.Tasks;
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
	}
}