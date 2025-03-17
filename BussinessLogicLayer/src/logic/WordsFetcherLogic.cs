public class WordsFetcherLogic
{
    public List<string> WordsList { get; set; } = new List<string>();

    WordApiService wordApiService = new WordApiService();

    public async Task GetWordsAsync()
    {
        WordsList = await wordApiService.GetWordsAsync();
    }
}

