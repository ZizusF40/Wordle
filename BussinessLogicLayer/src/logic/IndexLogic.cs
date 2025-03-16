public class IndexLogic
{
    public int IndexFirstEmptyTextBox(string[,] textBoxesText, int lives)
    {
        for (int i = 0; i < 5; i++)
        {
            if (string.IsNullOrEmpty(textBoxesText[lives, i]))
            {
                return i; //return the index of the first empty text box
            }
        }
        return -1; // No empty text box found
    }
}