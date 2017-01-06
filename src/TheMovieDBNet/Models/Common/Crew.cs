using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Common
{
    /// <summary>
    /// Represents base data about crew.
    /// </summary>
    public class Crew
    {
        /// <summary>
        /// Gets or Sets person identifier.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Gets or Sets the creditId.
        /// </summary>
        [JsonProperty("credit_id")]
        public string CreditId { get; set; }

        /// <summary>
        /// Gets or Sets the department of crew member.
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Gets or Sets the job of crew member.
        /// </summary>
        public string Job { get; set; }
    }
}