using System;

namespace Helper
{
    public class ConsoleHelper
    {
        public static void Print(IDay day, long TestResultPartOne, long ResultPartOne)
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"The Riddel From Day {day.dayNumber} Year {day.year}");
            Console.Write("The test for the first part was  : ");
            TestWas(day.FirstTestValue == TestResultPartOne);
            Console.WriteLine("The answer for the first Part is : " + ResultPartOne);
            Console.WriteLine("####################################################");
            Console.WriteLine("####################################################");
        }

        public static void Print(IDay day, long TestResultPartOne, long ResultPartOne, long TestResultPartTwo, long ResultPartTwo)
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"The Riddel From Day {day.dayNumber} Year {day.year}");
            Console.Write("The test for the first part was  : ");
            TestWas(day.FirstTestValue == TestResultPartOne);
            Console.Write("The test for the Second part was : ");
            TestWas(day.SecondTestValue == TestResultPartTwo);
            Console.WriteLine("The answer for the first Part is : " + ResultPartOne);
            Console.WriteLine("The answer for the Second Part is: " + ResultPartTwo);
            Console.WriteLine("####################################################");
            Console.WriteLine("####################################################");
        }

        public static void TestWas(bool TestWasSuccessfully)
        {
            if (TestWasSuccessfully)
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

        }
    }
}
