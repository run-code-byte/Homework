using System.Drawing.Drawing2D;

namespace WinFormsControlLibrary1
{
    public partial class UserControl1 : UserControl
    {
        private int ShortLineStartX = 0;
        private int ShortLineStartY = 0;
        private int ShortLineEndX = 0;
        private int ShortLineEndY = 0;
        public UserControl1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            panel1.Paint += Panel1_Paint;
            // 刻度初始x、y
            ShortLineStartX = RX + R;
            ShortLineEndX = RX + R - ShortLine;
            ShortLineEndY = RY;
            ShortLineStartY = RY;
            MyTimer.Interval = 2000;
            MyTimer.Tick += MyTimer_Tick;
            MyTimer.Start();
        }

        private void MyTimer_Tick(object? sender, EventArgs e)
        {
            CurrentTemp++;
            panel1.Invalidate();
        }

        private int RX = 60;
        private int RY = 60;
        private int R = 60;
        private int ShortLine = 10;
        private int ShortLineCount = 30;
        private int CurrentTemp = 20;
        private double EveryDeg = 6;
        private double EveryTemp = 2;
        private System.Windows.Forms.Timer MyTimer = new System.Windows.Forms.Timer();
        private void Panel1_Paint(object? sender, PaintEventArgs e)
        {
            // 获取画图对象
            Graphics g = e.Graphics;
            // 配置抗锯齿
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;


            using (Pen penGreen = new Pen(Color.Green, 2))
            {
                Rectangle Rect = new Rectangle(RX - R, RY - R, R * 2, R * 2);
                g.DrawArc(penGreen, Rect, 180, 180);
                for (int i = 0; i <= 30; i++)
                {
                    var LineLength = ShortLine;
                    if (i % 10 == 0)
                    {
                        LineLength = ShortLine + 5;
                    }
                    var StartX = RX + Math.Cos((180 + EveryDeg * i) * Math.PI / 180) * R;
                    var StartY = RY + Math.Sin((180 + EveryDeg * i) * Math.PI / 180) * R;
                    var EndX = RX + Math.Cos((180 + EveryDeg * i) * Math.PI / 180) * (R - LineLength);
                    var EndY = RY + Math.Sin((180 + EveryDeg * i) * Math.PI / 180) * (R - LineLength);

                    g.DrawLine(Pens.Orange, (int)StartX, (int)StartY, (int)EndX, (int)EndY);

                    if (i % 10 == 0)
                    {
                        using (Brush brushText = new SolidBrush(Color.Black))
                        using (StringFormat sf = new StringFormat())
                        using (Font font = new Font("微软雅黑", 8))
                        {
                            /*
                                0 60 60
                                10 60 40
                                20 60 20
                                30 60 0
                            */
                            sf.Alignment = StringAlignment.Center;
                            sf.LineAlignment = StringAlignment.Center;
                            var FontEndX = RX + Math.Cos(-EveryDeg * i * Math.PI / 180) * (R - LineLength - 10);
                            var FontEndY = RY + Math.Sin(-EveryDeg * i * Math.PI / 180) * (R - LineLength - 10);
                            g.DrawString(((30 - i) * EveryTemp).ToString(), font, brushText, (float)FontEndX, (float)FontEndY, sf);
                        }
                    }
                }

                var PointX = RX + Math.Cos(-(180 - CurrentTemp / EveryTemp * EveryDeg) * Math.PI / 180) * (R - 10);
                var PointY = RY + Math.Sin(-(180 - CurrentTemp / EveryTemp * EveryDeg) * Math.PI / 180) * (R - 10);
                g.DrawLine(Pens.Green, (int)PointX, (int)PointY, (int)RX, (int)RY);
                Point[] pts = new Point[3];
                // 三个角度，0°、120°、240°
                double[] angles = { -(180 - CurrentTemp / EveryTemp * EveryDeg), -(180 - CurrentTemp / EveryTemp * EveryDeg) + 150, -(180 - CurrentTemp / EveryTemp * EveryDeg) + 210 };

                for (int i = 0; i < 3; i++)
                {
                    double rad = angles[i] * Math.PI / 180;
                    int x = (int)PointX + (int)(5 * Math.Cos(rad));
                    int y = (int)PointY + (int)(5 * Math.Sin(rad));
                    pts[i] = new Point(x, y);
                }

                using (SolidBrush brush = new SolidBrush(Color.FromArgb(180, 255, 0, 0)))
                {
                    g.FillPolygon(brush, pts);
                }
            }
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
