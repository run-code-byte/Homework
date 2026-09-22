namespace day13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ThisClass1 ThisObj = new ThisClass1()
            {
                N = 999
            };
            //Console.WriteLine(ThisObj.GetThis()==ThisObj);
            //ThisObj.SetN(100);
            //Console.WriteLine(ThisObj.N);
            ThisObj.CallFn();


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
