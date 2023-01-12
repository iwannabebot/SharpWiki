namespace SharpWiki.Exceptions
{
    using System;

    /// <summary>
    /// Page already exists exception
    /// </summary>
    public class WikiPageAlreayExistsException : WikiPageException
    {
        /// <summary>
        /// Initialize object
        /// </summary>
        public WikiPageAlreayExistsException(): base("Page already exists. To update the existing page, provide the base revision identifier in latest.id in the request body") { }

    }
}
