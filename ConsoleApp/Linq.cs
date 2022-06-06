using System.Linq;

class Linq
{
    // Language Integrated Query
    int[] numbers = { 2, 3, 4, 5, 6, 1, 7, 8, 9, 10, 11, 12 };

    public void LearnLINQ()
    {
        // Get all odd numbers
        var oddNumbers = numbers.Where(number => number % 2 == 1);

        // Get all multiples of 3
        var multiplesOf3 = numbers.Where(n => n % 3 == 0);

        // Get squares of all elements
        var squares = numbers.Select(x => x * x);

        // Get quares of all odd numbers
        var oddSquares = numbers.Where(number => number % 2 == 1)
                                .Select(x => x * x);

    } 
}