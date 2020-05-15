using System;
using System.IO;
using System.Collections.Generic;

namespace HospitalER
{
    public class Doctors
    {
        #region ATTRIBUTES

        const int MAXDOCTORS = 500; //numero máximo de pacientes (adultos)
        static List<Doctor> doctorsList = new List<Doctor>();
        //static Doctor[] doctorsList; //fila de espera da Urgencia normal
        public static int nDoctors; //numero de pacientes na Urgencia
        
        #endregion

        #region Methods
        
        #region CONSTRUCTORS

        /// <summary>
        /// Initializes at start up
        /// </summary>
        static Doctors()
        {
            //doctorsList = new Doctor[MAXDOCTORS];
            nDoctors = 0;
        }

        /// <summary>
        /// Verifys if the CC exists
        /// </summary>
        /// <param name="CC"></param>
        /// <returns></returns>
        public static bool VerifyIfRepeated(Doctor d)
        {
            for (var i = 0; i < doctorsList.Count; i++)
                if (doctorsList[i].IdDoctor == d.IdDoctor) return true;
            return false;
        }

        public static int GetNewDoctorID()
        {
            var sum = 0;
            try
            {
                foreach (var file in Directory.EnumerateFiles("DoctorsInfo/", "*"))
                {
                    sum++;
                }
            }
            catch
            {
                return -1;
            }

            return sum + 1;
        }

        #endregion

        /// <summary>
        /// Add a doctor to th array
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool AddToDoctors(Doctor d)
        {
            if (!VerifyIfRepeated(d))
            {
                doctorsList.Add(d);
                nDoctors++;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Edits the doctor's name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool EditDoctorName(int id, string name)
        {
            for (int i = 0; i < nDoctors; i++)
            {

                if (id == doctorsList[i].IdDoctor && doctorsList[i].Operational)
                {
                    doctorsList[i].Name = name;
                    return true;
                }

            }
            return false;
        }
        /// <summary>
        /// Removes a doctor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool RemoveDoc(int id)
        {
            int i;

            for (i = 0; i < nDoctors; i++)
            {
                if (doctorsList[i].IdDoctor == id && doctorsList[i].Operational)
                {

                    doctorsList[i].Operational = false;
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Verifys if the doctor's id exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool VerifyID(int id)
        {
            for (int i = 0; i < nDoctors; i++)
            {
                if(id == doctorsList[i].IdDoctor && doctorsList[i].Operational) return true;
            }
            return false;
        }
        
        /// <summary>
        /// Lists all the operational doctors
        /// </summary>
        public static void ListDoctors()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("|                                LIST OF ALL DOCTORS                            |");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("|      ID      |                 NAME                |          CC NUMBER       |");
            Console.WriteLine("---------------|-------------------------------------|--------------------------|");

            for (int i = 0; i < nDoctors; i++)
            {
                if (doctorsList[i].Operational)
                {
                    Console.WriteLine("|{0,14}|{1,37}|{2,26}|", doctorsList[i].IdDoctor, doctorsList[i].Name, doctorsList[i].CC);
                    if (i + 1 < nDoctors)
                        Console.WriteLine("---------------|-------------------------------------|--------------------------|");
                    else
                        Console.WriteLine("---------------------------------------------------------------------------------");
                }
            }
        }

        #endregion
    }
}