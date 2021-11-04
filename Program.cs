﻿using System;
using System.Text;

namespace Console_digit_converter
{
    class Program
    {
        const byte notationBaseMin = 2;
        const byte notationBaseMax = 20;
        const string wrongInputMessage = "Wrong input";

        static void Main(string[] args)
        {
            int num;
            byte notationBase;

            Console.WriteLine("Enter number to convert");
            bool isNumParsed = Int32.TryParse(Console.ReadLine(), out num);
            Console.WriteLine("Enter notation base");
            bool isNotationParsed = Byte.TryParse(Console.ReadLine(), out notationBase);

            if (isNotationParsed && isNumParsed)
            {
                Console.WriteLine($"{num} in decimal notation into {notationBase}-notation is " +
                                  $"{ConvertToAnotherNotation(num, notationBase)}");
            }
        }

        /// <summary>
        /// Converts a deciamal-notation value into another notation [2;20]
        /// </summary>
        /// <param name="num"> Number to convert </param>
        /// <param name="notationBase"> New notation base </param>
        /// <returns> Represents number in new notation as a string </returns>
        static string ConvertToAnotherNotation(int num, byte notationBase)
        {
            if (num < 0 || notationBase < notationBaseMin  || notationBase > notationBaseMax)
            {
                return wrongInputMessage;
            }

            StringBuilder newNumber = new StringBuilder("");
            while (true)
            {
                newNumber.Insert(0, ConvertDigitToNotationSymbol(num % notationBase));
                num /= notationBase;
                if (num == 0)
                {
                    break;
                }
            }
            return newNumber.ToString();
        }

        /// <summary>
        /// Convert integer number into a notation symbol.
        /// </summary>
        /// <param name="number"> Number to convert</param>
        /// <returns> Notation symbol as a char</returns>
        static char ConvertDigitToNotationSymbol(int number)
        {
            if (number >= 10)
                return (char)('A' + number - 10);

            return (char)(number + '0');
        }
    }
}
