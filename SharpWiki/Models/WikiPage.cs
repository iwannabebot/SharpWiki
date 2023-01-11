namespace SharpWiki.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The page object represents the latest revision of a wiki page.
    /// </summary>
    public class WikiPage
    {
        /// <summary>
        /// Page identifier
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Page title in URL-friendly format
        /// </summary>
        public string? Key { get; set; }

        /// <summary>
        /// Page title in reading-friendly format
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Information about the latest revision
        /// </summary>
        public WikiPageRevision? Latest { get; set; }

        /// <summary>
        /// Type of content on the page
        /// See https://www.mediawiki.org/wiki/Special:MyLanguage/Content_handlers for content models supported by MediaWiki and extensions.
        /// </summary>
        [JsonPropertyName("content_model")]
        public string? ContentModel { get; set; }

        /// <summary>
        /// Information about the wiki's license
        /// </summary>
        public WikiPageLicense? License { get; set; }

        /// <summary>
        /// API route to fetch the content of the page in HTML
        /// </summary>
        [JsonPropertyName("html_url")]
        public string? HtmlUrl { get; set; }

        /// <summary>
        /// Latest page content in HTML, following the HTML 2.1.0 specification
        /// </summary>
        public string? Html { get; set; }

        /// <summary>
        /// Latest page content in the format specified by the content_model property
        /// </summary>
        public string? Source { get; set; }
    }
}
