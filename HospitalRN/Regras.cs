using System;
using Exceptions;
using System.Collections.Generic;
using DataLayer;
using HospitalBO;
using System.IO;

namespace HospitalRN
{
    /// <summary>
    /// Intermediate between DataLayer and HospitalRN
    /// </summary>
    public class Regras
    {
        //Directories paths
        const string PATIENT_INFO = @"C:\Users\ricar\source\repos\18827_18843_LP2\DataLayer\PatientsInfo\";
        const string PATIENT_RECORD = @"C:\Users\ricar\source\repos\18827_18843_LP2\DataLayer\PatientsRecord\";
        const string DOCTOR_INFO = @"C:\Users\ricar\source\repos\18827_18843_LP2\DataLayer\DoctorsInfo\";

        public static void CreateCustomDirectory(string path)
        {
            try
            {
                IOManagement.CreateFolder(path);
            }
            catch(IOException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Calls function to create a file for an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool SavePersonFile<T>(string path, string name, T p)
        {
            try
            {
                if (!IOManagement.WriteNewPerson<T>(path + name + ".bin", p)) return false;
                return true;
            }
            catch (OpenFileException eo)
            {
                throw eo;
            }
            catch (WriteFileException ew)
            {
                throw ew;
            }
        }

        /// <summary>
        /// Calls function to get the information of a person in a file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T GetPersonInfo<T>(string path, string name)
        {
            try
            {
                return IOManagement.ReadPersonFromFile<T>(path + name + ".bin");
            }
            catch (OpenFileException ef)
            {
                throw ef;
            }
            catch (ReadFileException er)
            {
                throw er;
            }
        }

        /// <summary>
        /// Calls function to send a patient to the screening queue
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool SendPatientToScreeningQueue(Patient p)
        {
            return Screening.AddToQueue(p);
        }

        /// <summary>
        /// Calls a function to check if a file exists given a path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool VisitFile(string path, string name)
        {
            if (IOManagement.CheckIfFileExists(path + name + ".bin")) return true;
            return false;
        }

        /// <summary>
        /// Calls a function to read a patient from a file given the ID
        /// Edits the name or the address or both in the object
        /// Calls a function to rewrite the file with the object
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public static void EditPatientFile(string fName, string name, string address)
        {
            var p = new Patient();
            try
            {
                p = IOManagement.ReadPersonFromFile<Patient>(PATIENT_INFO + fName + ".bin");
            }
            catch (ReadFileException er)
            {
                throw er;
            }

            if (name != "")
                p.Name = name;
            if (address != "")
                p.Address = address;

            try
            {
                IOManagement.ReWriteFile(PATIENT_INFO + fName + ".bin", p);
            }
            catch (OpenFileException eo)
            {
                throw eo;
            }
            catch (WriteFileException ew)
            {
                throw ew;
            }
        }

        /// <summary>
        /// Calls a function to get a list of all registered patients
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<T> GetList<T>(string path)
        {
            try
            {
                var aux = new List<T>();
                aux = IOManagement.ListOfObjectsFromFile<T>(path);
                return aux;
            }
            catch (OpenFileException eo)
            {
                throw eo;
            }
            catch (ReadFileException er)
            {
                throw er;
            }
        }

        /// <summary>
        /// Calls a function to read a doctor from a file with his ID
        /// Adds that person to the doctorsWorking list
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool DoctorClockIn(int ID)
        {
            Doctor d;
            try
            {
                d = IOManagement.ReadPersonFromFile<Doctor>(DOCTOR_INFO + ID.ToString() + ".bin");
            }
            catch (OpenFileException e)
            {
                throw e;
            }
            if (!d.Operational)
            {
                throw new NotOperationalException("doctor is not operational.");
            }

            if (!Doctors.AddToWorkingDoctors(d))
            {
                return false;
            }
            return true;

        }

        /// <summary>
        /// Calls a function to remove a doctor from the doctorsWorking list
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool DoctorClockOut(int ID)
        {
            if (!Doctors.RemoveFromWorkingDoctorsByID(ID))
                return false;
            return true;
        }

        /// <summary>
        /// Calls a function to check if there is no doctor with the same cc
        /// </summary>
        /// <param name="cc"></param>
        /// <returns></returns>
        public static bool CreateDoctorCCValitation(string cc)
        {
            try
            {
                if (IOManagement.FindCCInFiles(DOCTOR_INFO, cc))
                {
                    return true;
                }
                return false;
            }
            catch (OpenFileException eo)
            {
                throw eo;
            }
            catch (ReadFileException er)
            {
                throw er;
            }
        }

        /// <summary>
        /// Calls a function to get the next id
        /// </summary>
        /// <returns></returns>
        public static int GetNewDoctorID()
        {
            return IOManagement.CountNumberOfFiles(DOCTOR_INFO) + 1;
        }

        /// <summary>
        /// Edit a doctor file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="FName"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        public static void EditDoctorFile(string FName, string name, string address)
        {
            var p = new Doctor();
            try
            {
                p = IOManagement.ReadPersonFromFile<Doctor>(DOCTOR_INFO + FName + ".bin");
            }
            catch(OpenFileException eo)
            {
                throw eo;
            }
            catch (ReadFileException er)
            {
                throw er;
            }

            if (name != "")
                p.Name = name;
            if (address != "")
                p.Address = address;

            try
            {
                IOManagement.ReWriteFile(DOCTOR_INFO + FName + ".bin", p);
            }
            catch (OpenFileException eo)
            {
                throw eo;
            }
            catch (WriteFileException ew)
            {
                throw ew;
            }
        }

        /// <summary>
        /// Change doctor operational status
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool ChangeDoctorStatus(string id)
        {   
            Doctor d;
            try
            {
                d = IOManagement.ReadPersonFromFile<Doctor>(DOCTOR_INFO + id + ".bin");
                if (d.Operational)
                    d.Operational = false;
                else
                    d.Operational = true;
            }
            catch (OpenFileException eo)
            {
                throw eo;
            }
            catch (ReadFileException er)
            {
                throw er;
            }

            if (Doctors.VerifyIfRepeated(d.IdDoctor))
            {
                throw new ReturnException("Can not change doctor status while at work");
            }

            try
            {
                IOManagement.ReWriteFile<Doctor>(DOCTOR_INFO + id + ".bin", d);
                return d.Operational;
            }
            catch (OpenFileException eo)
            {
                throw eo;
            }
            catch (WriteFileException ew)
            {
                throw ew;
            }

        }

        /// <summary>
        /// Calls a function to get a copy of the workingDoctors list
        /// </summary>
        /// <returns></returns>
        public static List<Doctor> GetDoctorsWorkingList()
        {
            return Doctors.ReturnCopiedList();
        }

        /// <summary>
        /// Calls a function to get a list of all the former or not doctors in this hospital
        /// </summary>
        /// <returns></returns>
        public static List<Doctor> GetHiredFormerDoctorsList(bool operational)
        {
            try
            {
                return IOManagement.GetFormerCurrentDoctors(DOCTOR_INFO, operational);
            }
            catch (OpenFileException eo)
            {
                throw eo;
            }
            catch (ReadFileException er)
            {
                throw er;
            }
        }

        /// <summary>
        /// Calls a function to get a list of all doctors
        /// </summary>
        /// <returns></returns>
        public static List<Doctor> GetAllDoctorsList()
        {

            try
            {
                List<Doctor> aux;
                aux = IOManagement.GetAllDoctors(DOCTOR_INFO);
                return aux;
            }
            catch (OpenFileException eo)
            {
                throw eo;
            }
            catch (ReadFileException er)
            {
                throw er;
            }
        }

        /// <summary>
        /// Calls function to return the next patient in the screening queue without removing him
        /// </summary>
        /// <returns></returns>
        public static Patient CallPatientToScreening()
        {
            return Screening.PeekNextPatient();
        }

        /// <summary>
        /// Calls function to add patient to the urgency queue
        /// </summary>
        /// <param name="p"></param>
        public static void AddPatientToUrgencyQueue(Patient p)
        {
            Urgency.AddToUrgencyQueue(p);
        }

        /// <summary>
        /// Removes the next patient in the screening queue
        /// </summary>
        public static void RemovePatientScreeningQueue(Patient p)
        {
            Screening.RemoveNextPatient();
        }

        /// <summary>
        /// Calls a function to return o copy of the screening queue
        /// </summary>
        /// <returns></returns>
        public static Queue<Patient> GetScreeningQueueCopy()
        {
            return Screening.ReturnCopyQueue();
        }

        /// <summary>
        /// Calls a function to check if a doctor is at work
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool CheckIfDoctorWorking(int id)
        {
            if (Doctors.VerifyIfRepeated(id))
                return true;
            return false;
        }

        /// <summary>
        /// Calls a function to return a copu of the urgency queue
        /// </summary>
        /// <returns></returns>
        public static SortedList<int, Patient> GetCopyUrgencyQueue()
        {
            return Urgency.ReturnCopyUrgencyQueue();
        }

        /// <summary>
        /// Calls a function to return the next patient in urgency queue
        /// </summary>
        /// <returns></returns>
        public static Patient GetNextPatientUrgencyQueue()
        {
            return Urgency.ReturnNextPatient();
        }

        /// <summary>
        /// Checks if the screening queue has patients
        /// </summary>
        /// <returns></returns>
        public static bool ScreeningHasPatients()
        {
            return Screening.HasPatients();
        }

        /// <summary>
        /// Calls a function to check if the urgency queue has patients
        /// </summary>
        /// <returns></returns>
        public static bool UrgencyHasPatients()
        {
            return Urgency.NotEmpty();
        }

        /// <summary>
        /// Calls a function to append the date when a patient enters or leaves the hospital
        /// </summary>
        /// <param name="cc"></param>
        /// <param name="time"></param>
        /// <param name="state"></param>
        public static void SaveRecord(string cc, DateTime time, bool state)
        {   
                IOManagement.AppendPatientRecord(PATIENT_RECORD + cc + ".txt", time, state);
        }
        
    }
}