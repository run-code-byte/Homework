using Cognex.VisionPro;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.ToolBlock;
using Microsoft.Win32;
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
    /// Window2.xaml 的交互逻辑
    /// </summary>
    public partial class Window2 : Window
    {
        private CogToolBlock CTB { get; set; }
        public Window2()
        {
            InitializeComponent();
            CTB = CogSerializer.LoadObjectFromFile("D:\\桌面\\老师发\\正课\\05阶段WPF\\day03\\04-资料\\vpps\\玩具轮胎计数方案.vpp") as CogToolBlock;
            //D:\桌面\老师发\正课\05阶段WPF\day03\04-资料\vpps\玩具轮胎计数方案.vpp
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "检测图像|*.png";
            if ((bool)OFD.ShowDialog())
            {
                //OFD.FileName
                Img.Source = new BitmapImage(new Uri(OFD.FileName));

                //CogImageConvertTool CIC = new CogImageConvertTool();
                CogImageFileTool CIFT = new CogImageFileTool();
                CIFT.Operator.Open(OFD.FileName, CogImageFileModeConstants.Read);
                CIFT.Run();

                CTB.Inputs["OutputImage"].Value = CIFT.OutputImage;
                CTB.Run();
                MessageBox.Show(CTB.Outputs["Result_Count"].Value.ToString());

            }

        }
    }
}
