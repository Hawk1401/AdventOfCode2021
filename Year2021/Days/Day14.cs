using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021.Days
{
    public class Day14 : IDay
    {
        public int dayNumber => 14;

        public int year => 2021;

        public IResult? FirstTestValue => new ResultLong(1588);
        public IResult? SecondTestValue => new ResultLong(2188189693529);

        public string[] TestInput => new string[]{
        "NNCB",
        " ",
        "CH -> B",
        "HH -> N",
        "CB -> H",
        "NH -> C",
        "HB -> C",
        "HC -> B",
        "HN -> C",
        "NN -> C",
        "BH -> H",
        "NC -> B",
        "NB -> B",
        "BN -> B",
        "BB -> N",
        "BC -> B",
        "CC -> N",
        "CN -> C"
        };

        public object Parser(string[] arg)
        {
            string polymer = arg[0];
            Dictionary<(char one, char two), char> Rules = new Dictionary<(char one, char two), char>();
            for (int i = 2; i < arg.Length; i++)
            {
                var split = arg[i].Split(" -> ");

                Rules.Add((split[0][0], split[0][1]), split[1][0]);
            }

            return new ParsedDataDay14() { PolymerTemplate = polymer, Rules = Rules };
        }

        public IResult PartOne<T>(T Data)
        {
            ParsedDataDay14 parsedData = Data as ParsedDataDay14;
            Dictionary<(char one, char two), long> map = parsedData.GetMap();
            for (int i = 0; i < 10; i++)
            {
                map = oneStep(parsedData.Rules, map);
            }

            return new ResultLong(getScore(map));
        }

        private long getScore(string polymer)
        {
            Dictionary<char, long> map = new Dictionary<char, long>();

            for (int i = 0; i < polymer.Length; i++)
            {
                if (map.ContainsKey(polymer[i]))
                {
                    map[polymer[i]]++;
                }
                else
                {
                    map.Add(polymer[i], 1);
                }
            }

            return map.Values.Max() - map.Values.Min();
        }

        private string oneStep(Dictionary<(char one, char two), char> Rules, string polymer)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < polymer.Length -1; i++)
            {
                stringBuilder.Append(polymer[i]);

                if(Rules.ContainsKey((polymer[i], polymer[i +1])))
                {
                    stringBuilder.Append(Rules[(polymer[i], polymer[i + 1])]);
                }
            }

            stringBuilder.Append(polymer[polymer.Length - 1]);
            return stringBuilder.ToString();
        }

        public IResult PartTwo<T>(T Data)
        {
            ParsedDataDay14 parsedData = Data as ParsedDataDay14;
            Dictionary<(char one, char two), long> map = parsedData.GetMap();
            for (int i = 0; i < 40; i++)
            {
                map = oneStep(parsedData.Rules, map);
            }

            return new ResultLong(getScore(map));
        }

        private Dictionary<(char one, char two), long> oneStep(Dictionary<(char one, char two), char> Rules, Dictionary<(char one, char two), long> map)
        {
            Dictionary<(char one, char two), long> _map = new Dictionary<(char one, char two), long>();
            foreach (var item in map)
            {
                if (Rules.ContainsKey(item.Key))
                {
                    var newKeyFirst = (item.Key.one, Rules[item.Key]);
                    var newKeySecond = (Rules[item.Key], item.Key.two);

                    if (!_map.ContainsKey(newKeyFirst))
                    {
                        _map.Add(newKeyFirst, 0);
                    }
                    if (!_map.ContainsKey(newKeySecond))
                    {
                        _map.Add(newKeySecond, 0);
                    }

                    _map[newKeyFirst] += item.Value;
                    _map[newKeySecond] += item.Value;
                }
                else
                {
                    _map.Add(item.Key, item.Value);
                }
            }
            return _map;
        }

        private long getScore(Dictionary<(char one, char two), long> map)
        {
            Dictionary<char, long> CharMap = new Dictionary<char, long>();


            foreach (var item in map)
            {
                if (!CharMap.ContainsKey(item.Key.one))
                {
                    CharMap.Add(item.Key.one, 0);
                }

                CharMap[item.Key.one] += item.Value;

            }

            return CharMap.Values.Max() - CharMap.Values.Min();
        }

        static IEnumerable<string> ChunksUpto(string str, int maxChunkSize)
        {
            for (int i = 0; i < str.Length; i += maxChunkSize)
                yield return str.Substring(i, Math.Min(maxChunkSize, str.Length - i));
        }
    }

    public class ParsedDataDay14
    {
        public string PolymerTemplate { get; set; }
        public Dictionary<(char one, char two), char> Rules { get; set; }

        public Dictionary<(char one, char two), long> GetMap()
        {

            Dictionary<(char one, char two), long> map = new Dictionary<(char one, char two), long>();
            for (int i = 0; i < PolymerTemplate.Length - 1 ; i++)
            {
                if (!map.ContainsKey((PolymerTemplate[i], PolymerTemplate[i + 1])))
                {
                    map.Add((PolymerTemplate[i], PolymerTemplate[i + 1]) , 0);
                }

                map[(PolymerTemplate[i], PolymerTemplate[i + 1])]++; 
            }

            map.Add((PolymerTemplate[PolymerTemplate.Length - 1], '#') , 1);
            return map;
        }
    }
}
