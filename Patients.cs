using System;

namespace LP2_TP1
{
    public class Patients
    {
        #region ATTRIBUTES

        const int MAXPATIENTS = 500; //numero máximo de pacientes (adultos)
        static Patient[] patientFiles; //fila de espera da Urgencia normal
        static int nPatients; //numero de pacientes na Urgencia


        #endregion

        #region CONSTRUCTORS

        static Patients()
        {
            patientFiles = new Patient[MAXPATIENTS];
            nPatients = 0;
        }

        #endregion

        #region Functions


        public static void AddToFile(Patient p)
        {
              patientFiles[nPatients] = p;
              nPatients++;
        }

        public static bool VerifyCC(string CC, out int valor)
        {
            valor = 0;
            for (int i = 0; i < nPatients; i++)
            {
                if (string.Compare(CC, patientFiles[i].CC) == 0)
                {
                    valor = i;
                    return true;
                }
            }

            return false;
        }

        
        public static bool VerifyCC(string CC)
        {
            for (int i = 0; i < nPatients; i++)
            {
                if (string.Compare(CC, patientFiles[i].CC) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool EditFileName(string CC, string name)
        {
            for (int i = 0; i < nPatients; i++)
            {

                if (VerifyCC(CC) == true)
                {
                    patientFiles[i].Name = name;
                    return true;
                }

            }
            return false;
        }

        public static bool EditFileAddress(string CC, string address)
        {
            for (int i = 0; i < nPatients; i++)
            {

                if (VerifyCC(CC) == true)
                {
                    patientFiles[i].Adress = address;
                    return true;
                }
            }
            return false;
        }

        public static bool EditFileNameAddress(string CC, string name, string address)
        {
            for (int i = 0; i < nPatients; i++)
            {
                if (VerifyCC(CC) == true)
                {
                    patientFiles[i].Name = name;
                    patientFiles[i].Adress = address;
                    return true;
                }
            }
            return false;
        }


        
        public static Patient GetPatientByCC(string CC)
        {
            int position;
            if (VerifyCC(CC, out position) == true)
            {
                return patientFiles[position];
            }
            return patientFiles[position]; 
        }


        public static void ListPatientsFile()
        {
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                                                    LIST OF ALL PATIENTS                                                                     |");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                NAME                    |      BIRTHDATE       |        CC NUMBER        |                              ADRESS                               |");
            Console.WriteLine("-----------------------------------------|----------------------|-------------------------|-------------------------------------------------------------------|");

            for (int i = 0; i < nPatients; i++)
            {
                
                Console.WriteLine("|{0,40}|{1,22}|{2,25}|{3, 67}|", patientFiles[i].Name, patientFiles[i].BirthDate, patientFiles[i].CC, patientFiles[i].Adress);
                if (i + 1 < nPatients)
                    Console.WriteLine("|----------------------------------------|----------------------|-------------------------|-------------------------------------------------------------------|");
                else
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
            }
        }

        #endregion
    }

}