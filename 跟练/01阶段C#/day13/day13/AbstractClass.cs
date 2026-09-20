using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day13
{
    internal abstract class AbstractClass
    {
        public string Name { get; set; }
        public abstract bool IsMan {  get; set; }
        public abstract void Hi(int n, string s);
        public void Say()
        {
            Console.WriteLine("Hello");
        }
    }

    internal class Son : AbstractClass
    {
        public override bool IsMan { get; set; }
        public override void Hi(int n, string s)
        {
            Console.WriteLine("hi");
        }
    }

    internal abstract class AbstractSon : AbstractClass
    {
         
    }
}
