﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
namespace PresentationLayer;

/// <summary>
/// Interaction logic for WordleUI.xaml
/// </summary>
public partial class WordleUI : Window
{
    WordsFetcherLogic wordsFetcherLogic = new WordsFetcherLogic();

    AttemptsLogic attempts = new AttemptsLogic();

    SelectedWordLogic selectedWordLogic = new SelectedWordLogic(new List<string>() { string.Empty });

    public WordleUI()
    {
        InitializeComponent();
    }
    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        await wordsFetcherLogic.GetWordsAsync();
        Intialization();
    }

    private void Intialization()
    {
        showTheWordLabel.Visibility = Visibility.Hidden;
        attempts = new AttemptsLogic();
        selectedWordLogic = new SelectedWordLogic(wordsFetcherLogic.WordsList);
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Button button = (Button)sender;
        ButtonsAlphabetTextService buttonsAlphabetTextService = new ButtonsAlphabetTextService();

        buttonsAlphabetTextService.TextBoxes = GetTextBoxesAndUserWord().Item1;
        buttonsAlphabetTextService.Letter = button.Content?.ToString() ?? string.Empty;
        buttonsAlphabetTextService.Lives = attempts.Lives;
        buttonsAlphabetTextService.WriteLetterToTextBox();
    }

    private void EnterButton_Click(object sender, RoutedEventArgs e)
    {
        if (attempts.Lives >= 6)
        {
            return;
        }

        List<Button> buttons = new List<Button> { Q, W, E, R, T, Y, U, I, O, P, A, S, D, F, G, H, J, K, L, Z, X, C, V, B, N, M };

        string userWord = GetTextBoxesAndUserWord().Item2;

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

        CompareWordsLogic compareWordsLogic = new CompareWordsLogic(wordsFetcherLogic.WordsList);

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
                GetTextBoxesAndUserWord().Item1[attempts.Lives, i].Background = Brushes.Green;
            }
            return;
        }

        List<(char, int)> samePositions = guessingLogic.SamePosition;

        List<(char, int)> presentButNotSamePositions = guessingLogic.PresentButNotSamePosition;

        List<(char, int)> notPresent = guessingLogic.NotPresent;

        ButtonsHighlighterService buttonsHighlighterService = new ButtonsHighlighterService(buttons);

        for (int i = 0; i < samePositions.Count; i++)
        {
            GetTextBoxesAndUserWord().Item1[attempts.Lives, samePositions[i].Item2].Background = Brushes.Green;
            buttonsHighlighterService.HighlightButtons(samePositions[i].Item1, "#FF008000");
        }
        for (int i = 0; i < presentButNotSamePositions.Count; i++)
        {
            Color customColor = (Color)ColorConverter.ConvertFromString("#c4c629");
            SolidColorBrush customBrush = new SolidColorBrush(customColor);

            GetTextBoxesAndUserWord().Item1[attempts.Lives, presentButNotSamePositions[i].Item2].Background = customBrush;
            buttonsHighlighterService.HighlightButtons(presentButNotSamePositions[i].Item1, "#c4c629");
        }


        for (int i = 0; i < notPresent.Count; i++)
        {
            buttonsHighlighterService.HighlightButtons(notPresent[i].Item1, "#f1ecec");
        }

        attempts.Lives++;

        if (attempts.Lives > 5)
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
        if (attempts.Lives >= 6)
        {
            return;
        }

        IndexLogic indexLogic = new IndexLogic();

        int index = indexLogic.IndexFirstEmptyTextBox(GetTextBoxesAndUserWord().Item3, attempts.Lives);

        if (index == -1 && GetTextBoxesAndUserWord().Item1[attempts.Lives, 4].Text != "") GetTextBoxesAndUserWord().Item1[attempts.Lives, 4].Text = "";
        else if (!string.IsNullOrEmpty(GetTextBoxesAndUserWord().Item1[attempts.Lives, 0].Text)) GetTextBoxesAndUserWord().Item1[attempts.Lives, index - 1].Text = "";

    }
    
    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        IndexLogic indexLogic = new IndexLogic();

        // Handle key presses
        if (e.Key >= Key.A && e.Key <= Key.Z) // Only allow letters A-Z
        {
            int index = indexLogic.IndexFirstEmptyTextBox(GetTextBoxesAndUserWord().Item3, attempts.Lives);

            // Append the pressed key to the TextBox
            if (index != -1)
            {
                GetTextBoxesAndUserWord().Item1[attempts.Lives, index].Text += e.Key.ToString();
            }
        }

        if (e.Key == Key.Enter)
        {
            EnterButton_Click(sender, e);

            e.Handled = true;
        }

        if (e.Key == Key.Back)
        {
            BackSpace_Click(sender, e);

            e.Handled = true;
        }

        if (e.Key == Key.Escape)
        {
            List<Button> buttons = new List<Button> 
            { Q, W, E, R, T, Y, U, I, O, P, A, S, D, F, G, H, J, K, L, Z, X, C, V, B, N, M , EnterButton, BackSpace};

            Reseter reseter = new Reseter
                (buttons, showTheWordLabel, GetTextBoxesAndUserWord().Item1, wordsFetcherLogic.WordsList,
                ref attempts, ref selectedWordLogic);
            reseter.ResetApp();

            e.Handled = true;
        }
    }

    private (TextBox[,], string, string[,]) GetTextBoxesAndUserWord()
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

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < 5; i++)
        {
            if (attempts.Lives < 6)
            {
                result.Append(textBoxesObj[attempts.Lives, i].Text);
            }
        }

        string[,] texts = new string[6, 5];

        for (int i = 0; i < 5; i++)
        {
            if (attempts.Lives < 6)
            {
                texts[attempts.Lives, i] = textBoxesObj[attempts.Lives, i].Text;
            }
        }

        return
        (
            textBoxesObj, // return array of textbox objects
            result.ToString().Trim(), // return the text from textbox in a entire string
            texts // return characters from textbox in a array of string
        ); 
    }
}