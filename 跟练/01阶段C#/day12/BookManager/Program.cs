namespace BookManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string num = "";
            while (num != "0")
            {
                // 提示信息
                Console.WriteLine("=====欢迎来到图书管理系统=====");
                Console.WriteLine("1: 新增图书");
                Console.WriteLine("2: 删除图书");
                Console.WriteLine("3: 编辑图书");
                Console.WriteLine("4: 查询所有图书");
                Console.WriteLine("5: 查询单个图书");
                Console.WriteLine("0: 退出");
                num = Console.ReadLine();

                string username = "youke";
                string result = "";

                switch (num)
                {
                    case "1":
                        Console.WriteLine("--新增图书--");

                        break;
                    case "2":
                        Console.WriteLine("--删除图书--");

                        break;
                    case "3":
                        Console.WriteLine("--编辑图书--");

                        break;
                    case "4":
                        Console.WriteLine("--查询所有图书--");

                        break;
                    case "5":
                        Console.WriteLine("--查询单个图书--");

                        break;
                    case "0":
                        Console.WriteLine("--退出--");
                        break;
                    default:
                        Console.WriteLine("******输入有误******");
                        break;
                }
            }
        }
    }
}
