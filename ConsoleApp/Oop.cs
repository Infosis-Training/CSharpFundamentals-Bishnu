// Object Oriented Programming Concepts
//1. Classes and objects

using System;

// Defining class
// Pascal casing: Class and Methods
// Camel casing: fields

class Person
{
    // Members: Fields, Methods
    internal static string scientificName;
    public string personName; //Camel casing
    public float heightInFt;
    internal byte age;
    string gender;

    public void SpeakLanguage() // Pascal casing
    {
        Console.WriteLine(personName + " is speaking...");
    }

    public string GetPersonDetails()
    {
        string nameDesc = "I am " + personName;
        string heightDesc = "My height is " + heightInFt + "Ft";
        string ageDesc = "I am " + age + " years old";
        string personDesc = nameDesc + "\n" + heightDesc + "\n" + ageDesc;
        return personDesc;
    }
}
