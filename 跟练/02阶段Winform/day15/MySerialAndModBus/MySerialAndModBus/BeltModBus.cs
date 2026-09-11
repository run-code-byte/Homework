using Modbus.Device;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySerialAndModBus
{
    public partial class BeltModBus : Form
    {
        public BeltModBus()
        {
            InitializeComponent();
        }
        private SerialPort MyPort;
        private IModbusSerialMaster Master;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MyPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
                MyPort.Open();
                Master = ModbusSerialMaster.CreateRtu(MyPort);
                Master.Transport.ReadTimeout = 2000; // 读超时
                Master.Transport.Retries = 3; // 重试次数
            }
            catch (Exception ex)
            {
                MessageBox.Show($"连接失败:{ex.Message}");
                return;
            }

            MessageBox.Show("连接成功");

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                await Master.WriteSingleRegisterAsync(2, 100, 1);

            }
            catch (Exception err)
            {
                MessageBox.Show($"启动失败:{err.Message}");

            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            try
            {
                await Master.WriteSingleRegisterAsync(2, 100, 0);

            }
            catch (Exception err)
            {
                MessageBox.Show($"停止失败:{err.Message}");

            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                await Master.WriteSingleRegisterAsync(2, 101, 1);

            }
            catch (Exception err)
            {
                MessageBox.Show($"改正转失败:{err.Message}");

            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            try
            {
                await Master.WriteSingleRegisterAsync(2, 101, 0);

            }
            catch (Exception err)
            {
                MessageBox.Show($"改反转失败:{err.Message}");

            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            bool isSpeed = int.TryParse(textBox1.Text, out int speed);
            if(!isSpeed||speed<0||speed>10000)
            {
                MessageBox.Show("输入转速有误！！！");
                return;
            }
            try
            {
                await Master.WriteSingleRegisterAsync(2, 102, (ushort)speed);

            }
            catch (Exception err)
            {
                MessageBox.Show($"改转速失败:{err.Message}");

            }
        }
    }
}
