namespace SharpWiki.Exceptions.Guards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Guards for Search API
    /// </summary>
    public static class SearchGuards
    {
        public static void SearchLimit(this Guard guard, int limit)
        {
            if (limit <= 0 || limit > 100)
                throw new ArgumentException("Invalid limit requested. Set limit parameter to between 1 and 100.");
        }
        public static void SearchErrors(this Guard guard, HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.BadRequest:
                    throw new WikiSearchException("Query parameter not set or Invalid limit requested");
                case System.Net.HttpStatusCode.InternalServerError:
                    throw new WikiSearchException("Search Error");
            }
            response.EnsureSuccessStatusCode();
        }
    }
}
