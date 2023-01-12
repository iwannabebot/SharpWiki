namespace SharpWiki.Exceptions
{
    /// <summary>
    /// Page not found exception
    /// </summary>
    public class WikiPageNotFoundException : WikiPageException
    {
        /// <summary>
        /// Initialize object
        /// </summary>
        public WikiPageNotFoundException(): base("Page does not exists") { }

    }
}
