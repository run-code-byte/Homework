using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        //private List<Book> books { get; set; } = new List<Book>();
        private BindingList<Book> books { get; set; } = new();
        public Form2()
        {
            InitializeComponent();
            books=new([
                 new Book(1, "三国", 12.20, true),
                new Book(2, "西游", 22.20, false),
                new Book(3, "水浒", 33.20, true),
                new Book(4, "红楼", 44.20, false)
            ]);
            dataGridView1.DataSource = books;
            //dataGridView1.AllowUserToAddRows = true;

            //dataGridView1.AllowUserToDeleteRows = false;

            //dataGridView1.AllowUserToResizeColumns = false;
            //dataGridView1.AllowUserToResizeRows = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ShowDataStr = "";
            foreach (var item in books)
            {
                ShowDataStr += $"书名：{item.Name};;书价：{item.Price}\n";
            }
            MessageBox.Show(ShowDataStr);
        }
    }
}
