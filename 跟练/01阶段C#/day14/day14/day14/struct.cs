using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day14
{
    internal class Person<A,B>
    {
        public A x{  get; set; }
        public B y{  get; set; }
        public string info<C, D>(C c,D d)
        {
            return $"=={this.x}=={c}=={d}=={this.y}===";
        }
    }

    public struct A
    {
        public string name {  get; set; }
        public int age { get; set; }
        public A(string n, int a)
        {
            this.name = n;
            this.age = a;
        }
    }
}
