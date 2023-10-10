

using _00_Assingment.Interfacas;

namespace _00_Assingment.Models;

public class UserInfo : IUserInfo
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public IAddress? Address { get; set; } = null!;

    public string FullName => $"{FirstName} {LastName}";
   
}
