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
            userControl11 = new WinFormsControlLibrary1.UserControl1();
            userControl12 = new WinFormsControlLibrary1.UserControl1();
            button1 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // userControl11
            // 
            userControl11.Location = new Point(12, 12);
            userControl11.Name = "userControl11";
            userControl11.Size = new Size(139, 99);
            userControl11.TabIndex = 0;
            // 
            // userControl12
            // 
            userControl12.Location = new Point(187, 12);
            userControl12.Name = "userControl12";
            userControl12.Size = new Size(173, 118);
            userControl12.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(82, 163);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(124, 252);
            label1.Name = "label1";
            label1.Size = new Size(43, 17);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(userControl12);
            Controls.Add(userControl11);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private WinFormsControlLibrary1.UserControl1 userControl11;
        private WinFormsControlLibrary1.UserControl1 userControl12;
        private Button button1;
        private Label label1;
    }
}
