using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Common
{
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
}