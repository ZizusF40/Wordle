public class CompareWordsLogic
{
    public bool CompareWords(string userWord)
    {
        Words words = new Words();

        if (words.GetAllWords().ConvertAll(s => s.ToUpper()).Contains(userWord))
        {
            return true; // The word is valid
        }

        return false; // The word is invalid
    }
}