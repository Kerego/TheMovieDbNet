using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TheMovieDbNet.Models
{
    /// <summary>
    /// class containg data about a movie 
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// id of the movie
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// id of the movie on the IMDB Site
        /// </summary>
        [JsonProperty("imdb_id")]
        public string ImdbId { get; set; }

        /// <summary>
        /// indicates whether the movie is an adult one or not
        /// </summary>
        public bool Adult { get; set; }

        /// <summary>
        /// path to the backdrop
        /// </summary>
        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        /// <summary>
        /// budget of the movie
        /// </summary>
        public int Budget { get; set; }

        /// <summary>
        /// homepage of the movie
        /// </summary>
        public string Homepage { get; set; }

        /// <summary>
        /// original language of the movie
        /// </summary>
        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        /// <summary>
        /// title of the movie in original language
        /// </summary>
        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        /// <summary>
        /// overview of the movie's plot
        /// </summary>
        public string Overview { get; set; }

        /// <summary>
        /// info about the collection of movies the one belongs to
        /// </summary>
        [JsonProperty("belongs_to_collection")]
        public MoviesCollection MovieCollection { get; set; }

        /// <summary>
        /// info about the genres of the movie
        /// </summary>
        public Genre[] Genres { get; set; }

        /// <summary>
        /// popularity of the movie
        /// </summary>
        public double Popularity { get; set; }

        /// <summary>
        /// path to the poster image
        /// </summary>
        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        /// <summary>
        /// info about the companies that produced the movie
        /// </summary>
        [JsonProperty("production_companies")]
        public ProductionCompany[] ProductionCompanies { get; set; }

        /// <summary>
        /// info about countries that produced the movie
        /// </summary>
        [JsonProperty("production_countries")]
        public ProductionCountry[] ProductionCountries { get; set; }

        /// <summary>
        /// realease date of the movie
        /// </summary>
        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        /// <summary>
        /// total revenue of the movie in $
        /// </summary>
        public int Revenue { get; set; }

        /// <summary>
        /// total runtime of the movie in minutes
        /// </summary>
        public int? Runtime { get; set; }

        /// <summary>
        /// array of languages that are spoke in the movie
        /// </summary>
        [JsonProperty("spoken_languages")]
        public SpokenLanguage[] SpokenLanguages { get; set; }

        /// <summary>
        /// relese status of the movie
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// tagline of the movie
        /// </summary>
        public string Tagline { get; set; }

        /// <summary>
        /// title of the movie
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// show whether this is a video or movie
        /// </summary>
        public bool Video { get; set; }

        /// <summary>
        /// average rating of the movie
        /// </summary>
        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        /// <summary>
        /// vote counts for the movie
        /// </summary>
        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        /// <summary>
        /// videos of the movie
        /// </summary>
        [JsonIgnore]
        public Video[] Videos { get; set; }
        
        /// <summary>
        /// backdrop images
        /// </summary>
        [JsonIgnore]
        public Image[] Backdrops { get; set; }

        /// <summary>
        /// poster images
        /// </summary>
        [JsonIgnore]
        public Image[] Posters { get; set; }
    }

    /// <summary>
    /// info about an image
    /// </summary>
    public class Image
    {
        /// <summary>
        /// full path to the resource in original resolution
        /// </summary>
        [JsonIgnore]
        public string FullPathOriginal => $"https://image.tmdb.org/t/p/original{FilePath}";
        /// <summary>
        /// aspect ratio of the image
        /// </summary>
        [JsonProperty("aspect_ratio")]
        public double AspectRatio { get; set; }

        /// <summary>
        /// path to the image
        /// </summary>
        [JsonProperty("file_path")]
        public string FilePath { get; set; }

        /// <summary>
        /// height of the image in pixels
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// standard info 
        /// </summary>
        [JsonProperty("iso_639_1")]
        public string Iso6391 { get; set; }

        /// <summary>
        /// average rating of the image
        /// </summary>
        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        /// <summary>
        /// number of votes for the image
        /// </summary>
        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        /// <summary>
        /// width of the image in pixels
        /// </summary>
        public int Width { get; set; }
    }

    /// <summary>
    /// info about a video
    /// </summary>
    public class Video
    {
        /// <summary>
        /// id of the video
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// standard info
        /// </summary>
        [JsonProperty("iso_639_1")]
        public string Iso6391 { get; set; }

        /// <summary>
        /// standard info
        /// </summary>
        [JsonProperty("iso_3166_1")]
        public string Iso31661 { get; set; }

        /// <summary>
        /// id of the video on external site (usually youtube)
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// name of the video
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// site of the video
        /// </summary>
        public string Site { get; set; }

        /// <summary>
        /// quality of the video (eg: 720p)
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// type of the video (eg: Trailer)
        /// </summary>
        public string Type { get; set; }
    }

    /// <summary>
    /// info about genre of movie
    /// </summary>
    public class Genre
    {

        /// <summary>
        /// id of the genre
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// name of the genre
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// info about a collection of movies
    /// </summary>
    public class MoviesCollection
    {
        /// <summary>
        /// id of the collection
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// name of the collection
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// path to the poster image
        /// </summary>
        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        /// <summary>
        /// path to the backdrop
        /// </summary>
        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }
    }

    /// <summary>
    /// info about company that produces movies
    /// </summary>
    public class ProductionCompany
    {
        /// <summary>
        /// id of the company
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// name of the company
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// info about country that produces movies
    /// </summary>
    public class ProductionCountry
    {
        /// <summary>
        /// iso_3166_1 name of country
        /// </summary>
        /// <returns></returns>
        [JsonProperty("iso_3166_1")]
        public string Iso31661 { get; set; }

        /// <summary>
        /// name of the country
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// info about a language spoken in a movie
    /// </summary>
    public class SpokenLanguage
    {
        /// <summary>
        /// iso_639_1 name of language
        /// </summary>
        [JsonProperty("iso_639_1")]
        public string Iso6391 { get; set; }

        /// <summary>
        /// human name of language
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }

}