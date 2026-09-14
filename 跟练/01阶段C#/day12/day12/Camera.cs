using System;
using System.Collections.Generic;
using System.Text;

namespace day12
{
    internal class Camera : Device
    {

        public void CaptureImage()
        {
            Console.WriteLine($"{DeviceName}拍照功能");
        }

    }
}
