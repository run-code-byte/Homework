namespace day08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 课堂案例
            // 函数案例
            // 用函数封装一个猜数字的小游戏，函数中生成一个随机整数（0 - 100）作为目标数字，不停的让用户输入数字，距离目标数字偏大，就提示用户偏大，距离目标数字偏小就输出偏小，用户有5次输入的机会，5次没有猜对，输出GAME OVER，猜对了就输出WIN！
            //var guessNum = (int n) =>
            //{
            //    // 函数的参数,在函数内部就是一个变量
            //    // 获取说技术
            //    var random = new Random();
            //    var x = random.Next(0, 100);
            //    int count = 1; // 猜测是次数
            //    while (true)
            //    {
            //        if (n == x)
            //        {
            //            Console.WriteLine("WIN!");
            //            break;// 循环结束
            //        }
            //        else if (n > x) Console.WriteLine("偏大");
            //        else Console.WriteLine("偏小");
            //        // 没猜对,继续猜
            //        Console.WriteLine("请输入你猜的数字");
            //        n = int.Parse(Console.ReadLine());
            //        count++;
            //        if (count == 5)
            //        {   // 游戏次数超过 
            //            Console.WriteLine("GAME OVER");
            //            break;
            //        }
            //    }
            //};

            //Console.WriteLine("请输入你猜的数字");
            //int m = int.Parse(Console.ReadLine());
            //guessNum(m);
            #endregion

            #region 作业
            //1、装修房间：参数1，圆的半径，计算圆的面积，每平方米收费200元，返回装修总价。计算这个半径的圆装修一半需要多少钱？
            //double calji (double x)
            //{
            //    return Math.PI * x * x;
            //}
            //double price = calji(5.0) * 200/2;
            //Console.WriteLine(price);

            //2、计算字符在字符串中出现的次数：参数1字符串，参数2某个字符，函数统计次数，并返回。
            //string str = "qwerysssssqqqqwwweee";
            //int n = fn(str, 's');
            //Console.WriteLine(n);

            //3、计算一个整型数组中，最小值第一次出现的下标。
            //int[] arr = [10, 20, 5, 30, 50, 6, 7];
            //int num=fn2(arr);
            //Console.WriteLine(num); 

            //4、判断一个字符串是否为回文，返回布尔值类型。
            string str = "abcdcba";
            bool b = fn3(str);
            Console.WriteLine(b);
            #endregion
        }
        static int fn(string str,char c)
        {
            int num = 0;
            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] == c) num++;
            }
            return num;
        }
        static int fn2(int[] arr)
        {
            //假设0号下标是最小值
            int minIndex = 0;

            //从第二个元素开始遍历 i=1
            for (int i = 1; i < arr.Length; i++)
            {
                // 如果当前元素比记录的最小值更小
                if (arr[i] < arr[minIndex])
                {
                    minIndex = i; //更新最小值下标
                }
            }
            return minIndex;
        }

        static bool fn3(string str)
        {
            int len = str.Length;
            string leftPart = str.Substring(0, len / 2);
            string rightPart;
            if (len % 2 == 0)
            {
                rightPart = str.Substring(len / 2);
            }
            else
            {
                rightPart = str.Substring(len / 2 + 1);
            }
            //反转rightPart
            char[] arr = rightPart.ToCharArray();
            Array.Reverse(arr);
            string rightRev = new string(arr);
            return leftPart == rightRev;
        }
    }
}
