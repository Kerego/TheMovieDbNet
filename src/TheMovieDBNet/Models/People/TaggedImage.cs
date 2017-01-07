using Newtonsoft.Json;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models.People
{
	/// <summary>
	/// Represents images from media for a person.
	/// </summary>
	public class TaggedImage<T> : Image
	{
		[JsonConstructor]
		internal TaggedImage(
			string id,
			string image_type,
			T media,
			double aspect_ratio, 
			string file_path, 
			int height, 
			int width, 
			string iso_639_1, 
			double vote_average,
			int vote_count) 
		: base(aspect_ratio, file_path, height, width, iso_639_1, vote_average, vote_count)
		{
			Id = id;
			ImageType = image_type;
			Media = media;
		}
		
		/// <summary>
		/// Gets the person identifier.
		/// </summary>
		public string Id { get; }

		/// <summary>
		/// Gets the image type.
		/// </summary>
		public string ImageType { get; }

		/// <summary>
		/// Gets or Sets the media image belongs to.
		/// </summary>
		[JsonIgnore]
		public T Media { get; set; }
	}
}