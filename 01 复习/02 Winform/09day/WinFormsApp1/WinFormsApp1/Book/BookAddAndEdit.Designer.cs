namespace WinFormsApp1.Book
{
    partial class BookAddAndEdit
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
            inputNumber1 = new AntdUI.InputNumber();
            button1 = new AntdUI.Button();
            label3 = new AntdUI.Label();
            input2 = new AntdUI.Input();
            label4 = new AntdUI.Label();
            label5 = new AntdUI.Label();
            input3 = new AntdUI.Input();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Microsoft YaHei UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(800, 65);
            label1.TabIndex = 2;
            label1.Text = "";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Location = new Point(219, 85);
            label2.Name = "label2";
            label2.Size = new Size(61, 23);
            label2.TabIndex = 3;
            label2.Text = "图书名称：";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // input1
            // 
            input1.Location = new Point(286, 71);
            input1.Name = "input1";
            input1.PlaceholderText = "请输入书名";
            input1.Size = new Size(274, 46);
            input1.TabIndex = 4;
            // 
            // inputNumber1
            // 
            inputNumber1.Location = new Point(286, 175);
            inputNumber1.Name = "inputNumber1";
            inputNumber1.PlaceholderText = "请输入价格";
            inputNumber1.Size = new Size(274, 46);
            inputNumber1.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(287, 373);
            button1.Name = "button1";
            button1.Size = new Size(170, 51);
            button1.TabIndex = 6;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.Location = new Point(219, 137);
            label3.Name = "label3";
            label3.Size = new Size(61, 23);
            label3.TabIndex = 3;
            label3.Text = "图书作者：";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // input2
            // 
            input2.Location = new Point(286, 123);
            input2.Name = "input2";
            input2.PlaceholderText = "请输入作者";
            input2.Size = new Size(274, 46);
            input2.TabIndex = 4;
            // 
            // label4
            // 
            label4.Location = new Point(219, 189);
            label4.Name = "label4";
            label4.Size = new Size(61, 23);
            label4.TabIndex = 3;
            label4.Text = "图书价格：";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Location = new Point(219, 252);
            label5.Name = "label5";
            label5.Size = new Size(61, 23);
            label5.TabIndex = 3;
            label5.Text = "图书标签：";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // input3
            // 
            input3.Location = new Point(287, 238);
            input3.Multiline = true;
            input3.Name = "input3";
            input3.PlaceholderText = "请输入标签(一行一个)";
            input3.Size = new Size(274, 117);
            input3.TabIndex = 4;
            // 
            // BookAddAndEdit
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(inputNumber1);
            Controls.Add(input3);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(input2);
            Controls.Add(label3);
            Controls.Add(input1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "BookAddAndEdit";
            Text = "BookAddAndEdit";
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label label1;
        private AntdUI.Label label2;
        private AntdUI.Input input1;
        private AntdUI.InputNumber inputNumber1;
        private AntdUI.Button button1;
        private AntdUI.Label label3;
        private AntdUI.Input input2;
        private AntdUI.Label label4;
        private AntdUI.Label label5;
        private AntdUI.Input input3;
    }
}