using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021.Days
{
    public class Day11 : IDay
    {
        public int dayNumber => 11;

        public int year => 2021;

        public IResult? FirstTestValue => new ResultLong(1656);
        public IResult? SecondTestValue => new ResultLong(195);

        public string[] TestInput => new string[] {
        "5483143223",
        "2745854711",
        "5264556173",
        "6141336146",
        "6357385478",
        "4167524645",
        "2176841721",
        "6882881134",
        "4846848554",
        "5283751526"
        };

        public object Parser(string[] arg)
        {
            int[][] cs = new int[arg.Length][];
            for (int i = 0; i < cs.Length; i++)
            {
                cs[i] = arg[i].Trim().Select(x => x - '0').ToArray();
            }

            return cs;
        }


        private long explosinCounterPartOne = 0;
        public IResult PartOne<T>(T Data)
        {
            int[][] matrix = Data as int[][];

            var watcher = new OctopusesWatcher(matrix);

            return new ResultLong(watcher.Run(100));
        }


        public void Explode(int[][] matrix, HashSet<(int x, int y)> exploded, int x, int y)
        {
            explosinCounterPartOne++;
            for (int _x = x-1; _x <= x+1; _x++)
            {
                if (_x < 0 ||
                    _x >= matrix.Length)
                {
                    continue;
                }

                for (int _y = y-1; _y <= y+1; _y++)
                {
                    if (
                    (_x == x && _y == y) ||
                    _y < 0 ||
                    _y >= matrix[_x].Length ||
                    exploded.Contains((_x, _y)))
                    {
                        continue;
                    }

                    matrix[_x][_y]++;
                    if(matrix[_x][_y] > 9)
                    {
                        Explode(matrix, exploded, _x, _y);
                    }
                }


            }
        }

        public IResult PartTwo<T>(T Data)
        {
            int[][] matrix = Data as int[][];

            var watcher = new OctopusesWatcher(matrix);

            return new ResultLong(watcher.AllFlashed());
        }
    }

    public class OctopusesWatcher
    {
        private HashSet<(int x, int y)> exploded = new HashSet<(int x, int y)>();
        private int[][] matrix;
        private long TotalExplosions = 0;

        public OctopusesWatcher(int[][] matrix)
        {
            this.matrix = matrix.Select(x => x.ToArray()).ToArray();
        }

        public long Run(int Steps)
        {
            for (int i = 0; i < Steps; i++)
            {
                runOneStep();
            }
            return TotalExplosions;
        }

        public long AllFlashed()
        {
            int totalOctopuse = matrix.Length * matrix[0].Length;
            for (int i = 1; i < int.MaxValue; i++)
            {
                runOneStep();
                if(exploded.Count == totalOctopuse)
                {
                    return i;
                }
            }

            return -1;
        }
        private void runOneStep()
        {
            exploded.Clear();

            for (int x = 0; x < matrix.Length; x++)
            {
                for (int y = 0; y < matrix[x].Length; y++)
                {
                   if(Increase(x, y))
                    {
                        Explode(x, y);
                    }
                }
            }

            TotalExplosions += exploded.Count;
        }
        public void Explode(int x, int y)
        {
            for (int _x = x - 1; _x <= x + 1; _x++)
            {
                if (_x < 0 ||
                    _x >= matrix.Length)
                {
                    continue;
                }

                for (int _y = y - 1; _y <= y + 1; _y++)
                {
                    if (
                    (_x == x && _y == y) ||
                    _y < 0 ||
                    _y >= matrix[_x].Length ||
                    exploded.Contains((_x, _y)))
                    {
                        continue;
                    }

                    if (Increase(_x, _y))
                    {
                        Explode(_x, _y);
                    }
                }


            }
        }

        public bool Increase(int x, int y)
        {
            if (exploded.Contains((x, y)))
            {
                return false;
            }

            matrix[x][y]++;

            if(matrix[x][y] > 9)
            {
                exploded.Add((x, y));
                matrix[x][y] = 0;
                return true;
            }

            return false;

        }
    }
}
