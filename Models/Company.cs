class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Industry { get; set; }
    public int NumOfEmployees { get; set; }
    public double Capitalization { get; set; }

    private string CapitalizationCurrency = "€";

    public string GetCapitalization()
    {
        return $"{Capitalization:N2} {CapitalizationCurrency}"; // два знаки після коми
    }

    public Company(int id, string name, string industry, int numOfEmployees, double capitalization)
    {
        Id = id;
        Name = name;
        Industry = industry;
        NumOfEmployees = numOfEmployees;
        Capitalization = capitalization;
    }
}
