using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021.Days
{
    public class Day5 : IDay
    {
        public long? FirstTestValue => 5;

        public long? SecondTestValue => 12;

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

        public int dayNumber => 5;

        public int year => 2021;

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

    public class Line
    {
        public (int x1, int y1) Start;
        public (int x2, int y2) End;

        public Line((int x1, int y1) Start, (int x2, int y2) End)
        {
            this.Start = Start;
            this.End = End;
        }


        public List<(int x, int y)> GetPointsPartOne()
        {
            var Points = new List<(int x, int y)>();



            if (Start.x1 == End.x2)
            {
                int x = Start.x1;
                int max = Math.Max(Start.y1, End.y2);
                int min = Math.Min(Start.y1, End.y2);

                for (int y = min; y <= max; y++)
                {
                    Points.Add((x, y));
                }
                return Points;
            }

            if (Start.y1 == End.y2)
            {
                int y = Start.y1;
                int max = Math.Max(Start.x1, End.x2);
                int min = Math.Min(Start.x1, End.x2);

                for (int x = min; x <= max; x++)
                {
                    Points.Add((x, y));
                }
                return Points;
            }

            return Points;
        }

        public List<(int x, int y)> GetPointsPartTwo()
        {
            var Points = GetPointsPartOne();


            // add diagonal 
            if (Start.x1 != End.x2 && Start.y1 != End.y2)
            {
                Points.AddRange(AddDiagonal());
            }

            return Points;
        }

        private List<(int x, int y)> AddDiagonal()
        {
            if (Start.x1 < End.x2)
            {
                return AddDiagonal(Start, End);
            }

            return AddDiagonal(End, Start);

        }


        private List<(int x, int y)> AddDiagonal((int x, int y) start, (int x, int y) end)
        {
            var Points = new List<(int x, int y)>();

            if (start.y > end.y)
            {
                // goning from top left to bottem Rigth

                for (int i = 0; i <= end.x - start.x; i++)
                {
                    Points.Add((start.x + i, start.y - i));
                }
            }
            else
            {
                // goning from bottem left to top Rigth
                for (int i = 0; i <= end.x - start.x; i++)
                {
                    Points.Add((start.x + i, start.y + i));
                }
            }

            return Points;
        }
    }
}
