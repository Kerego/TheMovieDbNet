using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TheMovieDbNet.Models.Movies;
using TheMovieDbNet.Models.People;
using TheMovieDbNet.Models.TVs;

namespace TheMovieDbNet.Converters
{
	internal class TaggedImageCollectionConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType) => objectType == typeof(TaggedImageCollection);

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JObject jo = JObject.Load(reader);
			TaggedImageCollection collection = jo.ToObject<TaggedImageCollection>();

			collection.MovieTaggedImages = jo
				.SelectToken("results")
				?.Where(x => (string)x["media_type"] == "movie")
				.Select(x => x.ToObject<TaggedImage<MovieSearchItem>>()).ToArray();
				
			collection.TVTaggedImages = jo
				.SelectToken("results")
				?.Where(x => (string)x["media_type"] == "tv")
				.Select(x => x.ToObject<TaggedImage<TVSearchItem>>()).ToArray();
				
			return collection;
		}
		
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}