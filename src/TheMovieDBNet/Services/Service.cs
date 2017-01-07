using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TheMovieDbNet.Services
{
	/// <summary>
	/// Represents a base service for making requests to the movie database
	/// </summary>
	public abstract class Service
	{
		/// <summary>
		/// Client for making http requests
		/// </summary>
		protected readonly HttpClient httpClient = new HttpClient();
		
		/// <summary>
		/// PI key from the movie db developer site
		/// </summary>
		protected readonly string apiKey;

		/// <summary>
		/// Initializes a new instance of the Service class.
		/// </summary>
		/// <param name="apiKey">API key from the movie db developer site</param>
		public Service(string apiKey)
		{
			this.apiKey = apiKey;
			httpClient.BaseAddress = new Uri("https://api.themoviedb.org/3/");
		}

		/// <summary>
		/// Makes a request to the path and then deserialize the result to the generic constraint.
		/// </summary>
		/// <param name="path">Path to the content.</param>
		/// <param name="customConverter">Custom Converter for deserialization.</param>
		/// <returns>The <typeparamref name="T"/> deserialized from json response.</returns>
		protected async Task<T> RequestAndDeserialize<T>(string path, JsonConverter customConverter)
		{
			using (var result = await httpClient.GetAsync(path))
			{
				var content = await result.Content.ReadAsStringAsync();
				if (!result.IsSuccessStatusCode)
					throw new Exception(content); //TODO use specific exception not the base
				return JsonConvert.DeserializeObject<T>(content, customConverter);
			}
		}
		
		/// <summary>
		/// Makes a request to the path and then deserialize the result to the generic constraint.
		/// </summary>
		/// <param name="path">Path to the content.</param>
		/// <returns>The <typeparamref name="T"/> deserialized from json response.</returns>
		protected async Task<T> RequestAndDeserialize<T>(string path)
		{
			using (var result = await httpClient.GetAsync(path))
			{
				var content = await result.Content.ReadAsStringAsync();
				if (!result.IsSuccessStatusCode)
					throw new Exception(content); //TODO use specific exception not the base
				return JsonConvert.DeserializeObject<T>(content);
			}
		}

		/// <summary>
		/// Makes a request to the path and then select the token from JObject and casts to generic constraint.
		/// </summary>
		/// <param name="path">Path to the content.</param>
		/// <param name="token">Path to the desired property.</param>
		/// <returns>The object deserialized from json response.</returns>
		protected async Task<T> RequestAndSelect<T>(string path, string token)
		{
			using (var result = await httpClient.GetAsync(path))
			{
				var content = await result.Content.ReadAsStringAsync();
				if (!result.IsSuccessStatusCode)
					throw new Exception(content); //TODO use specific exception not the base
				JObject obj = JObject.Parse(content);
				return obj.SelectToken(token).ToObject<T>();
			}
		}
	}
}