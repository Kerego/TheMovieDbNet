using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Companies
{
	/// <summary>
	/// Represents data about a company.
	/// </summary>
	public class Company : CompanySearchItem
	{
		[JsonConstructor]
		internal Company(
			int id,
			string name,
			string logo_path,
			string description,
			string headquarters,
			string homepage,
			string parent_company)
		: base(id, name, logo_path)
		{
			Description = description;
			Headquarters = headquarters;
			Homepage = homepage;
			ParentCompany = parent_company;
		}

		/// <summary>
		/// Gets the description of the company.
		/// </summary>
		public string Description { get; }
		/// <summary>
		/// Gets the headquarters location.
		/// </summary>
		public string Headquarters { get; }
		/// <summary>
		/// Gets the homepage of the company.
		/// </summary>
		public string Homepage { get; }
		/// <summary>
		/// Gets the parent company.
		/// </summary>
		public string ParentCompany { get; }
	}
}