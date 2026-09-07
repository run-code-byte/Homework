using System;
using System.Collections.Generic;
using System.Text;

namespace day12
{
    public class Person
    {
        public string Name { get; set; }
        protected int Age {  get; set; }
        private double Salary { get; set; }
        internal bool IsMan {  get; set; }
        static bool IsLive { get; set; }
        static public void GetInfoStatic(Person p)
        {
            IsLive = true;
            Console.WriteLine(IsLive);
            //Console.WriteLine(IsMan);
            Console.WriteLine(p.IsMan);
        }

        public void GetInfo(bool IsLive)
        {
            Console.WriteLine(IsLive);
            Console.WriteLine($"名字：{Name}--年龄：{Age}--薪水：{Salary}--男人：{IsMan}");
            Console.WriteLine(Person.IsLive);
        }
    }
}
