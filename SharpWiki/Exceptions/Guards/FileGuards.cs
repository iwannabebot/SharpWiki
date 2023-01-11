namespace SharpWiki.Exceptions.Guards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using SharpWiki.Models;

    /// <summary>
    /// Guards for Media API
    /// </summary>
    public static class FileGuards
    {
        /// <summary>
        /// Process File Response Errors
        /// </summary>
        /// <param name="guard"></param>
        /// <param name="response"></param>
        /// <exception cref="WikiFileNotFoundException"></exception>
        public static void GetFileErrors(this Guard guard, HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.NotFound:
                    throw new WikiFileNotFoundException();
            }
            response.EnsureSuccessStatusCode();
        }
    }
}
