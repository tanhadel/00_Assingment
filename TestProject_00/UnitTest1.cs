using _00_Assingment.Interfacas;
using _00_Assingment.Services;
using Moq;
namespace TestProject_00;

public class UserHandlarTests 
{
    [Fact]
    public async Task  Test_Adduser()
    {
        //Arrange
        var userInfo = new Mock <IUserInfo> ();
        var userHandlar = new UserHandlar();

        //Act
        userHandlar.AddUser(userInfo.Object);


        //Assert
        var allUsers = userHandlar.GetAllUsers();
        Assert. Contains(userInfo.Object, allUsers);
        // i denna sest f�rs�ker jag kolla  AddUser i  userhandlar klassen l�gger till en anv�ndare korrekt.
        // �ven anv�der en mock objekt f�r IuserInfo samt tester om anv�der finns i lstan efter att metoden k�rts. 


    }



}
