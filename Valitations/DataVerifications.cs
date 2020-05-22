using System;

namespace Verifications
{
    /// <summary>
    /// This class handles data valitations
    /// </summary>
    public class DataVerifications
    {
        /// <summary>
        /// Cheks if the inserted name has two or more words
        /// Returns false if it doesn't
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool ValidName(string name)
        {
            foreach (char c in name)
            {
                if (c == ' ') return true;
            }
            return false;
        }

        /// <summary>
        /// Check if the identification is valid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool ValidIdentification(string id)
        {
            if (id.Length != 12) return false;
            return true;
        }
    }
}