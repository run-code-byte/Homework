using WinFormsApp1.Book;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookShow BS = new BookShow();
            BS.Show();
            this.Hide();
            BS.FormClosing += BS_FormClosing;
        }

        private void BS_FormClosing(object? sender, FormClosingEventArgs e)
        {
            this.Show();
        }
    }
}
