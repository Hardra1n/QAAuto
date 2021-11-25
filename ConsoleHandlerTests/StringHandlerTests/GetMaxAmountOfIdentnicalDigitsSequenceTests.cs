using Console_handler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleHandlerTests.StringHandlerTests
{
    [TestClass()]
    public class GetMaxAmountOfIdentnicalDigitsSequenceTests
    {
        [TestMethod]
        public void GetMaxAmountOfIdentnicalDigitsSequenceTest_Null_Gets0()
        {
            string str = null;
            int expected = 0;

            int actual = StringHandler.GetMaxAmountOfIdentnicalDigitsSequence(str);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMaxAmountOfIdentnicalDigitsSequence_EmptyString_Gets0()
        {
            string str = string.Empty;
            int expected = 0;

            int actual = StringHandler.GetMaxAmountOfIdentnicalDigitsSequence(str);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("234211134221", 3)]
        [DataRow(" 2 fdwak33 3 dsa", 2)]
        [DataRow("332211", 2)]
        public void GetMaxAmountOfIdentnicalDigitsSequence_ValidString(string str, int expected)
        {
            int actual = StringHandler.GetMaxAmountOfIdentnicalDigitsSequence(str);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("1")]
        [DataRow("7")]
        public void GetMaxAmountOfIdentnicalDigitsSequence_OneDigit_Gets1(string str) 
        {
            int expected = 1;

            int actual = StringHandler.GetMaxAmountOfIdentnicalDigitsSequence(str);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("11111111", 8)]
        [DataRow("333", 3)]
        [DataRow("77777", 5)]
        public void GetMaxAmountOfIdentnicalDigitsSequence_SequenceOfDigit(string str, int expected) 
        {
            int actual = StringHandler.GetMaxAmountOfIdentnicalDigitsSequence(str);

            Assert.AreEqual(expected, actual);
        }
    }
}
