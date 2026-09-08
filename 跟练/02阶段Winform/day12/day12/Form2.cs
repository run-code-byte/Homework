using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace day12
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            panel1.Paint += Panel1_Paint;
        }

        private void Panel1_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //int Radius = 100;
            //int cx = 100;
            //int cy = 100;
            //Point[] points = new Point[3];
            //double[] angles = { 30, 270, 150 };
            //for (int i = 0; i < angles.Length; i++)
            //{
            //    var px = Math.Cos(angles[i] * Math.PI / 180) * Radius + cx;
            //    var py = Math.Sin(angles[i] * Math.PI / 180) * Radius + cy;
            //    points[i] = new Point((int)px, (int)py);
            //}
            //using (Pen penRed = new Pen(Color.Red, 2))
            //{
            //    g.DrawPolygon(penRed, points);
            //    //g.DrawEllipse(penRed, 0, 0, 200, 200);

            //}

            using (Pen penRed = new Pen(Color.Red, 2))
            //using (var brushRed = new SolidBrush(Color.Red))
            {
                var rg = new Rectangle(10, 10, 100, 100);
                g.DrawArc(penRed, rg, 0,360);
                //g.FillArc(brushRed, rg, 0,360);
            }

        }
    }
}
