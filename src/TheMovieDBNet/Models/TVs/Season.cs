using System;
using Newtonsoft.Json;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models.TVs
{
	/// <summary>
	/// Represents a season of a tv series.
	/// </summary>
	public class Season : Entity
	{
		[JsonConstructor]
		internal Season(
			int id,
			DateTime? air_date,
			int episode_count,
			string poster_path,
			int season_number) : base(id)
		{
			AirDate = air_date;
			EpisodeCount = episode_count;
			PosterPath = poster_path;
			SeasonNumber = season_number;
		}
		/// <summary>
		/// Gets the air date of season.
		/// </summary>
		public DateTime?  AirDate { get; }
		/// <summary>
		/// Gets the number of episodes in the season.
		/// </summary>
		public int EpisodeCount { get; }
		/// <summary>
		/// Gets the path to the poster of the season.
		/// </summary>
		public string PosterPath { get; }
		/// <summary>
		/// Gets the number of the season.
		/// </summary>
		public int SeasonNumber { get; }
	}
}