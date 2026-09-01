namespace day03
{
    partial class FocusNoGo
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
            tb1 = new TextBox();
            richTextBox1 = new RichTextBox();
            label1 = new Label();
            lab = new Label();
            SuspendLayout();
            // 
            // tb1
            // 
            tb1.Location = new Point(123, 29);
            tb1.Name = "tb1";
            tb1.Size = new Size(227, 27);
            tb1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(123, 71);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(227, 143);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Red;
            label1.Location = new Point(367, 32);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 2;
            label1.Text = "不能为空";
            label1.Visible = false;
            // 
            // lab
            // 
            lab.AutoSize = true;
            lab.ForeColor = Color.Blue;
            lab.Location = new Point(397, 152);
            lab.Name = "lab";
            lab.Size = new Size(129, 20);
            lab.TabIndex = 3;
            lab.Text = "AI视觉，工业视觉";
            // 
            // FocusNoGo
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(635, 349);
            Controls.Add(lab);
            Controls.Add(label1);
            Controls.Add(richTextBox1);
            Controls.Add(tb1);
            Name = "FocusNoGo";
            Text = "FocusNoGo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb1;
        private RichTextBox richTextBox1;
        private Label label1;
        private Label lab;
    }
}