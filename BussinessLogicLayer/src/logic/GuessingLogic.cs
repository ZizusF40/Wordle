public class GuessingLogic
{
    private List<(char, int)> samePosition = new List<(char, int)>();
    private List<(char, int)> presentButNotSamePosition = new List<(char, int)>();

    public List<(char, int)> SamePosition { get => samePosition;}
    public List<(char, int)> PresentButNotSamePosition { get => presentButNotSamePosition; }

    public void CheckCharacters(string userLetter, string selectedWord)
    {
        for (int i = 0; i < 5; i++)
        {
            char userChar = userLetter[i];
            char selectedWordChar = selectedWord[i];

            bool isSame = Equals(char.ToUpper(userChar), char.ToUpper(selectedWordChar));

            if (isSame)
            {
                samePosition.Add((userChar, i));
            }
            else if (selectedWord.ToUpper().Contains(char.ToUpper(userChar)))
            {
                presentButNotSamePosition.Add((userChar, i));
            }
        }
    }
}
