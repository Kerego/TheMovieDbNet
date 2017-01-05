using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TheMovieDbNet.Models
{
    internal class MovieConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(Movie);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            Movie movie = jo.ToObject<Movie>();
            movie.Videos = jo.SelectToken("videos.results").ToObject<Video[]>();
            movie.Posters = jo.SelectToken("images.posters").ToObject<Image[]>();
            movie.Backdrops = jo.SelectToken("images.backdrops").ToObject<Image[]>();
            return movie;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}