using System;
using System.Collections.Generic;
using System.Text;
using HospitalBO;

namespace HospitalER
{
    /// <summary>
    /// Didn't know where to put this methods so here they are!
    /// </summary>
    public class Utils
    {
        #region METHODS

        /// <summary>
        /// Lists a patient
        /// </summary>
        /// <param name="p"></param>
        public static void ListPatient(Patient p)
        {
            Console.WriteLine("Patient: {0}", p.Name.ToString());
            Console.WriteLine("Birth date: {0}", p.BirthDate.ToString());
            Console.WriteLine("Identification: {0}", p.CC.ToString());
            Console.WriteLine("Address: {0}", p.Address.ToString());
        }

        /// <summary>
        /// List patient with priority
        /// </summary>
        /// <param name="p"></param>
        public static void ListPatientWithPriority(Patient p)
        {
            Console.WriteLine("Patient: {0}", p.Name.ToString());
            Console.WriteLine("Birth date: {0}", p.BirthDate.ToString());
            Console.WriteLine("Identification: {0}", p.CC.ToString());
            Console.WriteLine("Address: {0}", p.Address.ToString());
            Console.WriteLine("Priority: {0}", p.Priority.ToString());
        }

        #endregion
    }
}
