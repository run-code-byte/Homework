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
    public partial class VisonEdit : Form
    {
        public VisonEdit()
        {
            InitializeComponent();
            this.Shown += VisonEdit_Shown;
        }
        private ICogAcqFifo Acq { get; set; }
        private CogAcqFifoTool AcqTool { get; set; }
        private CogToolBlock CTB { get; set; }

        private void VisonEdit_Shown(object sender, EventArgs e)
        {
            CTB = CogSerializer.LoadObjectFromFile("./vpps/new瓶盖计数带相机.vpp") as CogToolBlock;
        }
    }
}
