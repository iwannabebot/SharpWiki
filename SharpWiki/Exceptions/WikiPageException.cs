namespace SharpWiki.Exceptions
{
    using System;
    public class WikiPageException : Exception
    {
        public WikiPageException(string message): base(message)
        {
        }

    }
}
