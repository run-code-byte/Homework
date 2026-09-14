using System;
using System.Collections.Generic;
using System.Text;

namespace day12
{
    internal class Device
    {
        public string DeviceName { get; set; }
        public bool IsConnected { get; set; }
        public void Connect()
        {
            Console.WriteLine($"{DeviceName}连接设备");
        }
        public void Disconnect()
        {
            Console.WriteLine($"{DeviceName}断开设备");
        }
        
        public virtual void Start()
        {
            Console.WriteLine($"{DeviceName}设备启动----->");
        }
        protected void GetInfo()
        {
            Console.WriteLine("父类的GetInfo方法");
        }
    }
}
