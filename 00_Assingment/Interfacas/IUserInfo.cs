using _00_Assingment.Models;

namespace _00_Assingment.Interfacas
{
    public interface IUserInfo
    {
        IAddress? Address { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string FullName { get; }
    }
}