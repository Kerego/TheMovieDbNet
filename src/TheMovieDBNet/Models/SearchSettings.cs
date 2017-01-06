namespace TheMovieDbNet.Models
{
    /// <summary>
    /// Represents base settings used in search.
    /// </summary>
    public class SearchSettings
    {
        /// <summary>
        /// Gets and Sets query parameters of the search.
        /// </summary>
        public string Query { get; set; }
        /// <summary>
        /// Gets and Sets the page of the search.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Converts to string to use in search queries.
        /// </summary>
        /// <returns>String form of query.</returns>
        public override string ToString()
        {
            var result = $"&query={Query}";
            if(Page > 0)
                result += $"&page={Page}";
            return result;
        }
    }

    /// <summary>
    /// Represents movie settings used in search.
    /// </summary>
    public class MovieSearchSettings : SearchSettings
    {
        /// <summary>
        /// Gets or Sets language of search query
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        /// Gets or Sets whether to include Adult content in search results
        /// </summary>
        public bool AllowAdult { get; set; }
        /// <summary>
        /// Gets or Sets region of search query
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// Gets or Sets year of the seached movie
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// Gets or Sets primary release year of the seached movie
        /// </summary>
        public int PrimaryReleaseYear { get; set; }

        /// <summary>
        /// Converts to string to use in search queries.
        /// </summary>
        /// <returns>String form of query.</returns>
        public override string ToString() 
        {
            var result = base.ToString();
            if (!string.IsNullOrWhiteSpace(Language))
                result += $"&language={Language}";
            if (!string.IsNullOrWhiteSpace(Region))
                result += $"&region={Region}";
            if (Year > 1900)
                result += $"&year={Year}";
            if (PrimaryReleaseYear > 1900)
                result += $"&primary_release_year={PrimaryReleaseYear}";
            if (AllowAdult)
                result += $"&include_adult={AllowAdult.ToString().ToLower()}";      

            return result;
        }
    }
}