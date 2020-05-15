using System;
using System.Net.NetworkInformation;

namespace HospitalER
{
    [Serializable]
    public abstract class Person
    {
        #region ATTRIBUTES
        
        protected string name;
        protected string birthDate;
        protected string cc;
        protected string address;
        
        #endregion

        #region PROPERTIES

        public abstract string Name
        {
            get;
            set;
        }

        public abstract string BirthDate
        {
            get;
            set;
        }

        public abstract string CC
        {
            get;
            set;
        }

        public abstract string Address
        {
            get;
            set;
        }

        #endregion
        
        #region METHODS
        
        

        #endregion
    }
}