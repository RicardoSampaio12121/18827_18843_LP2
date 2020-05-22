using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    /// <summary>
    /// This class has a comparator used in the sortedlist in urgency
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
    {
        #region IComparer<TKey> Members
        
        /// <summary>
        /// Compares the key of a sortedlist
        /// if x == y, x is inserted behind y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(TKey x, TKey y)
        {
            int result = x.CompareTo(y);

            if (result == 0)
                return -1;  
            else
                return result;
        }

        #endregion
    }
}

