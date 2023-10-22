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

// i denna test försker jag kolla DeleteOnser Fungerar när anvädare finns inte. 
// Den försöker tar bort en avändare med hjälp av fullständiga namn samt returneraar en falskt värd när användaren finns inte kvar i lisatan.
 

