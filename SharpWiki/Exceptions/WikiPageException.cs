namespace SharpWiki.Exceptions
{
    using System;

    /// <summary>
    /// Base Page Exception
    /// </summary>
    public class WikiPageException : Exception
    {
        /// <summary>
        /// Initialize object
        /// </summary>
        /// <param name="message">Error Message</param>
        public WikiPageException(string message): base(message)
        {
        }

    }
}
