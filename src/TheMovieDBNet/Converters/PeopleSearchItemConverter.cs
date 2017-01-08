using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TheMovieDbNet.Models.Movies;
using TheMovieDbNet.Models.People;
using TheMovieDbNet.Models.TVs;

namespace TheMovieDbNet.Converters
{
	internal class PeopleSearchItemConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType) => objectType == typeof(PeopleSearchItem);

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JObject jo = JObject.Load(reader);
			PeopleSearchItem psi = jo.ToObject<PeopleSearchItem>();
			
			psi.MoviesKnownFor = jo
				.SelectToken("known_for")?.Where(x => (string)x["media_type"] == "movie")
				.Select(x => x.ToObject<MovieSearchItem>()).ToArray();

			psi.TVsKnownFor = jo
				.SelectToken("known_for")?.Where(x => (string)x["media_type"] == "tv")
				.Select(x => x.ToObject<TVSearchItem>()).ToArray();
			return psi;
		}
		
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}