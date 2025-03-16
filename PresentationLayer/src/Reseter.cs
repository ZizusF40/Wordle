using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

public class Reseter
{
    private List<Button> _buttons;

    //AttemptsLogic attempts;

    //SelectedWordLogic selectedWordLogic;

    private TextBox[,] _textBoxes;

    public Reseter
        (List<Button> buttons, Label showTheWordLabel , TextBox[,] textBoxes, ref AttemptsLogic attempts, ref SelectedWordLogic selectedWordLogic)
    {
        _buttons = buttons;
        showTheWordLabel.Visibility = Visibility.Hidden;
        _textBoxes = textBoxes;
        attempts = new AttemptsLogic();
        selectedWordLogic = new SelectedWordLogic();
    }

    public void ResetApp()
    {
        for (int lines = 0; lines < 6; lines++)
        {
            for (int col = 0; col < 5; col++)
            {
                _textBoxes[lines, col].Text = "";
                _textBoxes[lines, col].Background = Brushes.Black;
            }
        }

        foreach (var button in _buttons)
        {
            button.IsEnabled = true;

            Color customColor = (Color)ColorConverter.ConvertFromString("#5a5a5a");
            SolidColorBrush grayBrush = new SolidColorBrush(customColor);
            button.Background = grayBrush;
        }
    }
}

