namespace SharpWiki.Models
{
    using System;

    /// <summary>
    /// Object containing information about the revision to the file
    /// </summary>
    public class WikiFileRevision
    {
        /// <summary>
        /// Timestamp of the latest revision
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Object containing information about the user who uploaded the file
        /// </summary>
        public WikiUser? User { get; set; }
    }
}
