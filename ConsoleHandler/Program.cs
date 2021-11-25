using System;

namespace Console_handler
{
    class Program
    { 
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine($"You entered: {args[0]}");
                Console.WriteLine($"Output of unique func: {StringHandler.GetUniqueMaxLength(args[0])}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
