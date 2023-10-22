
namespace _00_Assingment.Services;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using _00_Assingment.Interfacas;
using Newtonsoft.Json;

public class UserHandlar
{
    // min list samt file address.
    private List<IUserInfo> _users = new List<IUserInfo>();
    private readonly string _filePath = @"c:\filelove\users.json";
    public async void AddUser(IUserInfo userInfo)
    {
        //utskrift furmaten i file.
        _users.Add(userInfo);
        FileHandlar.SaveToFile(_filePath, JsonConvert.SerializeObject(_users));
    }

              //läser in alla användare 
    public IEnumerable<IUserInfo> GetAllUsers()
    {        
        FileHandlar.ReadFromFile(_filePath);
        //  return _users;
        try
        {
            var userinfo = FileHandlar.ReadFromFile(_filePath);
            if (string.IsNullOrEmpty(userinfo))
            {
                _users = JsonConvert.DeserializeObject<List<IUserInfo>>(userinfo)!;
            }
        }   catch (Exception ex) {  Debug.WriteLine(ex.Message); }
        return _users;
    }


    public IUserInfo GetOneUser(string email)
    {
            // söker efter den och retunerar den först vars fullname matchar det angivna och om den inte hittas kommer den retunerar null.
            return _users.FirstOrDefault(x => x.Email == email)!;

    }


    public bool DeleteOneUser(string FullName)
    {         //     tar bort en anvädare med hjälpa fullständiga namn
        var user = GetOneUser(FullName);
        if (user != null)
        {
            _users.Remove(user);
            FileHandlar.SaveToFile(_filePath, JsonConvert.SerializeObject(_users));

            return true;
        }
        else
        {
            return false;
        }
    }
    public IUserInfo UpdateUser(IUserInfo userInfo)
    {
        var user = _users.FirstOrDefault(x => x.FullName == userInfo.FullName);
        if (user != null)
        {
            if (user.FirstName != userInfo.FirstName)
                user.FirstName = userInfo.FirstName;
            if (user.LastName != userInfo.LastName)
                user.LastName = userInfo.LastName;
            if (user.Email != userInfo.Email)
                user.Email = userInfo.Email;

            FileHandlar.SaveToFile(_filePath, JsonConvert.SerializeObject(_users));
            return user;
        }
        return null!; // Ta bort utropstecknet här.
    }



}




















