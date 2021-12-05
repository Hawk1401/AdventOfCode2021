using System.Collections.Generic;
using System.Linq;

namespace Year2021.Days.ModelsDay4
{
    public class Bingo
    {
        private int[] numbers;
        private List<Board> boards;

        public Bingo()
        {

        }
        public Bingo(int[] numbers, List<Board> boards)
        {
            this.numbers = numbers;
            this.boards = boards;
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
            return new Bingo() { numbers = numbers, boards = boards.Select(x => x.Copy()).ToList() };
        }
    }
}
