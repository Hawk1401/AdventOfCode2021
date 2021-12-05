using Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Year2021.Days.ModelsDay5;

namespace Year2021.Days
{
    public class Day5 : IDay
    {
        public long? FirstTestValue => 5;
        public long? SecondTestValue => 12;
        public int dayNumber => 5;
        public int year => 2021;
        public string[] TestInput => new string[]{
        "0,9 -> 5,9",
        "8,0 -> 0,8",
        "9,4 -> 3,4",
        "2,2 -> 2,1",
        "7,0 -> 7,4",
        "6,4 -> 2,0",
        "0,9 -> 2,9",
        "3,4 -> 1,4",
        "0,0 -> 8,8",
        "5,5 -> 8,2"
        };


        public object Parser(string[] arg)
        {
            return arg.Select(x => Parser(x)).ToList();
        }
        public Line Parser(string s)
        {
            var splits = s.Split("->");

            var firstPonints = splits[0].Trim().Split(",");
            var secondPonints = splits[1].Trim().Split(",");

            return new Line(
                (int.Parse(firstPonints[0]), int.Parse(firstPonints[1])),
                (int.Parse(secondPonints[0]), int.Parse(secondPonints[1]))
                );
        }

        public long PartOne<T>(T Data)
        {
            var Lines = Data as List<Line>;

            var map = new Dictionary<(int x, int y), int>();

            foreach (var line in Lines)
            {
                foreach (var point in line.GetPointsPartOne())
                {
                    AddPoint(point, map);
                }
            }

            return map.Values.ToList().Where(x => x > 1).Count();

        }

        public void AddPoint((int x, int y) Point, Dictionary<(int x, int y), int> map)
        {
            if (map.ContainsKey(Point))
            {
                map[Point]++;
                return;
            }

            map.Add(Point, 1);
        }
        public long PartTwo<T>(T Data)
        {
            var Lines = Data as List<Line>;

            var map = new Dictionary<(int x, int y), int>();

            foreach (var line in Lines)
            {
                foreach (var point in line.GetPointsPartTwo())
                {
                    AddPoint(point, map);
                }
            }

            return map.Values.ToList().Where(x => x > 1).Count();
        }

        
    }
}
