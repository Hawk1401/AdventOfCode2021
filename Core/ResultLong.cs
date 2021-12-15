using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ResultLong : IResult
    {
        public long resultData;

        public ResultLong(long resultData)
        {
            this.resultData = resultData;
        }

        public bool HasSameValue(IResult other)
        {
            if(other is ResultLong otherAsLong)
            {
                return resultData == otherAsLong.resultData;
            }

            return false;
        }

        public void print()
        {
            Console.WriteLine(resultData);
        }
    }
}
