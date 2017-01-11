using System;
using System.Threading.Tasks;
using TheMovieDbNet.Converters;
using TheMovieDbNet.Models.Common;
using TheMovieDbNet.Models.Movies;

namespace TheMovieDbNet.Services
{
	/// <summary>
	/// Represents a service for accessing movie-related data.
	/// </summary>
	public class MovieService : Service, IMovieService
	{
		private Lazy<MovieConverter> _lazyConverter = new Lazy<MovieConverter>(() => new MovieConverter(), true);

		/// <summary>
		/// Initializes a new instance of MovieService.
		/// </summary>
		/// <param name="apiKey">API key from the movie db developer site</param>
		public MovieService(string apiKey) : base(apiKey)
		{

		}

		/// <summary>
		/// Gets the mosty newly created movie.
		/// </summary>
		/// <param name="language">Language of the result.</param>
		/// <returns>Object of type Movie with filled details.</returns>
		public async Task<Movie> GetLatestAsync(string language = "")
		{
			var path = $"/3/movie/latest?api_key={apiKey}";
			if(!string.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			return await RequestAndDeserialize<Movie>(path, _lazyConverter.Value);
		}

		/// <summary>
		/// Gets the list of upcoming movies.
		/// </summary>
		/// <param name="page">Page of results.</param>
		/// <param name="region">Region of the theatres.</param>
		/// <param name="language">Language of the result.</param>
		/// <returns>A page of the dated results.</returns>
		public async Task<DatedPagedResult<MovieSearchItem>> GetUpcomingAsync(int page = 0, string region = "", string language = "")
		{
			var path = $"/3/movie/upcoming?api_key={apiKey}";
			if(!string.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			if(!string.IsNullOrWhiteSpace(region))
				path += $"&region={region}";
			if(page > 0)
				path +=$"&page={page}";
			return await RequestAndDeserialize<DatedPagedResult<MovieSearchItem>>(path);
		}

		/// <summary>
		/// Gets the list of movies in theatres.
		/// </summary>
		/// <param name="page">Page of results.</param>
		/// <param name="region">Region of the theatres.</param>
		/// <param name="language">Language of the result.</param>
		/// <returns>A page of the dated results.</returns>
		public async Task<DatedPagedResult<MovieSearchItem>> GetNowPlayingAsync(int page = 0, string region = "", string language = "")
		{
			var path = $"/3/movie/now_playing?api_key={apiKey}";
			if(!string.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			if(!string.IsNullOrWhiteSpace(region))
				path += $"&region={region}";
			if(page > 0)
				path += $"&page={page}";
			return await RequestAndDeserialize<DatedPagedResult<MovieSearchItem>>(path);
		}

		/// <summary>
		/// Gets the list of popular movies.
		/// </summary>
		/// <param name="page">Page of results.</param>
		/// <param name="region">Region to search.</param>
		/// <param name="language">Language of the result.</param>
		/// <returns>A page of the dated results.</returns>
		public async Task<PagedResult<MovieSearchItem>> GetPopularAsync(int page = 0, string region = "", string language = "")
		{
			var path = $"/3/movie/popular?api_key={apiKey}";
			if(!string.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			if(!string.IsNullOrWhiteSpace(region))
				path += $"&region={region}";
			if(page > 0)
				path += $"&page={page}";
			return await RequestAndDeserialize<PagedResult<MovieSearchItem>>(path);
		}

		/// <summary>
		/// Gets the list of top rated movies.
		/// </summary>
		/// <param name="page">Page of results.</param>
		/// <param name="region">Region to search.</param>
		/// <param name="language">Language of the result.</param>
		/// <returns>A page of the dated results.</returns>
		public async Task<PagedResult<MovieSearchItem>> GetTopRatedAsync(int page = 0, string region = "", string language = "")
		{
			var path = $"/3/movie/top_rated?api_key={apiKey}";
			if(!string.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			if(!string.IsNullOrWhiteSpace(region))
				path += $"&region={region}";
			if(page > 0)
				path += $"&page={page}";
			return await RequestAndDeserialize<PagedResult<MovieSearchItem>>(path);
		}

		/// <summary>
		/// Gets details of the movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <param name="append">Additional info to append to the response (eg: images, videos).</param>
		/// <returns>Object of type Movie with fields filled with data.</returns>
		public async Task<Movie> GetDetailsAsync(int id, string append = "")
		{
			var path = $"/3/movie/{id}?api_key={apiKey}&append_to_response={append}";
			return await RequestAndDeserialize<Movie>(path, _lazyConverter.Value);
		}

		/// <summary>
		/// Gets details of the movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <param name="settings">Additional info to append to the response (eg: images, videos).</param>
		/// <returns>Object of type Movie with fields filled with data.</returns>
		public async Task<Movie> GetDetailsAsync(int id, MovieAppendSettings settings)
			=> await GetDetailsAsync(id, settings.ToString());

		/// <summary>
		/// Gets translated titles of the movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <param name="country">Country of translation (eg: es, pt).</param>
		/// <returns>Array of Alternative Titles for movie.</returns>
		public async Task<AlternativeTitle[]> GetAlternativeTitlesAsync(int id, string country = "")
		{
			var path = $"/3/movie/{id}/alternative_titles?api_key={apiKey}";
			if (!String.IsNullOrWhiteSpace(country))
				path += $"&country={country}";
			return await RequestAndSelect<AlternativeTitle[]>(path, "titles");
		}

		/// <summary>
		/// Gets the cast and crew of the movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <returns>Credits of the movie.</returns>
		public async Task<MediaCredits> GetCreditsAsync(int id)
		{
			var path = $"/3/movie/{id}/credits?api_key={apiKey}";
			return await RequestAndDeserialize<MediaCredits>(path);
		}

		/// <summary>
		/// Gets the images of the movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <param name="language">Language of the image.</param>
		/// <param name="includeLanguages">Additional Languages to add to the image. (eg: fr,es,null)</param>
		/// <returns>Collection with the images of the movie.</returns>
		public async Task<ImageCollection> GetImagesAsync(int id, string language = "", string includeLanguages = "")
		{
			var path = $"/3/movie/{id}/images?api_key={apiKey}";
			if (!String.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			if (!String.IsNullOrWhiteSpace(includeLanguages))
				path += $"&include_image_language={includeLanguages}";
			return await RequestAndDeserialize<ImageCollection>(path);
		}

		/// <summary>
		/// Gets the keywords of the movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <returns>Array of the keywords.</returns>
		public async Task<Keyword[]> GetKeywordsAsync(int id)
		{
			var path = $"/3/movie/{id}/keywords?api_key={apiKey}";
			return await RequestAndSelect<Keyword[]>(path, "keywords");
		}

		/// <summary>
		/// Gets the release info of the movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <returns>Array of release infos.</returns>
		public async Task<ReleaseInfo[]> GetReleaseInfoAsync(int id)
		{
			var path = $"/3/movie/{id}/release_dates?api_key={apiKey}";
			return await RequestAndSelect<ReleaseInfo[]>(path, "results");
		}

		/// <summary>
		/// Gets the videos of the movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <param name="language">Video language.</param>
		/// <returns>Array of videos.</returns>
		public async Task<Video[]> GetVideosAsync(int id, string language = "")
		{
			var path = $"/3/movie/{id}/videos?api_key={apiKey}";
			if (!String.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			return await RequestAndSelect<Video[]>(path, "results");
		}

		/// <summary>
		/// Gets the translations of the movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <returns>Array of translations.</returns>
		public async Task<Translation[]> GetTranslationsAsync(int id)
		{
			var path = $"/3/movie/{id}/translations?api_key={apiKey}";
			return await RequestAndSelect<Translation[]>(path, "translations");
		}

		/// <summary>
		/// Gets the recommendations for the movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <param name="page">Recommendations page number.</param>
		/// <param name="language">Movie language.</param>
		/// <returns>Collection of recommendations.</returns>
		public async Task<PagedResult<MovieSearchItem>> GetRecommendationsAsync(int id, int page = 0, string language = "")
		{
			var path = $"/3/movie/{id}/recommendations?api_key={apiKey}";
			if (page > 0)
				path += $"&page={page}";
			if (!String.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			return await RequestAndDeserialize<PagedResult<MovieSearchItem>>(path);
		}

		/// <summary>
		/// Gets the similar movies.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <param name="page">Similar movies page number.</param>
		/// <param name="language">Movie language.</param>
		/// <returns>Collection of similar movies.</returns>
		public async Task<PagedResult<MovieSearchItem>> GetSimilarMoviesAsync(int id, int page = 0, string language = "")
		{
			var path = $"/3/movie/{id}/similar_movies?api_key={apiKey}";
			if (page > 0)
				path += $"&page={page}";
			if (!String.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			return await RequestAndDeserialize<PagedResult<MovieSearchItem>>(path);
		}

		/// <summary>
		/// Gets a page of movies based on search query.
		/// </summary>
		/// <param name="settings">Settings class for detailed search</param>
		/// <returns>Search Result with movies and page data.</returns>
		public async Task<PagedResult<MovieSearchItem>> SearchAsync(MovieSearchSettings settings)
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
		public async Task<PagedResult<MovieSearchItem>> SearchAsync(string query, int page = 0)
		{
			var settings = new MovieSearchSettings
			{
				Query = query,
				Page = page
			};
			return await SearchAsync(settings);
		}

	}
}