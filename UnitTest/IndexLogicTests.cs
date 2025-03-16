[TestClass]
public class IndexLogicTests
{
    [TestMethod]
    public void TestIndexFirstEmptyTextBox()
    {
        // Arrange
        IndexLogic indexLogic = new IndexLogic();
        string[,] textBoxesText = new string[3, 5]
        {
            { "A", "B", "C", "D", "E" },
            { "F", "", "G", "H", "I" }, // Second row has an empty text box at index 1
            { "J", "K", "L", "M", "N" }
        };
        int lives = 0; // Check the second row

        // Act
        int result = indexLogic.IndexFirstEmptyTextBox(textBoxesText, lives);

        // Assert
        Assert.AreEqual(-1, result); // Expect the index of the first empty text box
    }
}