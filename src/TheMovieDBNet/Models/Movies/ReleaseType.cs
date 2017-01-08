namespace TheMovieDbNet.Models.Movies
{
	/// <summary>
	/// Represent a release type of a media.
	/// </summary>
	public enum ReleaseType
	{
		/// <summary>
		/// Premiere release in cinema.
		/// </summary>
		Premiere = 1,
		/// <summary>
		/// Limited release in theathers.
		/// </summary>
		LimitedTheatrical = 2,
		
		/// <summary>
		/// Premiere release in theathers.
		/// </summary>
		Theatrical = 3,
		
		/// <summary>
		/// Premiere digital release.
		/// </summary>
		Digital = 4,
		
		/// <summary>
		/// Premiere release on dvds, blu-rays.
		/// </summary>
		Physical = 5,
		
		/// <summary>
		/// Premiere release on tv.
		/// </summary>
		TV = 6
	}
}