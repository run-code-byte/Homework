using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace day12
{
    public partial class Form3 : Form
    {
        private System.Windows.Forms.Timer timer=new System.Windows.Forms.Timer();
        private int Num = 0;
        public Form3()
        {
           


            InitializeComponent();
            panel1.Paint += Panel1_Paint;
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            Num = DateTime.Now.Second;
            panel1.Invalidate();
        }

        private int Radius = 100;
        private int RadiusX = 150;
        private int RadiusY = 150;

        private int LongScale = 10;
        private int Count = 60;

        private void Panel1_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (Pen p = new Pen(Color.Black, 2))
            {
                g.DrawArc(p, RadiusX - Radius, RadiusY - Radius, 2 * Radius, 2 * Radius, 0, 360);
                var tmpLong = 10;
                for (int i = 0; i < Count; i++)
                {
                    if (i % 5 == 0) tmpLong = 2 * LongScale;
                    var startX = Math.Cos(360/Count*i* Math.PI / 180) * Radius + RadiusX;
                    var startY = Math.Sin(360 / Count*i * Math.PI / 180) * Radius + RadiusY;
                    var endX = Math.Cos(360/Count*i * Math.PI / 180) * (Radius - tmpLong) + RadiusX;
                    var endY = Math.Sin(360/Count*i * Math.PI / 180) * (Radius - tmpLong) + RadiusY;
                    g.DrawLine(p, (int)startX, (int)startY, (int)endX, (int)endY);
                    tmpLong = LongScale;
                }
                using (Pen pRed=new Pen(Color.Red, 2))
                {
                    var endX = Math.Cos(((360 / Count) * Num + 90) * Math.PI / 180) * (Radius - tmpLong) + RadiusX;
                    var endY = Math.Sin(((360 / Count) * Num + 90) * Math.PI / 180) * (Radius - tmpLong) + RadiusY;
                    g.DrawLine(pRed, RadiusX, RadiusY, (int)endX, (int)endY);
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

/*
 //g.DrawLine(p, RadiusX + Radius, RadiusY ,  RadiusX+80, RadiusY);
//var startX=Math.Cos(30*Math.PI/180)*Radius+RadiusX;
//var startY=Math.Sin(30*Math.PI/180)*Radius+RadiusY;
//var endX = Math.Cos(30 * Math.PI / 180) * (Radius-20) + RadiusX;
//var endY = Math.Sin(30 * Math.PI / 180) * (Radius - 20) + RadiusY;
//g.DrawLine(p, (int)startX, (int)startY, (int)endX, (int)endY);

//var startX = Math.Cos(30*2 * Math.PI / 180) * Radius + RadiusX;
//var startY = Math.Sin(30*2 * Math.PI / 180) * Radius + RadiusY;
//var endX = Math.Cos(30*2 * Math.PI / 180) * (Radius - 20) + RadiusX;
//var endY = Math.Sin(30*2 * Math.PI / 180) * (Radius - 20) + RadiusY;
//g.DrawLine(p, (int)startX, (int)startY, (int)endX, (int)endY);
 
 
 */