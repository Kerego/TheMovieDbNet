using System;
using System.Threading.Tasks;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Services
{
	/// <summary>
	/// Represents abstraction for fetching utility data.
	/// </summary>
	public interface IUtilityService : IDisposable
	{
		/// <summary>
		/// Get all the possible genres for a movie.
		/// </summary>
		/// <param name="language">Language of the result.</param>
		/// <returns>Array of genres translated to the given language.</returns>
		Task<Genre[]> GetMovieGenresAsync(string language = "");

		/// <summary>
		/// Get all the possible genres for a tv.
		/// </summary>
		/// <param name="language">Language of the result.</param>
		/// <returns>Array of genres translated to the given language.</returns>
		Task<Genre[]> GetTVGenresAsync(string language = "");

		/// <summary>
		/// Gets the image configuration settings.
		/// </summary>
		/// <returns>Configuration data.</returns>
		Task<Configuration> GetConfigurationAsync();

	}
}