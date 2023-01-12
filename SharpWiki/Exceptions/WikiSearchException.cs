namespace SharpWiki.Exceptions
{
    using System;

    /// <summary>
    /// Base Wiki Search Exception
    /// </summary>
    public class WikiSearchException : Exception
    {
        /// <summary>
        /// Initialize object
        /// </summary>
        /// <param name="message">Error Message</param>
        public WikiSearchException(string message) : base(message) { }
    }
}
