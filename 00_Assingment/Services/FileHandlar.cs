


using _00_Assingment.Services;

namespace _00_Assingment.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;


    public class User
    {
        public required string Username { get; set; }
        public required string FullName { get; set; }
    }
    public class FileHandlar
    {

        public static async Task SaveToFileAsync(string filePath, string content)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                  writer.WriteLine( );
                    
                }
                Console.WriteLine("Informationen har sparats i filen.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel inträffade: {ex.Message}");
            }
        }

     }
    //public class Program
    //{
    //    public static void Main (string[] args)
    //    {
    //        string contentTosave = "Detta information sparas i  fillen filelove";
    //        string filePath = "filelove";
    //        _ = FileHandler.RemoveUserFromFileAsync(filePath, contentTosave);
    //        Console.WriteLine("sparningsprocessen är klar.");
    //    }
    //}
    public class MyClass
    {
        public static void Save(string filePath, string content)
        {
            // Här använder du din befintliga Save-metod för att spara innehållet till filen.
            using (var s = new StreamWriter(File.Create(filePath)))
            {
                s.WriteLine(content);
            }
        }

    }
    public class FileHandler
    {
        public static async Task<string> ReadFromFileAsync(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string content = await reader.ReadToEndAsync();
                    Console.WriteLine("Detta info kommer från filen.");
                    return content;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel Inträffade, {ex.Message}");
                return null!;
            }
        }

        public static void Save(string filePath, string content)
        {
            // Här använder du din befintliga Save-metod för att spara innehållet till filen.
            using (var s = new StreamWriter(filePath))
            {
                s.WriteLine(content);
            }
        }

        public static async Task RemoveUserFromFileAsync(string filePath, string usernameToRemove)
        {
            try
            {
                // läs innehålleet i file
                List<string> line = (await File.ReadAllLinesAsync(filePath)).ToList();
                
                     //fileterar bort användare med matchande anvädername 
                List<string>updateLines=line.Where (line => ! line.Contains(usernameToRemove)).ToList();

                await File.WriteAllLinesAsync(filePath, updateLines);
                Console.WriteLine($"Användaren med anvädarnamn {usernameToRemove} har targist bort från filen ");

            }  
            catch (Exception ex)
            {
                Console.WriteLine($" Ett fel inträffade : {ex.Message}");

            }
        }
    }




}
public class MainProgram
{
    public static async Task Main(string[] args)
    {
        try
        {
            string contentToSave = "Detta info kommer att sparas i den här filen...";
            string filePath = "filelove.txt";

            FileHandler fileHandler = new FileHandler();
            await FileHandlar.SaveToFileAsync(filePath, contentToSave);

            // Ta bort en användare från filen
            string usernameToRemove = "Mainnprogram";
            await FileHandler.RemoveUserFromFileAsync(filePath, usernameToRemove);

            Console.WriteLine("Sparningsprocessen är klar.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ett fel inträffade: {ex.Message}");
        }
    }


}















