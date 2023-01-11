namespace SharpWiki.Models
{
    using System;
    /// <summary>
    /// Page revision object
    /// </summary>
    public class WikiPageRevision
    {
        /// <summary>
        /// Revision identifier for the latest revision
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Timestamp of the latest revision
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
