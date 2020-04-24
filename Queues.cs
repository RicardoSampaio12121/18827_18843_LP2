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
        static Patient[] queueUrgency1;
        static Patient[] queueUrgency2;
        static Patient[] queueUrgency3;
        static Patient[] queueUrgency4;
        static Patient[] queueUrgency5;
        static int nPatients;
        static int nPatients1;
        static int nPatients2;
        static int nPatients3;
        static int nPatients4;
        static int nPatients5;

        #endregion

        #region CONSTRUCTORS

        static UrgencyQueue()
        {
            queueUrgency1 = new Patient[MAXPATIENTS];
            queueUrgency2 = new Patient[MAXPATIENTS];
            queueUrgency3 = new Patient[MAXPATIENTS];
            queueUrgency4 = new Patient[MAXPATIENTS];
            queueUrgency5 = new Patient[MAXPATIENTS];
        }

        #endregion

        #region Functions

        public static bool AddToUrgency(Patient p)
        {
            if (!VerifyCC(p))
            {
                /*bool entrou = false;
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
                            aux2 = queueUrgency[i];
                            queueUrgency[i] = aux;
                            aux = aux2;

                        }
                    }
                }
                else
                    queueUrgency[nPatients] = p;

                nPatients++;
                return true;
                */

                if (p.Priority == 1)
                {
                    queueUrgency1[nPatients1] = p;
                    nPatients1++;
                }
                else if (p.Priority == 2)
                {
                    queueUrgency2[nPatients2] = p;
                    nPatients2++;
                }
                else if (p.Priority == 3)
                {
                    queueUrgency3[nPatients3] = p;
                    nPatients3++;
                }
                else if (p.Priority == 4)
                {
                    queueUrgency4[nPatients4] = p;
                    nPatients4++;
                }
                else if (p.Priority == 5)
                {
                    queueUrgency5[nPatients5] = p;
                    nPatients5++;
                }
                return true;
            }
            return false;
        }


        public static Patient CallNextPatient()
        {
            if (nPatients5 > 0)
                return queueUrgency5[0];
            else if (nPatients4 > 0)
                return queueUrgency4[0];
            else if (nPatients3 > 0)
                return queueUrgency3[0];
            else if (nPatients2 > 0)
                return queueUrgency2[0];
            else if (nPatients1 > 0)
                return queueUrgency1[0];

            return queueUrgency1[0];

        }


        public static void RemovePatientUrgencyQueue()
        {
            if (nPatients5 > 0)
            {
                for (int i = 0; i < nPatients5; i++)
                {
                    queueUrgency5[i] = queueUrgency5[i + 1];
                }
                nPatients5--;
            }
            else if (nPatients4 > 0)
            {
                for (int i = 0; i < nPatients4; i++)
                {
                    queueUrgency4[i] = queueUrgency4[i + 1];
                }
                nPatients4--;
            }
            else if (nPatients3 > 0)
            {
                for (int i = 0; i < nPatients3; i++)
                {
                    queueUrgency3[i] = queueUrgency3[i + 1];
                }
                nPatients3--;
            }
            else if (nPatients2 > 0)
            {
                for (int i = 0; i < nPatients2; i++)
                {
                    queueUrgency2[i] = queueUrgency2[i + 1];
                }
                nPatients2--;
            }
            else if (nPatients1 > 0)
            {
                for (int i = 0; i < nPatients1; i++)
                {
                    queueUrgency1[i] = queueUrgency1[i + 1];
                }
                nPatients1--;
            }
        }

        public static bool VerifyCC(Patient p1)
        {
            if (p1.Priority == 5)
            {
                for (int i = 0; i < nPatients5; i++)
                {
                    if (p1 == queueUrgency5[i])
                        return true;
                }
            }
            if (p1.Priority == 4)
            {
                for (int i = 0; i < nPatients4; i++)
                {
                    if (p1 == queueUrgency4[i])
                        return true;
                }
            }
            if (p1.Priority == 3)
            {
                for (int i = 0; i < nPatients3; i++)
                {
                    if (p1 == queueUrgency3[i])
                        return true;
                }
            }
            if (p1.Priority == 2)
            {
                for (int i = 0; i < nPatients2; i++)
                {
                    if (p1 == queueUrgency2[i])
                        return true;
                }
            }
            if (p1.Priority == 1)
            {
                for (int i = 0; i < nPatients1; i++)
                {
                    if (p1 == queueUrgency1[i])
                        return true;
                }
            }
            return false;
        }

        public static void ListCurrentPatient()
        {
            Console.WriteLine("       Pacient Information        ");
            if (nPatients5 > 0)
            {
                Console.WriteLine("Name: {0}", queueUrgency5[0].Name);
                Console.WriteLine("Birth Date: {0}", queueUrgency5[0].BirthDate);
                Console.WriteLine("CC Number: {0}", queueUrgency5[0].CC);
                Console.WriteLine("Priority: {0}", queueUrgency5[0].Priority);
            }
            else if (nPatients4 > 0)
            {
                Console.WriteLine("Name: {0}", queueUrgency4[0].Name);
                Console.WriteLine("Birth Date: {0}", queueUrgency4[0].BirthDate);
                Console.WriteLine("CC Number: {0}", queueUrgency4[0].CC);
                Console.WriteLine("Priority: {0}", queueUrgency4[0].Priority);
            }
            else if (nPatients3 > 0)
            {
                Console.WriteLine("Name: {0}", queueUrgency3[0].Name);
                Console.WriteLine("Birth Date: {0}", queueUrgency3[0].BirthDate);
                Console.WriteLine("CC Number: {0}", queueUrgency3[0].CC);
                Console.WriteLine("Priority: {0}", queueUrgency3[0].Priority);
            }
            else if (nPatients2 > 0)
            {
                Console.WriteLine("Name: {0}", queueUrgency2[0].Name);
                Console.WriteLine("Birth Date: {0}", queueUrgency2[0].BirthDate);
                Console.WriteLine("CC Number: {0}", queueUrgency2[0].CC);
                Console.WriteLine("Priority: {0}", queueUrgency2[0].Priority);
            }
            else if (nPatients1 > 0)
            {
                Console.WriteLine("Name: {0}", queueUrgency1[0].Name);
                Console.WriteLine("Birth Date: {0}", queueUrgency1[0].BirthDate);
                Console.WriteLine("CC Number: {0}", queueUrgency1[0].CC);
                Console.WriteLine("Priority: {0}", queueUrgency1[0].Priority);
            }
        }

        public static void ListPatientsInUrgency()
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                   LIST OF PATIENTS IN QUEUE FOR URGENCY                                    |");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                NAME                    |      BIRTHDATE       |        CC NUMBER        |      PRIORITY    |");
            Console.WriteLine("-----------------------------------------|----------------------|-------------------------|------------------|");


            if (nPatients5 > 0)
            {
                for (int t = 0; t < nPatients5; t++)
                {
                    Console.WriteLine("|{0,40}|{1,22}|{2,25}|{3, 18}|", queueUrgency5[t].Name, queueUrgency5[t].BirthDate, queueUrgency5[t].CC, queueUrgency5[t].Priority);
                    Console.WriteLine("-----------------------------------------|----------------------|-------------------------|------------------|");

                }
            }
            if (nPatients4 > 0)
            {
                for (int t = 0; t < nPatients4; t++)
                {
                    Console.WriteLine("|{0,40}|{1,22}|{2,25}|{3, 18}|", queueUrgency4[t].Name, queueUrgency4[t].BirthDate, queueUrgency4[t].CC, queueUrgency4[t].Priority);
                    Console.WriteLine("-----------------------------------------|----------------------|-------------------------|------------------|");

                }
            }
            if (nPatients3 > 0)
            {
                for (int t = 0; t < nPatients3; t++)
                {
                    Console.WriteLine("|{0,40}|{1,22}|{2,25}|{3, 18}|", queueUrgency3[t].Name, queueUrgency3[t].BirthDate, queueUrgency3[t].CC, queueUrgency3[t].Priority);
                    Console.WriteLine("-----------------------------------------|----------------------|-------------------------|------------------|");

                }
            }
            if (nPatients2 > 0)
            {
                for (int t = 0; t < nPatients2; t++)
                {
                    Console.WriteLine("|{0,40}|{1,22}|{2,25}|{3, 18}|", queueUrgency2[t].Name, queueUrgency2[t].BirthDate, queueUrgency2[t].CC, queueUrgency2[t].Priority);
                    Console.WriteLine("-----------------------------------------|----------------------|-------------------------|------------------|");

                }
            }
            if (nPatients1 > 0)
            {
                for (int t = 0; t < nPatients1; t++)
                {
                    Console.WriteLine("|{0,40}|{1,22}|{2,25}|{3, 18}|", queueUrgency1[t].Name, queueUrgency1[t].BirthDate, queueUrgency1[t].CC, queueUrgency1[t].Priority);
                    Console.WriteLine("-----------------------------------------|----------------------|-------------------------|------------------|");

                }
            }

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------|");

        }

        #endregion

    }
}