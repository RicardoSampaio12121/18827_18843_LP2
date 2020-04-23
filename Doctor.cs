using System;

namespace LP2_TP1
{

    public class Doctor
    {

        #region ATTRIBUTES

        private int idDoctor = 0;
        private string name;
        private string birthDate;
        private string cc;
        private bool operational;

        #endregion


        #region properties

        public int IdDoctor
        {
            get => idDoctor;
            set => idDoctor = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string BirthDate
        {
            get => birthDate;
            set => birthDate = value;
        }

        public string CC
        {
            get => cc;
            set => cc = value;
        }

        public bool Operational{
            get => operational;
            set => operational = value;
        }

        #endregion

        #region METHODS



        #region CONSTRUCTORS 

        public Doctor()
        {
            this.idDoctor = Doctors.nDoctors + 1;
            this.name = "";
            this.birthDate = "";
            this.cc = "";
            this.operational = true;
        }

        public Doctor(string name, string birthDate, string cc)
        {
            this.idDoctor++;
            this.name = name;
            this.birthDate = "";
            this.cc = cc;
        }

        #endregion


        #endregion



    }
}