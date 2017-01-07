using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Common
{
	/// <summary>
	/// Represents info about company that produces movies.
	/// </summary>
	public class ProductionCompany : Entity
	{
		[JsonConstructor]
		internal ProductionCompany(string name, int id) : base(id)
		{
			Name = name;
		}

		/// <summary>
		/// Gets the name of the company.
		/// </summary>
		public string Name { get; }
	}
}