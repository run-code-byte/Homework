namespace WinFormsApp1.Book
{
    partial class Login
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
            label1 = new AntdUI.Label();
            label2 = new AntdUI.Label();
            button1 = new AntdUI.Button();
            input1 = new AntdUI.Input();
            label3 = new AntdUI.Label();
            input2 = new AntdUI.Input();
            button2 = new AntdUI.Button();
            label4 = new AntdUI.Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Microsoft YaHei UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(621, 65);
            label1.TabIndex = 1;
            label1.TabStop = false;
            label1.Text = "登录";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Location = new Point(137, 92);
            label2.Name = "label2";
            label2.Size = new Size(76, 52);
            label2.TabIndex = 2;
            label2.Text = "用户名：";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Location = new Point(219, 252);
            button1.Name = "button1";
            button1.Size = new Size(176, 57);
            button1.TabIndex = 2;
            button1.Text = "登录";
            button1.Click += button1_Click;
            // 
            // input1
            // 
            input1.Location = new Point(219, 92);
            input1.Name = "input1";
            input1.PlaceholderText = "请输入用户名";
            input1.Size = new Size(295, 52);
            input1.TabIndex = 0;
            // 
            // label3
            // 
            label3.Location = new Point(137, 174);
            label3.Name = "label3";
            label3.Size = new Size(76, 52);
            label3.TabIndex = 2;
            label3.Text = "密码：";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // input2
            // 
            input2.Location = new Point(219, 174);
            input2.Name = "input2";
            input2.PlaceholderText = "请输入密码";
            input2.Size = new Size(295, 52);
            input2.TabIndex = 1;
            // 
            // button2
            // 
            button2.Location = new Point(305, 326);
            button2.Name = "button2";
            button2.Size = new Size(69, 38);
            button2.TabIndex = 5;
            button2.Text = "注册";
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.Location = new Point(165, 326);
            label4.Name = "label4";
            label4.Size = new Size(134, 38);
            label4.TabIndex = 6;
            label4.TabStop = false;
            label4.Text = "没有账号请先注册==>";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(621, 376);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(input2);
            Controls.Add(input1);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label label1;
        private AntdUI.Label label2;
        private AntdUI.Button button1;
        private AntdUI.Input input1;
        private AntdUI.Label label3;
        private AntdUI.Input input2;
        private AntdUI.Button button2;
        private AntdUI.Label label4;
    }
}