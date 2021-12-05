using System;
using System.Collections.Generic;

namespace Year2021.Days.ModelsDay5
{
    public class Line
    {
        public (int x1, int y1) Start;
        public (int x2, int y2) End;

        public Line((int x1, int y1) Start, (int x2, int y2) End)
        {
            this.Start = Start;
            this.End = End;
        }


        public List<(int x, int y)> GetPointsPartOne()
        {
            var Points = new List<(int x, int y)>();



            if (Start.x1 == End.x2)
            {
                int x = Start.x1;
                int max = Math.Max(Start.y1, End.y2);
                int min = Math.Min(Start.y1, End.y2);

                for (int y = min; y <= max; y++)
                {
                    Points.Add((x, y));
                }
                return Points;
            }

            if (Start.y1 == End.y2)
            {
                int y = Start.y1;
                int max = Math.Max(Start.x1, End.x2);
                int min = Math.Min(Start.x1, End.x2);

                for (int x = min; x <= max; x++)
                {
                    Points.Add((x, y));
                }
                return Points;
            }

            return Points;
        }

        public List<(int x, int y)> GetPointsPartTwo()
        {
            var Points = GetPointsPartOne();


            // add diagonal 
            if (Start.x1 != End.x2 && Start.y1 != End.y2)
            {
                Points.AddRange(AddDiagonal());
            }

            return Points;
        }

        private List<(int x, int y)> AddDiagonal()
        {
            if (Start.x1 < End.x2)
            {
                return AddDiagonal(Start, End);
            }

            return AddDiagonal(End, Start);

        }


        private List<(int x, int y)> AddDiagonal((int x, int y) start, (int x, int y) end)
        {
            var Points = new List<(int x, int y)>();

            if (start.y > end.y)
            {
                // goning from top left to bottem Rigth

                for (int i = 0; i <= end.x - start.x; i++)
                {
                    Points.Add((start.x + i, start.y - i));
                }
            }
            else
            {
                // goning from bottem left to top Rigth
                for (int i = 0; i <= end.x - start.x; i++)
                {
                    Points.Add((start.x + i, start.y + i));
                }
            }

            return Points;
        }
    }
}
