using System;
using System.IO;

namespace Exceptions
{
    /// <summary>
    /// Handles the exception when files can not be opened
    /// </summary>
    public class OpenFileException : ApplicationException
    {
        public OpenFileException() : base("Error") { }
        public OpenFileException(string g) : base("Error: " + g) { }

        public OpenFileException(string g, IOException e)
        {
            throw new OpenFileException("Error: " + g + " " + e.Message);
        }
    }
}