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
        /// <summary>
        /// Gives and receaves the value of the variable
        /// </summary>
        /// <value></value>
        public int IdDoctor
        {
            get => idDoctor;
            set => idDoctor = value;
        }
        /// <summary>
        /// Gives and receaves the value of the variable
        /// </summary>
        /// <value></value>
        public string Name
        {
            get => name;
            set => name = value;
        }
        /// <summary>
        /// Gives and receaves the value of the variable
        /// </summary>
        /// <value></value>
        public string BirthDate
        {
            get => birthDate;
            set => birthDate = value;
        }
        /// <summary>
        /// Gives and receaves the value of the variable
        /// </summary>
        /// <value></value>
        public string CC
        {
            get => cc;
            set => cc = value;
        }
        /// <summary>
        /// Gives and receaves the value of the variable
        /// </summary>
        /// <value></value>
        public bool Operational
        {
            get => operational;
            set => operational = value;
        }

        #endregion

        #region METHODS



        #region CONSTRUCTORS 
        /// <summary>
        /// Creates a new object of the class
        /// </summary>
        public Doctor()
        {
            this.idDoctor = Doctors.nDoctors + 1;
            this.name = "";
            this.birthDate = "";
            this.cc = "";
            this.operational = true;
        }
        /// <summary>
        /// Create a new Doctor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="birthDate"></param>
        /// <param name="cc"></param>
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