


using _00_Assingment.Interfacas;

namespace _00_Assingment.Models
{
    public class Address : IAddress
    {
        public string? StreetName { get; set; }
        public string? StreetNumber { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

        public string? FullAddress => $"{StreetName} {StreetNumber} {PostalCode} {City} {Country}";

      
    }
}
