using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021.Days
{
    public class Day17 : IDay
    {
        public int dayNumber => 17;

        public int year => 2021;

        public IResult FirstTestValue => new ResultLong(45);
        public IResult? SecondTestValue => new ResultLong(112);

        
        public string[] TestInput => new string[] { "target area: x=20..30, y=-10..-5" };

        public object Parser(string[] arg)
        {
            var split = arg[0].Trim().Split(": ")[1].Split(", ");

            var x = split[0].Replace("x=", "").Split("..");
            var y = split[1].Replace("y=", "").Split("..");

            return new TargetArea(int.Parse(x[0]), int.Parse(x[1]), int.Parse(y[0]), int.Parse(y[1]));
        }

        public IResult PartOne<T>(T Data)
        {
            TargetArea target = Data as TargetArea;

            return new ResultLong(getMaxY(target));
        }

        private (long[] Fx, HashSet<long> map) getMap()
        {
            int maxVel = 500;
            long[] Fx = new long[maxVel];
            HashSet<long> map = new HashSet<long>();
            for (int i = 1; i < Fx.Length; i++)
            {
                Fx[i] = Fx[i - 1] + i;
                map.Add(Fx[i]);
            }

            return (Fx, map);
        }
        

        private long getMaxY(TargetArea target)
        {
            var MapTupple = getMap();

            long[] Fx = MapTupple.Fx;
            HashSet<long> map = MapTupple.map;


            long max = long.MinValue;
            for (int i = 0; i < Fx.Length; i++)
            {
                long vertex = Fx[i];

                for (int k = target.yMin; k < target.yMax; k++)
                {
                    long diff = vertex - k;

                    if (map.Contains(diff))
                    {
                        max = Math.Max(max, vertex);
                        break;
                    }
                }
            }

            return max;
        }


        public IResult PartTwo<T>(T Data)
        {
            TargetArea target = Data as TargetArea;

            var ySet = GetYSet(target);

            foreach (var item in Enumerable.Range(target.yMin, Math.Abs(target.yMin) + 1))
            {
                ySet.Add(item);
            }

            var xSet = GetXSet(target);

            long count = 0;
            List<(int x, int y)> hits = new List<(int x, int y)>();
            foreach (var x in xSet)
            {
                foreach (var y in ySet)
                {

                    if(WillHit(target, x, y))
                    {
                        count++;
                        hits.Add((x, y));
                    }
                }
            }

            var overHead = count- (xSet.Count * ySet.Count);

            return new ResultLong(count);
        }


        private bool WillHit(TargetArea target, int x, int y)
        {
            var hitStatus = target.CanHit(x, y);
            int posX = x;
            int posY = y;

            while (hitStatus == Days.Hit.CanHit)
            {
                hitStatus = target.CanHit(posX, posY);

                if(x > 0)
                {
                    x--;
                }
                y--;
                posX += x;
                posY += y;
            }

            return hitStatus == Days.Hit.Hit;
        }

        private HashSet<int> GetXSet(TargetArea target)
        {
            var result = new HashSet<int>();

            for (int i = 1; i <= target.xMax; i++)
            {
                if(XWillHitTarget(target, i, out int step))
                {
                    result.Add(i);
                }
            }


            return result;
        }

        private bool XWillHitTarget(TargetArea target, int x, out int steps)
        {

            int pos = 0;
            for (int i = x; i >= 0; i--)
            {
                pos += i;
                if (pos < target.xMin)
                {
                    continue;
                }

                steps = x-i;
                if(steps == x)
                {
                    steps *= -100;
                }
                return pos <= target.xMax;
            }
            steps =  - 1;
            return false;
        }
        
        private HashSet<int> GetYSet(TargetArea target)
        {
            var MapTupple = getMap();

            long[] Fx = MapTupple.Fx;
            HashSet<long> map = MapTupple.map;
            var result = new HashSet<int>();

            for (int i = 0; i < Fx.Length; i++)
            {
                long vertex = Fx[i];

                for (int k = target.yMin; k <= target.yMax; k++)
                {
                    long diff = vertex - k;

                    if (map.Contains(diff))
                    {

                        result.Add(i);
                        break;
                    }
                }
            }

            return result;
        }
    }
    public class TargetArea
    {
        public int xMin { get; private set; }
        public int xMax { get; private set; }
        public int yMin { get; private set; }
        public int yMax { get; private set; }

        public TargetArea(int x1, int x2, int y1, int y2)
        {
            xMax = Math.Max(x1, x2);
            xMin = Math.Min(x1, x2);
            yMin = Math.Min(y1, y2);
            yMax = Math.Max(y1, y2);
        }

        public Hit CanHit(int x, int y)
        {

            if(x > xMax || y < yMin)
            {
                return Hit.CanNotHit;
            }

            if(x >= xMin && y <= yMax)
            {
                return Hit.Hit;
            }

            return Hit.CanHit;
        }
    }

    public enum Hit
    {
        CanHit,
        Hit,
        CanNotHit
    }
}
