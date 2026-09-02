namespace day09.Book
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
            label1.Font = new Font("微软雅黑", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(982, 68);
            label1.TabIndex = 2;
            label1.Text = "";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Location = new Point(171, 83);
            label2.Name = "label2";
            label2.Size = new Size(94, 29);
            label2.TabIndex = 3;
            label2.Text = "图书名称：";
            // 
            // input1
            // 
            input1.Location = new Point(271, 74);
            input1.Name = "input1";
            input1.PlaceholderText = "请输入书名";
            input1.Size = new Size(291, 49);
            input1.TabIndex = 4;
            // 
            // inputNumber1
            // 
            inputNumber1.Location = new Point(271, 204);
            inputNumber1.Name = "inputNumber1";
            inputNumber1.Size = new Size(291, 49);
            inputNumber1.TabIndex = 6;
            inputNumber1.Text = "0";
            // 
            // button1
            // 
            button1.Location = new Point(271, 395);
            button1.Name = "button1";
            button1.Size = new Size(163, 43);
            button1.TabIndex = 7;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.Location = new Point(171, 149);
            label3.Name = "label3";
            label3.Size = new Size(94, 29);
            label3.TabIndex = 3;
            label3.Text = "图书作者：";
            // 
            // input2
            // 
            input2.Location = new Point(271, 140);
            input2.Name = "input2";
            input2.PlaceholderText = "请输入作者";
            input2.Size = new Size(291, 49);
            input2.TabIndex = 4;
            // 
            // label4
            // 
            label4.Location = new Point(171, 213);
            label4.Name = "label4";
            label4.Size = new Size(94, 29);
            label4.TabIndex = 3;
            label4.Text = "图书价格：";
            // 
            // label5
            // 
            label5.Location = new Point(171, 282);
            label5.Name = "label5";
            label5.Size = new Size(94, 29);
            label5.TabIndex = 3;
            label5.Text = "图书标签：";
            // 
            // input3
            // 
            input3.Location = new Point(271, 274);
            input3.Multiline = true;
            input3.Name = "input3";
            input3.PlaceholderText = "请输入标签";
            input3.Size = new Size(291, 115);
            input3.TabIndex = 4;
            // 
            // BookAddAndEdit
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 603);
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