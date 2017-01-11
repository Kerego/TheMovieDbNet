using System;
using System.Linq;
using System.Text;

namespace TheMovieDbNet.Models.Common
{
	/// <summary>
	/// Represents settings used to dicover media.
	/// </summary>
	public class DiscoverSettings
	{
		/// <summary>
		/// Gets or Sets the language of the media.
		/// </summary>
		public string Language { get; set; }
		/// <summary>
		/// Gets or Sets the page of dicover.
		/// </summary>
		public int Page { get; set; }
		/// <summary>
		/// Gets or Sets the minimal vote count.
		/// </summary>
		public int MinVoteCount { get; set; }
		/// <summary>
		/// Gets or Sets the genres to include in discover.
		/// </summary>
		public int[] Genres { get; set; }
		/// <summary>
		/// Gets or Sets the genres to exclude in discover.
		/// </summary>
		public int[] ExcludeGenres { get; set; }
		/// <summary>
		/// Gets or Sets the minimal runtime.
		/// </summary>
		public int MinRuntime { get; set; }
		/// <summary>
		/// Gets or Sets the maximal runtime.
		/// </summary>
		public int MaxRuntime { get; set; }
		/// <summary>
		/// Gets or Sets the original language.
		/// </summary>
		public string OriginalLanguage { get; set; }
		
		/// <summary>
		/// Gets or Sets the minimal vote avergae.
		/// </summary>
		public int MinVoteAverage { get; set; }

		/// <summary>
		/// Converts enum to the underscore query text for sorting.
		/// </summary>
		protected string ConvertEnum(Enum @enum)
		{
			if (@enum == null)
				throw new ArgumentNullException(nameof(@enum));

			string text = @enum.ToString();
			if (text.EndsWith("Descending"))
				text = text.Substring(0, text.Length - 10);

			StringBuilder result = new StringBuilder();

			result.Append(char.ToLower(text[0]));
			for (int i = 1; i < text.Length; i++)
			{
				if (char.IsLower(text[i]))
					result.Append(text[i]);
				else
				{
					result.Append('_');
					result.Append(char.ToLower(text[i]));
				}
			}

			if (@enum.ToString().EndsWith("Descending"))
				result.Append(".desc");
			else
				result.Append(".asc");
			return result.ToString();
		}

		/// <summary>
		/// Converts the settings to the query string representation.
		/// </summary>
		/// <returns>Query string.</returns>
		public override string ToString()
		{
			var query = new StringBuilder();
			if (!string.IsNullOrWhiteSpace(Language))
				query.Append($"&language={Language}");
			if (!string.IsNullOrWhiteSpace(OriginalLanguage))
				query.Append($"&with_original_language={OriginalLanguage}");
			if (Page > 0)
				query.Append($"&page={Page}");
			if (MinVoteCount > 0)
				query.Append($"&vote_count.gte={MinVoteCount}");
			if (MinRuntime > 0)
				query.Append($"&with_runtime.gte={MinRuntime}");
			if (MaxRuntime > 0)
				query.Append($"&with_runtime.lte={MaxRuntime}");
			if (MinVoteAverage > 0)
				query.Append($"&vote_average.gte={MinVoteAverage}");
			if (Genres?.Any() == true)
				query.Append($"&with_genres={String.Join(",", Genres)}");
			if (ExcludeGenres?.Any() == true)
				query.Append($"&without_genres={String.Join(",", ExcludeGenres)}");

			return query.ToString();
		}
	}


}