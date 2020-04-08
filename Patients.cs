using System;

namespace LP2_TP1
{
    public class Patients
    {
        #region ATTRIBUTES

        const int MAXPATIENTS = 500; //numero máximo de pacientes (adultos)
        static Patient[] queueNormal; //fila de espera da Urgencia normal
        static int nPatients; //numero de pacientes na Urgencia


        #endregion

        #region CONSTRUCTORS

        static Patients()
        {
            queueNormal = new Patient[MAXPATIENTS];
            nPatients = 0;
        }



        #endregion

        #region Functions

        public static int NPatients()
        {
            return nPatients;
        }


        public static bool AddToQueue(Patient p)
        {
            if (!VerifyCC(p))
            {
                queueNormal[nPatients] = p;
                nPatients++;
                return true;
            }
            return false;

        }

        public static bool VerifyCC(Patient p1)
        {
            for (int i = 0; i < nPatients; i++)
            {
                if (p1 == queueNormal[i])
                    return true;
            }
            return false;
        }

        public static void ListPatientsQueue()
        {
            for(int i = 0; i < nPatients; i++){
                Console.WriteLine("Nome: {0}", queueNormal[i].Name);
                Console.WriteLine("Priority: {0}", queueNormal[i].Priority);
            }
        }

        #endregion
    }


    public class PatientsPediatry
    {
        #region  ATTRIBUTES

        static Patient[] queuePediatrics; //fila de espera da Urgencia de Pediatria
        const int MAXPATIENTSPEDRIATRICS = 500; //numero máximo de pacientes (pediatria)
        static int nPatientsPedriatics; //numero de pacientes na Urgencia da pediatria
        #endregion


        #region CONSTRUCTORS

        static PatientsPediatry()
        {
            queuePediatrics = new Patient[MAXPATIENTSPEDRIATRICS];
            nPatientsPedriatics = 0;
        }


        #endregion
    }
}