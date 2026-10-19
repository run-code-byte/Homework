using Cognex.VisionPro.Blob;
using Cognex.VisionPro.PMAlign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Window3.xaml 的交互逻辑
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();

            // 手动创建visionPro的控件
            CogPMAlignEditV2 PMA = new CogPMAlignEditV2()
            {
                Dock = System.Windows.Forms.DockStyle.Fill
            };
            //wf.Child = PMA;
        }
    }
}
