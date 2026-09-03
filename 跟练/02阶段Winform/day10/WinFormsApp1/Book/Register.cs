using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsApp1.Book
{
    public partial class Register : Form
    {
        private Mysql MySql = new Mysql("test");
        public Register()
        {
            InitializeComponent();
            inputNumber1.Minimum = 1;
            inputNumber1.Maximum = 120;
            select1.Items = ["01班", "02班", "03班"];
        }

        private  async Task button1_Click(object sender, EventArgs e)
        {
            string username = input1.Text.Trim();
            if(!Regex.IsMatch(username, @"^[a-zA-Z0-9_]{4,15}$") )
            {
                MessageBox.Show("用户名格式有误");
                return;
            }
            string password = input2.Text.Trim();
            if (password.Length < 6 || password.Length > 15)
            {
                MessageBox.Show("密码格式有误");
                return;
            }
            if(password != input3.Text.Trim())
            {
                MessageBox.Show("两次输入的密码不一致");
                return;
            }
            int age = (int)inputNumber1.Value;
            string gender = radio1.Checked ? radio1.Text : radio2.Text;

            if(select1.SelectedValue==null)
            {
                MessageBox.Show("班级未选择");
                return;
            }
            string banji = select1.SelectedValue.ToString();
           
            string sqlName= "select * from user where username=@username";
            bool isName = await MySql.ConAndHandler(sqlName, Cmd =>
            {
                Cmd.Parameters.AddWithValue("@username", username);
                MySqlDataReader Reader = Cmd.ExecuteReader();
                if (Reader.Read())
                {
                    MessageBox.Show("用户名已存在，请更换用户名");
                    return false;
                }
                return true;
            });
            string sql = "insert into user (username, password, age, gender, banji) values(@username, @password, @age, @gender, @banji)";
            await MySql.ConAndHandler(sql, Cmd =>
            {
                Cmd.Parameters.AddWithValue("@username", username);
                Cmd.Parameters.AddWithValue("@password", password);
                Cmd.Parameters.AddWithValue("@age", age);
                Cmd.Parameters.AddWithValue("@gender", gender);
                Cmd.Parameters.AddWithValue("@banji", banji);


                int rows = Cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("注册成功,去登录吧！！！");
                }
                else
                {
                    MessageBox.Show("注册失败，请重试");
                }
                return true;
            });
        }
    }
}
