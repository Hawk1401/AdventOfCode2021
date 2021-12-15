using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021.Days
{
    public class Day12 : IDay
    {
        public int dayNumber => 12;

        public int year => 2021;

        public IResult? FirstTestValue => new ResultLong(10);
        public IResult? SecondTestValue => new ResultLong(36);

        public string[] TestInput => new string[] {
        "start-A",
        "start-b",
        "A-c",
        "A-b",
        "b-d",
        "A-end",
        "b-end"
        };

        public object Parser(string[] args)
        {
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

            for (int i = 0; i < args.Length; i++)
            {
                var arr = args[i].Trim().Split("-");

                AddToMap(map, arr[0], arr[1]);
                AddToMap(map, arr[1], arr[0]);

            }
            return map;
        }

        private void AddToMap(Dictionary<string, List<string>> map, string key, string value)
        {
            if (!map.ContainsKey(key))
            {
                map.Add(key, new List<string>());
            }

            map[key].Add(value);
        }
        public IResult PartOne<T>(T Data)
        {
            Dictionary<string, List<string>> map = Data as Dictionary<string, List<string>>;

            var c = new CaveMapper(map);

            return new ResultLong(c.RunPartOne());



        }
        public IResult PartTwo<T>(T Data)
        {
            Dictionary<string, List<string>> map = Data as Dictionary<string, List<string>>;

            var c = new CaveMapper(map);

            return new ResultLong(c.RunPartTwo());
        }
    }

    public class CaveMapper
    {
        int FinischedWaysCount = 0;

        List<(string curr, HashSet<string> Smallcaces)> PerUnfinischedWays;

        List<(string curr, HashSet<string> Smallcaces, bool Double)> PerUnfinischedWaysPartTwo;

       Dictionary<string, List<string>> map;

        public CaveMapper(Dictionary<string, List<string>> map)
        {
            this.map = map;
        }

        
        public int RunPartOne()
        {
            PerUnfinischedWays = new List<(string curr, HashSet<string> Smallcaces)>();
            var hashset = new HashSet<string>();
            hashset.Add("start");
            PerUnfinischedWays.Add(("start", hashset));
            while (NextGenPartOne()) ;

            return FinischedWaysCount;
        }

        public int RunPartTwo()
        {
            PerUnfinischedWaysPartTwo = new List<(string curr, HashSet<string> Smallcaces, bool Double)>();

            var hashset = new HashSet<string>();
            hashset.Add("start");
            PerUnfinischedWaysPartTwo.Add(("start", hashset, false));
            while (NextGenPartTwo()) ;

            return FinischedWaysCount;
        }


        public bool NextGenPartOne()
        {
            List<(string curr, HashSet<string> Smallcaces)> _unfinischedWays = new List<(string curr, HashSet<string> Smallcaces)>();
            bool newWays = false;
            foreach (var UnfinischedWay in PerUnfinischedWays)
            {
                foreach (var item in map[UnfinischedWay.curr])
                {

                    if (UnfinischedWay.Smallcaces.Contains(item))
                    {
                        continue;
                    }

                    newWays = true;

                    var newCurr = item;
                    var hashset = new HashSet<string>(UnfinischedWay.Smallcaces);

                    if (item.ToLower() == item)
                    {
                        hashset.Add(item);
                    }

                    if (item == "end")
                    {
                        FinischedWaysCount++;
                    }
                    else
                    {
                        _unfinischedWays.Add((newCurr, hashset));
                    }
                }
            }

            PerUnfinischedWays = _unfinischedWays;

            return newWays;
        }
        public bool NextGenPartTwo()
        {
            List<(string curr, HashSet<string> Smallcaces, bool Double)> _unfinischedWays = new List<(string curr, HashSet<string> Smallcaces, bool Double)>();
            bool newWays = false;
            foreach (var UnfinischedWay in PerUnfinischedWaysPartTwo)
            {
                foreach (var item in map[UnfinischedWay.curr])
                {
                    bool b = UnfinischedWay.Double;
                    if (UnfinischedWay.Smallcaces.Contains(item))
                    {
                        if (b || item == "start" || item == "end")
                        {
                            continue;
                        }

                        b = true;
                    }

                    newWays = true;

                    var newCurr = item;
                    var hashset = new HashSet<string>(UnfinischedWay.Smallcaces);

                    if (item.ToLower() == item)
                    {
                        hashset.Add(item);
                    }

                    if (item == "end")
                    {
                        FinischedWaysCount++;
                    }
                    else
                    {
                        _unfinischedWays.Add((newCurr, hashset, b));
                    }
                }
            }

            PerUnfinischedWaysPartTwo = _unfinischedWays;

            return newWays;
        }

    }
}
