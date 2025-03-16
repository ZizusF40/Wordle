public static class GetWordsListLogic
{
    public static List<string> WordsList { get; set; } = new List<string>();

    public static async Task InitializeAsync()
    {
        HashSet<string> combination = new HashSet<string>();

        for (int i = 0; i < 10; i++)
        {
            try
            {
                HashSet<string> words = await WordsAPI.GetUniqueFiveLetterWordsAsync(100);

                combination.UnionWith(words);

                //WordsList = new List<string>(words);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching words: {ex.Message}");
            }
        }
        WordsList = combination.ToList();
    }
}