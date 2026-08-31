using NPOI.XSSF.UserModel;
using System.Drawing.Printing;

namespace day07
{
    public partial class Form1 : Form
    {
        public List<string> users = ["张三", "李四", "王五", "赵六", "孙七", "周八", "吴九", "小明", "小红", "小兰", "小刚", "丧彪"];
        public Form1()
        {
            InitializeComponent();
            users.ForEach(x =>
            {
                Label lab = new Label();
                {
                    Text = x;
                    BackColor = Color.White;
                    AutoSize = false;
                    Size = new Size(flowLayoutPanel1.Width, 20);
                    Margin = new Padding(0, 5, 0, 5);
                };
                
                lab.Click += Lab_Click;
                flowLayoutPanel1.Controls.Add(lab);

            });
            MiddleWare mw = MiddleWare.GetInstance();
            mw.AddMsg(101, getData);
        }
        private string data = "";

        private void Lab_Click(object sender, EventArgs e)
        {
            data = (sender as Label).Text;
            foreach (Label lab in flowLayoutPanel1.Controls) lab.BackColor = Color.White;
            (sender as Label)?.BackColor = Color.Yellow;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MiddleWare mw = MiddleWare.GetInstance();
            mw.CallMsg(101, data);
        }

        public List<string> getUsers = new List<string>();
        private void getData(object data) { 
            getUsers.Add(data.ToString());
            flowLayoutPanel2.Controls.Clear ();
            getUsers.ForEach(x =>
            {
                Label lab = new Label();
                {
                    Text = x;
                    BackColor = Color.White;
                    AutoSize = false;
                    Size = new Size(flowLayoutPanel1.Width, 20);
                    Margin = new Padding(0, 5, 0, 5);
                    //TextAlign = ContentAlignment.MiddleCenter;
                };
                flowLayoutPanel2.Controls.Add(lab);

            });
        }

        
    }
}
