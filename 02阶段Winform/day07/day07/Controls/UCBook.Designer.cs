namespace day07.Controls
{
    partial class UCBook
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new AntdUI.Label();
            label2 = new AntdUI.Label();
            nameInp = new AntdUI.Input();
            label3 = new AntdUI.Label();
            authoInp = new AntdUI.Input();
            label4 = new AntdUI.Label();
            label5 = new AntdUI.Label();
            input3 = new AntdUI.Input();
            priceInpNum = new AntdUI.InputNumber();
            button1 = new AntdUI.Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("微软雅黑", 18F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.Location = new Point(77, 13);
            label1.Name = "label1";
            label1.Size = new Size(151, 51);
            label1.TabIndex = 0;
            label1.Text = "";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Font = new Font("微软雅黑", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label2.Location = new Point(20, 70);
            label2.Name = "label2";
            label2.Size = new Size(121, 34);
            label2.TabIndex = 1;
            label2.Text = "图书名称：";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // nameInp
            // 
            nameInp.Location = new Point(147, 70);
            nameInp.Name = "nameInp";
            nameInp.PlaceholderText = "请输入图书名称";
            nameInp.Size = new Size(207, 50);
            nameInp.TabIndex = 2;
            // 
            // label3
            // 
            label3.Font = new Font("微软雅黑", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label3.Location = new Point(20, 140);
            label3.Name = "label3";
            label3.Size = new Size(121, 34);
            label3.TabIndex = 1;
            label3.Text = "图书作者：";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // authoInp
            // 
            authoInp.Location = new Point(147, 140);
            authoInp.Name = "authoInp";
            authoInp.PlaceholderText = "请输入图书作者";
            authoInp.Size = new Size(207, 50);
            authoInp.TabIndex = 2;
            // 
            // label4
            // 
            label4.Font = new Font("微软雅黑", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label4.Location = new Point(20, 213);
            label4.Name = "label4";
            label4.Size = new Size(121, 34);
            label4.TabIndex = 1;
            label4.Text = "图书价格：";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Font = new Font("微软雅黑", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label5.Location = new Point(20, 292);
            label5.Name = "label5";
            label5.Size = new Size(121, 34);
            label5.TabIndex = 1;
            label5.Text = "图书标签：";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // input3
            // 
            input3.Location = new Point(147, 292);
            input3.Multiline = true;
            input3.Name = "input3";
            input3.PlaceholderText = "请输入图书标签（一行一个）";
            input3.Size = new Size(207, 112);
            input3.TabIndex = 2;
            // 
            // priceInpNum
            // 
            priceInpNum.Location = new Point(147, 213);
            priceInpNum.Name = "priceInpNum";
            priceInpNum.PlaceholderText = "请输入图书价格";
            priceInpNum.Size = new Size(207, 51);
            priceInpNum.TabIndex = 3;
            priceInpNum.Text = "0";
            // 
            // button1
            // 
            button1.Font = new Font("微软雅黑", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 134);
            button1.Location = new Point(147, 410);
            button1.Name = "button1";
            button1.Size = new Size(143, 44);
            button1.TabIndex = 4;
            button1.Click += button1_Click;
            // 
            // UCBook
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(priceInpNum);
            Controls.Add(input3);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(authoInp);
            Controls.Add(label3);
            Controls.Add(nameInp);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UCBook";
            Size = new Size(375, 463);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label label1;
        private AntdUI.Label label2;
        private AntdUI.Input nameInp;
        private AntdUI.Label label3;
        private AntdUI.Input authoInp;
        private AntdUI.Label label4;
        private AntdUI.Label label5;
        private AntdUI.Input input3;
        private AntdUI.InputNumber priceInpNum;
        private AntdUI.Button button1;
    }
}
