﻿using System;
using Collect;
using Object.Oriented;
using OOP;

class EntryPoint
{
    public static void Main()
    {
        // Inheritance inheritance = new();
        
        // //Creating (Instantiating) objects/instances
        // Person p1 = new();
        
        // //Accessing static member
        // Person.scientificName = "Homosapiens";

        // //Accessing instance members
        // p1.personName = "Rim";
        // p1.heightInFt = 6.1f;
        // p1.age = 12;

        // string details = p1.GetPersonDetails();
        // Console.WriteLine(details);

        // Collection coll = new();
        // coll.LearnArrays();

        // Basics b = new(); 
        // b.LearnLoops();

        // Methods m = new();
        // m.Print();
        // m.Print("Bishnu");
        
        // var d = m.Print("Asmita", 20);
        // Console.WriteLine(d);

        // Console.WriteLine(m.Greet("David", "Dr."));
        // Console.WriteLine(m.Greet("David"));

        Exercise2 ex = new();
        string ini = ex.GetInititals("david", "Fowler");    
        Console.WriteLine(ini);
    }
}
