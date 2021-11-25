using System;

namespace Console_handler
{
    class Program
    { 
        static void Main(string[] args)
        {
            //Console.WriteLine($"You entered: {args[0]}");
            //Console.WriteLine($"Output of func: {StringHandler.GetUniqueStringMaxLength(args[0])}");
            Console.WriteLine(StringHandler.GetMaxAmountOfIdentnicalLettersSequence(";sssdcreee;a'sdw,l,wwww"));
            Console.WriteLine(StringHandler.GetMaxAmountOfIdentnicalDigitsSequence(";1333245d23k2j4"));
        }
    }
}
