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
            label3 = new Label();
            button2 = new Button();
            textBox3 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            label4 = new Label();
            textBox1 = new TextBox();
            button3 = new Button();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(454, 54);
            panel1.Name = "panel1";
            panel1.Size = new Size(267, 349);
            panel1.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(392, 54);
            label3.Name = "label3";
            label3.Size = new Size(56, 17);
            label3.TabIndex = 14;
            label3.Text = "收到消息";
            // 
            // button2
            // 
            button2.Location = new Point(127, 203);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 13;
            button2.Text = "发送消息";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(127, 162);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(189, 23);
            textBox3.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(79, 165);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 11;
            label2.Text = "消息：";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(127, 48);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(186, 23);
            textBox2.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(79, 51);
            label1.Name = "label1";
            label1.Size = new Size(44, 17);
            label1.TabIndex = 9;
            label1.Text = "端口：";
            // 
            // button1
            // 
            button1.Location = new Point(127, 90);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "连接TCP服务";
            button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(79, 15);
            label4.Name = "label4";
            label4.Size = new Size(31, 17);
            label4.TabIndex = 9;
            label4.Text = "IP：";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(127, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(186, 23);
            textBox1.TabIndex = 10;
            // 
            // button3
            // 
            button3.Location = new Point(221, 90);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 16;
            button3.Text = "断开连接";
            button3.UseVisualStyleBackColor = true;
          
            // 
            // MyTcpClient
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(textBox3);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "MyTcpClient";
            Text = "MyTcpClient";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label3;
        private Button button2;
        private TextBox textBox3;
        private Label label2;
        private TextBox textBox2;
        private Label label1;
        private Button button1;
        private Label label4;
        private TextBox textBox1;
        private Button button3;
    }
}