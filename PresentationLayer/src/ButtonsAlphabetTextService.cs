using System.Windows.Controls;

public class ButtonsAlphabetTextService
{
    IndexLogic indexLogic = new IndexLogic();

    public TextBox[,] TextBoxes { get; set; } = new TextBox[6, 5];
    public string Letter { get; set; } = "";
    public int Lives { get; set; }

    public void WriteLetterToTextBox()
    {
        int index = indexLogic.IndexFirstEmptyTextBox(GetTextBoxTexts(), Lives);

        if (index != -1)
        {
            TextBoxes[Lives, index].Text = Letter;
        }
    }

    private string[,] GetTextBoxTexts()
    {
        string[,] texts = new string[6, 5];

        for (int i = 0; i < 5; i++)
        {
            texts[Lives, i] = TextBoxes[Lives, i].Text;
        }

        return texts;
    }
}
