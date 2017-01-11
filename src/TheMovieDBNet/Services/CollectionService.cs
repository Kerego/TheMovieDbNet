using System;
using System.Threading.Tasks;
using TheMovieDbNet.Models.Collections;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Services
{
	/// <summary>
	/// Represents a service for accessing movie collections data.
	/// </summary>
	public class CollectionService : Service, ICollectionService
	{
		/// <summary>
		/// Initializes a new instance of CollectionService.
		/// </summary>
		/// <param name="apiKey">API key from the movie db developer site</param>
		public CollectionService(string apiKey) : base(apiKey)
		{
		}

		/// <summary>
		/// Gets the details about the collection.
		/// </summary>
		/// <param name="id">Collection identifier.</param>
		/// <param name="language">Language of the result.</param>
		/// <returns>MovieCollection with movies that belongs to it.</returns>
		public async Task<MovieCollection> GetDetails(int id, string language = "")
		{
			var path = $"/3/collection/{id}?api_key={apiKey}";
			return await RequestAndDeserialize<MovieCollection>(path);
		}

		/// <summary>
		/// Gets the images of the movie collection.
		/// </summary>
		/// <param name="id">Collection identifier.</param>
		/// <param name="language">Language of the result.</param>
		/// <returns>Collection of Poster and Backdrops images.</returns>
		public async Task<ImageCollection> GetImages(int id, string language = "")
		{
			var path = $"/3/collection/{id}/images?api_key={apiKey}";
			if (!String.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			return await RequestAndDeserialize<ImageCollection>(path);
		}
	}
}