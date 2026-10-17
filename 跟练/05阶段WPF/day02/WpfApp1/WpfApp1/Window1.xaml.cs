using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        //public List<string> ItemList { get; set; } = new List<string>() { "吃饭", "睡觉", "大豆豆", "写代码" };
        public ObservableCollection<string> ItemList { get; set; } = new ObservableCollection<string>() { "吃饭", "睡觉", "大豆豆", "写代码" };
        public Window1()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ItemList[0] = "喝水";
        }

      
    }
}
