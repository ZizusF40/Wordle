public class IndexLogic
{
    public int IndexFirstEmptyTextBox(string[] textBoxesText)
    {
        for (int i = 0; i < 5; i++)
        {
            if (string.IsNullOrEmpty(textBoxesText[i]))
            {
                return i; //return the index of the first empty text box
            }
        }
        return -1; // No empty text box found
    }
}