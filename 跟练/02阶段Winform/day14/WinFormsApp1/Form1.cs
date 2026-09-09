using WinFormsApp1.Book;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            AntdUI.Config.ShowInWindow = true;
            if (Properties.Settings.Default.username != "" && Properties.Settings.Default.password != "")
            {
                // 初始化
                状态ToolStripMenuItem.Text = "已登录";
                登录ToolStripMenuItem.Visible= false;
                退出ToolStripMenuItem.Visible = true;
            }
            else
            {
                状态ToolStripMenuItem.Text = "未登录";
                登录ToolStripMenuItem.Visible = true;
                退出ToolStripMenuItem.Visible = false;
            }
                
        }
        private string Mark { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (状态ToolStripMenuItem.Text == "已登录")
            {
                // 跳转到图书展示界面
                BookShow BS = new Book.BookShow();
                BS.Show(); // 展示目标窗体
                this.Hide(); // 当前窗体隐藏
                BS.FormClosing += BS_FormClosing; // 目标窗体关闭前事件
            }
            else
            {
                // 未登录,提示点击左上角登录
                AntdUI.Message.warn(this, "未登录,点击左上角登录", autoClose: 1);
            }

        }

        private void Lg_LoginMark(string mark)
        {
            //this.Mark = mark;
            //label2.Text = mark;
            状态ToolStripMenuItem.Text = mark;
            if (mark == "已登录")
            {
                登录ToolStripMenuItem.Visible = false;
                退出ToolStripMenuItem.Visible = true;
            }
        }

        private void BS_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void 登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            lg.LoginMark += Lg_LoginMark;
            this.Hide();
            lg.FormClosing += (object sender, FormClosingEventArgs e) => this.Show();
        }

        private void 注册ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 跳转到图书展示界面
            Register Rg = new Book.Register();
            Rg.Show(); // 展示目标窗体
            this.Hide(); // 当前窗体隐藏
            Rg.FormClosing += BS_FormClosing; // 目标窗体关闭前事件
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            状态ToolStripMenuItem.Text = "未登录";
            登录ToolStripMenuItem.Visible = true;
            退出ToolStripMenuItem.Visible = false;

            Properties.Settings.Default.Reset();
        }
    }
}
