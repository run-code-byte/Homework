namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 回调地狱 ====> 解决回调地狱(async/await)
            //var fn = (Action ff) => { };
            //fn(() => {
            //    // 拿到结果执行下一次
            //    fn(() => {
            //        fn(() => {
            //            fn(() => {
            //                fn(() => {
            //                    fn(() => {
            //                    });
            //                });
            //            });
            //        });
            //    });
            //});

            //async Task<int> fn(int n, Func<int, Task<int>> ff)
            //{
            //    await ff(1);
            //    return 1 + n;
            //}

            //Func<int, Task<int>> f2 = async delegate (int i)
            //{
            //    return i;
            //};

            //var f1 = async () =>
            //{
            //    int r1 = await fn(10,f2);

            //    int r2 = await fn(r1,f2);

            //    int r3 = await fn(r2,f2);

            //    int r4 = await fn(r3,f2);

            //    int r5 = await fn(r4,f2);

            //};




            //double n1 = 0.1;
            //double n2 = 0.2;
            //double res = n1 + n2;
            //MessageBox.Show(res.ToString());
            //double x = 0.1;
            //float n = 100f; // 数字表示法:  数字f 表示这个数字是 浮点型

            //decimal n1 = 0.1m;  // 如果要进行 数字 (精确度高) 的计算 那么就用decimal类型
            //decimal n2 = 0.2m;
            //decimal res = n1 + n2;
            //MessageBox.Show(res.ToString());



            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}