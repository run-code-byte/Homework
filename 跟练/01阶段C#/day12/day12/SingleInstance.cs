using System;
using System.Collections.Generic;
using System.Text;

namespace day12
{
    internal class SingleInstance
    {
        public bool isTool;
        private SingleInstance()
        {

        }

        private static SingleInstance Instance { get; set; }

        static public SingleInstance GetInstance()
        {
            if (Instance == null)
            {
                Instance = new SingleInstance();
            }
            return Instance;
        }
    }
}
