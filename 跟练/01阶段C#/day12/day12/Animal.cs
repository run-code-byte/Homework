using System;
using System.Collections.Generic;
using System.Text;

namespace day12
{
    public class Animal
    {
        public string Name { get; set; }
        public string Description { get; }
        public void Run()
        {
            Console.WriteLine($"名字:{Name}，跑起来，描述：{Description}");
        }
    }
}
