namespace day03
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
            panel1 = new Panel();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(78, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(578, 384);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Font = new Font("微软雅黑", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 134);
            button1.Location = new Point(22, 156);
            button1.Name = "button1";
            button1.Size = new Size(34, 45);
            button1.TabIndex = 0;
            button1.Text = "<";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("微软雅黑", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 134);
            button2.Location = new Point(520, 156);
            button2.Name = "button2";
            button2.Size = new Size(34, 45);
            button2.TabIndex = 1;
            button2.Text = ">";
            button2.UseVisualStyleBackColor = true;
            button2.Click += leftClick;
            // 
            // button3
            // 
            button3.Location = new Point(202, 339);
            button3.Name = "button3";
            button3.Size = new Size(33, 30);
            button3.TabIndex = 2;
            button3.Text = "1";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(254, 339);
            button4.Name = "button4";
            button4.Size = new Size(33, 30);
            button4.TabIndex = 2;
            button4.Text = "2";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(305, 339);
            button5.Name = "button5";
            button5.Size = new Size(33, 30);
            button5.TabIndex = 2;
            button5.Text = "3";
            button5.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(13, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(554, 369);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(737, 427);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button3;
        private Button button2;
        private Button button1;
        private Button button5;
        private Button button4;
        private PictureBox pictureBox1;
    }
}
