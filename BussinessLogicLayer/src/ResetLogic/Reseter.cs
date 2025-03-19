public class Reseter
{
    private readonly IWordsFetcherLogic _wordsFetcherLogic;
    private readonly IAttemptsResetter _attemptsResetter;
    private readonly ITextBoxResetter _textBoxResetter;
    private readonly IButtonResetter _buttonResetter;
    private readonly ILabelResetter _labelResetter;

    public WordSelectorLogic WordSelectorLogic { get; private set; }

    public Reseter
        (
        IWordsFetcherLogic wordsFetcherLogic,
        IAttemptsResetter attemptsResetter, 
        ITextBoxResetter textBoxResetter, 
        IButtonResetter buttonResetter, 
        ILabelResetter labelResetter)
    {
        _wordsFetcherLogic = wordsFetcherLogic;
        _attemptsResetter = attemptsResetter;
        _textBoxResetter = textBoxResetter;
        _buttonResetter = buttonResetter;
        _labelResetter = labelResetter;
    }

    public void ResetApp()
    {
        // Reset selected word
        WordSelectorLogic = new WordSelectorLogic(_wordsFetcherLogic.WordsList);

        // Reset lives
        _attemptsResetter.ResetAttempts(0);

        // Reset text boxes
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                _textBoxResetter.ResetTextBox(row, col, "", "Black");
            }
        }

        // Reset buttons
        _buttonResetter.ResetButton(true, "#5a5a5a");

        // Reset label
        _labelResetter.ResetLabel("", false);
    }
}