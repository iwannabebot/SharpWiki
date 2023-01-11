namespace SharpWiki.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// The search result object represents a wiki page matching the requested search.
    /// </summary>
    public class WikiSearch
    {
        /// <summary>
        /// Search Results
        /// </summary>
        public IEnumerable<WikiSearchPage>? Pages { get; set; }
    }
}
