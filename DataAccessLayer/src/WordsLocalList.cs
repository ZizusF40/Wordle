using System.Text.Json;

public class WordsLocalList
{
    public HashSet<string> GetAllWords()
    {
        JsonResourceLoader jsonResourceLoader = new JsonResourceLoader();

        // Deserialize the JSON into a list of strings
        HashSet<string> words = JsonSerializer.Deserialize<HashSet<string>>(jsonResourceLoader.LoadJSON());

        if (words == null || words.Count == 0)
        {
            throw new InvalidOperationException("The JSON file is empty or does not contain any words.");
        }

        return words;
    }
}
