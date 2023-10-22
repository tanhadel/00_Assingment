
namespace _00_Assingment.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;

    public class FileHandlar
    {
        // Metod för att spara innehåll i en fil
        // om ett fel uppstår ska  ut en felmeddelande.
        public static void SaveToFile(string filePath, string content)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                  writer.WriteLine(content);
                    // skriv innehållet i en file
                    
                }
                Console.WriteLine("Informationen har sparats i filen.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel inträffade: {ex.Message}");             
            }
        }
           // metod för att läsa innehållet från en fil 
        public static string ReadFromFile(string filePath)
        {
            // läs innehåll från file
            // retunera inläst innehåll
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string content = reader.ReadToEnd();             
                    Console.WriteLine("Detta info kommer från filen.");
                    return content;      
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel Inträffade, {ex.Message}");
                // om ett fel uppstår ska  ut en felmeddelande.
                // Retunera null om det uppstår ett fel.

                return null!;  
            }
        }    
    }
}














