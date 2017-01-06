using Newtonsoft.Json;

namespace TheMovieDbNet.Models.Common
{
    /// <summary>
    /// Represents base data about crew.
    /// </summary>
    public class Crew
    {
        [JsonConstructor]
        internal Crew(int id, string credit_id, string department, string job)
        {
            Id = id;
            CreditId = credit_id;
            Department = department;
            Job = job;
        }
        /// <summary>
        /// Gets the person identifier.
        /// </summary>
        public int Id { get; }
        
        /// <summary>
        /// Gets the credit identifier.
        /// </summary>
        public string CreditId { get; }

        /// <summary>
        /// Gets the department of crew member.
        /// </summary>
        public string Department { get; }

        /// <summary>
        /// Gets the job of crew member.
        /// </summary>
        public string Job { get; }
    }
}