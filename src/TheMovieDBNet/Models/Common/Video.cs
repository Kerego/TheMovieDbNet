using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Common
{
    /// <summary>
    /// Represents basic data of a video.
    /// </summary>
    public class Video
    {
        /// <summary>
        /// Gets or Sets video identifier
        /// </summary>
        /// <returns></returns>
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
}