namespace day05
{
    partial class Form4
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
            AllCbox = new CheckBox();
            ChildPan = new Panel();
            checkBox7 = new CheckBox();
            checkBox6 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            ChildPan.SuspendLayout();
            SuspendLayout();
            // 
            // AllCbox
            // 
            AllCbox.AutoSize = true;
            AllCbox.Location = new Point(132, 46);
            AllCbox.Name = "AllCbox";
            AllCbox.Size = new Size(61, 24);
            AllCbox.TabIndex = 0;
            AllCbox.Text = "全选";
            AllCbox.UseVisualStyleBackColor = true;
            // 
            // ChildPan
            // 
            ChildPan.Controls.Add(checkBox7);
            ChildPan.Controls.Add(checkBox6);
            ChildPan.Controls.Add(checkBox5);
            ChildPan.Controls.Add(checkBox4);
            ChildPan.Controls.Add(checkBox3);
            ChildPan.Controls.Add(checkBox2);
            ChildPan.Location = new Point(151, 67);
            ChildPan.Name = "ChildPan";
            ChildPan.Size = new Size(203, 204);
            ChildPan.TabIndex = 1;
            // 
            // checkBox7
            // 
            checkBox7.AutoSize = true;
            checkBox7.Location = new Point(3, 153);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new Size(61, 24);
            checkBox7.TabIndex = 0;
            checkBox7.Text = "芒果";
            checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Location = new Point(3, 123);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(61, 24);
            checkBox6.TabIndex = 0;
            checkBox6.Text = "龙眼";
            checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(3, 93);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(61, 24);
            checkBox5.TabIndex = 0;
            checkBox5.Text = "荔枝";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(3, 63);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(61, 24);
            checkBox4.TabIndex = 0;
            checkBox4.Text = "西瓜";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(3, 33);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(61, 24);
            checkBox3.TabIndex = 0;
            checkBox3.Text = "苹果";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(3, 3);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(61, 24);
            checkBox2.TabIndex = 0;
            checkBox2.Text = "香蕉";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ChildPan);
            Controls.Add(AllCbox);
            Name = "Form4";
            Text = "Form4";
            ChildPan.ResumeLayout(false);
            ChildPan.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox AllCbox;
        private Panel ChildPan;
        private CheckBox checkBox7;
        private CheckBox checkBox6;
        private CheckBox checkBox5;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
    }
}