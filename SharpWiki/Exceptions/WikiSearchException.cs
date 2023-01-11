namespace SharpWiki.Exceptions
{
    using System;

    public class WikiSearchException : Exception
    {
        public WikiSearchException() { }

        public WikiSearchException(string message) : base(message) { }

        public WikiSearchException(string message, Exception ex) : base(message, ex) { }

    }
}
