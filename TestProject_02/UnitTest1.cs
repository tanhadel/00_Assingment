using _00_Assingment.Services;
namespace TestProject_02;
using Xunit; 
public class UnitTest1
{
    [Fact]
    public void Test_GetAllUsers()
    {
        // Arrange
        var userHandlar = new UserHandlar();
        var FullNameToDelete = "Taha Taheri";

        // Act 
        var result = userHandlar.DeleteOneUser(FullNameToDelete);

        // Assert
        Assert.False(result);
        var deletedUser = userHandlar.GetOneUser(FullNameToDelete);
        Assert.Null(deletedUser);
    }
}

// i denna test f�rsker jag kolla DeleteOnser Fungerar n�r anv�dare finns inte. 
// Den f�rs�ker tar bort en av�ndare med hj�lp av fullst�ndiga namn samt returneraar en falskt v�rd n�r anv�ndaren finns inte kvar i lisatan.
 

