namespace TCM
{
    partial class Form2
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
            label1 = new Label();
            label2 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            dateTimePicker2 = new DateTimePicker();
            button1 = new Button();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(410, 9);
            label1.Name = "label1";
            label1.Size = new Size(180, 44);
            label1.TabIndex = 0;
            label1.Text = "历史温度数据查询";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Location = new Point(54, 98);
            label2.Name = "label2";
            label2.Size = new Size(49, 23);
            label2.TabIndex = 1;
            label2.Text = "开始时间";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(100, 98);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Size = new Size(196, 23);
            dateTimePicker1.TabIndex = 12;
            dateTimePicker1.Value = new DateTime(2026, 9, 25, 0, 0, 0, 0);
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Location = new Point(364, 97);
            label3.Name = "label3";
            label3.Size = new Size(49, 23);
            label3.TabIndex = 2;
            label3.Text = "结束时间";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(410, 98);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.ShowUpDown = true;
            dateTimePicker2.Size = new Size(196, 23);
            dateTimePicker2.TabIndex = 12;
            dateTimePicker2.Value = new DateTime(2026, 9, 26, 0, 0, 0, 0);
            // 
            // button1
            // 
            button1.Location = new Point(671, 99);
            button1.Name = "button1";
            button1.Size = new Size(62, 26);
            button1.TabIndex = 3;
            button1.Text = "查询";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(872, 99);
            button2.Name = "button2";
            button2.Size = new Size(62, 26);
            button2.TabIndex = 4;
            button2.Text = "导出";
            button2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(36, 147);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(916, 357);
            dataGridView1.TabIndex = 11;
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Location = new Point(36, 516);
            label4.Name = "label4";
            label4.Size = new Size(161, 36);
            label4.TabIndex = 5;
            label4.Text = "最高温度：62°";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Location = new Point(410, 516);
            label5.Name = "label5";
            label5.Size = new Size(161, 36);
            label5.TabIndex = 5;
            label5.Text = "最低温度：26°";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.BorderStyle = BorderStyle.FixedSingle;
            label6.Location = new Point(773, 516);
            label6.Name = "label6";
            label6.Size = new Size(161, 36);
            label6.TabIndex = 5;
            label6.Text = "平均温度：44°";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dateTimePicker2);
            Controls.Add(label3);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private DateTimePicker dateTimePicker2;
        private Button button1;
        private Button button2;
        private DataGridView dataGridView1;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}