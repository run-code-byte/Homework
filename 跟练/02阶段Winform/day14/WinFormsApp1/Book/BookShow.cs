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
        private Mysql MySql { get; set; } = new Mysql("test");
        public BookShow()
        {
            InitializeComponent();
            ShowData();// 调用图书展示方法                        
            table1.CellClick += Table1_CellClick; // 给表格单元绑定点击事件
            table1.CellButtonClick += Table1_CellButtonClick;
        }

        private void Table1_CellButtonClick(object sender, AntdUI.TableButtonEventArgs e)
        {
            // 表格按钮点击事件
            // e 事件参数对象
            // e.Record 获取对应行的数据
            // e.Btn 点击触发的按钮
            System.Data.DataRow Book = e.Record as System.Data.DataRow;
            //MessageBox.Show(Book["name"].ToString());
            //MessageBox.Show(e.Btn.Text);            
            if (e.Btn.Text == "编辑")
            {
                // 编辑===> 展示编辑窗体
                BookAddAndEdit BE = new BookAddAndEdit("编辑", Book["id"].ToString());
                BE.Show();
                this.Hide();
                BE.FormClosing += (object sender, FormClosingEventArgs e) =>
                {
                    this.Show();
                    ShowData();
                };
            }
            else if (e.Btn.Text == "删除")
            {
                // 删除
                Del(Book["id"].ToString());
            }
            else if (e.Btn.Text == "借书" || e.Btn.Text == "还书")
            {
                BorrowAndReturn(e.Btn.Text, Book["id"].ToString(), Book["is_borrow"].ToString()); // 借还书
            }


        }
        private async void BorrowAndReturn(string opt, string id, string state)
        {
            // 判断不能操作数据库的情况
            if (opt == "借书" && state == "1")
            {
                MessageBox.Show("书已借出");
                return;
            }
            if (opt == "还书" && state == "2")
            {
                MessageBox.Show("书在书架");
                return;
            }

            // 无论借书 还书 sql语句都一样
            string sql = "update book set is_borrow=@is_borrow where id = @id";
            await MySql.ConAndHandler(sql, Cmd =>
            {
                // 参数替换
                Cmd.Parameters.AddWithValue("@id", id);
                string isBorrow = state == "1" ? "2" : "1";//通过判断获取 要求改的 is_borrow的值
                Cmd.Parameters.AddWithValue("@is_borrow", isBorrow);

                int rows = Cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show(opt+"成功");
                    ShowData();
                }
                else
                {
                    MessageBox.Show(opt + "失败");
                }
                return true;

            });

        }
        private void Table1_CellClick(object sender, AntdUI.TableClickEventArgs e)
        {
            #region
            //TableClickEventArgs e
            //e.ColumnIndex 列下标
            //e.RowIndex 行下标
            //e.Column 列对象    key==> 列表名称           
            //e.Record 这一行数据
            // MessageBox.Show(e.ColumnIndex.ToString());
            //MessageBox.Show(e.RowIndex.ToString());
            //MessageBox.Show(e.Column.Key.ToString());
            //e.Record
            //System.Data.DataRow Book = e.Record as System.Data.DataRow;
            //MessageBox.Show(Book["name"].ToString());
            //MessageBox.Show(Book[1].ToString());
            #endregion


            if (e.RowIndex == 0 || e.Column.Key != "handler1") return;

            // 获取点击这一行的数据
            System.Data.DataRow Book = e.Record as System.Data.DataRow;
            DialogResult res = MessageBox.Show("编辑还是删除?\n是=编辑\n否=删除", "编辑删除", MessageBoxButtons.YesNoCancel);
            if (res == DialogResult.Yes)
            {
                // 编辑===> 展示编辑窗体
                BookAddAndEdit BE = new BookAddAndEdit("编辑", Book["id"].ToString());
                BE.Show();
                this.Hide();
                BE.FormClosing += (object sender, FormClosingEventArgs e) =>
                {
                    this.Show();
                    ShowData();
                };
            }
            else if (res == DialogResult.No)
            {
                // 删除
                Del(Book["id"].ToString());
            }
        }
        private async void Del(string id)
        {
            //DialogResult res = MessageBox.Show("确定要删除?", "删除操作", MessageBoxButtons.YesNo);
            DialogResult res = AntdUI.Modal.open(new AntdUI.Modal.Config(this, "删除提示", "你确定要删除吗?",AntdUI.TType.Warn) { 
                OkText="删除"
            });

            if (res == DialogResult.No) return;

            string sql = "delete from book where id=@id";
            await MySql.ConAndHandler(sql, Cmd =>
            {
                Cmd.Parameters.AddWithValue("@id", id);
                int row = Cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    MessageBox.Show("删除成功!!");
                    ShowData();
                }
                else
                {
                    MessageBox.Show("删除失败!!!");
                }
                return true;
            });
        }

        // 图书展示方法
        private async void ShowData()
        {
           await  MySql.ConAndHandler("select * from book", Cmd =>
            {
                MySqlDataAdapter Ada = new MySqlDataAdapter(Cmd);// 创建适配器
                DataTable dt = new DataTable();// 创建内存表
                Ada.Fill(dt);
                table1.DataSource = dt;
                SetColumn();               
                return true;
            });
        }

        // 设置表头
        private void SetColumn()
        {
            table1.Columns.Clear();// 先清除
            table1.Bordered = true;
            table1.Radius = 4;
            table1.Columns = new AntdUI.ColumnCollection()
            {
                new AntdUI.Column("id","编号"){
                    Render=(object val,object cel,int rowIndex )=> rowIndex+1
                },
                new AntdUI.Column("name","书名"),
                new AntdUI.Column("author","作者"),
                new AntdUI.Column("price","价格"),
                new AntdUI.Column("label","标签"),
                new AntdUI.Column("is_borrow","借阅"){
                    Render=(object val,object cel,int index )=> val.ToString()=="1"?"已借阅":"在书架"
                },
            };

            var HandlerCol1 = new AntdUI.Column("handler1", "操作");
            HandlerCol1.SetAlign();
            HandlerCol1.Render = (object val, object cel, int index) => "删除 | 编辑";
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
            // 显示新增界面
            BookAddAndEdit BA = new BookAddAndEdit("新增");
            BA.Show();
            this.Hide();
            BA.FormClosing += BA_FormClosing;
        }

        private void BA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
            ShowData();
        }
    }
}
