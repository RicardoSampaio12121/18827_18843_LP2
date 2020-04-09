using System;

namespace LP2_TP1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Patient[] patient = new Patient[500];
            Patient novo;

            while (true)
            {
                Console.Clear();
                Menu();
                char decisao = char.Parse(Console.ReadLine());

                switch (decisao)
                {
                    case 'A': //Add a new patient to the queue
                        
                        novo = new Patient(); //Initializes the object variable

                        //Collects the needed data and adds stores it to the object variable
                        Console.Write("Name (First and Last): ");
                        novo.Name = Console.ReadLine();
                        Console.Write("Age: ");
                        novo.Age = int.Parse(Console.ReadLine());
                        Console.Write("CC: ");
                        novo.CC = Console.ReadLine();
                        Console.Write("Priority: ");
                        novo.Priority = int.Parse(Console.ReadLine());

                        patient[Patients.NPatients()] = novo; //Inserts the new object in an array of the same object

                        //Verifies if the CC hasn't been to the screening before
                        bool patientAdded = Patients.AddToQueue(patient[Patients.NPatients()]);
                        if (!patientAdded) Console.WriteLine("Patient has already been to the screening");

                        System.Threading.Thread.Sleep(2000);

                        break;


                    case 'B':
                        
                        Patients.ListPatientsQueue();
                        Console.ReadKey();

                        break;

                    case 'C':
                        Environment.Exit(0);
                        break;
                }
            }


        }

        static void Menu()
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("|       Emergency Room of HOSPITAL S.JOAO DA POEIRA       |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("| A) Add Patient                                          |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| B) Waiting Queue                                        |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| C) Leave Program                                        |");
            Console.WriteLine("-----------------------------------------------------------");
        }

    }
}