using Newtonsoft.Json;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models.TVs
{
	/// <summary>
	/// Represents the basic info of a tv.
	/// </summary>
	public class TVBase : MediaBase
	{
		[JsonConstructor]
		internal TVBase(
			int id,
			double popularity,
			string poster_path,
			string backdrop_path,
			string overview,
			double vote_average,
			int vote_count,
			string first_air_date,
			string[] origin_country,
			string name,
			string original_name)
		: base(
			id,
			popularity,
			poster_path,
			backdrop_path,
			overview,
			vote_average,
			vote_count)
		{
			FirstAirDate = first_air_date;
			OriginCountry = origin_country;
			Name = name;
			OriginalName = original_name;
		}

		/// <summary>
		/// Gets the date of the first air.
		/// </summary>
		public string FirstAirDate { get; }
		/// <summary>
		/// Gets the array of origin countries
		/// </summary>
		public string[] OriginCountry { get; }
		/// <summary>
		/// Gets the name of the tv series.
		/// </summary>
		public string Name { get; }
		/// <summary>
		/// Gets the name of the tv series in original language.
		/// </summary>
		public string OriginalName { get; }
	}
}