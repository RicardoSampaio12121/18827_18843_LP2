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
                    case 'A':

                        Console.Write("Name (First and Last): ");
                        string nome = Console.ReadLine();
                        Console.Write("Age: ");
                        int idade = int.Parse(Console.ReadLine());
                        Console.Write("CC: ");
                        string cc = Console.ReadLine();
                        Console.Write("Priority: ");
                        int prioridade = int.Parse(Console.ReadLine());

                        novo = new Patient(nome, idade, cc, prioridade);
                        patient[Patients.NPatients()] = novo;

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