namespace WinFormsApp2
{
    partial class MyTcpClient
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
            panel1 = new Panel();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            button2 = new Button();
            button1 = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            textBox3 = new TextBox();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(374, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(393, 386);
            panel1.TabIndex = 12;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(83, 48);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(170, 23);
            textBox2.TabIndex = 10;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(83, 164);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(170, 23);
            textBox1.TabIndex = 11;
            // 
            // button2
            // 
            button2.Location = new Point(83, 208);
            button2.Name = "button2";
            button2.Size = new Size(83, 39);
            button2.TabIndex = 9;
            button2.Text = "发送消息";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(83, 92);
            button1.Name = "button1";
            button1.Size = new Size(129, 38);
            button1.TabIndex = 8;
            button1.Text = "连接TCP服务";
            button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(299, 32);
            label3.Name = "label3";
            label3.Size = new Size(56, 17);
            label3.TabIndex = 5;
            label3.Text = "收到消息";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 167);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 6;
            label2.Text = "消息：";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 51);
            label1.Name = "label1";
            label1.Size = new Size(44, 17);
            label1.TabIndex = 7;
            label1.Text = "端口：";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 15);
            label4.Name = "label4";
            label4.Size = new Size(31, 17);
            label4.TabIndex = 7;
            label4.Text = "IP：";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(83, 12);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(170, 23);
            textBox3.TabIndex = 10;
            // 
            // MyTcpClient
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MyTcpClient";
            Text = "MyTcpClient";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button2;
        private Button button1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
        private TextBox textBox3;
    }
}