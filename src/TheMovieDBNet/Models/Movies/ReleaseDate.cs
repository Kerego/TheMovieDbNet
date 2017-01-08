using System;
using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Movies
{
	/// <summary>
	/// Represents realease date along with certification.
	/// </summary>
	public class ReleaseDate
	{
		[JsonConstructor]
		internal ReleaseDate(
			ReleaseType type,
			string certification,
			string note,
			string iso_639_1,
			DateTime release_date)
		{
			Type = type;
			Certification = certification;
			Note = note;
			Iso6391 = iso_639_1;
			Value = release_date;
		}
		/// <summary>
		/// Gets the certification.
		/// </summary>
		public string Certification { get; }

		/// <summary>
		/// Gets the iso_639_1.
		/// </summary>
		public string Iso6391 { get; }

		/// <summary>
		/// Gets the note related to release.
		/// </summary>
		public string Note { get; }

		/// <summary>
		/// Gets the release date.
		/// </summary>
		public DateTime Value { get; }

		/// <summary>
		/// Gets type of release.
		/// </summary>
		public ReleaseType Type { get; }
	}
}