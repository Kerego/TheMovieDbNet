using System;
using Newtonsoft.Json;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models.Movies
{
	/// <summary>
	/// Represents a generic class that holds data about paged data.
	/// </summary>
	public class DatedPagedResult<T> : PagedResult<T> where T : Entity
	{
		[JsonConstructor]
		internal DatedPagedResult(
			T[] results, 
			int total_results, 
			int total_pages, 
			int page,
			DatesRange dates) : base(results, total_results, total_pages, page)
		{
			Dates = dates;
		}

		/// <summary>
		/// Gets the date range of the search result.
		/// </summary>
		public DatesRange Dates { get;}
	}


	/// <summary>
	/// Represents a range of dates.
	/// </summary>
	public class DatesRange
	{
		[JsonConstructor]
		internal DatesRange(DateTime minimum, DateTime maximum)
		{
			Minimum = minimum;
			Maximum = maximum;
		}
		/// <summary>
		/// Gets the start date.
		/// </summary>
		public DateTime Minimum { get; }
		/// <summary>
		/// Gets the end date.
		/// </summary>
		public DateTime Maximum { get; }
	}
}