/* ---------------------------------------------------------------------
 * Resume: Contains the Screening class, which controls the screening 
 * queue.
 * Author: Ricardo Sampaio
 * Author: Cláudio Silva
 *---------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Text;
using HospitalBO;

namespace DataLayer
{
    /// <summary>
    /// This class handles the queue to the screening
    /// </summary>
    public class Screening
    {
        #region ATTRIBUTES

        static Queue<Patient> screeningQueue;

        #endregion

        #region CONSTRUCTOR
        static Screening()
        {
            screeningQueue = new Queue<Patient>();
        }
        #endregion

        #region METHODS

        /// <summary>
        /// Add a patient to the queue
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool AddToQueue(Patient p)
        {
            if (!screeningQueue.Contains(p))
            {
                screeningQueue.Enqueue(p);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets the next patient in the screening queue
        /// </summary>
        /// <returns></returns>
        public static void RemoveNextPatient()
        {
            screeningQueue.Dequeue();
        }
        
        /// <summary>
        /// Gets the next patient in the queue without removing him
        /// </summary>
        /// <returns></returns>
        public static Patient PeekNextPatient()
        {
            return screeningQueue.Peek();
        }

        /// <summary>
        /// Returns a copy of the queue
        /// </summary>
        /// <returns></returns>
        public static Queue<Patient> ReturnCopyQueue()
        {
            Queue<Patient> aux = screeningQueue;
            return aux;
        }

        /// <summary>
        /// Checks if the queue is empty or not
        /// </summary>
        /// <returns></returns>
        public static bool HasPatients()
        {
            if (screeningQueue.Count > 0)
                return true;
            return false;
        }

        #endregion

    }
}
