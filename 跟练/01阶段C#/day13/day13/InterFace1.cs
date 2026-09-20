using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day13
{
    interface InterFace1
    {
        string Name { get; set; }
        void SayHi(int n);
        void SayHello()
        {
            Console.WriteLine($"{Name}说Hello啊");
        }
       
    }

    public class A : InterFace1
    {
        public string Name { get; set; }
        public void SayHi(int n)
        {
            Console.WriteLine($"{Name}说Hi啊{n}");
        }
    }
}
