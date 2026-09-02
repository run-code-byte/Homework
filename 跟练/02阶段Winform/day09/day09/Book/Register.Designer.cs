namespace day09.Book
{
    partial class Register
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
            input1 = new AntdUI.Input();
            button1 = new AntdUI.Button();
            label3 = new AntdUI.Label();
            input2 = new AntdUI.Input();
            label4 = new AntdUI.Label();
            input3 = new AntdUI.Input();
            label5 = new AntdUI.Label();
            label6 = new AntdUI.Label();
            input5 = new AntdUI.Input();
            radio1 = new AntdUI.Radio();
            radio2 = new AntdUI.Radio();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("微软雅黑", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(982, 76);
            label1.TabIndex = 3;
            label1.Text = "注册";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Location = new Point(279, 91);
            label2.Name = "label2";
            label2.Size = new Size(100, 39);
            label2.TabIndex = 4;
            label2.Text = "用户名：";
            // 
            // input1
            // 
            input1.Location = new Point(364, 82);
            input1.Name = "input1";
            input1.PlaceholderText = "请输入用户名";
            input1.Size = new Size(333, 58);
            input1.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(364, 428);
            button1.Name = "button1";
            button1.Size = new Size(206, 60);
            button1.TabIndex = 6;
            button1.Text = "注册";
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.Location = new Point(279, 155);
            label3.Name = "label3";
            label3.Size = new Size(100, 39);
            label3.TabIndex = 4;
            label3.Text = "密码：";
            // 
            // input2
            // 
            input2.Location = new Point(364, 146);
            input2.Name = "input2";
            input2.PasswordChar = '*';
            input2.PasswordCopy = true;
            input2.PlaceholderText = "请输入密码";
            input2.Size = new Size(333, 58);
            input2.TabIndex = 5;
            // 
            // label4
            // 
            label4.Location = new Point(279, 219);
            label4.Name = "label4";
            label4.Size = new Size(100, 39);
            label4.TabIndex = 4;
            label4.Text = "年龄：";
            // 
            // input3
            // 
            input3.Location = new Point(364, 210);
            input3.Name = "input3";
            input3.PlaceholderText = "请输入年龄";
            input3.Size = new Size(333, 58);
            input3.TabIndex = 5;
            // 
            // label5
            // 
            label5.Location = new Point(279, 283);
            label5.Name = "label5";
            label5.Size = new Size(100, 39);
            label5.TabIndex = 4;
            label5.Text = "性别：";
            // 
            // label6
            // 
            label6.Location = new Point(279, 358);
            label6.Name = "label6";
            label6.Size = new Size(100, 39);
            label6.TabIndex = 4;
            label6.Text = "班级：";
            // 
            // input5
            // 
            input5.Location = new Point(364, 349);
            input5.Name = "input5";
            input5.PlaceholderText = "请输入班级";
            input5.Size = new Size(333, 58);
            input5.TabIndex = 5;
            // 
            // radio1
            // 
            radio1.Location = new Point(385, 288);
            radio1.Name = "radio1";
            radio1.Size = new Size(94, 29);
            radio1.TabIndex = 7;
            radio1.Text = "男";
            // 
            // radio2
            // 
            radio2.Location = new Point(508, 288);
            radio2.Name = "radio2";
            radio2.Size = new Size(94, 29);
            radio2.TabIndex = 7;
            radio2.Text = "女";
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 603);
            Controls.Add(radio2);
            Controls.Add(radio1);
            Controls.Add(button1);
            Controls.Add(input5);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(input3);
            Controls.Add(label4);
            Controls.Add(input2);
            Controls.Add(label3);
            Controls.Add(input1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Register";
            Text = "Register";
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label label1;
        private AntdUI.Label label2;
        private AntdUI.Input input1;
        private AntdUI.Button button1;
        private AntdUI.Label label3;
        private AntdUI.Input input2;
        private AntdUI.Label label4;
        private AntdUI.Input input3;
        private AntdUI.Label label5;
        private AntdUI.Label label6;
        private AntdUI.Input input5;
        private AntdUI.Radio radio1;
        private AntdUI.Radio radio2;
    }
}