using System.Threading.Tasks;
using TheMovieDbNet.Models.Common;
using TheMovieDbNet.Models.People;

namespace TheMovieDbNet.Services
{
	/// <summary>
	/// Represents abstraction for requesting people-related data from database.
	/// </summary>
	public interface IPersonService
	{
		/// <summary>
		/// Gets details of a person.
		/// </summary>
		/// <param name="id">Person identifier.</param>
		/// <returns>Object of type person with fields filled with data.</returns>
		Task<Person> GetDetailsAsync(int id);

		/// <summary>
		/// Gets details of a person.
		/// </summary>
		/// <param name="id">Person identifier.</param>
		/// <param name="append">Additional info to append to the response (eg: images, videos).</param>
		/// <returns>Object of type person with fields filled with data.</returns>
		Task<Person> GetDetailsAsync(int id, string append);
		
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
		/// <returns>Credits of the person.</returns>
		Task<PersonCredits> GetCreditsAsync(int id);

		/// <summary>
		/// Gets the cast and crew of the person.
		/// </summary>
		/// <param name="id">Person identifier.</param>
		/// <param name="language">Language of the media.</param>
		/// <returns>Credits of the person.</returns>
		Task<PersonCredits> GetCreditsAsync(int id, string language);

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
		/// <returns>Collection with the images of the person.</returns>
		Task<TaggedImageCollection> GetTaggedImagesAsync(int id);
		
		/// <summary>
		/// Gets the tagged images of the person.
		/// </summary>
		/// <param name="id">person identifier.</param>
		/// <param name="page">Page of the tagged images search result.</param>
		/// <returns>Collection with the images of the person.</returns>
		Task<TaggedImageCollection> GetTaggedImagesAsync(int id, int page);

		/// <summary>
		/// Gets the tagged images of the person.
		/// </summary>
		/// <param name="id">person identifier.</param>
		/// <param name="language">Language of the image.</param>
		/// <param name="page">Page of the tagged images search result.</param>
		/// <returns>Collection with the images of the person.</returns>
		Task<TaggedImageCollection> GetTaggedImagesAsync(int id, int page, string language);

		/// <summary>
		/// Gets a page of people based on search query.
		/// </summary>
		/// <param name="settings">Settings class for detailed search</param>
		/// <returns>Search Result with people and page data.</returns>
		Task<SearchResult<PeopleSearchItem>> SearchAsync(PeopleSearchSettings settings);

		/// <summary>
		/// Gets a page of people based on search query.
		/// </summary>
		/// <param name="query">Name of the person.</param>
		/// <returns>Search Result with people and page data.</returns>
		Task<SearchResult<PeopleSearchItem>> SearchAsync(string query);

		/// <summary>
		/// Gets a page of people based on search query.
		/// </summary>
		/// <param name="query">Name of the person.</param>
		/// <param name="page">Number of page for search</param>
		/// <returns>Search Result with people and page data.</returns>
		Task<SearchResult<PeopleSearchItem>> SearchAsync(string query, int page);
	}
}