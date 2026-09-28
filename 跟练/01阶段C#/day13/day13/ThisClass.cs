using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day13
{
    internal class BankCard
    {
        public string CardNo { get; set; }
        public string Owner { get; set; }

        //构造函数1
        public BankCard(string cardNo) : this(cardNo, "未知户主") // 调用下面的构造函数执行
        {
            // 这里不用写具体代码了
        }

        //构造函数2
        public BankCard(string cardNo, string owner)
        {
            CardNo = cardNo;
            Owner = owner;
        }

        private int N { get; set; }

        public int this[int index]
        {
            get
            {
                return this.N;
            }
            set
            {
                // 给某个数据赋值
                this.N = value;
            }
        }
    }
}
