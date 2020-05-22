using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions
{
    /// <summary>
    /// General use
    /// </summary>
    public class ReturnException :ApplicationException
    {
        public ReturnException() : base("Error") { }
        public ReturnException(string g) : base("Error: " + g) { }

        public ReturnException(string g, Exception e)
        {
            throw new NotOperationalException("Error: " + g + " " + e.Message);
        }
    }
}
