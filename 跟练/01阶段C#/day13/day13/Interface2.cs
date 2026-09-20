using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day13
{
    internal interface X
    {
        int Sun(int n, int m);
    }
    internal interface Y
    {
        int Sub(int n, int m);
    }

    internal class Z:X,Y
    {
        public int Sun(int n, int m)
        {
            return n + m;
        }

        public int Sub(int n, int m)
        {
            return n-m;
        }

    }
}
