public interface IWordsFetcherLogic
{
    List<string> WordsList { get; set; }

    Task GetWordsAsync();
}

