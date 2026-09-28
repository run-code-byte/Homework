namespace day13
{
    internal class Program
    {
        static void Main(string[] args)
        {

            GetAndSet gs=new GetAndSet();
            //gs.X = 12;
            //gs.setX(1000);
            //Console.WriteLine(gs.X);

            gs.N = 10;
            gs.N = 999;
            Console.WriteLine(gs.N);




            //    ThisClass1 ThisObj = neSw ThisClass1()
            //    {
            //        N = 999
            //    };
            //Console.WriteLine(ThisObj.GetThis()==ThisObj);
            //ThisObj.SetN(100);
            //Console.WriteLine(ThisObj.N);
            //ThisObj.CallFn();

            //new BankCard("11112222","未知户主");
            //new BankCard("11112223","未知户主");
            //new BankCard("11112224","未知户主");
            //new BankCard("11112225","未知户主");
            //new BankCard("11112226","未知户主");

            //new BankCard("11112226");
            //new BankCard("11112228","zs");

            //var b=new BankCard("11112228", "zs");
            //b[0] = 111;
            //Console.WriteLine(b[0]);

            //A zsA=new A()
            //{
            //    Name = "zs"
            //};
            //zsA.SayHi(10);
            //zsA.SayHello();

            //Console.WriteLine(new Random().Next(1, 10));
            //Console.WriteLine(Tool.GetRanL());
            //Console.WriteLine(Tool.GetRanI(10));
            //Console.WriteLine(Tool.GetRanD());

            //new AbstractClass();
            //Son son1=new Son();
            //son1.Hi(10, "111");
            //Console.WriteLine(son1.IsMan);
            //son1.Say();
        }
    }
}
