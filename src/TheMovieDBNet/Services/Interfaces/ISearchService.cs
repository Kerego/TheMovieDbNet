using System;
using System.Threading.Tasks;
using TheMovieDbNet.Models.Common;
using TheMovieDbNet.Models.Companies;
using TheMovieDbNet.Models.Movies;
using TheMovieDbNet.Models.People;
using TheMovieDbNet.Models.TVs;

namespace TheMovieDbNet.Services
{
	/// <summary>
	/// Represents abstraction for searching and discovering media.
	/// </summary>
	public interface ISearchService : IDisposable
	{
		/// <summary>
		/// Gets a page of dicovered movies based on dicovery settings.
		/// </summary>
		/// <param name="settings">Filter option for discovery.</param>
		Task<PagedResult<MovieSearchItem>> DiscoverMovies(MovieDiscoverSettings settings);

		/// <summary>
		/// Gets a page of dicovered tvs based on dicovery settings.
		/// </summary>
		/// <param name="settings">Filter option for discovery.</param>
		Task<PagedResult<TVSearchItem>> DiscoverTVs(TVDiscoverSettings settings);
		

		/// <summary>
		/// Gets a page of tv based on search query.
		/// </summary>
		/// <param name="query">Name of the tv.</param>
		/// <param name="page">Number of page for search.</param>
		/// <returns>Search Result with tv and page data.</returns>
		Task<PagedResult<TVSearchItem>> SearchTVAsync(string query, int page = 0);
		
		/// <summary>
		/// Gets a page of tv based on search query.
		/// </summary>
		/// <param name="settings">Settings class for detailed search.</param>
		/// <returns>Search Result with tv and page data.</returns>
		Task<PagedResult<TVSearchItem>> SearchTVAsync(TVSearchSettings settings);

		/// <summary>
		/// Gets a page of movies based on search query.
		/// </summary>
		/// <param name="query">Name of the movie.</param>
		/// <param name="page">Number of page for search.</param>
		/// <returns>Search Result with movies and page data.</returns>
		Task<PagedResult<MovieSearchItem>> SearchMovieAsync(string query, int page = 0);

		/// <summary>
		/// Gets a page of movies based on search query.
		/// </summary>
		/// <param name="settings">Settings class for detailed search.</param>
		/// <returns>Search Result with movies and page data.</returns>
		Task<PagedResult<MovieSearchItem>> SearchMovieAsync(MovieSearchSettings settings);
		
		/// <summary>
		/// Gets a page of people based on search query.
		/// </summary>
		/// <param name="settings">Settings class for detailed search.</param>
		/// <returns>Search Result with people and page data.</returns>
		Task<PagedResult<PersonSearchItem>> SearchPersonAsync(PersonSearchSettings settings);

		/// <summary>
		/// Gets a page of people based on search query.
		/// </summary>
		/// <param name="query">Name of the person.</param>
		/// <param name="page">Number of page for search.</param>
		/// <returns>Search Result with people and page data.</returns>
		Task<PagedResult<PersonSearchItem>> SearchPersonAsync(string query, int page = 0);

		/// <summary>
		/// Gets a page of companies based on search query.
		/// </summary>
		/// <param name="query">Name of the company.</param>
		/// <param name="page">Number of page for search.</param>
		/// <returns>Search Result with company and page data.</returns>
		Task<PagedResult<CompanySearchItem>> SearchCompanyAsync(string query, int page = 0);

		/// <summary>
		/// Gets a page of keywords based on search query.
		/// </summary>
		/// <param name="query">Name of the keyword.</param>
		/// <param name="page">Number of page for search.</param>
		/// <returns>Search Result with keywords and page data.</returns>
		Task<PagedResult<Keyword>> SearchKeywordAsync(string query, int page = 0);

		/// <summary>
		/// Gets a page of movie collections based on search query.
		/// </summary>
		/// <param name="query">Name of the collection.</param>
		/// <param name="page">Number of page for search.</param>
		/// <param name="language">Language of the result.</param>
		/// <returns>Search Result with collections and page data.</returns>
		Task<PagedResult<MovieCollectionSearchItem>> SearchCollectionAsync(string query, int page = 0, string language = "");
	}
}