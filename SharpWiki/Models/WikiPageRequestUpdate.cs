namespace SharpWiki.Models
{
    using System.Text.Json.Serialization;
    /// <summary>
    /// Request body to update a wiki page
    /// </summary>
    public class WikiPageRequestUpdate
    {
        /// <summary>
        /// Page content in the format specified by the content_model property
        /// </summary>
        public string? Source { get; set; }

        /// <summary>
        /// Reason for creating the page. To allow the comment to be filled in by the server, use "comment": null
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// Object identifying the base revision of the edit. You can fetch this information from the get page source endpoint.
        /// </summary>
        public WikiPageRevision? Latest { get; set; }

        /// <summary>
        /// Type of content on the page. Defaults to wikitext
        /// </summary>
        [JsonPropertyName("content_model")] 
        public string? ContentModel { get; set; }
    }
}
