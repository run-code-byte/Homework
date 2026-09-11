namespace TCM
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
            label1 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            plcStatusLabel = new Label();
            closePLCBtn = new Button();
            connPLCBtn = new Button();
            panel3 = new Panel();
            label3 = new Label();
            panel4 = new Panel();
            panel6 = new Panel();
            inpTempTb = new TextBox();
            setTempBtn = new Button();
            stopBtn = new Button();
            startBtn = new Button();
            panel5 = new Panel();
            label4 = new Label();
            panel7 = new Panel();
            panel9 = new Panel();
            tempPanel = new DoubleBufferPanel();
            label9 = new Label();
            setTempLab = new Label();
            currentTempLab = new Label();
            label7 = new Label();
            panel8 = new Panel();
            label6 = new Label();
            panel10 = new Panel();
            panel12 = new Panel();
            dataGridView1 = new DataGridView();
            panel13 = new Panel();
            goHistoryDataBtn = new Button();
            label5 = new Label();
            panel11 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel14 = new Panel();
            label8 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel7.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            panel10.SuspendLayout();
            panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel13.SuspendLayout();
            panel11.SuspendLayout();
            panel14.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("宋体", 18F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.Location = new Point(350, 5);
            label1.Name = "label1";
            label1.Size = new Size(285, 35);
            label1.TabIndex = 0;
            label1.Text = "温控设备监控主界面";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel3);
            panel1.Location = new Point(18, 51);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 250);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(plcStatusLabel);
            panel2.Controls.Add(closePLCBtn);
            panel2.Controls.Add(connPLCBtn);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 60);
            panel2.Name = "panel2";
            panel2.Size = new Size(298, 188);
            panel2.TabIndex = 0;
            // 
            // plcStatusLabel
            // 
            plcStatusLabel.BorderStyle = BorderStyle.FixedSingle;
            plcStatusLabel.Location = new Point(51, 92);
            plcStatusLabel.Name = "plcStatusLabel";
            plcStatusLabel.Size = new Size(180, 42);
            plcStatusLabel.TabIndex = 2;
            plcStatusLabel.Text = "当前状态：未连接";
            plcStatusLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // closePLCBtn
            // 
            closePLCBtn.BackColor = Color.ForestGreen;
            closePLCBtn.FlatStyle = FlatStyle.Flat;
            closePLCBtn.Location = new Point(161, 30);
            closePLCBtn.Name = "closePLCBtn";
            closePLCBtn.Size = new Size(100, 30);
            closePLCBtn.TabIndex = 1;
            closePLCBtn.Text = "连接PLC";
            closePLCBtn.UseVisualStyleBackColor = false;
            // 
            // connPLCBtn
            // 
            connPLCBtn.BackColor = Color.ForestGreen;
            connPLCBtn.FlatStyle = FlatStyle.Flat;
            connPLCBtn.Location = new Point(32, 30);
            connPLCBtn.Name = "connPLCBtn";
            connPLCBtn.Size = new Size(100, 30);
            connPLCBtn.TabIndex = 1;
            connPLCBtn.Text = "连接PLC";
            connPLCBtn.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label3);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(298, 60);
            panel3.TabIndex = 1;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("宋体", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(296, 58);
            label3.TabIndex = 0;
            label3.Text = "连接控制区";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(panel6);
            panel4.Controls.Add(panel5);
            panel4.Location = new Point(672, 51);
            panel4.Name = "panel4";
            panel4.Size = new Size(300, 250);
            panel4.TabIndex = 1;
            // 
            // panel6
            // 
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(inpTempTb);
            panel6.Controls.Add(setTempBtn);
            panel6.Controls.Add(stopBtn);
            panel6.Controls.Add(startBtn);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 60);
            panel6.Name = "panel6";
            panel6.Size = new Size(298, 188);
            panel6.TabIndex = 0;
            // 
            // inpTempTb
            // 
            inpTempTb.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            inpTempTb.Location = new Point(31, 83);
            inpTempTb.Name = "inpTempTb";
            inpTempTb.PlaceholderText = "请输入设定温度";
            inpTempTb.Size = new Size(233, 28);
            inpTempTb.TabIndex = 2;
            // 
            // setTempBtn
            // 
            setTempBtn.BackColor = Color.ForestGreen;
            setTempBtn.FlatStyle = FlatStyle.Flat;
            setTempBtn.Location = new Point(161, 129);
            setTempBtn.Name = "setTempBtn";
            setTempBtn.Size = new Size(100, 30);
            setTempBtn.TabIndex = 1;
            setTempBtn.Text = "设定温度";
            setTempBtn.UseVisualStyleBackColor = false;
            // 
            // stopBtn
            // 
            stopBtn.BackColor = Color.ForestGreen;
            stopBtn.FlatStyle = FlatStyle.Flat;
            stopBtn.Location = new Point(161, 30);
            stopBtn.Name = "stopBtn";
            stopBtn.Size = new Size(100, 30);
            stopBtn.TabIndex = 1;
            stopBtn.Text = "停止";
            stopBtn.UseVisualStyleBackColor = false;
            // 
            // startBtn
            // 
            startBtn.BackColor = Color.ForestGreen;
            startBtn.FlatStyle = FlatStyle.Flat;
            startBtn.Location = new Point(32, 30);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(100, 30);
            startBtn.TabIndex = 1;
            startBtn.Text = "启动";
            startBtn.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(label4);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(298, 60);
            panel5.TabIndex = 1;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("宋体", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(296, 58);
            label4.TabIndex = 0;
            label4.Text = "设备控制区";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(panel9);
            panel7.Controls.Add(panel8);
            panel7.Location = new Point(324, 51);
            panel7.Name = "panel7";
            panel7.Size = new Size(341, 250);
            panel7.TabIndex = 1;
            // 
            // panel9
            // 
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.Controls.Add(tempPanel);
            panel9.Controls.Add(label9);
            panel9.Controls.Add(setTempLab);
            panel9.Controls.Add(currentTempLab);
            panel9.Controls.Add(label7);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(0, 60);
            panel9.Name = "panel9";
            panel9.Size = new Size(339, 188);
            panel9.TabIndex = 0;
            // 
            // tempPanel
            // 
            tempPanel.Location = new Point(24, 1);
            tempPanel.Name = "tempPanel";
            tempPanel.Size = new Size(305, 151);
            tempPanel.TabIndex = 3;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(205, 155);
            label9.Name = "label9";
            label9.Size = new Size(68, 17);
            label9.TabIndex = 1;
            label9.Text = "设定温度：";
            // 
            // setTempLab
            // 
            setTempLab.AutoSize = true;
            setTempLab.Location = new Point(276, 156);
            setTempLab.Name = "setTempLab";
            setTempLab.Size = new Size(35, 17);
            setTempLab.TabIndex = 2;
            setTempLab.Text = "NaN";
            // 
            // currentTempLab
            // 
            currentTempLab.AutoSize = true;
            currentTempLab.Location = new Point(81, 156);
            currentTempLab.Name = "currentTempLab";
            currentTempLab.Size = new Size(35, 17);
            currentTempLab.TabIndex = 2;
            currentTempLab.Text = "NaN";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 155);
            label7.Name = "label7";
            label7.Size = new Size(68, 17);
            label7.TabIndex = 1;
            label7.Text = "实际温度：";
            // 
            // panel8
            // 
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Controls.Add(label6);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(339, 60);
            panel8.TabIndex = 1;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("宋体", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(337, 58);
            label6.TabIndex = 0;
            label6.Text = "监控画面区";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel10
            // 
            panel10.BorderStyle = BorderStyle.FixedSingle;
            panel10.Controls.Add(panel12);
            panel10.Controls.Add(panel13);
            panel10.Location = new Point(17, 307);
            panel10.Name = "panel10";
            panel10.Size = new Size(483, 250);
            panel10.TabIndex = 2;
            // 
            // panel12
            // 
            panel12.BorderStyle = BorderStyle.FixedSingle;
            panel12.Controls.Add(dataGridView1);
            panel12.Dock = DockStyle.Fill;
            panel12.Location = new Point(0, 64);
            panel12.Name = "panel12";
            panel12.Size = new Size(481, 184);
            panel12.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(481, 180);
            dataGridView1.TabIndex = 0;
            // 
            // panel13
            // 
            panel13.BorderStyle = BorderStyle.FixedSingle;
            panel13.Controls.Add(goHistoryDataBtn);
            panel13.Controls.Add(label5);
            panel13.Dock = DockStyle.Top;
            panel13.Location = new Point(0, 0);
            panel13.Name = "panel13";
            panel13.Size = new Size(481, 64);
            panel13.TabIndex = 1;
            // 
            // goHistoryDataBtn
            // 
            goHistoryDataBtn.FlatStyle = FlatStyle.Flat;
            goHistoryDataBtn.Font = new Font("宋体", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            goHistoryDataBtn.Location = new Point(348, -1);
            goHistoryDataBtn.Name = "goHistoryDataBtn";
            goHistoryDataBtn.Size = new Size(133, 64);
            goHistoryDataBtn.TabIndex = 0;
            goHistoryDataBtn.Text = "查看历史数据";
            goHistoryDataBtn.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("宋体", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(479, 62);
            label5.TabIndex = 1;
            label5.Text = "数据记录区";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel11
            // 
            panel11.BorderStyle = BorderStyle.FixedSingle;
            panel11.Controls.Add(flowLayoutPanel1);
            panel11.Controls.Add(panel14);
            panel11.Location = new Point(515, 307);
            panel11.Name = "panel11";
            panel11.Size = new Size(457, 250);
            panel11.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 64);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(455, 184);
            flowLayoutPanel1.TabIndex = 2;
            flowLayoutPanel1.WrapContents = false;
            // 
            // panel14
            // 
            panel14.BorderStyle = BorderStyle.FixedSingle;
            panel14.Controls.Add(label8);
            panel14.Dock = DockStyle.Top;
            panel14.Location = new Point(0, 0);
            panel14.Name = "panel14";
            panel14.Size = new Size(455, 64);
            panel14.TabIndex = 1;
            // 
            // label8
            // 
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("宋体", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label8.Location = new Point(0, 0);
            label8.Name = "label8";
            label8.Size = new Size(453, 62);
            label8.TabIndex = 1;
            label8.Text = "日志输出区";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(panel11);
            Controls.Add(panel10);
            Controls.Add(panel7);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel8.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel13.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel14.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private Label plcStatusLabel;
        private Button closePLCBtn;
        private Button connPLCBtn;
        private Label label3;
        private Panel panel4;
        private Panel panel5;
        private Label label4;
        private Panel panel6;
        private Button stopBtn;
        private Button startBtn;
        private Panel panel7;
        private Panel panel8;
        private Label label6;
        private Panel panel9;
        private Label label9;
        private Label currentTempLab;
        private Label label7;
        private Label setTempLab;
        private TextBox inpTempTb;
        private Button setTempBtn;
        private Panel panel10;
        private Panel panel13;
        private Panel panel12;
        private Panel panel11;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel14;
        private Label label5;
        private Button goHistoryDataBtn;
        private DataGridView dataGridView1;
        private Label label8;
        private DoubleBufferPanel tempPanel;
    }
}
