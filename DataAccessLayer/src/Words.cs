using System.Text.Json;

public class Words
{
    public List<string> GetAllWords()
    {
        // Path to the JSON file
        //string baseDir = Directory.GetCurrentDirectory();

        //string filePath = Path.Combine(baseDir, @"json\words.json");

        string filePath = @"D:\Solutions\Wordle\DataAccessLayer\json\words.json";

        // Read the JSON file// Read the JSON file
        string jsonString = File.ReadAllText(filePath);

        // Deserialize the JSON into a list of strings
        List<string> words = JsonSerializer.Deserialize<List<string>>(jsonString);

        if (words == null || words.Count == 0)
        {
            throw new InvalidOperationException("The JSON file is empty or does not contain any words.");
        }

        return words;
    }
}
