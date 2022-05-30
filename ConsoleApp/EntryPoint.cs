
class EntryPoint
{
    public static void Main()
    {
        //Creating (Instantiating) objects/instances
        Person p1 = new();
        
        //Accessing static member
        Person.scientificName = "Homosapiens";

        //Accessing instance members
        p1.personName = "Rim";
        p1.heightInFt = 6.1f;
        p1.age = 12;

        string details = p1.GetPersonDetails();
        Console.WriteLine(details);
    }
}
