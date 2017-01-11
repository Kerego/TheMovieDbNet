using System.Text;

namespace TheMovieDbNet.Models.TVs
{
	/// <summary>
	/// Represents settings used for appending data to tv details response.
	/// </summary>
	public class TVAppendSettings
	{
		/// <summary>
		/// Gets or Sets whether to append credits to main data or not.
		/// </summary>
		public bool IncludeCredits { get; set; }
		/// <summary>
		/// Gets or Sets whether to append images to main data or not.
		/// </summary>
		public bool IncludeImages { get; set; }
		/// <summary>
		/// Gets or Sets whether to append recommendations to main data or not.
		/// </summary>
		public bool IncludeRecommendations { get; set; }
		/// <summary>
		/// Gets or Sets whether to append similar tvs to main data or not.
		/// </summary>
		public bool IncludeSimilarTVs { get; set; }
		/// <summary>
		/// Gets or Sets whether to append videos to main data or not.
		/// </summary>
		public bool IncludeVideos { get; set;}
		/// <summary>
		/// Gets or Sets whether to append alternative titles to main data or not.
		/// </summary>
		public bool IncludeAlternativeTitles { get; set; }
		/// <summary>
		/// Gets or Sets whether to append keywords to main data or not.
		/// </summary>
		public bool IncludeKeywords { get; set; }
		/// <summary>
		/// Gets or Sets whether to append translations to main data or not.
		/// </summary>
		public bool IncludeTranslations { get; set; }
		/// <summary>
		/// Gets or Sets whether to include the external ids.
		/// </summary>
		public bool IncludeExternalIds { get; set; }
		/// <summary>
		/// Gets or Sets whether to append content ratings to main data or not.
		/// </summary>
		public bool IncludeContentRatings { get; set; }

		/// <summary>
		/// Gets the settings in form of comma separated values.
		/// </summary>
		/// <returns>String to use in query.</returns>
		public override string ToString() 
		{
			var query = new StringBuilder();
			if(IncludeImages)
				query.Append("images,");
			if(IncludeCredits)
				query.Append("credits,");
			if(IncludeRecommendations)
				query.Append("recommendations,");
			if(IncludeAlternativeTitles)
				query.Append("alternative_titles,");
			if(IncludeVideos)
				query.Append("videos,");
			if(IncludeKeywords)
				query.Append("keywords,");
			if(IncludeSimilarTVs)
				query.Append("similar,");
			if(IncludeTranslations)
				query.Append("translations,");
			if(IncludeContentRatings)
				query.Append("content_ratings,");
			if(IncludeExternalIds)
				query.Append("external_ids,");
			return query.ToString();
		}
	}
}