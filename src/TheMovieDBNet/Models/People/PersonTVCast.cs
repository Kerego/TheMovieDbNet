using Newtonsoft.Json;

namespace TheMovieDbNet.Models.People
{
	/// <summary>
	/// Represents data about person's tv cast.
	/// </summary>
	public class PersonTVCast : PersonCast
	{
		[JsonConstructor]
		internal PersonTVCast(
			int id, 
			string character, 
			string credit_id,
			string poster_path,
			int episode_count,
			string first_air_date,
			string name,
			string original_name)
			: base(id, character, credit_id, poster_path)
		{
			EpisodeCount = episode_count;
			FirstAirDate = first_air_date;
			Name = name;
			OriginalName = original_name;
		}

		/// <summary>
		/// Gets the number of episodes.
		/// </summary>
		public int EpisodeCount { get; }
		
		/// <summary>
		/// Gets the name of the tv series.
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Gets the name of the tv series in original language.
		/// </summary>
		public string OriginalName { get; }

		/// <summary>
		/// Gets the date of the first air.
		/// </summary>
		public string FirstAirDate { get; }
	}
}