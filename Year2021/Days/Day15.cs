
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021.Days
{

    public class Day15 : IDay
    {
        public int dayNumber => 15;

        public int year => 2021;

        public IResult? FirstTestValue => new ResultLong(40);
        public IResult? SecondTestValue => new ResultLong(315);

        public string[] TestInput => new string[]{
            
            "1163751742",
            "1381373672",
            "2136511328",
            "3694931569",
            "7463417111",
            "1319128137",
            "1359912421",
            "3125421639",
            "1293138521",
            "2311944581"

            };

        public object Parser(string[] arg)
        {
            byte[][] map = new byte[arg.Length][];
            for (int i = 0; i < arg.Length; i++)
            {
                map[i] = arg[i].Select(x => (byte)(x - '0')).ToArray();
            }

            return map;
        }

        public IResult PartOne<T>(T Data)
        {
            byte[][] mapOfRiskLevel = Data as byte[][];

            var aStar = new AStar(mapOfRiskLevel);

            long result = aStar.Run((0,0),(mapOfRiskLevel.Length-1, mapOfRiskLevel[mapOfRiskLevel.Length - 1].Length - 1));
            return new ResultLong(result);
        }

        public IResult PartTwo<T>(T Data)
        {
            byte[][] mapOfRiskLevel = Data as byte[][];
            byte[][] bigMap = CreateBigMap(mapOfRiskLevel);

            var aStar = new AStar(bigMap);

            long result = aStar.Run((0, 0), (bigMap.Length - 1, bigMap[bigMap.Length - 1].Length - 1));
            return new ResultLong(result);
        }

        public byte[][] CreateBigMap(byte[][] SmallMap)
        {
            byte[][] BigMap = new byte[SmallMap.Length * 5][];
            for (int i = 0; i < SmallMap.Length; i++)
            {
                byte[] line = MakeLineFromSmallLine(SmallMap[i]);
                BigMap[i] = line;

            }
            for (int i = SmallMap.Length; i < BigMap.Length; i++)
            {
                int index = i - SmallMap.Length;
                byte[] line = incressLine(BigMap[index]);
                BigMap[i] = line;

            }
            return BigMap;
        }
        private byte[] incressLine(byte[] oldLine) {
            byte[] line = new byte[oldLine.Length];

            for (int i = 0; i < line.Length; i++)
            {
                int temp = oldLine[i] + 1;
                byte value = (byte)((temp % 10) + (temp / 10)); 
                line[i] = value;
            }

            return line;
        }
        private byte[] MakeLineFromSmallLine(byte[] smallLine)
        {
            byte[] line = new byte[smallLine.Length * 5];
            for (int i = 0; i < line.Length; i++)
            {
                int temp = (smallLine[i % smallLine.Length] + (i / smallLine.Length));
                byte value = (byte)((temp % 10) + temp / 10);
                line[i] = value;
            }
            return line;
        }
    }

    public class AStar
    {
        private byte[][] mapOfRiskLevel;

        public AStar(byte[][] mapOfRiskLevel)
        {
            this.mapOfRiskLevel = mapOfRiskLevel;
        }

        public int getFx((int x, int y) node, (int x, int y) end, int[][] map)
        {
            int _x = end.x - node.x;
            int _y = end.y - node.y;
            int Hx = _x + _y;
            int Fx = map[node.y][node.x] + Hx;
            return Fx;
        }
        public long Run((int x, int y) start, (int x, int y) end)
        {

            List<(int x, int y)> OpenList = new List<(int x, int y)>();
            HashSet<(int x, int y)> CloseSet = new HashSet<(int x, int y)>();
            SortedList<int, Stack<(int x, int y)>> OpenListSorted = new SortedList<int, Stack<(int x, int y)>>();
            int[][] map = new int[mapOfRiskLevel.Length][];
            for (int i = 0; i < mapOfRiskLevel.Length; i++)
            {
                map[i] = new int[mapOfRiskLevel[i].Length];
            }

            OpenList.Add(start);
            var stack = new Stack<(int x, int y)>();
            stack.Push(start);
            OpenListSorted.Add(getFx(start, end, map), stack);

            while (OpenList.Count > 0)
            {
                (int x, int y) curr = (-1, -1);
                int min = int.MaxValue;
                foreach (var item in OpenList)
                {
                    int Fx = getFx(item, end, map);
                    if (min > Fx)
                    {
                        min = Fx;
                        curr = item;
                    }
                }

                if (curr == end)
                {
                    int f = map[curr.y][curr.x];

                    return f;
                }

                OpenList.Remove(curr);
                CloseSet.Add(curr);

                foreach (var neighbor in getNeighbors(curr))
                {
                    if (!OpenList.Contains(neighbor) && !CloseSet.Contains(neighbor))
                    {
                        OpenList.Add(neighbor);
                    }

                    int f = map[curr.y][curr.x] + mapOfRiskLevel[neighbor.y][neighbor.x];
                    int oldF = map[neighbor.y][neighbor.x];
                    if (oldF == 0 || oldF > f)
                    {
                        map[neighbor.y][neighbor.x] = f;

                        if (!OpenList.Contains(neighbor))
                        {
                            OpenList.Add(neighbor);
                        }
                    }
                }
            }

            return -1;
        }

        private List<(int x, int y)> getNeighbors((int x, int y) Start)
        {
            List<(int x, int y)> neighbors = new List<(int x, int y)>();

            if (Start.x > 0)
            {
                neighbors.Add((Start.x - 1, Start.y));
            }
            if (Start.y > 0)
            {
                neighbors.Add((Start.x, Start.y - 1));
            }

            if (Start.x < mapOfRiskLevel[Start.y].Length - 1)
            {
                neighbors.Add((Start.x + 1, Start.y));
            }
            if (Start.y < mapOfRiskLevel.Length - 1)
            {
                neighbors.Add((Start.x, Start.y + 1));
            }

            return neighbors;
        }

    }
}
