using System.Text.Json;

public static class WordsAPI
{
    public static async Task<HashSet<string>> GetUniqueFiveLetterWordsAsync(int count)
    {
        // Datamuse API endpoint for fetching 5-letter words
        string apiUrl = "https://api.datamuse.com/words?sp=?????&max=1000"; // Fetch up to 1000 words

        // Create a HashSet to store unique words
        HashSet<string> uniqueWords = new HashSet<string>();

        // Create an HttpClient instance
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Send a GET request to the API
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                // Ensure the request was successful
                response.EnsureSuccessStatusCode();

                // Read the JSON content of the response
                string jsonContent = await response.Content.ReadAsStringAsync();

                // Parse the JSON response to extract words
                JsonDocument jsonDocument = JsonDocument.Parse(jsonContent);
                JsonElement root = jsonDocument.RootElement;

                // Extract words from the JSON array and add them to the HashSet
                for (int i = 0; i < root.GetArrayLength(); i++)
                {
                    string word = root[i].GetProperty("word").GetString();
                    if (word.Length == 5) // Ensure the word is exactly 5 letters
                    {
                        uniqueWords.Add(word);
                        if (uniqueWords.Count >= count) // Stop when we have enough words
                        {
                            break;
                        }
                    }
                }

                return uniqueWords;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error retrieving data: {ex.Message}");
                return uniqueWords;
            }
        }
    }
}

