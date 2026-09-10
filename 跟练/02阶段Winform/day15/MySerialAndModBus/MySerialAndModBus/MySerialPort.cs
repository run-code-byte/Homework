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
    public partial class MySerialPort : Form
    {
        public MySerialPort()
        {
            InitializeComponent();
            new MySerialPort2().Show();
            this.Shown += MySerialPortInit;
        }

        private void MySerialPortInit(object sender, EventArgs e)
        {
            //SerialPort MyPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
            //MyPort.Open();
            //Stream St = MyPort.BaseStream;
            //byte[] Buffer = new byte[1024];
            //while (true)
            //{
            //    int Len = St.Read(Buffer, 0, Buffer.Length);
            //    string ReviceStr=Encoding.UTF8.GetString(Buffer);
            //    MessageBox.Show(ReviceStr);
            //}

            //string str = "666";
            //St.Write(Encoding.UTF8.GetBytes(str));
            myPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
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
                lab.Text= ReviceStr;
                lab.Size = new Size(300, 30);
                lab.Location = new Point(0, 30 * Num);
                panel1.Controls.Add(lab);
                Num++;
            }
        }
    }
}
