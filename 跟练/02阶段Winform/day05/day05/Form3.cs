using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace day05
{
    public class BcColor
    {
        public string Name;
        public Color _Color;
        public BcColor(string Name, Color _Color) { 
            this.Name = Name;
            this._Color = _Color;
        }
    }
    public partial class Form3 : Form
    {
        private List<BcColor> ColorList = new ();
        public Form3()
        {
            InitializeComponent();
            ColorList.AddRange(
                new BcColor("红色", Color.Red),
                new BcColor("橙色", Color.Orange),
                new BcColor("黄色", Color.Yellow),
                new BcColor("绿色", Color.Green),
                new BcColor("青色", Color.Cyan),
                new BcColor("蓝色", Color.Blue),
                new BcColor("紫色", Color.Purple)
            );
            BackColorCb.Items.AddRange(ColorList.ConvertAll(x => x.Name).ToArray());
            BackColorCb.SelectedIndexChanged += Change;
        }

        private void Change(object sender, EventArgs e)
        {
            string name = (sender as ComboBox).SelectedItem.ToString();
            Color c = ColorList.Find(x => x.Name == name)._Color;
            this.BackColor = c;
        }
    }


}


