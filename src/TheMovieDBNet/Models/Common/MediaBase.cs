using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Common
{
	/// <summary>
	/// Represents the basic info of a media.
	/// </summary>
	public class MediaBase : Entity
	{
		[JsonConstructor]
		internal MediaBase(
			int id,
			double popularity,
			string poster_path,
			string backdrop_path,
			string overview,
			double vote_average,
			int vote_count
		) : base(id)
		{
			Popularity = popularity;
			PosterPath = poster_path;
			BackdropPath = backdrop_path;
			Overview = overview;
			VoteAverage = vote_average;
			VoteCount = vote_count;
		}
		/// <summary>
		/// Gets the popularity of the movie.
		/// </summary>
		public double Popularity { get; }	
		
		/// <summary>
		/// Gets the path to the poster image.
		/// </summary>
		public string PosterPath { get; }

		/// <summary>
		/// Gets the path to the backdrop.
		/// </summary>
		public string BackdropPath { get; }
		
		/// <summary>
		/// Gets the overview of the movie's plot.
		/// </summary>
		public string Overview { get; }
		
		/// <summary>
		/// Gets the average rating of the movie.
		/// </summary>
		public double VoteAverage { get; }

		/// <summary>
		/// Gets the vote counts for the movie.
		/// </summary>
		public int VoteCount { get; }
		

	}
}