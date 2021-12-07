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

        public long PartOne<T>(T Data)
        {
            var nums = Data as List<int>;

            return Solve(nums, CalculateFuleConstantRate);
        }

        public long PartTwo<T>(T Data)
        {
            var nums = Data as List<int>;

            return Solve(nums, CalculateFule);
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

        private long CalculateFuleConstantRate(Dictionary<int, int> map, int dest)
        {
            long Fule = 0;

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

            long fule = (steps * (steps + 1)) / 2;

            stepsChache.Add(steps, fule);

            return fule;
        }

        public long Solve(List<int> nums, Func<Dictionary<int, int> , int ,long> calculationFunction)
        {
            var map = GetMap(nums);
            int lowBound = map.Keys.Min();
            int upperBound = map.Keys.Max();

            HashSet<int> chache = new HashSet<int>();
            long min = int.MaxValue;
            for (int pos = lowBound; pos < upperBound; pos++)
            {

                if (chache.Contains(pos))
                {
                    continue;
                }

                var steps = calculationFunction.Invoke(map, pos);
                min = Math.Min(min, steps);

                chache.Add(pos);
            }
            return min;
        }

    }
}
