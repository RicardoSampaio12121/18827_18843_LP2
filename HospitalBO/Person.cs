/* ---------------------------------------------------------------------
 * Resume: Contains an abstract class of a person, it's used both by
 * the class Patient and the class Doctor
 * Author: Ricardo Sampaio
 * Author: Cláudio Silva
 *---------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalBO
{
    /// <summary>
    /// Abstract class of a Person, can be used by both Doctor and Patient
    /// </summary>
    [Serializable]
    public abstract class Person
    {
        #region ATTRIBUTES

        protected string name;
        protected DateTime birthDate;
        protected string cc;
        protected string address;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets and sets a value for name
        /// </summary>
        public abstract string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets and sets a value for BirthDate
        /// </summary>
        public abstract DateTime BirthDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets and sets a value for CC
        /// </summary>
        public abstract string CC
        {
            get;
            set;
        }

        /// <summary>
        /// Gets and sets a value for Address
        /// </summary>
        public abstract string Address
        {
            get;
            set;
        }

        #endregion   
    }
}