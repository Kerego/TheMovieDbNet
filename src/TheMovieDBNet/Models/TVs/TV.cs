using System;
using Newtonsoft.Json;
using TheMovieDbNet.Models.Common;

namespace TheMovieDbNet.Models.TVs
{
	/// <summary>
	/// Represents the data of a tv series.
	/// </summary>
	public class TV : TVBase
	{
		[JsonConstructor]
		internal TV(
			int id,
			double popularity,
			string poster_path,
			string backdrop_path,
			string overview,
			double vote_average,
			int vote_count,
			DateTime? first_air_date,
			string[] origin_country,
			string name,
			string original_name,
			TVCreator[] created_by,
			int[] episode_run_time,
			Genre[] genres,
			string homepage,
			bool in_production,
			string[] languages,
			DateTime? last_air_date,
			Network[] networks,
			int number_of_episodes,
			int number_of_seasons,
			string original_language,
			ProductionCompany[] production_companies,
			Season[] seasons,
			string status,
			string type,
			PagedResult<TVSearchItem> similar,
			PagedResult<TVSearchItem> recommendations,
			TVExternals external_ids)
		: base(
			id,
			popularity,
			poster_path,
			backdrop_path,
			overview,
			vote_average,
			vote_count,
			first_air_date,
			origin_country,
			name,
			original_name)
		{
			CreatedBy =created_by;
			EpisodeRunTime =episode_run_time;
			Genres = genres;
			Homepage = homepage;
			InProduction = in_production;
			Languages = languages;
			LastAirDate = last_air_date;
			Networks = networks;
			NumberOfEpisodes = number_of_episodes;
			NumberOfSeasons = number_of_seasons;
			OriginalLanguage = original_language;
			ProductionCompanies = production_companies;
			Seasons = seasons;
			Status = status;
			Type = type;
			SimilarTVs = similar;
			Recommendations = recommendations;
			ExternalIds = external_ids;
		}
		/// <summary>
		/// Gets the creators of the tv.
		/// </summary>
		public TVCreator[] CreatedBy { get; }
		/// <summary>
		/// Gets the runtimes of episodes.
		/// </summary>
		public int[] EpisodeRunTime { get; }
		/// <summary>
		/// Gets the genres of the tv.
		/// </summary>
		public Genre[] Genres { get; }
		
		/// <summary>
		/// Gets the homepage of the tv.
		/// </summary>
		public string Homepage { get; }
		
		/// <summary>
		/// Gets whethet the tv is still in production.
		/// </summary>
		public bool InProduction { get; }
		
		/// <summary>
		/// Gets the languages used in tv.
		/// </summary>
		public string[] Languages { get; }
		
		/// <summary>
		/// Gets the last air date.
		/// </summary>
		public DateTime? LastAirDate { get; }
		
		/// <summary>
		/// Gets the networks tv is available on.
		/// </summary>
		public Network[] Networks { get; }
		
		/// <summary>
		/// Gets the number of episodes of the tv.
		/// </summary>
		public int NumberOfEpisodes { get; }
		
		/// <summary>
		/// Gets the number of seasons.
		/// </summary>
		public int NumberOfSeasons { get; }
		
		/// <summary>
		/// Gets the original language of the tv.
		/// </summary>
		public string OriginalLanguage { get; }
		
		/// <summary>
		/// Gets the production companies.
		/// </summary>
		public ProductionCompany[] ProductionCompanies { get; }
		
		/// <summary>
		/// Gets the seasons detail.
		/// </summary>
		public Season[] Seasons { get; }
		
		/// <summary>
		/// Gets the status of the tv series.
		/// </summary>
		public string Status { get; }
		
		/// <summary>
		/// Gets the type of tv series
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// Gets the tv identifier on external sites.
		/// </summary>
		public TVExternals ExternalIds { get; }

		/// <summary>
		/// Gets the Recommendations for the tv.
		/// </summary>
		public PagedResult<TVSearchItem> Recommendations { get; }
		
		/// <summary>
		/// Gets the similar tvs.
		/// </summary>
		public PagedResult<TVSearchItem> SimilarTVs { get; }

		/// <summary>
		/// Gets or Sets the alternative titles for the tv series.
		/// </summary>
		[JsonIgnore]
		public AlternativeTitle[] AlternativeTitles { get; set; }

		/// <summary>
		/// Gets or Sets the videos of the tv.
		/// </summary>
		[JsonIgnore]
		public Video[] Videos { get; set; }

		/// <summary>
		/// Gets or Sets the backdrop images.
		/// </summary>
		[JsonIgnore]
		public Image[] Backdrops { get; set; }

		/// <summary>
		/// Gets or Sets the poster images.
		/// </summary>
		[JsonIgnore]
		public Image[] Posters { get; set; }

		/// <summary>
		/// Gets or Sets cast of the tv.
		/// </summary>
		[JsonIgnore]
		public MediaCast[] Cast { get; set; }

		/// <summary>
		/// Gets or Sets crew of the tv.
		/// </summary>
		[JsonIgnore]
		public MediaCrew[] Crew { get; set;}

		/// <summary>
		/// Gets or Sets the keywords of the tv.
		/// </summary>
		[JsonIgnore]
		public Keyword[] Keywords { get; set; }

		/// <summary>
		/// Gets or Sets available translation for the tv.
		/// </summary>
		[JsonIgnore]
		public Translation[] Translations { get; set; }

		/// <summary>
		/// Gets or Sets the content rating for the tv series.
		/// </summary>
		[JsonIgnore]
		public ContentRating[] ContentRatings { get; set; }
	}
}