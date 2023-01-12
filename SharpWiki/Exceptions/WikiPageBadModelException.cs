namespace SharpWiki.Exceptions
{
    /// <summary>
    /// Create or update model is bad
    /// </summary>
    public class WikiPageBadModelException : WikiPageException
    {
        /// <summary>
        /// Initialize object
        /// </summary>
        public WikiPageBadModelException(): base("Bad content model. Include a valid content_model based on available content handlers.")
        {
        }

    }
}
