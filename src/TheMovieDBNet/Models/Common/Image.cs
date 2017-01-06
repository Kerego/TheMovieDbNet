using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Common
{
    /// <summary>
    /// Represents data about a image.
    /// </summary>
    public class Image
    {
        [JsonConstructor]
        internal Image(
            double aspect_ratio, 
            string file_path, 
            int height,
            int width,
            string iso_639_1,
            double vote_average,
            int vote_count)
        {
            AspectRatio = aspect_ratio;
            FilePath = file_path;
            Height = height;
            Width = width;
            Iso6391 = iso_639_1;
            VoteAverage = vote_average;
            VoteCount = vote_count;
        }
        /// <summary>
        /// Gets full path to the resource in original resolution.
        /// </summary>
        public string FullPathOriginal => $"https://image.tmdb.org/t/p/original{FilePath}";
        
        /// <summary>
        /// Gets the aspect ratio of the image.
        /// </summary>
        public double AspectRatio { get; }

        /// <summary>
        /// Gets the path to the image.
        /// </summary>
        public string FilePath { get; }

        /// <summary>
        /// Gets the height of the image in pixels
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Gets the iso_639_1 standard info 
        /// </summary>
        public string Iso6391 { get; }

        /// <summary>
        /// Gets the average rating of the image
        /// </summary>
        public double VoteAverage { get; }

        /// <summary>
        /// Gets the number of votes for the image
        /// </summary>
        public int VoteCount { get; }

        /// <summary>
        /// Gets the width of the image in pixels
        /// </summary>
        public int Width { get; }
    }
}