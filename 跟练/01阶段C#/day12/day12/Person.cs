using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace day12
{
    public class Person
    {
        public string Name { get; set; }
        public int Id { get;  }
        protected int Age {  get;}
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
            Console.WriteLine($"名字：{Name}--年龄：{Age}--薪水：{Salary}--男人：{IsMan}--活着：{Person.IsLive}");
            //Console.WriteLine(IsLive);
            //Console.WriteLine(Person.IsLive);
        }

        public Person(string name, int age, double salary, bool isman,bool islive)
        {
            Console.WriteLine("实例构造函数---");

            Name = name;
            Age = age;
            Salary = salary;
            IsMan = isman;
            Person.IsLive = islive;
        }

        static Person()
        {
            Console.WriteLine("静态构造函数---");
            //Name = "csss";
            IsLive = false;

        }

        public void Say()
        {
            Console.WriteLine("吧啦吧啦吧啦吧啦....小魔仙");
        }
        public void Say(string content)
        {
            Console.WriteLine("吧嗒吧嗒吧嗒吧嗒....{content}");
        }

        public void Say(string start ,string end)
        {
            Console.WriteLine($"{start}***************....{end}");
        }
      

    }
}
