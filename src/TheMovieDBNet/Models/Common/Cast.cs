using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Common
{
    /// <summary>
    /// Represents base data about cast.
    /// </summary>
    public class Cast
    {
        /// <summary>
        /// Gets or Sets the name of character of cast.
        /// </summary>
        public string Character { get; set; }
        /// <summary>
        /// Gets or Sets identifier of coresponding credit.
        /// </summary>
        [JsonProperty("credit_id")]
        public string CreditId { get; set; }
        
        /// <summary>
        /// Gets or Sets person identifier.
        /// </summary>
        public int Id { get; set; }
    }
}