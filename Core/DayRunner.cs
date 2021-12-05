using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class DayRunner
    {
        public static string session = ""; 
        public static void Run(IDay day)
        {
            var input = GetInputAsync(day);
            day.Run(input);
        }

        private static Dictionary<(int day, int year), string[]> Cache = new Dictionary<(int day, int year), string[]>();

        public static string[] GetInputAsync(IDay day)
        {
            return GetInputAsync(day.dayNumber, day.year).Result;
        }
        public static async Task<string[]> GetInputAsync(int day, int year)
        {
            if(Cache.ContainsKey((day, year)))
            {
                return Cache[(day, year)];
            }

            if (string.IsNullOrWhiteSpace(session))
            {
                session = Environment.GetEnvironmentVariable("SessionAdventofcode", EnvironmentVariableTarget.User);

                if (string.IsNullOrWhiteSpace(session))
                {
                    throw new Exception("No session was found");
                }
            }


            var httpClient = new HttpClient();

            var url = $"https://adventofcode.com/{year}/day/{day}/input";

            httpClient.DefaultRequestHeaders.Add("Cookie", $"session={session}");

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var s = (await response.Content.ReadAsStringAsync()).Split("\n").ToList();
                s.RemoveAt(s.Count - 1);
                var arr = s.ToArray();
                Cache.Add((day, year), arr);
                return arr;
            }

            throw new Exception("something went wrong");
        }
    }
}
