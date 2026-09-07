using System.ComponentModel;

namespace day12
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            panel1.Paint += Panel1_Paint;
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (SolidBrush brushGreen = new SolidBrush(Color.Green))
            using (SolidBrush brushBlack = new SolidBrush(Color.Black))
            using (SolidBrush brushColor = new SolidBrush(Color.FromArgb(255,100, 255, 100)))
            using (Pen penRed = new Pen(Color.Red, 2))
            using (Pen penO = new Pen(Color.Orange, 2))
            {
                g.DrawRectangle(penRed, 10, 10, 200, 200);
                g.FillRectangle(brushGreen,220, 10, 200, 200);
                g.FillRectangle(brushColor,440, 10, 200, 200);
                g.DrawEllipse(penRed,10,220,200, 200);
                g.FillEllipse(brushColor, 230, 220, 200, 200);
                g.DrawEllipse(penO,10,10,200, 100);

                g.DrawLine(penO, 500, 300, 700, 300);

                Font f = new Font("微软雅黑", 18);
                //g.DrawString("DGI+测试文字", f, brushBlack, 500, 300);
                StringFormat Sf =new StringFormat();
                Sf.Alignment = StringAlignment.Center;
                Sf.LineAlignment = StringAlignment.Center;
                g.DrawString("DGI+测试文字", f, brushBlack, 500, 300,Sf);
            }
            

        }

    }
}