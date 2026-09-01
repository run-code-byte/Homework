namespace day08
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //Task<int> t1 =Task.Run(() =>
            //{
            //    //throw new Exception("错误");
            //    MessageBox.Show(Thread.CurrentThread.ManagedThreadId.ToString());
            //    return 100;
            //});
            //Task<string> t2 = t1.ContinueWith((Task<int> prv) =>
            //{
            //    MessageBox.Show(Thread.CurrentThread.ManagedThreadId.ToString());
            //    return "6666";
            //});
            //MessageBox.Show(t2.Result.ToString());

            //Task t1 = new Task(() =>
            //{
            //    Thread.Sleep(2000);
            //    MessageBox.Show("Task任务");
            //});
            //MessageBox.Show("111"+t1.Status.ToString()); // Created
            //t1.Start();
            //MessageBox.Show("222"+t1.Status.ToString()); // WaitingToRun
            //Thread.Sleep(1000);
            //MessageBox.Show("333"+  t1.Status.ToString()); // Running
            //Thread.Sleep(2000);
            //MessageBox.Show("444"+t1.Status.ToString()); // RanToCompletion

            //CancellationTokenSource cts = new CancellationTokenSource();
            //Task t1 = Task.Run(() =>
            //{
            //    throw new Exception("错误");
            //    Thread.Sleep(4000);
            //    MessageBox.Show("Task任务");
            //}, cts.Token);
            ////cts.Cancel();
            //Thread.Sleep(3000);
            //MessageBox.Show(t1.Status.ToString()); // Canceled

            //Task<int> Tres = Task.Run(() =>
            //{
            //    return 1;
            //}).ContinueWith(p1 =>
            //{
            //    return p1.Result + 2;
            //}).ContinueWith(p2 =>
            //{
            //    return p2.Result + 3;

            //}).ContinueWith(p3 =>
            //{
            //    return p3.Result + 4;

            //});

            //MessageBox.Show(Tres.Result.ToString()); // 10

            label1.Text = "await 不占用线程";


        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string res = await Other();
            MessageBox.Show(res);
        }
        private async Task<string> Other()
        {
            int i = 10;
            await Task.Run(() =>
            {
                i++;
                MessageBox.Show("ShowOther任务开始");
                Thread.Sleep(3000);
            });
            return "任务完毕" + i;
        }

      

        private async void button3_Click_1(object sender, EventArgs e)
        {
            label1.Text = "开始等待";
            // await 不阻塞UI线程，窗口可以拖动、按钮可以点击
            await Task.Delay(3000);
            label1.Text = "等待完成";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            label1.Text = "开始等待";
            // .Wait() 阻塞UI线程！窗口直接卡死，无法拖动
            Task.Delay(3000).Wait();
            label1.Text = "等待完成";
        }
    }
}
