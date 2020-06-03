using System;
using System.IO;
using System.Collections.Generic;
using Exceptions;
using Verifications;
using HospitalBO;
using HospitalRN;
using System.Globalization;

namespace HospitalER
{
    class Program
    {
        static void Main()
        {
            Console.Clear();
            char decision;
            const string dateFormat = "d/M/yyyy";


            //Directories paths
            const string PATIENT_INFO = @"C:\Users\ricar\source\repos\18827_18843_LP2\DataLayer\PatientsInfo\";
            const string PATIENT_RECORD = @"C:\Users\ricar\source\repos\18827_18843_LP2\DataLayer\PatientsRecord\";
            const string DOCTOR_INFO = @"C:\Users\ricar\source\repos\18827_18843_LP2\DataLayer\DoctorsInfo\";
            

            //Create essential directories if they don't already exist
            try
            {
                Regras.CreateCustomDirectory(PATIENT_INFO);
                Regras.CreateCustomDirectory(PATIENT_RECORD);
                Regras.CreateCustomDirectory(DOCTOR_INFO);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            while (true)
            {
                Console.Clear();
                Menus.PrintMainMenu();//Prints the main menu to the screen

                //Checks if the user chose a valid option
                if (!char.TryParse(Console.ReadLine(), out decision))
                {
                    Console.WriteLine("Decision must be a character.\nPress any key to continue...");
                    Console.ReadKey();
                    decision = 'z';
                }
                switch (decision)
                {
                    case 'a':
                    case 'A': //Patients menu//

                        while (decision != 'D' && decision != 'd') //Stays in the menu while user says otherwise
                        {
                            Console.Clear();
                            Menus.PrintMenuPatients(); //Prints the Patients menu to the screen

                            //Checks if the user chose a valid option
                            if (!char.TryParse(Console.ReadLine(), out decision))
                            {
                                Console.WriteLine("Decision must be a character.");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                break;
                            }
                            switch (decision)
                            {
                                case 'a':
                                case 'A': //Creates a patient file and add the patient to the screening queue

                                    Console.Write("CC: ");
                                    string cc = Console.ReadLine();//Gets the patient cc

                                    //check if CC has a valid format
                                    if (!DataVerifications.ValidIdentification(cc))
                                    {
                                        Console.WriteLine("Invalid CC.");
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }

                                    var newPatient = new Patient();
                                    //C:\Users\ricar\source\repos\18827_18843_LP2\DataLayer\PatientsInfo
                                    //Checks if the patient has a file
                                    if (!Regras.VisitFile(PATIENT_INFO, cc))
                                    {
                                        newPatient.CC = cc;

                                        //Gets the patient name
                                        Console.Write("Name (First and Last): ");
                                        newPatient.Name = Console.ReadLine();

                                        //checks if name has a valid format
                                        if (!DataVerifications.ValidName((newPatient.Name)))
                                        {
                                            Console.WriteLine("Invalid name.\nPress any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }

                                        //Gets patient birth date
                                        Console.Write("Birth Date: ");

                                        if (!DateTime.TryParseExact(Console.ReadLine(), dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                                        {
                                            Console.WriteLine("Invalid date format.");
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }
                                        newPatient.BirthDate = date;
                                        

                                        //Gets new patient address
                                        Console.Write("Address: ");
                                        newPatient.Address = Console.ReadLine();

                                        //Creates a file for the patient
                                        try
                                        {
                                            if (!Regras.SavePersonFile(PATIENT_INFO, newPatient.CC, newPatient))
                                            {
                                                Console.WriteLine("There is already a file associated with that ID");
                                                Console.WriteLine("Press any key to continue...");
                                                Console.ReadKey();
                                                break;
                                            }
                                            
                                        }
                                        catch (OpenFileException eo)
                                        {
                                            Console.WriteLine(eo.Message);
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }
                                        catch (WriteFileException ew)
                                        {
                                            Console.WriteLine(ew.Message);
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        //If the patient already has a file, get the info from it
                                        try
                                        {
                                            newPatient = Regras.GetPersonInfo<Patient>(PATIENT_INFO, cc);
                                        }
                                        catch (OpenFileException ef)
                                        {
                                            Console.WriteLine(ef.Message);
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }
                                        catch (ReadFileException er)
                                        {
                                            Console.WriteLine(er.Message);
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }
                                    }
                                    Regras.SaveRecord(newPatient.CC, DateTime.Now, true);
                                    //Adds the patient to the screening queue
                                    if (!Regras.SendPatientToScreeningQueue(newPatient))
                                    {
                                        Console.WriteLine("There is a patient in the queue with the same ID");
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }

                                    Console.WriteLine("Patient sucessfully added to the screening queue.");
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                    break;
                                case 'b':
                                case 'B'://Edit information from a patient file

                                    //Gets patient cc
                                    Console.Write("CC: ");
                                    cc = Console.ReadLine();

                                    //checks if CC has a valid format
                                    if (!DataVerifications.ValidIdentification(cc))
                                    {
                                        Console.WriteLine("Invalid CC.\nPress any key to continue...");
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }

                                    //Checks if the patient has a file
                                    if (!Regras.VisitFile(PATIENT_INFO, cc))
                                    {
                                        Console.WriteLine("There is no file associated with that ID.");
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }

                                    //Prints the edit options to the screen    
                                    Console.WriteLine("<A>Edit name");
                                    Console.WriteLine("<B>Edit address");
                                    Console.WriteLine("<C>Edit name and address");
                                    Console.Write("Decision: ");

                                    //Gets the user option and checks if it's valid
                                    if (!char.TryParse(Console.ReadLine(), out decision))
                                    {
                                        Console.WriteLine("Decision must be a character");
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }

                                    string newName = "", newAddress = "";

                                    //If the user chooses option 'a' or 'c'
                                    if (decision == 'a' || decision == 'A' || decision == 'c' || decision == 'C')
                                    {
                                        //Gets the new name
                                        Console.Write("New name: ");
                                        newName = Console.ReadLine();

                                        //Checks if the user inserted two or more names
                                        if (!DataVerifications.ValidName(newName))
                                        {
                                            //If he didn't, error message
                                            Console.WriteLine("Invalid name.\nPress any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }
                                    }

                                    //if the user chooses option 'b' or 'c'
                                    if (decision == 'b' || decision == 'B' || decision == 'c' || decision == 'C')
                                    {
                                        //Gets the user address
                                        Console.Write("New address: ");
                                        newAddress = Console.ReadLine();
                                    }

                                    try
                                    {
                                        Regras.EditPatientFile(cc, newName, newAddress);
                                    }
                                    catch (OpenFileException eo)
                                    {
                                        Console.WriteLine(eo.Message);
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }
                                    catch (WriteFileException ew)
                                    {
                                        Console.WriteLine(ew.Message);
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }
                                    catch (ReadFileException er)
                                    {
                                        Console.WriteLine(er.Message);
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }


                                    Console.WriteLine("Patient sucessfully edited.");
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                    break;

                                case 'c':
                                case 'C'://List all patients//

                                    //Gets a list of all the patients registered in the hospital

                                    var aux = new List<HospitalBO.Patient>();
                                    try
                                    {
                                        aux = Regras.GetList<Patient>(PATIENT_INFO);
                                    }
                                    catch (OpenFileException eo)
                                    {
                                        Console.WriteLine(eo.Message);
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }
                                    catch (ReadFileException er)
                                    {
                                        Console.WriteLine(er.Message);
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }

                                    //Prints the data to the screen
                                    DataGrids.ListRegisteredPatients(aux);
                                    Console.WriteLine("\nPress any key to continue...");
                                    Console.ReadKey();
                                    break;
                            }
                        }
                        break;
                    case 'b':
                    case 'B'://Doctors menu//
                             //Stays in this menu while user doesn't say otherwise
                        while (decision != 'G' && decision != 'g')
                        {
                            Console.Clear();
                            Menus.PrintMenuDoctors(); //Prints the doctors menu to the screen

                            //Checks if the user selected a valid option of the menu
                            if (!char.TryParse(Console.ReadLine(), out decision))
                            {
                                Console.WriteLine("Decision must be a character.");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                break;
                            }

                            int id;
                            Doctor d;
                            switch (decision)
                            {
                                case 'a':
                                case 'A': //Doctor clock in

                                    //Gets doctor ID
                                    Console.Write("Enter ID: ");
                                    if (!int.TryParse(Console.ReadLine(), out id))//Checks if id format is valid
                                    {
                                        Console.WriteLine("ID must be an integer");
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }

                                    try
                                    {
                                        if (!Regras.DoctorClockIn(id))
                                        {
                                            Console.WriteLine("Doctor associated with that ID is already at work.");
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }
                                    }
                                    catch (OpenFileException e)
                                    {
                                        Console.WriteLine(e.Message);
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }
                                    catch (NotOperationalException en)
                                    {
                                        Console.WriteLine(en.Message);
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }

                                    Console.WriteLine("Doctor clocked in.");
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                    break;

                                case 'b':
                                case 'B'://Clock out

                                    //Gets doctor ID
                                    Console.Write("Enter ID: ");

                                    //Checks if id format is valid
                                    if (!int.TryParse(Console.ReadLine(), out id))
                                    {
                                        Console.WriteLine("ID must be an integer");
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }

                                    //Clock out
                                    if (!Regras.DoctorClockOut(id))
                                    {
                                        Console.WriteLine("There is no doctor associated with that ID at work.");
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }

                                    Console.WriteLine("Doctor clocked out.");
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                    break;

                                case 'c':
                                case 'C':
                                    d = new Doctor();

                                    //Gets the cc of the doctor
                                    Console.Write("CC: ");
                                    d.CC = Console.ReadLine();

                                    //checks if CC has a valid format
                                    if (!DataVerifications.ValidIdentification(d.CC))
                                    {
                                        //If not, error message
                                        Console.WriteLine("Invalid cc.\nPress any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }

                                    //Checks if there is no doctor with the same cc
                                    try
                                    {
                                        if (Regras.CreateDoctorCCValitation(d.CC))
                                        {
                                            Console.WriteLine("There is a doctor associated with that cc");
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }
                                    }
                                    catch (OpenFileException eo)
                                    {
                                        Console.WriteLine(eo.Message);
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }
                                    catch (ReadFileException er)
                                    {
                                        Console.WriteLine(er.Message);
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }

                                    //Gets the name of the doctor
                                    Console.Write("Name (First and Last): ");
                                    d.Name = Console.ReadLine();

                                    //checks if name has a valid format
                                    if (!DataVerifications.ValidName(d.Name))
                                    {
                                        //if not, error message
                                        Console.WriteLine("Invalid first and last name.\n Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }

                                    //Gets doctor's birthdate
                                    Console.Write("Birth Date (DD-MM-YYYY): ");

                                    if (!DateTime.TryParseExact(Console.ReadLine(), dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
                                    {
                                        Console.WriteLine("Invalid date time format.");
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }

                                    //Gets the doctor's address
                                    Console.Write("Address: ");
                                    d.Address = Console.ReadLine();

                                    d.IdDoctor = Regras.GetNewDoctorID();

                                    //Save doctor
                                    try
                                    {
                                        if (!Regras.SavePersonFile(DOCTOR_INFO, d.IdDoctor.ToString(), d))
                                        {
                                            Console.WriteLine("There is already a doctor with that ID.");
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }
                                    }
                                    catch (OpenFileException eo)
                                    {
                                        Console.WriteLine(eo.Message);
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }
                                    catch (WriteFileException er)
                                    {
                                        Console.WriteLine(er.Message);
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }

                                    Console.WriteLine("Doctor created sucessfully.");
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                    break;

                                case 'd':
                                case 'D': //Edit doctor

                                    //Gets doctor ID
                                    Console.Write("ID: ");
                                    if (!int.TryParse(Console.ReadLine(), out id))
                                    {
                                        Console.WriteLine("ID must be an integer.");
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }

                                    //Checks if doctor exists
                                    if (!Regras.VisitFile(DOCTOR_INFO, id.ToString()))
                                    {
                                        Console.WriteLine("There is no file associated with that ID.");
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }

                                    //Prints the edit options to the screen    
                                    Console.WriteLine("<A>Edit name");
                                    Console.WriteLine("<B>Edit address");
                                    Console.WriteLine("<C>Edit name and address");
                                    Console.Write("Decision: ");

                                    //Gets the user option and checks if it's valid
                                    if (!char.TryParse(Console.ReadLine(), out decision))
                                    {
                                        Console.WriteLine("Decision must be a character");
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }

                                    string newName = "", newAddress = "";

                                    //If the user chooses option 'a' or 'c'
                                    if (decision == 'a' || decision == 'A' || decision == 'c' || decision == 'C')
                                    {
                                        //Gets the new name
                                        Console.Write("New name: ");
                                        newName = Console.ReadLine();

                                        //Checks if the user inserted two or more names
                                        if (!DataVerifications.ValidName(newName))
                                        {
                                            //If he didn't, error message
                                            Console.WriteLine("Invalid name.\nPress any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }
                                    }

                                    //if the user chooses option 'b' or 'c'
                                    if (decision == 'b' || decision == 'B' || decision == 'c' || decision == 'C')
                                    {
                                        //Gets the user address
                                        Console.Write("New address: ");
                                        newAddress = Console.ReadLine();
                                    }

                                    try
                                    {
                                        Regras.EditDoctorFile(id.ToString(), newName, newAddress);
                                    }
                                    catch (OpenFileException eo)
                                    {
                                        Console.WriteLine(eo.Message);
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }
                                    catch (ReadFileException er)
                                    {
                                        Console.WriteLine(er.Message);
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }
                                    catch (WriteFileException ew)
                                    {
                                        Console.WriteLine(ew.Message);
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }

                                    Console.WriteLine("Doctor sucessfully edited.");
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                    break;


                                case 'e':
                                case 'E': //Change operational status

                                    //Gets doctor ID
                                    Console.Write("ID: ");
                                    if (!int.TryParse(Console.ReadLine(), out id))
                                    {
                                        Console.WriteLine("ID must be an integer.");
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }

                                    //Checks if doctor exists
                                    if (!Regras.VisitFile(DOCTOR_INFO, id.ToString()))
                                    {
                                        Console.WriteLine("There is no file associated with that ID.");
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }

                                    try
                                    {
                                        bool q = Regras.ChangeDoctorStatus(id.ToString());
                                        Console.WriteLine("Status changed sucessfully from {0} to {1}.", !q, q);
                                    }
                                    catch (OpenFileException eo)
                                    {
                                        Console.WriteLine(eo.Message);
                                    }
                                    catch (ReadFileException er)
                                    {
                                        Console.WriteLine(er.Message);
                                    }
                                    catch (WriteFileException ew)
                                    {
                                        Console.WriteLine(ew.Message);
                                    }
                                    catch (ReturnException ere)
                                    {
                                        Console.WriteLine(ere.Message);
                                    }

                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                    break;

                                case 'f':
                                case 'F': //Lists

                                    //List options
                                    Console.WriteLine("<A>Doctors working right now.");
                                    Console.WriteLine("<B>Doctors working in this hospital.");
                                    Console.WriteLine("<C>Former doctors.");
                                    Console.WriteLine("<D>All doctors.");
                                    Console.Write("Decision: ");

                                    //Verify if the input is a character
                                    if (!char.TryParse(Console.ReadLine(), out decision))
                                    {
                                        Console.WriteLine("Decision must be a character.");
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }

                                    //Get doctors list
                                    List<Doctor> aux;
                                    if (decision == 'a' || decision == 'A')
                                    {
                                        aux = Regras.GetDoctorsWorkingList();
                                    }
                                    else if (decision == 'b' || decision == 'B')
                                    {
                                        try
                                        {
                                            aux = Regras.GetHiredFormerDoctorsList(true);
                                        }
                                        catch (OpenFileException eo)
                                        {
                                            Console.WriteLine(eo.Message);
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }
                                        catch (ReadFileException er)
                                        {
                                            Console.WriteLine(er.Message);
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }
                                    }
                                    else if (decision == 'c' || decision == 'C')
                                    {
                                        try
                                        {
                                            aux = Regras.GetHiredFormerDoctorsList(false);
                                        }
                                        catch (OpenFileException eo)
                                        {
                                            Console.WriteLine(eo.Message);
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }
                                        catch (ReadFileException er)
                                        {
                                            Console.WriteLine(er.Message);
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }
                                    }
                                    else if (decision == 'd' || decision == 'D')
                                    {
                                        try
                                        {
                                            aux = Regras.GetAllDoctorsList();
                                        }
                                        catch (OpenFileException eo)
                                        {
                                            Console.WriteLine(eo.Message);
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }
                                        catch (ReadFileException er)
                                        {
                                            Console.WriteLine(er.Message);
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid option.");
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        break;
                                    }

                                    //List the doctors list
                                    DataGrids.ListDoctors(aux);
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                    break;

                                case 'g':
                                case 'G':
                                    break;
                                default:
                                    Console.WriteLine("Invalid option");
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                    break;
                            }
                        }
                        break;
                    case 'c':
                    case 'C':
                        decision = ' ';
                        while (decision != 'c' && decision != 'C') //while "decisao" != 'c' or 'C', stays in the menu "Emergency Room"
                        {
                            Console.Clear();
                            Menus.PrintMenuER();

                            //Checks if the input is a character
                            if (!char.TryParse(Console.ReadLine(), out decision))
                            {
                                Console.WriteLine("Decision must be a character.");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                break;
                            }

                            switch (decision)
                            {
                                case 'a':
                                case 'A': //Secreening

                                    while (decision != 'c' && decision != 'C')
                                    {
                                        Console.Clear();
                                        Menus.PrintMenuScreening();

                                        //checks if the input is a character
                                        if (!char.TryParse(Console.ReadLine(), out decision))
                                        {
                                            Console.WriteLine("Decision must be a character.\nPress any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }

                                        switch (decision)
                                        {
                                            case 'a':
                                            case 'A': //Call patient

                                                //Checks if there are patients in the queue
                                                if (!Regras.ScreeningHasPatients())
                                                {
                                                    Console.WriteLine("Screening queue is empty.");
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();
                                                    break;
                                                }

                                                //Peeks next patient in the queue
                                                Patient p = Regras.CallPatientToScreening();
                                                Utils.ListPatient(p);

                                                //Asks for which priority to give to the patient
                                                Console.Write("Patient priority: ");
                                                if (!int.TryParse(Console.ReadLine(), out int priority))
                                                {
                                                    Console.WriteLine("Priority must be an integer.");
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();
                                                    break;
                                                }
                                                p.Priority = priority;

                                                //Add to the urgency queue

                                                Regras.AddPatientToUrgencyQueue(p);
                                                Regras.RemovePatientScreeningQueue(p);

                                                Console.WriteLine("Persons added to the urgency queue!");
                                                break;

                                            case 'b':
                                            case 'B'://List queue

                                                //Get the queue
                                                Queue<Patient> aux = Regras.GetScreeningQueueCopy();
                                                

                                                //Print the queue
                                                DataGrids.ListScreeningQueue(aux);
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

                                    while (decision != 'c' && decision != 'C') //while "decisao" != 'c' or 'C', stays in the menu "Urgency"
                                    {
                                        Console.Clear();
                                        Menus.PrintMenuUrgency();

                                        //Checks if user inserted a valid option format
                                        if (!char.TryParse(Console.ReadLine(), out decision))
                                        {
                                            Console.WriteLine("Decision must be a character.");
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            break;
                                        }

                                        switch (decision)
                                        {
                                            case 'a':
                                            case 'A'://Call patient

                                                //gets doctor's id
                                                Console.Write("Doctor ID: ");
                                                if (!int.TryParse(Console.ReadLine(), out int docID))
                                                {
                                                    Console.WriteLine("ID must be a character.");
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();
                                                    break;
                                                }

                                                //Check if doctor is at work
                                                if (!Regras.CheckIfDoctorWorking(docID))
                                                {
                                                    Console.WriteLine("There's no doctor associatewith that ID working right now.");
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();
                                                    break;
                                                }

                                                if (!Regras.UrgencyHasPatients())
                                                {
                                                    Console.WriteLine("There are no patients in the urgency queue.");
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();
                                                    break;

                                                }
                                                
                                                //Get next patient
                                                Patient q = Regras.GetNextPatientUrgencyQueue();
                                                Regras.SaveRecord(q.CC, DateTime.Now, false);

                                                Console.WriteLine("Person {0} has been called.", q.Name.ToString());
                                                Utils.ListPatientWithPriority(q);
                                                Console.WriteLine("Press any key to continue...");
                                                Console.ReadKey();
                                                break;

                                            case 'b':
                                            case 'B'://List patients

                                                //Get copy of urgency queue

                                                SortedList<int, Patient> aux = Regras.GetCopyUrgencyQueue();
                                                DataGrids.ListUrgencyQueue(aux);
                                                Console.WriteLine("Press any key to continue...");
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
        }

    }
}