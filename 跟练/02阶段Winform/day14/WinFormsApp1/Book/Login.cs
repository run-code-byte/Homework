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
            // 判断setting中是否有用户名和密码
            if (Properties.Settings.Default.username != "" && Properties.Settings.Default.password != "")
            {
                input1.Text = Properties.Settings.Default.username;
                input2.Text = Properties.Settings.Default.password;
            }
        }
        private Mysql MySql = new Mysql("test");
        public event Action<string> LoginMark;
        private async void button1_Click(object sender, EventArgs e)
        {
            // 点击实现登录

            // 获取数据
            string Name = input1.Text;
            string Pwd = input2.Text;

            // 不为空校验
            if (Name.Trim() == "" || Pwd.Trim() == "")
            {
                MessageBox.Show("用户名或密码不能为空");
                return;
            }

            string sql = "select * from user where username=@username and password=@password";
            await MySql.ConAndHandler(sql, Cmd =>
            {
                Cmd.Parameters.AddWithValue("@username", Name);
                Cmd.Parameters.AddWithValue("@password", Pwd);

                MySqlDataReader Reader = Cmd.ExecuteReader();
                bool isLogin = Reader.Read();
                if (isLogin)
                {
                    if (checkbox1.Checked)
                    {
                        // 记录登录成功的用户名和密码
                        Properties.Settings.Default.username = Name;
                        Properties.Settings.Default.password = Pwd;
                        // 保存
                        Properties.Settings.Default.Save();
                    }
                    MessageBox.Show("登录成功");
                    LoginMark.Invoke("已登录");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误!!!");
                    LoginMark.Invoke("未登录");
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
