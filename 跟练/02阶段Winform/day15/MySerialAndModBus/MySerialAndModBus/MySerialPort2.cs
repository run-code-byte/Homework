using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySerialAndModBus
{
    public partial class MySerialPort2 : Form
    {
        public MySerialPort2()
        {
            InitializeComponent();
            this.Shown += MySerialPortInit;
        }
        private void MySerialPortInit(object sender, EventArgs e)
        {
            myPort = new SerialPort("COM2", 9600, Parity.None, 8, StopBits.One);
            button1.Click += OpenSerial;
            button2.Click += SendData;
        }

        private async void SendData(object sender, EventArgs e)
        {
            //MessageBox.Show(myPort.IsOpen.ToString());
            if (!myPort.IsOpen)
            {
                MessageBox.Show("串口未打开");
                return;
            }
            await stream.WriteAsync(Encoding.UTF8.GetBytes(textBox1.Text));
        }

        private Stream stream;
        SerialPort myPort;
        private int Num = 0;

        private void OpenSerial(object? sender, EventArgs e)
        {
            myPort.Open();
            stream = myPort.BaseStream;
            ReadData();
        }

        private async void ReadData()
        {
            byte[] Buffer = new byte[1024];
            while (true)
            {
                Buffer = new byte[1024];
                int Len = await stream.ReadAsync(Buffer, 0, Buffer.Length);
                if (Len == 0)
                {
                    MessageBox.Show("连接断开");
                    break;
                }
                string ReviceStr = Encoding.UTF8.GetString(Buffer);
                Label lab = new Label();
                lab.Text = ReviceStr;
                lab.Size = new Size(300, 30);
                lab.Location = new Point(0, 30 * Num);
                panel1.Controls.Add(lab);
                Num++;
            }
        }
    }
}
