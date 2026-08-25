namespace day02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            initTab();
        }
        public string[] picArr = { @"./images/cat.jpg", @"./images/bird.jpg", @"./images/eagle.jpg" };

        public void initTab()
        {
            pictureBox1.Image = Image.FromFile(picArr[0]);
            panel1.Controls[0].BackColor = Color.Cyan;
            panel1.Controls[0].ForeColor = Color.White;

            for (int i = 0; i < panel1.Controls.Count; i++) {
                panel1.Controls[i].Click += btn_Click;
            }

        }
        public void btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                panel1.Controls[i].BackColor = Color.DarkGray;
                panel1.Controls[i].ForeColor = Color.Black;
            }
            Button btn = (Button)sender;
            panel1.Controls[0].BackColor = Color.Cyan;
            panel1.Controls[0].ForeColor = Color.White;

            int index = panel1.Controls.IndexOf(btn);
            pictureBox1.Image = Image.FromFile(picArr[index]);
        }
    }
}
