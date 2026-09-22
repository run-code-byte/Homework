using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day13
{
    internal class ThisClass1
    {
        static void Fn()
        {
            //Console.WriteLine(this);
        }

        public ThisClass1 GetThis()
        {
            return this;
        }

        public int N { get; set; }

        public void SetN(int N){
            //N = N;
            this.N = N;

        }
        public void CallFn()
        {
            Console.WriteLine("要调用ABC的Fn方法");
            ABC.Fn(this);
        }
    }

    internal class ABC { 
        static public void Fn(ThisClass1 o)
        {
            Console.WriteLine(o.N);
        }
    }
}
