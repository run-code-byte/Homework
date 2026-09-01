using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySqlConnector;

namespace day08
{
    public partial class Form3 : Form
    {
        private string ConnStr = "server=127.0.0.1;port=3306;uid=root;password=root;database=test;charset=utf-8";

        public Form3()
        {
            InitializeComponent();
            using (MySqlConnection conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                string Sql = "select * from user";
                using (MySqlCommand Comm = new MySqlCommand(Sql, conn))
                {
                    MySqlDataAdapter Ada = new MySqlDataAdapter(Comm);
                    DataTable dt = new DataTable();
                    Ada.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            using (MySqlConnection conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                //string Sql = "select * from user where username=@username";
                //string Sql = $"select * from user where username like '%{str}%'";
                string Sql = $"select * from user where username like CONCAT('%', @username, '%')";
                using (MySqlCommand Comm = new MySqlCommand(Sql, conn))
                {
                    Comm.Parameters.AddWithValue("@username", str);
                    MySqlDataAdapter Ada = new MySqlDataAdapter(Comm);
                    DataTable dt = new DataTable();
                    Ada.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnStr))
            {
                conn.Open();

                //string Sql = "delete from user where username=@username";
                //string Sql = "update user set gender=@gender,age=@age,username=@username where id=@id";
                //string Sql = "insert into user (gender, age, username,banji,password) values (@gender, @age, @username, @banji, @password)";
                string Sql = "update user set gender='男',age=age+1 where id=1";

                using (MySqlCommand Comm = new MySqlCommand(Sql, conn))
                {
                    //Comm.Parameters.AddWithValue("@gender", "女");
                    //Comm.Parameters.AddWithValue("@age", 18);
                    //Comm.Parameters.AddWithValue("@username", "晓燕");
                    //Comm.Parameters.AddWithValue("@banji", "02班");
                    //Comm.Parameters.AddWithValue("@password", "123456");
                    int row=Comm.ExecuteNonQuery();
                    if(row > 0)
                    {
                        MessageBox.Show("插入成功");
                    }
                    else
                    {
                        MessageBox.Show("插入失败");
                    }
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                //string Sql = "select count(*) from user";
                string Sql = "select * from user where id=1";

                using (MySqlCommand Comm = new MySqlCommand(Sql, conn))
                {
                   
                    //Comm.Parameters.AddWithValue("@password", "123456");
                   //object res = Comm.ExecuteScalar();
                   //label1.Text=res.ToString();
                   MySqlDataReader reader = Comm.ExecuteReader();
                   //label1.Text=reader.HasRows.ToString();

                    bool isRow=reader.Read();
                    //label1.Text= isRow.ToString();

                    //label1.Text = reader.GetInt32(3).ToString();
                    label1.Text = reader.GetString("banji");
                }
            }
        }
    }
}
