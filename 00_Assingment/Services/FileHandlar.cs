


namespace _00_Assingment.Services
{

    public class FileHandlar
    {
        public static async Task SaveToFileAsync(string filePath, string content)
        {
            try
            {
                using StreamWriter writer = new StreamWriter(filePath);
                //await Task.Delay(1000); 
                await writer.WriteAsync(content);
                Console.WriteLine("Informationen har sparats i filen.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel inträffade: {ex.Message}");
            }
        }
    }

    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                string contentToSave = "Detta info kommer att sparas i den här filen...";
                string filePath = "filelove.text";

                FileHandlar fileHandler = new FileHandlar();
                await FileHandlar.SaveToFileAsync(filePath, contentToSave);

                Console.WriteLine("Sparningsprocessen är klar.");

            } catch (Exception ex)
            {
                Console.WriteLine(""); 
            }
           
        }


    }
}






