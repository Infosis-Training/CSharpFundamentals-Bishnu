// Object Oriented Programming Concepts
//1. Classes and objects

using System;

// Defining class
// Pascal casing: Class and Methods
// Camel casing: fields
namespace OOP;

class Person
{
    // Members: Fields, Methods
    internal static string scientificName;
    public string personName; //Camel casing
    protected float heightInFt;
    internal byte age;
    //string gender;

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
