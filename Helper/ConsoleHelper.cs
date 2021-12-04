using System;

namespace Helper
{
    public class ConsoleHelper
    {
        public static void PrintTest(long result, long expected)
        {
            Console.Write("The test was ");
            
            if(result == expected)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("successfully");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("notsuccessfully");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"The Test returned: {result}, expected was: {expected}");
        }

        public static void PrintFirstResult(long result)
        {
            Console.WriteLine();
            Console.WriteLine($"The result Of the First Problem is: {result}");
            Console.WriteLine("#############################################");
        }

        public static void PrintSecondResult(long result)
        {
            Console.WriteLine();
            Console.WriteLine($"The result Of the Second Problem is: {result}");
        }
    }
}
