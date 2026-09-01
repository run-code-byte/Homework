using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace book.Book
{
    public partial class BookEdit : Form
    {
        public BookEdit()
        {
            InitializeComponent();
        }
        public BookEdit(string id)
        {
            InitializeComponent();
            // 根据id查找数据
            //MessageBox.Show(id); 
            // 回显  ====> 根据id 查找到 对应的书籍数据 ==> 显示在界面中(界面使用UCBook)
            //  编辑按钮, 修改
        }
    }
}
