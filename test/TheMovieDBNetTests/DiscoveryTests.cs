using System.Linq;
using TheMovieDbNet.Models.Movies;
using Xunit;

namespace TheMovieDbNet.Tests
{
	public class DiscoveryTests : IClassFixture<DiscoveryFixture>
	{
		DiscoveryFixture _fixture;
		public DiscoveryTests(DiscoveryFixture fixture)
		{
			_fixture = fixture;
		}

		[Theory]
		[InlineData(1900)]
		[InlineData(2016)]
		public void ResultsShouldContainOnlyGivenYear(int year)
		{
			//Given
			var settings = new MovieDiscoverSettings();
			settings.Year = year;
			//When
			var data = _fixture.SearchService.DiscoverMovies(settings).Result;
			//Then
			Assert.True(data.Results.All(x=>x.ReleaseDate?.Year == year));
		}

		[Theory]
		[InlineData("de")]
		[InlineData("es")]
		public void ResultsShouldContainOnlyGivenLanguage(string language)
		{
			//Given
			var settings = new MovieDiscoverSettings();
			settings.OriginalLanguage = language;
			//When
			var data = _fixture.SearchService.DiscoverMovies(settings).Result;
			//Then
			Assert.True(data.Results.All(x=>x.OriginalLanguage == language));
		}

		[Theory]
		[InlineData(75)]
		public void ResultsShouldContainOnlyRuntimesHigher(int runtime)
		{
			//Given
			var settings = new MovieDiscoverSettings();
			settings.MinRuntime = runtime;
			//When
			var data = _fixture.SearchService.DiscoverMovies(settings).Result;
			var details = data.Results.Select(x => _fixture.MoviesService.GetDetailsAsync(x.Id).Result);
			//Then
			Assert.True(details.All(x=>x.Runtime >= runtime));
		}

		[Theory]
		[InlineData(100)]
		public void ResultsShouldContainOnlyRuntimesLower(int runtime)
		{
			//Given
			var settings = new MovieDiscoverSettings();
			settings.MaxRuntime = runtime;
			//When
			var data = _fixture.SearchService.DiscoverMovies(settings).Result;
			var details = data.Results.Select(x => _fixture.MoviesService.GetDetailsAsync(x.Id).Result);
			//Then
			Assert.True(details.All(x=>x.Runtime <= runtime));
		}

		[Theory]
		[InlineData(400)]
		[InlineData(1150)]
		public void ResultsShouldContainOnlyVoteCountHigher(int voteCount)
		{
			//Given
			var settings = new MovieDiscoverSettings();
			settings.MinVoteCount = voteCount;
			//When
			var data = _fixture.SearchService.DiscoverMovies(settings).Result;
			//Then
			Assert.True(data.Results.All(x=>x.VoteCount >= voteCount));
		}

		[Theory]
		[InlineData(5.5)]
		[InlineData(7.5)]
		public void ResultsShouldContainOnlyVoteAverageHigher(int voteAverage)
		{
			//Given
			var settings = new MovieDiscoverSettings();
			settings.MinVoteAverage = voteAverage;
			//When
			var data = _fixture.SearchService.DiscoverMovies(settings).Result;
			//Then
			Assert.True(data.Results.All(x=>x.VoteAverage >= voteAverage));
		}
		
		[Fact]
		public void ResultsShouldContainOnlyGivenGenres()
		{
			//Given
			var genres = new int[] { 12, 16 };
			var settings = new MovieDiscoverSettings();
			settings.Genres = genres;
			//When
			var data = _fixture.SearchService.DiscoverMovies(settings).Result;
			//Then
			Assert.True(data.Results.All(x=>x.GenreIds.Intersect(genres).Count() == genres.Count()));
		}

		[Fact]
		public void ResultsShouldNotContainGivenGenres()
		{
			//Given
			var genres = new int[] { 12, 16 };
			var settings = new MovieDiscoverSettings();
			settings.ExcludeGenres = genres;
			//When
			var data = _fixture.SearchService.DiscoverMovies(settings).Result;
			//Then
			Assert.True(data.Results.All(x=>x.GenreIds.Intersect(genres).Count() == 0));
		}
	}
}