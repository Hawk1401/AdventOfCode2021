using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021.Days
{
    public class Day18 : IDay
    {
        public int dayNumber => 18;

        public int year => 2021;

        public IResult FirstTestValue => new ResultLong(4140);
        public IResult? SecondTestValue => new ResultLong(3937);

        public string[] TestInput => new string[] {
            "[[[0,[5, 8]],[[1,7],[9,6]]],[[4,[1,2]],[[1,4],2]]]",
            "[[[5,[2,8]],4],[5,[[9,9],0]]]",
            "[6,[[[6,2],[5,6]],[[7,6],[4,7]]]]",
            "[[[6,[0,7]],[0,9]],[4,[9,[9,0]]]]",
            "[[[7,[6,4]],[3,[1,3]]],[[[5,5],1],9]]",
            "[[6,[[7,3],[3,2]]],[[[3,8],[5,7]],4]]",
            "[[[[5,4],[7,7]],8],[[8,3],8]]",
            "[[9,3],[[9,9],[6,[4,9]]]]",
            "[[2,[[7,7],7]],[[5,8],[[9,3],[0,2]]]]",
            "[[[[5,2],5],[8,[3,7]]],[[5,[7,5]],[4,4]]]"
        };

        public object Parser(string[] arg)
        {
            return arg;
        }

        public List<Snailfish> ParserForSnailfish(string[] arg)
        {
            var result = new List<Snailfish>();

            foreach (var line in arg)
            {
                result.Add(Parser(line));
            }


            return result;
        }

        public Snailfish Parser(string line)
        {
            Snailfish curr = new Snailfish();

            for (int i = 1; i < line.Length - 1; i++)
            {
                if (line[i] == '[')
                {
                    curr = curr.addNewFish();
                    continue;
                }

                if (line[i] == ']')
                {
                    curr = curr.Parent;
                    continue;

                }

                if (line[i] != ',')
                {
                    curr.addNumber(line[i] - '0');
                }
            }

            curr.CreateNewMap();
            return curr;
        }

        public IResult PartOne<T>(T Data)
        {
            var listOfFishs = ParserForSnailfish(Data as string[]);

            Snailfish result = listOfFishs[0];

            for (int i = 1; i < listOfFishs.Count; i++)
            {
                result = Snailfish.AddTwoSnailfishs(result, listOfFishs[i]);
            }

            return new ResultLong(result.GetMagnitude());
        }

        public IResult PartTwo<T>(T Data)
        {
            var lines = (Data as string[]);

            long max = long.MinValue;

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines.Length; j++)
                {
                    if(i == j)
                    {
                        continue;
                    }

                    long v = Snailfish.AddTwoSnailfishs(Parser(lines[i]), Parser(lines[j])).GetMagnitude();
                    max = Math.Max(max, v);

                }
            }

            return new ResultLong(max);

        }
    }

    public interface SnailfishItem
    {
        public string Print();
        public void CreateNewMap(List<SnailfishNumber> map);

        public long GetMagnitude();
    }


    public class SnailfishNumber : SnailfishItem
    {
        public int Number { get; set; }
        public Snailfish Parent;

        public SnailfishNumber(int number, Snailfish parent)
        {
            Number = number;
            Parent = parent;
        }

        public string Print()
        {
            return Number.ToString();
        }

        public void CreateNewMap(List<SnailfishNumber> map)
        {
            map.Add(this);
        }
        public override string ToString()
        {
            return Number.ToString();
        }

        public long GetMagnitude()
        {
            return Number;
        }
    }

    public class Snailfish : SnailfishItem
    {
        public List<SnailfishItem> Subs;
        public Snailfish Parent;
        public List<SnailfishNumber> map = new List<SnailfishNumber>(); 
        public int NestCount { get; private set; }
        public bool IsPair { get; private set; }

        public Snailfish()
        {
            Subs = new List<SnailfishItem>();
        }

        public Snailfish(Snailfish Parent)
        {
            Subs = new List<SnailfishItem>();
            this.Parent = Parent;

            NestCount = Parent.NestCount + 1;
            map = Parent.map;
        }

        public void UpdateNestCount()
        {
            if(Parent is not null)
            {
                NestCount = Parent.NestCount + 1;
            }

            foreach (var sub in Subs)
            {
                if(sub is Snailfish _sub)
                {
                    _sub.UpdateNestCount();
                }
            }
        }

        public void addNumber(int i)
        {
            Subs.Add(new SnailfishNumber(i, this));

            if(Subs.Count == 2)
            {
                if(Subs[0] is SnailfishNumber)
                {
                    IsPair = true;
                }
            }
        }

        public void ReplaceWithNumber(int i, int index)
        {
            var old = Subs[index] as Snailfish;
            Subs[index] = new SnailfishNumber(i, this);

            if (Subs.Count == 2)
            {
                if (Subs[0] is SnailfishNumber)
                {
                    IsPair = true;
                }
            }
        }

        public Snailfish addNewFish()
        {
            var fish = new Snailfish(this);
            Subs.Add(fish);
            IsPair = false;
            return fish;
        }

        public Snailfish addNewFish(Snailfish snailfish)
        {
            snailfish.Parent = this;
            snailfish.map = this.map;
            AddMapToSubs(snailfish);
            Subs.Add(snailfish);

            return snailfish;
        }

        private void AddMapToSubs(Snailfish snailfish)
        {
            snailfish.map = map;
            for (int i = 0; i < snailfish.Subs.Count; i++)
            {
                if(snailfish.Subs[i] is Snailfish _snailfish)
                {
                    AddMapToSubs(_snailfish);
                }
            }
        }

        public void CreateNewMap()
        {
            var _map = new List<SnailfishNumber>();
            CreateNewMap(_map);

            map.Clear();
            map.AddRange(_map);
        }

        public void CreateNewMap(List<SnailfishNumber> map)
        {
            for (int i = 0; i < Subs.Count; i++)
            {
                Subs[i].CreateNewMap(map);
            }
        }
        public string Print()
        {
            var sb = new StringBuilder();

            sb.Append("[");

            for (int i = 0; i < Subs.Count; i++)
            {
                if (i > 0)
                {
                    sb.Append(",");
                }


                sb.Append(Subs[i].Print());
            }

            sb.Append("]");

            return sb.ToString();
        }

        public bool explode()
        {

            if (NestCount < 3)
            {
                foreach (var sub in Subs)
                {
                    if (sub is Snailfish _sub)
                    {
                        if (_sub.explode())
                        {
                            return true;
                        }
                    }
                }
                return false;
            }

            //Pairs need to explode
            for (int i = 0; i < 2; i++)
            {
                if (isPair(Subs[i]))
                {
                    var Pair = Subs[i] as Snailfish;
                    Pair.explode(Pair == this.Subs[0]);

                    ReplaceWithNumber(0,i);
                    return true;
                }
            }
            return false;

        }

        public void explode(bool isLeft)
        {
            int LeftIndex = map.IndexOf(Subs[0] as SnailfishNumber);
            int RigthIndex = LeftIndex + 1;

            if (LeftIndex > 0)
            {
                map[LeftIndex - 1].Number += map[LeftIndex].Number;
            }

            if (RigthIndex < map.Count - 1)
            {
                map[RigthIndex + 1].Number += map[RigthIndex].Number;
            }
        }

        private IEnumerable<Snailfish> GetPairs()
        {
            foreach (var sub in Subs)
            {
                if (sub is Snailfish _sub)
                {
                    if (_sub.IsPair)
                    {
                        yield return _sub;
                    }
                }
            }
        }

        private static bool isPair(SnailfishItem snailfishItem)
        {
            if (snailfishItem is Snailfish snailfish)
            {
                return snailfish.IsPair;
            }
            return false;
        }

        public SnailfishNumber GetMostRigth(Snailfish snailfish)
        {
            var curr = snailfish;

            while(curr.Subs.Count != 0)
            {
                if(snailfish.Subs[1] is SnailfishNumber snailfishNumber)
                {
                    return snailfishNumber;
                }

                curr = snailfish.Subs[1] as Snailfish;
            }

            throw new ArgumentException();
        }

        public static Snailfish addition(Snailfish left, Snailfish rigth)
        {
            var result = new Snailfish();

            result.addNewFish(left);
            result.addNewFish(rigth);


            result.UpdateNestCount();
            result.CreateNewMap();
            return result;
        }

        public bool split()
        {
            CreateNewMap();

            for (int i = 0; i < map.Count; i++)
            {
                if(map[i].Number > 9)
                {
                    var snail = new Snailfish(map[i].Parent);

                    var half = ((double)map[i].Number) / 2;

                    snail.addNumber((int)half);

                    snail.addNumber((int)(half + 0.5));

                    if(map[i].Parent.Subs[0] == map[i])
                    {
                        map[i].Parent.Subs[0] = snail;
                    }
                    else
                    {
                        map[i].Parent.Subs[1] = snail;
                    }
                    return true;

                }

            }
            return false;

        }

        public override string ToString()
        {
            return Print();
        }

        public static Snailfish AddTwoSnailfishs(Snailfish First, Snailfish Second)
        {
            var result = addition(First, Second);


            Explode(result);

            while (result.split())
            {
                Explode(result);
            };

            return result;
        }

        public static void Explode(Snailfish result)
        {
            result.UpdateNestCount();
            result.CreateNewMap();
            while (result.explode())
            {
                result.UpdateNestCount();
                result.CreateNewMap();
            }
        }

        public long GetMagnitude()
        {
            return (Subs[0].GetMagnitude() * 3) + (Subs[1].GetMagnitude() * 2);
         }
    }
}

/*
 * [[[[[9,8],1],2],3],4] becomes [[[[0,9],2],3],4] (the 9 has no regular number to its left, so it is not added to any regular number).
 * 
[7,[6,[5,[4,[3,2]]]]] becomes [7,[6,[5,[7,0]]]] (the 2 has no regular number to its right, and so it is not added to any regular number).

[[6,[5,[4,[3,2]]]],1] becomes [[6,[5,[7,0]]],3].

[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]] becomes [[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]] (the pair [3,2] is unaffected because the pair [7,3] is further to the left; [3,2] would explode on the next action).

[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]] becomes [[3,[2,[8,0]]],[9,[5,[7,0]]]].*/
