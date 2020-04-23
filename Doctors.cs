using System;

namespace LP2_TP1
{

    public class Doctors
    {

        #region ATTRIBUTES

        const int MAXDOCTORS = 500; //numero máximo de pacientes (adultos)
        static Doctor[] doctorsList; //fila de espera da Urgencia normal
        public static int nDoctors; //numero de pacientes na Urgencia


        #endregion

        #region CONSTRUCTORS

        static Doctors()
        {
            doctorsList = new Doctor[MAXDOCTORS];
            nDoctors = 0;
        }



        #endregion

        #region Functions

        public static bool VerifyCC(string CC)
        {
            for (int i = 0; i < nDoctors; i++)
            {

                if (string.Compare(CC, doctorsList[i].CC) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool AddToDoctors(Doctor d)
        {
            for (int i = 0; i <= nDoctors; i++)
            {
                if (!VerifyCC(d.CC))
                {
                    doctorsList[nDoctors] = d;
                    nDoctors++;
                    return true;
                }
            }
            return false;
        }




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