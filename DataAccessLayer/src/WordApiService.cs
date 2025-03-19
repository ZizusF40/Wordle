using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class WordApiService
{
    private static readonly HttpClient client = new HttpClient(); // to delete static for test

    public async Task<List<string>> GetWordsAsync()
    {
        string apiUrl = "https://random-word-api.herokuapp.com/word?number=10000&length=5";

        //https://developer.wordnik.com/
        //email = xabatoy247@barodis.com
        //username = Xabatoy247
        //password = J(eIb4Lp3rcH)Uq*

        //List<string> words = new List<string>();
        HashSet<string> words = new HashSet<string>();

        try
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            // Deserialize JSON response to a list of strings
            words = JsonConvert.DeserializeObject<HashSet<string>>(responseBody);
            //return words;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
        }

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

        WordsLocalList wordsLocalList = new WordsLocalList();
        foreach (var word in wordsLocalList.GetAllWords())
        {
            words.Add(word);
        }

        return words.ToList();
    }
}
