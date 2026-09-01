namespace day06
{
    partial class BookAdd
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
            label3 = new AntdUI.Label();
            label4 = new AntdUI.Label();
            label5 = new AntdUI.Label();
            button1 = new AntdUI.Button();
            input1 = new AntdUI.Input();
            input2 = new AntdUI.Input();
            input4 = new AntdUI.Input();
            inputNumber1 = new AntdUI.InputNumber();
            flowLayoutPanel1 = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(32, 67);
            label1.Name = "label1";
            label1.Size = new Size(102, 37);
            label1.TabIndex = 0;
            label1.Text = "图书名称：";
            // 
            // label2
            // 
            label2.Location = new Point(32, 120);
            label2.Name = "label2";
            label2.Size = new Size(102, 37);
            label2.TabIndex = 0;
            label2.Text = "作者：";
            // 
            // label3
            // 
            label3.Location = new Point(32, 177);
            label3.Name = "label3";
            label3.Size = new Size(102, 37);
            label3.TabIndex = 0;
            label3.Text = "价格：";
            // 
            // label4
            // 
            label4.Location = new Point(32, 233);
            label4.Name = "label4";
            label4.Size = new Size(102, 37);
            label4.TabIndex = 0;
            label4.Text = "标签：";
            // 
            // label5
            // 
            label5.Font = new Font("微软雅黑", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label5.Location = new Point(178, 9);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.No;
            label5.Size = new Size(205, 57);
            label5.TabIndex = 0;
            label5.Text = "图书新增";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Location = new Point(119, 347);
            button1.Name = "button1";
            button1.Size = new Size(175, 51);
            button1.TabIndex = 1;
            button1.Text = "新增";
            button1.Click += button1_Click;
            // 
            // input1
            // 
            input1.Location = new Point(119, 72);
            input1.Name = "input1";
            input1.PlaceholderText = "请输入图书名称";
            input1.Size = new Size(311, 42);
            input1.TabIndex = 2;
            // 
            // input2
            // 
            input2.Location = new Point(119, 120);
            input2.Name = "input2";
            input2.PlaceholderText = "请输入作者姓名";
            input2.Size = new Size(311, 42);
            input2.TabIndex = 2;
            // 
            // input4
            // 
            input4.Location = new Point(119, 228);
            input4.Multiline = true;
            input4.Name = "input4";
            input4.PlaceholderText = "请输入标签（一个标签占一行）";
            input4.PrefixFormat = AntdUI.FormatFlags.NoWrap | AntdUI.FormatFlags.EllipsisCharacter;
            input4.Size = new Size(311, 113);
            input4.SuffixFormat = AntdUI.FormatFlags.NoWrap;
            input4.TabIndex = 2;
            // 
            // inputNumber1
            // 
            inputNumber1.Location = new Point(119, 177);
            inputNumber1.Name = "inputNumber1";
            inputNumber1.Size = new Size(311, 45);
            inputNumber1.TabIndex = 3;
            inputNumber1.Text = "0";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(456, 15);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(339, 423);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // BookAdd
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(inputNumber1);
            Controls.Add(input4);
            Controls.Add(input2);
            Controls.Add(input1);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "BookAdd";
            Text = "BookAdd";
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label label1;
        private AntdUI.Label label2;
        private AntdUI.Label label3;
        private AntdUI.Label label4;
        private AntdUI.Label label5;
        private AntdUI.Button button1;
        private AntdUI.Input input1;
        private AntdUI.Input input2;
        private AntdUI.Input input4;
        private AntdUI.InputNumber inputNumber1;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}