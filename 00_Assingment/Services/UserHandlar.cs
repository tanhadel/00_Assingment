

using _00_Assingment.Interfacas;
using _00_Assingment.Models;

namespace _00_Assingment.Services;

public class UserHandlar : IUserHandlar
{
    // min list samt file address.

    private List<IUserInfo> _users = new List<IUserInfo>();
    private readonly string _filePath=@"c:\filelove\users.json";
    public async void AddUserAsync(IUserInfo userInfo)
    {
        //utskrift furmaten i file.

        _users.Add(userInfo);
        await FileHandlar.SaveToFileAsync(_filePath,   userInfo.FullName+userInfo.Email+","+ userInfo.Address?.FullAddress);
    }
    public IEnumerable<IUserInfo> GetAllUsers()
    {
        return _users;
    }

    public IUserInfo GetOneUser(string FullName)
    {
        return _users.FirstOrDefault(x => x.FullName== FullName)!; 
    }
    public bool DeletOneUser(string FullName)
    {
        var user =GetOneUser (FullName);
        if (user != null)
        {
            _users.Remove(user);
            return true;
        }
        else
        {
            return false;
        }

    }

    
}
