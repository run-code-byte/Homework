using AntdUI;
using MySqlConnector;
using System;
using System.Data;
using System.Windows.Forms;

namespace day09.Book
{
    public partial class BookShow : Form
    {
        MySql MySql { get; set; } = new MySql("test");
        private int _colHandlerIndex;    //编辑删除列下标
        private int _colBorrowIndex;     //借阅操作列下标

        public BookShow()
        {
            InitializeComponent();
            ShowData();
            table1.CellClick += Table1_CellClick;
        }

        private void Table1_CellClick(object sender, TableClickEventArgs e)
        {
            DataRow Book = e.Record as DataRow;
            if (Book == null) return;

            //✅正确字段 ColumnIndex
            if (e.ColumnIndex == _colHandlerIndex)
            {
                DialogResult res = MessageBox.Show("编辑还是删除？\n是-编辑\n否-删除", "删除编辑", MessageBoxButtons.YesNoCancel);
                if (res == DialogResult.Yes)
                {
                    BookAddAndEdit BE = new BookAddAndEdit("编辑", Book["id"].ToString());
                    BE.ShowDialog();
                    ShowData();
                }
                else if (res == DialogResult.No)
                {
                    Del(Book["id"].ToString());
                }
            }
            else if (e.ColumnIndex == _colBorrowIndex)
            {
                string isBorrow = Book["is_borrow"].ToString();
                int bookId = Convert.ToInt32(Book["id"]);

                if (isBorrow == "2")
                {
                    var ok = MessageBox.Show("确认借阅这本书？", "借阅", MessageBoxButtons.YesNo);
                    if (ok == DialogResult.Yes)
                    {
                        BorrowOrReturn(bookId, "1");
                    }
                }
                else
                {
                    var ok = MessageBox.Show("确认归还这本书？", "归还", MessageBoxButtons.YesNo);
                    if (ok == DialogResult.Yes)
                    {
                        BorrowOrReturn(bookId, "2");
                    }
                }
            }
        }

        /// <summary>
        /// status："1"已借阅，"2"在书架
        /// </summary>
        private void BorrowOrReturn(int bookId, string status)
        {
            string sql = "update book set is_borrow=@status where id=@id";
            MySql.ConAndHandler(sql, (cmd) =>
            {
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", bookId);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    string msg = status == "1" ? "借阅成功" : "归还成功";
                    MessageBox.Show(msg);
                    ShowData();
                }
                else
                {
                    MessageBox.Show("操作失败");
                }
            });
        }

        private void Del(string id)
        {
            string sql = "delete from book where id=@id";
            MySql.ConAndHandler(sql, (cmd) =>
            {
                cmd.Parameters.AddWithValue("@id", id);
                int res = cmd.ExecuteNonQuery();
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
            MySql.ConAndHandler("select * from book", (cmd) =>
            {
                MySqlDataAdapter Ada = new MySqlDataAdapter(cmd);
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
                new AntdUI.Column( "id", "编号")
                {
                    Render = (object val,object cel,int index)=>index+1
                },
                new AntdUI.Column( "name",  "书名"),
                new AntdUI.Column( "author",  "作者"),
                new AntdUI.Column( "price",  "价格"),
                new AntdUI.Column( "lable",  "标签"),
                new AntdUI.Column( "is_borrow", "借阅状态")
                {
                    Render = (object val,object cel,int index)=> val.ToString()=="2" ? "在书架" : "已借阅"
                },
            };

            //操作1：编辑删除
            Column HandlerCol = new AntdUI.Column("", "操作");
            HandlerCol.Render = (object val, object cel, int index) => "编辑 | 删除";
            table1.Columns.Add(HandlerCol);
            _colHandlerIndex = table1.Columns.Count - 1;

            //操作2：借阅归还
            var BorrowCol = new AntdUI.Column("", "借阅操作");
            BorrowCol.Render = (object val, object cel, int index) =>
            {
                DataRow row = cel as DataRow;
                string st = row["is_borrow"].ToString();
                return st == "2" ? "📖借阅" : "🔄归还";
            };
            table1.Columns.Add(BorrowCol);
            _colBorrowIndex = table1.Columns.Count - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookAddAndEdit BA = new BookAddAndEdit("新增");
            BA.ShowDialog();
            ShowData();
        }
    }
}
