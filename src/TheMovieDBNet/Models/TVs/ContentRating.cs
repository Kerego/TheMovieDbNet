using Newtonsoft.Json;

namespace TheMovieDbNet.Models.TVs
{
	/// <summary>
	/// Represents the content rating of the tv series in a country.
	/// </summary>
	public class ContentRating
	{
		[JsonConstructor]
		internal ContentRating(string iso_3166_1, string rating)
		{
			Iso31661 = iso_3166_1;
			Rating = rating;
		}
		/// <summary>
		/// Gets the iso_3166_1 name of the country.
		/// </summary>
		public string Iso31661 { get; }

		/// <summary>
		/// Gets the rating of the tv series.
		/// </summary>
		public string Rating { get; }
	}
}