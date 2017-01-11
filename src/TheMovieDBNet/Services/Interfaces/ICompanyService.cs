using System;
using System.Threading.Tasks;
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
	}
}