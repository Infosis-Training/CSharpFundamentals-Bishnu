class Properties
{
    // FUll property
    string _name;
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (value.Length >= 2)
            {
                _name = value;
            }
        }
    }

    // Auto-implemented property
    public double Average { get; set; }
    public string Address { get; private set;}
}
