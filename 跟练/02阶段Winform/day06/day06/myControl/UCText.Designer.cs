namespace day06.myControl
{
    partial class UCText
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
            label1 = new Label();
            BookLab = new Label();
            label3 = new Label();
            AuthoLab = new Label();
            label5 = new Label();
            IntroLab = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 28);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 0;
            label1.Text = "书名：";
            // 
            // BookLab
            // 
            BookLab.AutoSize = true;
            BookLab.Location = new Point(114, 28);
            BookLab.Name = "BookLab";
            BookLab.Size = new Size(69, 20);
            BookLab.TabIndex = 0;
            BookLab.Text = "三国演义";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(42, 74);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 0;
            label3.Text = "作者：";
            // 
            // AuthoLab
            // 
            AuthoLab.AutoSize = true;
            AuthoLab.Location = new Point(114, 74);
            AuthoLab.Name = "AuthoLab";
            AuthoLab.Size = new Size(54, 20);
            AuthoLab.TabIndex = 0;
            AuthoLab.Text = "罗贯中";
            // 
            // label5
            // 
            label5.Location = new Point(42, 119);
            label5.Name = "label5";
            label5.Size = new Size(66, 20);
            label5.TabIndex = 0;
            label5.Text = "简介：";
            // 
            // IntroLab
            // 
            IntroLab.AutoSize = true;
            IntroLab.Location = new Point(114, 119);
            IntroLab.Name = "IntroLab";
            IntroLab.Size = new Size(172, 20);
            IntroLab.TabIndex = 0;
            IntroLab.Text = "东汉末年分三国.......曹操";
            // 
            // button1
            // 
            button1.Location = new Point(212, 24);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // UCText
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(IntroLab);
            Controls.Add(label5);
            Controls.Add(AuthoLab);
            Controls.Add(label3);
            Controls.Add(BookLab);
            Controls.Add(label1);
            Name = "UCText";
            Size = new Size(330, 186);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label BookLab;
        private Label label3;
        private Label AuthoLab;
        private Label label5;
        private Label IntroLab;
        private Button button1;

        
    }
}
