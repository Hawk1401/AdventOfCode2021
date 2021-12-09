using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021.Days
{
    public class Day9 : IDay
    {
        public int dayNumber => 9;

        public int year => 2021;

        public long? FirstTestValue => 15;

        public long? SecondTestValue => 1134;

        public string[] TestInput => new string[]{
        "2199943210",
        "3987894921",
        "9856789892",
        "8767896789",
        "9899965678"
        };

        public object Parser(string[] arg)
        {
            int[][] matrix = new int[arg.Length][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = arg[i].Trim().Select(x => x - '0').ToArray();
            }

            return matrix;
        }

        public long PartOne<T>(T Data)
        {
            int[][] matrix = Data as int[][];

            List<int> smallest = new List<int>();

            for (int x= 0; x < matrix.Length; x++)
            {
                for (int y = 0; y < matrix[x].Length; y++)
                {
                    if (IsSmallestNeighbor(matrix, x,y))
                    {
                        smallest.Add(matrix[x][y]);
                    }
                }
            }

                 return smallest.Sum() + smallest.Count;
        }

        public bool IsSmallestNeighbor(int[][] matrix, int posx, int posy)
        {

            int x = posx - 1;
            
            if(x >= 0){
                if (matrix[x][posy] <= matrix[posx][posy])
                {
                    return false;
                }
            }

            x = posx + 1;
            if (x < matrix.Length)
            {
                if (matrix[x][posy] <= matrix[posx][posy])
                {
                    return false;
                }
            }


            int y = posy - 1;

            if (y >= 0)
            {
                if (matrix[posx][y] <= matrix[posx][posy])
                {
                    return false;
                }
            }

            y = posy + 1;
            if (y < matrix[posx].Length)
            {
                if (matrix[posx][y] <= matrix[posx][posy])
                {
                    return false;
                }
            }

            return true;
        }

        public long PartTwo<T>(T Data)
        {
            HashSet<(int x, int y)> setOfNumbers = new HashSet<(int x, int y)>();
            int[][] matrix = Data as int[][];

            for (int x = 0; x < matrix.Length; x++)
            {
                for (int y = 0; y < matrix[x].Length; y++)
                {
                    if (matrix[x][y] != 9)
                    {
                        setOfNumbers.Add((x, y));

                    }
                }
            }
            List<List<int>> listOfPools = new List<List<int>>();
            while (setOfNumbers.Count > 0)
            {
                listOfPools.Add(AddTOPool(new List<int>(), setOfNumbers, matrix, setOfNumbers.First()));
            }

            listOfPools = listOfPools.OrderBy(x => x.Count).Reverse().ToList();

            return listOfPools[0].Count * listOfPools[1].Count * listOfPools[2].Count;
        }


        public List<int> AddTOPool(List<int> pool, HashSet<(int x, int y)> setOfNumbers, int[][] matrix, (int x, int y) cords)
        {
            if (!setOfNumbers.Contains(cords))
            {
                return pool;
            }

            setOfNumbers.Remove(cords);
            pool.Add(matrix[cords.x][cords.y]);

            foreach (var Neighbor in GetNeighbors(matrix, cords.x, cords.y))
            {
                AddTOPool(pool, setOfNumbers, matrix, Neighbor);
            }

            return pool;
        }

        public List<(int x, int y)> GetNeighbors(int[][] matrix, int posx, int posy)
        {
            var Neighbors = new List<(int x, int y)>();
            for (int x = posx-1; x <= posx+2; x += 2)
            {
                if(x < 0 ||x >= matrix.Length)
                {
                    continue;
                }

                if(matrix[x][posy]  != 9)
                {
                    Neighbors.Add((x,posy));
                }
            }

            for (int y = posy - 1; y <= posy + 2; y += 2)
            {
                if (y < 0 || y >= matrix[posx].Length)
                {
                    continue;
                }

                if (matrix[posx][y] != 9)
                {
                    Neighbors.Add((posx, y));
                }
            }

            return Neighbors;
        }
    }
}
