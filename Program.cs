using System;

namespace LP2_TP1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Patient novo;
            Doctor novo2;
            char decisao;


            while (true)
            {
                Console.Clear();
                MainMenu();
                decisao = char.Parse(Console.ReadLine());

                switch (decisao)
                {

                    case 'a':
                    case 'A': //Add a new patient to the queue

                        while (decisao != 'D' && decisao != 'd')
                        {
                            MenuPatients();
                            decisao = char.Parse(Console.ReadLine());
                            switch (decisao)

                            {
                                case 'a':
                                case 'A':
                                    //Adiciona um paciente à lista de espera para a triagem
                                    Console.Write("CC: ");
                                    string cc = Console.ReadLine();

                                    if (!Patients.VerifyCC(cc))
                                    {
                                        novo = new Patient();

                                        //Collects the needed data and adds stores it to the object variable
                                        Console.Write("Name (First and Last): ");
                                        novo.Name = Console.ReadLine();
                                        Console.Write("Age: ");
                                        novo.BirthDate = Console.ReadLine();
                                        //Console.Write("CC: ");
                                        novo.CC = cc;
                                        Console.Write("Address: ");
                                        novo.Adress = Console.ReadLine();
                                        Patients.AddToFile(novo);
                                        //Verifies if the CC hasn't been to the screening before
                                    }
                                    else novo = Patients.GetPatientByCC(cc);

                                    if (Screening.AddToScreening(novo))
                                        Console.WriteLine("Patient has been added to the screening queue.");
                                    else
                                        Console.WriteLine("Patient is arleady in the sceening queue");
                                    Console.ReadKey();
                                    break;

                                case 'b':
                                case 'B':
                                    //edita as infos de um paciente
                                    Console.WriteLine("CC: ");
                                    cc = Console.ReadLine();

                                    Console.WriteLine("<A>Editar nome");
                                    Console.WriteLine("<B>Editar morada");
                                    Console.WriteLine("<C>Editar nome e morada");
                                    decisao = char.Parse(Console.ReadLine());

                                    if (decisao == 'a' || decisao == 'A')
                                    {
                                        Console.WriteLine("Novo nome: ");
                                        string newName = Console.ReadLine();

                                        Patients.EditFileName(cc, newName);
                                    }

                                    else if (decisao == 'b' || decisao == 'B')
                                    {
                                        Console.WriteLine("Nova morada: ");
                                        string newAddress = Console.ReadLine();

                                        Patients.EditFileAddress(cc, newAddress);
                                    }
                                    else if (decisao == 'c' || decisao == 'C')
                                    {
                                        Console.WriteLine("Novo nome: ");
                                        string newName = Console.ReadLine();
                                        Console.WriteLine("Nova morada: ");
                                        string newAddress = Console.ReadLine();

                                        Patients.EditFileNameAddress(cc, newName, newAddress);
                                    }

                                    Console.ReadKey();

                                    break;

                                case 'c':
                                case 'C':
                                    Patients.ListPatientsFile();
                                    Console.ReadKey();
                                    break;

                                case 'd':
                                case 'D':
                                    break;
                            }
                        }

                        break;

                    case 'b':
                    case 'B':

                        while (decisao != 'E' && decisao != 'e')
                        {
                            MenuDoctors();
                            decisao = char.Parse(Console.ReadLine());

                            switch (decisao)
                            {
                                case 'a':
                                case 'A':


                                    novo2 = new Doctor();

                                    //Collects the needed data and adds stores it to the object variable
                                    Console.Write("Name (First and Last): ");
                                    novo2.Name = Console.ReadLine();
                                    Console.Write("CC: ");
                                    novo2.CC = Console.ReadLine();
                                    Console.Write("BirthDate: ");
                                    novo2.BirthDate = Console.ReadLine();

                                    if (Doctors.AddToDoctors(novo2)) Console.WriteLine("Doctor has been added sucessfully.");
                                    else
                                        Console.WriteLine("There is a doctor with the same CC.");

                                    Console.ReadKey();

                                    break;

                                case 'b':
                                case 'B':
                                    Console.WriteLine("ID: ");
                                    int id = int.Parse(Console.ReadLine());

                                    Console.WriteLine("New name: ");
                                    string newName = Console.ReadLine();

                                    if (Doctors.EditDoctorName(id, newName)) Console.WriteLine("Name sucessfully edited.");
                                    else Console.WriteLine("There was an error trying to edit the name, verify if the ID is correct");

                                    Console.ReadKey();
                                    break;

                                case 'c':
                                case 'C':


                                    Console.WriteLine("ID: ");
                                    bool ver = int.TryParse(Console.ReadLine(), out id);

                                    if (ver)
                                    {
                                        if (Doctors.RemoveDoc(id)) Console.Write("Doctor sucessfully removed.");
                                        else Console.Write("There was an error trying to remove the doctor, please verify the ID");
                                    }
                                    Console.ReadKey();
                                    break;


                                case 'd':
                                case 'D':
                                    Doctors.ListDoctors();
                                    Console.ReadKey();
                                    break;

                            }
                        }



                        break;
                    case 'c':
                    case 'C':
                        decisao = ' ';
                        while (decisao != 'c' && decisao != 'C')
                        {

                            MenuER();
                            decisao = char.Parse(Console.ReadLine());

                            switch (decisao)
                            {
                                case 'a':
                                case 'A': //Secreening

                                    MenuScreening();
                                    decisao = char.Parse(Console.ReadLine());

                                    switch (decisao)
                                    {
                                        case 'a':
                                        case 'A': //Call patient

                                            Patient p = Screening.CallNextPatient();
                                            Screening.ListCurrentPatient();
                                            Console.Write("Patient priority: ");
                                            bool ver = int.TryParse(Console.ReadLine(), out int patientPriority);

                                            if (ver)
                                            {
                                                Screening.GivePriority(p, patientPriority);

                                                Screening.RemovePatientFromScreeningQueue();
                                                UrgencyQueue.AddToUrgency(p);

                                                Console.WriteLine("Patient added to the queue!");
                                            }
                                            else
                                                Console.WriteLine("There was an error trying to read the patient patient priority.");
                                            Console.ReadKey();
                                            break;

                                        case 'b':
                                        case 'B'://List queue

                                            Screening.ListPatientsInScreening();

                                            break;

                                        case 'c':
                                        case 'C'://Quit

                                            break;
                                    }
                                    break;

                                case 'b':
                                case 'B': //Urgency

                                    MenuUrgency();
                                    decisao = char.Parse(Console.ReadLine());

                                    switch (decisao)
                                    {
                                        case 'a':
                                        case 'A'://Call patient
                                            
                                            Console.WriteLine("Doctor ID: ");
                                            bool verify = int.TryParse(Console.ReadLine(), out int docID);

                                            if (verify)
                                            {
                                                if (Doctors.VerifyID(docID))
                                                {
                                                    Patient q = UrgencyQueue.CallNextPatient();

                                                    Console.WriteLine("Patient {0} has been called.", q.Name.ToString());
                                                    UrgencyQueue.ListCurrentPatient();
                                                    UrgencyQueue.RemovePatientUrgencyQueue();
                                                }
                                                else
                                                {
                                                    Console.WriteLine("There was a problem trying to verify the Doctor's ID.");
                                                }
                                            }
                                            else Console.WriteLine("There was a problem trying to read the Doctor's ID.");

                                            Console.ReadKey();
                                            break;

                                        case 'b':
                                        case 'B'://List patients

                                            UrgencyQueue.ListPatientsInUrgency();
                                            Console.ReadKey();
                                            break;

                                        case 'c':
                                        case 'C'://Exits
                                            break;
                                    }

                                    break;

                                case 'c':
                                case 'C':
                                    break;
                            }
                        }
                        break;
                }
            }
        }

        static void MainMenu()
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("|       Emergency Room of HOSPITAL S.JOAO DA POEIRA       |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("|                       MAIN MENU                         |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("| A) Patients                                             |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| B) Doctors                                              |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| C) Emergency Room                                       |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| D) Exit                                                 |");
            Console.WriteLine("-----------------------------------------------------------");
        }

        static void MenuPatients()
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("|       Emergency Room of HOSPITAL S.JOAO DA POEIRA       |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("|                     PATIENTS MENU                       |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("| A) Make file                                            |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| B) Edit                                                 |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| C) List all Patients                                    |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| D) Exit                                                 |");
            Console.WriteLine("-----------------------------------------------------------");
        }

        static void MenuDoctors()
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("|       Emergency Room of HOSPITAL S.JOAO DA POEIRA       |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("|                     DOCTORS MENU                        |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("| A) Add                                                  |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| B) Edit                                                 |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| C) Delete                                               |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| D) List all Doctors                                     |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("| E) Exit                                                 |");
            Console.WriteLine("-----------------------------------------------------------");
        }

        static void MenuER()
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("|       Emergency Room of HOSPITAL S.JOAO DA POEIRA       |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("|                 EMERGENCY ROOM MENU                     |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("| A) Screening                                            |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| B) Urgency                                              |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| C) Exit                                                 |");
            Console.WriteLine("-----------------------------------------------------------");

        }

        static void MenuScreening()
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("|       Emergency Room of HOSPITAL S.JOAO DA POEIRA       |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("|                   SCREENING  MENU                       |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("| A) Call Patient                                         |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| B) List Screening queue                                 |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| C) Exit                                                 |");
            Console.WriteLine("-----------------------------------------------------------");

        }

        static void MenuUrgency()
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("|       Emergency Room of HOSPITAL S.JOAO DA POEIRA       |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("|                      URGENCY  MENU                      |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("| A) Call Patient                                         |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| B) List Urgency queue                                   |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| C) Exit                                                 |");
            Console.WriteLine("-----------------------------------------------------------");

        }

    }
}