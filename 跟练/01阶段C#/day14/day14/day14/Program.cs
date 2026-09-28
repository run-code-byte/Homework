using QQ.WW;
using System.Diagnostics;
using System.Text.Json;
using XX;
using YY;
using xa = XX.AA;
using ya = YY.AA;


namespace day14
{
    enum Gender
    {
        MAN=2,
        WOMAN,
        UNKNOW
    }
    class Res1
    {
        public List<int> text { get; set;  }

    }
    internal class Program
    {
        //static async Task Main(string[] args)
        //{
        //    //HttpClient hc=new HttpClient();
        //    //var response=await hc.GetAsync("https://uapis.cn/api/v1/saying");
        //    ////Console.WriteLine(response.Content);
        //    //string resStr=await response.Content.ReadAsStringAsync();
        //    ////Console.WriteLine(resStr);
        //    ////var resDic=JsonSerializer.Deserialize<Dictionary<string,dynamic>>(resStr);
        //    ////Console.WriteLine(resDic["text"]);

        //    //Res1 resObj =JsonSerializer.Deserialize<Res1>(resStr);
        //    //Console.WriteLine(resObj.text);
        //    ////Console.WriteLine(resObj.text);
        //    ///

        //    //HttpClient hc=new HttpClient();
        //    //byte[] response = await hc.GetByteArrayAsync("https://img95.699pic.com/photo/50465/4467.jpg_wh860.jpg");

        //    //File.WriteAllBytes("./fj.png", response);


        //}





        //static async Task Main(string[] args)
        //{
        //    //// 同步读取3个文件内容
        //    //// 开始计时
        //    //Stopwatch stopwatch1 = Stopwatch.StartNew();
        //    //string aContent = File.ReadAllText("./a.txt");
        //    //string bContent = File.ReadAllText("./b.txt");
        //    //string cContent = File.ReadAllText("./c.txt");
        //    //stopwatch1.Stop();
        //    //Console.WriteLine($"同步读取耗时：{stopwatch1.ElapsedMilliseconds} ms");
        //    //// 异步同时读取
        //    //// 开始计时
        //    //Stopwatch stopwatch2 = Stopwatch.StartNew();
        //    //Task<string> aTask = File.ReadAllTextAsync("a.txt");
        //    //Task<string> bTask = File.ReadAllTextAsync("b.txt");
        //    //Task<string> cTask = File.ReadAllTextAsync("c.txt");
        //    //// 结束计时
        //    //string[] res = await Task.WhenAll(aTask, bTask, cTask);
        //    //stopwatch2.Stop();
        //    //Console.WriteLine($"异步同时读取耗时：{stopwatch2.ElapsedMilliseconds} ms");

        //    string aContent = await File.ReadAllTextAsync("a.txt");
        //    string bContent = await File.ReadAllTextAsync("b.txt");
        //}

        static void ShowList<T>(List<T> list)
        {
            foreach (T i in list)
            {
                Console.WriteLine(i);
            }
        }

        static void Main(string[] args)
        {

            //List<int> ls1 = [10, 20, 30];
            //ShowList<int>(ls1);
            //List<string> ls2 = ["10aa", "20bb", "30cc"];
            //ShowList<string>(ls2);

            Person<string, bool> p = new Person<string, bool>()
            {
                x = "哈哈",
                y=true
            };
            string resS=p.info<double, long>(10.1, 3333333);
            Console.WriteLine(resS);


            //    //int man = 1;
            //    //int woman = 2;
            //    //int unknow = 0;
            //    //man = 3;

            //    Gender man=Gender.MAN;
            //    Console.WriteLine(man);
            //    Console.WriteLine((int)man==2);
            //    Gender un = Gender.UNKNOW;
            //    Console.WriteLine(un);
            //    Console.WriteLine((int)un==4);

            //    //Console.WriteLine("start");
            //    //for (int i = 0; i < 2000; i++)
            //    //{
            //    //    Console.Write("6");
            //    //}
            //    //Console.WriteLine("end");


            //    //A zs1 = new A("zs", 17);
            //    //Console.WriteLine(zs1.name);
            //    //A zs2 = zs1;
            //    //zs2.name = "ls";
            //    //Console.WriteLine(zs1.name);
            //    //Console.WriteLine(zs2.name);

            //    //new ABC();
            //    //new AA();
            //    //new XX.AA();
            //    //new XX.AA();
            //    //new XX.AA();
            //    //new XX.AA();
            //    //new CC();
            //    //new QQ.WW.CC();
            //    //new xa().say();
            //    //new ya().say();



        }
}
}
