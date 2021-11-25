using System;
using System.Collections.Generic;
using System.Text;

namespace Console_handler
{
    public static class StringHandler
    {

        /// <summary>
        /// Returns max length of symbols sequences, in which symbols dosn't place next to the same symbol.
        /// </summary>
        /// <param name="str"> Pointer to string, which max unique length calculates </param>
        /// <returns></returns>
        public static int GetUniqueStringMaxLength(string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return 0;
            }

            int maxLength = 1;

            for (int i = 0, temp = 1; i < str.Length - 1; i++)
            {
                if (str[i] == str[i + 1])
                {
                    temp = 0;
                }
                temp++;

                if (maxLength < temp)
                {
                    maxLength = temp;
                }
            }
            return maxLength;
        }

        public static int GetMaxAmountOfIdentnicalLettersSequence(string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return 0;
            }

            int counter = 0;
            int maxLength = 0;
            if (IsLatinLetter(str[0]))
            {
                counter++;
                maxLength++;
            }

            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == str[i + 1] && IsLatinLetter(str[i + 1]) || 
                    counter == 0 && IsLatinLetter(str[i + 1])) 
                {
                    counter++;
                }
                else
                {
                    counter = 0;
                }

                maxLength = maxLength < counter ? counter : maxLength;
            }

            return maxLength;
        }

        public static int GetMaxAmountOfIdentnicalDigitsSequence(string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return 0;
            }

            int counter = 0;
            int maxLength = 0;

            if (Char.IsDigit(str[0]))
            {
                counter++;
                maxLength++;
            }

            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == str[i + 1] && Char.IsDigit(str[i + 1]) || 
                    counter == 0 && Char.IsDigit(str[i +1]))
                {
                    counter++;
                }
                else
                {
                    counter = 0;
                }

                maxLength = maxLength < counter ? counter : maxLength;
            }

            return maxLength;
        }

        private static bool IsLatinLetter(char symbol) 
            => (symbol >= 'a' && symbol <= 'z') || (symbol >= 'A' && symbol <= 'Z');
    }
}
