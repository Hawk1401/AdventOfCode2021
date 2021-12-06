using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021.Days
{
    public class Day6 : IDay
    {
        public int dayNumber => 6;

        public int year => 2021;

        public long? FirstTestValue => 5934;

        public long? SecondTestValue => 26984457539;

        public string[] TestInput => new string[] { "3,4,3,1,2" };

        public object Parser(string[] arg)
        {
            return arg[0].Trim().Split(",").Select(x => int.Parse(x)).ToList();
        }

        public long PartOne<T>(T Data)
        {
            var nums = Data as List<int>;
            Dictionary<int, int> chache = new Dictionary<int, int>();

            long total = 0;
            foreach (var num in nums)
            {
                if (chache.ContainsKey(num))
                {
                    total += chache[num];
                }
                else
                {
                    var result = Resultof(num, 80);
                    chache.Add(num, result);
                    total += result;
                }
            }
            return total;
        }


        //This implementaion is two slow for part Two 
        public int Resultof(int startValue, int TimeSpan)
        {
            List<int> nums = new List<int>();
            nums.Add(startValue);
            for (int i = 0; i < TimeSpan; i++)
            {
                int addCount = 0;
                for (int j = 0; j < nums.Count; j++)
                {
                    if (nums[j] == 0)
                    {
                        nums[j] = 6;
                        addCount++;
                    }
                    else
                    {
                        nums[j]--;
                    }
                }
                for (int j = 0; j < addCount; j++)
                {
                    nums.Add(8);
                }
            }

            return nums.Count;
        }

        public static long ResultOfPartTwo(int startValue, int TimeSpan)
        {

            List<int> map = new List<int>();
            for (int i = 0; i <= 8; i++)
            {
                    map.Add(0);
            }
            map[startValue]++;
            for (int i = 0; i < TimeSpan; i++)
            {
                int TempNewOnce = 0;

                for (int j = 0; j < map.Count - 1; j++)
                {
                    if (j == 0)
                    {
                        TempNewOnce = map[0];
                    }
                    map[j] = map[j + 1];
                }

                map[6] += TempNewOnce;
                map[8] = TempNewOnce;

            }

            long sum = 0;
            foreach (var item in map)
            {
                sum += item;
            }
            return sum;
        }
        public long PartTwo<T>(T Data)
        {
            var nums = Data as List<int>;
            Dictionary<int, long> chache = new Dictionary<int, long>();

            long total = 0;
            foreach (var num in nums)
            {
                if (chache.ContainsKey(num))
                {
                    total += chache[num];
                }
                else
                {
                    var result = ResultOfPartTwo(num, 256);
                    chache.Add(num, result);
                    total += result;
                }
            }
            return total;
        }
    }
}
