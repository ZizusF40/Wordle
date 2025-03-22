using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class WordApiService
{
    private static readonly HttpClient client = new HttpClient();
    private HashSet<string> words = new HashSet<string>();
    public async Task<List<string>> GetWordsAsync()
    {
        await GetFirstList();
        await GetSecondList();
        GetThirdList();

        return words.ToList();
    }

    private async Task GetFirstList()
    {
        string apiUrl = "https://random-word-api.herokuapp.com/word?number=10000&length=5";

        try
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            // Deserialize JSON response to a list of strings
            words = JsonConvert.DeserializeObject<HashSet<string>>(responseBody);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
        }
    }

    private async Task GetSecondList()
    {
        string url = "https://api.datamuse.com/words?sp=?????&max=10000";

        try
        {
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                JArray wordsArray = JArray.Parse(jsonResponse);
                foreach (var word in wordsArray)
                {
                    string wordText = word["word"].ToString();
                    if (wordText.Length == 5) // Ensure the word is exactly 5 letters
                    {
                        words.Add(wordText);
                    }
                }

                Console.WriteLine($"Fetched {words.Count} unique 5-letter words.");
                // Use the words list as needed
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }

    private void GetThirdList() 
    {
        IWordsLocalList localList = new WordsLocalList();
        foreach (var word in localList.GetAllWords())
        {
            words.Add(word);
        }
    }
}
