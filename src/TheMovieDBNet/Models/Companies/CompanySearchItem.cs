using Newtonsoft.Json;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models.Companies
{
	/// <summary>
	/// Represents the result of a search for companies.
	/// </summary>
	public class CompanySearchItem : Entity
	{
		[JsonConstructor]
		internal CompanySearchItem(int id, string name, string logo_path) : base(id)
		{
			Name = name;
			LogoPath = logo_path;
		}
		/// <summary>
		/// Gets the name of the company.
		/// </summary>
		public string Name { get; }
		/// <summary>
		/// Gets the logo of the company.
		/// </summary>
		public string LogoPath { get; }
	}
}