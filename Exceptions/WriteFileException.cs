using System;

namespace Exceptions
{
    /// <summary>
    /// Handles exception when file can not be read
    /// </summary>
    public class WriteFileException : ApplicationException
    {
        public WriteFileException() : base("Error") { }
        public WriteFileException(string g) : base("Error: " + g) { }

        public WriteFileException(string g, Exception e)
        {
            throw new WriteFileException("Error: " + g + " " + e.Message);
        }
    }
}