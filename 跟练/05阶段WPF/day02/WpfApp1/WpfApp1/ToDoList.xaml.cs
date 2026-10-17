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
    /// ToDoList.xaml 的交互逻辑
    /// </summary>
    public partial class ToDoList : Window
    {
        public ObservableCollection<ToDo> ToDoLists { get; set; } = new ObservableCollection<ToDo>()
        {
            new ToDo("吃饭",1),
            new ToDo("睡觉",2),
        };
        public ToDoList()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CurrToDoName.Text.Trim() == "") return;
            int CurrToDoId = ToDoLists[ToDoLists.Count - 1].todoId + 1;
            ToDoLists.Add(new ToDo(CurrToDoName.Text.Trim(), CurrToDoId));
            CurrToDoName.Text = "";
        }
    }
    public class ToDo
    {
        public string todoName { get; set; }
        public int todoId { get; set; }
        public ToDo(string Name,int Id)
        {
            todoName = Name;
            todoId= Id;
        }
    }
}
