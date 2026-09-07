using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace day11
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog OFD = new OpenFileDialog())
            {
                OFD.Title = "请选择文件";
                OFD.Filter = "图片|*.png|图像|*.jpg;*.jpeg;*.webp|所有|*.*";
                OFD.FilterIndex = 2;
                OFD.InitialDirectory = Application.StartupPath;

                DialogResult res = OFD.ShowDialog();
                if (res == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(OFD.FileName);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog OFD = new OpenFileDialog())
            {
                OFD.Title = "请选择文件";
                OFD.Filter = "图片|*.png|图像|*.jpg;*.jpeg;*.webp|所有|*.*";
                OFD.FilterIndex = 2;
                //OFD.InitialDirectory = Application.StartupPath;
                OFD.Multiselect = true;
                DialogResult res = OFD.ShowDialog();
                if (res == DialogResult.OK)
                {
                    string[] pics = OFD.FileNames;
                    for (int i = 0; i < pics.Length; i++)
                    {
                        var p = new PictureBox()
                        {
                            Image = Image.FromFile(pics[i]),
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Size = new Size(100, 140),
                            Location = new Point(i * 105, 260)
                        };
                        this.Controls.Add(p);
                    }
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog SFD = new SaveFileDialog())
            {
                SFD.Title = "保存文件";
                SFD.Filter = "图片|*.png|图像|*.jpg;*.jpeg;*.webp|所有|*.*";
                SFD.OverwritePrompt = false;
                SFD.AddExtension = true;
                SFD.DefaultExt = "md";
                if (SFD.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(SFD.FileName, "保存的内容212");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog FBD = new FolderBrowserDialog())
            {
                FBD.Description = "请选择文件夹";
                FBD.SelectedPath = Application.StartupPath;
                if (FBD.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show(FBD.SelectedPath);
                }
            }
        }
    }
}
