using System;

namespace Core
{
    public class ConsoleHelper
    {
        public static void Print(IDay day, IResult TestResultPartOne, IResult ResultPartOne)
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"The Riddel From Day {day.dayNumber} Year {day.year}");
            Console.Write("The test for the first part was  : ");
            TestWas(day.FirstTestValue.HasSameValue(TestResultPartOne));
            Console.WriteLine("The answer for the first Part is : ");
            ResultPartOne.print();;

            Console.WriteLine("####################################################");
            Console.WriteLine("####################################################");
        }

        public static void Print(IDay day, IResult TestResultPartOne, IResult ResultPartOne, IResult TestResultPartTwo, IResult ResultPartTwo)
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"The Riddel From Day {day.dayNumber} Year {day.year}");
            Console.Write("The test for the first part was  : ");
            TestWas(day.FirstTestValue.HasSameValue(TestResultPartOne));
            Console.Write("The test for the Second part was : ");
            TestWas(day.SecondTestValue.HasSameValue(TestResultPartTwo));
            Console.Write("The answer for the first Part is : ");
            ResultPartOne.print();
            Console.Write("The answer for the Second Part is: ");
            ResultPartTwo.print();
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
