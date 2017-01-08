using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Common
{
	/// <summary>
	/// Represents the media credits.
	/// </summary>
	public class MediaCredits
	{
		[JsonConstructor]
		internal MediaCredits(int id, MediaCast[] cast, MediaCrew[] crew)
		{
			Id = id;
			Cast = cast;
			Crew = crew;
		}
		/// <summary>
		/// Gets the id of the media credits belong to.
		/// </summary>
		public int Id { get; }
		/// <summary>
		/// Gets the cast of the media.
		/// </summary>
		public MediaCast[] Cast { get; }
		/// <summary>
		/// Gets the crew of the media.
		/// </summary>
		public MediaCrew[] Crew { get; }
	}
}