﻿using Console_handler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConsoleHandlerTests.StringHandlerTests
{
    [TestClass]
    public class GetUniqueMaxLengthTests
    {
        [TestMethod]
        public void GetUniqueMaxLength_EmptyString_Gets0()
        {
            // Arrange
            string str = string.Empty;
            int expected = 0;

            // Act
            int actual = StringHandler.GetUniqueMaxLength(str);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetUniqueMaxLength_Null_Gets0()
        {
            // Arrange 
            string str = null;
            int expected = 0;

            // Act
            int actual = StringHandler.GetUniqueMaxLength(str);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("dswwddswasxmck", 9)]
        [DataRow("d4k%sasswwdds", 7)]
        [DataRow("ddvnfjwakdd", 9)]
        [DataRow("a", 1)]
        [DataRow("#######", 1)]
        public void GetUniqueMaxLength_ValidString(string str, int expected)
        {
            // Act
            int actual = StringHandler.GetUniqueMaxLength(str);
            
            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
