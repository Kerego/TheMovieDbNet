using System;
using System.Threading.Tasks;
using TheMovieDbNet.Converters;
using TheMovieDbNet.Models.Common;
using TheMovieDbNet.Models.Companies;
using TheMovieDbNet.Models.Movies;
using TheMovieDbNet.Models.People;
using TheMovieDbNet.Models.TVs;

namespace TheMovieDbNet.Services
{
	/// <summary>
	/// Represents the service to search and discover media.
	/// </summary>
	public class SearchService : Service, ISearchService
	{
		private Lazy<PeopleSearchItemConverter> _lazySearchConverter =
			new Lazy<PeopleSearchItemConverter>(() => new PeopleSearchItemConverter(), true);
			
		/// <summary>
		/// Initializes a new instance of SearcgService.
		/// </summary>
		/// <param name="apiKey">API key from the movie db developer site</param>

		public SearchService(string apiKey) : base(apiKey)
		{
		}
		/// <summary>
		/// Gets a page of dicovered movies based on dicovery settings.
		/// </summary>
		/// <param name="settings">Filter option for discovery.</param>
		public async Task<PagedResult<MovieSearchItem>> DiscoverMovies(MovieDiscoverSettings settings)
		{
			var path = $"/3/discover/movie?api_key={apiKey}{settings.ToString()}";
			return await RequestAndDeserialize<PagedResult<MovieSearchItem>>(path);
		}

			
		/// <summary>
		/// Gets a page of dicovered tvs based on dicovery settings.
		/// </summary>
		/// <param name="settings">Filter option for discovery.</param>
		public async Task<PagedResult<TVSearchItem>> DiscoverTVs(TVDiscoverSettings settings)
		{
			var path = $"/3/discover/tv?api_key={apiKey}{settings.ToString()}";
			return await RequestAndDeserialize<PagedResult<TVSearchItem>>(path);
		}

		
		/// <summary>
		/// Gets a page of tv based on search query.
		/// </summary>
		/// <param name="query">Name of the tv.</param>
		/// <param name="page">Number of page for search.</param>
		/// <returns>Search Result with tv and page data.</returns>
		public async Task<PagedResult<TVSearchItem>> SearchTVAsync(string query, int page = 0)
		{
			return await SearchTVAsync(new TVSearchSettings
			{
				Query = query,
				Page = page
			});
		}

		/// <summary>
		/// Gets a page of tv based on search query.
		/// </summary>
		/// <param name="settings">Settings class for detailed search.</param>
		/// <returns>Search Result with tv and page data.</returns>
		public async Task<PagedResult<TVSearchItem>> SearchTVAsync(TVSearchSettings settings)
		{
			var path = $"/3/search/tv?api_key={apiKey}{settings}";
			return await RequestAndDeserialize<PagedResult<TVSearchItem>>(path);
		}

		

		/// <summary>
		/// Gets a page of movies based on search query.
		/// </summary>
		/// <param name="settings">Settings class for detailed search</param>
		/// <returns>Search Result with movies and page data.</returns>
		public async Task<PagedResult<MovieSearchItem>> SearchMovieAsync(MovieSearchSettings settings)
		{
			var path = $"/3/search/movie?api_key={apiKey}{settings}";
			return await RequestAndDeserialize<PagedResult<MovieSearchItem>>(path);
		}

		/// <summary>
		/// Gets a page of movies based on search query.
		/// </summary>
		/// <param name="query">Name of the movie.</param>
		/// <param name="page">Number of page for search</param>
		/// <returns>Search Result with movies and page data.</returns>
		public async Task<PagedResult<MovieSearchItem>> SearchMovieAsync(string query, int page = 0)
		{
			var settings = new MovieSearchSettings
			{
				Query = query,
				Page = page
			};
			return await SearchMovieAsync(settings);
		}
		

		/// <summary>
		/// Gets a page of companies based on search query.
		/// </summary>
		/// <param name="query">Name of the company.</param>
		/// <param name="page">Number of page for search</param>
		/// <returns>Search Result with company and page data.</returns>
		public async Task<PagedResult<CompanySearchItem>> SearchCompanyAsync(string query, int page = 0)
		{
			var path = $"/3/search/company?api_key={apiKey}&query={query}";
			if (page > 0)
				path += $"&page={page}";
			return await RequestAndDeserialize<PagedResult<CompanySearchItem>>(path);
		}

		/// <summary>
		/// Gets a page of people based on search query.
		/// </summary>
		/// <param name="settings">Settings class for detailed search</param>
		/// <returns>Search Result with people and page data.</returns>
		public async Task<PagedResult<PersonSearchItem>> SearchPersonAsync(PersonSearchSettings settings)
		{
			var path = $"/3/search/person?api_key={apiKey}{settings}";
			return await RequestAndDeserialize<PagedResult<PersonSearchItem>>(path, _lazySearchConverter.Value);
		}

		/// <summary>
		/// Gets a page of people based on search query.
		/// </summary>
		/// <param name="query">Name of the person.</param>
		/// <param name="page">Number of page for search</param>
		/// <returns>Search Result with people and page data.</returns>
		public async Task<PagedResult<PersonSearchItem>> SearchPersonAsync(string query, int page = 0)
		{
			var settings = new PersonSearchSettings
			{
				Query = query,
				Page = page
			};
			return await SearchPersonAsync(settings);
		}

		/// <summary>
		/// Gets a page of movie collections based on search query.
		/// </summary>
		/// <param name="query">Name of the collection.</param>
		/// <param name="page">Number of page for search.</param>
		/// <param name="language">Language of the result.</param>
		/// <returns>Search Result with collections and page data.</returns>
		public async Task<PagedResult<MovieCollectionSearchItem>> SearchCollectionAsync(string query, int page = 0, string language = "")
		{
			var path = $"/3/search/collection?api_key={apiKey}&query={query}";
			if (!string.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			if (page > 0)
				path += $"&page={page}";
			return await RequestAndDeserialize<PagedResult<MovieCollectionSearchItem>>(path);
		}

	}
}