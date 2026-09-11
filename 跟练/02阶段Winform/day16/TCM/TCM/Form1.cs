using Modbus.Device;
using System.ComponentModel;
using System.IO.Ports;
using TCM.models;

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
            TempTimer.Interval= 500;
            TempTimer.Tick += TempMoni;

            DataTimer= new System.Windows.Forms.Timer();
            DataTimer.Interval= 3000;
            DataTimer.Tick += DataRecorde;

            tempPanel.Paint += TempPaint;

            // 按钮绑定事件
            connPLCBtn.Click += ConnectPLC;
            //setTempBtn.Click += SetTemp;
            //startBtn.Click += StartDevice;
            //stopBtn.Click += StopDevice;
            //closePLCBtn.Click += ClosePLC;
        }

        private void ConnectPLC(object sender, EventArgs e)
        {
            
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
                //ushort realTemp = 0;
                //if (Master != null)
                //{
                //    ushort[] realTempushort = Master.ReadHoldingRegisters(1, 2, 1);
                //    realTemp = realTempushort[0];
                //}

                // 角度 180°/120 ===> 1.5 
                // 温度 600 / 120   ===> 5
                // 所以温度一度 就是 角度 0.3度
                double pointX = locationX - (r - 10) * Math.Cos(50 * 0.3 * Math.PI / 180);
                double pointY = locationY - (r - 10) * Math.Sin(50 * 0.3 * Math.PI / 180);

                using (Pen penline = new Pen(Color.Green, 2))
                {
                    g.DrawLine(penline, (int)pointX, (int)pointY, (int)locationX, (int)locationY);
                }

            }
        }

        private void DataRecorde(object sender, EventArgs e)
        {
            
        }

        private void TempMoni(object sender, EventArgs e)
        {
            
        }

        private void SetDataColumns()
        {
            DTRs = new();
            dataGridView1.AutoGenerateColumns= false;
            dataGridView1.DataSource = DTRs;
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn(){
                DataPropertyName="CollectTime",
                Name="CollectTime",
                HeaderText="采集时间",
                DefaultCellStyle=new DataGridViewCellStyle()
                {
                    Format="yyyy-mm-dd hh:mm:ss",
                    Alignment=DataGridViewContentAlignment.MiddleCenter
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

            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows= false;
            dataGridView1.AllowUserToDeleteRows= false;
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
