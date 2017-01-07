using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Common
{
	/// <summary>
	/// Represents info about the language spoken in a movie
	/// </summary>
	public class SpokenLanguage
	{
		[JsonConstructor]
		internal SpokenLanguage(string iso_639_1, string name)
		{
			Iso6391 = iso_639_1;
			Name = name;
		}

		/// <summary>
		/// Gets the iso_639_1 name of language
		/// </summary>
		public string Iso6391 { get; }

		/// <summary>
		/// Gets the human name of language
		/// </summary>
		public string Name { get; }
	}
}