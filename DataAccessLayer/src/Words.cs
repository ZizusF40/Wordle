using System.Text.Json;

public class Words
{
    public List<string> GetAllWords()
    {
        JsonResourceLoader jsonResourceLoader = new JsonResourceLoader();

        // Deserialize the JSON into a list of strings
        List<string> words = JsonSerializer.Deserialize<List<string>>(jsonResourceLoader.LoadJSON());

        if (words == null || words.Count == 0)
        {
            throw new InvalidOperationException("The JSON file is empty or does not contain any words.");
        }

        return words;
    }
}
