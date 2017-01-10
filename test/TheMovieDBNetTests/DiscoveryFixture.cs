using System;
using System.IO;
using TheMovieDbNet.Services;

namespace TheMovieDbNet.Tests
{
	public class DiscoveryFixture : IDisposable
	{
		public ISearchService SearchService;
		public IMovieService MoviesService;

		public DiscoveryFixture()
		{
			var api = File.ReadAllText("src/Samples/secrets.txt");
			SearchService = new SearchService(api);
			MoviesService = new MovieService(api);
		}
		public void Dispose()
		{
			SearchService.Dispose();
			MoviesService.Dispose();
		}
	}
}