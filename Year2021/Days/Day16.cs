using Core;
using System.Text;
using System.Threading.Tasks;
using Year2021.Days.ModelsDay16;

namespace Year2021.Days
{
    public class Day16 : IDay
    {
        public int dayNumber => 16;

        public int year => 2021;

        public IResult FirstTestValue => new ResultLong(20);
        public IResult SecondTestValue => new ResultLong(1);

        public string[] TestInput => new string[] { "9C0141080250320F1802104A08" };

        public object Parser(string[] arg)
        {
            return arg;
        }

        public IResult PartOne<T>(T Data)
        {
            string[] lines = Data as string[];

            int total = 0;

            foreach (var line in lines)
            {
                var c = new Packet(line);
                total += c.GetTotalVersionNumber();
            }

            return new ResultLong(total);
        }


        public IResult PartTwo<T>(T Data)
        {
            string[] lines = Data as string[];

            long total = 0;

            foreach (var line in lines)
            {
                var c = new Packet(line);
                total += c.GetValue();
            }

            return new ResultLong(total);
        }
    }
}