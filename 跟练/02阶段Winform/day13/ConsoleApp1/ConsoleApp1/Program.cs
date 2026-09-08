namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Hello, World!");
            //Console.WriteLine(digui(5));
            //Console.WriteLine(FeiBo(3));
            //Console.WriteLine(FeiBo(4));
            //Console.WriteLine(FeiBo(6));
            //Console.WriteLine(FeiBo(8));
            //Console.WriteLine(FeiBo(10));
            //Console.WriteLine(FeiBo(11));
            Console.WriteLine(GetSum(2));
            Console.WriteLine(GetSum(3));


        }
        static double GetSum(double n)
        {
            if (n == 1) return 1;
            return GetSum(n-1)+(n%2==0?-1/n:1/n);
        }
        static int FeiBo(int n)
        {
            if (n == 1 || n == 2) return 1;
            return FeiBo(n-2)+FeiBo(n-1);
        }
        //static int digui(int num)
        //{
        //    if (num == 1) return 1;
        //    return num+digui(num-1);
        //}

        //static void digui()
        //{
        //    digui();
        //}
    }
}
