using System;

namespace Helper
{
    public class ConsoleHelper
    {
        public static void PrintTest(long result, long expected)
        {
            if(result == expected)
            {
                Console.WriteLine("The test was successfully");
            }
            else
            {
                Console.WriteLine("The test was notsuccessfully");
            }

            Console.WriteLine($"The Test returned {result}, expected was {expected}");

        }

        public static void PrintFirstResult(long result)
        {
            Console.WriteLine();
            Console.WriteLine($"The result Of the First Problem is {result}");
            Console.WriteLine("#############################################");



        }

        public static void PrintSecondResult(long result)
        {
            Console.WriteLine();
            Console.WriteLine($"The result Of the Second Problem is {result}");
        }
    }
}
