using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

namespace HospitalER
{
    [Serializable]
    public class Doctor : Person
    {
        #region ATTRIBUTES
        
        [NonSerialized]
        private int idDoctor;
        
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
        public override string Name
        {
            get => name;
            set => name = value;
        }
        /// <summary>
        /// Gives and receaves the value of the variable
        /// </summary>
        /// <value></value>
        public override string BirthDate
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
            this.address = "";
            this.operational = true;
        }
        /// <summary>
        /// Create a new Doctor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="birthDate"></param>
        /// <param name="cc"></param>
        public Doctor(string name, string birthDate, string cc, string address)
        {
            this.idDoctor++;
            this.name = name;
            this.birthDate = "";
            this.cc = cc;
            this.address = address;
        }

        #endregion
        
        
        public static bool EditDoctorFile(string path, string name, string address)
        {
            var p = new Doctor();
            try
            { 
                p = Directories.ReadPersonFromFile<Doctor>(path);
            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message + "Could not read Doctor file");
                return false;
            }

            if (p.CC.Length > 2)
            {
                try
                {
                    if(name != "")
                        p.Name = name;
                    if (address != "") ;
                    p.Address = address;
                        
                    if (Patient.RewritePersonFile<Doctor>(path, p))
                    {
                        return true;
                    }
                    return false;
                }
                catch(IOException e)
                {
                    Console.WriteLine(e.Message + "Could not write to file");
                }
            }
            return false;
        }

        public static bool ChangeOperationalStatus(string path, bool newStatus)
        {
            var p = new Doctor();
           
            try
            {
                p = Directories.ReadPersonFromFile<Doctor>(path);
            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message + "\nCould not read file.");
                return false;
            }
           
            if (p.Operational == newStatus)
            {
                Console.WriteLine("This doctor operational status is already set to {0}.", newStatus.ToString());
                return false;
            }
            
            p.Operational = newStatus;

            if (!Patient.RewritePersonFile<Doctor>(path, p))
            {
                return false;
            }
            return true;
        }
        
        #endregion



    }
}