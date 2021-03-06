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
        public IResult? FirstTestValue => new ResultLong(5);
        public IResult? SecondTestValue => new ResultLong(12);
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

        public IResult PartOne<T>(T Data)
        {
            var Lines = Data as List<Line>;


            int[][] map = new int[1000][];
            for (int i = 0; i < map.Length; i++)
            {
                map[i] = new int[1000];
            }

            long count = 0;

            foreach (var line in Lines)
            {
                foreach (var point in line.GetPointsPartOne())
                {
                    if(AddPoint(point, map))
                    {
                        count++;
                    }
                }
            }

            return new ResultLong(count);
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

        public bool AddPoint((int x, int y) Point, int[][] map)
        {
            map[Point.x][Point.y]++;
            return map[Point.x][Point.y] == 2;
        }
        public IResult PartTwo<T>(T Data)
        {
            var Lines = Data as List<Line>;


            int[][] map = new int[1000][];
            for (int i = 0; i < map.Length; i++)
            {
                map[i] = new int[1000];
            }

            long count = 0;

            foreach (var line in Lines)
            {
                foreach (var point in line.GetPointsPartTwo())
                {
                    if (AddPoint(point, map))
                    {
                        count++;
                    }
                }
            }

            return new ResultLong(count);
        }

        
    }
}
