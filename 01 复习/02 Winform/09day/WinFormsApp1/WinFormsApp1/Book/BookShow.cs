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
        private Mysql Mysql { get; set; }

        public BookShow()
        {
            InitializeComponent();
            Mysql = new Mysql("test");
            ShowData();



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
                    Render=(object val,object cel,int index)=>index+1
                },
                new AntdUI.Column("name","书名"),
                new AntdUI.Column("author","作者"),
                new AntdUI.Column("price","价格"),
                new AntdUI.Column("label","标签"),
                new AntdUI.Column("is_borrow","借阅") {
                    Render=(object val,object cel,int index)=>val.ToString()=="1"?"已借阅":"在书架"
                },
            };
        }
    }
}
