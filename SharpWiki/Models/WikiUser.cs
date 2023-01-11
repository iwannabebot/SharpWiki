namespace SharpWiki.Models
{
    /// <summary>
    /// Object containing information about the user who uploaded the file
    /// </summary>
    public class WikiUser
    {
        /// <summary>
        /// User identifier
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string? Name { get; set; }
    }
}
