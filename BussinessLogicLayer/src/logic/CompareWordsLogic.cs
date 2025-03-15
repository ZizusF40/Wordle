using Microsoft.VisualBasic;

public class CompareWordsLogic
{
    Words words = new Words();

    public bool CompareWords(string userWord)
    {
        if (words.GetAllWords().ConvertAll(s => s.ToUpper()).Contains(userWord))
        {
            return true; // The word is valid
        }

        return false; // The word is invalid
    }
}

