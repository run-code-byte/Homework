namespace day06.myControl
{
    partial class UCinfo
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
            nameLab = new Label();
            ageLab = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // nameLab
            // 
            nameLab.AutoSize = true;
            nameLab.Location = new Point(11, 15);
            nameLab.Name = "nameLab";
            nameLab.Size = new Size(53, 20);
            nameLab.TabIndex = 0;
            nameLab.Text = "label1";
            // 
            // ageLab
            // 
            ageLab.AutoSize = true;
            ageLab.Location = new Point(153, 15);
            ageLab.Name = "ageLab";
            ageLab.Size = new Size(53, 20);
            ageLab.TabIndex = 1;
            ageLab.Text = "label2";
            // 
            // button1
            // 
            button1.Location = new Point(260, 9);
            button1.Name = "button1";
            button1.Size = new Size(95, 32);
            button1.TabIndex = 2;
            button1.Text = "删除";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // UCinfo
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(ageLab);
            Controls.Add(nameLab);
            Name = "UCinfo";
            Size = new Size(371, 54);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nameLab;
        private Label ageLab;
        private Button button1;
    }
}
