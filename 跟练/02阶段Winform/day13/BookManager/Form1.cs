using WinFormsApp1.Book;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }
        private string Mark { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Mark == "已登录")
            {
                // 跳转到图书展示界面
                BookShow BS = new Book.BookShow();
                BS.Show(); // 展示目标窗体
                this.Hide(); // 当前窗体隐藏
                BS.FormClosing += BS_FormClosing; // 目标窗体关闭前事件
            }
            else
            {
                Login lg = new Login();
                lg.Show();
                lg.LoginMark += Lg_LoginMark;
                this.Hide();
                lg.FormClosing += (object sender, FormClosingEventArgs e) => this.Show();
            }

        }

        private void Lg_LoginMark(string mark)
        {
            this.Mark = mark;
            label2.Text = mark;
        }

        private void BS_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }
    }
}
