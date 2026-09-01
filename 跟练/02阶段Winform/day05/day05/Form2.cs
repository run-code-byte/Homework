using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace day05
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            PriceCb.Items.AddRange(["升序", "降序"]);
            TimeCb.Items.AddRange(["升序", "降序"]);

            PriceCb.SelectedIndexChanged += Cchange;
            TimeCb.SelectedIndexChanged += Cchange;
        }

        private void Cchange(object sender, EventArgs e)
        {
            ComboBox cb = (sender as ComboBox);
            if (cb.Name == "PriceCb")
            {
                if(cb.SelectedItem == "升序" ) {
                    MessageBox.Show("按价格升序排序");
                }
                else if(cb.SelectedItem == "降序")
                {
                    MessageBox.Show("按价格降序排序");
                }
            }
            else if(cb.Name == "TimeCb")
            {
                if(cb.SelectedItem == "升序")
                {
                    MessageBox.Show("按上架时间升序排序");
                }
                else if (cb.SelectedItem == "降序")
                {
                    MessageBox.Show("按上架时间降序排序");
                }
            }
        }
    }
}
