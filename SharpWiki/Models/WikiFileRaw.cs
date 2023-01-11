namespace SharpWiki.Models
{
    using System.Text.Json.Serialization;

    public class WikiFileRaw
    {
        /// <summary>
        /// The file type, one of: BITMAP, DRAWING, AUDIO, VIDEO, MULTIMEDIA, UNKNOWN, 
        /// OFFICE, TEXT, EXECUTABLE, ARCHIVE, or 3D
        /// </summary>
        [JsonPropertyName("mimetype")]
        public string? MimeType { get; set; }

        /// <summary>
        /// File size in bytes or null if not available
        /// </summary>
        public ulong? Size { get; set; }

        /// <summary>
        /// Maximum recommended image width in pixels or null if not available
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// Maximum recommended image height in pixels or null if not available
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Length of the video, audio, or multimedia file or null for other media types
        /// </summary>
        public int? Duration { get; set; }

        /// <summary>
        /// URL to download the file
        /// </summary>
        public string? Url { get; set; }
    }
}
