using System;
using Newtonsoft.Json;
using TheMovieDbNet.Models.Common;
using TheMovieDbNet.Models.Movies;
using TheMovieDbNet.Models.TVs;

namespace TheMovieDbNet.Models.People
{
	/// <summary>
	/// Represents an item from people search.
	/// </summary>
	public class Person : PersonBase
	{
		[JsonConstructor]
		internal Person(
			int id,
			string profile_path,
			bool adult,
			string name,
			double popularity,
			string[] also_known_as,
			string biography,
			DateTime? birthday,
			DateTime? deathday,
			int gender,
			string homepage,
			string imdb_id,
			string place_of_birth,
			PeopleExternals external_ids) : base(id, profile_path, adult, name, popularity)
		{
			AlsoKnownAs = also_known_as;
			Biography = biography;
			Birthday = birthday;
			Deathday = deathday;
			Gender = gender;
			Homepage = homepage;
			ImdbId = imdb_id;
			PlaceOfBirth = place_of_birth;
			ExternalIds = external_ids;
		}

		/// <summary>
		/// Gets the pseudonimes of the person.
		/// </summary>
		public string[] AlsoKnownAs { get; }

		/// <summary>
		/// Gets the short biography of the person.
		/// </summary>
		public string Biography { get; }
		/// <summary>
		/// Gets the birthday of the person.
		/// </summary>
		public DateTime? Birthday { get; }

		/// <summary>
		/// Gets the deathday of the person.
		/// </summary>
		public DateTime? Deathday { get; }

		/// <summary>
		/// Gets the gender of the person (0 - male, 1 - female).
		/// </summary>
		public int Gender { get; }

		/// <summary>
		/// Gets the homepage of the person.
		/// </summary>
		public string Homepage { get; }

		/// <summary>
		/// Gets the imdb identifier of the person.
		/// </summary>
		public string ImdbId { get; }

		/// <summary>
		/// Gets the place of birth.
		/// </summary>
		public string PlaceOfBirth { get; }

		/// <summary>
		/// Gets the identifier of person on external sites.
		/// </summary>
		public PeopleExternals ExternalIds { get; }

		/// <summary>
		/// Gets or Sets the persons movie casts.
		/// </summary>
		[JsonIgnore]
		public PersonMovieCast[] MovieCast { get; set; }

		/// <summary>
		/// Gets or Sets the person tv casts.
		/// </summary>
		[JsonIgnore]
		public PersonTVCast[] TVCast { get; set; }

		/// <summary>
		/// Gets or Sets the person tv crew appearances.
		/// </summary>
		[JsonIgnore]
		public PersonMovieCrew[] MovieCrew { get; set; }

		/// <summary>
		/// Gets or Sets the person tv crew appearances.
		/// </summary>
		[JsonIgnore]
		public PersonTVCrew[] TVCrew { get; set; }

		/// <summary>
		/// Gets or Sets the person profile pictures.
		/// </summary>
		[JsonIgnore]
		public Image[] Images { get; set; }

		/// <summary>
		/// Gets or Sets the images of movies person appeared in.
		/// </summary>
		[JsonIgnore]
		public TaggedImage<MovieSearchItem>[] MovieTaggedImages { get; set; }

		/// <summary>
		/// Gets or Sets the images of tv person appeared in.
		/// </summary>
		[JsonIgnore]
		public TaggedImage<TVSearchItem>[] TVTaggedImages { get; set; }
	}
}