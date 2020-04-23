using System;

namespace LP2_TP1
{

    public class Screening
    {

        #region ATTRIBUTES

        const int MAXPATIENTS = 500;
        static Patient[] queueScreening; //fila de espera da Urgencia normal
        static int nPatients; //numero de pacientes na Urgencia

        #endregion


        #region CONSTRUCTORS

        static Screening()
        {
            queueScreening = new Patient[MAXPATIENTS];
            nPatients = 0;
        }

        #endregion


        #region Functions
        public static bool AddToScreening(Patient p)
        {
            if (!VerifyCC(p))
            {
                queueScreening[nPatients] = p;
                nPatients++;
                return true;
            }
            return false;
        }

        public static bool VerifyCC(Patient p1)
        {
            for (int i = 0; i < nPatients; i++)
            {
                if (p1 == queueScreening[i])
                    return true;
            }
            return false;
        }

        public static void ListPatientsInScreening()
        {
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                                              LIST OF PATIENTS IN QUEUE FOR SCREENING                                                        |");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                NAME                    |      BIRTHDATE       |        CC NUMBER        |                              ADRESS                               |");
            Console.WriteLine("-----------------------------------------|----------------------|-------------------------|-------------------------------------------------------------------|");

            for (int i = 0; i < nPatients; i++)
            {

                Console.WriteLine("|{0,40}|{1,22}|{2,25}|{3, 67}|", queueScreening[i].Name, queueScreening[i].BirthDate, queueScreening[i].CC, queueScreening[i].Adress);
                if (i + 1 < nPatients)
                    Console.WriteLine("|----------------------------------------|----------------------|-------------------------|-------------------------------------------------------------------|");
                else
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------");
            }
        }
        #endregion
    }
}