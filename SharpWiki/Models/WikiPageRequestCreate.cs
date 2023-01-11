namespace SharpWiki.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Request body to create a wiki page
    /// </summary>
    public class WikiPageRequestCreate
    {
        /// <summary>
        /// Page content in the format specified by the content_model property
        /// </summary>
        public string? Source { get; set; }

        /// <summary>
        /// Page title
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Reason for creating the page. To allow the comment to be filled in by the server, use "comment": null
        /// </summary>
        public string? Comment { get; set;}

        /// <summary>
        /// Type of content on the page. Defaults to wikitext
        /// </summary>
        [JsonPropertyName("content_model")] 
        public string? ContentModel { get; set; }
    }
}
