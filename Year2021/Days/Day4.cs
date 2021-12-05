using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021.Days
{
    public class Day4 : IDay
    {
        public long? FirstTestValue => 4512;

        public long? SecondTestValue => 1924;

        public string[] TestInput => new string[]{
        "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1",
        " ",
        "22 13 17 11  0",
        " 8  2 23  4 24",
        "21  9 14 16  7",
        " 6 10  3 18  5",
        " 1 12 20 15 19",
        " ",
        " 3 15  0  2 22",
        " 9 18 13 17  5",
        "19  8  7 25 23",
        "20 11 10 24  4",
        "14 21 16 12  6",
        " ",
        "14 21 17 24  4",
        "10 16 15  9 19",
        "18  8 23 26 20",
        "22 11 13  6  5",
        " 2  0 12  3  7",
        };

        public int dayNumber => 4;

        public int year => 2021;
        public object Parser(string[] arg)
        {
            var BinogNumbers = arg[0].Split(",").Select(x => int.Parse(x)).ToArray();

            List<Board> boards = new List<Board>();
            for (int i = 2; i < arg.Length; i += 6)
            {
                boards.Add(new Board(arg, i));
            }

            return new Bingo(BinogNumbers, boards);
        }

        public long PartOne<T>(T Data)
        {
            var game = Data as Bingo;
            return game.Start();
        }

        public long PartTwo<T>(T Data)
        {
            var game = Data as Bingo;
            return game.GetLastWinning();
        }

    }
    public class Board
    {
        private int[][] matrix;
        private Dictionary<int, (int x, int y)> map;
        private int _Score = -1;
        private bool Won = false;
        public int Score => _Score;

        public Board()
        {

        }

        public Board(string[] text, int offset)
        {
            matrix = new int[5][];
            map = new Dictionary<int, (int x, int y)>();


            for (int i = offset; i < offset + 5; i++)
            {
                int index = i - offset;
                matrix[index] = text[i].Trim().Split(" ").Where(x => !String.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToArray();

                for (int j = 0; j < matrix[index].Length; j++)
                {
                    map.Add(matrix[index][j], (index, j));
                }
            }
        }

        public int getScore(int lastGussedNumber)
        {
            return map.Keys.Sum() * lastGussedNumber;
        }

        public bool Gusse(int number)
        {
            if (!map.ContainsKey(number))
            {
                return false;
            }

            var coordinates = map[number];
            map.Remove(number);

            Won = check(coordinates);

            if (Won)
            {
                _Score = getScore(number);
            }

            return Won;
        }

        private bool check((int x, int y) coordinates)
        {
            return
                checkHorizontal(coordinates) ||
                checkVertical(coordinates);
            //checkDiagonal(coordinates);
        }

        private bool checkHorizontal((int x, int y) coordinates)
        {
            for (int x = 0; x < 5; x++)
            {
                if (map.ContainsKey(matrix[x][coordinates.y]))
                {
                    return false;
                }
            }
            return true;
        }

        private bool checkVertical((int x, int y) coordinates)
        {
            for (int y = 0; y < 5; y++)
            {
                if (map.ContainsKey(matrix[coordinates.x][y]))
                {
                    return false;
                }
            }
            return true;
        }

        private bool checkDiagonal((int x, int y) coordinates)
        {
            if (coordinates.x != coordinates.y)
            {
                return false;
            }

            for (int xy = 0; xy < 5; xy++)
            {
                if (map.ContainsKey(matrix[xy][xy]))
                {
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        ///Print the Current Board on the console
        ///Red number indicates the marked
        ///and the green number the unmarked
        /// </summary>
        public void print()
        {
            for (int x = 0; x < matrix.Length; x++)
            {
                for (int y = 0; y < matrix.Length; y++)
                {
                    if (map.ContainsKey(matrix[x][y]))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    string s = "";
                    if (matrix[x][y] < 10)
                    {
                        s += " " + matrix[x][y];
                    }
                    else
                    {
                        s += matrix[x][y];

                    }
                    Console.Write(s + " ");
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public Board Copy()
        {
            return new Board() { map = new Dictionary<int, (int x, int y)>(map), matrix = matrix };
        }
    }
    public class Bingo
    {
        private int[] numbers;
        private int index;
        private List<Board> boards;

        public Bingo()
        {

        }
        public Bingo(int[] numbers, List<Board> boards)
        {
            this.numbers = numbers;
            this.boards = boards;

            index = 0;
        }

        public int Start()
        {
            foreach (var number in numbers)
            {
                if (CallNumber(number, out int result))
                {
                    return result;
                }
            }

            return -1;
        }

        public int GetLastWinning()
        {
            foreach (var number in numbers)
            {
                if (CallNumberForLosser(number, out int score))
                {
                    return score;
                }
            }

            return -1;
        }
        public bool CallNumber(int number, out int result)
        {
            foreach (var board in boards)
            {
                if (board.Gusse(number))
                {
                    result = board.Score;
                    return true;

                }
            }

            result = 0;

            return false;
        }
        public bool CallNumberForLosser(int number, out int score)
        {

            List<Board> _boards = new List<Board>(boards);

            foreach (var board in _boards)
            {
                if (board.Gusse(number))
                {
                    if (boards.Count == 1)
                    {
                        score = board.Score;
                        return true;
                    }
                    boards.Remove(board);
                }
            }
            score = -1;
            return false;
        }

        public Bingo Copy()
        {
            return new Bingo() { numbers = numbers, index = 0, boards = boards.Select(x => x.Copy()).ToList() };
        }
    }
}
