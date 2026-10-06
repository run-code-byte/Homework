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
        private Mysql Mysql = new Mysql("test");
        public Register()
        {
            InitializeComponent();
            inputNumber1.Minimum = 1;
            inputNumber1.Maximum = 120;
            select1.Items = ["01班", "02班", "03班", "04班"];
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string username = input1.Text.Trim();
            if(!Regex.IsMatch(username, @"^[0-9a-zA-Z]{4,15}$"))
            {
                MessageBox.Show("用户名格式有误！");
                return;
            }
            string password = input2.Text.Trim();
            if(password.Length < 6 || password.Length > 15)
            {
                MessageBox.Show("密码格式有误！");
                return;
            }
            if(password != input3.Text.Trim())
            {
                MessageBox.Show("两次输入的密码不一致！");
                return;
            }
            int age = (int)inputNumber1.Value;

            string gender = radio1.Checked ? "男" : "女";
            if(select1.SelectedValue == null)
            {
                MessageBox.Show("请选择班级！");
                return;
            }
            string banji = select1.SelectedValue.ToString();

            string checkSql = @"select * from user where username=@username";
            bool isUsernameAvailable = await Mysql.ConAndHandler(checkSql, Cmd =>
            {
                Cmd.Parameters.AddWithValue("@username", username);
                MySqlDataReader Reader = Cmd.ExecuteReader();
                if (Reader.Read())
                {
                    MessageBox.Show("用户名已存在！");
                    return false;
                }
                return true;
            });
            if(isUsernameAvailable == false)
            {
                
                return;
            }

            string sql = @"insert into user(username,password,age,gender,banji) values(@username,@password,@age,@gender,@banji)";
            await Mysql.ConAndHandler(sql, Cmd =>
            {
                Cmd.Parameters.AddWithValue("@username", username);
                Cmd.Parameters.AddWithValue("@password", password);
                Cmd.Parameters.AddWithValue("@age", age);
                Cmd.Parameters.AddWithValue("@gender", gender);
                Cmd.Parameters.AddWithValue("@banji", banji);
                int result = Cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("注册成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("注册失败！");
                }
                return true;
            });
        }
    }
}
