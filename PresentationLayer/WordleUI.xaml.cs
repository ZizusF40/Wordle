using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace PresentationLayer;

/// <summary>
/// Interaction logic for WordleUI.xaml
/// </summary>
public partial class WordleUI : Window
{
    SelectedWordLogic selectedWordLogic = new SelectedWordLogic();

    ButtonsAlphabetTextService buttonsAlphabetTextService = new ButtonsAlphabetTextService();

    public WordleUI()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Button button = (Button)sender;

        buttonsAlphabetTextService.TextBoxes = new[] { _1letter, _2letter, _3letter, _4letter, _5letter };
        buttonsAlphabetTextService.Letter = button.Content?.ToString() ?? string.Empty;
        buttonsAlphabetTextService.WriteLetterToTextBox();
    }

    private void EnterButton_Click(object sender, RoutedEventArgs e)
    {
        TextBox[] textBoxesObj = { _1letter, _2letter, _3letter, _4letter, _5letter };

        List<Button> buttons = new List<Button> { Q, W, E, R, T, Y, U, I, O, P, A, S, D, F, G, H, J, K, L, Z, X, C, V, B, N, M };

        string userWord = string.Concat(textBoxesObj.Select(tb => tb.Text).ToArray());

        string selectedWord = selectedWordLogic.SelectedWord;

        CompareWordsLogic compareWordsLogic = new CompareWordsLogic();

        if (!compareWordsLogic.CompareWords(userWord))
        {
            PopupService popupService = new PopupService(Popup, PopupTextBlock);

            popupService.ShowPopup("Not in word list");

            return;
        }

        if (userWord.Equals(selectedWord.ToUpper()))
        {
            foreach (var button in buttons)
            {
                button.IsEnabled = false;
                EnterButton.IsEnabled = false;
                BackSpace.IsEnabled = false;
            }

            foreach (var textBox in textBoxesObj)
            {
                textBox.Background = Brushes.Green;
            }
            return;
        }

        GuessingLogic guessingLogic = new GuessingLogic();

        try
        {
            guessingLogic.CheckCharacters(userWord, selectedWord);
        }
        catch (IndexOutOfRangeException)
        {
            PopupService popupService = new PopupService(Popup, PopupTextBlock);

            popupService.ShowPopup("Not enough letters");
        }

        List<(char, int)> samePositions = guessingLogic.SamePosition;

        List<(char, int)> presentButNotSamePositions = guessingLogic.PresentButNotSamePosition;

        List<(char, int)> notPresent = guessingLogic.NotPresent;

        bool isNotCorrect = true;

        ButtonsHighlighterService buttonsHighlighterService = new ButtonsHighlighterService(buttons);

        for (int i = 0; i < samePositions.Count; i++)
        {
            textBoxesObj[samePositions[i].Item2].Background = Brushes.Green;
            buttonsHighlighterService.HighlightButtons(samePositions[i].Item1, "#FF00FF00");
            isNotCorrect = false;
        }

        if (isNotCorrect)
        {
            for (int i = 0; i < presentButNotSamePositions.Count; i++)
            {
                textBoxesObj[presentButNotSamePositions[i].Item2].Background = Brushes.Yellow;
                buttonsHighlighterService.HighlightButtons(presentButNotSamePositions[i].Item1, "#FFFFFF00");
            }
        }

        for (int i = 0; i < notPresent.Count; i++)
        {
            buttonsHighlighterService.HighlightButtons(notPresent[i].Item1, "#f1ecec");
        }
    }

    private void BackSpace_Click(object sender, RoutedEventArgs e)
    {
        TextBox[] textBoxesObj = { _1letter, _2letter, _3letter, _4letter, _5letter };

        IndexLogic indexLogic = new IndexLogic();

        int index = indexLogic.IndexFirstEmptyTextBox(textBoxesObj.Select(tb => tb.Text).ToArray());

        if (index == -1 && textBoxesObj[4].Text != "") textBoxesObj[4].Text = "";
        else if (!string.IsNullOrEmpty(textBoxesObj[0].Text)) textBoxesObj[index - 1].Text = "";
    }
}

