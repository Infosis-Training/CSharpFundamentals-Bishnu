using System;

class Methods
{
    // Simplest possble: No return type, no parameters 
    public void Print() => Console.WriteLine("Hello there!!");

    // No return type, take some arguments
    public void Print(string name) => Console.WriteLine("Hello there!!, " + name);
    
    // one return type, multiple arguments
    public string Print(string name, byte age) => $"I am {name}. I am {age} years old.";

    // Optional Arguments
    public string Greet(string name, string salutation = "Mr.") => $"Hello, {salutation} {name}";

    public int Sum(int x , int y) => x + y;

    // Write a method to find if number is odd or even
    public void DecideEvenOrOdd(int num)
    {
        if(num % 2 == 0)
        {
            Console.WriteLine($"{num} is even");
        }
        else
        {
            Console.WriteLine($"{num} is odd");
        }
    }

    public bool IsEven(int num) => num % 2 == 0;

    // Returning multiple values, using tuple
    public (int, int) FindMinMax(int x, int y, int z)
    {
        Exercise2 ex = new();
        int max = ex.GetMax(x, y, z);
        int min = ex.GetMin(x, y, z);

        return (min, max);
    }
}


