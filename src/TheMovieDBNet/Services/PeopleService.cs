using System;
using System.Threading.Tasks;
using TheMovieDbNet.Converters;
using TheMovieDbNet.Models.Common;
using TheMovieDbNet.Models.People;

namespace TheMovieDbNet.Services
{
	/// <summary>
	/// Represents a service for accessing movie-related data.
	/// </summary>
	public class PeopleService : Service, IPeopleService
	{
		private Lazy<PeopleSearchItemConverter> _lazyConverter = 
			new Lazy<PeopleSearchItemConverter>(() => new PeopleSearchItemConverter(), true);
			
		/// <summary>
		/// Initializes a new instance of PeopleService.
		/// </summary>
		/// <param name="apiKey">API key from the movie db developer site</param>
		public PeopleService(string apiKey) : base(apiKey)
		{
		}

		/// <summary>
		/// Gets a page of people based on search query.
		/// </summary>
		/// <param name="settings">Settings class for detailed search</param>
		/// <returns>Search Result with people and page data.</returns>
		public async Task<SearchResult<PeopleSearchItem>> SearchAsync(PeopleSearchSettings settings)
		{
			var path = $"/3/search/person?api_key={apiKey}{settings}";
			return await RequestAndDeserialize<SearchResult<PeopleSearchItem>>(path, _lazyConverter.Value);
		}

		/// <summary>
		/// Gets a page of people based on search query.
		/// </summary>
		/// <param name="query">Name of the person.</param>
		/// <returns>Search Result with people and page data.</returns>
		public async Task<SearchResult<PeopleSearchItem>> SearchAsync(string query)
		{
			var settings = new PeopleSearchSettings
			{
				Query = query,
				Page = 1
			};
			return await SearchAsync(settings);
		}

		/// <summary>
		/// Gets a page of people based on search query.
		/// </summary>
		/// <param name="query">Name of the person.</param>
		/// <param name="page">Number of page for search</param>
		/// <returns>Search Result with people and page data.</returns>
		public async Task<SearchResult<PeopleSearchItem>> SearchAsync(string query, int page)
		{
			var settings = new PeopleSearchSettings
			{
				Query = query,
				Page = page
			};
			return await SearchAsync(settings);
		}
	}
}