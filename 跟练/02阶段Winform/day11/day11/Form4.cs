using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace day11
{
    public partial class Form4 : Form
    {
        private BindingList<Book> books { get; set; } = new BindingList<Book>();
        public Form4()
        {
            InitializeComponent();

            books.Add(new Book(1, "三国", 99.9, true));
            books.Add(new Book(2, "西游记", 88.8, false));
            books.Add(new Book(3, "水浒传", 77.7, true));
            books.Add(new Book(4, "红楼梦", 66.6, false));

            dataGridView1.DataSource = books;

            dataGridView1.AllowUserToAddRows = true;
            //dataGridView1.AllowUserToDeleteRows = false;
            //dataGridView1.AllowUserToResizeColumns = false;
            //dataGridView1.AllowUserToResizeRows = false;
            //dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //dataGridView1.MultiSelect = false;
            //dataGridView1.ReadOnly = true;
            //dataGridView1.ColumnHeadersVisible = false;
            //dataGridView1.RowHeadersVisible = false;

            //dataGridView1.Columns[1].Visible = false;
            //dataGridView1.Columns["Price"].Visible = false;
            //dataGridView1.Columns["Price"].Width = 250;

            //dataGridView1.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.AllCells;

            //dataGridView1.Columns.Remove("Id");

            //DataGridViewButtonColumn ColBtn=new DataGridViewButtonColumn();
            //ColBtn.Name = "opt";
            //ColBtn.HeaderText = "操作";
            //ColBtn.Text= "删除";
            //ColBtn.UseColumnTextForButtonValue = true;
            //dataGridView1 .Columns.Add(ColBtn);

            //dataGridView1.Rows.Add();

            //dataGridView1.Rows.Clear();
            //dataGridView1.Rows.RemoveAt(2);




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

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Add("Id", "编号");
            dataGridView1.Columns.Add("Name", "名字");
            dataGridView1.Columns.Add("Price", "价格");

            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add("三国", 12.3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //object val=dataGridView1.Rows[0].Cells[1].Value;
            //MessageBox.Show(val.ToString());
            dataGridView1.Rows[0].Cells[1].Value = "东汉末年";
        }
    }
}
