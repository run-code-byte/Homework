using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
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
    /// useControl.xaml 的交互逻辑
    /// </summary>
    public partial class useControl : Window
    {
        public useControl()
        {
            InitializeComponent();
            MessageBox.Show(AutomationProperties.GetHelpText(MyUserControl));
        }
    }
}
