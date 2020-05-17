using System;
using System.IO;
using System.Collections.Generic;
using System.Linq.Expressions;

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
        public static bool CheckOut(int id)
        {
            foreach (var d in doctorsList)
            {
                if (d.IdDoctor == id)
                {
                    try
                    {
                        doctorsList.Remove(d);
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
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
        public static void ListCurrentOrFormerDoctors(string path, bool hired)
        {
            int id = 0;
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                                        LIST OF ALL DOCTORS                                                     |");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|      ID      |                 NAME                |          CC NUMBER       |        ADDRESS         |       OPERATIONAL     |");
            
            foreach (var file in Directory.EnumerateFiles(path, "*"))
            {
                id++;
                Console.WriteLine("---------------|-------------------------------------|--------------------------|------------------------|------------------------");
                
                var p = Directories.ReadPersonFromFile<Doctor>(file);
                if(hired && p.Operational)
                    Console.WriteLine("|{0,14}|{1,37}|{2,26}|{3,24}|{4, 23}|", id.ToString(), p.Name.ToString(),p.CC.ToString(), p.Address.ToString(), p.Operational.ToString());

                else if(!hired && !p.Operational)
                    Console.WriteLine("|{0,14}|{1,37}|{2,26}|{3,24}|{4, 23}|", id.ToString(), p.Name.ToString(),p.CC.ToString(), p.Address.ToString(), p.Operational.ToString());
                
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------");
        }

        public static void ListWorkingDoctors()
        {
            if (doctorsList.Count == 0)
            {
                Console.WriteLine("There are no doctors at work right now.");
            }
            else
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------");
                    
                Console.WriteLine("|                                                          DOCTORS AT WORK                                                       |");
                    
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------");
                    
                Console.WriteLine("|      ID      |                 NAME                |          CC NUMBER       |        ADDRESS         |       OPERATIONAL     |");
                    
                foreach (var p in doctorsList)
                {
                    Console.WriteLine("---------------|-------------------------------------|--------------------------|------------------------|------------------------");
                    Console.WriteLine("|{0,14}|{1,37}|{2,26}|{3,24}|{4, 23}|", p.IdDoctor.ToString(), p.Name.ToString(), p.CC.ToString(), p.Address.ToString(), p.Operational.ToString());
                }
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------");
            }
        }

        public static void ListAllDoctors(string path)
        {
            int id = 0;
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                                        LIST OF ALL DOCTORS                                                     |");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|      ID      |                 NAME                |          CC NUMBER       |        ADDRESS         |       OPERATIONAL     |");

            foreach (var file in Directory.EnumerateFiles(path, "*"))
            {
                id++;
                Console.WriteLine("---------------|-------------------------------------|--------------------------|------------------------|------------------------");
                
                var p = Directories.ReadPersonFromFile<Doctor>(file);
                Console.WriteLine("|{0,14}|{1,37}|{2,26}|{3,24}|{4, 23}|", id.ToString(), p.Name.ToString(),p.CC.ToString(), p.Address.ToString(), p.Operational.ToString());
                
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------");
        }

        #endregion
    }
}