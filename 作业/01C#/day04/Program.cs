using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;

namespace day04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int i = 1;
            //int sum = 0;
            //while (i <= 10) {
            //    sum = sum + i;
            //    i++;
            //}
            //Console.WriteLine(sum);

            #region 上课案例
            //例：利用while循环中的变量输出数字1~5
            //int i = 1;
            //while (i <= 5) {
            //    Console.WriteLine(i);
            //    i++;
            //}


            //例：将1 - 5相加
            //int i = 1;
            //int sum = 0;
            //while (i <= 5)
            //{
            //    sum=sum+i;
            //    i++;
            //}
            //Console.WriteLine(sum);


            //例：将1 - 10相加
            //int i = 1;
            //int sum = 0;
            //while (i <= 10)
            //{
            //    sum = sum + i;
            //    i++;
            //}
            //Console.WriteLine(sum);

            //例：将1 - 10之间的奇数加起来
            //int i = 1;
            //int sum = 0;
            //while (i <= 10)
            //{
            //    if(i%2!=0)sum = sum + i;
            //    i++;
            //}
            //Console.WriteLine(sum);

            //例：输出50以内所有能被3整除且能被5整除的数字
            //int i = 1;
            //while (i <= 50)
            //{
            //    if (i % 3== 0&&i%5==0) Console.WriteLine(i); 
            //    i++;
            //}


            //例：1 - 5相乘
            //int i = 1;
            //int ji = 1;
            //while (i <= 5)
            //{
            //    ji *= i;
            //    i++;
            //}
            //Console.WriteLine(ji);

            //例：逢7就过的游戏中，100以内所有喊过的数字
            //int i = 1;
            //while (i <= 100)
            //{
            //    if(i%7==0) Console.WriteLine(i);
            //    i++;
            //}

            // 例：求100~1000之间所有的水仙花数
            // 其百位、十位、个位上的数字的 3次方之和 恰好等于这个数本身
            //int i = 100;
            //while (i <= 1000)
            //{
            //    int ge = i % 10;
            //    int shi = (i / 10) % 10;
            //    int bai= i / 100;
            //    if(Math.Pow(ge,3)+Math.Pow(shi,3)+Math.Pow(bai,3)==i) Console.WriteLine(i);
            //    i++;
            //}

            //do while循环结构
            //例：输出1 - 5
            //int i = 1;
            //do
            //{
            //    Console.WriteLine(i);
            //    i++;
            //}while (i <= 5);

            //例：输出5句“我爱你”
            //for(int i = 1; i <=5; i++)
            //{
            //    Console.WriteLine("我爱你");
            //}

            //例：倒着输出1 - 10
            //for(int i = 10; i >0; i--)
            //{
            //    Console.WriteLine(i);
            //}

            //例：输出1 - 10之间的偶数
            //for (int i = 1; i <=10; i++)
            //{
            //    if(i%2==0)Console.WriteLine(i);
            //}

            //例：while的例子
            //例：入职薪水10K，每年涨幅5 %，50年后工资多少？
            //double money = 10;
            //int year = 1;
            //while (year<=50) 
            //{
            //    money = money + money * 0.05;
            //    year++;
            //}
            //Console.WriteLine(money);

            //例：遍历List
            //List<string> strlist = new()
            //{
            //    "a",
            //    "b",
            //    "c",
            //    "d"
            //};
            //for (int i = 0; i < strlist.Count; i++)
            //{
            //    Console.WriteLine(strlist[i]);
            //}

            //例：求int型List的所有数据之和
            //List<int> intlist = new()
            //{
            //    3,4,5,6,7,8,9
            //};
            //int sum = 0;
            //for (int i = 0; i < intlist.Count; i++)
            //{
            //    sum += intlist[i];
            //}
            //Console.WriteLine(sum);

            //例：判断一个数是否是素数(素数，就是除了1和自己本身，不能被别的数整除)
            //int m = 11;
            //string s = "黑色";
            //for (int i = 1; i <= m; i++)
            //{
            //    if (i == 1 || i == m) continue;
            //    if (m % i == 0) s = "白色";
            //}
            //if(s =="黑色") Console.WriteLine($"{m}是素数");

            //foreach循环结构 专门遍历数组、List。
            //foreach 遍历数组
            //int[] intArr = {10,20,30,40};
            //foreach(int item in intArr) Console.WriteLine(item);

            // 数组数据求和
            //int[] intArr = { 10, 20, 30, 40 };
            //int sum = 0;
            //foreach (int i in intArr) sum += i;
            //Console.WriteLine(sum);

            // foreach 遍历 List集合
            //List<string> strlist = new List<string>() { "h","e","l","l","o"};
            //foreach(string str in strlist) Console.WriteLine(str);

            // 拼接 strList集合的数据
            //List<string> strlist = new List<string>() { "h", "e", "l", "l", "o" };
            //string res = "";
            //foreach (string str in strlist)res+=str ;
            //Console.WriteLine(res);

            // foreach 遍历字典
            //Dictionary<string, dynamic> dic = new Dictionary<string, dynamic>()
            //{
            //    ["name"] = "Tom",
            //    ["age"]=19,
            //    ["gender"]=1,
            //    ["hobby"]="jerry"
            //};
            //foreach(dynamic item in dic) Console.WriteLine(item);

            //例：5个人，每个人都跑5圈
            //for (int i = 0; i < 5; i++) { 
            //    for (int j = 0; j < 5; j++)
            //    {
            //        Console.WriteLine($"第{i}人 跑第{j}圈");
            //    }
            //}

            //例：输出5行星号，每行5个
            //for (int i = 0; i < 5; i++)
            //{
            //    for(int j = 0; j < 5; j++)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine();
            //}

            //例：用星号输出直角三角形
            //for (int i = 0; i < 5; i++)
            //{
            //    for (int j = 0; j < i; j++)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine();
            //}

            //例：输出九九乘法表
            //for (int i = 1; i <= 9; i++)
            //{
            //    for (int j = 1; j <= i; j++)
            //    {
            //        Console.Write($"{j}*{i}={j*i}\t");
            //    }
            //    Console.WriteLine();
            //}

            #endregion

            #region 作业
            //1.计算100以内偶数的和
            //int sum = 0;
            //for(int i = 1; i <= 100; i++)
            //{
            //    if (i % 2 == 0) sum += i;
            //}
            //Console.WriteLine(sum);


            //2.显示出1000 - 2000年中所有的闰年，并以每行四个数的形式输出
            //for(int i = 1000; i <= 2000; i+=4)
            //{
            //    for(int j = 1; j <= 4; j++)
            //    {
            //        if(i%4==0&&i%100!=0||i%400==0)Console.Write($"{i}\t");

            //    }
            //    Console.WriteLine( );
            //}


            //3.输出一个倒三角形，如下
            //for (int i = 1; i <= 9; i++)
            //{
            //    for(int j = 1; j <= 9-i; j++)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine();
            //}

            //4.用循环计算下面的结果
            //   1 - 1 / 2 + 1 / 3 - 1 / 4 + ... -1 / 100
            //double res = 1;
            //for (int i = 2; i <= 100; i++)
            //{
            //    if (i % 2 == 0) res -= 1/i;
            //    else res += 1/i;
            //}
            //Console.WriteLine(res);

            //5.求10以内所有数字的阶乘的和
            //int n = 1;
            //int sum = 0;
            //for (int i = 1; i <= 10; i++)
            //{
            //    for (int j = 1; j <= i; j++)
            //    {
            //        n *= j;
            //    }
            //    sum += n;
            //}
            //Console.WriteLine(sum);


            //6.篮球从5米高的地方掉下来，每次弹起的高度是原来的30 %，经过几次弹起，篮球的高度小于0.1米。
            //double h = 5;
            //int i = 1;
            //for (; i < 100; i++)
            //{
            //    if (h < 0.1) break;
            //    h = h * 0.3;
            //}
            //Console.WriteLine(i);

            //7.有一个棋盘，有64个方格，在第一个方格里面放1粒芝麻重量是0.00001kg，第二个里面放2粒，第三个里面放4，棋盘上放的所有芝麻的重量
            //double sum = 0;
            //for (int i = 1; i <= 64; i++)
            //{
            //    sum += 0.00001+(i-1)*2 * 0.00001;
            //}
            //Console.WriteLine(sum);

            //8.某人在银行有50000元存款。银行每月都要收取服务费，存款大于5000元时每个月收取总额的5 %，总额不大于5000元的时候不收服务费；假设这个人存了以后从来都不用，用循环计算银行要扣这个人的手续费能扣多少次？每次扣取后剩余多少钱？
            //double n = 50000;
            //int i = 1;
            //for (; i <100; i++)
            //{
            //    if (n <= 5000) break;
            //    n *= (1 - 0.05);
            //    Console.WriteLine($"第{i}次:{n}");
            //}
            //Console.WriteLine(i);

            //9.猴子摘桃，猴子摘了x个桃，每天吃一半，再多吃一个，第7天吃的时候剩下一个了，猴子摘了多少桃子？
            //int sum = 1;
            //for (int i = 1; i < 7; i++)
            //{
            //    sum += i * 2 + 1;
            //}
            //Console.WriteLine(sum);

            //10.有个皮球，每次落地弹起都是高度的一半，如果从10米高的地方丢下，第十次弹起时，皮球总过经历了多少距离。
            //double h = 10;
            //double sum = 0;
            //for(int i = 0; i < h; i++)
            //{
            //    h *= (1 - 0.5);
            //    sum += 10-h;
            //}
            //Console.WriteLine(sum);


            #endregion

        }
    }
}
