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
            


        }

        private void Table1_CellButtonClick(object sender, TableButtonEventArgs e)
        {
            System.Data.DataRow Book = e.Record as System.Data.DataRow;
            //MessageBox.Show(Book["name"].ToString());
            //MessageBox.Show(e.Btn.ToString());
            if (e.Btn.Text == "编辑")
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
            else if (e.Btn.Text == "删除")
            {
                Del(Book["id"].ToString());
            }
            else if (e.Btn.Text == "借书"|| e.Btn.Text == "还书")
            {
                BorrowAndReturn(e.Btn.Text, Book["id"].ToString(), Book["is_borrow"].ToString());
            }
           

        }
        private async void BorrowAndReturn(string opt,string id,string state)
        {
            if(opt== "借书" && state == "1")
            {
                MessageBox.Show("书已借出");
                return;
            }
            else if (opt == "还书" && state == "2")
            {
                MessageBox.Show("书在书架");
                return;
            }

            string sql = "update book set is_borrow=@is_borrow where id=@id";
            await Mysql.ConAndHandler(sql, Cmd =>
            {
                Cmd.Parameters.AddWithValue("@id", id);
                string isBorrow = state == "1" ? "2" : "1";
                Cmd.Parameters.AddWithValue("@is_borrow", isBorrow);
                int res = Cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    MessageBox.Show(opt + "成功");
                    ShowData();
                }
                else
                {
                    MessageBox.Show(opt + "失败");
                }
                return true;
            });

            //string sql = opt == "借书" ? "update book set is_borrow=1 where id=@id" : "update book set is_borrow=0 where id=@id";
            //Mysql.ConAndHandler(sql, Cmd =>
            //{
            //    Cmd.Parameters.AddWithValue("@id", id);
            //    int res = Cmd.ExecuteNonQuery();
            //    if (res > 0)
            //    {
            //        MessageBox.Show(opt + "成功");
            //        ShowData();
            //    }
            //    else
            //    {
            //        MessageBox.Show(opt + "失败");
            //    }
            //});
        }

        private void Table1_CellClick(object sender, TableClickEventArgs e)
        {
            //MessageBox.Show(e.ColumnIndex.ToString());
            //MessageBox.Show(e.RowIndex.ToString());
            //MessageBox.Show(e.Column.Key.ToString());
            //System.Data.DataRow Book = e.Record as System.Data.DataRow;
            //MessageBox.Show(Book["name"].ToString());
            //MessageBox.Show(Book[1].ToString());

            if (e.RowIndex == 0 || e.Column.Key != "handler1") return;

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
        private async void Del(string id)
        {
            DialogResult res = MessageBox.Show("确定要删除吗？", "删除操作", MessageBoxButtons.YesNo);
            if (res != DialogResult.Yes) return;

            await Mysql.ConAndHandler("delete from book where id=@id", Cmd =>
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
                return true;
            });
        }


        private async void ShowData()
        {
            await Mysql.ConAndHandler("select * from book", Cmd =>
            {
                MySqlDataAdapter Ada = new MySqlDataAdapter(Cmd);
                DataTable dt = new DataTable();
                Ada.Fill(dt);
                table1.DataSource = dt;
                SetColumn();
                table1.CellClick += Table1_CellClick;
                table1.CellButtonClick += Table1_CellButtonClick;
                return true;
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

            var HandlerCol1 = new AntdUI.Column("handler1", "操作");
            HandlerCol1.SetAlign();
            HandlerCol1.Render = (object val, object cel, int index) =>"编辑|删除";
            table1.Columns.Add(HandlerCol1);

            var HandlerCol = new AntdUI.Column("handler", "操作");
            HandlerCol.SetAlign();
            HandlerCol.Render = (object val, object cel, int index) =>
            {
                var _btns = new AntdUI.CellLink[] {
                    new AntdUI.CellButton("edit", "编辑", AntdUI.TTypeMini.Default),
                    new AntdUI.CellButton("delete", "删除", AntdUI.TTypeMini.Default)
                };
                return _btns;
            };
            table1.Columns.Add(HandlerCol);

            var RetHandlerCol = new AntdUI.Column("resort", "借还书");
            RetHandlerCol.SetAlign();
            RetHandlerCol.Render = (object val, object cel, int index) =>
            {
                return new AntdUI.CellLink[] {
                    new AntdUI.CellButton("borrow", "借书", AntdUI.TTypeMini.Default),
                    new AntdUI.CellButton("return", "还书", AntdUI.TTypeMini.Default)
                };
            };
            table1.Columns.Add(RetHandlerCol);
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
