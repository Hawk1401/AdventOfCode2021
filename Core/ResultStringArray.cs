using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ResultStringArray : IResult
    {
        public string[] ResultData;
        public ResultStringArray(string[] arr)
        {
            ResultData = arr;
        }
        public bool HasSameValue(IResult other)
        {
            if(other is ResultStringArray ResultArr)
            {
                if(ResultArr.ResultData.Length == ResultData.Length)
                {
                    for (int i = 0; i < ResultData.Length ; i++)
                    {
                        if(ResultData[i] != ResultArr.ResultData[i])
                        {
                            return false;
                        }
                    }

                    return true;
                }
            }
            return false;

        }

        public void print()
        {
            Console.WriteLine();

            foreach (var line in ResultData)
            {
                Console.WriteLine(line);
            }
        }
    }
}
