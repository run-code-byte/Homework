using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class MyTcpServer : Form
    {
        public MyTcpServer()
        {
            InitializeComponent();
            this.Shown += TcpServerInit;
        }

        private void TcpServerInit(object sender, EventArgs e)
        {
            new MyTcpClient().Show();
            button1.Click += CreateServer;
        }

        private void CreateServer(object? sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int Port)|| Port < 0 || Port > 65535)
            {
                MessageBox.Show("请输入有效的端口号（0-65535）！");
                return;
            }
        }
    }
}
