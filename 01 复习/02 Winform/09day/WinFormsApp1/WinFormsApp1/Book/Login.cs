using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1.Book
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private Mysql Mysql = new Mysql("test");
        public event Action<string> LoginMark;
        private async void button1_Click(object sender, EventArgs e)
        {
            string Name = input1.Text;
            string Password = input2.Text;

            if (Name.Trim() == "" || Password.Trim() == "")
            {
                MessageBox.Show("用户名或密码不能为空");
                return;
            }
            string sql = @"select * from user where username=@name and password=@password";
            await Mysql.ConAndHandler(sql, Cmd =>
            {
                Cmd.Parameters.AddWithValue("@name", Name);
                Cmd.Parameters.AddWithValue("@password", Password);
                MySqlDataReader Reader = Cmd.ExecuteReader();
                bool isLogin = Reader.Read();
                if (isLogin)
                {
                    MessageBox.Show("登录成功");
                    LoginMark?.Invoke("已登录");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误");
                    LoginMark?.Invoke("未登录");
                    this.Close();
                }
                return true;
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register rg = new Register();
            rg.Show();
            this.Hide();
            rg.FormClosing += (object sender, FormClosingEventArgs e) => this.Show();
        }
    }
}
