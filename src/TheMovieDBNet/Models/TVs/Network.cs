using Newtonsoft.Json;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models.TVs
{
	/// <summary>
	/// Represents a tv network.
	/// </summary>
	public class Network : Entity
	{
		[JsonConstructor]
		internal Network(int id) : base(id)
		{
		}
		/// <summary>
		/// Gets the name of the network.
		/// </summary>
		public string Name { get; }
	}
}