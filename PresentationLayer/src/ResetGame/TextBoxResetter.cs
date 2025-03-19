using System.Windows.Controls;
using System.Windows.Media;

public class TextBoxResetter : ITextBoxResetter
{
    private readonly TextBox[,] _textBoxes;

    public TextBoxResetter(TextBox[,] textBoxes)
    {
        _textBoxes = textBoxes;
    }

    public void ResetTextBox(int row, int col, string text, string backgroundColor)
    {
        _textBoxes[row, col].Text = text;
        _textBoxes[row, col].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(backgroundColor));
    }
}
