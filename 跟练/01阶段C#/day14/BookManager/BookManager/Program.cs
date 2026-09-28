using System.Text.Json;
using System.Text.RegularExpressions;

namespace BookManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<Dictionary<string, dynamic>> ls = new()
            //{
            //    new Dictionary<string, dynamic>()
            //    {
            //        ["a"]=10,
            //        ["b"]=20,
            //        ["c"]=30,
            //    },
            //    new Dictionary<string, dynamic>()
            //    {
            //        ["a"]=100,
            //        ["b"]=200,
            //        ["c"]=300,
            //    }

            //};
            //var dic = ls.Find(item => item["c"]==30);
            //dic["c"] = 33333;

            //foreach(var it in ls)
            //{
            //    foreach(var item in it) Console.WriteLine($"{item.Key}--{item.Value}");
            //}


            //return;

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
                        string bookName = Console.ReadLine();
                        Console.WriteLine("请输入作者");
                        string author = Console.ReadLine();
                        Console.WriteLine("请输入标签");
                        string mark = Console.ReadLine();
                        Console.WriteLine("请输入价格");
                        //double price = double.Parse(Console.ReadLine());
                        string priceStr= Console.ReadLine();
                        //@"^[1-9]+[0-9]*(\.[0-9]+)?$"
                        if(Regex.IsMatch(priceStr, @"^[1-9]+[0-9]*(\.[0-9]+)?$"))
                        {
                            Dictionary<string, dynamic> bookDic = new()
                            {
                                ["name"] = bookName,
                                ["author"] = author,
                                ["isBorrow"] = false,
                                ["id"] = new Random().NextDouble(),
                                ["mark"] = mark,
                                ["price"] = double.Parse(priceStr)
                            };

                            string res = BM.AddBook(bookDic);
                            Console.WriteLine(res);
                        }
                        else Console.WriteLine("输入的价格格式有误");
                        break;
                    case "2":
                        Console.WriteLine("--删除图书--");
                        string removeBN= Console.ReadLine();
                        string reStr = BM.RemoveBook(removeBN);
                        Console.WriteLine(reStr);
                        break;
                    case "3":
                        Console.WriteLine("--编辑图书--");
                        Console.WriteLine("请输入书名");
                        string editBookName = Console.ReadLine();
                        Console.WriteLine("请输入作者");
                        string editAuthor = Console.ReadLine();
                        Console.WriteLine("请输入标签");
                        string editMark = Console.ReadLine();
                        Console.WriteLine("请输入价格");
                        double editPrice = double.Parse(Console.ReadLine());
                        Dictionary<string, dynamic> editBook = new()
                        {
                            ["name"] = editBookName,
                            ["author"] = editAuthor,
                            ["mark"] = editMark,
                            ["price"] = editPrice
                        };
                        string resEditStr=BM.EditBook(editBook);
                        Console.WriteLine(resEditStr);
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
                            foreach (var item in resList)
                            {
                                Console.WriteLine($"书名：{item["name"]}-作者：{item["author"]}-标签：{item["mark"]}-价格：{item["price"]}");
                            }
                        }
                        break;
                    case "5":
                        Console.WriteLine("--查询单个图书--");
                        Console.WriteLine("请输入查询的书名");
                        string SearchBookName = Console.ReadLine();
                        var resBook = BM.SearchBook(SearchBookName);
                        if(resBook.Count==0) Console.WriteLine("没有找到对应的数据，请先添加");
                        else
                        {
                           Console.WriteLine($"书名：{resBook["name"]}-作者：{resBook["author"]}-标签：{resBook["mark"]}-价格：{resBook["price"]}");
                        }
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
