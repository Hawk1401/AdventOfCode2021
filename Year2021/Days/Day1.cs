using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021.Days
{
    public class Day1 : IDay
    {
        public IResult? FirstTestValue => new ResultLong(7);

        public IResult? SecondTestValue => new ResultLong(5);

        public string[] TestInput => new string[] {
        "199",
        "200",
        "208",
        "210",
        "200",
        "207",
        "240",
        "269",
        "260",
        "263" };

        public int dayNumber => 1;

        public int year => 2021;

        public object Parser(string[] arg)
        {
            return arg.Select(x => int.Parse(x)).ToList();
        }



        public IResult PartOne<T>(T Data)
        {
            var nums = Data as List<int>;
            int count = 0;
            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i - 1] < nums[i])
                {
                    count++;
                }
            }

            return new ResultLong(count);
        }
        public IResult PartTwo<T>(T Data)
        {
            var nums = Data as List<int>;

            int count = 0;

            int prev = nums[0] + nums[1] + nums[2];
            for (int i = 1; i < nums.Count - 2; i++)
            {
                int sum = nums[i] + nums[i + 1] + nums[i + 2];
                if (prev < sum)
                {
                    count++;
                }
                prev = sum;
            }

            return new ResultLong(count);
        }
    }

}
