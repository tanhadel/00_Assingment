
using _00_Assingment.Interfacas;
using _00_Assingment.Models;
using System.Diagnostics;

namespace _00_Assingment.Services
{
    public class UserService
    {
        //programmer kommer fråga följande.
        private static readonly UserHandlar userHandlar = new UserHandlar();

        public static void AddUserMenu()
        {
            IUserInfo userInfo = new UserInfo();

            Console.Write("Förnamn: ");
            userInfo.FirstName = Console.ReadLine()!;
            Console.Write("Efternamn: ");
            userInfo.LastName = Console.ReadLine()!;
            Console.Write("E-postadress: ");
            userInfo.Email = Console.ReadLine()!;

            userInfo.Address = new Address();
            Console.Write("Gatuadress: ");
            userInfo.Address.StreetName = Console.ReadLine();
            Console.Write("Gatunummer: ");
            userInfo.Address.StreetNumber = Console.ReadLine();
            Console.Write("Postnummer: ");
            userInfo.Address.PostalCode = Console.ReadLine();
            Console.Write("Stad/Ort: ");
            userInfo.Address.City = Console.ReadLine();
            Console.Write("Land: ");
            userInfo.Address.Country = Console.ReadLine();

            userHandlar.AddUser(userInfo);
        }

        public static void ViewAllUserMenu()
        {
            //här kommer programmet visa alla användare. 
            try
            {
                var users = userHandlar.GetAllUsers();
                foreach (var user in users)
                {
                    Console.WriteLine(user.FullName);
                    Console.WriteLine(user?.Address?.FullAddress);
                    Console.WriteLine();
                }
            }
            catch
            {
                // Felhantering
            }
        }

        public static void ViewOneUserMenu()
           // Här kommer visas om man vill söka efter en specifik användare.
        {
            Console.Write("Fullständigt namn: ");
            var FullName = Console.ReadLine();

            var user = userHandlar.GetOneUser(FullName!);

            if (user != null)
            {
                Console.WriteLine(user?.FullName);
                Console.WriteLine(user?.Address?.FullAddress);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Användaren kunde inte hittas.");
            }
        }

        public static void UpdateMenu()
        {   // updateraing biten som man kan updatera  förnamn, efternamn samt Email. 
            //´Här kommer jag programet skicka ett meddelande om den inte hittar användaren.
            Console.Clear();
            Console.WriteLine("E-postadress: ");
            var email = Console.ReadLine();

            var user = userHandlar.GetOneUser( email);
            if (user != null)
            {
                Console.WriteLine($"{user.FirstName} {user.LastName} <{user.Email}>\n");

                Console.WriteLine("Vill du uppdatera förnamn? (y/n)");
                var updateFirstName = Console.ReadLine();
                if (updateFirstName.ToLower() == "y")
                {
                    Console.Write("Förnamn: ");
                    user.FirstName = Console.ReadLine();
                }

                Console.WriteLine("Vill du uppdatera efternamn? (y/n)");
                var updateLastName = Console.ReadLine();
                if (updateLastName.ToLower() == "y")
                {
                    Console.Write("Efternamn: ");
                    user.LastName = Console.ReadLine();
                }

                Console.WriteLine("Vill du uppdatera e-postadress? (y/n)");
                var updateEmail = Console.ReadLine();
                if (updateEmail.ToLower() == "y")
                {
                    Console.Write("E-postadress: ");
                    user.Email = Console.ReadLine();
                }

                userHandlar.UpdateUser(user);
            }
            else
            {
                Console.WriteLine("Ingen användare kunde hittas.");
            }
        }
           public static bool DeletOneUserMenu()
        {
            // Här kommer så kommer man kunna tar bort en användare. 
            Console.Write("Fullständig Namn:");
            var FullName = Console.ReadLine();
            var deleted = userHandlar.DeleteOneUser(FullName!);

            if (deleted)                           // Om avändaren hitta meddelar  programmet detta.
            {
                Console.WriteLine("Anvädaren har  tagits bort,");
            }
            else
            {                                                           // annars så skickar detta.
                Console.WriteLine("Kunde inte ta bort anvädaren. Anvädaren hittades inte ");
            }
            return deleted;

        }

        public static void MainUser()
        {             // Meny vall
            try
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("-------------- Meny --------------");
                    Console.WriteLine("5. Skapa en ny användare");
                    Console.WriteLine("6. Visa alla användare");
                    Console.WriteLine("7. Visa en användare");
                    Console.WriteLine("8. Ta bort en användare");
                    Console.WriteLine("9. Uppdatera en användare");
                    Console.WriteLine("0. Avsluta");
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Välj ett av ovanstående alternativ.");
                    var option = Console.ReadLine();
                    Console.Clear();

                    switch (option!.ToLower())
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
                        case "9":
                            UpdateMenu();
                            break;
                        case "0":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Ogiltigt val. Försök igen.");
                            break;
                    }

                    Console.ReadKey();
                } while (true);
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            {
                // Felhantering
            }
        }
    }
}



