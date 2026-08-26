namespace day03
{
    partial class CursorLocation
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
            label2 = new Label();
            lab1 = new Label();
            lab2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            labT = new Label();
            labF = new Label();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 16);
            label1.Name = "label1";
            label1.Size = new Size(139, 20);
            label1.TabIndex = 0;
            label1.Text = "光标X轴坐标位置：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 59);
            label2.Name = "label2";
            label2.Size = new Size(138, 20);
            label2.TabIndex = 0;
            label2.Text = "光标Y轴坐标位置：";
            // 
            // lab1
            // 
            lab1.AutoSize = true;
            lab1.Location = new Point(175, 16);
            lab1.Name = "lab1";
            lab1.Size = new Size(0, 20);
            lab1.TabIndex = 1;
            // 
            // lab2
            // 
            lab2.AutoSize = true;
            lab2.Location = new Point(174, 59);
            lab2.Name = "lab2";
            lab2.Size = new Size(0, 20);
            lab2.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(435, 192);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(196, 27);
            textBox1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(358, 195);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 3;
            label3.Text = "手机号：";
            // 
            // labT
            // 
            labT.AutoSize = true;
            labT.ForeColor = Color.Green;
            labT.Location = new Point(646, 195);
            labT.Name = "labT";
            labT.Size = new Size(54, 20);
            labT.TabIndex = 3;
            labT.Text = "正确 √";
            labT.Visible = false;
            // 
            // labF
            // 
            labF.AutoSize = true;
            labF.ForeColor = Color.Red;
            labF.Location = new Point(637, 199);
            labF.Name = "labF";
            labF.Size = new Size(54, 20);
            labF.TabIndex = 3;
            labF.Text = "错误 ×";
            labF.Visible = false;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(526, 249);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(263, 146);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            // 
            // CursorLocation
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox1);
            Controls.Add(labF);
            Controls.Add(labT);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(lab2);
            Controls.Add(lab1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CursorLocation";
            Text = "CursorLocation";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label lab1;
        private Label lab2;
        private TextBox textBox1;
        private Label label3;
        private Label labT;
        private Label labF;
        private RichTextBox richTextBox1;
    }
}