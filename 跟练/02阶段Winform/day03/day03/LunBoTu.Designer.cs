namespace day03
{
    partial class LunBoTu
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
            pictureBox1 = new PictureBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(111, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(546, 356);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkGray;
            button1.Location = new Point(314, 329);
            button1.Name = "button1";
            button1.Size = new Size(29, 25);
            button1.TabIndex = 1;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Microsoft YaHei UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.Location = new Point(111, 168);
            label1.Name = "label1";
            label1.Size = new Size(32, 31);
            label1.TabIndex = 2;
            label1.Text = "<";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Microsoft YaHei UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label2.Location = new Point(625, 168);
            label2.Name = "label2";
            label2.Size = new Size(32, 31);
            label2.TabIndex = 2;
            label2.Text = ">";
            // 
            // button2
            // 
            button2.BackColor = Color.DarkGray;
            button2.Location = new Point(349, 329);
            button2.Name = "button2";
            button2.Size = new Size(29, 25);
            button2.TabIndex = 1;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.DarkGray;
            button3.Location = new Point(384, 329);
            button3.Name = "button3";
            button3.Size = new Size(29, 25);
            button3.TabIndex = 1;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = false;
            // 
            // LunBoTu
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(757, 412);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "LunBoTu";
            Text = "LunBoTu";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private Label label1;
        private Label label2;
        private Button button2;
        private Button button3;
    }
}