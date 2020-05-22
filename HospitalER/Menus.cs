using System;

namespace HospitalER
{
    /// <summary>
    /// This class handles all the menus drawings
    /// </summary>
    public class Menus
    {

        /// <summary>
        /// Prints the main menu to the screen
        /// </summary>
        public static void PrintMainMenu()
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("|       Emergency Room of HOSPITAL S.JOAO DA POEIRA       |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("|                       MAIN MENU                         |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("| A) Patients                                             |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| B) Doctors                                              |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| C) Emergency Room                                       |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| D) Exit                                                 |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.Write("Decision: ");
        }

        /// <summary>
        /// Prints the patient's menu to the screen
        /// </summary>
        public static void PrintMenuPatients()
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("|       Emergency Room of HOSPITAL S.JOAO DA POEIRA       |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("|                     PATIENTS MENU                       |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("| A) Make file                                            |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| B) Edit                                                 |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| C) List all Patients                                    |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| D) Exit                                                 |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.Write("Decision: ");
        }

        /// <summary>
        /// Prints doctor's menu to the screen
        /// </summary>
        public static void PrintMenuDoctors()
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("|       Emergency Room of HOSPITAL S.JOAO DA POEIRA       |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("|                     DOCTORS MENU                        |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("| A) Clock in                                             |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| B) Clock out                                            |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| C) Add doctor                                           |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| D) Edit doctor                                          |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| E) Change operational status                            |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("| F) List                                                 |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("| G) Exit                                                 |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.Write("Decision: ");
        }

        /// <summary>
        /// Prints the emergency room menu to the screen
        /// </summary>
        public static void PrintMenuER()
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("|       Emergency Room of HOSPITAL S.JOAO DA POEIRA       |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("|                 EMERGENCY ROOM MENU                     |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("| A) Screening                                            |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| B) Urgency                                              |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| C) Exit                                                 |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.Write("Decision: ");
        }

        /// <summary>
        /// Prints the screening menu to the screen
        /// </summary>
        public static void PrintMenuScreening()
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("|       Emergency Room of HOSPITAL S.JOAO DA POEIRA       |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("|                   SCREENING  MENU                       |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("| A) Call Persons                                         |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| B) List Screening queue                                 |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| C) Exit                                                 |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.Write("Decision: ");
        }

        /// <summary>
        /// Prints the urgency menu to the screen
        /// </summary>
        public static void PrintMenuUrgency()
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("|       Emergency Room of HOSPITAL S.JOAO DA POEIRA       |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("|                      URGENCY  MENU                      |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("| A) Call Persons                                         |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| B) List Urgency queue                                   |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| C) Exit                                                 |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.Write("Decision: ");
        }
    }
}