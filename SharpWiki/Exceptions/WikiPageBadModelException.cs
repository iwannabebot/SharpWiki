namespace SharpWiki.Exceptions
{
    using System;

    public class WikiPageBadModelException : WikiPageException
    {
        public WikiPageBadModelException(): base("Bad content model. Include a valid content_model based on available content handlers.")
        {
        }

    }
}
