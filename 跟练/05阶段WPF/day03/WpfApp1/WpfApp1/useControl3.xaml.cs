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
    /// useControl3.xaml 的交互逻辑
    /// </summary>
    public partial class useControl3 : Window
    {
        public string dataStr { get; set; } = "我是订阅者";
        public useControl3()
        {
            InitializeComponent();
            this.DataContext = this;
            Bus BusIns = Bus.CreateIns();
            BusIns.AddFn(getData);

        }
        private void getData(string data)
        {
            //dataStr = data;
            MessageBox.Show(data);
            tb.Text = data;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            useControl4 uc = new useControl4();
            uc.Show();
            //uc.Closed += Uc_Closed;
        }

        private void Uc_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("13245");
        }
    }
}
