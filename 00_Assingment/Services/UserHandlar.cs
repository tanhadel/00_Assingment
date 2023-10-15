
namespace _00_Assingment.Services;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using _00_Assingment.Interfacas;

public class UserHandlar : IUserHandlar
{
    // min list samt file address.

    private List<IUserInfo> _users = new List<IUserInfo>();
    private readonly string _filePath = @"c:\filelove\users.json";
    public async void AddUserAsync(IUserInfo userInfo)
    {
        //utskrift furmaten i file.
        
        _users.Add(userInfo);
        await FileHandlar.SaveToFileAsync(_filePath, userInfo.FullName + "," + userInfo.Email + "," + "" + userInfo.Address?.FullAddress);
    }
    public IEnumerable<IUserInfo> GetAllUsers()
    {
        return _users;
    }
    public IUserInfo GetOneUser(string FullName)
        
    {
                              // söker efter den och retunerar den först vars fullname matchar det angivna och om den inte hittas kommer den retunerar null.
            return _users.FirstOrDefault(x => x.FullName == FullName)!;

    }
    //Kommer tarbort användaren med hjälp av fullname.
    public bool DeletOneUser(string FullName)

    {
        var user = GetOneUser(FullName);
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


    public void Save(string filePath)
    {
        using (var s = new StreamWriter(filePath, true))
            // Använd "append"-läge för att inte skriva över filen
        {
            for (int i = 0; i < _users.Count; i++)
            {
                s.WriteLine(_users[i].FullName + "," + _users[i].Email + "," + (_users[i].Address?.FullAddress ?? ""));
            }
        }
    }

    public bool DeleteOneUser(string FullName)
    {
        var user = GetOneUser(FullName);
        if (user != null)
        {
            _users.Remove(user);

            // Ta bort användaren från filen
            string fileContent = FileHandler.ReadFromFileAsync(_filePath).Result;
            string userLine = $"{user.FullName},{user.Email},{user.Address?.FullAddress}";

            if (fileContent.Contains(userLine))
            {
                fileContent = fileContent.Replace(userLine, "");
                FileHandler.Save(_filePath, fileContent); // Använd din befintliga Save-metod
                Console.WriteLine($"Användaren med användarnamn {FullName} har tagits bort från filen.");
            }

            return true;
        }
        else
        {
            return false;
        }
    }












}











