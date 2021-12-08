using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021.Days
{
    public class Day8 : IDay
    {
        public int dayNumber => 8;

        public int year => 2021;

        public long? FirstTestValue => 26;

        public long? SecondTestValue => 61229;

        public string[] TestInput => new string[]{
        "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe",
        "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc",
        "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg",
        "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb",
        "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea",
        "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb",
        "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe",
        "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef",
        "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb",
        "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce" };

        public object Parser(string[] args)
        {
            var output = new string[args.Length][];

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = args[i].Split("|");
            }

            return output;
        }

        public long PartOne<T>(T Data)
        {
            var strings = Data as string[][];

            int count = 0;
            foreach (var line in strings)
            {
                foreach (var number in line[1].Trim().Split(" "))
                {
                    int numberLength = number.Length;

                    if(numberLength == 2 ||
                        numberLength == 4 ||
                        numberLength == 3 ||
                        numberLength == 7)
                    {
                        count++;
                    }
                }
            }
            return count;

        }

        public long PartTwo<T>(T Data)
        {
            var Lines = Data as string[][];

            long SumOfOutputs = 0;
            foreach (var line in Lines)
            {
                var input = line[0].Trim();
                var mapper = new Mapper(input);
                

                SumOfOutputs += mapper.MapOutput(line[1]);
            }

            return SumOfOutputs;
        }
    }

    public class Mapper
    {
        Dictionary<string, int> map = new Dictionary<string, int>();
        public Mapper(string toMapp)
        {
            var nums = toMapp.Trim().Split(" ").Select(x => SortString(x));

            string One = nums.FirstOrDefault(x => x.Length == 2);
            string Four = nums.FirstOrDefault(x => x.Length == 4);
            string Seven = nums.FirstOrDefault(x => x.Length == 3);
            string Eight = nums.FirstOrDefault(x => x.Length == 7);

            var ZeroSixNine = nums.Where(x => x.Length == 6);

            string Nine = "";
            string Zero = "";

            foreach (var candidate in ZeroSixNine)
            {
                if (HasSameChars(candidate, Four))
                {
                    Nine = candidate;
                    continue;
                }

                if (HasSameChars(candidate, One))
                {
                    Zero = candidate;
                    continue;
                }
            }

            string Six = ZeroSixNine.First(x => x != Nine && x != Zero);
            ZeroSixNine = null;


            char A = getMissingChar(Seven, One);
            char C = getMissingChar(Eight, Six);
            char D = getMissingChar(Eight, Zero);
            char E = getMissingChar(Eight, Nine);
            char F = getMissingChar(One, C);
            char B = getMissingChar(Four, C,D,F);
            char G = getMissingChar("abcdefg", A,B,C,D,E,F);

            string Two = SortString(A, C, D, E, G);
            string Three = SortString(A, C, D, F, G);
            string Five = SortString(A, B, D, F, G);

            map.Add(Zero, 0) ;
            map.Add(One, 1);
            map.Add(Two, 2);
            map.Add(Three, 3);
            map.Add(Four, 4);
            map.Add(Five, 5);
            map.Add(Six, 6);
            map.Add(Seven, 7);
            map.Add(Eight, 8);
            map.Add(Nine, 9);
        }
        public int MapOutput(string output)
        {
            var nums = output.Trim().Split(" ").Select(x => GetMapStringToNumber(SortString(x)));
            int MappedOutput = 0;
            for (int i = 0; i < nums.Count(); i++)
            {
                MappedOutput *= 10;
                MappedOutput += nums.ElementAt(i);
            }

            return MappedOutput;
        }
        public int GetMapStringToNumber(string s)
        {
            string sorted = SortString(s);
            return map[sorted];
        }

        private char getMissingChar(string longString, string shortString)
        {
            foreach (var c in longString)
            {
                if (!shortString.Contains(c))
                {
                    return c;
                }
            }

            throw new ArgumentException();
        }

        private char getMissingChar(string longString, params char[] unwantedCs)
        {
            foreach (var c in longString)
            {
                if (!unwantedCs.Contains(c))
                {
                    return c;
                }
            }

            throw new ArgumentException();
        }

        public bool HasSameChars(string longString, string shortString)
        {
            foreach (var c in shortString)
            {
                if (!longString.Contains(c))
                {
                    return false;
                }
            }
            return true;
        }

        public string SortString(string ToSort)
        {
            return String.Concat(ToSort.OrderBy(c => c));
        }

        public string SortString(params char[] ToSort)
        {
            return String.Concat(ToSort.OrderBy(c => c));
        }
    }
}
