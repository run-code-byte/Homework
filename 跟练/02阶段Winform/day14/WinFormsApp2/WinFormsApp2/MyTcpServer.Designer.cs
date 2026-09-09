namespace WinFormsApp2
{
    partial class MyTcpServer
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
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            button2 = new Button();
            label3 = new Label();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(96, 75);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "创建TCP服务";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 36);
            label1.Name = "label1";
            label1.Size = new Size(44, 17);
            label1.TabIndex = 1;
            label1.Text = "端口：";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(96, 33);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(186, 23);
            textBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 150);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 3;
            label2.Text = "消息：";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(96, 147);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(189, 23);
            textBox2.TabIndex = 4;
            // 
            // button2
            // 
            button2.Location = new Point(96, 188);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "发送消息";
            button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(361, 39);
            label3.Name = "label3";
            label3.Size = new Size(56, 17);
            label3.TabIndex = 6;
            label3.Text = "收到消息";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(423, 39);
            panel1.Name = "panel1";
            panel1.Size = new Size(267, 349);
            panel1.TabIndex = 7;
            // 
            // MyTcpServer
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "MyTcpServer";
            Text = "MyTcpServer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Button button2;
        private Label label3;
        private Panel panel1;
    }
}