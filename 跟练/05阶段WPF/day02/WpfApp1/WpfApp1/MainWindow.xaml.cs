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

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private PersonViewModel Person = new PersonViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Person;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Person.Name = "ls";
            Person.Age = 20;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Name:{Person.Name}--Age:{Person.Age}");
        }
    }
}
