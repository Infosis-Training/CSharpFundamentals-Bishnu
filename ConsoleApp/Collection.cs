using System;

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
}