using System.Threading.Tasks;
using TheMovieDbNet.Models.Common;
using TheMovieDbNet.Models.Movies;

namespace TheMovieDbNet.Services
{
	/// <summary>
	/// Represents the service to search and discover media.
	/// </summary>
	public class SearchService : Service, ISearchService
	{
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
		public async Task<SearchResult<MovieSearchItem>> DiscoverMovies(MovieDiscoverSettings settings)
		{
			var path = $"/3/discover/movie?api_key={apiKey}{settings.ToString()}";
			return await RequestAndDeserialize<SearchResult<MovieSearchItem>>(path);
		}
	
	}
}