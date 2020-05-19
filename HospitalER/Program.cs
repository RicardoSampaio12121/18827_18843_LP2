using System;
using System.ComponentModel;
using System.IO;

namespace HospitalER
{
    class Program
    {
        static void Main()
        {
            Console.Clear();
            char decisao;

            //Directories paths
            const string PATIENT_INFO = "PatientsInfo/";
            const string PATIENT_RECORD = "PatientsRecord/";
            const string DOCTOR_INFO = "DoctorsInfo/";

            //Create essential directories if they don't already exist
            Directories.CreateDirectory(PATIENT_INFO);
            Directories.CreateDirectory(PATIENT_RECORD);
            Directories.CreateDirectory(DOCTOR_INFO);


            while (true)
            {
                Console.Clear();
                PrintMainMenu();//Prints the main menu to the screen

                if (char.TryParse(Console.ReadLine(), out decisao)) //Checks if the user chose a valid option
                {
                    switch (decisao)
                    {
                        case 'a':
                        case 'A': //Patients menu//

                            while (decisao != 'D' && decisao != 'd') //Stays in the menu while user says otherwise
                            {
                                Console.Clear();
                                PrintMenuPatients(); //Prints the Patients menu to the screen

                                //Checks if the user chose a valid option of the menu
                                if (!char.TryParse(Console.ReadLine(), out decisao))
                                {
                                    //if not, error message
                                    Console.WriteLine("Decision must be a character.");
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                    break;
                                }

                                switch (decisao)
                                {
                                    case 'a':
                                    case 'A': //Creates a patient file and add the patient to the screening queue

                                        Console.Write("CC: ");
                                        var cc = Console.ReadLine();//Gets the patient cc

                                        //Verifies if CC has the right number of digits
                                        if (cc.Length != 12)
                                        {
                                            //If not, error message
                                            Console.WriteLine("Invalid CC.\nPress any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }

                                        //Verifies if there is no patient with the same cc in the queue
                                        if (Screening.VerifyIfQueueContainsPatientByCC(cc))
                                        {
                                            //Error message if it has
                                            Console.WriteLine("There is a patient with the same cc in the queue.");
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }

                                        var newPatient = new Patient();
                                        if (!File.Exists(PATIENT_INFO + cc + ".bin"))//Checks if the patient has a file
                                        {
                                            newPatient.CC = cc;

                                            //Gets the patient name
                                            Console.Write("Name (First and Last): ");
                                            newPatient.Name = Console.ReadLine();

                                            //checks if name has a valid format
                                            if (!CheckIfTTwoNames(newPatient.Name))
                                            {
                                                Console.WriteLine("Invalid name.\nPress any key to continue...");
                                                Console.ReadKey();
                                                break;
                                            }

                                            //Gets patient birth date
                                            Console.Write("Birth Date (DD-MM-YYYY) or (DD/MM/YYYY): ");
                                            newPatient.BirthDate = Console.ReadLine();

                                            //checks if Birth date has a valid format
                                            if (!CheckIfValidBirthDate(newPatient.BirthDate))
                                            {
                                                Console.WriteLine("Invalid birth date.\nPress any key to continue...");
                                                Console.ReadKey();
                                                break;
                                            }

                                            //Gets new patient address
                                            Console.Write("Address: ");
                                            newPatient.Address = Console.ReadLine();

                                            //Creates a file for the patient
                                            if (!Directories.WriteNewPerson<Patient>(PATIENT_INFO + newPatient.CC + ".bin", newPatient))
                                            {
                                                //Throw error message
                                                Console.WriteLine("Press any key to continue...");
                                                Console.ReadKey();
                                                break;
                                            }
                                        }
                                        else //If the patient already has a file, get the info from it
                                            newPatient = Directories.ReadPersonFromFile<Patient>(PATIENT_INFO + cc + ".bin");

                                        //Checks if the patient was correctry read
                                        try
                                        {
                                            string auxCC = newPatient.CC;
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message + "Could not read the patient from file.");
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }

                                        //Adds patient to the queue
                                        if (!Screening.AddToScreening(newPatient))
                                        {
                                            Console.WriteLine("Press any key to continue");
                                            Console.ReadKey();
                                            break;
                                        }
                                        //Sucessfull message
                                        Console.WriteLine("Patient added to the queue!");
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    case 'b':
                                    case 'B'://Edit information form a patient file

                                        //Gets patient cc
                                        Console.Write("CC: ");
                                        cc = Console.ReadLine();

                                        //checks if CC has a valid format
                                        if (cc.Length < 12)
                                        {
                                            //If not, throw error message
                                            Console.WriteLine("Invalid CC.\nPress any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }

                                        //Checks if the patient has a file
                                        if (!File.Exists(PATIENT_INFO + cc + ".bin"))
                                        {
                                            //If there is not, error message
                                            Console.WriteLine("There is no file associated with that CC.");
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }

                                        //Prints the edit options to the screen 
                                        Console.WriteLine("<A>Edit name");
                                        Console.WriteLine("<B>Edit address");
                                        Console.WriteLine("<C>Edit name and address");
                                        Console.Write("Decision: ");

                                        string newName = "", newAddress = "";

                                        //Gets the user option and checks if it's valid
                                        if (!char.TryParse(Console.ReadLine(), out decisao))
                                        {
                                            //If not error message
                                            Console.WriteLine("Decision must b either a, b or c");
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }

                                        //If the user chooses to change name or name and address
                                        if (decisao == 'A' || decisao == 'a' || decisao == 'c' || decisao == 'C')
                                        {
                                            //Gets the new name
                                            Console.Write("New name: ");
                                            newName = Console.ReadLine();

                                            //Checks if the user inserted two or more names
                                            if (!CheckIfTTwoNames(newName))
                                            {
                                                //If he didn't, error message
                                                Console.WriteLine("Invalid name.\nPress any key to continue...");
                                                Console.ReadKey();
                                                break;
                                            }
                                        }

                                        //If the user chose to choose the address or name and address
                                        if (decisao == 'B' || decisao == 'b' || decisao == 'c' || decisao == 'C')
                                        {
                                            //Gets the user address
                                            Console.Write("New address: ");
                                            newAddress = Console.ReadLine();
                                        }

                                        //Edits the patient file
                                        if (!Patients.EditPatientFile(PATIENT_INFO + cc + ".bin", newName, newAddress))
                                        {
                                            //If something goes wrong, error message
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }

                                        //Sucessful message
                                        Console.WriteLine("Patient edited sucessfully.");
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    case 'c':
                                    case 'C'://List all patients//

                                        //Calls a method to list all the patients
                                        if (!Patients.ListPatientsFile(PATIENT_INFO))
                                            //If something goes wrong, error message
                                            Console.WriteLine("There was an error trying to read the patients files.");

                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey();
                                        break;
                                }
                            }
                            break;
                        case 'b':
                        case 'B'://Doctors menu//
                            //Stays in this menu while user doesn't say otherwise
                            while (decisao != 'E' && decisao != 'e')
                            {
                                Console.Clear();
                                PrintMenuDoctors(); //Prints the doctors menu to the screen

                                //Checks if the user selected a valid option of the menu
                                if (!char.TryParse(Console.ReadLine(), out decisao))
                                {
                                    //if not, error message
                                    Console.WriteLine("Decision must be a character.");
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                    break;
                                }

                                int id;
                                var d = new Doctor();
                                switch (decisao)
                                {
                                    case 'a':
                                    case 'A': //Doctor clock in

                                        //Gets doctor ID
                                        Console.Write("Enter ID: ");
                                        if (int.TryParse(Console.ReadLine(), out id))//Checks if id format is valid
                                        {
                                            //Reads the information associated with the ID from a file
                                            d = Directories.ReadPersonFromFile<Doctor>(DOCTOR_INFO + id + ".bin");

                                            //Checks if the information was read sucessfully
                                            try
                                            {
                                                d.IdDoctor = id;
                                            }
                                            catch
                                            {
                                                //If it wasn't, error message and break
                                                Console.WriteLine("There is no doctor matching that ID.");
                                                Console.WriteLine("Press any key to continue...");
                                                Console.ReadKey();
                                                break;
                                            }

                                            //Adds the doctor to a list, meaning that he is working
                                            if (Doctors.AddToDoctors(d)) Console.WriteLine("Sucessfully checked in.");
                                            else Console.WriteLine("This ID has already checked in.");
                                        }
                                        else
                                            //ID must be an integer, error message
                                            Console.WriteLine("Wrong ID format.");
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    case 'b':
                                    case 'B'://Clock out
                                             //Gets doctor ID
                                        Console.Write("Enter ID: ");
                                        if (int.TryParse(Console.ReadLine(), out id)) //Checks if id format is valid
                                        {
                                            //Attempts to clock out doctor
                                            if (!Doctors.ClockOut(id))
                                                //If there is no doctor at work with that ID, error message
                                                Console.WriteLine("There is no doctor with that ID working right now.");
                                            else
                                                Console.WriteLine("Doctor sucessfully checked out");
                                        }
                                        else
                                            //Error message if inserted a not integer value
                                            Console.WriteLine("Wrong ID format.");

                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    case 'c':
                                    case 'C'://Make doctor file/create doctor
                                        d = new Doctor();

                                        //Gets the cc of the doctor 
                                        Console.Write("CC: ");
                                        d.CC = Console.ReadLine();
                                        if (d.CC.Length < 12) //checks if CC has a valid format
                                        {
                                            //If not, error message
                                            Console.WriteLine("Invalid cc.\nPress any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }

                                        //Verifies if there is a doctor with the same cc associated
                                        if (Doctors.DoctorExistsByCC(DOCTOR_INFO, d.CC))
                                        {
                                            //if exists, error message
                                            Console.WriteLine("There is a doctor registered with the same cc.");
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }

                                        //Gets the name of the doctor
                                        Console.Write("Name (First and Last): ");
                                        d.Name = Console.ReadLine();
                                        if (!CheckIfTTwoNames(d.Name)) //checks if name has a valid format
                                        {
                                            //if not, error message
                                            Console.WriteLine("Invalid first and last name.\n Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }

                                        //Gets doctor's birthdate
                                        Console.Write("Birth Date (DD-MM-YYYY) or (DD/MM/YYYY): ");
                                        d.BirthDate = Console.ReadLine();
                                        if (!CheckIfValidBirthDate(d.BirthDate)) //checks if Birth Date has a valid format
                                        {
                                            //if not, error message
                                            Console.WriteLine("Invalid birth date.\nPress any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }
                                        //Gets the doctor's address
                                        Console.Write("Address: ");
                                        d.Address = Console.ReadLine();

                                        //Gets an ID for the new doctor
                                        var newID = Doctors.GetNewDoctorID();
                                        if (newID == 0)
                                        {
                                            //Error message if it's not possible to get the ID
                                            Console.WriteLine("There was and error trying to get the new ID");
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }

                                        //Writes a file with the doctor's information
                                        if (!Directories.WriteNewPerson<Doctor>(DOCTOR_INFO + newID.ToString() + ".bin", d))
                                        {
                                            //If something goes wrong, error message
                                            Console.WriteLine("There was an error trying to create a file");
                                            break;
                                        }

                                        Console.WriteLine("Doctor file created sucessfully\nPress any key to continue.");
                                        Console.ReadKey();
                                        break;

                                    case 'd':
                                    case 'D': //edit doctor information
                                        d = new Doctor();

                                        //Get doctor ID
                                        Console.WriteLine("ID: ");
                                        if (!int.TryParse(Console.ReadLine(), out var a)) //Verifys if it's int
                                        {
                                            //If the input is not an integer, error message
                                            Console.WriteLine("ID must be an integer value.");
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }

                                        //Checks if there is a file associated with that ID
                                        if (!File.Exists(DOCTOR_INFO + a + ".bin"))
                                        {
                                            //If file doesn't exist
                                            Console.WriteLine("There is no file associated with ID {0}.", a.ToString());
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }

                                        id = a;
                                        //Prints the edit options to the screen 
                                        Console.WriteLine("<A>Edit name");
                                        Console.WriteLine("<B>Edit address");
                                        Console.WriteLine("<C>Edit name and address");
                                        Console.Write("Decision: ");

                                        if (!char.TryParse(Console.ReadLine(), out decisao))
                                        {
                                            //Decision must be a character
                                            Console.WriteLine("Decision must be a character");
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }

                                        //Verifica se introduziu uma opção inválida
                                        if (decisao < 65 || decisao > 67 && decisao < 97 || decisao > 99)
                                        {
                                            Console.WriteLine("Decision must be a, b or c");
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }

                                        string newName = "";
                                        string newAddress = "";

                                        //Get new name if decision is a or c
                                        if (decisao == 'a' || decisao == 'A' || decisao == 'c' || decisao == 'C')
                                        {
                                            //Get new name
                                            Console.WriteLine("Insert new name(First and last): ");
                                            newName = Console.ReadLine();

                                            //Check if user entered two names
                                            if (!CheckIfTTwoNames(newName))
                                            {
                                                //if not, error message
                                                Console.WriteLine("You must enter atleast your first and last name.");
                                                Console.WriteLine("Press any key to continue");
                                                Console.ReadKey();
                                                break;
                                            }
                                        }

                                        //Gets new address if decision is b or c
                                        if (decisao == 'b' || decisao == 'B' || decisao == 'c' || decisao == 'C')
                                        {
                                            //Get new address
                                            Console.WriteLine("Insert new address: ");
                                            newAddress = Console.ReadLine();
                                        }

                                        if (!Doctor.EditDoctorFile(DOCTOR_INFO + id + ".bin", newName, newAddress))
                                        {
                                            //if something goes wrong, error message
                                            Console.WriteLine("Something went wrong, could not edit file");
                                            Console.WriteLine("Press any key to continue");
                                            Console.ReadKey();
                                            break;
                                        }
                                        //if everything goes right
                                        Console.WriteLine("Sucessfull!");
                                        Console.WriteLine("Press any key to continue");
                                        Console.ReadKey();
                                        break;

                                    case 'e':
                                    case 'E'://List doctors

                                        //List options
                                        Console.WriteLine("<A>Doctors working right now.");
                                        Console.WriteLine("<B>Doctors working in this hospital.");
                                        Console.WriteLine("<C>Former doctors");
                                        Console.WriteLine("<D>All doctors.");
                                        Console.Write("Decision: ");

                                        if (!char.TryParse(Console.ReadLine(), out decisao))
                                        {
                                            //Decision must be a character
                                            Console.WriteLine("Decision must be a character");
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }

                                        if (decisao < 65 || decisao > 68 && decisao < 97 || decisao > 100)
                                        {
                                            //Decision must be between a and e
                                            Console.WriteLine("Decision must be a, b, c or d");
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }

                                        if (decisao == 'a' || decisao == 'A')
                                            Doctors.ListWorkingDoctors();
                                        else if (decisao == 'b' || decisao == 'B')
                                            Doctors.ListCurrentOrFormerDoctors(DOCTOR_INFO, true);
                                        else if (decisao == 'c' || decisao == 'C')
                                            Doctors.ListCurrentOrFormerDoctors(DOCTOR_INFO, false);
                                        else
                                            Doctors.ListAllDoctors(DOCTOR_INFO);

                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    case 'f':
                                    case 'F'://Change operational status

                                        //Get doctor ID
                                        Console.WriteLine("ID: ");
                                        if (!int.TryParse(Console.ReadLine(), out int i)) //Verifys if it's int
                                        {
                                            //If the input is not an integer, error message
                                            Console.WriteLine("ID must be an integer value.");
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }

                                        //Checks if there is a doctor at work right now with that id
                                        if (Doctors.VerifyIfAtWorkByID(i))
                                        {
                                            //If the doctor is at work, error message
                                            Console.WriteLine("Doctor with that ID is at work");
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }

                                        //Checks if there is a file associated with that ID
                                        if (!File.Exists(DOCTOR_INFO + i + ".bin"))
                                        {
                                            //If file doesn't exist
                                            Console.WriteLine("There is no file associated with ID {0}.", i.ToString());
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }
                                        id = i;

                                        Console.WriteLine("<A>Change status to true");
                                        Console.WriteLine("<B>Change status to false");

                                        if (!char.TryParse(Console.ReadLine(), out decisao)) //Verifys if it's char
                                        {
                                            //If the input is not an character, error message
                                            Console.WriteLine("Decision must be a character value.");
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }

                                        if (decisao != 'a' && decisao != 'A' && decisao != 'b' && decisao != 'B')
                                        {
                                            //Decision must be either a or b
                                            Console.WriteLine("Decision must be either a or b");
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }

                                        //Gets the new operational status
                                        bool newOperationalStatus;
                                        if (decisao == 'a' || decisao == 'A')
                                            newOperationalStatus = true;
                                        else
                                        {
                                            newOperationalStatus = false;
                                            Doctors.ClockOut(id);
                                        }

                                        //Sets the new operational status
                                        if (!Doctor.ChangeOperationalStatus(DOCTOR_INFO + id.ToString() + ".bin", newOperationalStatus))
                                        {
                                            //If something goes wrong, error message
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }

                                        Console.WriteLine("Operational status of doctor's id number {0} changes sucessfully to {1}", id.ToString(), newOperationalStatus.ToString());
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;

                                    default:
                                        Console.WriteLine("Invalid option.\nPress any key to continue...");
                                        Console.ReadKey();
                                        break;
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


                                                    Patient p = Screening.PeekNextPatient();
                                                    Screening.ListCurrentPatient(p);
                                                    Console.Write("Patient priority: ");
                                                    bool ver = int.TryParse(Console.ReadLine(), out int patientPriority); //Checks Daif user inseted a valid priority for

                                                    if (ver)
                                                    {
                                                        Patient.GivePriority(p, patientPriority);

                                                        //Screening.RemovePatientFromScreeningQueue();
                                                        UrgencyQueue.AddToUrgency(p);
                                                        Screening.CallNextPatient();

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

        static void PrintMainMenu()
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

        static void PrintMenuPatients()
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

        static void PrintMenuDoctors()
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("|       Emergency Room of HOSPITAL S.JOAO DA POEIRA       |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("|                     DOCTORS MENU                        |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("| A) Clock in                                             |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| B) Clock out                                            |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| C) Add doctor                                           |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| D) Edit                                                 |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| E) List all doctors                                     |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("| F) Change operational value                             |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("| G) Exit                                                 |");
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