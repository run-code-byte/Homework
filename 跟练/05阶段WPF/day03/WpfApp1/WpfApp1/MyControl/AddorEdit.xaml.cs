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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.MyControl
{
    /// <summary>
    /// AddorEdit.xaml 的交互逻辑
    /// </summary>
    public partial class AddorEdit : UserControl
    {
        public Action<string> sonFn { get; set; }
        public string textstring { get; set; }

        public AddorEdit()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public AddorEdit(string textdata)
        {
            InitializeComponent();
            this.textstring = textdata;
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string bookname = BN.Text;
            sonFn.Invoke(bookname);
        }
    }
}
