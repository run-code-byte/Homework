using System.Text.Json;

namespace BookManager
{
    internal class Program
    {
        

        static void Main(string[] args)
        {

            BookManager BM = new BookManager("./book.json", new JsonSerializerOptions
            {
                WriteIndented = true,
                AllowTrailingCommas = true
            });
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
                        Console.WriteLine("请输入书名");
                        string bookName=Console.ReadLine();
                        Console.WriteLine("请输入作者");
                        string author = Console.ReadLine();
                        Console.WriteLine("请输入标签");
                        string mark = Console.ReadLine();
                        Console.WriteLine("请输入价格");
                        double price = double.Parse(Console.ReadLine());

                        Dictionary<string, dynamic> bookDic = new()
                        {
                            ["name"] = bookName,
                            ["author"]=author,
                            ["isBorrow"]=false,
                            ["id"]=new Random().NextDouble(),
                            ["mark"]=mark,
                            ["price"]=price
                        };

                        string res=BM.AddBook(bookDic);
                        Console.WriteLine(res);
                        break;
                    case "2":
                        Console.WriteLine("--删除图书--");

                        break;
                    case "3":
                        Console.WriteLine("--编辑图书--");

                        break;
                    case "4":
                        Console.WriteLine("--查询所有图书--");
                        var resList = BM.SearchBook();
                        if (resList.Count == 0)
                        {
                            Console.WriteLine("没有书籍，请先添加");
                        }
                        else
                        {
                            foreach( var item in resList)
                            {
                                Console.WriteLine($"书名：{item["name"]}-作者：{item["author"]}-标签：{item["mark"]}-价格：{item["price"]}");
                            }
                        }
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
