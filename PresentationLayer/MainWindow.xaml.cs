using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace PresentationLayer;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    SelectedWordLogic selectedWordLogic = new SelectedWordLogic();

    IndexLogic completeTextBoxLogic = new IndexLogic();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Q_Click(object sender, RoutedEventArgs e)
    {
        var textBoxes = new[] { _1letter, _2letter, _3letter, _4letter, _5letter };

        int index = completeTextBoxLogic.IndexFirstEmptyTextBox(textBoxes.Select(tb => tb.Text).ToArray());

        if (index != -1)
        {
            textBoxes[index].Text = "Q";
        }
    }

    private void W_Click(object sender, RoutedEventArgs e)
    {
        var textBoxes = new[] { _1letter, _2letter, _3letter, _4letter, _5letter };

        int index = completeTextBoxLogic.IndexFirstEmptyTextBox(textBoxes.Select(tb => tb.Text).ToArray());

        if (index != -1)
        {
            textBoxes[index].Text = "W";
        }
    }

    private void E_Click(object sender, RoutedEventArgs e)
    {
        var textBoxes = new[] { _1letter, _2letter, _3letter, _4letter, _5letter };

        int index = completeTextBoxLogic.IndexFirstEmptyTextBox(textBoxes.Select(tb => tb.Text).ToArray());

        if (index != -1)
        {
            textBoxes[index].Text = "E";
        }
    }

    private void R_Click(object sender, RoutedEventArgs e)
    {
        var textBoxes = new[] { _1letter, _2letter, _3letter, _4letter, _5letter };

        int index = completeTextBoxLogic.IndexFirstEmptyTextBox(textBoxes.Select(tb => tb.Text).ToArray());

        if (index != -1)
        {
            textBoxes[index].Text = "R";
        }
    }

    private void T_Click(object sender, RoutedEventArgs e)
    {
        var textBoxes = new[] { _1letter, _2letter, _3letter, _4letter, _5letter };

        int index = completeTextBoxLogic.IndexFirstEmptyTextBox(textBoxes.Select(tb => tb.Text).ToArray());

        if (index != -1)
        {
            textBoxes[index].Text = "T";
        }
    }

    private void Y_Click(object sender, RoutedEventArgs e)
    {
        var textBoxes = new[] { _1letter, _2letter, _3letter, _4letter, _5letter };

        int index = completeTextBoxLogic.IndexFirstEmptyTextBox(textBoxes.Select(tb => tb.Text).ToArray());

        if (index != -1)
        {
            textBoxes[index].Text = "Y";
        }
    }

    private void U_Click(object sender, RoutedEventArgs e)
    {
        var textBoxes = new[] { _1letter, _2letter, _3letter, _4letter, _5letter };

        int index = completeTextBoxLogic.IndexFirstEmptyTextBox(textBoxes.Select(tb => tb.Text).ToArray());

        if (index != -1)
        {
            textBoxes[index].Text = "U";
        }
    }

    private void I_Click(object sender, RoutedEventArgs e)
    {
        var textBoxes = new[] { _1letter, _2letter, _3letter, _4letter, _5letter };

        int index = completeTextBoxLogic.IndexFirstEmptyTextBox(textBoxes.Select(tb => tb.Text).ToArray());

        if (index != -1)
        {
            textBoxes[index].Text = "I";
        }
    }

    private void O_Click(object sender, RoutedEventArgs e)
    {
        var textBoxes = new[] { _1letter, _2letter, _3letter, _4letter, _5letter };

        int index = completeTextBoxLogic.IndexFirstEmptyTextBox(textBoxes.Select(tb => tb.Text).ToArray());

        if (index != -1)
        {
            textBoxes[index].Text = "O";
        }
    }

    private void P_Click(object sender, RoutedEventArgs e)
    {
        var textBoxes = new[] { _1letter, _2letter, _3letter, _4letter, _5letter };

        int index = completeTextBoxLogic.IndexFirstEmptyTextBox(textBoxes.Select(tb => tb.Text).ToArray());

        if (index != -1)
        {
            textBoxes[index].Text = "P";
        }
    }

    private void A_Click(object sender, RoutedEventArgs e)
    {
        var textBoxes = new[] { _1letter, _2letter, _3letter, _4letter, _5letter };

        int index = completeTextBoxLogic.IndexFirstEmptyTextBox(textBoxes.Select(tb => tb.Text).ToArray());

        if (index != -1)
        {
            textBoxes[index].Text = "A";
        }
    }

    private void S_Click(object sender, RoutedEventArgs e)
    {
        var textBoxes = new[] { _1letter, _2letter, _3letter, _4letter, _5letter };

        int index = completeTextBoxLogic.IndexFirstEmptyTextBox(textBoxes.Select(tb => tb.Text).ToArray());

        if (index != -1)
        {
            textBoxes[index].Text = "S";
        }
    }

    private void D_Click(object sender, RoutedEventArgs e)
    {
        var textBoxes = new[] { _1letter, _2letter, _3letter, _4letter, _5letter };

        int index = completeTextBoxLogic.IndexFirstEmptyTextBox(textBoxes.Select(tb => tb.Text).ToArray());

        if (index != -1)
        {
            textBoxes[index].Text = "D";
        }
    }

    private void F_Click(object sender, RoutedEventArgs e)
    {
        var textBoxes = new[] { _1letter, _2letter, _3letter, _4letter, _5letter };

        int index = completeTextBoxLogic.IndexFirstEmptyTextBox(textBoxes.Select(tb => tb.Text).ToArray());

        if (index != -1)
        {
            textBoxes[index].Text = "F";
        }
    }

    private void G_Click(object sender, RoutedEventArgs e)
    {
        var textBoxes = new[] { _1letter, _2letter, _3letter, _4letter, _5letter };

        int index = completeTextBoxLogic.IndexFirstEmptyTextBox(textBoxes.Select(tb => tb.Text).ToArray());

        if (index != -1)
        {
            textBoxes[index].Text = "G";
        }
    }

    private void H_Click(object sender, RoutedEventArgs e)
    {
        var textBoxes = new[] { _1letter, _2letter, _3letter, _4letter, _5letter };

        int index = completeTextBoxLogic.IndexFirstEmptyTextBox(textBoxes.Select(tb => tb.Text).ToArray());

        if (index != -1)
        {
            textBoxes[index].Text = "H";
        }
    }

    private void J_Click(object sender, RoutedEventArgs e)
    {
        var textBoxes = new[] { _1letter, _2letter, _3letter, _4letter, _5letter };

        int index = completeTextBoxLogic.IndexFirstEmptyTextBox(textBoxes.Select(tb => tb.Text).ToArray());

        if (index != -1)
        {
            textBoxes[index].Text = "J";
        }
    }

    private void K_Click(object sender, RoutedEventArgs e)
    {
        var textBoxes = new[] { _1letter, _2letter, _3letter, _4letter, _5letter };

        int index = completeTextBoxLogic.IndexFirstEmptyTextBox(textBoxes.Select(tb => tb.Text).ToArray());

        if (index != -1)
        {
            textBoxes[index].Text = "K";
        }
    }

    private void L_Click(object sender, RoutedEventArgs e)
    {
        var textBoxes = new[] { _1letter, _2letter, _3letter, _4letter, _5letter };

        int index = completeTextBoxLogic.IndexFirstEmptyTextBox(textBoxes.Select(tb => tb.Text).ToArray());

        if (index != -1)
        {
            textBoxes[index].Text = "L";
        }
    }

    private void Z_Click(object sender, RoutedEventArgs e)
    {
        var textBoxes = new[] { _1letter, _2letter, _3letter, _4letter, _5letter };

        int index = completeTextBoxLogic.IndexFirstEmptyTextBox(textBoxes.Select(tb => tb.Text).ToArray());

        if (index != -1)
        {
            textBoxes[index].Text = "Z";
        }
    }

    private void X_Click(object sender, RoutedEventArgs e)
    {
        var textBoxes = new[] { _1letter, _2letter, _3letter, _4letter, _5letter };

        int index = completeTextBoxLogic.IndexFirstEmptyTextBox(textBoxes.Select(tb => tb.Text).ToArray());

        if (index != -1)
        {
            textBoxes[index].Text = "X";
        }
    }

    private void C_Click(object sender, RoutedEventArgs e)
    {
        var textBoxes = new[] { _1letter, _2letter, _3letter, _4letter, _5letter };

        int index = completeTextBoxLogic.IndexFirstEmptyTextBox(textBoxes.Select(tb => tb.Text).ToArray());

        if (index != -1)
        {
            textBoxes[index].Text = "C";
        }
    }

    private void V_Click(object sender, RoutedEventArgs e)
    {
        var textBoxes = new[] { _1letter, _2letter, _3letter, _4letter, _5letter };

        int index = completeTextBoxLogic.IndexFirstEmptyTextBox(textBoxes.Select(tb => tb.Text).ToArray());

        if (index != -1)
        {
            textBoxes[index].Text = "V";
        }
    }

    private void B_Click(object sender, RoutedEventArgs e)
    {
        var textBoxes = new[] { _1letter, _2letter, _3letter, _4letter, _5letter };

        int index = completeTextBoxLogic.IndexFirstEmptyTextBox(textBoxes.Select(tb => tb.Text).ToArray());

        if (index != -1)
        {
            textBoxes[index].Text = "B";
        }
    }

    private void N_Click(object sender, RoutedEventArgs e)
    {
        var textBoxes = new[] { _1letter, _2letter, _3letter, _4letter, _5letter };

        int index = completeTextBoxLogic.IndexFirstEmptyTextBox(textBoxes.Select(tb => tb.Text).ToArray());

        if (index != -1)
        {
            textBoxes[index].Text = "N";
        }
    }

    private void M_Click(object sender, RoutedEventArgs e)
    {
        var textBoxes = new[] { _1letter, _2letter, _3letter, _4letter, _5letter };

        int index = completeTextBoxLogic.IndexFirstEmptyTextBox(textBoxes.Select(tb => tb.Text).ToArray());

        if (index != -1)
        {
            textBoxes[index].Text = "M";
        }
    }

    private void EnterButton_Click(object sender, RoutedEventArgs e)
    {
        TextBox[] textBoxesObj = { _1letter, _2letter, _3letter, _4letter, _5letter };

        List<Button> buttons = new List<Button> { Q, W, E, R, T, Y, U, I, O, P, A, S, D, F, G, H, J, K, L, Z, X, C, V, B, N, M };

        string userWord = string.Concat(textBoxesObj.Select(tb => tb.Text).ToArray());

        string selectedWord = selectedWordLogic.SelectedWord;

        GuessingLogic guessingLogic = new GuessingLogic();

        guessingLogic.CheckCharacters(userWord, selectedWord);

        List<(char, int)> samePositions = guessingLogic.SamePosition;

        List<(char, int)> presentButNotSamePositions = guessingLogic.PresentButNotSamePosition;

        bool isCorrect = false;

        IButtonsService buttonsService = new ButtonsService(buttons);

        for (int i = 0; i < samePositions.Count; i++)
        {
            textBoxesObj[samePositions[i].Item2].Background = Brushes.Green;
            buttonsService.HighlightButtonsGreen(samePositions[i].Item1);
            isCorrect = true;
        }

        if (!isCorrect)
        {
            for (int i = 0; i < presentButNotSamePositions.Count; i++)
            {
                textBoxesObj[presentButNotSamePositions[i].Item2].Background = Brushes.Yellow;
                buttonsService.HighlightButtonsYellow(presentButNotSamePositions[i].Item1);
            }
        }
    }

    private void BackSpace_Click(object sender, RoutedEventArgs e)
    {
        TextBox[] textBoxesObj = { _1letter, _2letter, _3letter, _4letter, _5letter };

        int index = completeTextBoxLogic.IndexFirstEmptyTextBox(textBoxesObj.Select(tb => tb.Text).ToArray());

        if (index == -1 && textBoxesObj[4].Text != "") textBoxesObj[4].Text = "";
        else if(!string.IsNullOrEmpty(textBoxesObj[0].Text)) textBoxesObj[index - 1].Text = "";
    }
}
