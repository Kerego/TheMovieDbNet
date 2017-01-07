using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Common
{
	/// <summary>
	/// Represents an identifiable object.
	/// </summary>
	public class Entity
	{
		[JsonConstructor]
		internal Entity(int id)
		{
			Id = id;
		}
		/// <summary>
		/// Gets the identity of object.
		/// </summary>
		public int Id { get; }
	}
}
