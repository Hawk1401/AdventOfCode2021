using Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Year2021.Days.ModelsDay4;

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
}
