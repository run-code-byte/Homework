namespace day05
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
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(122, 94);
            button1.Name = "button1";
            button1.Size = new Size(84, 75);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(601, 333);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(89, 49);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form5";
            Text = "Form5";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private RichTextBox richTextBox1;
    }
}