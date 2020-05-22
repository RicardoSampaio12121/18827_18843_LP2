using System;
using System.Globalization;

namespace HospitalBO
{
    /// <summary>
    /// Inherits from the abstract class person and creates objects of type Patient
    /// </summary>
    [Serializable]
    public class Patient : Person
    {
        #region ATTRIBUTES

        [NonSerialized]
        private int priority = 0;

        #endregion

        #region PROPERTIES
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
        /// Gives and receaves the value of the variable
        /// </summary>
        /// <value></value>
        public override string Address
        {
            get => address;
            set => address = value;
        }
        /// <summary>
        /// Gives and receaves the value of the variable
        /// </summary>
        /// <value></value>
        public int Priority
        {
            get => priority;
            set => priority = value;
        }

        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// Creates an object of the class
        /// </summary>
        public Patient()
        {
            this.name = "";
            this.birthDate = DateTime.ParseExact("01/01/0001", "d/M/yyyy", CultureInfo.InvariantCulture);
            this.cc = "";
            this.address = "";
        }
        /// <summary>
        /// Create a new Persons
        /// </summary>
        /// <param name="name"></param>
        /// <param name="birthDate"></param>
        /// <param name="cc"></param>
        /// <param name="morada"></param>
        public Patient(string name, DateTime birthDate, string cc, string morada)
        {
            this.name = name;
            this.birthDate = birthDate;
            this.cc = cc;
            this.address = morada;
        }


        #endregion

        #region Operators
        /// <summary>
        /// Creates an equals of the object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Patient aux = (Patient)obj;
            return (String.Compare(this.cc, aux.cc) == 0);
        }

        public override int GetHashCode() { return 0; }
        /// <summary>
        /// Creates an == of the object
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Patient p1, Patient p2)
        {
            return (p1.Equals(p2));
        }
        /// <summary>
        /// Creates an != of the object
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Patient p1, Patient p2)
        {
            return (!(p1.Equals(p2)));
        }

        #endregion
    }
}