namespace SharpWiki.Exceptions
{
    using System;
    public class WikiPageNotFoundException : WikiPageException
    {
        public WikiPageNotFoundException(): base("Page does not exists") { }

    }
}
