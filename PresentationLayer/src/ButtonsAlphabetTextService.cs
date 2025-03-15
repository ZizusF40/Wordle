using System.Windows.Controls;

public class ButtonsAlphabetTextService
{
    IndexLogic indexLogic = new IndexLogic();

    public TextBox[] TextBoxes { get; set; } = new TextBox[5];
    public string Letter { get; set; } = "";

    public void WriteLetterToTextBox()
    {
        int index = indexLogic.IndexFirstEmptyTextBox(TextBoxes.Select(tb => tb.Text).ToArray());

        if (index != -1)
        {
            TextBoxes[index].Text = Letter;
        }
    }
}

