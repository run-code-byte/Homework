using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace day06.myControl
{
    public partial class UCinfo : UserControl
    {
        public UCinfo(string uname, string uage)
        {
            InitializeComponent();
            nameLab.Text = uname;
            ageLab.Text = uage;
        }
        public UCinfo()
        {
            InitializeComponent();
        }
        public Action<string> toParent;

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Parent.Parent.Controls.Remove(button1.Parent);
            //MessageBox.Show(this.Tag.ToString());
            toParent?.Invoke(this.Tag.ToString());
        }
    }
}
