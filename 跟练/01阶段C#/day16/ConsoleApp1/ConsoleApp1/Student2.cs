using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    partial class Student
    {
        public string Name { get; set; }
        public void ShowName()
        {
            Console.WriteLine($"姓名：{Name}");
        }
    }
}
