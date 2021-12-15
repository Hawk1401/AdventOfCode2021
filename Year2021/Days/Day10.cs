using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021.Days
{
    public class Day10 : IDay
    {
        public int dayNumber => 10;

        public int year => 2021;

        public IResult? FirstTestValue => new ResultLong(26397);
        public IResult? SecondTestValue => new ResultLong(288957);

        public string[] TestInput => new string[]
        {
            "[({(<(())[]>[[{[]{<()<>>",
            "[(()[<>])]({[<{<<[]>>(",
            "{([(<{}[<>[]}>{[]{[(<()>",
            "(((({<>}<{<{<>}{[]{[]{}",
            "[[<[([]))<([[{}[[()]]]",
            "[{[{({}]{}}([{[{{{}}([]",
            "{<[[]]>}<{[{[{[]{()[[[]",
            "[<(<(<(<{}))><([]([]()",
            "<{([([[(<>()){}]>(<<{{",
            "<{([{{}}[<[[[<>{}]]]>[]]"
        };

        public object Parser(string[] arg)
        {
            return arg;
        }

        public IResult PartOne<T>(T Data)
        {
            string[] lines = Data as string[];

            long totalError = 0;

            foreach (var line in lines)
            {
                if(!CheckLineForError(line, out int error))
                {
                    totalError += error;
                }
            }

            return new ResultLong(totalError);
        }

        private bool CheckLineForError(string line, out int error)
        {
            Stack<int> openingStack = new Stack<int>();

            for (int i = 0; i < line.Length; i++)
            {
                int index = MapChar(line[i]);

                if(index < 4)
                {
                    //opening
                    openingStack.Push(index);
                }
                else
                {
                    // closing
                    index = index % 4;
                    if (openingStack.Pop() != index)
                    {
                        error = getError(line[i]);
                        return false;
                    }
                }
            }

            error = 0;
            return true;

        }
        private int MapChar(char c)
        {
            switch (c)
            {
                case '(':
                    return 0;
                case '[':
                    return 1;
                case '{':
                    return 2;
                case '<':
                    return 3;


                case ')':
                    return 4;
                case ']':
                    return 5;
                case '}':
                    return 6;
                case '>':
                    return 7;
            }

            throw new ArgumentException();
        }
        private int getError(char c)
        {
            switch (c)
            {
                case ')':
                    return 3;
                case ']':
                    return 57;
                case '}':
                    return 1197;
                case '>':
                    return 25137;
            }

            throw new ArgumentException();
        }


        public IResult PartTwo<T>(T Data)
        {
            string[] lines = Data as string[];

            List<long> Scores = new List<long>();

            foreach (var line in lines)
            {
                if (CheckLineForIncomplete(line, out long score))
                {
                    Scores.Add(score);
                }
            }
            Scores.Sort();
            return new ResultLong(Scores[(Scores.Count / 2 )]);
        }
        private bool CheckLineForIncomplete(string line, out long score)
        {
            Stack<int> openingStack = new Stack<int>();

            for (int i = 0; i < line.Length; i++)
            {
                int index = MapChar(line[i]);

                if (index < 4)
                {
                    //opening
                    openingStack.Push(index);
                }
                else
                {
                    // closing
                    index = index % 4;
                    if (openingStack.Pop() != index)
                    {
                        score = 0;
                        return false;
                    }
                }
            }

            score = 0;
            foreach (var item in openingStack)
            {
                
                int itemScore = item + 1; // map back to the itemScore

                score *= 5;
                score += itemScore;
            }


            return true;

        }
    }
}
