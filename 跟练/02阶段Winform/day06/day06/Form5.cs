using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using day06.myControl;

namespace day06
{
    public partial class Form5 : Form
    {

        public Form5()
        {
            InitializeComponent();
        }
        public List<User> users = new List<User>();
        private void button1_Click(object sender, EventArgs e)
        {
            string uname = textBox1.Text;
            string uage = textBox2.Text;

            UCinfo uci = new UCinfo(uname, uage);
            string uid=Guid.NewGuid().ToString();
            uci.toParent += del;
            uci.Tag= uid;
            users.Add(new User(uname, uage,uid));
            flowLayoutPanel1.Controls.Add(uci);

        }
        private void del(string id)
        {
            //MessageBox.Show(id);
            users.RemoveAll(item => item.uid == id);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(users.Count.ToString());
        }
    }
    public class User
    {
        public string username {  get; set; }
        public string userage { get; set; }
        public string uid { get; set; }
        public User(string username,string userage,string uid) {
            this.username = username;
            this.userage= userage;
            this.uid = uid;
        }
    }
}
