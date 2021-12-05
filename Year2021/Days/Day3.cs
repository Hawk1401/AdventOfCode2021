using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021.Days
{
    public class Day3 : IDay
    {
        public long? FirstTestValue => 198;

        public long? SecondTestValue => 230;

        public string[] TestInput => new string[]{
        "00100",
        "11110",
        "10110",
        "10111",
        "10101",
        "01111",
        "00111",
        "11100",
        "10000",
        "11001",
        "00010",
        "01010",
        };

        public int dayNumber => 3;

        public int year => 2021;

        public object Parser(string[] arg)
        {
            return arg.Select(x => x.Trim()).ToList();
        }

        public long PartOne<T>(T Data)
        {
            var Strings = Data as List<string>;

            var bitcount = new int[Strings[0].Length];

            for (int i = 0; i < Strings.Count; i++)
            {
                CountBits(Strings[i], bitcount);
            }

            int gamma = 0;
            int epsilon = 0;
            ArrayToGammaAndEpsilon(bitcount, ref gamma, ref epsilon);

            return gamma * epsilon;
        }

        private void ArrayToGammaAndEpsilon(int[] bitcount, ref int gamma, ref int epsilon)
        {
            for (int i = 0; i < bitcount.Length; i++)
            {
                gamma = gamma << 1;
                epsilon = epsilon << 1;

                if (bitcount[i] > 0)
                {
                    gamma = (gamma + 1);
                }
                else
                {
                    epsilon = (epsilon + 1);
                }
            }
        }

        private void CountBits(string word, int[] bitcount)
        {
            for (int j = 0; j < word.Length; j++)
            {
                if (word[j] == '1')
                {
                    bitcount[j]++;
                }
                else
                {
                    bitcount[j]--;
                }
            }
        }

        public long PartTwo<T>(T Data)
        {
            var Strings = Data as List<string>;
            int stringLength = Strings[0].Length;


            var oxygenGeneratorCandidates = new List<string>(Strings);
            for (int i = 0; i < stringLength && oxygenGeneratorCandidates.Count > 1; i++)
            {
                oxygenGeneratorCandidates = GetNumbersWithMostCommonBit(oxygenGeneratorCandidates, i);
            }


            var scrubberRatingCandidates = new List<string>(Strings);
            for (int i = 0; i < stringLength && scrubberRatingCandidates.Count > 1; i++)
            {
                scrubberRatingCandidates = GetNumbersWithLeastCommonBit(scrubberRatingCandidates, i);
            }


            int oxygenGenerator = Convert.ToInt32(oxygenGeneratorCandidates[0], 2);
            int scrubberRating = Convert.ToInt32(scrubberRatingCandidates[0], 2);

            return oxygenGenerator * scrubberRating;
        }

        public bool HasMoreOnes(List<string> strings, int index, out List<string> WithOnes, out List<string> WithZeros)
        {
            int count = 0;
            WithOnes = new List<string>();
            WithZeros = new List<string>();

            for (int i = 0; i < strings.Count; i++)
            {
                if (strings[i][index] == '1')
                {
                    count++;
                    WithOnes.Add(strings[i]);
                }
                else
                {
                    count--;
                    WithZeros.Add(strings[i]);
                }
            }

            return count >= 0;
        }

        public List<string> GetNumbersWithMostCommonBit(List<string> strings, int index)
        {
            if (HasMoreOnes(strings, index, out List<string> WithOnes, out List<string> WithZeros))
            {
                return WithOnes;
            }

            return WithZeros;
        }

        public List<string> GetNumbersWithLeastCommonBit(List<string> strings, int index)
        {
            if (strings.Count == 1)
            {
                return strings;
            }

            if (HasMoreOnes(strings, index, out List<string> WithOnes, out List<string> WithZeros))
            {
                return WithZeros;
            }

            return WithOnes;
        }


    }

}
