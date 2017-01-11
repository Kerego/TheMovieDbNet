using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Common
{
	/// <summary>
	/// Represents the tmdb configurations for building image paths.
	/// </summary>
	public class Configuration
	{
		[JsonConstructor]
		internal Configuration(
			string base_url,
			string secure_base_url,
			string[] backdrop_sizes,
			string[] logo_sizes,
			string[] poster_sizes,
			string[] profile_sizes,
			string[] still_sizes
		)
		{
			BaseUrl = base_url;
			SecureBaseUrl = secure_base_url;
			BackdropSizes = backdrop_sizes;
			LogoSizes = logo_sizes;
			PosterSizes = poster_sizes;
			ProfileSizes = profile_sizes;
			StillSizes = still_sizes;
		}

		/// <summary>
		/// Gets the base url of the images.
		/// </summary>
		public string BaseUrl { get; }
		/// <summary>
		/// Gets the secure base url of the images.
		/// </summary>
		public string SecureBaseUrl { get; }
		/// <summary>
		/// Gets the backdrop image sizes.
		/// </summary>
		public string[] BackdropSizes { get; }
		/// <summary>
		/// Gets the logo image sizes.
		/// </summary>
		public string[] LogoSizes { get; }
		/// <summary>
		/// Gets the poster image sizes.
		/// </summary>
		public string[] PosterSizes { get; }
		/// <summary>
		/// Gets the profile image sizes.
		/// </summary>
		public string[] ProfileSizes { get; }
		/// <summary>
		/// Gets the still image sizes.
		/// </summary>
		public string[] StillSizes { get; }
	}
}