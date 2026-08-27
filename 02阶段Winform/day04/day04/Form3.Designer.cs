namespace day04
{
    partial class Form3
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
            label1 = new Label();
            textBox1 = new TextBox();
            tipsLab = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            listBox1 = new ListBox();
            button1 = new Button();
            label3 = new Label();
            selectedLab = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 28);
            label1.Name = "label1";
            label1.Size = new Size(144, 20);
            label1.TabIndex = 0;
            label1.Text = "限制最大输入长度：";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(162, 25);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(278, 27);
            textBox1.TabIndex = 1;
            // 
            // tipsLab
            // 
            tipsLab.AutoSize = true;
            tipsLab.ForeColor = Color.Red;
            tipsLab.Location = new Point(465, 26);
            tipsLab.Name = "tipsLab";
            tipsLab.Size = new Size(129, 20);
            tipsLab.TabIndex = 2;
            tipsLab.Text = "已达最多输入长度";
            tipsLab.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 93);
            label2.Name = "label2";
            label2.Size = new Size(129, 20);
            label2.TabIndex = 3;
            label2.Text = "列表框数据过滤：";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(162, 93);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(306, 27);
            textBox2.TabIndex = 4;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(162, 126);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(306, 284);
            listBox1.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(517, 142);
            button1.Name = "button1";
            button1.Size = new Size(92, 34);
            button1.TabIndex = 6;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(103, 61);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 7;
            label3.Text = "选中项：";
            // 
            // selectedLab
            // 
            selectedLab.AutoSize = true;
            selectedLab.Location = new Point(162, 61);
            selectedLab.Name = "selectedLab";
            selectedLab.Size = new Size(0, 20);
            selectedLab.TabIndex = 8;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(selectedLab);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(tipsLab);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form3";
            Text = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label tipsLab;
        private Label label2;
        private TextBox textBox2;
        private ListBox listBox1;
        private Button button1;
        private Label label3;
        private Label selectedLab;
    }
}