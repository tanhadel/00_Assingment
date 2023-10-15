

using _00_Assingment.Interfacas;
using _00_Assingment.Models;

namespace _00_Assingment.Services;

public class UserService
{
    // insatans av klassen UserHandlar. 
    private static readonly IUserHandlar userHandlar = new UserHandlar();
    public static void AddUserMenu()
        // Meny
    {
        IUserInfo userInfo = new UserInfo();
        {
         Console.Write ("Förnamn:");
        userInfo.FirstName = Console.ReadLine()!;
        Console.Write("Efternamn:");
        userInfo.LastName = Console.ReadLine()!;
        Console.Write("E-postaddress:");
        userInfo.Email = Console.ReadLine()!;

        userInfo.Address = new Address();
        Console.Write("Gatuadress:");
        userInfo.Address.StreetName = Console.ReadLine();
        Console.Write("Gatnummer:");
        userInfo.Address.StreetNumber = Console.ReadLine();
        Console.Write("Postnummer:");
        userInfo.Address.PostalCode = Console.ReadLine();
        Console.Write("stad / ord:");
        userInfo.Address.City = Console.ReadLine();
        Console.Write("Land:");
        userInfo.Address.Country = Console.ReadLine();

                Task.Run(() => userHandlar.AddUserAsync(userInfo));

        }

    }
    public static void ViewAllUserMenu()
    {
        //Här så kommer visas alla användarens uppgift.
        try
        {
            var users = userHandlar.GetAllUsers();
            foreach (var user in users)
            {
                Console.WriteLine(user.FullName);
                Console.WriteLine(user?.Address?.FullAddress);
                Console.WriteLine();
            }

        }  catch { }
        
    }
    public  static void ViewOneUserMenu()
    {

      
        // Här kommer visas om man vill söka efter en specifik användare. 
        Console.Write("Fullständig Namn:");
        var FulleName= Console.ReadLine();

        var user = userHandlar.GetOneUser(FulleName!);

        if (user != null)
        {
            Console.WriteLine(user?.FullName);
            Console.WriteLine(user?.Address?.FullAddress);
            Console.WriteLine();
        }
        else                      //´Här kommer jag programet skicka ett meddelande om den inte hittar användaren.
        {
            Console.WriteLine("Användare kunde inte hittas.");
        }

    }
    public static bool DeletOneUserMenu()
    {
        // Här kommer så kommer man kunna tar bort en användare. 
        Console.Write("Fullstandig Namn:");
        var FullName = Console.ReadLine();
        var deleted = userHandlar.DeletOneUser(FullName!);

        if (deleted )                           // Om avändaren hitta meddelar  programmet detta.
        {
            Console.WriteLine("Anvädaren har  tagits bort,");
        }
        else
        {                                                           // annars så skickar detta.
            Console.WriteLine("Kunde inte ta bort anvädaren. Anvädaren hittades inte ");
        }
        return deleted;

    }
    public static void MainUser ()
    {
        //Meny val.
        try
        {
            do
            {
                Console.Clear();
                Console.WriteLine("5. För att skapa en ny användare.");
                Console.WriteLine("6  För att visa alla anvädare.");
                Console.WriteLine("7. För att visa en användare");
                Console.WriteLine("8. Tar bort en användare.");
                Console.WriteLine("0. För att avsluta");
                Console.WriteLine(" Välj bland ovenstående alternativ.");
                var option = Console.ReadLine();
                Console.Clear();
                switch (option)
                {
                    case "5":
                        AddUserMenu();

                        break;
                    case "6":
                        ViewAllUserMenu();
                        break;
                    case "7":
                        ViewOneUserMenu();
                        break;
                    case "8":
                        DeletOneUserMenu();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;



                }
                Console.ReadKey();


            } while (true);

        } catch (Exception ex) {}
     
     


    }

}
