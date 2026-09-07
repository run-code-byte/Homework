namespace day11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 设置时间间隔为1秒
            timer.Tick += (object sender, EventArgs e) => ShowTime(); // 订阅Tick事件
            timer.Start(); // 启动定时器
        }

        private void ShowTime()
        {
            TimeSpan diff=DateTime.Parse("2026-10-1 00:00:00") - DateTime.Now;
            label2.Text=Math.Floor(diff.TotalDays).ToString();
            label4.Text=Math.Floor(diff.TotalHours%24).ToString();
            label6.Text=Math.Floor(diff.TotalMinutes%60).ToString();
            label8.Text=Math.Floor(diff.TotalSeconds%60).ToString();

        }
      
    }
}
