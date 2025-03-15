public class CompareWordsLogic
{
    Words words = new Words();

    public bool CompareWords(string userWord)
    {
        if (words.GetAllWords().Contains(userWord))
        {
            return true; // The word is valid
        }

        return false; // The word is invalid
    }
}

