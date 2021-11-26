using Console_handler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleHandlerTests.StringHandlerTests
{
    [TestClass]
    public class GetMaxAmountOfIdenticalLettersSequenceTests
    {
        [TestMethod]
        public void GetMaxAmountOfIdenticalLettersSequenceTests_Null_Gets0()
        {
            // Arrange
            string str = null;
            int expected = 0;

            // Act
            int actual = StringHandler.GetMaxAmountOfIdentnicalDigitsSequence(str);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMaxAmountOfIdenticalLettersSequenceTests_EmptyString_Gets0()
        {
            // Arrange
            string str = string.Empty;
            int expected = 0;

            // Act
            int actual = StringHandler.GetMaxAmountOfIdentnicalLettersSequence(str);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        [DataRow("dwaaadsfwazs", 3)]
        [DataRow("fffdssw^&*()$d232 dswas", 3)]
        [DataRow("123421232421dd", 2)]
        [DataRow("1", 0)]
        [DataRow("a", 1)]
        [DataRow("AaaAa", 5)]
        public void GetMaxAmountOfIdenticalLettersSequenceTests_ValidString(string str, int expected)
        {
            // Act
            var actual = StringHandler.GetMaxAmountOfIdentnicalLettersSequence(str);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
