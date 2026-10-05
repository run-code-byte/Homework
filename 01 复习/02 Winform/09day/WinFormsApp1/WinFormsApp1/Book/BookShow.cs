using AntdUI;
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
    public partial class BookShow : Form
    {
        private Mysql Mysql { get; set; } = new Mysql("test");

        public BookShow()
        {
            InitializeComponent();
            ShowData();
            table1.CellClick += Table1_CellClick;


        }

        private void Table1_CellClick(object sender, TableClickEventArgs e)
        {
            //MessageBox.Show(e.ColumnIndex.ToString());
            //MessageBox.Show(e.RowIndex.ToString());
            //MessageBox.Show(e.Column.Key.ToString());
            //System.Data.DataRow Book = e.Record as System.Data.DataRow;
            //MessageBox.Show(Book["name"].ToString());
            //MessageBox.Show(Book[1].ToString());

            System.Data.DataRow Book = e.Record as System.Data.DataRow;
            DialogResult res = MessageBox.Show("编辑还是删除？\n是=编辑\n否=删除", "编辑删除", MessageBoxButtons.YesNoCancel);
            if(res== DialogResult.Yes)
            {
                BookAddAndEdit BE = new BookAddAndEdit("编辑", Book["id"].ToString());
                BE.Show();
                this.Hide();
                BE.FormClosing += (object sender, FormClosingEventArgs args) =>
                {
                    this.Show();
                    ShowData();
                };
            }
            else if(res == DialogResult.No)
            {
                Del(Book["id"].ToString());
            }

        }
        private void Del(string id)
        {
            Mysql.ConAndHandler("delete from book where id=@id", Cmd =>
            {
                Cmd.Parameters.AddWithValue("@id", id);
                int res = Cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    MessageBox.Show("删除成功");
                    ShowData();
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            });
        }


        private void ShowData()
        {
            Mysql.ConAndHandler("select * from book", Cmd =>
            {
                MySqlDataAdapter Ada = new MySqlDataAdapter(Cmd);
                DataTable dt = new DataTable();
                Ada.Fill(dt);
                table1.DataSource = dt;
                SetColumn();
            });
        }
        private void SetColumn()
        {
            table1.Columns.Clear();
            table1.Bordered = true;
            table1.Radius = 4;
            table1.Columns = new AntdUI.ColumnCollection()
            {
                new AntdUI.Column("id", "编号")
                {
                    Render=(object val,object cel,int rowindex)=>rowindex+1
                },
                new AntdUI.Column("name","书名"),
                new AntdUI.Column("author","作者"),
                new AntdUI.Column("price","价格"),
                new AntdUI.Column("label","标签"),
                new AntdUI.Column("is_borrow","借阅") {
                    Render=(object val,object cel,int index)=>val.ToString()=="1"?"已借阅":"在书架"
                },
            };
            var HandlerCol = new AntdUI.Column("handler", "操作");
            HandlerCol.Render = (object val, object cel, int index) => "删除|编辑";
            table1.Columns.Add(HandlerCol);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookAddAndEdit BA = new BookAddAndEdit("新增");
            BA.Show();
            this.Hide();
            BA.FormClosing += BA_FormClosing;
        }

        private void BA_FormClosing(object? sender, FormClosingEventArgs e)
        {
            this.Show();
            ShowData();
        }
    }
}
