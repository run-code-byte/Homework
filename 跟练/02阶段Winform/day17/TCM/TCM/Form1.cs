using Modbus.Device;
using System.ComponentModel;
using System.IO.Ports;
using TCM.models;
using TCM.mysql;

namespace TCM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Shown += TCMInit;
        }



        // 定义数据
        private BindingList<DeviceTempRecord> DTRs; // 表格数据
        private SerialPort MyPort; // 串口对象
        private IModbusSerialMaster Master; // 主站串口
        private System.Windows.Forms.Timer TempTimer;// 温度定时器(用于模拟温度变化)
        private System.Windows.Forms.Timer DataTimer; // 数据记录定时器(用于定时记录数据)
        private bool isHeating = true;     //温度变化模拟 true=升温, false=降温
        private int RecordeDataBase = 0; // 主页数据每隔500ms记录  每隔3000ms数据库记录,可以使用计数器,6次则写入数据库

        private void TCMInit(object sender, EventArgs e)
        {
            closePLCBtn.Enabled = false;
            startBtn.Enabled = false;
            stopBtn.Enabled = false;
            inpTempTb.Enabled = false;
            setTempBtn.Enabled = false;

            SetDataColumns();
            TempTimer = new System.Windows.Forms.Timer();
            TempTimer.Interval = 400;
            TempTimer.Tick += TempMoni;

            DataTimer = new System.Windows.Forms.Timer();
            DataTimer.Interval = 500;
            DataTimer.Tick += DataRecorde;

            tempPanel.Paint += TempPaint;

            // 按钮绑定事件
            connPLCBtn.Click += ConnectPLC;
            setTempBtn.Click += SetTemp;
            startBtn.Click += StartDevice;
            stopBtn.Click += StopDevice;
            closePLCBtn.Click += ClosePLC;

            goHistoryDataBtn.Click += GoHData;
        }

        private void GoHData(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void TempMoni(object sender, EventArgs e)
        {
            ushort[] Temps = Master.ReadHoldingRegisters(1, 1, 2);
            ushort CurrTemp = Temps[1];

            if (isHeating)
            {
                CurrTemp++;
                if (CurrTemp >=300)
                {
                    CurrTemp = 300;
                    isHeating = false;
                }
            }
            else
            {
                CurrTemp--;
                if (CurrTemp <= 30)
                {
                    CurrTemp = 30;
                    isHeating = true;
                }
            }

            if (Temps[0] == Temps[1])
            {
                string msg = isHeating ? $"【警告】发生超温故障，实际温度={Temps[1]}，目标温度={Temps[0]}":"超温故障已消除";
                WriteLog(msg);
                Master.WriteSingleRegister(1, 0, isHeating ? (ushort)2 : (ushort)1);
                Master.WriteSingleRegister(1, 3, isHeating ? (ushort)1 : (ushort)0);
            }
            currentTempLab.Text = CurrTemp + "°C";
            Master.WriteSingleRegister(1, 2, CurrTemp);
            tempPanel.Invalidate();
        }

        private async void DataRecorde(object sender, EventArgs e)
        {
            ushort[] ResArr = await Master.ReadHoldingRegistersAsync(1, 0, 4);
            DeviceTempRecord DTR = new DeviceTempRecord(ResArr);
            DTRs.Add(DTR);
            RecordeDataBase++;
            if (RecordeDataBase == 6)
            {
                bool isInsert =await MysqlHandler.InserOne(ResArr);
                if (isInsert)
                {
                Console.WriteLine($"采集时间：{DTR.CollectTime} 设备状态：{DTR.DeviceStatus} 设定温度：{DTR.SetTemp} 实际温度：{DTR.RealTemp} 故障码：{DTR.FaultCode}");
                RecordeDataBase = 0;// 计数器重置为0

                }

            }
        }

       

        private async void ClosePLC(object sender, EventArgs e)
        {
            TempTimer.Stop();
            DataTimer.Stop();
            MyPort.Close();
            MyPort = null;
            Master = null;
            closePLCBtn.Enabled = false;
            startBtn.Enabled = false;
            stopBtn.Enabled = false;
            inpTempTb.Enabled = false;
            setTempBtn.Enabled = false;
            connPLCBtn.Enabled = true;
            plcStatusLabel.Text = "当前状态：未连接";
            plcStatusLabel.ForeColor = Color.Black;
            WriteLog("断开设备，停止采集");
            Console.WriteLine("---断开（关闭）PLC---");
        }
        private async void StopDevice(object sender, EventArgs e)
        {
            TempTimer.Stop();
            stopBtn.Enabled = false;
            startBtn.Enabled = true;
            inpTempTb.Enabled = true;
            setTempBtn.Enabled= true;
            await Master.WriteSingleRegisterAsync(1, 0, 0);
            WriteLog("设备置待机状态");
            Console.WriteLine("---设备停止---");

        }

        private async void StartDevice(object sender, EventArgs e)
        {
            TempTimer.Start();
            DataTimer.Start();
            await Master.WriteSingleRegisterAsync(1, 0, 1);
            startBtn.Enabled = false;
            stopBtn.Enabled = true;
            WriteLog("设备置运行状态");
            Console.WriteLine("===设备启动===");
        }

        private async void SetTemp(object sender, EventArgs e)
        {
            if(!int.TryParse(inpTempTb.Text,out int temp)||temp<0||temp>600)
            {
                MessageBox.Show("输入设定的温度有误！！！");
                return;
            }
            await Master.WriteSingleRegisterAsync(1, 1, (ushort)temp);
            inpTempTb.Enabled = false;
            setTempBtn.Enabled = false;
            startBtn.Enabled = true;
            setTempLab.Text = $"{temp}°C";
            WriteLog($"设置目标温度={temp}°C");

        }
        private async void ConnectPLC(object sender, EventArgs e)
        {
            if (Master != null) return;
            try
            {
                MyPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
                MyPort.Open();
                Master = ModbusSerialMaster.CreateRtu(MyPort);
                Master.Transport.ReadTimeout = 2000;
                Master.Transport.Retries = 3;

                await Master.WriteSingleRegisterAsync(1, 0, 0);
                await Master.WriteSingleRegisterAsync(1, 2, 30);
                await Master.WriteSingleRegisterAsync(1, 3, 0);
                plcStatusLabel.Text = "当前状态：已连接";
                plcStatusLabel.ForeColor= Color.Green;
                Console.WriteLine("====连接设备（PLC）成功====");
            }
            catch (Exception err)
            {
                MessageBox.Show($"设备连接失败，异常：{err.Message}");
                return;
            }
            

            connPLCBtn.Enabled = false;
            closePLCBtn.Enabled = true;
            inpTempTb.Enabled= true;
            setTempBtn.Enabled = true;

            WriteLog("连接设备成功，开始采集");

        }

        private void WriteLog(string msg)
        {
            Label lab= new Label();
            lab.Text = DateTime.Now.ToString() + " " + msg;
            lab.AutoSize = true;
            lab.ForeColor = msg.Contains("警告") ? Color.Red : Color.Black;
            flowLayoutPanel1.Controls.Add(lab);

        }


        private void TempPaint(object sender, PaintEventArgs e)
        {
            // 获取画图对象
            Graphics g = e.Graphics;
            //设置抗锯齿
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (var pen = new Pen(Color.Green, 2))
            {
                //圆弧矩形起点
                float sx = 0;
                float sy = 0;
                float r = 140;//半径
                float locationX = sx + r;
                float locationY = sy + r;
                //画个弧
                g.DrawArc(pen, sx, sy, (float)r * 2, (float)r * 2, 180, 180);
                // 温度0~600° ===>  分为120次  温度5度一个刻度
                for (int i = 0; i <= 120; i++)
                {
                    var lineLen = 5;
                    if (i % 10 == 0) lineLen = 10;
                    //开始结束坐标  1.5====>180度/120份,每个刻度是角度1.5
                    double startX = locationX - r * Math.Cos(1.5 * i * Math.PI / 180);
                    double startY = locationY - r * Math.Sin(1.5 * i * Math.PI / 180);
                    //结束坐标
                    double endX = locationX - (r - lineLen) * Math.Cos(1.5 * i * Math.PI / 180);
                    double endY = locationY - (r - lineLen) * Math.Sin(1.5 * i * Math.PI / 180);
                    //画刻度线, 使用笔枚举
                    g.DrawLine(Pens.Black, (int)startX, (int)startY, (int)endX, (int)endY);
                    if (i % 10 == 0) // 文字
                    {
                        using (Brush brushText = new SolidBrush(Color.Black))
                        using (StringFormat sf = new StringFormat())
                        using (Font font = new Font("宋体", 8))
                        {
                            sf.Alignment = StringAlignment.Center;
                            sf.LineAlignment = StringAlignment.Center;
                            //刻度标
                            double fontX = locationX - (r - lineLen - 10) * Math.Cos(-1.5 * i * Math.PI / 180);
                            double fontY = locationY + (r - lineLen - 10) * Math.Sin(-1.5 * i * Math.PI / 180);
                            g.DrawString((5 * i).ToString(), font, brushText, (float)fontX, (float)fontY, sf);
                        }
                    }

                }
                //定义变量去modbus寄存器地址2中获取实时温度  用来给指针转动的值 
                ushort realTemp = 0;
                if (Master != null)
                {
                    ushort[] realTempushort = Master.ReadHoldingRegisters(1, 2, 1);
                    realTemp = realTempushort[0];
                }

                // 角度 180°/120 ===> 1.5 
                // 温度 600 / 120   ===> 5
                // 所以温度一度 就是 角度 0.3度
                double pointX = locationX - (r - 10) * Math.Cos(realTemp * 0.3 * Math.PI / 180);
                double pointY = locationY - (r - 10) * Math.Sin(realTemp * 0.3 * Math.PI / 180);

                using (Pen penline = new Pen(Color.Green, 2))
                {
                    g.DrawLine(penline, (int)pointX, (int)pointY, (int)locationX, (int)locationY);
                }

            }
        }

     

        private void SetDataColumns()
        {
            DTRs = new();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = DTRs;
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "CollectTime",
                Name = "CollectTime",
                HeaderText = "采集时间",
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "yyyy-MM-dd hh:mm:ss",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "DeviceStatus",
                Name = "DeviceStatus",
                HeaderText = "设备状态",
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "SetTemp",
                Name = "SetTemp",
                HeaderText = "设定温度",
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "RealTemp",
                Name = "RealTemp",
                HeaderText = "实际温度",
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "FaultCode",
                Name = "FaultCode",
                HeaderText = "故障码",
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

     
    }

    public class DoubleBufferPanel : Panel
    {
        public DoubleBufferPanel()
        {
            //开启双缓冲，消除闪烁
            this.SetStyle(ControlStyles.UserPaint
            | ControlStyles.AllPaintingInWmPaint
            | ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
        }
    }
}
