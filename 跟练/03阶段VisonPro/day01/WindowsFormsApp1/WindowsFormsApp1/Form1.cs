using Cognex.VisionPro;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.ToolBlock;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog OFD = new OpenFileDialog())
            {
                OFD.Title = "请选择检测轮胎数量的图片";
                OFD.Filter = "图片|*.jpg;*.jpeg;*.png;*.gif;";
                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(OFD.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    CogImageFileTool CFT = new CogImageFileTool();
                    CFT.Operator.Open(OFD.FileName, CogImageFileModeConstants.Read);
                    string VppFilePath = Path.Combine(Directory.GetCurrentDirectory(), "vpps", "玩具轮胎的计数方案.vpp");
                    object LOF = CogSerializer.LoadObjectFromFile(VppFilePath);
                    CogToolBlock CTB = (LOF as CogToolBlock);
                    CTB.Inputs["OutInputImage"].Value = CFT.OutputImage;
                    CTB.Run();
                    MessageBox.Show("111");
                    //MessageBox.Show(CTB.Outputs["Results_Count"].Value.ToString());
                }
            }
        }
    }
}
