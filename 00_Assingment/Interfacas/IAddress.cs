namespace _00_Assingment.Interfacas
{
    public interface IAddress
    {
        string? City { get; set; }
        string? Country { get; set; }
        string? PostalCode { get; set; }
        string? StreetName { get; set; }
        string? StreetNumber { get; set; }
        string? FullAddress { get; }
    }
}