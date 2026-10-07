using WinFormsApp1.Book;


namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private string Mark { get; set; }
        public Form1()
        {
            InitializeComponent();
            AntdUI.Config.ShowInWindow = true;

            状态ToolStripMenuItem.Text = "未登录";
            退出ToolStripMenuItem.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (状态ToolStripMenuItem.Text == "已登录")
            {
                BookShow BS = new BookShow();
                BS.Show();
                this.Hide();
                BS.FormClosing += BS_FormClosing;
            }
            else
            {
                //Login lg = new Login();
                //lg.Show();
                //lg.LoginMark += Lg_LoginMark;
                //this.Hide();
                //lg.FormClosing += (object? sender, FormClosingEventArgs e) => this.Show();
                AntdUI.Message.warn(this,"未登录，请点击左上角登录！",autoClose:1);
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

        private void BS_FormClosing(object? sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void 登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            lg.LoginMark += Lg_LoginMark;
            this.Hide();
            lg.FormClosing += (object? sender, FormClosingEventArgs e) => this.Show();
        }

        private void 注册ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Register rg = new Register();
            rg.Show();
            this.Hide();
            rg.FormClosing += (object sender, FormClosingEventArgs e) => this.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            状态ToolStripMenuItem.Text = "未登录";
            登录ToolStripMenuItem.Visible =true;
            退出ToolStripMenuItem.Visible = false;
        }
    }
}
