using MySqlConnector;
using System.Data;

namespace WinFormsApp1
{

    public partial class Form1 : Form
    {
        private string ConStr = "server=127.0.0.1;port=3306;database=test;uid=root;password=root;charset=utf8";

        public Form1()
        {
            InitializeComponent();
            using (MySqlConnection Conn = new MySqlConnection(ConStr))
            {
                Conn.Open();
                string Sql = "select * from user";
                using (MySqlCommand Comm = new MySqlCommand(Sql, Conn))
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
            using (MySqlConnection Conn = new MySqlConnection(ConStr))
            {
                Conn.Open();
                //string Sql = "select * from user where username = @username";
                //string Sql = $"select * from user where username like '%{str}%'";
                string Sql = "select * from user where username like CONCAT('%', @username, '%')";
                using (MySqlCommand Comm = new MySqlCommand(Sql, Conn))
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
            using (MySqlConnection Conn = new MySqlConnection(ConStr))
            {
                Conn.Open();

                //string Sql = "delete from user where username = @username";
                //string Sql = "update user set gender = @gender,age=@age where id = @id";
                //string Sql = "insert into user (username, gender, age,banji,password) values (@username, @gender, @age, @banji, @password)";
                string Sql = "update user set gender = '男',age=age+1 where id = 1";

                using (MySqlCommand Comm = new MySqlCommand(Sql, Conn))
                {
                    Comm.Parameters.AddWithValue("@username", "李四");
                    Comm.Parameters.AddWithValue("@gender", "女");
                    Comm.Parameters.AddWithValue("@age", 18);
                    Comm.Parameters.AddWithValue("@banji", "01班");
                    Comm.Parameters.AddWithValue("@password", "123456");


                    int row = Comm.ExecuteNonQuery();
                    if (row > 0)
                    {
                        MessageBox.Show("成功");
                    }
                    else
                    {
                        MessageBox.Show("失败");
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (MySqlConnection Conn = new MySqlConnection(ConStr))
            {
                Conn.Open();

                //string Sql = "select count(*) from user";
                //string Sql = "select * from user";
                string Sql = "select * from user where id = 1";

                using (MySqlCommand Comm = new MySqlCommand(Sql, Conn))
                {

                    // Comm.Parameters.AddWithValue("@password", "123456");


                    // object res = Comm.ExecuteScalar();
                    //label1.Text = res.ToString();

                    MySqlDataReader Reader = Comm.ExecuteReader();
                    //label1.Text = Reader.FieldCount.ToString();
                    //label1.Text = Reader.HasRows.ToString();

                    bool isRow = Reader.Read();
                    //label1.Text = isRow.ToString();

                    //label1.Text = Reader.GetInt32(3).ToString();
                    //label1.Text = Reader.GetString("banji");
                    label1.Text = Reader.GetDateTime("create_at").ToString();
                }
            }
        }
    }
}
