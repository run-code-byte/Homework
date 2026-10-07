using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Book : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _Id { get; set; }
        public int Id
        {
            get { return _Id; }
            set
            {
                if (_Id != value)
                {
                    _Id = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
                }
            }
        }
        private string _Name { get; set; }
        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                }
            }
        }
        private double _Price { get; set; }
        public double Price
        {
            get { return _Price; }
            set
            {
                if (_Price != value)
                {
                    _Price = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
                }
            }
        }
        private bool _IsBorrow { get; set; }
        public bool IsBorrow
        {
            get { return _IsBorrow; }
            set
            {
                if (_IsBorrow != value)
                {
                    _IsBorrow = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBorrow)));
                }
            }
        }
        public Book(int id, string name, double price, bool isBorrow)
        {
            //_Id = id;
            //_Name = name;
            //_Price = price;
            Id = id;
            Name = name;
            Price = price;
            IsBorrow = isBorrow;
        }
    }
}
