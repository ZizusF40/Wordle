public class CompareWordsLogic
{
    private List<string> wordsList = new List<string>();

    public CompareWordsLogic(List<string> wordsList)
    {
        this.wordsList = wordsList;
    }

    public bool CompareWords(string userWord)
    {
        if (wordsList.ConvertAll(s => s.ToUpper()).Contains(userWord))
        {
            return true; // The word is valid
        }

        return false; // The word is invalid
    }
}