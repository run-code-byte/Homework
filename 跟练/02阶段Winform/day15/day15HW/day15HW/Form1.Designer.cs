namespace day15HW
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            panel2 = new Panel();
            button3 = new Button();
            button4 = new Button();
            label4 = new Label();
            panel3 = new Panel();
            label6 = new Label();
            panel5 = new Panel();
            label7 = new Label();
            button5 = new Button();
            textBox1 = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            label3 = new Label();
            label5 = new Label();
            label8 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(8, 64);
            panel1.Margin = new Padding(6, 5, 6, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(317, 239);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(315, 50);
            label1.TabIndex = 0;
            label1.Text = "连接控制区";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.BackColor = Color.LimeGreen;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(6, 82);
            button1.Margin = new Padding(6, 5, 6, 5);
            button1.Name = "button1";
            button1.Size = new Size(137, 42);
            button1.TabIndex = 1;
            button1.Text = "连接PLC";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.LimeGreen;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(166, 82);
            button2.Margin = new Padding(6, 5, 6, 5);
            button2.Name = "button2";
            button2.Size = new Size(142, 42);
            button2.TabIndex = 1;
            button2.Text = "连接PLC";
            button2.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Location = new Point(24, 157);
            label2.Name = "label2";
            label2.Size = new Size(241, 43);
            label2.TabIndex = 2;
            label2.Text = "当前状态：未连接";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(657, 64);
            panel2.Margin = new Padding(6, 5, 6, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(319, 239);
            panel2.TabIndex = 0;
            // 
            // button3
            // 
            button3.BackColor = Color.LimeGreen;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(166, 82);
            button3.Margin = new Padding(6, 5, 6, 5);
            button3.Name = "button3";
            button3.Size = new Size(142, 42);
            button3.TabIndex = 1;
            button3.Text = "停止";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.LimeGreen;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(6, 82);
            button4.Margin = new Padding(6, 5, 6, 5);
            button4.Name = "button4";
            button4.Size = new Size(137, 42);
            button4.TabIndex = 1;
            button4.Text = "启动";
            button4.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Dock = DockStyle.Top;
            label4.Location = new Point(0, 0);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(317, 50);
            label4.TabIndex = 0;
            label4.Text = "设备控制区";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label6);
            panel3.Location = new Point(331, 65);
            panel3.Margin = new Padding(6, 5, 6, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(319, 238);
            panel3.TabIndex = 0;
            // 
            // label6
            // 
            label6.BorderStyle = BorderStyle.FixedSingle;
            label6.Dock = DockStyle.Top;
            label6.Location = new Point(0, 0);
            label6.Margin = new Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new Size(317, 49);
            label6.TabIndex = 0;
            label6.Text = "监控画面区";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(label7);
            panel5.Location = new Point(497, 313);
            panel5.Margin = new Padding(6, 5, 6, 5);
            panel5.Name = "panel5";
            panel5.Size = new Size(479, 238);
            panel5.TabIndex = 0;
            // 
            // label7
            // 
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Dock = DockStyle.Top;
            label7.Location = new Point(0, 0);
            label7.Margin = new Padding(6, 0, 6, 0);
            label7.Name = "label7";
            label7.Size = new Size(477, 49);
            label7.TabIndex = 0;
            label7.Text = "日志输出区";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button5
            // 
            button5.BackColor = Color.LimeGreen;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Location = new Point(166, 190);
            button5.Margin = new Padding(6, 5, 6, 5);
            button5.Name = "button5";
            button5.Size = new Size(137, 42);
            button5.TabIndex = 1;
            button5.Text = "设定温度";
            button5.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 147);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "请输入设定温度";
            textBox1.Size = new Size(294, 35);
            textBox1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.727272F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.727272F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.727272F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.818182F));
            tableLayoutPanel1.Controls.Add(label3, 0, 0);
            tableLayoutPanel1.Controls.Add(label5, 3, 0);
            tableLayoutPanel1.Location = new Point(9, 313);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.Size = new Size(480, 238);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            tableLayoutPanel1.SetColumnSpan(label3, 3);
            label3.Location = new Point(4, 1);
            label3.Name = "label3";
            label3.Size = new Size(317, 38);
            label3.TabIndex = 0;
            label3.Text = "数据记录区";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("微软雅黑", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label5.Location = new Point(328, 1);
            label5.Name = "label5";
            label5.Size = new Size(148, 38);
            label5.TabIndex = 1;
            label5.Text = "查看历史记录";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.BorderStyle = BorderStyle.FixedSingle;
            label8.Font = new Font("微软雅黑", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label8.Location = new Point(344, 9);
            label8.Name = "label8";
            label8.Size = new Size(306, 51);
            label8.TabIndex = 1;
            label8.Text = "温控设备监控主界面";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(label8);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel5);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("微软雅黑", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 134);
            Margin = new Padding(6, 5, 6, 5);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel5.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Label label1;
        private Label label2;
        private Button button2;
        private Panel panel2;
        private Button button3;
        private Button button4;
        private Label label4;
        private Panel panel3;
        private Label label6;
        private Panel panel5;
        private Label label7;
        private TextBox textBox1;
        private Button button5;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label3;
        private Label label5;
        private Label label8;
    }
}
