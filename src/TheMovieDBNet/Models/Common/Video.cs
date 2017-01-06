using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Common
{
    /// <summary>
    /// Represents basic data of a video.
    /// </summary>
    public class Video
    {
        [JsonConstructor]
        internal Video(
            string id,
            string iso_639_1,
            string iso_3166_1,
            string key,
            string name,
            string site,
            string type,
            int size
        )
        {
            Id = id;
            Iso6391 = iso_639_1;
            Iso31661 = iso_3166_1;
            Key = key;
            Name = name;
            Site = site;
            Type = type;
            Size = size;
        }

        /// <summary>
        /// Gets the video identifier.
        /// </summary>
        public string Id { get; }
        /// <summary>
        /// Gets the standard info.
        /// </summary>
        public string Iso6391 { get; }

        /// <summary>
        /// Gets the standard info.
        /// </summary>
        public string Iso31661 { get; }

        /// <summary>
        /// Gets the id of the video on external site (usually youtube).
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// Gets the Name of the video.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the Site of the video.
        /// </summary>
        public string Site { get; }

        /// <summary>
        /// Gets the quality of the video (eg: 720p).
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// Gets the type of the video (eg: Trailer).
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets full link to the video; works only for youtube videos.
        /// </summary>
        public string FullPath => $"https://youtube.com/watch?v={Key}";
    }
}