using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TheMovieDbNet.Models;
using TheMovieDbNet.Models.Common;
using TheMovieDbNet.Models.Movies;

namespace TheMovieDbNet.Services
{
	/// <summary>
	/// Represents a service for accessing movie-related data.
	/// </summary>
	public class MovieService : Service, IMovieService
	{
		/// <summary>
		/// Initializes a new instance of MovieService.
		/// </summary>
		/// <param name="apiKey">API key from the movie db developer site</param>
		public MovieService(string apiKey) : base(apiKey)
		{
		}

		/// <summary>
		/// Gets translated titles of the movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <returns>Array of Alternative Titles for movie.</returns>
		public async Task<AlternativeTitle[]> GetAlternativeTitlesAsync(int id) => await GetAlternativeTitlesAsync(id, string.Empty);

		/// <summary>
		/// Gets translated titles of the movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <param name="country">Country of translation (eg: es, pt).</param>
		/// <returns>Array of Alternative Titles for movie.</returns>
		public async Task<AlternativeTitle[]> GetAlternativeTitlesAsync(int id, string country)
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
		public async Task<MovieCredits> GetCreditsAsync(int id)
		{
			var path = $"/3/movie/{id}/credits?api_key={apiKey}";
			return await RequestAndDeserialize<MovieCredits>(path);
		}

		/// <summary>
		/// Gets the images of the movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <returns>Collection with the images of the movie.</returns>
		public async Task<ImageCollection> GetImagesAsync(int id)
			=> await GetImagesAsync(id, string.Empty, string.Empty);


		/// <summary>
		/// Gets the images of the movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <param name="language">Language of the image.</param>
		/// <returns>Collection with the images of the movie.</returns>
		public async Task<ImageCollection> GetImagesAsync(int id, string language)
			=> await GetImagesAsync(id, language, string.Empty);

		/// <summary>
		/// Gets the images of the movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <param name="language">Language of the image.</param>
		/// <param name="includeLanguages">Additional Languages to add to the image. (eg: fr,es,null)</param>
		/// <returns>Collection with the images of the movie.</returns>
		public async Task<ImageCollection> GetImagesAsync(int id, string language, string includeLanguages)
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
		/// <returns>Array of videos.</returns>
		public async Task<Video[]> GetVideosAsync(int id)
			=> await GetVideosAsync(id, string.Empty);


		/// <summary>
		/// Gets the videos of the movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <param name="language">Video language.</param>
		/// <returns>Array of videos.</returns>
		public async Task<Video[]> GetVideosAsync(int id, string language)
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
		public async Task<SearchResult<MovieSearchItem>> GetRecommendationsAsync(int id, int page, string language)
		{
			var path = $"/3/movie/{id}/recommendations?api_key={apiKey}";
			if (page > 0)
				path += $"&page={page}";
			if (!String.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			return await RequestAndDeserialize<SearchResult<MovieSearchItem>>(path);
		}

		/// <summary>
		/// Gets the recommendations for the movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <param name="page">Recommendations page number.</param>
		/// <returns>Collection of recommendations.</returns>
		public async Task<SearchResult<MovieSearchItem>> GetRecommendationsAsync(int id, int page)
			=> await GetRecommendationsAsync(id, page, string.Empty);

		/// <summary>
		/// Gets the recommendations for the movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <returns>Collection of recommendations.</returns>
		public async Task<SearchResult<MovieSearchItem>> GetRecommendationsAsync(int id)
			=> await GetRecommendationsAsync(id, 0, string.Empty);

		/// <summary>
		/// Gets the similar movies.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <param name="page">Similar movies page number.</param>
		/// <param name="language">Movie language.</param>
		/// <returns>Collection of similar movies.</returns>
		public async Task<SearchResult<MovieSearchItem>> GetSimilarMoviesAsync(int id, int page, string language)
		{
			var path = $"/3/movie/{id}/similar_movies?api_key={apiKey}";
			if (page > 0)
				path += $"&page={page}";
			if (!String.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			return await RequestAndDeserialize<SearchResult<MovieSearchItem>>(path);
		}

		/// <summary>
		/// Gets the similar movies.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <param name="page">Similar movies page number.</param>
		/// <returns>Collection of similar movies.</returns>
		public async Task<SearchResult<MovieSearchItem>> GetSimilarMoviesAsync(int id, int page)
			=> await GetSimilarMoviesAsync(id, page, string.Empty);

		/// <summary>
		/// Gets the similar movies.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <returns>Collection of similar movies.</returns>
		public async Task<SearchResult<MovieSearchItem>> GetSimilarMoviesAsync(int id)
			=> await GetSimilarMoviesAsync(id, 0, string.Empty);

		/// <summary>
		/// Gets details of the movie.
		/// </summary>
		/// <param name="id">Movie identifier.</param>
		/// <param name="append">Additional info to append to the response (eg: images, videos).</param>
		/// <returns>Object of type Movie with fields filled with data.</returns>
		public async Task<Movie> GetDetailsAsync(int id, string append)
		{
			var path = $"/3/movie/{id}?api_key={apiKey}&append_to_response={append}";
			using (var result = await httpClient.GetAsync(path))
			{
				var content = await result.Content.ReadAsStringAsync();
				if (!result.IsSuccessStatusCode)
					throw new Exception(content); //TODO use specific exception not the base
				return JsonConvert.DeserializeObject<Movie>(content, new MovieConverter());
			}
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
		/// Gets a page of movies based on search query.
		/// </summary>
		/// <param name="settings">Settings class for detailed search</param>
		/// <returns>Search Result with movies and page data.</returns>
		public async Task<SearchResult<MovieSearchItem>> SearchAsync(MovieSearchSettings settings)
		{
			var path = $"/3/search/movie?api_key={apiKey}{settings}";
			using (var result = await httpClient.GetAsync(path))
			{
				var content = await result.Content.ReadAsStringAsync();
				if (!result.IsSuccessStatusCode)
					throw new Exception(content); //TODO use specific exception not the base
				return JsonConvert.DeserializeObject<SearchResult<MovieSearchItem>>(content);
			}
		}

		/// <summary>
		/// Gets a page of movies based on search query.
		/// </summary>
		/// <param name="query">Name of the movie.</param>
		/// <returns>Search Result with movies and page data.</returns>
		public async Task<SearchResult<MovieSearchItem>> SearchAsync(string query)
		{
			var settings = new MovieSearchSettings
			{
				Query = query,
				Page = 1
			};
			return await SearchAsync(settings);
		}

		/// <summary>
		/// Gets a page of movies based on search query.
		/// </summary>
		/// <param name="query">Name of the movie.</param>
		/// <param name="page">Number of page for search</param>
		/// <returns>Search Result with movies and page data.</returns>
		public async Task<SearchResult<MovieSearchItem>> SearchAsync(string query, int page)
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