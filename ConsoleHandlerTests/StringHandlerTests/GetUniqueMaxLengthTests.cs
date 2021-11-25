using Console_handler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConsoleHandlerTests.StringHandlerTests
{
    [TestClass()]
    public class GetUniqueMaxLengthTests
    {
        [TestMethod()]
        [DataRow("dsdakwwdds", 6)]
        [DataRow("d4k%sasswwdds", 7)]
        [DataRow("d fwas dww lddw", 9)]
        public void GetUniqueMaxLength_ValidString(string str, int expected)
        {
            int actual = StringHandler.GetUniqueMaxLength(str);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow("a")]
        [DataRow("$")]
        [DataRow(" ")]
        public void GetUniqueMaxLength_OneSymbol_Gets1(string str)
        {
            int expected = 1;

            int actual = StringHandler.GetUniqueMaxLength(str);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetUniqueMaxLength_EmptyString_Gets0()
        {
            string str = string.Empty;
            int expected = 0;

            int actual = StringHandler.GetUniqueMaxLength(str);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetUniqueMaxLength_NullString_Gets0()
        {
            string str = null;
            int expected = 0;

            int actual = StringHandler.GetUniqueMaxLength(str);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow("lllll")]
        [DataRow("########")]
        [DataRow("22")]
        public void GetUniqueLength_SequenceOfOneSymbol_Gets1(string str)
        {
            int expected = 1;

            int actual = StringHandler.GetUniqueMaxLength(str);

            Assert.AreEqual(expected, actual);
        }
    }
}
