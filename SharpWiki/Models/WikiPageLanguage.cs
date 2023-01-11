namespace SharpWiki.Models
{
    /// <summary>
    /// The page language object represents a wiki page and its language.
    /// </summary>
    public class WikiPageLanguage
    {
        /// <summary>
        /// Language code
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Translated language name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Translated page title in URL-friendly format
        /// </summary>
        public string? Key { get; set; }

        /// <summary>
        /// Translated page title in reading-friendly format
        /// </summary>
        public string? Title { get; set; }
    }
}
