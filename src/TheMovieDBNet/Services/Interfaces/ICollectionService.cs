using System;
using System.Threading.Tasks;
using TheMovieDbNet.Models.Collections;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Services
{
	/// <summary>
	/// Represents abstraction for requesting movie collections data from database.
	/// </summary>
	public interface ICollectionService : IDisposable
	{
		/// <summary>
		/// Gets the details about the collection.
		/// </summary>
		/// <param name="id">Collection identifier.</param>
		/// <param name="language">Language of the result.</param>
		/// <returns>MovieCollection with movies that belongs to it.</returns>
		Task<MovieCollection> GetDetails(int id, string language = "");

		/// <summary>
		/// Gets the images of the movie collection.
		/// </summary>
		/// <param name="id">Collection identifier.</param>
		/// <param name="language">Language of the result.</param>
		/// <returns>Collection of Poster and Backdrops images.</returns>
		Task<ImageCollection> GetImages(int id, string language = "");

	}
}