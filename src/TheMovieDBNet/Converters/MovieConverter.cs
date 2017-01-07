using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TheMovieDbNet.Models.Common;
using TheMovieDbNet.Models.Movies;

namespace TheMovieDbNet.Models
{
	internal class MovieConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType) => objectType == typeof(Movie);

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JObject jo = JObject.Load(reader);
			Movie movie = jo.ToObject<Movie>();
			movie.Videos = jo.SelectToken("videos.results")?.ToObject<Video[]>();
			movie.Posters = jo.SelectToken("images.posters")?.ToObject<Image[]>();
			movie.Backdrops = jo.SelectToken("images.backdrops")?.ToObject<Image[]>();
			movie.Cast = jo.SelectToken("credits.cast")?.ToObject<MovieCast[]>();
			movie.Crew = jo.SelectToken("credits.crew")?.ToObject<MovieCrew[]>();
			movie.AlternativeTitles = jo.SelectToken("alternative_titles.titles")?.ToObject<AlternativeTitle[]>();
			movie.Keywords = jo.SelectToken("keywords.keywords")?.ToObject<Keyword[]>();
			movie.ReleaseInfo = jo.SelectToken("release_dates.results")?.ToObject<ReleaseInfo[]>();
			movie.Translations = jo.SelectToken("translations.translations")?.ToObject<Translation[]>();
			return movie;
		}
		
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}