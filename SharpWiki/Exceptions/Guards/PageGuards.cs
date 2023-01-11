namespace SharpWiki.Exceptions.Guards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using SharpWiki.Models;
    using SharpWiki.Exceptions;

    /// <summary>
    /// Guards for Page API
    /// </summary>
    public static class PageGuards
    {
        public static void CreatePage(this Guard guard, WikiPageRequestCreate createPageRequest)
        {
        }

        public static void UpdatePage(this Guard guard, WikiPageRequestUpdate createPageRequest)
        {
        }

        public static void CreatePageErrors(this Guard guard, HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.BadRequest:
                    throw new WikiPageBadModelException();
                case System.Net.HttpStatusCode.Conflict:
                    throw new WikiPageAlreayExistsException();
                case System.Net.HttpStatusCode.UnsupportedMediaType:
                    throw new WikiPageException("Unsupported Content-Type. Add the request header Content-Type: application/json");
            }
            response.EnsureSuccessStatusCode();
        }

        public static void UpdatePageErrors(this Guard guard, HttpResponseMessage response)
        {
            /*
            409	Edit conflict. The error response includes the differences between the base revision specified 
            in the request and the latest published revision. See the Wikidiff2 docs for information about the 
            diff format. Requires Wikidiff2 extension 1.10+.
             */

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.BadRequest:
                    throw new WikiPageBadModelException();
                case System.Net.HttpStatusCode.Conflict:
                    throw new WikiPageAlreayExistsException();
                case System.Net.HttpStatusCode.UnsupportedMediaType:
                    throw new WikiPageException("Unsupported Content-Type. Add the request header Content-Type: application/json");
            }
            response.EnsureSuccessStatusCode();
        }

        public static void GetPageErrors(this Guard guard, HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.NotFound:
                    throw new WikiPageNotFoundException();
                case System.Net.HttpStatusCode.InternalServerError:
                    throw new WikiPageException("RESTBase not installed or not configured with VirtualRESTService");
            }
            response.EnsureSuccessStatusCode();
        }

        public static void GetPageLanguagesErrors(this Guard guard, HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.NotFound:
                    throw new WikiPageNotFoundException();
            }
            response.EnsureSuccessStatusCode();
        }

        public static void GetPageFilesErrors(this Guard guard, HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.NotFound:
                    throw new WikiPageNotFoundException();
                case System.Net.HttpStatusCode.InternalServerError:
                    throw new WikiPageException("Page contains more than 100 media files");
            }
            response.EnsureSuccessStatusCode();
        }
    }
}
