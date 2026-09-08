using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
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
            // 初始化设置
            inputNumber1.Minimum = 1;
            inputNumber1.Maximum = 120;
            select1.Items = ["01班", "02班", "03班", "04班"];
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // 1. 获取数据并校验
            string username = input1.Text.Trim();
            if (!Regex.IsMatch(username, @"^[0-9a-zA-Z]{4,15}$"))
            {
                MessageBox.Show("用户名格式有误!");
                return;
            }

            string password = input2.Text.Trim();
            if (password.Length < 6 || password.Length > 15)
            {
                MessageBox.Show("密码格式有误!");
                return;
            }

            // 两次密码一致校验
            if (password != input3.Text.Trim())
            {
                MessageBox.Show("两次密码不一致!");
                return;
            }

            int age = (int)inputNumber1.Value; // 获取年龄

            // 获取性别
            string gender = radio1.Checked ? "男" : "女";

            if (select1.SelectedValue == null)
            {
                MessageBox.Show("班级未选择!");
                return;
            }
            string banji = select1.SelectedValue.ToString();
            //MessageBox.Show(banji);

            // 校验这个用户是否已注册
            string sqlName = "select * from user where username=@username";
            bool isName = await MySql.ConAndHandler(sqlName, Cmd =>
            {
                Cmd.Parameters.AddWithValue("@username", username);
                MySqlDataReader Reader = Cmd.ExecuteReader();
                bool isRead = Reader.Read();
                if (isRead) return false;
                return true;
            });

            if (!isName)
            {
                MessageBox.Show("用户名已经注册,请重试!!!");
                return; // 后续代码执行
            }
            // 数据获取校验完毕, 写入数据库
            string sql = "insert into user(username,password,age,gender,banji) value(@username,@password,@age,@gender,@banji)";
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
                    MessageBox.Show("注册成功,去登录吧!!!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("注册失败,请重试!!!");
                }

                return true;

            });




            //// 数据获取校验完毕, 写入数据库
            //string sql = "insert into user(username,password,age,gender,banji) value(@username,@password,@age,@gender,@banji)";
            //MySql.ConAndHandler(sql, Cmd =>
            //{
            //    Cmd.Parameters.AddWithValue("@username", username);
            //    Cmd.Parameters.AddWithValue("@password", password);
            //    Cmd.Parameters.AddWithValue("@age", age);
            //    Cmd.Parameters.AddWithValue("@gender", gender);
            //    Cmd.Parameters.AddWithValue("@banji", banji);

            //    int rows = Cmd.ExecuteNonQuery();
            //    if (rows > 0)
            //    {
            //        MessageBox.Show("注册成功,去登录吧!!!");
            //        this.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("注册失败,请重试!!!");
            //    }
            //});

        }
    }
}
