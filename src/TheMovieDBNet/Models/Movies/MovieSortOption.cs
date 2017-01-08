namespace TheMovieDbNet.Models.Movies
{
	/// <summary>
	/// Represents the sort options for dicovery.
	/// </summary>
	public enum MovieSortOption
	{
		/// <summary>
		/// Sort by popularity descending.
		/// </summary>
		PopularityDescending,
		/// <summary>
		/// Sort by popularity ascending.
		/// </summary>
		Popularity,
		/// <summary>
		/// Sort by vote_average descending.
		/// </summary>
		VoteAverageDescending,
		/// <summary>
		/// Sort by vote_average ascending.
		/// </summary>
		VoteAverage,
		/// <summary>
		/// Sort by release_date descending.
		/// </summary>
		ReleaseDateDescending,
		/// <summary>
		/// Sort by release_date ascending.
		/// </summary>
		ReleaseDate, 
		/// <summary>
		/// Sort by revenue descending.
		/// </summary>
		RevenueDescending,
		/// <summary>
		/// Sort by revenue ascending.
		/// </summary>
		Revenue, 
		/// <summary>
		/// Sort by primary_release_date descending.
		/// </summary>
		PrimaryReleaseDateDescending,
		/// <summary>
		/// Sort by primary_release_date ascending.
		/// </summary>
		PrimaryReleaseDate, 
		/// <summary>
		/// Sort by original_title descending.
		/// </summary>
		OriginalTitleDescending,
		/// <summary>
		/// Sort by original_title ascending.
		/// </summary>
		OriginalTitle,
		/// <summary>
		/// Sort by vote_count descending.
		/// </summary>
		VoteCountDescending,
		/// <summary>
		/// Sort by vote_count ascending.
		/// </summary>
		VoteCount

	}
}