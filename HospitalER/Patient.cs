using System;
using System.Buffers;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace HospitalER
{
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

        #region METHODS
        
        #region CONSTRUCTOR
        /// <summary>
        /// Creates an object of the class
        /// </summary>
        public Patient()
        {
            this.name = "";
            this.birthDate = "";
            this.cc = "";
            this.address = "";
        }
        /// <summary>
        /// Create a new Patient
        /// </summary>
        /// <param name="name"></param>
        /// <param name="birthDate"></param>
        /// <param name="cc"></param>
        /// <param name="morada"></param>
        public Patient(string name, string birthDate, string cc, string morada)
        {
            this.name = name;
            this.birthDate = birthDate;
            this.cc = cc;
            this.address = morada;
        }


        #endregion

        /// <summary>
        /// Give Priority to a patient
        /// </summary>
        /// <param name="p"></param>
        /// <param name="patientPriority"></param>
        /// <returns></returns>
        public static Patient GivePriority(Patient p, int patientPriority)
        {
            p.Priority = patientPriority;
            return p;
        }

        /*public static bool PatientFileExists(string path)
        {
            try
            {
                var fs = new FileStream(path, FileMode.Open);
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }*/

        public static bool RewritePersonFile<T>(string path, T p)
        {
            var bfw = new BinaryFormatter();
            FileStream fs;

            try
            {
                fs = new FileStream(path, FileMode.Open);
                fs.SetLength(0);
                fs.Flush(); 
                bfw.Serialize(fs, p);
                fs.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "Could not rewrite file.");
                return false;
            }

            return true;
        }
        
        public static bool WriteNewPatientFile(string path, Patient p)
        {
            //var bw = new BinaryWriter(new FileStream("Patients/" + p.cc + ".bin", FileMode.Create));;
            var bfw = new BinaryFormatter();
            FileStream fs;
            if (!File.Exists(path + p.cc + ".bin"));
            {
                try
                {
                    fs = new FileStream(path + p.cc + ".bin", FileMode.Create);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message + "\nCan't open file");
                    return false;
                }
                
                try 
                { 
                    bfw.Serialize(fs, p); 
                    fs.Close(); 
                    return true;
                }
                catch (IOException e) 
                { 
                    Console.WriteLine(e.Message + "\nCan't write to file"); 
                    fs.Close();
                    return false;
                }
            }
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