using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TheMovieDbNet.Models.People;

namespace TheMovieDbNet.Converters
{
	internal class PersonCreditsConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType) => objectType == typeof(PersonCredits);

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JObject jo = JObject.Load(reader);
			PersonCredits credits = jo.ToObject<PersonCredits>();

			credits.MovieCast = jo.SelectToken("cast")
					?.Where(x => (string)x["media_type"] == "movie")
					.Select(x => x.ToObject<PersonMovieCast>()).ToArray();
			
			
			credits.MovieCrew = jo.SelectToken("crew")
					?.Where(x => (string)x["media_type"] == "movie")
					.Select(x => x.ToObject<PersonMovieCrew>()).ToArray();
			
			
			credits.TVCast = jo.SelectToken("cast")
					?.Where(x => (string)x["media_type"] == "tv")
					.Select(x => x.ToObject<PersonTVCast>()).ToArray();

			
			credits.TVCrew = jo.SelectToken("crew")
					?.Where(x => (string)x["media_type"] == "tv")
					.Select(x => x.ToObject<PersonTVCrew>()).ToArray();
				 
			return credits;
		}
		
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}