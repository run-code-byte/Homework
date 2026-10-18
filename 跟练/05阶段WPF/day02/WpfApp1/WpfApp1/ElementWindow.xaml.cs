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
    /// ElementWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ElementWindow : Window
    {
        public ElementWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(label.ToString());
            //label.Background = Brushes.Cyan;
            //(FindName("label") as Label).Background = Brushes.CornflowerBlue;
            //(myPan.Children[0] as Label).Background = Brushes.Aqua;
            //foreach(Control Ctl in myPan.Children)
            //{
            //    Ctl.Foreground = Brushes.Blue;
            //}
            MessageBox.Show(((label.Parent as Panel).Children[1] as Label).Content.ToString());

        }

        private void AddLabel(object sender, RoutedEventArgs e)
        {
            Label newLabel = new Label()
            {
                Content = "我是添加的Label",
                Width = 100,
                Height = 50,
                Background = Brushes.CornflowerBlue
            };
            myPan.Children.Add(newLabel);
        }
    }
}
