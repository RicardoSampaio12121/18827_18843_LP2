using System;
using System.Globalization;

namespace HospitalBO
{
    /// <summary>
    /// Inherits from the abstract class person and creates objects of type Doctro
    /// </summary>
    [Serializable]
    public class Doctor : Person
    {
        #region ATTRIBUTES

        private int idDoctor;
        private bool operational;

        #endregion

        #region CONSTRUCTORS 
        /// <summary>
        /// Creates a new object of the class
        /// </summary>
        public Doctor()
        {
            this.idDoctor = 0;
            this.name = "";
            this.birthDate = DateTime.ParseExact("01/01/0001", "d/M/yyyy", CultureInfo.InvariantCulture);
            this.cc = "";
            this.address = "";
            this.operational = true;
        }
        /// <summary>
        /// Create a new Doctor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="birthDate"></param>
        /// <param name="cc"></param>
        public Doctor(string name, DateTime birthDate, string cc, string address)
        {
            this.idDoctor = 0;
            this.name = name;
            this.birthDate = birthDate;
            this.cc = cc;
            this.address = address;
            this.operational = true;
        }

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
        public override string Name
        {
            get => name;
            set => name = value;
        }
        /// <summary>
        /// Gives and receaves the value of the variable
        /// </summary>
        /// <value></value>
        public override DateTime BirthDate
        {
            get => birthDate;
            set => birthDate = value;
        }
        /// <summary>
        /// Gives and receaves the value of the variable
        /// </summary>
        /// <value></value>
        public override string CC
        {
            get => cc;
            set => cc = value;
        }
        /// <summary>
        /// Gets or sets address value
        /// </summary>
        public override string Address
        {
            get => address;
            set => address = value;
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
    }
}
