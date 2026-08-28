namespace day05
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
            PriceCb = new ComboBox();
            TimeCb = new ComboBox();
            SuspendLayout();
            // 
            // PriceCb
            // 
            PriceCb.FormattingEnabled = true;
            PriceCb.Location = new Point(116, 93);
            PriceCb.Name = "PriceCb";
            PriceCb.Size = new Size(206, 28);
            PriceCb.TabIndex = 0;
            PriceCb.Text = "按价格排序";
            // 
            // TimeCb
            // 
            TimeCb.FormattingEnabled = true;
            TimeCb.Location = new Point(387, 93);
            TimeCb.Name = "TimeCb";
            TimeCb.Size = new Size(209, 28);
            TimeCb.TabIndex = 1;
            TimeCb.Text = "按上架时间排序";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TimeCb);
            Controls.Add(PriceCb);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
        }

        #endregion

        private ComboBox PriceCb;
        private ComboBox TimeCb;
    }
}