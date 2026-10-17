using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class PersonViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name { get; set; } = "zs";
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }
        private int _age { get; set; } =18;
        public int Age
        {
            get { return _age; }
            set {
                _age = value;
                OnPropertyChanged();
            }
        }
        public virtual void OnPropertyChanged([CallerMemberName]string PropertyName=null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
