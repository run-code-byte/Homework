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
using WpfApp1.pages;

namespace WpfApp1
{
    /// <summary>
    /// Window4.xaml 的交互逻辑
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
        }

        private void ToPage1(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(new Page1());
        }
        private void ToPage2(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(new Page2());
        }
        private void ToPage3(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(new Page3());
        }
        private void Toback(object sender, RoutedEventArgs e)
        {
            MyFrame.GoBack();
        }
    }
}
