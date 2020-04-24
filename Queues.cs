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

        public static Patient CallNextPatient()
        {
            return queueScreening[0];
        }

        public static void RemovePatientFromScreeningQueue()
        {
            for (int i = 0; i < nPatients; i++)
            {
                queueScreening[i] = queueScreening[i + 1];
            }
            nPatients--;
        }

        public static Patient GivePriority(Patient p, int patientPriority)
        {
            p.Priority = patientPriority;
            return p;
        }

        public static void ListCurrentPatient()
        {
            Console.WriteLine("       Pacient Information        ");
            Console.WriteLine("Name: {0}", queueScreening[0].Name);
            Console.WriteLine("Birth Date: {0}", queueScreening[0].BirthDate);
            Console.WriteLine("CC Number: {0}", queueScreening[0].CC);
            Console.WriteLine("Adress: {0}", queueScreening[0].Adress);
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

    public class UrgencyQueue
    {

        #region ATTRIBUTES

        const int MAXPATIENTS = 500;
        static Patient[] queueUrgency; //fila de espera da Urgencia normal
        static int nPatients; //numero de pacientes na Urgencia

        #endregion

        #region CONSTRUCTORS

        static UrgencyQueue()
        {
            queueUrgency = new Patient[MAXPATIENTS];
            nPatients = 0;
        }

        #endregion

        #region Functions

        public static bool AddToUrgency(Patient p)
        {
            if (!VerifyCC(p))
            {
                bool entrou = false;
                int x = 0;

                for (int i = 0; i < nPatients; i++)
                {
                    if (p.Priority > queueUrgency[i].Priority)
                    {
                        entrou = true;
                        x = i;
                    }
                }

                if (entrou == true)
                {
                    Patient aux = queueUrgency[x];
                    Patient aux2;
                    queueUrgency[x] = p;

                    for (int i = 0; i < nPatients + 1; i++)
                    {

                        if (i > x)
                        {
                            aux2 = queueUrgency[x + (i - x)];
                            queueUrgency[x + (i - x)] = aux;
                            aux = aux2;

                        }
                    }
                }
                else
                    queueUrgency[nPatients] = p;

                nPatients++;
                return true;
            }
            return false;
        }


        public static Patient CallNextPatient()
        {
            return queueUrgency[0];
        }


        public static void RemovePatientUrgencyQueue()
        {
            for (int i = 0; i < nPatients; i++)
            {
                queueUrgency[i] = queueUrgency[i + 1];
            }
            nPatients--;
        }

        public static bool VerifyCC(Patient p1)
        {
            for (int i = 0; i < nPatients; i++)
            {
                if (p1 == queueUrgency[i])
                    return true;
            }
            return false;
        }

        public static void ListCurrentPatient()
        {
            Console.WriteLine("       Pacient Information        ");
            Console.WriteLine("Name: {0}", queueUrgency[0].Name);
            Console.WriteLine("Birth Date: {0}", queueUrgency[0].BirthDate);
            Console.WriteLine("CC Number: {0}", queueUrgency[0].CC);
            Console.WriteLine("Priority: {0}", queueUrgency[0].Priority);

        }

        public static void ListPatientsInUrgency()
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                   LIST OF PATIENTS IN QUEUE FOR URGENCY                                    |");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                NAME                    |      BIRTHDATE       |        CC NUMBER        |      PRIORITY    |");
            Console.WriteLine("-----------------------------------------|----------------------|-------------------------|------------------|");

            for (int i = 0; i < nPatients; i++)
            {

                Console.WriteLine("|{0,40}|{1,22}|{2,25}|{3, 18}|", queueUrgency[i].Name, queueUrgency[i].BirthDate, queueUrgency[i].CC, queueUrgency[i].Priority);
                if (i + 1 < nPatients)
                    Console.WriteLine("-----------------------------------------|----------------------|-------------------------|------------------|");
                else
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------|");
            }
        }

        #endregion

    }
}