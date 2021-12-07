using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021.Days
{
    public class Day7 : IDay
    {
        public int dayNumber => 7;

        public int year => 2021;

        public long? FirstTestValue => 37;

        public long? SecondTestValue => 168;

        public string[] TestInput => new string[] { "16,1,2,0,4,2,7,1,2,14" };

        private Dictionary<int, long> stepsChache = new Dictionary<int, long>();
        public object Parser(string[] arg)
        {
            return arg[0].Trim().Split(",").Select(x => int.Parse(x)).ToList();
        }


        private Dictionary<int, int> GetMap(List<int> nums)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (var x in nums)
            {
                if (!map.ContainsKey(x))
                {
                    map.Add(x, 0);
                }
                map[x]++;
            }

            return map;
        }
        public long PartOne<T>(T Data)
        {
            var nums = Data as List<int>;
            var map = GetMap(nums);
            nums.Sort();
            int lowBound = nums[nums.Count / 3];
            int upperBound = nums[nums.Count - 1];

            HashSet<int> chache = new HashSet<int>();
            long min = int.MaxValue;
            for (int pos = lowBound; pos < upperBound; pos++)
            {

                if (chache.Contains(pos))
                {
                    continue;
                }

                var steps = CalculateFuleConstantRate(map, pos);
                min = Math.Min(min, steps);

                chache.Add(pos);
            }
            return min;
        }

        private int CalculateFuleConstantRate(Dictionary<int, int> map, int dest)
        {
            int Fule = 0;

            foreach (var keyValuePair in map)
            {
                Fule += Math.Abs(keyValuePair.Key - dest) * keyValuePair.Value;
            }

            return Fule;
        }

        private long CalculateFule(Dictionary<int, int> map, int dest)
        {
            long Fule = 0;

            foreach (var keyValuePair in map)
            {
                Fule += CalculateFule(Math.Abs(keyValuePair.Key - dest)) * keyValuePair.Value;
            }

            return Fule;
        }
        
        private long CalculateFule(int steps)
        {
            if (stepsChache.ContainsKey(steps))
            {
                return stepsChache[steps];
            }
            long fule = 0;

            for (int i = 1; i <= steps; i++)
            {
                fule += i;
            }
            stepsChache.Add(steps, fule);

            return fule;
        }

        public long PartTwo<T>(T Data)
        {
            var nums = Data as List<int>;
            var map = GetMap(nums);
            nums.Sort();
            int lowBound = nums[nums.Count / 3];
            int upperBound = nums[nums.Count - 1];

            HashSet<int> chache = new HashSet<int>();
            long min = int.MaxValue;
            for (int pos = lowBound; pos < upperBound; pos++)
            {

                if (chache.Contains(pos))
                {
                    continue;
                }

                var steps = CalculateFule(map, pos);
                min = Math.Min(min, steps);

                chache.Add(pos);
            }
            return min;
        }
    }
}
