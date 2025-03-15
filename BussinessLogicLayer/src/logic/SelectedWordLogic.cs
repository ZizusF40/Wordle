public class SelectedWordLogic
{
    private string selectedWord = "";

    public string SelectedWord { get => selectedWord; }

    public SelectedWordLogic()
    {
		try
		{
            Words words = new Words();

            List<string> wordsList = words.GetAllWords();

            Random random = new Random();

            int randomIndex = random.Next(wordsList.Count);

            selectedWord = wordsList[randomIndex];
        }
		catch (InvalidOperationException ex)
		{
            Console.WriteLine(ex.Message);
        }
    }
}

