public class WordSelectorLogic
{
    private List<string> wordsList;

    private string selectedWord = "";

    public string SelectedWord { get => selectedWord; }

    public WordSelectorLogic(List<string> wordsList)
    {
        this.wordsList = wordsList;
        EstablishWord();
    }

    private void EstablishWord()
    {
        Random random = new Random();

        int index = random.Next(wordsList.Count);

        selectedWord = wordsList[index];
    }
}

