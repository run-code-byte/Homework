namespace day06
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
            button1 = new AntdUI.Button();
            button2 = new AntdUI.Button();
            button3 = new AntdUI.Button();
            inputNumber1 = new AntdUI.InputNumber();
            select1 = new AntdUI.Select();
            progress1 = new AntdUI.Progress();
            progress2 = new AntdUI.Progress();
            datePicker1 = new AntdUI.DatePicker();
            timePicker1 = new AntdUI.TimePicker();
            datePickerRange1 = new AntdUI.DatePickerRange();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(48, 33);
            button1.Name = "button1";
            button1.Size = new Size(189, 70);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.Type = AntdUI.TTypeMini.Primary;
            // 
            // button2
            // 
            button2.Location = new Point(243, 33);
            button2.Name = "button2";
            button2.Shape = AntdUI.TShape.Circle;
            button2.Size = new Size(189, 70);
            button2.TabIndex = 0;
            button2.Text = "button1";
            button2.Type = AntdUI.TTypeMini.Primary;
            // 
            // button3
            // 
            button3.BorderWidth = 4F;
            button3.Font = new Font("微软雅黑", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 134);
            button3.Ghost = true;
            button3.Location = new Point(438, 33);
            button3.Name = "button3";
            button3.Size = new Size(158, 70);
            button3.TabIndex = 0;
            button3.Text = "button1";
            button3.Type = AntdUI.TTypeMini.Primary;
            // 
            // inputNumber1
            // 
            inputNumber1.Location = new Point(48, 144);
            inputNumber1.Name = "inputNumber1";
            inputNumber1.Size = new Size(189, 53);
            inputNumber1.TabIndex = 1;
            inputNumber1.Text = "0";
            // 
            // select1
            // 
            select1.Items.AddRange(new object[] { "香蕉", "苹果", "葡萄", "荔枝" });
            select1.Location = new Point(264, 155);
            select1.Name = "select1";
            select1.Size = new Size(177, 42);
            select1.TabIndex = 2;
            select1.Text = "选水果";
            // 
            // progress1
            // 
            progress1.Location = new Point(479, 213);
            progress1.Name = "progress1";
            progress1.Shape = AntdUI.TShapeProgress.Circle;
            progress1.Size = new Size(167, 43);
            progress1.TabIndex = 3;
            progress1.Text = "progress1";
            progress1.Value = 0.5F;
            // 
            // progress2
            // 
            progress2.Location = new Point(479, 154);
            progress2.Name = "progress2";
            progress2.Size = new Size(167, 43);
            progress2.TabIndex = 3;
            progress2.Text = "progress1";
            progress2.Value = 0.5F;
            // 
            // datePicker1
            // 
            datePicker1.Location = new Point(243, 239);
            datePicker1.Name = "datePicker1";
            datePicker1.Size = new Size(216, 36);
            datePicker1.TabIndex = 4;
            // 
            // timePicker1
            // 
            timePicker1.Location = new Point(41, 239);
            timePicker1.Name = "timePicker1";
            timePicker1.Size = new Size(172, 41);
            timePicker1.TabIndex = 5;
            timePicker1.Text = "00:00:00";
            // 
            // datePickerRange1
            // 
            datePickerRange1.Location = new Point(243, 310);
            datePickerRange1.Name = "datePickerRange1";
            datePickerRange1.Size = new Size(216, 43);
            datePickerRange1.TabIndex = 6;
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(datePickerRange1);
            Controls.Add(timePicker1);
            Controls.Add(datePicker1);
            Controls.Add(progress2);
            Controls.Add(progress1);
            Controls.Add(select1);
            Controls.Add(inputNumber1);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(button1);
            Name = "Form6";
            Text = "Form6";
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Button button1;
        private AntdUI.Button button2;
        private AntdUI.Button button3;
        private AntdUI.InputNumber inputNumber1;
        private AntdUI.Select select1;
        private AntdUI.Progress progress1;
        private AntdUI.Progress progress2;
        private AntdUI.DatePicker datePicker1;
        private AntdUI.TimePicker timePicker1;
        private AntdUI.DatePickerRange datePickerRange1;
    }
}