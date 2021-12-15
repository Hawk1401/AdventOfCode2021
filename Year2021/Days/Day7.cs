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

        public IResult? FirstTestValue => new ResultLong(37);

        public IResult? SecondTestValue => new ResultLong(168);

        public string[] TestInput => new string[] { "16,1,2,0,4,2,7,1,2,14" };

        private Dictionary<int, long> stepsChache = new Dictionary<int, long>();
        public object Parser(string[] arg)
        {
            return arg[0].Trim().Split(",").Select(x => int.Parse(x)).ToList();
        }

        public IResult PartOne<T>(T Data)
        {
            var nums = Data as List<int>;

            return new ResultLong(Solve(nums, CalculateFuleConstantRate));
        }

        public IResult PartTwo<T>(T Data)
        {
            var nums = Data as List<int>;

            return new ResultLong(Solve(nums, CalculateFule));
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

        private (int[] arr, List<int> nums, int min, int max, int med) GetMapMinMaxAndMed(List<int> numsInput)
        {
            int[] map = new int[10000];
            int min = int.MaxValue;
            int max = int.MinValue;
            int total = 0;
            List<int> nums = new List<int>();
            foreach (var x in numsInput)
            {
                total += x;
                map[x]++;

                min = Math.Min(x, min);
                max = Math.Max(x, max);

                if(map[x] == 1)
                {
                    nums.Add(x);
                }
            }

            return (map, nums, min, max, total/ numsInput.Count);
        }

        private long CalculateFuleConstantRate(List<int> nums, int[] arr, int dest)
        {
            long Fule = 0;

            foreach (var num in nums)
            {
                Fule += Math.Abs(num - dest) * arr[num];
            }

            return Fule;
        }

        private long CalculateFule(List<int> nums, int[] arr, int dest)
        {
            long Fule = 0;

            foreach (var num in nums)
            {
                Fule += CalculateFule(Math.Abs(num - dest)) * arr[num];
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

        public long Solve(List<int> nums, Func<List<int>, int[], int, long> calculationFunction)
        {
            var mapNumsMaxMinMed = GetMapMinMaxAndMed(nums);
            nums = mapNumsMaxMinMed.nums;
            int lowBound = mapNumsMaxMinMed.min;
            int upperBound = mapNumsMaxMinMed.max;

            long[] chache = new long[upperBound+2];


            long min = int.MaxValue;

            for (int pos = mapNumsMaxMinMed.med; pos <= upperBound && pos >= lowBound;)
            {

                var steps = calcFule(chache, nums, mapNumsMaxMinMed.arr, pos, calculationFunction);
                var stepsMinusOne = calcFule(chache, nums, mapNumsMaxMinMed.arr, pos-1, calculationFunction);
                var stepsPlusOne = calcFule(chache, nums, mapNumsMaxMinMed.arr, pos+1, calculationFunction);


                if(steps < stepsMinusOne &&
                   steps < stepsPlusOne)
                {
                    return steps;
                }

                if (steps < stepsMinusOne)
                {
                    pos++;
                }
                else
                {
                    pos--;
                }

                min = steps;
            }
            return min;
        }

        public long calcFule(long[] chache, List<int> nums, int[] arr, int pos, Func<List<int>, int[], int, long> calculationFunction)
        {
            if(pos < 0)
            {
                return int.MaxValue;
            }
            if (chache[pos] == 0)
            {
                chache[pos] = calculationFunction.Invoke(nums, arr, pos);
            }

            return chache[pos];
        }
    }
}
