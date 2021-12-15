using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IDay
    {
        public int dayNumber { get; }
        public int year { get; }
        public IResult? FirstTestValue { get; }
        public IResult? SecondTestValue { get => null; }
        public string[] TestInput { get; }



        public object Parser(string[] arg);
        public IResult PartOne<T>(T Data);
        public IResult PartTwo<T>(T Data);



        public void Run(string[] Input)
        {
            var dataTuple = parseData(Input);


            var ResultsPartOne = RunPartOne(dataTuple.testData, dataTuple.data);

            if(SecondTestValue is not null)
            {
                dataTuple = parseData(Input);

                var ResultParttwo = RunPartTwo(dataTuple.testData, dataTuple.data);
                ConsoleHelper.Print(this, ResultsPartOne.testResult, ResultsPartOne.result, ResultParttwo.testResult, ResultParttwo.result);

                return;
            }
            ConsoleHelper.Print(this, ResultsPartOne.testResult, ResultsPartOne.result);

        }

        public (IResult testResult, IResult result) RunPartOne<I>(I testData, I data)
        {
            return (PartOne(testData), PartOne(data));

        }

        public (IResult testResult, IResult result) RunPartTwo<I>(I testData, I data)
        {
            return (PartTwo(testData), PartTwo(data));
        }

        public (object testData, object data) parseData(string[] Input)
        {
            var testData = Parser(TestInput);
            var data = Parser(Input);

            return (testData, data);
        }
    }
}
