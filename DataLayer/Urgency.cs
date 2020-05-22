using System;
using System.Collections.Generic;
using System.Text;
using HospitalBO;

namespace DataLayer
{
    /// <summary>
    /// This class handles the urgency queue
    /// </summary>
    public class Urgency
    {
        #region ATTRIBUTES

        static SortedList<int, Patient> urgencyQueue;

        #endregion

        #region CONSTRUCTOR
        static Urgency()
        {
            urgencyQueue = new SortedList<int, Patient>(new DuplicateKeyComparer<int>());
        }
        #endregion

        #region METHODS

        /// <summary>
        /// Add a patient to the queue
        /// </summary>
        /// <param name="p"></param>
        public static void AddToUrgencyQueue(Patient p)
        {
            urgencyQueue.Add(p.Priority, p);
        }

        /// <summary>
        /// Returns a copy of the queue
        /// </summary>
        /// <returns></returns>
        public static SortedList<int, Patient> ReturnCopyUrgencyQueue()
        {
            SortedList<int, Patient> aux = urgencyQueue;
            return aux;
        }

        /// <summary>
        /// Returns and removes the next patient in the queue
        /// </summary>
        /// <returns></returns>
        public static Patient ReturnNextPatient()
        {
            Patient p = urgencyQueue.Values[0];
            urgencyQueue.RemoveAt(0);
            return p;
        }

        /// <summary>
        /// Checks if the queue is empty or not
        /// </summary>
        /// <returns></returns>
        public static bool NotEmpty()
        {
            if (urgencyQueue.Count > 0) return true;
            return false;
        }

        #endregion

    }
}
