using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TheMovieDbNet.Models.Common;
using TheMovieDbNet.Models.TVs;

namespace TheMovieDbNet.Converters
{
	internal class TVConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType) => objectType == typeof(TV);

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JObject jo = JObject.Load(reader);
			TV tv = jo.ToObject<TV>();
			tv.Videos = jo.SelectToken("videos.results")?.ToObject<Video[]>();
			tv.Posters = jo.SelectToken("images.posters")?.ToObject<Image[]>();
			tv.Backdrops = jo.SelectToken("images.backdrops")?.ToObject<Image[]>();
			tv.Cast = jo.SelectToken("credits.cast")?.ToObject<MediaCast[]>();
			tv.Crew = jo.SelectToken("credits.crew")?.ToObject<MediaCrew[]>();
			tv.AlternativeTitles = jo.SelectToken("alternative_titles.results")?.ToObject<AlternativeTitle[]>();
			tv.Keywords = jo.SelectToken("keywords.results")?.ToObject<Keyword[]>();
			tv.Translations = jo.SelectToken("translations.translations")?.ToObject<Translation[]>();
			tv.ContentRatings = jo.SelectToken("content_ratings.results")?.ToObject<ContentRating[]>();
			return tv;
		}
		
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}