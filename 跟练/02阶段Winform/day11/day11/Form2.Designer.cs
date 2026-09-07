namespace day11
{
    partial class Form2
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
            button1 = new AntdUI.Button();
            button2 = new AntdUI.Button();
            pictureBox1 = new PictureBox();
            button3 = new AntdUI.Button();
            button4 = new AntdUI.Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(29, 21);
            button1.Name = "button1";
            button1.Size = new Size(103, 43);
            button1.TabIndex = 0;
            button1.Text = "单文件";
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(29, 217);
            button2.Name = "button2";
            button2.Size = new Size(103, 43);
            button2.TabIndex = 0;
            button2.Text = "多文件";
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(29, 70);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(103, 132);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // button3
            // 
            button3.Location = new Point(183, 21);
            button3.Name = "button3";
            button3.Size = new Size(103, 43);
            button3.TabIndex = 0;
            button3.Text = "保存文件";
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(366, 21);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 2;
            button4.Text = "选择文件夹";
            button4.Click += button4_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(pictureBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Button button1;
        private AntdUI.Button button2;
        private PictureBox pictureBox1;
        private AntdUI.Button button3;
        private AntdUI.Button button4;
    }
}