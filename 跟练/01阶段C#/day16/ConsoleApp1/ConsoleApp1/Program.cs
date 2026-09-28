namespace ConsoleApp1
{
    enum Gender
    {
        MAN,
        WOMAN,
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Gender a = Gender.MAN;
            //Gender b = a;
            //Console.WriteLine(b);
            //b = Gender.WOMAN;
            //Console.WriteLine(b);
            //Console.WriteLine(a);
            //Console.WriteLine(a.GetType());
            //Console.WriteLine(a.GetType().IsValueType);
            //Console.WriteLine((10).GetType().IsValueType);
            //Console.WriteLine((new { }).GetType().IsValueType);

            //List<Object> ls = [1, 2, "3dsvf", true, new List<int>()];

            //object obj = 100;
            //int num =(int) obj;

            Student s=new Student()
            {
                Id= 1,
                Name="heiehei"
            };
            s.ShowId();
            s.ShowName();
        }
    }
}
