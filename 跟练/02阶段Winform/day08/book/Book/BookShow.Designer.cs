namespace book.Book
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
            table1 = new AntdUI.Table();
            button1 = new AntdUI.Button();
            SuspendLayout();
            // 
            // table1
            // 
            table1.Gap = 12;
            table1.Location = new Point(88, 66);
            table1.Name = "table1";
            table1.Size = new Size(615, 298);
            table1.TabIndex = 0;
            table1.Text = "table1";
            // 
            // button1
            // 
            button1.Location = new Point(350, 385);
            button1.Name = "button1";
            button1.Size = new Size(141, 61);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.Click += button1_Click;
            // 
            // BookShow
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(table1);
            Name = "BookShow";
            Text = "BookShow";
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Table table1;
        private AntdUI.Button button1;
    }
}