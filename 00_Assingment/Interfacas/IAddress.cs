namespace _00_Assingment.Interfacas
{
    public interface IAddress
    {            // Interface för Address.
        string? City { get; set; }
        string? Country { get; set; }
        string? PostalCode { get; set; }
        string? StreetName { get; set; }
        string? StreetNumber { get; set; }
        string? FullAddress { get; }
    }
}

                                   



