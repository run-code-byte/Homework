namespace day07
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
            button3 = new AntdUI.Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(46, 35);
            button1.Margin = new Padding(6);
            button1.Name = "button1";
            button1.Size = new Size(203, 93);
            button1.TabIndex = 0;
            button1.Text = "图书新增";
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(46, 162);
            button2.Margin = new Padding(6);
            button2.Name = "button2";
            button2.Size = new Size(203, 93);
            button2.TabIndex = 0;
            button2.Text = "图书编辑";
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(46, 302);
            button3.Margin = new Padding(6);
            button3.Name = "button3";
            button3.Size = new Size(203, 93);
            button3.TabIndex = 0;
            button3.Text = "图书查看";
            button3.Click += button3_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(19F, 40F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(808, 454);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Font = new Font("微软雅黑", 18F, FontStyle.Bold, GraphicsUnit.Point, 134);
            Margin = new Padding(6);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Button button1;
        private AntdUI.Button button2;
        private AntdUI.Button button3;
    }
}