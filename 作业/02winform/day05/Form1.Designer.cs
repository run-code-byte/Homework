namespace day05
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
            ProvinceCb = new ComboBox();
            CityCb = new ComboBox();
            SuspendLayout();
            // 
            // ProvinceCb
            // 
            ProvinceCb.FormattingEnabled = true;
            ProvinceCb.Location = new Point(105, 48);
            ProvinceCb.Name = "ProvinceCb";
            ProvinceCb.Size = new Size(179, 28);
            ProvinceCb.TabIndex = 0;
            ProvinceCb.Text = "请选择省份";
            // 
            // CityCb
            // 
            CityCb.FormattingEnabled = true;
            CityCb.Location = new Point(326, 48);
            CityCb.Name = "CityCb";
            CityCb.Size = new Size(191, 28);
            CityCb.TabIndex = 1;
            CityCb.Text = "请选择城市";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CityCb);
            Controls.Add(ProvinceCb);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private ComboBox ProvinceCb;
        private ComboBox CityCb;
    }
}
