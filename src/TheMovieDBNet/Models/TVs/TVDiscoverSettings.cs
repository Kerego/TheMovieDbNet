using System;
using System.Linq;
using System.Text;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models.TVs
{
	/// <summary>
	/// Represents settings used to dicover media.
	/// </summary>
	public class TVDiscoverSettings : DiscoverSettings
	{
		/// <summary>
		/// Gets or Sets the sorting options for dicovery.
		/// </summary>
		public TVSortOption SortOption { get; set; } = TVSortOption.PopularityDescending;
		/// <summary>
		/// Gets or Sets the minimal air date.
		/// </summary>
		public DateTime MinAirDate { get; set; }
		/// <summary>
		/// Gets or Sets the maximal air date.
		/// </summary>
		public DateTime MaxAirDate { get; set; }
		/// <summary>
		/// Gets or Sets the minimal first air date.
		/// </summary>
		public DateTime MinFirstAirDate { get; set; }
		/// <summary>
		/// Gets or Sets the maximal first air date.
		/// </summary>
		public DateTime MaxFirstAirDate { get; set; }
		/// <summary>
		/// Gets or Sets the first air year.
		/// </summary>
		public int FirstAirYear { get; set; }
		/// <summary>
		/// Gets or Sets the collection of networks.
		/// </summary>
		public int[] Networks { get; set; }
		/// <summary>
		/// Gets or Sets whether to include non-released tv shows.
		/// </summary>
		public bool IncludeNullAirDates { get; set; }
		/// <summary>
		/// Gets or Sets the timezone
		/// </summary>
		public string Timezone { get; set; }
		/// <summary>
		/// Converts the settings to the query string representation.
		/// </summary>
		/// <returns>Query string.</returns>
		public override string ToString()
		{
			var query = new StringBuilder();
			query.Append(base.ToString());
			query.Append($"&sort_by={ConvertEnum(SortOption)}");
			if(!string.IsNullOrWhiteSpace(Timezone))
				query.Append($"&timezone={Timezone}");
			if(FirstAirYear > 0)
				query.Append($"&first_air_date_year={FirstAirYear}");
			if(IncludeNullAirDates)
				query.Append($"&include_null_first_air_dates=true");
			if(MinAirDate != default(DateTime))
				query.Append($"&air_date.gte={MinAirDate.ToString("yyyy-MM-dd")}");
			if(MaxAirDate != default(DateTime))
				query.Append($"&air_date.lte={MaxAirDate.ToString("yyyy-MM-dd")}");
			if(MinFirstAirDate != default(DateTime))
				query.Append($"&first_air_date.gte={MinFirstAirDate.ToString("yyyy-MM-dd")}");
			if(MaxFirstAirDate != default(DateTime))
				query.Append($"&first_air_date.lte={MaxFirstAirDate.ToString("yyyy-MM-dd")}");
			if (Networks?.Any() == true)
				query.Append($"&with_networks={String.Join(",", Networks)}");

			return query.ToString();
		}
	}
}