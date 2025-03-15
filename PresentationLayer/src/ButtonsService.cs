using System.Windows.Controls;
using System.Windows.Media;

public interface IButtonsService
{
    void HighlightButtonsGreen(char buttonChar);
    void HighlightButtonsYellow(char buttonChar);
}

public class ButtonsService : IButtonsService
{
    private List<Button> buttons = new List<Button>();

    public ButtonsService(List<Button> buttons)
    {
        this.buttons = buttons;
    }

    public void HighlightButtonsGreen(char buttonChar)
    {
        foreach (var button in buttons)
        {
            if (Convert.ToString(button.Content).Contains(buttonChar))
            {
                button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00FF00"));
            }
        }
    }

    public void HighlightButtonsYellow(char buttonChar)
    {
        foreach (var button in buttons)
        {
            if (Convert.ToString(button.Content).Contains(buttonChar))
            {
                button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF00"));
            }
        }
    }
}


