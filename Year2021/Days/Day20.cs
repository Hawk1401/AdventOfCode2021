using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2021.Days
{
    public class Day20 : IDay
    {
        public int dayNumber => 20;

        public int year => 2021;

        public IResult FirstTestValue => new ResultLong(35);

        public IResult? SecondTestValue => new ResultLong(3351);

        public string[] TestInput => new string[] {
        "..#.#..#####.#.#.#.###.##.....###.##.#..###.####..#####..#....#..#..##..###..######.###...####..#..#####..##..#.#####...##.#.#..#.##..#.#......#.###.######.###.####...#.##.##..#..#..#####.....#.#....###..#.##......#.....#..#..#..##..#...##.######.####.####.#.#...#.......#..#.#.#...####.##.#......#..#...##.#.##..#...##.#.##..###.#......#.#.......#.#.#.####.###.##...#.....####.#..#..#.##.#....##..#.####....##...##..#...#......#.#.......#.......##..####..#...#.#.#...##..#.#..###..#####........#..####......#..#",
        "",
        "#..#.",
        "#....",
        "##..#",
        "..#..",
        "..###",

        };

        public object Parser(string[] arg)
        {
            var ImageEnhancementer = new ImageEnhancementer(arg[0]);
            var points = new HashSet<(int x, int y)>();

            int offset = 2;
            for (int x = offset; x < arg.Length; x++)
            {
                for (int y = 0; y < arg[x].Length; y++)
                {
                    if(arg[x][y] == '#')
                    {
                        points.Add((x - offset, y));
                    }
                }
            }

            return new ImageEnhancementerStart(ImageEnhancementer, new Image(points, true));
        }

        public IResult PartOne<T>(T Data)
        {
            var data = Data as ImageEnhancementerStart;
            var image = data.Image;
            for (int i = 0; i < 2; i++)
            {
                image = data.Enhancementer.EnhancementImage(image);
            }

            return new ResultLong(image.getCountOfLitPoints());
        }

        public IResult PartTwo<T>(T Data)
        {
            var data = Data as ImageEnhancementerStart;
            var image = data.Image;
            for (int i = 0; i < 50; i++)
            {
                image = data.Enhancementer.EnhancementImage(image);
            }

            return new ResultLong(image.getCountOfLitPoints());
        }
    }
    public class ImageEnhancementerStart
    {
        public ImageEnhancementer Enhancementer { get; set; }
        public Image Image { get; set; }

        public ImageEnhancementerStart(ImageEnhancementer Enhancementer, Image Image)
        {
            this.Enhancementer = Enhancementer;
            this.Image = Image;
        }
    }

    public class ImageEnhancementer
    {

        private bool[] Map;
        public ImageEnhancementer(string algorithm)
        {
            Map = new bool[512];

            if(Map.Length != algorithm.Length)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < Map.Length; i++)
            {
                Map[i] = algorithm[i] == '#';
            }
        }

        public Image EnhancementImage(Image image)
        {

            var newPoints = new HashSet<(int x, int y)>();
            var Neibors = GetAllNeighbors(image.Points);

            if (Map[511] && Map[0])
            {
                // Problem 
                throw new Exception();
            }

            bool ThePointsAreLit = true;
            if (image.ThePointsAreLit && Map[0])
            {
                ThePointsAreLit = false;

                foreach (var pointToCheck in Neibors)
                {
                    var score = GetScore(pointToCheck, image);

                    if (!Map[score])
                    {
                        newPoints.Add(pointToCheck);
                    }
                }
                return new Image(newPoints, ThePointsAreLit);

            }

            foreach (var pointToCheck in Neibors)
            {
                var score = GetScore(pointToCheck, image);

                if (Map[score])
                {
                    newPoints.Add(pointToCheck);
                }
            }

            return new Image(newPoints, ThePointsAreLit);
        }

        private HashSet<(int x, int y)> GetAllNeighbors(HashSet<(int x, int y)> Image)
        {
            var set = new HashSet<(int x, int y)>();
            foreach (var point in Image)
            {
                foreach (var Neibor in GetNeibors(point))
                {
                    set.Add(Neibor);
                }
            }
            
            return set;
        }

        private IEnumerable<(int x, int y)> GetNeibors((int x, int y) Point)
        {
            yield return (Point.x - 1, Point.y - 1);
            yield return (Point.x-1, Point.y);
            yield return (Point.x - 1, Point.y + 1);
            yield return (Point.x, Point.y - 1);
            yield return (Point.x, Point.y);
            yield return (Point.x, Point.y + 1);
            yield return (Point.x + 1, Point.y - 1);
            yield return (Point.x + 1, Point.y);
            yield return (Point.x + 1, Point.y + 1);


        }

        private int GetScore((int x, int y) Point, Image image)
        {
            int score = 0;

            foreach (var Neibor in GetNeibors(Point))
            {
                score = score << 1;
                if(image.Points.Contains(Neibor) == image.ThePointsAreLit)
                {
                    score++;
                }
            }

            return score;
        }
    }

    public class Image
    {
        public HashSet<(int x, int y)> Points { get; private set; }

        public bool ThePointsAreLit { get; private set; }

        public Image(HashSet<(int x, int y)> image, bool ThePointsAreLit)
        {
            Points = image;
            this.ThePointsAreLit = ThePointsAreLit;
        }

        public long getCountOfLitPoints()
        {
            if (!ThePointsAreLit)
            {
                throw new Exception("infenety points");
            }

            return Points.LongCount();
        }
    }
}
