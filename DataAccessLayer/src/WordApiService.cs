using Newtonsoft.Json;

public class WordApiService
{
    private static readonly HttpClient client = new HttpClient(); // to delete static for test

    public async Task<List<string>> GetWordsAsync()
    {
        string apiUrl = "https://random-word-api.herokuapp.com/word?number=10000&length=5";

        try
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            // Deserialize JSON response to a list of strings
            List<string> words = JsonConvert.DeserializeObject<List<string>>(responseBody);
            return words;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
            return null;
        }
    }
}
