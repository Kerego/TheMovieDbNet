using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Common
{
	/// <summary>
	/// Represents a existing translation of the media.
	/// </summary>
	public class Translation
	{
		
		[JsonConstructor]
		internal Translation(string iso_639_1, string iso_3166_1, string name, string english_name)
		{
			Iso6391 = iso_639_1;
			Iso31661 = iso_3166_1;
			Name = name;
			EnglishName = english_name;
		}

		/// <summary>
		/// Gets the iso_639_1.
		/// </summary>
		public string Iso6391 { get; }

		/// <summary>
		/// Gets the iso_3166_1.
		/// </summary>
		public string Iso31661 { get; }

		/// <summary>
		/// Gets the name of the language in original.
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Gets the name of the language in english.
		/// </summary>
		public string EnglishName { get; }
	}
}