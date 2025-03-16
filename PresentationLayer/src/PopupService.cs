using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;

public class PopupService
{
    private Popup popup;

    private TextBlock popupTextBlock;

    public PopupService(Popup popup, TextBlock popupTextBlock)
    {
        this.popup = popup;
        this.popupTextBlock = popupTextBlock;
    }

    public void ShowPopup(string message)
    {
        popup.IsOpen = true;
        popupTextBlock.Text = message;
        // Create a timer to close the popup after 3 seconds
        DispatcherTimer timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromSeconds(3);
        timer.Tick += (sender, e) =>
        {
            popup.IsOpen = false;
            timer.Stop();
        };
        timer.Start();
    }
}

