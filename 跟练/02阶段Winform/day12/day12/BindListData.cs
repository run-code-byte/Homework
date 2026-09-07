using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace day12
{
    internal class BindListData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _BookName { get; set; }
        public string BookName
        {
            get
            {
                return _BookName;
            }
            set
            {
                _BookName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BookName)));
            }
        }
        private double _BookPrice { get; set; }
        public double BookPrice
        {
            get
            {
                return _BookPrice;
            }
            set
            {
                _BookPrice = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BookPrice)));
            }
        }
    }
}
