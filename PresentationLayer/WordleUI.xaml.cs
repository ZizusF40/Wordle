using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace PresentationLayer;

/// <summary>
/// Interaction logic for WordleUI.xaml
/// </summary>
public partial class WordleUI : Window
{
    AttemptsLogic attempts = new AttemptsLogic();

    SelectedWordLogic selectedWordLogic = new SelectedWordLogic();

    public WordleUI()
    {
        InitializeComponent();
        showTheWordLabel.Visibility = Visibility.Hidden;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Button button = (Button)sender;
        ButtonsAlphabetTextService buttonsAlphabetTextService = new ButtonsAlphabetTextService();

        buttonsAlphabetTextService.TextBoxes = new[,]
        {
            { _1letter, _2letter, _3letter, _4letter, _5letter },
            { _1letter2Try, _2letter2Try, _3letter2Try, _4letter2Try, _5letter2Try },
            { _1letter3Try, _2letter3Try, _3letter3Try, _4letter3Try, _5letter3Try },
            { _1letter4Try, _2letter4Try, _3letter4Try, _4letter4Try, _5letter4Try },
            { _1letter5Try, _2letter5Try, _3letter5Try, _4letter5Try, _5letter5Try },
            { _1letter6Try, _2letter6Try, _3letter6Try, _4letter6Try, _5letter6Try }
        };
        buttonsAlphabetTextService.Letter = button.Content?.ToString() ?? string.Empty;
        buttonsAlphabetTextService.Lives = attempts.Lives;
        buttonsAlphabetTextService.WriteLetterToTextBox();
    }

    private void EnterButton_Click(object sender, RoutedEventArgs e)
    {
        TextBox[,] textBoxesObj =
        {
            { _1letter, _2letter, _3letter, _4letter, _5letter },
            { _1letter2Try, _2letter2Try, _3letter2Try, _4letter2Try, _5letter2Try },
            { _1letter3Try, _2letter3Try, _3letter3Try, _4letter3Try, _5letter3Try },
            { _1letter4Try, _2letter4Try, _3letter4Try, _4letter4Try, _5letter4Try },
            { _1letter5Try, _2letter5Try, _3letter5Try, _4letter5Try, _5letter5Try },
            { _1letter6Try, _2letter6Try, _3letter6Try, _4letter6Try, _5letter6Try }
        };

        string GetTextBoxTexts(TextBox[,] textBoxesObj)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < 5; i++)
            {
                result.Append(textBoxesObj[attempts.Lives, i].Text);
            }

            return result.ToString().Trim(); // Remove the trailing space
        }

        List<Button> buttons = new List<Button> { Q, W, E, R, T, Y, U, I, O, P, A, S, D, F, G, H, J, K, L, Z, X, C, V, B, N, M };

        string userWord = GetTextBoxTexts(textBoxesObj);

        string selectedWord = selectedWordLogic.SelectedWord.ToUpper();

        GuessingLogic guessingLogic = new GuessingLogic();

        try
        {
            guessingLogic.CheckCharacters(userWord, selectedWord);
        }
        catch (IndexOutOfRangeException)
        {
            PopupService popupService = new PopupService(Popup, PopupTextBlock);

            popupService.ShowPopup("Not enough letters");

            return;
        }

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

            for (int i = 0; i < 5; i++)
            {
                textBoxesObj[attempts.Lives, i].Background = Brushes.Green;
            }
            return;
        }

        List<(char, int)> samePositions = guessingLogic.SamePosition;

        List<(char, int)> presentButNotSamePositions = guessingLogic.PresentButNotSamePosition;

        List<(char, int)> notPresent = guessingLogic.NotPresent;

        bool isNotCorrect = true;

        ButtonsHighlighterService buttonsHighlighterService = new ButtonsHighlighterService(buttons);

        for (int i = 0; i < samePositions.Count; i++)
        {
            textBoxesObj[attempts.Lives, samePositions[i].Item2].Background = Brushes.Green;
            buttonsHighlighterService.HighlightButtons(samePositions[i].Item1, "#FF00FF00");
            isNotCorrect = false;
        }

        if (isNotCorrect)
        {
            for (int i = 0; i < presentButNotSamePositions.Count; i++)
            {
                textBoxesObj[attempts.Lives, presentButNotSamePositions[i].Item2].Background = Brushes.Yellow;
                buttonsHighlighterService.HighlightButtons(presentButNotSamePositions[i].Item1, "#FFFFFF00");
            }
        }

        for (int i = 0; i < notPresent.Count; i++)
        {
            buttonsHighlighterService.HighlightButtons(notPresent[i].Item1, "#f1ecec");
        }
        attempts.Lives++;

        if (attempts.Lives >= 6)
        {
            foreach (var button in buttons)
            {
                button.IsEnabled = false;
                EnterButton.IsEnabled = false;
                BackSpace.IsEnabled = false;
                showTheWordLabel.Visibility = Visibility.Visible;
                showTheWordLabel.Content = selectedWord;
            }
        }
    }

    private void BackSpace_Click(object sender, RoutedEventArgs e)
    {
        TextBox[,] textBoxesObj =
        {
            { _1letter, _2letter, _3letter, _4letter, _5letter },
            { _1letter2Try, _2letter2Try, _3letter2Try, _4letter2Try, _5letter2Try },
            { _1letter3Try, _2letter3Try, _3letter3Try, _4letter3Try, _5letter3Try },
            { _1letter4Try, _2letter4Try, _3letter4Try, _4letter4Try, _5letter4Try },
            { _1letter5Try, _2letter5Try, _3letter5Try, _4letter5Try, _5letter5Try },
            { _1letter6Try, _2letter6Try, _3letter6Try, _4letter6Try, _5letter6Try }
        };

        IndexLogic indexLogic = new IndexLogic();

        int index = indexLogic.IndexFirstEmptyTextBox(GetTextBoxTexts(textBoxesObj), attempts.Lives);

        if (index == -1 && textBoxesObj[attempts.Lives, 4].Text != "") textBoxesObj[attempts.Lives, 4].Text = "";
        else if (!string.IsNullOrEmpty(textBoxesObj[attempts.Lives, 0].Text)) textBoxesObj[attempts.Lives, index - 1].Text = "";

        string[,] GetTextBoxTexts(TextBox[,] textBoxesObj)
        {
            string[,] texts = new string[6, 5];

            for (int i = 0; i < 5; i++)
            {
                texts[attempts.Lives, i] = textBoxesObj[attempts.Lives, i].Text;
            }

            return texts;
        }
    }
}