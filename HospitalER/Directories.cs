using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HospitalER
{
    public class Directories
    {
        public static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message + "\nCan't create directory.");
                }
            }
        }

        public static T ReadPersonFromFile<T>(string path)
        {
            var d = default(T);
            var b = new BinaryFormatter();
            Stream s;
            try
            {
                s = File.Open(path, FileMode.Open, FileAccess.Read);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\nCan't open file.");
                return d;
            }

            try
            {
                d = (T)b.Deserialize(s);
                s.Close();
                return d;
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\nCan't read file");
                return d;
            }
        }

        public static bool WriteNewPerson<T>(string path, T p)
        {
            var bfw = new BinaryFormatter();
            FileStream fs;
            if (!File.Exists(path))
            {
                try
                {
                    fs = new FileStream(path, FileMode.Create);
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
            else
                return false;
            
            
        }

    }
}