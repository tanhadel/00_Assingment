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
        // i denna sest försöker jag kolla  AddUser i  userhandlar klassen lägger till en användare korrekt.
        // även anväder en mock objekt för IuserInfo samt tester om anväder finns i lstan efter att metoden körts. 


    }



}
