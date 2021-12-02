using Helper;
using System;
using System.Collections.Generic;

namespace Day2
{
    public class Day2 : IDay
    {
        static void Main(string[] args) 
        {
            IDay day = new Day2();
            day.Run(150, 900, x=> (x.Split(" ")[0], int.Parse(x.Split(" ")[1])));
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
