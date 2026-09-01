using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace day04_homework
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            button4 = new Button();
            textBox2 = new TextBox();
            button3 = new Button();
            label8 = new Label();
            label7 = new Label();
            button2 = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            totalLab = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.Controls.Add(button4, 4, 2);
            tableLayoutPanel1.Controls.Add(textBox2, 3, 2);
            tableLayoutPanel1.Controls.Add(button3, 2, 2);
            tableLayoutPanel1.Controls.Add(label8, 1, 2);
            tableLayoutPanel1.Controls.Add(label7, 0, 2);
            tableLayoutPanel1.Controls.Add(button2, 4, 1);
            tableLayoutPanel1.Controls.Add(label6, 1, 1);
            tableLayoutPanel1.Controls.Add(label5, 0, 1);
            tableLayoutPanel1.Controls.Add(label4, 2, 0);
            tableLayoutPanel1.Controls.Add(label3, 1, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(button1, 2, 1);
            tableLayoutPanel1.Controls.Add(textBox1, 3, 1);
            tableLayoutPanel1.Location = new Point(102, 41);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(540, 102);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // button4
            // 
            button4.BackColor = Color.White;
            button4.Dock = DockStyle.Fill;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(462, 69);
            button4.Name = "button4";
            button4.Size = new Size(75, 30);
            button4.TabIndex = 12;
            button4.Text = "+";
            button4.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            textBox2.Dock = DockStyle.Fill;
            textBox2.Location = new Point(246, 69);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(210, 30);
            textBox2.TabIndex = 11;
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // button3
            // 
            button3.BackColor = Color.White;
            button3.Dock = DockStyle.Fill;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(165, 69);
            button3.Name = "button3";
            button3.Size = new Size(75, 30);
            button3.TabIndex = 10;
            button3.Text = "-";
            button3.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Fill;
            label8.Location = new Point(111, 66);
            label8.Name = "label8";
            label8.Size = new Size(48, 36);
            label8.TabIndex = 9;
            label8.Text = "5";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Location = new Point(3, 66);
            label7.Name = "label7";
            label7.Size = new Size(102, 36);
            label7.TabIndex = 8;
            label7.Text = "鸡蛋";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Dock = DockStyle.Fill;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(462, 36);
            button2.Name = "button2";
            button2.Size = new Size(75, 27);
            button2.TabIndex = 7;
            button2.Text = "+";
            button2.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(111, 33);
            label6.Name = "label6";
            label6.Size = new Size(48, 33);
            label6.TabIndex = 4;
            label6.Text = "3";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(3, 33);
            label5.Name = "label5";
            label5.Size = new Size(102, 33);
            label5.TabIndex = 3;
            label5.Text = "西红柿";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label4, 3);
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(165, 0);
            label4.Name = "label4";
            label4.Size = new Size(372, 33);
            label4.TabIndex = 2;
            label4.Text = "数量";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(111, 0);
            label3.Name = "label3";
            label3.Size = new Size(48, 33);
            label3.TabIndex = 1;
            label3.Text = "单价";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(102, 33);
            label2.TabIndex = 0;
            label2.Text = "商品名称";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Dock = DockStyle.Fill;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(165, 36);
            button1.Name = "button1";
            button1.Size = new Size(75, 27);
            button1.TabIndex = 5;
            button1.Text = "-";
            button1.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(246, 36);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(210, 27);
            textBox1.TabIndex = 6;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(86, 268);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 1;
            label1.Text = "总计：";
            // 
            // totalLab
            // 
            totalLab.AutoSize = true;
            totalLab.Location = new Point(143, 268);
            totalLab.Name = "totalLab";
            totalLab.Size = new Size(0, 20);
            totalLab.TabIndex = 2;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(totalLab);
            Controls.Add(label1);
            Controls.Add(tableLayoutPanel1);
            Name = "Form5";
            Text = "Form5";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label totalLab;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button button1;
        private Button button4;
        private TextBox textBox2;
        private Button button3;
        private Label label8;
        private Label label7;
        private Button button2;
        private TextBox textBox1;
    }
}