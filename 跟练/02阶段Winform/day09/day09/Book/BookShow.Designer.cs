namespace day09.Book
{
    partial class BookShow
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
            button1 = new AntdUI.Button();
            table1 = new AntdUI.Table();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("微软雅黑", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(982, 76);
            label1.TabIndex = 1;
            label1.Text = "图书展示";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Location = new Point(68, 92);
            button1.Name = "button1";
            button1.Size = new Size(150, 51);
            button1.TabIndex = 2;
            button1.Text = "新增图书";
            button1.Click += button1_Click;
            // 
            // table1
            // 
            table1.Gap = 12;
            table1.Location = new Point(23, 171);
            table1.Name = "table1";
            table1.Size = new Size(936, 420);
            table1.TabIndex = 3;
            table1.Text = "table1";
            // 
            // BookShow
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 603);
            Controls.Add(table1);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "BookShow";
            Text = "BookShow";
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label label1;
        private AntdUI.Button button1;
        private AntdUI.Table table1;
    }
}