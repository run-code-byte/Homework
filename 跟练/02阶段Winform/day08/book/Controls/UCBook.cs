using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace book.Controls
{
    public partial class UCBook : UserControl
    {
        public UCBook()
        {
            InitializeComponent();
        }
        public UCBook(string text)
        {
            InitializeComponent();
            button1.Text = text;
            label1.Text = "图书" + text;
        }

        internal event Action<BookInfo> SendData;

        private void button1_Click(object sender, EventArgs e)
        {
            SendData.Invoke(new BookInfo()
            {
                Id = Guid.NewGuid().ToString(),
                Name = nameInp.Text,
                Author = authorInp.Text,
                Price = double.Parse(priceInpNum.Text),
                BookLabel = input3.Text,
                IsBorrow = false
            });
        }
    }
}
