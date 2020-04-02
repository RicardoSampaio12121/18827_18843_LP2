using System;

namespace LP2_TP1
{
    class Program
    {
        static void Main(string[] args)
        {
            Patient novo  = new Patient("Ricardo", 19, "303387971zy9", 1);
            Patient novo2 = new Patient("Claudio", 12, "303387971zy9", 2);
            bool teste;
            Console.WriteLine("Name: "+ novo.Name);
            Console.WriteLine("Age: "+ novo.Age);
            Console.WriteLine("CC: "+ novo.CC);
            Console.WriteLine("Priority: "+ novo.Priority);


            
            /*teste = Patients.AddToQueue(novo);
            
            if(teste) Console.WriteLine("tru2");

            teste = Patients.AddToQueue(novo2);
            
            if(teste) Console.WriteLine("tru2");*/
            
        }
    }
}