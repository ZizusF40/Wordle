using System.Windows;
using System.Windows.Controls;

public class LabelResetter : ILabelResetter
{
    private readonly Label _label;

    public LabelResetter(Label label)
    {
        _label = label;
    }

    public void ResetLabel(string text, bool isVisible)
    {
        _label.Content = text;
        _label.Visibility = isVisible ? Visibility.Visible : Visibility.Hidden;
    }
}