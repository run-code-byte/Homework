using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace day09.Book
{
    public partial class Login : Form
    {
        private MySql MySql = new MySql("test");
        public event Action<string> LoginMark;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name = input1.Text;
            string Pwd = input2.Text;
            if(Name.Trim()== "" || Pwd.Trim() == "")
            {
                MessageBox.Show("用户名或密码不能为空");
                return;
            }
            string sql = "select * from user where username=@username and password=@password";
            MySql.ConAndHandler(sql, (cmd) =>
            {
                cmd.Parameters.AddWithValue("@username", Name);
                cmd.Parameters.AddWithValue("@password", Pwd);
                MySqlDataReader reader = cmd.ExecuteReader();
                bool isread = reader.Read();
                if (isread)
                {

                    MessageBox.Show("登录成功");
                    LoginMark.Invoke("已登录");
                    this.Close();

                }
                else
                {
                    MessageBox.Show("用户名或密码错误");
                    LoginMark.Invoke("未登录");
                    this.Close();

                }
            });
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Register RG = new Register();
            RG.Show();
            this.Hide();
            RG.FormClosing += (object sender, FormClosingEventArgs e) => this.Show();
        }
    }
}
