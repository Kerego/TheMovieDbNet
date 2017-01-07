using Newtonsoft.Json;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models.Movies
{
	
	/// <summary>
	/// Represents base class for object containing info about movies.
	/// </summary>
	public class MovieBase : MediaBase
	{
		[JsonConstructor]
		internal MovieBase(
			int id,
			bool adult,
			string original_language,
			string original_title,
			double popularity,
			string poster_path,
			string backdrop_path,
			string overview,
			string title,
			bool video,
			double vote_average,
			int vote_count,
			string release_date) 
		: base(
			id,
			popularity,
			poster_path,
			backdrop_path,
			overview,
			vote_average,
			vote_count)
		{
			Adult = adult;
			OriginalLanguage = original_language;
			OriginalTitle = original_title;
			Title = title;
			Video = video;
			ReleaseDate = release_date;
		}

		/// <summary>
		/// Gets whether the movie is an adult one or not.
		/// </summary>
		public bool Adult { get; }
		
		/// <summary>
		/// Gets the original language of the movie.
		/// </summary>
		public string OriginalLanguage { get; }

		/// <summary>
		/// Gets the title of the movie in original language.
		/// </summary>
		public string OriginalTitle { get; }
		
		/// <summary>
		/// Gets whether this is a video.
		/// </summary>
		public bool Video { get; }
		/// <summary>
		/// Gets the title of the movie.
		/// </summary>
		public string Title { get; }
		
		/// <summary>
		/// Gets the realease date of the movie.
		/// </summary>
		public string ReleaseDate { get; }

	}
}