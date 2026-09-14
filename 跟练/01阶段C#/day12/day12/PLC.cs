using System;
using System.Collections.Generic;
using System.Text;

namespace day12
{
    internal class PLC:Device
    //public class PLC: Device
    {
        public void ReadRegister()
        {
            Console.WriteLine($"{DeviceName}读取PLC寄存器");
            GetInfo();
        }
        public override void Start()
        {
            Console.WriteLine($"{DeviceName}先检查信号，然后设备启动----->");
        }

    }
}
