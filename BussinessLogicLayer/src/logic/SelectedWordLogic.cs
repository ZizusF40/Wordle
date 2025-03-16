public class SelectedWordLogic
{
    private string selectedWord = "";

    public string SelectedWord { get => selectedWord; }

    public SelectedWordLogic()
    {
        Words words = new Words();

        List<string> bufferList = words.GetAllWords();

        Random random = new Random();

        int index = random.Next(bufferList.Count);

        selectedWord = bufferList[index];
    }
}

