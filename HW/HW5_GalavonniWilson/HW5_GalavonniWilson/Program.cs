//MIS 3033 HW5
//Galavonni Wilson 113506288

using a;
using System.Formats.Tar;
using System.Runtime.Intrinsics.X86;

Console.WriteLine("DB");

string menuStr = @"

****************************
1. Add a new patient
2. Show all patients
3. Search for one patient based on a given ID
4. Delete one patient based on a given ID
5. Show the average age of all patients
6. Show the patient information with the lowest age
Press other keys to exit
****************************

";

PatientDB db = new PatientDB(); //load the db from file to RAM


while (true)
{
    Console.WriteLine(menuStr);
    Console.Write("Enter an option: ");
    string opStr = Console.ReadLine();


    if (opStr =="1")
    { //1. Add a new patient

        Console.WriteLine("Add a new patient");
        Console.Write("ID: ");
        string idStr = Console.ReadLine();

        Console.Write("Age: ");
        string ageStr = Console.ReadLine();
        int ageInt = Convert.ToInt32(ageStr);

        //create a new patient
        Patient patient =new Patient();
        patient.PID = idStr;
        patient.Age = ageInt;

        //call age level. the function created in pdb to automatically calculate it for you
        patient.GetAgeLevel();

        //add patient ot patient table
        db.patients.Add(patient);

        //persist it, save db from RAM to file
        db.SaveChanges();

        Console.WriteLine("Patient added successfully");
        Console.WriteLine(patient);


    }
    else if (opStr =="2")
    {//2. Show all patients
        Console.WriteLine("Show all Patients");
        List<Patient> pList = db.patients.ToList();
        for (int i=0; i<pList.Count; i++)
        {
            Console.WriteLine(pList[i]);
        }

    }
    else if (opStr == "3")
    {//Search for one patient with PID
        Console.WriteLine("Search for one patient based on ID");
        Console.WriteLine("ID: ");
        string idStr = Console.ReadLine();

        Patient p =db.patients.Where(x=>x.PID==idStr).FirstOrDefault();

        if (p !=null) //we can find the patient
        {
            Console.WriteLine(p);
        }
        else // cannot find the patient in db
        {
            Console.WriteLine ($"PID {idStr} does not exist in the db");
        }

    }
    else if (opStr == "4")
    {//Delete a patient given an PID
        Console.WriteLine("Delete a patient given an PID");
        Console.Write("ID: ");
        string idStr = Console.ReadLine();

        //query to find patient
        Patient p = db.patients.Where(x => x.PID == idStr).FirstOrDefault();

        if (p!= null)// if id can be found
        {
            db.patients.Remove(p);
            Console.WriteLine("Patient successfully removed");


        }
        else
        {
            Console.WriteLine($"Patient ID {idStr} does not exist in the DB!!!!");
        }


        // remove from the table in the RAM

        //persist
        db.SaveChanges();





    }
    else if (opStr == "5")
    {//Show average age of all patient
        Console.WriteLine("Show average age of all patients");
        double aveAge = db.patients.Average(x => x.Age);

        Console.WriteLine($"{aveAge:F2}");

    }
    else if (opStr == "6")
    {// Show the patient information with the lowest age
        Console.WriteLine("Show the patient information with the lowest age");
        Patient p =db.patients.ToList().MinBy(x => x.Age);
        Console.WriteLine(p);
    }
    else
    {
        Console.WriteLine("Thank you and goodbye");
        break; //stop the loop
    }







}
