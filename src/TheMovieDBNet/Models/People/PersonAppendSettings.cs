using System.Text;

namespace TheMovieDbNet.Models.People
{
	/// <summary>
	/// Represents settings used for appending data to movie details response.
	/// </summary>
	public class PersonAppendSettings
	{
		/// <summary>
		/// Gets or Sets whether to append combined credits to main data or not.
		/// </summary>
		public bool IncludeCombinedCredits { get; set; }
		
		/// <summary>
		/// Gets or Sets whether to append tv credits to main data or not.
		/// </summary>
		public bool IncludeTVCredits { get; set; }
		
		/// <summary>
		/// Gets or Sets whether to append movie credits to main data or not.
		/// </summary>
		public bool IncludeMovieCredits { get; set; }
		/// <summary>
		/// Gets or Sets whether to append images to main data or not.
		/// </summary>
		public bool IncludeImages { get; set; }
		
		/// <summary>
		/// Gets or Sets whether to append tagged images to main data or not.
		/// </summary>
		public bool IncludeTaggedImages { get; set; }

		/// <summary>
		/// Gets the settings in form of comma separated values.
		/// </summary>
		/// <returns>String to use in query.</returns>
		public override string ToString() 
		{
			var query = new StringBuilder();
			if(IncludeImages)
				query.Append("images,");
			if(IncludeImages)
				query.Append("tagged_images,");
			if(IncludeCombinedCredits)
				query.Append("combined_credits,");
			if(IncludeTVCredits)
				query.Append("tv_credits,");
			if(IncludeMovieCredits)
				query.Append("movie_credits,");
			return query.ToString();
		}
	}
}