using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TheMovieDbNet.Models.Common;
using TheMovieDbNet.Models.Movies;
using TheMovieDbNet.Models.People;
using TheMovieDbNet.Models.TVs;

namespace TheMovieDbNet.Converters
{
	internal class PersonConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType) => objectType == typeof(Person);

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JObject jo = JObject.Load(reader);
			Person person = jo.ToObject<Person>();

			person.MovieCast = jo
				.SelectToken("movie_credits.cast")
				?.ToObject<PersonMovieCast[]>()
				?? 	jo.SelectToken("combined_credits.cast")
					?.Where(x => (string)x["media_type"] == "movie")
					.Select(x => x.ToObject<PersonMovieCast>()).ToArray();
			
			
			person.MovieCrew = jo
				.SelectToken("movie_credits.crew")
				?.ToObject<PersonMovieCrew[]>()
				?? 	jo.SelectToken("combined_credits.crew")
					?.Where(x => (string)x["media_type"] == "movie")
					.Select(x => x.ToObject<PersonMovieCrew>()).ToArray();
			
			
			person.TVCast = jo
				.SelectToken("tv_credits.cast")
				?.ToObject<PersonTVCast[]>()
				?? 	jo.SelectToken("combined_credits.cast")
					?.Where(x => (string)x["media_type"] == "tv")
					.Select(x => x.ToObject<PersonTVCast>()).ToArray();

			
			person.TVCrew = jo
				.SelectToken("tv_credits.crew")
				?.ToObject<PersonTVCrew[]>()
				?? 	jo.SelectToken("combined_credits.crew")
					?.Where(x => (string)x["media_type"] == "tv")
					.Select(x => x.ToObject<PersonTVCrew>()).ToArray();
				 
			person.Images = jo.SelectToken("images.profiles")?.ToObject<Image[]>();

			person.MovieTaggedImages = jo
				.SelectToken("tagged_images.results")
				?.Where(x => (string)x["media_type"] == "movie")
				.Select(x => x.ToObject<TaggedImage<MovieSearchItem>>()).ToArray();
				
			person.TVTaggedImages = jo
				.SelectToken("tagged_images.results")
				?.Where(x => (string)x["media_type"] == "tv")
				.Select(x => x.ToObject<TaggedImage<TVSearchItem>>()).ToArray();

			return person;
		}
		
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}