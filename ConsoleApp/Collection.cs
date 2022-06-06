using System;
using System.Collections.Generic;

namespace Collect;
class Collection
{
    internal void LearnArrays()
    {
        // 1D
        byte[] ages = new byte[20];
        ages[0] = 23;
        ages[1] = 89;

        float[] numbers = { 45, 67, 78 };

        //2D/Multi
        decimal[,] mat = new decimal[3, 4];
        mat[0, 0] = 34;
        mat[0, 1] = 23;

        double[,] table = { { 2, 3 }, { 4, 5 } };

        // Jagged array
        string[][] semNames = new string[3][];
        string[] firstSemNames = { "hari", "ram" };
        string[] secondSemNames = { "bishnu", "rim", "david" };

        semNames[0] = firstSemNames;
        semNames[1] = secondSemNames;

        Console.WriteLine(semNames[1][1]);
    }

    internal void LearnBuiltInCollections()
    {
        // List
        List<int> numbers = new();
        numbers.Add(23);
        numbers.Add(27);
        numbers.Add(29);
        numbers.Add(31);
        numbers.Add(90);
        numbers.Remove(23);

        // Stack and Queue
        Stack<string> names = new();
        names.Push("dfsfa");
        names.Push("dfsfa");
        names.Pop();

        Queue<double> bill = new();
        bill.Enqueue(34.5);
        bill.Enqueue(38.5);
        bill.Dequeue();

        Dictionary<string, byte> data = new();
        try
        {
            data.Add("A", 1);
            data.Add("A", 11);
            data.Add("Bsdfsfs", 15);
            data.Add("Hfsdfsaf", 10);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        foreach (var item in data)
        {
            Console.WriteLine($"{item.Key} => {item.Value}");
        }

        Dictionary<string, byte> data1 = new()
        {
            ["A"] = 1,
            ["Asdf"] = 11,
            ["Bsdfsfs"] = 15,
            ["Hfsdfsaf"] = 10
        };
    }
}