using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day13
{
    //internal sealed class SealedClass
    //{

    //}

    //internal class Sql : SealedClass
    //{

    //}

    internal class Father
    {
        public virtual void Say()
        {
            Console.WriteLine("Hello");
        }
    }

    internal class Son2 : Father
    {
        public sealed override void Say()
        {
            Console.WriteLine("World");
        }
    }

    internal class Son3:Son2
    {
        //public sealed override void Say()
        //{
        //    Console.WriteLine("World");
        //}

    }
}
