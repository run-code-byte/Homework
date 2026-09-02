using day09.Book;

namespace day09
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
                BookShow BS = new BookShow();
                BS.Show();
                this.Hide();
                BS.FormClosing += BS_FormClosing;

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
