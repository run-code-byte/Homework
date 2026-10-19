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
    /// useControl4.xaml 的交互逻辑
    /// </summary>
    public partial class useControl4 : Window
    {
        public useControl4()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Bus BusIns = Bus.CreateIns();
            BusIns.fabu("我是uc4来的数据");
        }
    }
}
