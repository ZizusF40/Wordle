public class SelectedWordLogic
{
    private string selectedWord = "";

    public string SelectedWord { get => selectedWord; }

    public SelectedWordLogic(List<string> bufferList)
    {
        Random random = new Random();

        int index = random.Next(bufferList.Count);

        selectedWord = bufferList[index];
    }
}

