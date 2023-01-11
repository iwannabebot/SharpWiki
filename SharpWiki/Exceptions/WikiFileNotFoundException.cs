using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpWiki.Exceptions
{
    /// <summary>
    /// File not found exception
    /// </summary>
    public class WikiFileNotFoundException : Exception
    {
        public WikiFileNotFoundException(): base("Title not found") { }

    }
}
