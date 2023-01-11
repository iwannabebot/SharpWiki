namespace SharpWiki.Models
{
    /// <summary>
    /// Page license object
    /// </summary>
    public class WikiPageLicense
    {
        /// <summary>
        /// URL of the applicable license
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// Name of the applicable license
        /// </summary>
        public string? Title { get; set; }
    }
}
