using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WpfApp1
{
    public class Bus
    {
        private Action<string> Fn { get; set; }
        public void AddFn(Action<string> f)
        {
            Fn = f;
        }
        public void fabu(string data)
        {
            Fn(data);
        }
        private Bus() { }
        private static Bus _instance { get; set; }
        public static Bus CreateIns()
        {
            if (_instance == null) _instance = new Bus();
            return _instance;
        }
    }
}
