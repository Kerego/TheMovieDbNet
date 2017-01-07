using Newtonsoft.Json;

namespace TheMovieDbNet.Models.People
{
	/// <summary>
	/// Represents data about person's movie cast.
	/// </summary>
	public class PersonMovieCast : PersonCast
	{
		
		[JsonConstructor]
		internal PersonMovieCast(
			int id, 
			string character, 
			string credit_id,
			string poster_path,
			bool adult,
			string original_title,
			string title,
			string release_date)
			: base(id, character, credit_id, poster_path)
		{
			Adult = adult;
			OriginalTitle = original_title;
			Title = title;
			ReleaseDate = release_date;
		}
		
		/// <summary>
		/// Gets whether the movie is an adult one or not.
		/// </summary>
		public bool Adult { get; }
		
		/// <summary>
		/// Gets the title of the movie in original language.
		/// </summary>
		public string OriginalTitle { get; }

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