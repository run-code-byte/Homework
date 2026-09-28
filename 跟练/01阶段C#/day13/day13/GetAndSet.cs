using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day13
{
    internal class GetAndSet
    {
        public int X { get; private set; }

        public void setX(int x)
        {
            X = x;
        }
        private int _N;
        public int N
        {
            get
            {
                //Console.WriteLine("你访问了N属性");
                return _N*100;
            }
            set
            {
                //Console.WriteLine("你设置了N属性");

                //Console.WriteLine(value);
                if(value<100) Console.WriteLine("N的值不能小于100");
                else _N = value;
            }
        }
    }
}
