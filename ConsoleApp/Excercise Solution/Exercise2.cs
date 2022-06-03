class Exercise2
{
    public int GetMax(int x, int y, int z)
    {
        if(x > y)
        {
            if(x > z)
                return x;
            else
                return z;
        }
        else
        {
            if(y > z)
                return y;
            else
               return z; 
        }
    }

    internal double Multiply(double x, double y, double z = 1) => x * y * z;

    internal string GetInititals(string firstName, string lastName)// Bishnu, Rawal
    {
        string initials = $"{firstName[0]}{lastName[0]}";
        return initials.ToUpper();
    }
}