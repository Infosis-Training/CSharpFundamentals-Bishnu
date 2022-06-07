using System;
using System.Collections.Generic;
using System.Linq;

class Exercise4
{
    List<float> bills = new() { 23.5f, 56.2f, 45.1f, 90.34f, 12.23f, 78.65f };

    public void FetchData()
    {
        //Select all bills higher or equal to 50$
        var billsHigherThan50 = bills.Where(bill => bill >= 50);

        //Round all bills to nereast integer 
        var roundedBills = bills.Select(x => Math.Round(x));
        
        PrintCollection<float>(billsHigherThan50); 
        Console.WriteLine();
        PrintCollection<double>(roundedBills); 
    }

    void PrintCollection<T>(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            Console.Write($"{item} ");
        }
    }   

}