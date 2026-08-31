namespace day07.Book
{
    partial class BookEdit
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
            ucBook1 = new day07.Controls.UCBook("编辑");
            SuspendLayout();
            // 
            // ucBook1
            // 
            ucBook1.Location = new Point(181, -1);
            ucBook1.Name = "ucBook1";
            ucBook1.Size = new Size(399, 471);
            ucBook1.TabIndex = 0;
            // 
            // BookEdit
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(791, 469);
            Controls.Add(ucBook1);
            Name = "BookEdit";
            Text = "BookEdit";
            ResumeLayout(false);
        }

        #endregion

        private Controls.UCBook ucBook1;
    }
}