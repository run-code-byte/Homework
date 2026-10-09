using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3ShowVpp : Form
    {
        public Form3ShowVpp()
        {
            InitializeComponent();
            this.FormClosed += Form3ShowVpp_FormClosed;
        }

        private void Form3ShowVpp_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private CogToolBlock CTB;

        private void button1_Click(object sender, EventArgs e)
        {
            //CTB = CogSerializer.LoadObjectFromFile("./vpps/瓶盖计数带相机.vpp") as CogToolBlock;
            CTB = CogSerializer.LoadObjectFromFile("./vpps/new瓶盖计数带相机.vpp") as CogToolBlock;
            MessageBox.Show("方案加载成功");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cogToolBlockEditV21.Subject = CTB;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CogSerializer.SaveObjectToFile(CTB, "./vpp/new瓶盖计数带相机.vpp");
            MessageBox.Show("方案保存成功");
        }
    }
}
