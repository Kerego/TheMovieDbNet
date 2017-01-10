using System;
using System.Threading.Tasks;
using TheMovieDbNet.Models.Common;
using TheMovieDbNet.Models.Movies;
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
		Task<SearchResult<MovieSearchItem>> DiscoverMovies(MovieDiscoverSettings settings);

		/// <summary>
		/// Gets a page of dicovered tvs based on dicovery settings.
		/// </summary>
		/// <param name="settings">Filter option for discovery.</param>
		Task<SearchResult<TVSearchItem>> DiscoverTVs(TVDiscoverSettings settings);
	}
}