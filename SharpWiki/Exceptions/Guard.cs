using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpWiki.Exceptions
{
    /// <summary>
    /// Guards facade
    /// </summary>
    public class Guard
    {
        /// <summary>
        /// An entry point to a set of Guard Clauses.
        /// </summary>
        private Guard() { }

        /// <summary>
        /// Default Guard Object
        /// </summary>
        public static Guard Against = new Guard();
    }
}
