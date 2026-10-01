using DobotClientDemo.CPlusDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // 测试机械臂连接
            //开辟一块可以存 128 个字符的内存空间，DLL会把设备类型写进来
            StringBuilder fwType = new StringBuilder(128);
            //开辟一块可以存 128 个字符的内存空间，DLL会把设备版本写进来
            StringBuilder version = new StringBuilder(128);
            // 调用DLL中的函数，连接机械臂
            int ret = DobotDll.ConnectDobot("COM4", 115200, fwType, version);
            // 输出连接结果
            MessageBox.Show($"ConnectDobot 返回码:{ret}\n固件:{fwType}\n版本:{version}");
        }
        //连接
        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder fwType = new StringBuilder(128);
            StringBuilder version = new StringBuilder(128);
            int ret = DobotDll.ConnectDobot("COM4", 115200, fwType, version);
            if (ret == 0)
            {
                MessageBox.Show($"连接成功！\n固件:{fwType}\n版本:{version}");
            }
            else
            {
                MessageBox.Show($"连接失败，返回码:{ret}");
            }
        }
        //断开
        private void button2_Click(object sender, EventArgs e)
        {
            DobotDll.DisconnectDobot();
            MessageBox.Show("串口已断开");
        }
        //回零
        private void button3_Click(object sender, EventArgs e)
        {
            // 创建指令对象
            HOMECmd homeCmd = new HOMECmd();
            // 设置指令队列编号
            UInt64 cmdIndex = 0;
            // 调用回零函数
            int ret = DobotDll.SetHOMECmd(ref homeCmd, true, ref cmdIndex);
            if (ret == 0)
            {
                MessageBox.Show("回零指令下发成功，请观察机械臂运动");
            }
            else
            {
                MessageBox.Show($"回零调用失败，返回码:{ret}");
            }
        }
        //消除警报
        private void button4_Click(object sender, EventArgs e)
        {
            int ret = DobotDll.ClearAllAlarmsState();
            if (ret == 0)
            {
                MessageBox.Show("清除所有报警成功，观察指示灯变回绿色");
            }
            else
            {
                MessageBox.Show($"清除报警失败，返回码:{ret}");
            }
        }
        //启动队列
        private void button5_Click(object sender, EventArgs e)
        {
            int ret = DobotDll.SetQueuedCmdStartExec();
            if (ret == 0)
            {
                MessageBox.Show("队列开始执行，机械臂自动跑点位");
            }
            else
            {
                MessageBox.Show($"启动队列失败，返回码:{ret}");
            }
        }
        //停止队列
        private void button6_Click(object sender, EventArgs e)
        {
            int ret = DobotDll.SetQueuedCmdStopExec();
            MessageBox.Show($"停止队列引擎 返回值:{ret}");
        }
        //清空队列
        private void button7_Click(object sender, EventArgs e)
        {
            int ret = DobotDll.SetQueuedCmdClear();
            if (ret == 0)
            {
                MessageBox.Show("队列已清空");
            }
            else
            {
                MessageBox.Show($"清空队列失败，返回码:{ret}");
            }
        }
        //定点移动
        private void button8_Click(object sender, EventArgs e)
        {
            PTPCmd ptpCmd = new PTPCmd();
            ptpCmd.ptpMode = 0; // 0：关节运动 MoveJ
            ptpCmd.x = 232.29f;
            ptpCmd.y = 80.86f;
            ptpCmd.z = 3.8f;
            ptpCmd.rHead = 0;
            UInt64 cmdIndex = 1;
            int ret = DobotDll.SetPTPCmd(ref ptpCmd, true, ref cmdIndex);
            if (ret == 0)
            {
                MessageBox.Show("移动指令下发成功");
            }
            else
            {
                MessageBox.Show($"移动失败，返回码:{ret}");
            }
        }
        //获取坐标
        private void button9_Click(object sender, EventArgs e)
        {
            Pose pose = new Pose();
            int ret = DobotDll.GetPose(ref pose);
            if (ret == 0)
            {
                string info = $"X:{pose.x:F2}\nY:{pose.y:F2}\nZ:{pose.z:F2}\nrHead:{pose.rHead:F2}";
                MessageBox.Show("当前机械臂坐标：\n" + info);
            }
            else
            {
                MessageBox.Show($"读取坐标失败，返回码:{ret}");
            }
        }
        //吸取吸盘
        private void button10_Click(object sender, EventArgs e)
        {
            UInt64 cmdIndex = 0;
            // 第二个参数true表示开启，false表示关闭
            int ret = DobotDll.SetEndEffectorSuctionCup(true, true, false, ref cmdIndex);
            if (ret == 0)
            {
                MessageBox.Show("吸盘吸气开启");
            }
            else
            {
                MessageBox.Show($"吸盘控制失败，返回码:{ret}");
            }
        }
        //释放吸盘
        private void button11_Click(object sender, EventArgs e)
        {
            UInt64 cmdIndex = 0;
            // 第二个参数true表示开启，false表示关闭
            int ret = DobotDll.SetEndEffectorSuctionCup(true, false, false, ref cmdIndex);
            if (ret == 0)
            {
                MessageBox.Show("吸盘吸气关闭");
            }
            else
            {
                MessageBox.Show($"吸盘控制失败，返回码:{ret}");
            }
        }
        //添加队列移动
        private void button12_Click(object sender, EventArgs e)
        {
            // ========== 定义点位 ==========
            // A点：取料位置
            PTPCmd ptpA = new PTPCmd();
            ptpA.ptpMode = 1;
            ptpA.x = 223.1f;
            ptpA.y = -169.1f;
            ptpA.z = 7f;
            ptpA.rHead = 0f;
            UInt64 cmdIndex0 = 0;

            // B点：取料后上升抬高
            PTPCmd ptpB = new PTPCmd();
            ptpB.ptpMode = 1;
            ptpB.x = 223.1f;
            ptpB.y = -169.1f;
            ptpB.z = -54.8f;
            ptpB.rHead = 0f;
            UInt64 cmdIndex1 = 1;
            // C点：平移到放料上方
            PTPCmd ptpC = new PTPCmd();
            ptpC.ptpMode = 1;
            ptpC.x = 223.1f;
            ptpC.y = -169.1f;
            ptpC.z = 37f;
            ptpC.rHead = 0f;
            UInt64 cmdIndex3 = 3;
            // D点：下降到放料位置
            PTPCmd ptpD = new PTPCmd();
            ptpD.ptpMode = 1;
            ptpD.x = 226;
            ptpD.y = -5.8f;
            ptpD.z = 31f;
            ptpD.rHead = 0f;
            UInt64 cmdIndex4 = 4;

            // F点：下降到放料位置
            PTPCmd ptpF = new PTPCmd();
            ptpD.ptpMode = 1;
            ptpD.x = 278.8f;
            ptpD.y = 87.3f;
            ptpD.z = -38.6f;
            ptpD.rHead = 0f;
            UInt64 cmdIndex5 = 5;

            // G点：下降到放料位置
            PTPCmd ptpG = new PTPCmd();
            ptpD.ptpMode = 1;
            ptpD.x = 226;
            ptpD.y = -5.8f;
            ptpD.z = 31f;
            ptpD.rHead = 0f;
            UInt64 cmdIndex7 = 7;
            int ret;

            ret = DobotDll.SetPTPCmd(ref ptpA, true, ref cmdIndex0);
            ret = DobotDll.SetPTPCmd(ref ptpB, true, ref cmdIndex1);
            UInt64 cmdIndex2 = 2;
            ret = DobotDll.SetEndEffectorSuctionCup(true, true, true, ref cmdIndex2);
            ret = DobotDll.SetPTPCmd(ref ptpC, true, ref cmdIndex3);
            ret = DobotDll.SetPTPCmd(ref ptpD, true, ref cmdIndex4);
            ret = DobotDll.SetPTPCmd(ref ptpD, true, ref cmdIndex5);

            UInt64 cmdIndex6 = 6;
            ret = DobotDll.SetEndEffectorSuctionCup(false, false, true, ref cmdIndex2);
            ret = DobotDll.SetPTPCmd(ref ptpG, true, ref cmdIndex7);
        }
    }
}
