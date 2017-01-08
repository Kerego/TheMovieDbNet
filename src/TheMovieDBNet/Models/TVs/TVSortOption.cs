namespace TheMovieDbNet.Models.TVs
{
	/// <summary>
	/// Represents the sort options for dicovery.
	/// </summary>
	public enum TVSortOption
	{
		/// <summary>
		/// Sort by first_air_date descending.
		/// </summary>
		FirstAirDateDescending,
		/// <summary>
		/// Sort by first_air_date ascending.
		/// </summary>
		FirstAirDate,
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
		VoteAverage

	}
}