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
using WpfApp1.MyControl;

namespace WpfApp1
{
    /// <summary>
    /// useControl2.xaml 的交互逻辑
    /// </summary>
    public partial class useControl2 : Window
    {
        public useControl2()
        {
            InitializeComponent();
            //AddorEdit Aoe = new AddorEdit("修改");
            //myGrid.Children.Add(Aoe);

            //AddorEdit Aoe = new AddorEdit();
            //Aoe.textstring = "修改";
            //myGrid.Children.Add(Aoe);

            AddorEdit Aoe = new AddorEdit("新增");
            Aoe.sonFn = fuFn;
            myGrid.Children.Add(Aoe);
        }
        public void fuFn(string bn)
        {
            MessageBox.Show("在父窗体中获取的数据：" + bn);
        }
    }
}
