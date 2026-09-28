using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    partial class Student
    {
        public int Id { get; set; }
        public void ShowId()
        {
            Console.WriteLine($"学号：{Id}");
        }
    }
}
