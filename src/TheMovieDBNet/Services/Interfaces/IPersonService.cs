using System;
using System.Threading.Tasks;
using TheMovieDbNet.Models.Common;
using TheMovieDbNet.Models.People;

namespace TheMovieDbNet.Services
{
	/// <summary>
	/// Represents abstraction for requesting people-related data from database.
	/// </summary>
	public interface IPersonService : IDisposable
	{
		/// <summary>
		/// Gets details of a person.
		/// </summary>
		/// <param name="id">Person identifier.</param>
		/// <param name="append">Additional info to append to the response (eg: images, videos).</param>
		/// <returns>Object of type person with fields filled with data.</returns>
		Task<Person> GetDetailsAsync(int id, string append = "");
		
		/// <summary>
		/// Gets the last added person.
		/// </summary>
		/// <param name="language">Language of the result.</param>
		/// <returns>Person object with details.</returns>
		Task<Person> GetLatestAsync(string language = "");

		/// <summary>
		/// Get the list of popular people on TMDb. This list updates daily.
		/// </summary>
		/// <param name="page">Page of the result.</param>
		/// <param name="language">Language of the result.</param>
		/// <returns>Paged Result with people and page data.</returns>
		Task<PagedResult<PersonSearchItem>> GetPopularAsync(int page = 0, string language = "");

		/// <summary>
		/// Gets person identifiers on external sites.
		/// </summary>
		/// <param name="id">Person identifier.</param>
		/// <param name="language">Language of the result.</param>
		/// <returns>External ids for person.</returns>
		Task<PersonExternals> GetExternalIdsAsync(int id, string language = "");

		/// <summary>
		/// Gets details of a person.
		/// </summary>
		/// <param name="id">Person identifier.</param>
		/// <param name="settings">Additional info to append to the response (eg: images, videos).</param>
		/// <returns>Object of type person with fields filled with data.</returns>
		Task<Person> GetDetailsAsync(int id, PersonAppendSettings settings);

		/// <summary>
		/// Gets the cast and crew of the person.
		/// </summary>
		/// <param name="id">Person identifier.</param>
		/// <param name="language">Language of the media.</param>
		/// <returns>Credits of the person.</returns>
		Task<PersonCredits> GetCreditsAsync(int id, string language = "");

		/// <summary>
		/// Gets the images of the person.
		/// </summary>
		/// <param name="id">person identifier.</param>
		/// <returns>Collection with the images of the person.</returns>
		Task<Image[]> GetImagesAsync(int id);
		
		/// <summary>
		/// Gets the tagged images of the person.
		/// </summary>
		/// <param name="id">person identifier.</param>
		/// <param name="language">Language of the image.</param>
		/// <param name="page">Page of the tagged images search result.</param>
		/// <returns>Collection with the images of the person.</returns>
		Task<TaggedImageCollection> GetTaggedImagesAsync(int id, int page = 0, string language = "");

	}
}