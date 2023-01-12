namespace SharpWiki.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The search result object represents a wiki page matching the requested search.
    /// </summary>
    public class WikiSearchPage
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
        /// For search pages endpoint:
        /// A few lines giving a sample of page content with search terms highlighted with span tags
        /// For autocomplete page title endpoint:
        /// Page title in reading-friendly format
        /// </summary>
        public string? Excerpt { get; set; }

        /// <summary>
        /// The title of the page redirected from, if the search term originally matched a redirect page 
        /// or null if search term did not match a redirect page.
        /// </summary>
        [JsonPropertyName("matched_title")]
        public string? MatchedTitle { get; set; }

        /// <summary>
        /// Short summary of the page topic based on the corresponding entry on Wikidata or null if no 
        /// entry exists
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Information about the thumbnail image for the page or null if no thumbnail exists.
        /// </summary>
        public WikiFileRaw? Thumbnail { get; set; }

    }
}
