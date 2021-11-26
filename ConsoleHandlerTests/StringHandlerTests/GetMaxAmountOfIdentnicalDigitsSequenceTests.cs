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
        [DataRow("22 dsa 8232 ds^$@&", 2)]
        [DataRow("$!@%$#&#fsa4dsa11", 2)]
        [DataRow("7", 1)]
        [DataRow("99999", 5)]

        public void GetMaxAmountOfIdentnicalDigitsSequence_ValidString(string str, int expected)
        {
            int actual = StringHandler.GetMaxAmountOfIdentnicalDigitsSequence(str);

            Assert.AreEqual(expected, actual);
        }
    }
}
