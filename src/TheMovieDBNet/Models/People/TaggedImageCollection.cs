using Newtonsoft.Json;
using TheMovieDbNet.Models.Movies;
using TheMovieDbNet.Models.TVs;

namespace TheMovieDbNet.Models.People
{
	/// <summary>
	/// Represents all the images person was tagged in.
	/// </summary>
	public class TaggedImageCollection
	{
		[JsonConstructor]
		internal TaggedImageCollection(int total_results, int total_pages, int page)
		{
			TotalResults = total_results;
			TotalPages = total_pages;
			Page = page;
		}

		/// <summary>
		/// Gets the total number of results available.
		/// </summary>
		public int TotalResults { get; }

		/// <summary>
		/// Gets the total number of pages available.
		/// </summary>

		public int TotalPages { get; }
		/// <summary>
		/// Gets the current page of the result.
		/// </summary>
		public int Page { get; }

		/// <summary>
		/// Gets or Sets the images of movies person appeared in.
		/// </summary>
		[JsonIgnore]
		public TaggedImage<MovieSearchItem>[] MovieTaggedImages { get; set; }

		/// <summary>
		/// Gets or Sets the images of tv person appeared in.
		/// </summary>
		[JsonIgnore]
		public TaggedImage<TVSearchItem>[] TVTaggedImages { get; set; }
	}
}