using MySqlConnector;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace day09.Book
{
    public partial class Register : Form
    {
        private MySql MySql = new MySql("test");
        public Register()
        {
            InitializeComponent();
            // 修改窗口标题文字，设计器里label1还是“登录”，代码改一下
            label1.Text = "用户注册";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 获取所有输入框的值
            string username = input1.Text.Trim();
            string password = input2.Text.Trim();
            string ageStr = input3.Text.Trim();
            string banji = input5.Text.Trim();

            // 1.非空校验
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("用户名不能为空");
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("密码不能为空");
                return;
            }
            if (string.IsNullOrEmpty(ageStr))
            {
                MessageBox.Show("年龄不能为空");
                return;
            }
            if (string.IsNullOrEmpty(banji))
            {
                MessageBox.Show("班级不能为空");
                return;
            }
            // 性别校验
            string gender = "";
            if (radio1.Checked)
            {
                gender = "男";
            }
            else if (radio2.Checked)
            {
                gender = "女";
            }
            else
            {
                MessageBox.Show("请选择性别");
                return;
            }

            // 年龄转int
            int age;
            if (!int.TryParse(ageStr, out age))
            {
                MessageBox.Show("年龄必须是数字！");
                return;
            }

            // 2.先查询用户名是否已经存在
            bool isExist = false;
            string checkSql = "select id from user where username=@username";
            MySql.ConAndHandler(checkSql, (cmd) =>
            {
                cmd.Parameters.AddWithValue("@username", username);
                var reader = cmd.ExecuteReader();
                isExist = reader.Read();
            });

            if (isExist)
            {
                MessageBox.Show("该用户名已经被注册！");
                return;
            }

            // 3.插入注册数据
            string insertSql = @"INSERT INTO user(username,password,age,gender,banji,create_at) 
                                 VALUES(@username,@password,@age,@gender,@banji,@create_at)";

            MySql.ConAndHandler(insertSql, (cmd) =>
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@banji", banji);
                cmd.Parameters.AddWithValue("@create_at", DateTime.Now);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("注册成功！可以去登录了");
                    this.Close(); //注册成功关闭注册窗口
                }
                else
                {
                    MessageBox.Show("注册失败！");
                }
            });
        }
    }
}
