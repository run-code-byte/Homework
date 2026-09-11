using Modbus.Device;
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
    public partial class ModBus : Form
    {
        public ModBus()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SerialPort MyPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
            MyPort.Open();
            ModbusSerialMaster Master = ModbusSerialMaster.CreateRtu(MyPort);
            //bool[] resArr = Master.ReadCoils(1, 2, 1);
            //bool[] resArr = Master.ReadCoils(1, 0, 5);
            //MessageBox.Show(string.Join(",", resArr));

            //Master.WriteSingleCoil(1, 1, true);
            //Master.WriteMultipleCoils(1, 0, new bool[] {true,false,true,false,true});

            //bool[] resArr = Master.ReadInputs(1, 0,4);
            //MessageBox.Show(string.Join(",", resArr));

            //ushort i = 65535;
            //ushort[] resArr = Master.ReadHoldingRegisters(1, 0, 4);
            //MessageBox.Show(string.Join(",", resArr));

            //Master.WriteSingleRegister(1, 4, 12345);
            //Master.WriteMultipleRegisters(1, 0, new ushort[] {12,14,5,62,77});

            ushort[] resArr= Master.ReadInputRegisters(1, 0, 4);
            MessageBox.Show(string.Join(",", resArr));



        }
    }
}
