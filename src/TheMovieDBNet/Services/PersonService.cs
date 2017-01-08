using System;
using System.Threading.Tasks;
using TheMovieDbNet.Converters;
using TheMovieDbNet.Models.Common;
using TheMovieDbNet.Models.People;

namespace TheMovieDbNet.Services
{
	/// <summary>
	/// Represents a service for accessing movie-related data.
	/// </summary>
	public class PersonService : Service, IPersonService
	{
		private Lazy<PeopleSearchItemConverter> _lazySearchConverter =
			new Lazy<PeopleSearchItemConverter>(() => new PeopleSearchItemConverter(), true);

		private Lazy<PersonConverter> _lazyPersonConverter =
			new Lazy<PersonConverter>(() => new PersonConverter(), true);

		private Lazy<PersonCreditsConverter> _lazyCreditsConverter =
			new Lazy<PersonCreditsConverter>(() => new PersonCreditsConverter(), true);

		private Lazy<TaggedImageCollectionConverter> _lazyTaggedCollectionConverter =
			new Lazy<TaggedImageCollectionConverter>(() => new TaggedImageCollectionConverter(), true);

		/// <summary>
		/// Initializes a new instance of PeopleService.
		/// </summary>
		/// <param name="apiKey">API key from the movie db developer site</param>
		public PersonService(string apiKey) : base(apiKey)
		{
		}

		/// <summary>
		/// Gets details of a person.
		/// </summary>
		/// <param name="id">Person identifier.</param>
		/// <returns>Object of type person with fields filled with data.</returns>
		public async Task<Person> GetDetailsAsync(int id) => await GetDetailsAsync(id, string.Empty);

		/// <summary>
		/// Gets details of a person.
		/// </summary>
		/// <param name="id">Person identifier.</param>
		/// <param name="append">Additional info to append to the response (eg: images, videos).</param>
		/// <returns>Object of type person with fields filled with data.</returns>
		public async Task<Person> GetDetailsAsync(int id, string append)
		{
			var path = $"/3/person/{id}?api_key={apiKey}&append_to_response={append}";
			return await RequestAndDeserialize<Person>(path, _lazyPersonConverter.Value);
		}

		/// <summary>
		/// Gets details of a person.
		/// </summary>
		/// <param name="id">Person identifier.</param>
		/// <param name="settings">Additional info to append to the response (eg: images, videos).</param>
		/// <returns>Object of type person with fields filled with data.</returns>
		public async Task<Person> GetDetailsAsync(int id, PersonAppendSettings settings)
			=> await GetDetailsAsync(id, settings.ToString());

		/// <summary>
		/// Gets the cast and crew of the person.
		/// </summary>
		/// <param name="id">person identifier.</param>
		/// <returns>Credits of the person.</returns>
		public async Task<PersonCredits> GetCreditsAsync(int id)
			=> await GetCreditsAsync(id, string.Empty);

		/// <summary>
		/// Gets the cast and crew of the person.
		/// </summary>
		/// <param name="id">Person identifier.</param>
		/// <param name="language">Language of the media.</param>
		/// <returns>Credits of the person.</returns>
		public async Task<PersonCredits> GetCreditsAsync(int id, string language)
		{
			var path = $"/3/person/{id}/combined_credits?api_key={apiKey}";
			if (!string.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			return await RequestAndDeserialize<PersonCredits>(path, _lazyCreditsConverter.Value);
		}

		/// <summary>
		/// Gets the images of the person.
		/// </summary>
		/// <param name="id">person identifier.</param>
		/// <returns>Collection with the images of the person.</returns>
		public async Task<Image[]> GetImagesAsync(int id)
		{
			var path = $"/3/person/{id}/images?api_key={apiKey}";
			return await RequestAndSelect<Image[]>(path, "profiles");
		}

		/// <summary>
		/// Gets the tagged images of the person.
		/// </summary>
		/// <param name="id">person identifier.</param>
		/// <returns>Collection with the images of the person.</returns>
		public async Task<TaggedImageCollection> GetTaggedImagesAsync(int id)
			=> await GetTaggedImagesAsync(id, 0, string.Empty);

		/// <summary>
		/// Gets the tagged images of the person.
		/// </summary>
		/// <param name="id">person identifier.</param>
		/// <param name="page">Page of the tagged images search result.</param>
		/// <returns>Collection with the images of the person.</returns>
		public async Task<TaggedImageCollection> GetTaggedImagesAsync(int id, int page)
			=> await GetTaggedImagesAsync(id, page, string.Empty);


		/// <summary>
		/// Gets the tagged images of the person.
		/// </summary>
		/// <param name="id">person identifier.</param>
		/// <param name="language">Language of the image.</param>
		/// <param name="page">Page of the tagged images search result.</param>
		/// <returns>Collection with the images of the person.</returns>
		public async Task<TaggedImageCollection> GetTaggedImagesAsync(int id, int page, string language)
		{
			var path = $"/3/person/{id}/tagged_images?api_key={apiKey}";
			if (page > 0)
				path += $"&page={page}";
			if (!String.IsNullOrWhiteSpace(language))
				path += $"&language={language}";
			return await RequestAndDeserialize<TaggedImageCollection>(path, _lazyTaggedCollectionConverter.Value);
		}

		/// <summary>
		/// Gets a page of people based on search query.
		/// </summary>
		/// <param name="settings">Settings class for detailed search</param>
		/// <returns>Search Result with people and page data.</returns>
		public async Task<SearchResult<PeopleSearchItem>> SearchAsync(PeopleSearchSettings settings)
		{
			var path = $"/3/search/person?api_key={apiKey}{settings}";
			return await RequestAndDeserialize<SearchResult<PeopleSearchItem>>(path, _lazySearchConverter.Value);
		}

		/// <summary>
		/// Gets a page of people based on search query.
		/// </summary>
		/// <param name="query">Name of the person.</param>
		/// <returns>Search Result with people and page data.</returns>
		public async Task<SearchResult<PeopleSearchItem>> SearchAsync(string query)
		{
			var settings = new PeopleSearchSettings
			{
				Query = query,
				Page = 1
			};
			return await SearchAsync(settings);
		}

		/// <summary>
		/// Gets a page of people based on search query.
		/// </summary>
		/// <param name="query">Name of the person.</param>
		/// <param name="page">Number of page for search</param>
		/// <returns>Search Result with people and page data.</returns>
		public async Task<SearchResult<PeopleSearchItem>> SearchAsync(string query, int page)
		{
			var settings = new PeopleSearchSettings
			{
				Query = query,
				Page = page
			};
			return await SearchAsync(settings);
		}
	}
}