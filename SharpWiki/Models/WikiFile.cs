namespace SharpWiki.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The file object represents a file uploaded to a wiki.
    /// </summary>
    public class WikiFile
    {
        /// <summary>
        /// File title
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// URL for the page describing the file, including license information and other metadata
        /// </summary>
        [JsonPropertyName("file_description_url")]
        public string? FileDescriptionUrl { get; set; }

        /// <summary>
        /// Object containing information about the latest revision to the file
        /// </summary>
        public WikiFileRevision? Latest { get; set; }

        /// <summary>
        /// Information about the file's preferred preview format
        /// </summary>
        public WikiFileRaw? Preferred { get; set; }

        /// <summary>
        /// Information about the file's original format
        /// </summary>
        public WikiFileRaw? Original { get; set; }

        /// <summary>
        /// Information about the file's thumbnail format
        /// </summary>
        public WikiFileRaw? Thumbnail { get; set; }
    }
}
