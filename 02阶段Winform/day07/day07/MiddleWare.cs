using System;
using System.Collections.Generic;
using System.Text;

namespace day07
{
    internal class MiddleWare
    {
        private Dictionary<int, Action<object>> MsgBox = new Dictionary<int, Action<object>>() { };
        public void AddMsg(int Id, Action<object> callBack) {
            MsgBox[Id] = callBack;
        }
        public void CallMsg(int Id, object data) {
            MsgBox[Id].Invoke(data);
        }
        private MiddleWare() { }
        private static MiddleWare instance { get; set; }
       public static MiddleWare GetInstance()
        {
            if(instance==null)instance=new MiddleWare();
            return instance;
        }
    }
}
