using System;
using System.Collections.Generic;
using System.Text;

namespace day12
{
    internal class MotionController : Device
    {

        public void MoveAxis()
        {
            Console.WriteLine($"{DeviceName}控制轴运动");
        }
    }
}
