namespace day03
{
    partial class Move
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
            box = new Panel();
            SuspendLayout();
            // 
            // box
            // 
            box.BackColor = Color.Black;
            box.Location = new Point(174, 83);
            box.Name = "box";
            box.Size = new Size(50, 50);
            box.TabIndex = 0;
            // 
            // Move
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(box);
            Name = "Move";
            Text = "Move";
            ResumeLayout(false);
        }

        #endregion

        private Panel box;
    }
}