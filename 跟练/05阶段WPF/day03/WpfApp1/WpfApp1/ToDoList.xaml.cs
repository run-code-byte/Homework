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
using WpfApp1.viewModel;

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
        public ToDoName todoname { get; set; } = new ToDoName();
        public ToDoList()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (todoname.Doname.Trim() == "") return;
            int CurrToDoId;
            //if (ToDoLists.Count == 0) CurrToDoId = 1;
            //else CurrToDoId = ToDoLists[ToDoLists.Count - 1].todoId + 1;
            CurrToDoId = ToDoLists.Count == 0 ? 1:ToDoLists[ToDoLists.Count - 1].todoId + 1;

            ToDoLists.Add(new ToDo(todoname.Doname.Trim(), CurrToDoId));
            todoname.Doname = "";
        }

        private void Del(object sender, RoutedEventArgs e)
        {
            int Id = (int)(sender as Button).Tag;
            int index = ToDoLists.ToList().FindIndex(item => item.todoId == Id);
            ToDoLists.RemoveAt(index);
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListBox).SelectedItem;
            if (item == null) return;
            //MessageBox.Show((item as ToDo).todoName);
            editName.Text = (item as ToDo).todoName;
            editName.Tag = (item as ToDo).todoId;
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            string name = editName.Text;
            int id = (int)editName.Tag;
            int index = ToDoLists.ToList().FindIndex(item => item.todoId == id);
            //ToDoLists[index].todoName = name;
            //ToDoLists.RemoveAt(index);
            //ToDoLists.Insert(index, new ToDo(name, id));
            ToDoLists[index] = new ToDo(name,id);
            editName.Text = "";
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
