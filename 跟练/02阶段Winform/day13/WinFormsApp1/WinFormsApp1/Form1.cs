namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 999;
            Console.WriteLine(i);
            label1.Text = "66666";

            Thread th = new Thread(test);
            th.Start();
        }

        private void test()
        {
            //label1.Text = "哈哈哈";
            label1.Invoke(() => { label1.Text = "哈哈哈"; });
        }
    }
}
