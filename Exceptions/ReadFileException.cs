using System;

namespace Exceptions
{
    /// <summary>
    /// Handles the exception when files can not be read
    /// </summary>
    public class ReadFileException : ApplicationException
    {
        public ReadFileException() : base("Error") { }
        public ReadFileException(string g) : base("Error: " + g) { }

        public ReadFileException(string g, Exception e)
        {
            throw new ReadFileException("Error: " + g + " " + e.Message);
        }
    }
}