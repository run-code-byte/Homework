using AntdUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace book.Book
{
    public partial class BookShow : Form
    {
        public BookShow()
        {
            InitializeComponent();
            showBook();
        }
        private void showBook()
        {
            string JsonStr = File.ReadAllText("./book.json");
            List<BookInfo> books = JsonSerializer.Deserialize<List<BookInfo>>(JsonStr);
            table1.DataSource = books;

            // 重置表头
            table1.Columns.Clear();
            table1.Columns = new AntdUI.ColumnCollection {
                new AntdUI.Column("Id", "编号")
                {
                    Render = (object val,object cel,int index ) =>index.ToString()

                },
                new AntdUI.Column("Name", "书名"),
                new AntdUI.Column("Author", "作者"),
                new AntdUI.Column("Price", "价格"),
                new AntdUI.Column("BookLabel", "标签"),
                new AntdUI.Column("IsBorrow", "是否借阅"){
                    // val 单元的值, cel: 行数据, index 行号
                    Render = (object val,object cel,int index) =>
                    {
                        return (bool)val?"已借阅":"书架中";
                    }
                },
            };

            table1.Columns.Add(new AntdUI.Column("Handler", "操作")
            {
                Render = (object val, object cel, int index) => "删除"
            });
            table1.Columns.Add(new AntdUI.Column("Handler2", "操作")
            {
                Render = (object val, object cel, int index) => "编辑"
            });

            // 绑定事件
            table1.CellClick += Table1_CellClick;

        }

        private void Table1_CellClick(object sender, TableClickEventArgs e)
        {
            BookInfo book = (e.Record as BookInfo);            
            //MessageBox.Show(e.ColumnIndex.ToString());
            if(e.ColumnIndex.ToString() == "6")
            {
                // 删除
                return;
            }
            if (e.ColumnIndex.ToString() == "7")
            {
                // 编辑
                new BookEdit(book.Id).Show();
            }               
        }


        private void goEdit(string id)
        {

            new BookEdit(id).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new BookEdit().Show();
        }
    }
}
