using System;
using System.Threading.Tasks;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Services
{
	/// <summary>
	/// Represents a service for fetching misc data.
	/// </summary>
	public class UtilityService : Service, IUtilityService
	{
		/// <summary>
		/// Initializes a new instance of UtilityService.
		/// </summary>
		/// <param name="apiKey">API key from the movie db developer site</param>
		public UtilityService(string apiKey) : base(apiKey)
		{
		}

		/// <summary>
		/// Get all the possible genres for a movie.
		/// </summary>
		/// <param name="language">Language of the result.</param>
		/// <returns>Array of genres translated to the given language.</returns>
		public async Task<Genre[]> GetMovieGenresAsync(string language = "")
		{
			var path = $"/3/genre/movie/list?api_key={apiKey}";
			if (!String.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			return await RequestAndSelect<Genre[]>(path, "genres");
		}

		/// <summary>
		/// Get all the possible genres for a tv.
		/// </summary>
		/// <param name="language">Language of the result.</param>
		/// <returns>Array of genres translated to the given language.</returns>
		public async Task<Genre[]> GetTVGenresAsync(string language = "")
		{
			var path = $"/3/genre/tv/list?api_key={apiKey}";
			if (!String.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			return await RequestAndSelect<Genre[]>(path, "genres");
		}

		/// <summary>
		/// Gets the image configuration settings.
		/// </summary>
		/// <returns>Configuration data.</returns>
		public async Task<Configuration> GetConfigurationAsync()
		{
			var path = $"/3/configuration?api_key={apiKey}";
			return await RequestAndSelect<Configuration>(path, "images");
		}
	}
}