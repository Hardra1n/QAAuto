using System;
using System.Text;

namespace Console_digit_converter
{
    class Program
    {
        /// <summary>
        /// Converts a deciamal-notation value into another notation [2;20]
        /// </summary>
        /// <param name="num"> Number to convert </param>
        /// <param name="notationBase"> New notation base </param>
        /// <returns> Represents number in new notation as a string </returns>
        static string ConvertToAnotherNotation(int num, byte notationBase)
        {
            if (num < 0 || notationBase < 2  || notationBase > 20)
            {
                return "WRONG INPUT";
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

        static void Main(string[] args)
        {
            int num;
            byte notationBase;

            Console.WriteLine("Enter number to convert");
            num = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter notation base");
            notationBase = Byte.Parse(Console.ReadLine());

            Console.WriteLine($"{num} in decimal notation into {notationBase}-notation is " +
                $"{ConvertToAnotherNotation(num, notationBase)}");

        }
    }
}
