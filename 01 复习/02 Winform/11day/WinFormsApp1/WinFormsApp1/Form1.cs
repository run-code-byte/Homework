namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Book Book = new Book(1, "三国", 1.20, true);
        public Form1()
        {
            InitializeComponent();
            textBox1.DataBindings.Add("Text", Book, "Name");
            label1.DataBindings.Add("Text", Book, "Id", true, DataSourceUpdateMode.OnPropertyChanged);
            checkBox1.DataBindings.Add("Checked", Book, "IsBorrow");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Book.Name);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Book.Name = "西游";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Book.Id.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Book.Id = 2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = "666";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Book.IsBorrow.ToString());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Book.IsBorrow = !Book.IsBorrow;
        }
    }
}
