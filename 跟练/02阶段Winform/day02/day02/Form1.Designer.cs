namespace day02
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(125, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(440, 324);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button3);
            panel1.Location = new Point(125, 352);
            panel1.Name = "panel1";
            panel1.Size = new Size(440, 57);
            panel1.TabIndex = 1;
            // 
            // button3
            // 
            button3.Font = new Font("微软雅黑", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 134);
            button3.Location = new Point(303, 2);
            button3.Name = "button3";
            button3.Size = new Size(126, 51);
            button3.TabIndex = 2;
            button3.Text = "老鹰";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("微软雅黑", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 134);
            button2.Location = new Point(155, 3);
            button2.Name = "button2";
            button2.Size = new Size(142, 51);
            button2.TabIndex = 1;
            button2.Text = "小鸟";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("微软雅黑", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 134);
            button1.Location = new Point(11, 3);
            button1.Name = "button1";
            button1.Size = new Size(138, 53);
            button1.TabIndex = 0;
            button1.Text = "小猫";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(701, 450);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel1;
        private Button button3;
        private Button button2;
        private Button button1;
    }
}
