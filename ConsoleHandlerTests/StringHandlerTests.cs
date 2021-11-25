using Console_handler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConsoleHandlerTests
{
    [TestClass()]
    public class StringHandlerTests
    {
        [TestMethod()]
        public void GetUniqueStringMaxLength_ValidString_Gets7()
        {
            string str = "asdmwkaadsds";
            int expected = 7;

            int actual = StringHandler.GetUniqueStringMaxLength(str);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetUniqueStringMaxLength_OneSymbol_Gets1()
        {
            string str = "$";
            int expected = 1;

            int actual = StringHandler.GetUniqueStringMaxLength(str);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetUniqueMaxLength_EmptyString_Gets0()
        {
            string str = string.Empty;
            int expected = 0;

            int actual = StringHandler.GetUniqueStringMaxLength(str);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetUniqueMaxLength_NullString_Gets0()
        {
            string str = null;
            int expected = 0;

            int actual = StringHandler.GetUniqueStringMaxLength(str);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetUniqueLength_SequenceOfOneSymbol_Gets1()
        {
            string str = "lllllll";
            int expected = 1;

            int actual = StringHandler.GetUniqueStringMaxLength(str);

            Assert.AreEqual(expected, actual);
        }
    }
}
