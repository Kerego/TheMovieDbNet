using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models.TVs
{
	/// <summary>
	/// Represents movie settings used in search.
	/// </summary>
	public class TVSearchSettings : SearchSettings
	{
		/// <summary>
		/// Gets or Sets language of search query
		/// </summary>
		public string Language { get; set; }
		
		/// <summary>
		/// Gets or Sets primary release year of the seached movie
		/// </summary>
		public int FirstAirDateYear { get; set; }

		/// <summary>
		/// Converts to string to use in search queries.
		/// </summary>
		/// <returns>String form of query.</returns>
		public override string ToString() 
		{
			var result = base.ToString();
			if (!string.IsNullOrWhiteSpace(Language))
				result += $"&language={Language}";
				
			if (FirstAirDateYear > 1900)
				result += $"&first_air_date_year={FirstAirDateYear}";

			return result;
		}
	}
}