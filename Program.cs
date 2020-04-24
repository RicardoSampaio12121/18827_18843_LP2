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
                bool ver1 = char.TryParse(Console.ReadLine(), out decisao); //Colect menu option

                if (ver1) //if user selected a valid option from the menu
                {
                    switch (decisao)
                    {
                        case 'a':
                        case 'A': //Add a new patient to the queue

                            while (decisao != 'D' && decisao != 'd') //while "decisao" != 'd' or 'D', stays in the menu "Patients"
                            {
                                Console.Clear();
                                MenuPatients();
                                bool ver2 = char.TryParse(Console.ReadLine(), out decisao);

                                switch (decisao)
                                {
                                    case 'a':
                                    case 'A':
                                        //Add patient to the Screening queue
                                        Console.Write("CC: ");
                                        string cc = Console.ReadLine();

                                        if (cc.Length != 12) Console.WriteLine("Invalid CC."); //check if CC has a valid format
                                        else
                                        {
                                            if (!Patients.VerifyCC(cc)) //if this patient doesn't already have a File, create one
                                            {
                                                novo = new Patient();

                                                //Collects the needed data and adds stores it to the object variable
                                                Console.Write("Name (First and Last): ");
                                                novo.Name = Console.ReadLine();
                                                if (!CheckIfTTwoNames(novo.Name)) //checks if name has a valid format
                                                {
                                                    Console.WriteLine("Invalid name.\nPress any key to continue...");
                                                    Console.ReadLine();
                                                    break;
                                                }
                                                Console.Write("Birth Date (DD-MM-YYYY) or (DD/MM/YYYY): ");
                                                novo.BirthDate = Console.ReadLine();
                                                if (!CheckIfValidBirthDate(novo.BirthDate)) //checks if Birth date has a valid format
                                                {
                                                    Console.WriteLine("Invalid birth date.\nPress any key to continue...");
                                                    Console.ReadLine();
                                                    break;
                                                }
                                                novo.CC = cc;
                                                Console.Write("Address: ");
                                                novo.Adress = Console.ReadLine();
                                                Patients.AddToFile(novo);
                                                //Verifies if the CC hasn't been to the screening before
                                            }
                                            else novo = Patients.GetPatientByCC(cc); //if this patient has already a file search and get his information

                                            if (Screening.AddToScreening(novo)) //checks if the patient isn't already in the queue for screening
                                                Console.WriteLine("Patient has been added to the screening queue.");
                                            else
                                                Console.WriteLine("Patient is already in the sceening queue");

                                        }
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;

                                    case 'b':
                                    case 'B':
                                        //Edit patient informations
                                        Console.Write("CC: ");
                                        cc = Console.ReadLine();

                                        if (cc.Length < 12) Console.WriteLine("Invalid CC.\nPress any key to continue..."); //checks if CC have a valid format
                                        else
                                        {
                                            //Collects the needed data to edit
                                            Console.WriteLine("<A>Editar nome");
                                            Console.WriteLine("<B>Editar morada");
                                            Console.WriteLine("<C>Editar nome e morada");
                                            bool ver3 = char.TryParse(Console.ReadLine(), out decisao); //if user selected a valid option from the menu

                                            if (ver3)
                                            {
                                                if (decisao == 'a' || decisao == 'A')
                                                {
                                                    Console.Write("Novo nome: ");
                                                    string newName = Console.ReadLine();

                                                    if (!CheckIfTTwoNames(newName))
                                                    {
                                                        Console.WriteLine("Invalid name.\nPress any key to continue...");
                                                        Console.ReadKey();
                                                        break;
                                                    }

                                                    if (!Patients.EditFileName(cc, newName))
                                                    {
                                                        Console.WriteLine("CC not found.\nPress any key to continue...");
                                                        Console.ReadKey();
                                                        break;
                                                    }
                                                    Console.WriteLine("Name sucessfully changes.\nPress any key to continue...");
                                                }
                                                else if (decisao == 'b' || decisao == 'B')
                                                {
                                                    Console.Write("Nova morada: ");
                                                    string newAddress = Console.ReadLine();

                                                    if (!Patients.EditFileAddress(cc, newAddress))
                                                    {
                                                        Console.WriteLine("CC not found.\nPress any key to continue...");
                                                        Console.ReadKey();
                                                        break;
                                                    }
                                                    Console.WriteLine("Address changes sucessfully.\nPress any key to continue...");
                                                }
                                                else if (decisao == 'c' || decisao == 'C')
                                                {
                                                    Console.Write("Novo nome: ");
                                                    string newName = Console.ReadLine();
                                                    if (!CheckIfTTwoNames(newName))
                                                    {
                                                        Console.WriteLine("Invalid name.\nPress any key to continue...");
                                                        Console.ReadKey();
                                                        break;
                                                    }
                                                    Console.Write("Nova morada: ");
                                                    string newAddress = Console.ReadLine();

                                                    if (!Patients.EditFileNameAddress(cc, newName, newAddress))
                                                    {
                                                        Console.WriteLine("CC not found.\nPress any key to continue...");
                                                        Console.ReadKey();
                                                        break;
                                                    }
                                                    Console.WriteLine("Sucessful.\nPress any key to continue...");
                                                }
                                                else Console.WriteLine("Invalid option.\nPress any key to continue...");
                                            }
                                            else //if user selected an invalid option from the menu
                                            {
                                                Console.WriteLine("There was an error trying to choose the menu.\nPress any key to continue...");
                                            }
                                        }

                                        Console.ReadKey();

                                        break;

                                    case 'c':
                                    case 'C':
                                        Patients.ListPatientsFile(); //list all patients file
                                        Console.WriteLine("Press any key to continue...");
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

                            while (decisao != 'E' && decisao != 'e') //while "decisao" != 'e' or 'E', stays in the menu "Doctors"
                            {
                                Console.Clear();
                                MenuDoctors();
                                bool ver4 = char.TryParse(Console.ReadLine(), out decisao);

                                if (ver4) //if user selected a valid option from the menu
                                {

                                    switch (decisao)
                                    {
                                        case 'a':
                                        case 'A':
                                            //create new doctor
                                            novo2 = new Doctor();

                                            //Collects the needed data and stores it to the object variable
                                            Console.Write("Name (First and Last): ");
                                            novo2.Name = Console.ReadLine();
                                            if (!CheckIfTTwoNames(novo2.Name)) //checks if name has a valid format
                                            {
                                                Console.WriteLine("Invalide first and last name.\n Press any key to continue...");
                                                Console.ReadKey();
                                                break;
                                            }
                                            Console.Write("CC: ");
                                            novo2.CC = Console.ReadLine();
                                            if (novo2.CC.Length < 12) //checks if CC has a valid format
                                            {
                                                Console.WriteLine("Invalid cc.\nPress any key to continue...");
                                                Console.ReadKey();
                                                break;
                                            }
                                            Console.Write("Birth Date (DD-MM-YYYY) or (DD/MM/YYYY): ");
                                            novo2.BirthDate = Console.ReadLine();
                                            if (!CheckIfValidBirthDate(novo2.BirthDate)) //checks if Birth Date has a valid format
                                            {
                                                Console.WriteLine("Invalid birth date.\nPress any key to continue...");
                                                Console.ReadKey();
                                                break;
                                            }


                                            if (Doctors.AddToDoctors(novo2)) Console.WriteLine("Doctor has been added sucessfully.");  //checks if the doctor isn't already created
                                            else
                                                Console.WriteLine("There is a doctor with the same CC.");

                                            Console.ReadKey();

                                            break;

                                        case 'b':
                                        case 'B':
                                            //Edit doctor information
                                            Console.Write("ID: ");
                                            bool ver5 = int.TryParse(Console.ReadLine(), out int id); //checks if the inserted id exists

                                            if (!ver5)
                                            {
                                                Console.WriteLine("Invalid ID.\nPress any key to continue...");
                                                Console.ReadKey();
                                                break;
                                            }

                                            Console.WriteLine("New name(first and last): "); //checks if name has a valid format
                                            string newName = Console.ReadLine();
                                            if (!CheckIfTTwoNames(newName))
                                            {
                                                Console.WriteLine("Invalid name.\nPress any key to continue");
                                                Console.ReadKey();
                                                break;
                                            }

                                            if (Doctors.EditDoctorName(id, newName)) Console.WriteLine("Name sucessfully edited.");
                                            else Console.WriteLine("There was an error trying to edit the name, verify if the ID is correct");

                                            Console.ReadKey();
                                            break;

                                        case 'c':
                                        case 'C':

                                            //delete doctor
                                            Console.Write("ID: ");
                                            bool ver = int.TryParse(Console.ReadLine(), out id);

                                            if (!ver)
                                            {
                                                Console.WriteLine("Invalid ID.\nPress any key to continue...");
                                                Console.ReadKey();
                                                break;
                                            }

                                            if (Doctors.RemoveDoc(id)) Console.Write("Doctor sucessfully removed.");
                                            else Console.Write("There was an error trying to remove the doctor, please verify the ID");

                                            Console.ReadKey();
                                            break;


                                        case 'd':
                                        case 'D':
                                            //list all doctors
                                            Doctors.ListDoctors();
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;

                                    }
                                }
                                else //if user selected an invalid option from the menu
                                {
                                    Console.WriteLine("Invalid option.\nPress any key to continue...");
                                }
                            }



                            break;
                        case 'c':
                        case 'C':
                            decisao = ' ';
                            while (decisao != 'c' && decisao != 'C') //while "decisao" != 'c' or 'C', stays in the menu "Emergency Room"
                            {
                                Console.Clear();
                                MenuER();
                                bool ver7 = char.TryParse(Console.ReadLine(), out decisao); //cheks if user inserted a valid option from the menu

                                switch (decisao)
                                {
                                    case 'a':
                                    case 'A': //Secreening


                                        while (decisao != 'c' && decisao != 'C') //while "decisao" != 'c' or 'C', stays in the menu "Screening"
                                        {
                                            Console.Clear();
                                            MenuScreening();
                                            bool ver8 = char.TryParse(Console.ReadLine(), out decisao); //checks if user inserted a valid option from the menu

                                            if (!ver8)
                                            {
                                                Console.WriteLine("Invalid option.\nPress any key to continue...");
                                                Console.ReadKey();
                                                break;
                                            }
                                            switch (decisao)
                                            {
                                                case 'a':
                                                case 'A': //Call patient

                                                    Patient p = Screening.CallNextPatient();
                                                    Screening.ListCurrentPatient();
                                                    Console.Write("Patient priority: ");
                                                    bool ver = int.TryParse(Console.ReadLine(), out int patientPriority); //Checks Daif user inseted a valid priority for

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
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();

                                                    break;

                                                case 'c':
                                                case 'C'://Quit

                                                    break;
                                            }
                                        }
                                        break;

                                    case 'b':
                                    case 'B': //Urgency

                                        while (decisao != 'c' && decisao != 'C') //while "decisao" != 'c' or 'C', stays in the menu "Urgency"
                                        {
                                            Console.Clear();
                                            MenuUrgency();
                                            bool ver9 = char.TryParse(Console.ReadLine(), out decisao); //Checks if user inserted a valid option format
                                            if (!ver9)
                                            {
                                                Console.WriteLine("Invalid option.\nPress any key to continue...");
                                                Console.ReadKey();
                                                break;
                                            }

                                            switch (decisao)
                                            {
                                                case 'a':
                                                case 'A'://Call patient

                                                    Console.Write("Doctor ID: ");
                                                    bool verify = int.TryParse(Console.ReadLine(), out int docID);

                                                    if (verify)
                                                    {
                                                        if (Doctors.VerifyID(docID)) //Checks if user inserted a valid priority
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
                                        }

                                        break;

                                    case 'c':
                                    case 'C':
                                        break;
                                }
                            }
                            break;
                        case 'd':
                        case 'D':
                            Environment.Exit(0);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("There was an error trying to read the option.\nPress any key to continue...");
                    Console.ReadKey();
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


        /// <summary>
        /// Checks if the inserted name has a valid format
        /// </summary>
        /// <param name="names"></param>
        /// <returns></returns>
        static bool CheckIfTTwoNames(string names)
        {

            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] == ' ')
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if the inserted birth day has a valid format
        /// </summary>
        /// <param name="birthDate"></param>
        /// <returns></returns>
        static bool CheckIfValidBirthDate(string birthDate)
        {
            int i;
            if (birthDate.Length != 10)
            {
                return false;
            }

            bool ver = int.TryParse(birthDate[0].ToString(), out i);
            if (!ver) return false;
            ver = int.TryParse(birthDate[1].ToString(), out i);
            if (!ver) return false;
            if (birthDate[2] != '-' && birthDate[2] != '/') return false;
            ver = int.TryParse(birthDate[3].ToString(), out i);
            if (!ver) return false;
            ver = int.TryParse(birthDate[4].ToString(), out i);
            if (!ver) return false;
            if (birthDate[5] != '-' && birthDate[5] != '/') return false;
            ver = int.TryParse(birthDate[6].ToString(), out i);
            if (!ver) return false;
            ver = int.TryParse(birthDate[7].ToString(), out i);
            if (!ver) return false;
            ver = int.TryParse(birthDate[8].ToString(), out i);
            if (!ver) return false;
            ver = int.TryParse(birthDate[9].ToString(), out i);
            if (!ver) return false;

            return true;
        }

    }
}