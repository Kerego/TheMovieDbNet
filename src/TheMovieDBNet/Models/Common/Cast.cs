using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Common
{
	/// <summary>
	/// Represents base data about cast.
	/// </summary>
	public class Cast
	{
		[JsonConstructor]
		internal Cast(int id, string character, string credit_id)
		{
			Id = id;
			Character = character;
			CreditId = credit_id;
		}
		
		/// <summary>
		/// Gets the character name.
		/// </summary>
		public string Character { get; }
		/// <summary>
		/// Gets identifier of coresponding credit.
		/// </summary>
		public string CreditId { get; }
		
		/// <summary>
		/// Gets person identifier.
		/// </summary>
		public int Id { get; }
	}
}