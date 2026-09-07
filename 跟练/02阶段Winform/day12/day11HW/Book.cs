using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace day11HW
{
    internal class Book
    {
        // 固定写法, 实现INotifyPropertyChanged 中的 接口属性
        public event PropertyChangedEventHandler PropertyChanged;
        private int _Id { get; set; }
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {

                _Id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }

        private string _Name { get; set; }
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {

                _Name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }


        private double _Price { get; set; }
        public double Price
        {
            get
            {
                return _Price;
            }
            set
            {

                _Price = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
            }
        }

        private bool _IsBorrow { get; set; }
        public bool IsBorrow
        {
            get
            {
                return _IsBorrow;
            }
            set
            {

                _IsBorrow = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBorrow)));
            }
        }


        public Book(int id, string name, double price, bool isBoorow)
        {
            Id = id;
            Name = name;
            Price = price;
            IsBorrow = isBoorow;
        }
        public Book()
        {

        }
    }
}
