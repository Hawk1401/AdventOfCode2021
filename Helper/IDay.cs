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
        public void Run<I>(int testResultPartOne, Func<string, I> parser)
        {
            var dataTuple = parseData(parser);

            RunPartOne(testResultPartOne, dataTuple.testData, dataTuple.data);
        }

        public void Run<I>(int TestResultPartOne, int TestResultPartTwo, Func<string, I> parser)
        {
            var dataTuple = parseData(parser);
            RunPartOne(TestResultPartOne, dataTuple.testData, dataTuple.data);

            dataTuple = parseData(parser);
            RunPartTwo(TestResultPartTwo, dataTuple.testData, dataTuple.data);
        }

        public void Run<I>(int testResultPartOne, Func<string[], I> parser)
        {
            var dataTuple = CustomParseData(parser);

            RunPartOne(testResultPartOne, dataTuple.testData, dataTuple.data);
        }

        public void Run<I>(int TestResultPartOne, int TestResultPartTwo, Func<string[], I> parser)
        {
            var dataTuple = CustomParseData(parser);

            RunPartOne(TestResultPartOne, dataTuple.testData, dataTuple.data);

            dataTuple = CustomParseData(parser);
            RunPartTwo(TestResultPartTwo, dataTuple.testData, dataTuple.data);
        }
        public void RunPartOne<I>(int testResultPartOne, I testData, I data)
        {
            var testReult = PartOne(testData);
            ConsoleHelper.PrintTest(testReult, testResultPartOne);
            ConsoleHelper.PrintFirstResult(PartOne(data));
        }

        public void RunPartTwo<I>(int testResultPartTwo, I testData, I data)
        {
            var TestReultPartTwo = PartTwo(testData);
            ConsoleHelper.PrintTest(TestReultPartTwo, testResultPartTwo);
            ConsoleHelper.PrintSecondResult(PartTwo(data));
        }

        public (List<I> testData, List<I> data) parseData<I>(Func<string, I> parser)
        {
            var testData = File.ReadAllLines("testInput.txt").Select(parser).ToList();
            var data = File.ReadAllLines("input.txt").Select(parser).ToList();

            return (testData, data);
        }

        public (I testData, I data) CustomParseData<I>(Func<string[], I> parser)
        {
            var testData = parser.Invoke(File.ReadAllLines("testInput.txt"));
            var data = parser.Invoke(File.ReadAllLines("input.txt"));

            return (testData, data);
        }


        public long PartOne<T>(T Data);
        public long PartTwo<T>(T Data);

    }
}
