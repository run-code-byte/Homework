using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.viewModel
{
    public class ToDoName : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _doname { get; set; }
        public string Doname
        {
            get { return _doname; }
            set { _doname = value; OnPropertyChanged(); }
        }
        public void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
