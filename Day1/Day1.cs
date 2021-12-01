using Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Day1
{
    public class Day1 : IDay
    {
        static void Main(string[] args)
        {
            IDay o = new Day1();
            o.Run(7,5);
        }

        public int PartOne(List<int> nums)
        {
            int count = 0;
            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i - 1] < nums[i])
                {
                    count++;
                }
            }

            return count;
        }
        public int PartTwo(List<int> nums)
        {
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

            return count;
        }
    }
}
