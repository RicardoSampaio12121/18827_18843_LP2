using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions
{
    /// <summary>
    /// Handles the exception when someone tries to clock in a non operational doctor
    /// </summary>
    public class NotOperationalException : ApplicationException
    {
        public NotOperationalException() : base("Error") { }
        public NotOperationalException(string g) : base("Error: " + g) { }

        public NotOperationalException(string g, Exception e)
        {
            throw new NotOperationalException("Error: " + g + " " + e.Message);
        }
    }
}
