using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public interface IDay
    {

        public void Run(int TestResultPartOne)
        {
            var Testnums = File.ReadAllLines("testInput.txt").Select(x => int.Parse(x)).ToList();
            var TestReult = PartOne(Testnums);
            ConsoleHelper.PrintTest(TestReult, TestResultPartOne);


            var nums = File.ReadAllLines("input.txt").Select(x => int.Parse(x)).ToList();
            ConsoleHelper.PrintFirstResult(PartOne(nums));
        }

        public void Run(int TestResultPartOne, int TestResultPartTwo)
        {
            var Testnums = File.ReadAllLines("testInput.txt").Select(x => int.Parse(x)).ToList();
            var TestReult = PartOne(Testnums);
            ConsoleHelper.PrintTest(TestReult, TestResultPartOne);


            var nums = File.ReadAllLines("input.txt").Select(x => int.Parse(x)).ToList();
            ConsoleHelper.PrintFirstResult(PartOne(nums));

            //Part Two 
            var TestReultPartTwo = PartTwo(Testnums);
            ConsoleHelper.PrintTest(TestReultPartTwo, 5);
            ConsoleHelper.PrintSecondResult(PartTwo(nums));
        }


        public int PartOne(List<int> nums);
        public int PartTwo(List<int> nums);

    }
}
