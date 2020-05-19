using System;
using System.IO;

namespace HospitalER
{
    [Serializable]
    public class Patients
    {
        #region ATTRIBUTES

        const int MAXPATIENTS = 500; //numero máximo de pacientes (adultos)
        static Patient[] patientFiles; //fila de espera da Urgencia normal
        static int nPatients = 0; //numero de pacientes na Urgencia

        #endregion

        #region Methods

        #region CONSTRUCTORS
        /// <summary>
        /// Initializes at start up
        /// </summary>
        static Patients()
        {
            patientFiles = new Patient[MAXPATIENTS];
            nPatients = 0;
        }

        #endregion





        /// <summary>
        /// Edit Patient name
        /// </summary>
        /// <param name="CC"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool EditPatientFile(string path, string name, string address)
        {
            var p = new Patient();
            try
            {
                p = Directories.ReadPersonFromFile<Patient>(path);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "Could not read patient file");
                return false;
            }

            try
            {
                if (name != "")
                    p.Name = name;
                if (address != "")
                    p.Address = address;

                if (Patient.RewritePersonFile<Patient>(path, p))
                {
                    return true;
                }
                return false;
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "Could not write to file");
                return false;
            }
        }


        /// <summary>
        /// list all Patients file
        /// </summary>
        public static bool ListPatientsFile(string path)
        {
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                                                    LIST OF ALL PATIENTS                                                                     |");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                NAME                    |      BIRTHDATE       |        CC NUMBER        |                              ADRESS                               |");

            foreach (var file in Directory.EnumerateFiles(path, "*"))
            {
                Console.WriteLine("-----------------------------------------|----------------------|-------------------------|-------------------------------------------------------------------|");

                var p = Directories.ReadPersonFromFile<Patient>(file);

                if (p.CC.Length > 2)
                    Console.WriteLine("|{0,40}|{1,22}|{2,25}|{3, 67}|", p.Name.ToString(), p.BirthDate.ToString(), p.CC.ToString(), p.Address.ToString());
                else return false;
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
            return true;
        }

        #endregion
    }

}