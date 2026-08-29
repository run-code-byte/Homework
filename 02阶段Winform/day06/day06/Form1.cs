namespace day06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.Shown += Form1_Shown;
            this.FormClosing += Form1_FormClosing;
            this.FormClosed += Form1_FormClosed;
            this.Resize += Form1_Resize;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            widthLab.Text=this.Width.ToString();
            heigthLab.Text=this.Height.ToString();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("窗体已经关闭了");

        }

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            //MessageBox.Show("要关闭了");
            //DialogResult res= MessageBox.Show("你真的要离开吗", "等等", MessageBoxButtons.OKCancel);
            //if (res == DialogResult.OK) {
            //    MessageBox.Show("你好狠心啊！");
            //}
            //else
            //{
            //    e.Cancel = true;

            //}
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //MessageBox.Show("你还看到窗体了！");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("你还看不到窗体！");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();

        }
    }
}
