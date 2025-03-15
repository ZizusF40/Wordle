using System.Windows.Controls;
using System.Windows.Media;

public class ButtonsHighlighterService
{
    private List<Button> buttons = new List<Button>();

    public ButtonsHighlighterService(List<Button> buttons)
    {
        this.buttons = buttons;
    }

    public void HighlightButtons(char buttonChar, string color)
    {
        foreach (var button in buttons)
        {
            if (Convert.ToString(button.Content).Contains(buttonChar))
            {
                button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
            }
        }
    }
}


