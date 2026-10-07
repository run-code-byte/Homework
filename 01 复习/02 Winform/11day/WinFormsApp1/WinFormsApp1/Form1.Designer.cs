namespace WinFormsApp1
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
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            checkBox1 = new CheckBox();
            button6 = new Button();
            button7 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(52, 39);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(153, 23);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(52, 92);
            button1.Name = "button1";
            button1.Size = new Size(102, 32);
            button1.TabIndex = 1;
            button1.Text = "查看Book的值";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(52, 160);
            button2.Name = "button2";
            button2.Size = new Size(102, 34);
            button2.TabIndex = 2;
            button2.Text = "修改Book的值";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(240, 37);
            label1.Name = "label1";
            label1.Size = new Size(43, 17);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // button3
            // 
            button3.Location = new Point(228, 92);
            button3.Name = "button3";
            button3.Size = new Size(84, 28);
            button3.TabIndex = 4;
            button3.Text = "查看Book";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(228, 140);
            button4.Name = "button4";
            button4.Size = new Size(84, 28);
            button4.TabIndex = 5;
            button4.Text = "修改Book";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(228, 194);
            button5.Name = "button5";
            button5.Size = new Size(84, 31);
            button5.TabIndex = 6;
            button5.Text = "修改label";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(370, 41);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(89, 21);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(373, 93);
            button6.Name = "button6";
            button6.Size = new Size(82, 22);
            button6.TabIndex = 8;
            button6.Text = "查看Book";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(371, 138);
            button7.Name = "button7";
            button7.Size = new Size(85, 26);
            button7.TabIndex = 9;
            button7.Text = "修改Book";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(checkBox1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Label label1;
        private Button button3;
        private Button button4;
        private Button button5;
        private CheckBox checkBox1;
        private Button button6;
        private Button button7;
    }
}
