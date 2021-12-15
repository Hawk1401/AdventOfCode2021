using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021.Days
{
    public class Day13 : IDay
    {
        public int dayNumber => 13;

        public int year => 2021;

        public IResult? FirstTestValue => new ResultLong(17);
        public IResult? SecondTestValue => new ResultStringArray(
            new string[] {
            "#####",
            "#   #",
            "#   #",
            "#   #",
            "#####"
            });

        public string[] TestInput => new string[] {
        "6,10",
        "0,14",
        "9,10",
        "0,3",
        "10,4",
        "4,11",
        "6,0",
        "6,12",
        "4,1",
        "0,13",
        "10,12",
        "3,4",
        "3,0",
        "8,4",
        "1,10",
        "2,14",
        "8,10",
        "9,0",
        "",
        "fold along y=7",
        "fold along x=5"
        };

        public object Parser(string[] arg)
        {

            HashSet<(int x, int y)> Dots = new HashSet<(int x, int y)>();
            List<(bool OnX, int cord)> Folds = new List<(bool OnX, int cord)>();

            int index = 0;
            while (!string.IsNullOrEmpty(arg[index]))
            {
                var splits = arg[index].Split(",");

                var dot = (int.Parse(splits[0]), int.Parse(splits[1]));

                Dots.Add(dot);
                index++;
            }
            index++;

            for (int i = index; i < arg.Length; i++)
            {
                var splits = arg[i].Split(" ")[2].Split("=");

                Folds.Add((splits[0] == "x", int.Parse(splits[1])));
                
            }

            return new ParsedDay13Data() { Dots = Dots, Folds = Folds };
        }

        public IResult PartOne<T>(T Data)
        {
            ParsedDay13Data parsedDay13 = Data as ParsedDay13Data;

            var dots = FoldPaper(parsedDay13.Dots, parsedDay13.Folds[0]);

            return new ResultLong(dots.LongCount());
        }

        public IResult PartTwo<T>(T Data)
        {
            ParsedDay13Data parsedDay13 = Data as ParsedDay13Data;

            var dots = parsedDay13.Dots;

            foreach (var fold in parsedDay13.Folds)
            {
                dots = FoldPaper(dots, fold);
            }
            var result = Print(dots);
            return new ResultStringArray(result);
        }

        public HashSet<(int x, int y)> FoldPaper(HashSet<(int x, int y)> Dots, (bool OnX, int cord) FoldInfo)
        {
            if (FoldInfo.OnX)
            {
                return FoldPaperOnX(Dots, FoldInfo.cord);
            }
            else
            {
                return FoldPaperOnY(Dots, FoldInfo.cord);
            }
        }

        public HashSet<(int x, int y)> FoldPaperOnX(HashSet<(int x, int y)> Dots, int cord)
        {
            HashSet<(int x, int y)> _Dots = new HashSet<(int x, int y)>();
            foreach (var dot in Dots)
            {
                if (dot.x > cord)
                {
                    var _dot = (cord + (cord - dot.x), dot.y);
                    _Dots.Add(_dot);

                }
                else
                {
                    _Dots.Add(dot);
                }
            }

            return _Dots;
        }

        public HashSet<(int x, int y)> FoldPaperOnY(HashSet<(int x, int y)> Dots, int cord)
        {
            HashSet<(int x, int y)> _Dots = new HashSet<(int x, int y)>();
            foreach (var dot in Dots)
            {
                if (dot.y > cord)
                {
                    var _dot = (dot.x, cord + (cord - dot.y));
                    _Dots.Add(_dot);

                }
                else
                {
                    _Dots.Add(dot);
                }
            }

            return _Dots;
        }

        public string[] Print(HashSet<(int x, int y)> Dots)
        {

            List<string> result = new List<string>();
            int xMax = 0;
            int yMax = 0;

            foreach (var Dot in Dots)
            {
                xMax = Math.Max(xMax, Dot.x);
                yMax = Math.Max(yMax, Dot.y);
            }

            for (int y = 0; y <= yMax; y++)
            {
                StringBuilder sb = new StringBuilder();
                for (int x = 0; x <= xMax; x++)
                {
                    if (Dots.Contains((x, y)))
                    {
                        sb.Append("#");
                    }
                    else
                    {
                        sb.Append(" ");

                    }
                }
                result.Add(sb.ToString());
            }

            return result.ToArray();
        }
    }

    public class ParsedDay13Data
    {
        public HashSet<(int x, int y)> Dots { get; set; }
        public List<(bool OnX, int cord)> Folds { get; set; }
    }
}
