﻿using System;

namespace Console_handler
{
    class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine($"You entered: {args[0]}");
            Console.WriteLine($"Output of func: {GetUniqueStringMaxLength(args[0])}");
        }

        /// <summary>
        /// Returns max length of symbols sequences, in which symbols dosn't place next to the same symbol.
        /// </summary>
        /// <param name="str"> Pointer to string, which max unique length calculates </param>
        /// <returns></returns>
        static int GetUniqueStringMaxLength(string str)
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
    }
}
