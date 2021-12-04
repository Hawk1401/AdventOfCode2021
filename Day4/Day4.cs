using Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    public class Day4 : IDay
    {
        static void Main(string[] args)
        {
            IDay day = new Day4();
            day.Run(4512, 1924, Parse);
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


        public static Bingo Parse(string[] input)
        {
            var BinogNumbers = input[0].Split(",").Select(x => int.Parse(x)).ToArray();

            List<Board> boards = new List<Board>();
            for (int i = 2; i < input.Length; i += 6)
            {
                boards.Add(new Board(input, i));
            }
            
            return new Bingo(BinogNumbers, boards);
        }
    }


    public class Board
    {
        private int[][] matrix;
        private Dictionary<int, (int x, int y)> map;
        private int _Score = -1;
        private bool Won = false;
        public int Score => _Score;

        public Board(string[] text, int offset)
        {
            matrix = new int[5][];
            map = new Dictionary<int, (int x, int y)>();


            for (int i = offset; i < offset+5; i++)
            {
                int index = i - offset;
                matrix[index] = text[i].Trim().Split(" ").Where(x=> !String.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToArray();

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
                if (map.ContainsKey(matrix[x][coordinates.y])){
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
            if(coordinates.x != coordinates.y)
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
                    if(matrix[x][y] < 10)
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
    }
    public class Bingo
    {
        private int[] numbers;
        private int index;
        private List<Board> boards;
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
                if(CallNumber(number, out int result))
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

        public bool  CallNumberForLosser(int number, out int score)
        {

            List<Board> _boards = new List<Board>(boards);

            foreach (var board in _boards)
            {
                if (board.Gusse(number))
                {
                    if(boards.Count == 1)
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
    }
}
