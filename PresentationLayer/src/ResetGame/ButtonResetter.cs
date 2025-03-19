using System.Windows.Controls;
using System.Windows.Media;

public class ButtonResetter : IButtonResetter
{
    private readonly List<Button> _buttons;

    public ButtonResetter(List<Button> buttons)
    {
        _buttons = buttons;
    }

    public void ResetButton(bool isEnabled, string backgroundColor)
    {
        foreach (var button in _buttons)
        {
            button.IsEnabled = isEnabled;
            button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(backgroundColor));
        }
    }
}