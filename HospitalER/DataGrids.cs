using System;
using System.Collections.Generic;
using System.Text;
using HospitalBO;

namespace HospitalER
{
    /// <summary>
    /// This class handles all the tables drawings
    /// </summary>
    public class DataGrids
    {
        /// <summary>
        /// Table of all patient files
        /// </summary>
        /// <param name="lst"></param>
        public static void ListRegisteredPatients(List<HospitalBO.Patient> lst)
        {
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                                                    LIST OF ALL PATIENTS                                                                     |");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                NAME                    |      BIRTHDATE       |        CC NUMBER        |                              ADRESS                               |");

            foreach (var p in lst)
            {
                Console.WriteLine("-----------------------------------------|----------------------|-------------------------|-------------------------------------------------------------------|");
                Console.WriteLine("|{0,40}|{1,22}|{2,25}|{3, 67}|", p.Name.ToString(), p.BirthDate.ToShortDateString(), p.CC.ToString(), p.Address.ToString());
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }

        /// <summary>
        /// List doctors working right now
        /// </summary>
        /// <param name="lst"></param>
        public static void ListDoctors(List<Doctor> lst)
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------");

            Console.WriteLine("|                                                          DOCTORS AT WORK                                                       |");

            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------");

            Console.WriteLine("|      ID      |                 NAME                |          CC NUMBER       |        ADDRESS         |       OPERATIONAL     |");

            foreach (var p in lst)
            {
                Console.WriteLine("---------------|-------------------------------------|--------------------------|------------------------|------------------------");
                Console.WriteLine("|{0,14}|{1,37}|{2,26}|{3,24}|{4, 23}|", p.IdDoctor.ToString(), p.Name.ToString(), p.CC.ToString(), p.Address.ToString(), p.Operational.ToString());
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------");
        }

        /// <summary>
        /// List screening queue
        /// </summary>
        /// <param name="queue"></param>
        public static void ListScreeningQueue(Queue<Patient> queue)
        {
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                                                      Screening Queue                                                                        |");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                NAME                    |      BIRTHDATE       |        CC NUMBER        |                              ADRESS                               |");

            foreach (var p in queue)
            {
                Console.WriteLine("-----------------------------------------|----------------------|-------------------------|-------------------------------------------------------------------|");
                Console.WriteLine("|{0,40}|{1,22}|{2,25}|{3, 67}|", p.Name.ToString(), p.BirthDate.ToShortDateString(), p.CC.ToString(), p.Address.ToString());
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }

        /// <summary>
        /// Prints urgency queue
        /// </summary>
        /// <param name="lst"></param>
        public static void ListUrgencyQueue(SortedList<int, Patient> lst)
        {

            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                                Urgency Queue                                               |");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                NAME                    |      BIRTHDATE       |        CC NUMBER        |     Priority     |");

            foreach (var p in lst)
            {
                Console.WriteLine("-----------------------------------------|----------------------|-------------------------|-------------------");
                Console.WriteLine("|{0,40}|{1,22}|{2,25}|{3, 18}|", p.Value.Name.ToString(), p.Value.BirthDate.ToShortDateString(), p.Value.CC.ToString(), p.Key.ToString());
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
        }



    }
}
