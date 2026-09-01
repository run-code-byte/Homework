using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace day06.myControl
{
    public partial class UCText : UserControl
    {
        public UCText()
        {
            InitializeComponent();
        }

        public UCText(string BookName, string AuthoName, string IntroContent)
        {
            InitializeComponent();
            BookLab.Text = BookName;
            AuthoLab.Text = AuthoName;
            IntroLab.Text = IntroContent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookLab.ForeColor = Color.Red;
        }
        public string BookName
        {
            get
            {
                return BookLab.Text;
            }
            set
            {
                BookLab.Text = value;
            }
        }
        public string AuthoName
        {
            get
            {
                return AuthoLab.Text;
            }
            set
            {
                AuthoLab.Text = value;
            }
        }
        public string IntroContent
        {
            get
            {
                return IntroLab.Text;
            }
            set
            {
                IntroLab.Text = value;
            }
        }
    }
}
