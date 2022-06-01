using System;

class Basics
{
    void LearnConditionals(byte x)
    {
        if (x < 50) // Comparision operators: <, >, ==, !=, <=, >=
        {
            Console.WriteLine("X is less than 50");
        }
        else if (x < 70)
        {
            Console.WriteLine("X is between 50-70");
        }
        else
        {
            Console.WriteLine("X is greater than 70");
        }
    }

    void LearnSwitch()
    {
        string name = "Bishnu";

        switch (name)
        {
            case "Bishnu":
                //Some code
                break;

            case "Ram":
                // Some code
                break;

            case "Shyam":
                // Some code
                break;

            default:
                //Some code
                break;
        }
    }
    
    internal void LearnLoops()
    {        
        for (byte i = 1; i < 6; i++)
        {
            Console.WriteLine(i + ".NET Training");
        }

        string[] names = {"Ramesh", "David" , "Anisha"};
        foreach(string name in names)
        {
            Console.WriteLine(name);
        }

        byte j = 1;
        while (j < 6)
        {
            Console.WriteLine(j + ".NET Training");
            j++;
        }
    }
}