namespace day07.Book
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
            SuspendLayout();
            // 
            // table1
            // 
            table1.Gap = 12;
            table1.Location = new Point(32, 61);
            table1.Name = "table1";
            table1.Size = new Size(641, 235);
            table1.TabIndex = 0;
            table1.Text = "table1";
            // 
            // BookShow
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(714, 362);
            Controls.Add(table1);
            Name = "BookShow";
            Text = "BookShow";
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Table table1;
    }
}