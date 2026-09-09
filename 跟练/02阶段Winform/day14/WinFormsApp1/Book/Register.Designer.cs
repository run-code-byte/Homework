namespace WinFormsApp1.Book
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
            button1 = new AntdUI.Button();
            input1 = new AntdUI.Input();
            inputNumber1 = new AntdUI.InputNumber();
            radio1 = new AntdUI.Radio();
            panel1 = new Panel();
            radio2 = new AntdUI.Radio();
            label3 = new AntdUI.Label();
            input2 = new AntdUI.Input();
            label4 = new AntdUI.Label();
            input3 = new AntdUI.Input();
            label5 = new AntdUI.Label();
            label6 = new AntdUI.Label();
            label7 = new AntdUI.Label();
            select1 = new AntdUI.Select();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Microsoft YaHei UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(982, 84);
            label1.TabIndex = 2;
            label1.Text = "注册";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Location = new Point(272, 104);
            label2.Name = "label2";
            label2.Size = new Size(92, 50);
            label2.TabIndex = 3;
            label2.Text = "用户名: ";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 134);
            button1.Location = new Point(383, 500);
            button1.Name = "button1";
            button1.Size = new Size(193, 58);
            button1.TabIndex = 6;
            button1.Text = "注册";
            button1.Click += button1_Click;
            // 
            // input1
            // 
            input1.Location = new Point(400, 104);
            input1.Name = "input1";
            input1.PlaceholderText = "请输入用户名";
            input1.Size = new Size(299, 50);
            input1.TabIndex = 0;
            // 
            // inputNumber1
            // 
            inputNumber1.Location = new Point(400, 282);
            inputNumber1.Name = "inputNumber1";
            inputNumber1.PlaceholderText = "请输入年龄";
            inputNumber1.Size = new Size(299, 50);
            inputNumber1.TabIndex = 6;
            inputNumber1.TabStop = false;
            inputNumber1.Text = "0";
            // 
            // radio1
            // 
            radio1.Checked = true;
            radio1.Location = new Point(16, 16);
            radio1.Name = "radio1";
            radio1.Size = new Size(77, 51);
            radio1.TabIndex = 3;
            radio1.Text = "男";
            // 
            // panel1
            // 
            panel1.Controls.Add(radio2);
            panel1.Controls.Add(radio1);
            panel1.Location = new Point(386, 334);
            panel1.Name = "panel1";
            panel1.Size = new Size(228, 82);
            panel1.TabIndex = 8;
            // 
            // radio2
            // 
            radio2.Location = new Point(111, 16);
            radio2.Name = "radio2";
            radio2.Size = new Size(77, 51);
            radio2.TabIndex = 4;
            radio2.Text = "女";
            // 
            // label3
            // 
            label3.Location = new Point(272, 160);
            label3.Name = "label3";
            label3.Size = new Size(92, 50);
            label3.TabIndex = 3;
            label3.Text = "密    码: ";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // input2
            // 
            input2.Location = new Point(400, 160);
            input2.Name = "input2";
            input2.PasswordChar = '*';
            input2.PlaceholderText = "请输入密码";
            input2.Size = new Size(299, 50);
            input2.TabIndex = 1;
            // 
            // label4
            // 
            label4.Location = new Point(278, 216);
            label4.Name = "label4";
            label4.Size = new Size(92, 50);
            label4.TabIndex = 3;
            label4.Text = "确认密码: ";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // input3
            // 
            input3.Location = new Point(400, 216);
            input3.Name = "input3";
            input3.PlaceholderText = "请再次输入密码";
            input3.Size = new Size(299, 50);
            input3.TabIndex = 2;
            // 
            // label5
            // 
            label5.Location = new Point(264, 282);
            label5.Name = "label5";
            label5.Size = new Size(92, 50);
            label5.TabIndex = 3;
            label5.Text = "年龄: ";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Location = new Point(264, 350);
            label6.Name = "label6";
            label6.Size = new Size(92, 50);
            label6.TabIndex = 3;
            label6.Text = "性别: ";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.Location = new Point(264, 418);
            label7.Name = "label7";
            label7.Size = new Size(92, 50);
            label7.TabIndex = 3;
            label7.Text = "班级: ";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // select1
            // 
            select1.Location = new Point(402, 422);
            select1.Name = "select1";
            select1.PlaceholderText = "请选择班级";
            select1.Size = new Size(297, 59);
            select1.TabIndex = 5;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 603);
            Controls.Add(select1);
            Controls.Add(panel1);
            Controls.Add(inputNumber1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(input3);
            Controls.Add(label5);
            Controls.Add(input2);
            Controls.Add(label4);
            Controls.Add(input1);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Register";
            Text = "Register";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label label1;
        private AntdUI.Label label2;
        private AntdUI.Button button1;
        private AntdUI.Input input1;
        private AntdUI.InputNumber inputNumber1;
        private AntdUI.Radio radio1;
        private Panel panel1;
        private AntdUI.Label label3;
        private AntdUI.Input input2;
        private AntdUI.Label label4;
        private AntdUI.Input input3;
        private AntdUI.Label label5;
        private AntdUI.Label label6;
        private AntdUI.Label label7;
        private AntdUI.Radio radio2;
        private AntdUI.Select select1;
    }
}