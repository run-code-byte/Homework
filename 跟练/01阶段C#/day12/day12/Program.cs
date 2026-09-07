namespace day12
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

            //Animal Bird= new Animal();
            //Bird.Name = "麻雀";
            //Console.WriteLine(Bird.Name);
            ////Bird.Description = "我能飞";
            //Bird.Run();

            //Console.WriteLine("=========================");
            //Animal Dog=new Animal();
            //Dog.Name = "旺财";
            //Dog.Run();

            Person p1 = new Person();
            //Console.WriteLine(p1.Name);
            //Console.WriteLine(p1.IsMan);
            //Console.WriteLine(p1.Age); 
            //p1.GetInfo(true);
            //p1.GetInfoStatic();

            Person.GetInfoStatic(p1);
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
