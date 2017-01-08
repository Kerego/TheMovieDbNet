using System;
using System.Linq;
using System.Text;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models.Movies
{
	/// <summary>
	/// Represents settings used to dicover movies.
	/// </summary>
	public class MovieDiscoverSettings : DiscoverSettings
	{
		/// <summary>
		/// Gets or Sets the sort option for dicovery.
		/// </summary>
		public MovieSortOption SortOption { get; set; } = MovieSortOption.PopularityDescending;
		/// <summary>
		/// Gets or Sets the region of the media.
		/// </summary>
		public string Region { get; set; }
		/// <summary>
		/// Gets or Sets whether to include simple videos(not movies related)
		/// </summary>
		public bool IncludeVideo { get; set; }
		/// <summary>
		/// Gets or Sets the country of certification.
		/// </summary>
		public string CertificationCountry { get; set; }
		/// <summary>
		/// Gets or Sets the certification.
		/// </summary>
		public string Certification { get; set; }
		/// <summary>
		/// Gets or Sets the max certification age.
		/// </summary>
		public int MaxCertification { get; set; }
		/// <summary>
		/// Gets or Sets whether to include adult movies or not.
		/// </summary>
		public bool IncludeAdult { get; set; }
		/// <summary>
		/// Gets or Sets the primary release year.
		/// </summary>
		public int PrimaryReleaseYear { get; set; }
		/// <summary>
		/// Gets or Sets the minimal primary release date.
		/// </summary>
		public DateTime MinPrimaryReleaseDate { get; set; }
		/// <summary>
		/// Gets or Sets the maximal primary release date.
		/// </summary>
		public DateTime MaxPrimaryReleaseDate { get; set; }
		/// <summary>
		/// Gets or Sets the minimal release date.
		/// </summary>
		public DateTime MinReleaseDate { get; set; }
		/// <summary>
		/// Gets or Sets the minimal release date.
		/// </summary>
		public DateTime MaxReleaseDate { get; set; }
		/// <summary>
		/// Gets or Sets the maximal vote count.
		/// </summary>
		public int MaxVoteCount { get; set; }
		/// <summary>
		/// Gets or Sets the maximal vote average.
		/// </summary>
		public int MaxVoteAverage { get; set; }
		/// <summary>
		/// Gets or Sets the ids of people participated as cast.
		/// </summary>
		public int[] Cast { get; set; }
		/// <summary>
		/// Gets or Sets the ids of people participated as crew.
		/// </summary>
		public int[] Crew { get; set; }
		/// <summary>
		/// Gets or Sets the ids of companies related to movie.
		/// </summary>
		public int[] Companies { get; set; }
		/// <summary>
		/// Gets or Sets the ids of keywords related to movie.
		/// </summary>
		public int[] Keywords { get; set; }
		/// <summary>
		/// Gets or Sets the ids of people related to movie.
		/// </summary>
		public int[] People { get; set; }
		/// <summary>
		/// Gets or Sets the year of the movie.
		/// </summary>
		public int Year { get; set; }
		/// <summary>
		/// Gets or Sets the release type of the movie (eg 5: Physical)
		/// </summary>
		public ReleaseType[] ReleaseTypes { get; set; }

		/// <summary>
		/// Converts the settings to the query string representation.
		/// </summary>
		/// <returns>Query string.</returns>
		public override string ToString()
		{
			var query = new StringBuilder();
			query.Append(base.ToString());
			query.Append($"&sort_by={ConvertEnum(SortOption)}");
			if(!string.IsNullOrWhiteSpace(Region))
				query.Append($"&region={Region}");
			if(!string.IsNullOrWhiteSpace(CertificationCountry))
				query.Append($"&certification_country={CertificationCountry}");
			if(!string.IsNullOrWhiteSpace(Certification))
				query.Append($"&certification={Certification}");
			if(MaxCertification > 0)
				query.Append($"&certification.lte={MaxCertification}");
			if(IncludeAdult)
				query.Append($"&include_adult=true");
			if(IncludeVideo)
				query.Append($"&include_video=true");
			if(PrimaryReleaseYear > 0)
				query.Append($"&primary_release_year={PrimaryReleaseYear}");
			if(MinPrimaryReleaseDate != default(DateTime))
				query.Append($"&primary_release_date.gte={MinPrimaryReleaseDate.ToString("yyyy-MM-dd")}");
			if(MaxPrimaryReleaseDate != default(DateTime))
				query.Append($"&primary_release_date.lte={MaxPrimaryReleaseDate.ToString("yyyy-MM-dd")}");
			if(MinReleaseDate != default(DateTime))
				query.Append($"&release_date.gte={MinReleaseDate.ToString("yyyy-MM-dd")}");
			if(MaxReleaseDate != default(DateTime))
				query.Append($"&release_date.lte={MaxReleaseDate.ToString("yyyy-MM-dd")}");
			if(MaxVoteCount > 0)
				query.Append($"&vote_count.lte={MaxVoteCount}");
			if(MaxVoteAverage > 0)
				query.Append($"&vote_average.lte={MaxVoteAverage}");
			if (Cast?.Any() == true)
				query.Append($"&with_cast={String.Join(",", Cast)}");
			if (Crew?.Any() == true)
				query.Append($"&with_crew={String.Join(",", Crew)}");
			if (Companies?.Any() == true)
				query.Append($"&with_companies={String.Join(",", Companies)}");
			if (Keywords?.Any() == true)
				query.Append($"&with_keywords={String.Join(",", Keywords)}");
			if (People?.Any() == true)
				query.Append($"&with_people={String.Join(",", People)}");
			if (ReleaseTypes?.Any() == true)
				query.Append($"&with_release_type={String.Join(",", ReleaseTypes.Cast<int>())}");
			if (Year > 0)
				query.Append($"&year={Year}");
			

			return query.ToString();
		}
	}
}