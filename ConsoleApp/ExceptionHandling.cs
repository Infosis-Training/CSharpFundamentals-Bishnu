using System;
using System.IO;

class ExceptionHandling
{
    public double Compute(double x, double y, double z)
    {
        double b = 0;
        try
        {
            double a = x + y * z;
            b = a / (y + z);

            if(double.IsInfinity(b))
            {
                throw new Exception("Divide by zero occured");
            }
        }
        catch(IOException ex1)
        {
            Console.WriteLine(ex1.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {

        }        

        return b;        
    }
}

// try, catch, finally, throw
// Exception classes: Exception