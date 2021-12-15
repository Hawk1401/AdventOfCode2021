using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IResult
    {
        public void print();
        public bool HasSameValue(IResult other);
    }
}
