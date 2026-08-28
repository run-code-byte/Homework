namespace day05
{
    partial class Form6
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(505, 46);
            button1.Name = "button1";
            button1.Size = new Size(136, 56);
            button1.TabIndex = 0;
            button1.Text = "打开窗体";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(505, 142);
            button2.Name = "button2";
            button2.Size = new Size(136, 56);
            button2.TabIndex = 0;
            button2.Text = "关闭窗体";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(505, 232);
            button3.Name = "button3";
            button3.Size = new Size(136, 56);
            button3.TabIndex = 0;
            button3.Text = "隐藏窗体";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(505, 317);
            button4.Name = "button4";
            button4.Size = new Size(136, 56);
            button4.TabIndex = 0;
            button4.Text = "退出应用";
            button4.UseVisualStyleBackColor = true;
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form6";
            Text = "Form6";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}