namespace day12
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //var p1 = new PLC()
            //{
            //    DeviceName = "PLC"
            //};
            //p1.Connect();
            //p1.ReadRegister();
            //p1.Disconnect();
            //p1.Start();

            var person1 = new Person("zs",17,10000,true,true);
            person1.Say();
            person1.Say("大魔仙");
            person1.Say("小魔仙","老魔仙");



            #region 继承
            //var c1 =new Camera()
            //{
            //    DeviceName = "相机1"

            //};
            //c1.Connect();
            //c1.CaptureImage();
            //c1.Disconnect();

            //Console.WriteLine("=======================");

            //var m1 = new MotionController()
            //{
            //    DeviceName="控制器1"
            //};
            //m1.Connect();
            //m1.MoveAxis();
            //m1.Disconnect();

            //Console.WriteLine("=======================");

            //var p1 = new PLC()
            //{
            //    DeviceName = "PLC"
            //};
            //p1.Connect();
            //p1.ReadRegister();
            //p1.Disconnect();
            #endregion


            #region 构造函数

            //Person p2 = new Person()
            //{
            //    Name = "ww",
            //    //Id = 18,
            //    //Salary = 10000,
            //    IsMan = true
            //};
            //p2.GetInfo(true);

            //Person p0 = new Person("ls", 19, 9000, false,true);
            //p0.GetInfo(true);

            //Person p1 = new Person("zs", 18, 10000, true,true);
            //p1.GetInfo(false);

            //SingleInstance single = new SingleInstance();

            //SingleInstance Single = SingleInstance.GetInstance();
            //Console.WriteLine(Single.isTool);

            //SingleInstance Single2 = SingleInstance.GetInstance();
            //Console.WriteLine(Single2.isTool);

            //Console.WriteLine(Single == Single2);
            #endregion


            #region 回调函数
            //List<int> Filter(List<int> list)
            //{
            //    List<int> newList = new List<int>();
            //    foreach (var item in list)
            //    {
            //        if(CondithionFn(item)) newList.Add(item);
            //    }
            //    return newList;
            //}
            //List<int> list = [1,2,3,4,5,6,7];
            //var resList = Filter(list);
            //bool CondithionFn(int item)
            //{
            //    return item > 0;
            //}
            //foreach (var item in resList) Console.WriteLine(item);

            //List<int> Filter(List<int> list, Func<int, bool> callBack)
            //{
            //    List<int> newList = new List<int>();
            //    foreach (var item in list)
            //    {
            //        if (callBack(item)) newList.Add(item);
            //    }
            //    return newList;
            //}
            //List<int> list = [1, 2, 3, 4, 5, 6, 7];

            //Func<int, bool> CondithionFn = item => item > 0;
            //var resList = Filter(list, CondithionFn);

            //var resList = Filter(list, item => item > 5);
            //foreach (var item in resList) Console.WriteLine(item);
            #endregion

            #region 实例化
            //Animal Bird= new Animal();
            //Bird.Name = "麻雀";
            //Console.WriteLine(Bird.Name);
            ////Bird.Description = "我能飞";
            //Bird.Run();

            //Console.WriteLine("=========================");
            //Animal Dog=new Animal();
            //Dog.Name = "旺财";
            //Dog.Run();

            //Person p1 = new Person();
            //Console.WriteLine(p1.Name);
            //Console.WriteLine(p1.IsMan);
            //Console.WriteLine(p1.Age); 
            //p1.GetInfo(true);
            //p1.GetInfoStatic();

            //Person.GetInfoStatic(p1);
            #endregion

        }

    }

    //public class Animal
    //{
    //    public string Name { get; set; }
    //    public string Description { get;  }
    //    public void Run()
    //    {
    //        Console.WriteLine($"名字:{Name}，跑起来，描述：{Description}");
    //    }
    //}
}
