namespace SharpWiki
{
    using System;
    using SharpWiki.Exceptions;
    using SharpWiki.Models;

    /// <summary>
    /// SharpWiki Client Options
    /// </summary>
    public class SharpWikiClientOptions
    {
        /// <summary>
        /// Default SharpWiki Client Options
        /// </summary>
        public static SharpWikiClientOptions Default { get; set; } = new SharpWikiClientOptions();

        /// <summary>
        /// Wikipedia
        /// </summary>
        public WikiLanguage Language { get; set; } = WikiLanguage.English;

        /// <summary>
        /// 
        /// </summary>
        public string? ApiUserAgent { get; set; } = "SharpWikiClient";

        /// <summary>
        /// Callback to fetch bearer token
        /// </summary>
        public Func<string> GetToken { get; set; } = () => throw new WikiTokenNotFoundException();
    }
}
