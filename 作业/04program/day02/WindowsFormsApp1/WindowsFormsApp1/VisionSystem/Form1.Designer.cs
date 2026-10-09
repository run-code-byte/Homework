namespace WindowsFormsApp1.VisionSystem
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            AntdUI.StepsItem stepsItem7 = new AntdUI.StepsItem();
            AntdUI.StepsItem stepsItem8 = new AntdUI.StepsItem();
            AntdUI.StepsItem stepsItem9 = new AntdUI.StepsItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.select1 = new AntdUI.Select();
            this.tag1 = new AntdUI.Tag();
            this.button1 = new AntdUI.Button();
            this.panel1 = new AntdUI.In.Panel();
            this.cogDisplay1 = new Cognex.VisionPro.Display.CogDisplay();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label1 = new AntdUI.Label();
            this.steps1 = new AntdUI.Steps();
            this.label2 = new AntdUI.Label();
            this.table1 = new AntdUI.Table();
            this.button2 = new AntdUI.Button();
            this.select2 = new AntdUI.Select();
            this.label3 = new AntdUI.Label();
            this.input1 = new AntdUI.Input();
            this.button3 = new AntdUI.Button();
            this.select3 = new AntdUI.Select();
            this.select4 = new AntdUI.Select();
            this.button4 = new AntdUI.Button();
            this.input2 = new AntdUI.Input();
            this.checkbox1 = new AntdUI.Checkbox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button5 = new AntdUI.Button();
            this.slider1 = new AntdUI.Slider();
            this.input3 = new AntdUI.Input();
            this.tag2 = new AntdUI.Tag();
            this.select5 = new AntdUI.Select();
            this.label4 = new AntdUI.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(902, 571);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.steps1);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(894, 545);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "主运行页";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.select1);
            this.panel2.Controls.Add(this.tag1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(597, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(289, 356);
            this.panel2.TabIndex = 5;
            // 
            // select1
            // 
            this.select1.Location = new System.Drawing.Point(60, 194);
            this.select1.Name = "select1";
            this.select1.Size = new System.Drawing.Size(189, 39);
            this.select1.TabIndex = 3;
            this.select1.Text = "select1";
            // 
            // tag1
            // 
            this.tag1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(243)))), ((int)(((byte)(12)))));
            this.tag1.Location = new System.Drawing.Point(8, 127);
            this.tag1.Name = "tag1";
            this.tag1.Radius = 100;
            this.tag1.Size = new System.Drawing.Size(25, 25);
            this.tag1.TabIndex = 2;
            this.tag1.Text = "";
            // 
            // button1
            // 
            this.button1.BackActive = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(86)))));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(70)))), ((int)(((byte)(103)))));
            this.button1.BackgroundImageLayout = AntdUI.TFit.Cover;
            this.button1.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(140)))), ((int)(((byte)(226)))));
            this.button1.Location = new System.Drawing.Point(8, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 37);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.cogDisplay1);
            this.panel1.Location = new System.Drawing.Point(8, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(556, 424);
            this.panel1.TabIndex = 4;
            this.panel1.Text = "panel1";
            // 
            // cogDisplay1
            // 
            this.cogDisplay1.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay1.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay1.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay1.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay1.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay1.DoubleTapZoomCycleLength = 2;
            this.cogDisplay1.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay1.Location = new System.Drawing.Point(9, 39);
            this.cogDisplay1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay1.MouseWheelSensitivity = 1D;
            this.cogDisplay1.Name = "cogDisplay1";
            this.cogDisplay1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay1.OcxState")));
            this.cogDisplay1.Size = new System.Drawing.Size(531, 370);
            this.cogDisplay1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.select5);
            this.tabPage2.Controls.Add(this.tag2);
            this.tabPage2.Controls.Add(this.input3);
            this.tabPage2.Controls.Add(this.slider1);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(894, 545);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "设备调式";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pictureBox1);
            this.tabPage3.Controls.Add(this.checkbox1);
            this.tabPage3.Controls.Add(this.input2);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.select4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(894, 545);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "视觉配置";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.table1);
            this.tabPage4.Controls.Add(this.button2);
            this.tabPage4.Controls.Add(this.select2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(894, 545);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "数据日志";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.select3);
            this.tabPage5.Controls.Add(this.button3);
            this.tabPage5.Controls.Add(this.input1);
            this.tabPage5.Controls.Add(this.label3);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(894, 545);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "系统设置";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(81, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // steps1
            // 
            this.steps1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.steps1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(14)))), ((int)(((byte)(18)))));
            this.steps1.Gap = 6;
            this.steps1.Items.Add(stepsItem7);
            this.steps1.Items.Add(stepsItem8);
            this.steps1.Items.Add(stepsItem9);
            this.steps1.Location = new System.Drawing.Point(17, 483);
            this.steps1.Name = "steps1";
            this.steps1.Size = new System.Drawing.Size(544, 41);
            this.steps1.TabIndex = 6;
            this.steps1.Text = "steps1";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(405, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            // 
            // table1
            // 
            this.table1.Gap = 12;
            this.table1.Location = new System.Drawing.Point(8, 62);
            this.table1.Name = "table1";
            this.table1.Size = new System.Drawing.Size(860, 230);
            this.table1.TabIndex = 6;
            this.table1.Text = "table1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(219, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 45);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            // 
            // select2
            // 
            this.select2.Location = new System.Drawing.Point(29, 23);
            this.select2.Name = "select2";
            this.select2.Size = new System.Drawing.Size(184, 33);
            this.select2.TabIndex = 4;
            this.select2.Text = "select2";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(73, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 48);
            this.label3.TabIndex = 0;
            this.label3.Text = "label3";
            // 
            // input1
            // 
            this.input1.Location = new System.Drawing.Point(171, 118);
            this.input1.Name = "input1";
            this.input1.Size = new System.Drawing.Size(233, 67);
            this.input1.TabIndex = 1;
            this.input1.Text = "input1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(197, 449);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(220, 61);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            // 
            // select3
            // 
            this.select3.Location = new System.Drawing.Point(63, 67);
            this.select3.Name = "select3";
            this.select3.Size = new System.Drawing.Size(279, 45);
            this.select3.TabIndex = 3;
            this.select3.Text = "select3";
            // 
            // select4
            // 
            this.select4.Location = new System.Drawing.Point(279, 113);
            this.select4.Name = "select4";
            this.select4.Size = new System.Drawing.Size(165, 42);
            this.select4.TabIndex = 0;
            this.select4.Text = "select4";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(337, 258);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(129, 39);
            this.button4.TabIndex = 1;
            this.button4.Text = "button4";
            // 
            // input2
            // 
            this.input2.Location = new System.Drawing.Point(586, 180);
            this.input2.Name = "input2";
            this.input2.Size = new System.Drawing.Size(162, 51);
            this.input2.TabIndex = 2;
            this.input2.Text = "input2";
            // 
            // checkbox1
            // 
            this.checkbox1.Location = new System.Drawing.Point(494, 337);
            this.checkbox1.Name = "checkbox1";
            this.checkbox1.Size = new System.Drawing.Size(97, 49);
            this.checkbox1.TabIndex = 3;
            this.checkbox1.Text = "checkbox1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(8, 239);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(195, 127);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(147, 51);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(152, 54);
            this.button5.TabIndex = 0;
            this.button5.Text = "button5";
            // 
            // slider1
            // 
            this.slider1.Location = new System.Drawing.Point(70, 214);
            this.slider1.Name = "slider1";
            this.slider1.Size = new System.Drawing.Size(336, 36);
            this.slider1.TabIndex = 1;
            this.slider1.Text = "slider1";
            this.slider1.Value = 50;
            // 
            // input3
            // 
            this.input3.Location = new System.Drawing.Point(80, 118);
            this.input3.Name = "input3";
            this.input3.Size = new System.Drawing.Size(191, 57);
            this.input3.TabIndex = 2;
            this.input3.Text = "input3";
            // 
            // tag2
            // 
            this.tag2.Location = new System.Drawing.Point(588, 118);
            this.tag2.Name = "tag2";
            this.tag2.Size = new System.Drawing.Size(88, 66);
            this.tag2.TabIndex = 3;
            this.tag2.Text = "tag2";
            // 
            // select5
            // 
            this.select5.Location = new System.Drawing.Point(552, 286);
            this.select5.Name = "select5";
            this.select5.Size = new System.Drawing.Size(215, 40);
            this.select5.TabIndex = 4;
            this.select5.Text = "select5";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(366, 402);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 47);
            this.label4.TabIndex = 5;
            this.label4.Text = "label4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 571);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private AntdUI.Button button1;
        private Cognex.VisionPro.Display.CogDisplay cogDisplay1;
        private AntdUI.In.Panel panel1;
        private AntdUI.Select select1;
        private AntdUI.Tag tag1;
        private System.Windows.Forms.Panel panel2;
        private AntdUI.Steps steps1;
        private AntdUI.Label label1;
        private AntdUI.Input input2;
        private AntdUI.Button button4;
        private AntdUI.Select select4;
        private AntdUI.Label label2;
        private AntdUI.Table table1;
        private AntdUI.Button button2;
        private AntdUI.Select select2;
        private AntdUI.Select select3;
        private AntdUI.Button button3;
        private AntdUI.Input input1;
        private AntdUI.Label label3;
        private AntdUI.Label label4;
        private AntdUI.Select select5;
        private AntdUI.Tag tag2;
        private AntdUI.Input input3;
        private AntdUI.Slider slider1;
        private AntdUI.Button button5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private AntdUI.Checkbox checkbox1;
    }
}