using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021.Days
{
    public class Day2 : IDay
    {
        public long? FirstTestValue => 150;

        public long? SecondTestValue => 900;

        public string[] TestInput => new string[] {
        "forward 5",
        "down 5",
        "forward 8",
        "up 3",
        "down 8",
        "forward 2"
        };

        public int dayNumber => 2;

        public int year => 2021;

        public object Parser(string[] arg)
        {
            return arg.Select(x => (x.Split(" ")[0], int.Parse(x.Split(" ")[1]))).ToList();
        }

        public long PartOne<T>(T Data)
        {
            var steps = Data as List<(string direction, int value)>;
            int horizontal = 0;
            int depth = 0;

            foreach (var step in steps)
            {
                switch (step.direction)
                {
                    case "forward":
                        horizontal += step.value;
                        break;
                    case "down":
                        depth += step.value;
                        break;
                    case "up":
                        depth -= step.value;
                        break;
                }
            }

            return horizontal * depth;
        }

        public long PartTwo<T>(T Data)
        {
            var steps = Data as List<(string direction, int value)>;
            int horizontal = 0;
            int depth = 0;
            int aim = 0;

            foreach (var step in steps)
            {
                switch (step.direction)
                {
                    case "forward":
                        horizontal += step.value;
                        depth += aim * step.value;
                        break;
                    case "down":
                        aim += step.value;
                        break;
                    case "up":
                        aim -= step.value;
                        break;
                }
            }

            return horizontal * depth;
        }
    }

}
