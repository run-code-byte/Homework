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
            Mysql.ConAndHandler("select * from book", Cmd =>
            {
                object res =  Cmd.ExecuteScalar();
                MessageBox.Show(res.ToString());
            });

        }
    }
}
