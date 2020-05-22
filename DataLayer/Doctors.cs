using System;
using System.Collections.Generic;
using System.Text;
using HospitalBO;

namespace DataLayer
{
    /// <summary>
    /// Controls the doctors at work
    /// </summary>
    public class Doctors
    {
        #region ATTRIBUTES

        static List<Doctor> doctorsWorking;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initializes at start up
        /// </summary>
        static Doctors()
        {
            doctorsWorking = new List<Doctor>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Checks if there is a doctor at work associated with the id passed by argument
        /// </summary>
        /// <param name="CC"></param>
        /// <returns></returns>
        public static bool VerifyIfRepeated(int id)
        {
            foreach(var dd in doctorsWorking)
            {
                if (id == dd.IdDoctor)
                {
                    return true;
                } 
            }     
            return false;
        }

        /// <summary>
        /// Adds a doctor to the list
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool AddToWorkingDoctors(Doctor d)
        {
            if (!VerifyIfRepeated(d.IdDoctor))
            {
                doctorsWorking.Add(d);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes a doctor from the list
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool RemoveFromWorkingDoctors(Doctor d)
        {
            if (doctorsWorking.Remove(d))
                return true;
            return false;
        }

        /// <summary>
        /// Removes a doctor by his ID from the doctorsWorking list
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool RemoveFromWorkingDoctorsByID(int id)
        {
            foreach(var d in doctorsWorking)
            {
                if (d.IdDoctor == id)
                    if (doctorsWorking.Remove(d)) return true;

            }
            return false;
        }

        /// <summary>
        /// Returns a copy of the workingDoctors list
        /// </summary>
        /// <returns></returns>
        public static List<Doctor> ReturnCopiedList()
        {
            List<Doctor> aux = doctorsWorking;
            return aux;
        }

        #endregion
    }
}
