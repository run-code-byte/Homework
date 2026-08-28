using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace day05
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            AllCbox.CheckStateChanged += AllChanged;
            foreach (Control i in ChildPan.Controls) (i as CheckBox).CheckedChanged += ChildChanged;
            
        }

        private void ChildChanged(object sender, EventArgs e)
        {
            List<Control> childList = ChildPan.Controls.OfType<Control>().ToList();
            bool isAll=childList.All(i => (i as CheckBox).Checked);
            bool isAny=childList.Any(i => (i as CheckBox).Checked);
            if(isAll) AllCbox.CheckState = CheckState.Checked;
            else if (isAny) AllCbox.CheckState = CheckState.Indeterminate;
            else AllCbox.CheckState = CheckState.Unchecked;
        }

        private void AllChanged(object sender, EventArgs e)
        {
            bool isChecked = AllCbox.CheckState == CheckState.Checked;
            if(AllCbox.CheckState != CheckState.Indeterminate)
            {
                foreach (Control i in ChildPan.Controls) { 
                    (i as CheckBox).Checked = isChecked;
                }
            }
        }
    }
}
