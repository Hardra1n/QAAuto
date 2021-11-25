using Console_handler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleHandlerTests.StringHandlerTests
{
    [TestClass()]
    public class GetMaxAmountOfIdenticalLettersSequenceTests
    {
        [TestMethod()]
        public void GetMaxAmountOfIdenticalLettersSequenceTests_Null_Gets0()
        {
            string str = null;
            int expected = 0;

            int actual = StringHandler.GetMaxAmountOfIdentnicalDigitsSequence(str);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetMaxAmountOfIdenticalLettersSequenceTests_EmptyString_Gets0()
        {
            string str = string.Empty;
            int expected = 0;

            int actual = StringHandler.GetMaxAmountOfIdentnicalLettersSequence(str);

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod()]
        [DataRow("dwaaadsfwazs", 3)]
        [DataRow("dsswaadf ff fff dswas", 3)]
        [DataRow("123421d232421", 1)]
        public void GetMaxAmountOfIdenticalLettersSequenceTests_ValidString(string str, int expected)
        {
            var actual = StringHandler.GetMaxAmountOfIdentnicalLettersSequence(str);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow("a")]
        [DataRow("t")]
        [DataRow("B")]
        public void GetMaxAmountOfIdenticalLettersSequenceTests_OneLetter(string str)
        {
            int expected = 1;

            var actual = StringHandler.GetMaxAmountOfIdentnicalLettersSequence(str);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow("AaaAaA", 6)]
        [DataRow("bbbBbbb", 7)]
        public void GetMaxAmountOfIdenticalLettersSequenceTests_CamelLetters(string str, int expected)
        {
            int actual = StringHandler.GetMaxAmountOfIdentnicalLettersSequence(str);

            Assert.AreEqual(expected, actual);
        }

    }
}
