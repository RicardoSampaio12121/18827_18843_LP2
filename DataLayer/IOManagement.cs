/* ---------------------------------------------------------------------
 * Resume: Contains all the methods to read and write to files, be it 
 * text or binary.
 * Author: Ricardo Sampaio
 * Author: Cláudio Silva
 *---------------------------------------------------------------------*/

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Exceptions;
using System.Collections.Generic;
using HospitalBO;

namespace DataLayer
{
    /// <summary>
    /// This class handles everything that has to do with folder and files
    /// </summary>
    public class IOManagement
    {

        /// <summary>
        /// Creates a folder given a path
        /// </summary>
        /// <param name="path"></param>
        public static void CreateFolder(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch(IOException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Writes a file with the given data
        /// </summary>
        /// <param name="path"></param>
        /// <param name="p"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool WriteNewPerson<T>(string path, T p)
        {
            var bfw = new BinaryFormatter();
            FileStream fs;

            if (File.Exists(path)) return false;

            try
            {
                fs = new FileStream(path, FileMode.Create);
            }
            catch
            {
                throw new OpenFileException("could not open file");
            }

            try
            {
                bfw.Serialize(fs, p);
                return true;
            }
            catch
            {
                throw new WriteFileException("could not write to file");
            }
            finally
            {
                fs.Close();
            }
        }

        /// <summary>
        /// Reads a person from a file and returns the person
        /// </summary>
        /// <param name="path"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T ReadPersonFromFile<T>(string path)
        {
            var d = default(T);
            var b = new BinaryFormatter();
            Stream s;
            try
            {
                s = File.Open(path, FileMode.Open, FileAccess.Read);
            }
            catch
            {
                throw new OpenFileException("There is no doctor associated with that ID.");
            }

            try
            {
                d = (T)b.Deserialize(s);
                s.Close();
                return d;
            }
            catch 
            {
                s.Close();
                throw new ReadFileException("Could not read file.");
            }
        }

        /// <summary>
        /// Checks if a file exists
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool CheckIfFileExists(string path)
        {
            if (File.Exists(path)) return true;
            return false;
        }

        /// <summary>
        /// Erases a file and rewrites all the data with a given an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="p"></param>
        public static void ReWriteFile<T>(string path, T p)
        {
            var bfw = new BinaryFormatter();
            FileStream fs;

            try
            {
                fs = new FileStream(path, FileMode.Open);
            }
            catch 
            {
                throw new OpenFileException("could not open file.");
            }

            try
            {
                fs.SetLength(0);
                fs.Flush();
                bfw.Serialize(fs, p);
                fs.Close();
            }
            catch
            {
                fs.Close();
                throw new WriteFileException("could not write to file.");
            }
        }

        /// <summary>
        /// Gets all the objects in a directory
        /// Returns a list with the objects
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<T> ListOfObjectsFromFile<T>(string path)
        {
            int i = 1;
            var aux = new List<T>();

            foreach (var file in Directory.EnumerateFiles(path, "*"))
            {
                try
                {
                    aux.Add(ReadPersonFromFile<T>(file));
                }
                catch(OpenFileException eo)
                {
                    throw eo;
                }
                catch (ReadFileException er)
                {
                    throw er;
                }
                i++;
            }
            return aux;
        }

        /// <summary>
        /// Checks if there is no file with the given cc
        /// </summary>
        /// <param name="path"></param>
        /// <param name="cc"></param>
        /// <returns></returns>
        public static bool FindCCInFiles(string path, string cc)
        {
            Doctor d;
            foreach (var file in Directory.EnumerateFiles(path, "*"))
            {
                try
                {
                    d = ReadPersonFromFile<Doctor>(file);
                }
                catch (OpenFileException eo)
                {
                    throw eo;
                }
                catch (ReadFileException er)
                {
                    throw er;
                }

                if (d.CC == cc) return true;
            }
            return false;
        }

        /// <summary>
        /// Returns the number of files in a given directory
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static int CountNumberOfFiles(string path)
        {
            int i = 0;
            foreach (var file in Directory.EnumerateFiles(path, "*"))
            {
                i++;
            }
            return i;
        }

        /// <summary>
        /// Returns a list of all hired or former doctors, depending on the bool passing by argument
        /// </summary>
        /// <param name="path"></param>
        /// <param name="hired"></param>
        /// <returns></returns>
        public static List<Doctor> GetFormerCurrentDoctors(string path, bool hired)
        {
            List<Doctor> lst = new List<Doctor>();

            Doctor d;
            foreach (var file in Directory.EnumerateFiles(path, "*"))
            {
                try
                {
                    d = ReadPersonFromFile<Doctor>(file);
                }
                catch (OpenFileException eo)
                {
                    throw eo;
                }
                catch (ReadFileException er)
                {
                    throw er;
                }

                if (hired && d.Operational)
                {
                    lst.Add(d);
                }
                else if (!hired && !d.Operational)
                {
                    lst.Add(d);
                }
            }

            return lst;
        }

        /// <summary>
        /// Returns a list of all former and currunt doctors
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<Doctor> GetAllDoctors(string path)
        {
            Doctor d;
            List<Doctor> aux = new List<Doctor>();
            foreach (var file in Directory.EnumerateFiles(path, "*"))
            {
                try
                {
                    d = ReadPersonFromFile<Doctor>(file);
                    aux.Add(d);
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
            return aux;
        }

        /// <summary>
        /// Write if a patient enters or leaves the hospital in a text file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="time"></param>
        /// <param name="state"></param>
        public static void AppendPatientRecord(string path, DateTime time, bool state)
        {
            if (state)
                File.AppendAllText(path ,"IN: ");
            else
                File.AppendAllText(path ,"OUT: ");

            File.AppendAllText(path, time.ToString() + "\n");
        }
        
    }
}