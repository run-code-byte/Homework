namespace Ctest
{
    internal class Programming1
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10];
            Random r = new Random();
            Console.WriteLine("随机生成10个1-50之间的随机整数：");
            for (int i = 0; i < 10; i++)
            {
                arr[i] = r.Next(1, 51); // 1~50，右边界写51
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();

            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += arr[i];
            }
            double averge = sum / 10.0; //浮点数除法
            Console.WriteLine($"总数：{sum}，平均值：{averge:F2}"); // :F2保留2位小数



        }
    }
}
