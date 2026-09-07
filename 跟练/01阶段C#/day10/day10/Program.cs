using System.ComponentModel;
using System.Security.AccessControl;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace day10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region IO操作
            //var path = @"D:\demo\Homework\跟练\01阶段C#\day10\day10\test.log";
            //var path = "./test.log";
            //var res=File.ReadAllText(path);
            //Console.WriteLine(res);

            //Console.ReadLine();

            //var path = "./test.log";
            //var path = "./day10.log";
            //File.WriteAllText(path, "hello");

            //var path = "./day10.log";
            //File.AppendAllText(path, "eeeee \n");

            //var path = "./day1.log";
            //bool res=File.Exists(path);
            //Console.WriteLine(res);

            //File.Copy("./day10.log", "./day1.log");

            //var path = "./day10.log";
            //File.Delete(path);

            //var path = "./day1.log";
            //File.Move(path, "./day11.log");

            //Action writeLog = () =>
            //{
            //    Console.WriteLine("输入模拟的操作");
            //    string opt = Console.ReadLine();
            //    var date = DateTime.Now;
            //    File.AppendAllText("./content.log", $"{opt}--{date} \n");
            //};

            //writeLog();
            #endregion

            #region 目录操作
            //bool isExists = Directory.Exists("./data");
            //Console.WriteLine(isExists);

            //Directory.CreateDirectory("./data");
            //Directory.CreateDirectory("./log/data");
            //Directory.Delete("./log/data");

            //Directory.Delete("./log", true);

            //string[] files = Directory.GetFiles("./");
            //foreach (string file in files) Console.WriteLine(file);

            //string[] files = Directory.GetDirectories("./");
            //foreach (string file in files) Console.WriteLine(file);

            //string[] files = Directory.GetDirectories("./","*",SearchOption.AllDirectories);
            //foreach (string file in files) Console.WriteLine(file);

            //string[] files = Directory.GetDirectories("./","log*");
            //foreach (string file in files) Console.WriteLine(file);


            //string[] files = Directory.GetFiles("./","day*",SearchOption.AllDirectories);
            //foreach (string file in files) Console.WriteLine(file);

            //Func<string, int> isFileOrDir = path =>
            //{
            //    if (File.Exists(path)) return 1;
            //    if (Directory.Exists(path)) return 2;
            //    return 0;
            //};
            //string[] resArr = ["啥也不是", "是文件", "是文件夹"];
            //int res = isFileOrDir("./content.log");
            //Console.WriteLine(resArr[res]);

            //Func<string, List<string>> getFileAndDir = path =>
            //{
            //    List<string> resList = [];
            //    if (isFileOrDir(path) != 2) throw new Exception("传递参数有误，必须要是目录路径");
            //    string[] files=Directory.GetFiles(path);
            //    resList.AddRange(files);
            //    string[] dirs = Directory.GetDirectories(path);
            //    resList.AddRange(dirs);
            //    return resList;
            //};

            //var res = getFileAndDir("./");
            //foreach(var item in res)Console.WriteLine(item);

            //Func<string, Dictionary<string, string[]>> getFileAndDir = path =>
            //{
            //    var resDic=new Dictionary<string, string[]>();
            //    if (isFileOrDir(path) != 2) throw new Exception("传递参数有误，必须要是目录路径");
            //    string[] files = Directory.GetFiles(path);
            //    resDic["files"]=files;
            //    string[] dirs = Directory.GetDirectories(path);
            //    resDic["dirs"]=dirs;
            //    return resDic;
            //};

            //var res = getFileAndDir("./");
            //foreach (var item in res) {

            //    Console.WriteLine(item.Key);
            //    foreach(var item2 in item.Value) Console.WriteLine(item2);
            //    Console.WriteLine("-----------------------");
            //}
            #endregion

            #region 路径处理
            //var res = Path.Combine(@"D:\a\b", "c", "book,jsonn");
            //Console.WriteLine(res);

            //var path = "D:/demo/ab/ef/book.json";
            //var res = Path.GetFileName(path);
            //Console.WriteLine(res);

            //var path = "D:/demo/ab/ef/book.json";
            //var res = Path.GetExtension(path);
            //Console.WriteLine(res);

            //var path = "D:/demo/ab/ef/book.json";
            //var res = Path.GetDirectoryName(path);
            //Console.WriteLine(res);

            //string[] resArr = File.ReadAllLines("./content.log");
            //foreach(var item in resArr) Console.WriteLine(item);


            //var r=File.ReadLines("./content.log");
            ////Console.WriteLine(r);
            //foreach (string line in r) {
            //    Console.WriteLine(line);

            //}
            #endregion

            List<Dictionary<string, dynamic>> list = new() {
                new Dictionary<string, dynamic>(){
                    ["name"] = "zs",
                    ["age"] = 29,
                    ["isMan"] = true,
                    ["isSingle"] = true,
                    ["salary"] = 4200
                },
                new Dictionary<string, dynamic>(){
                    ["name"] = "ls",
                    ["age"] = 20,
                    ["isMan"] = false,
                    ["isSingle"] = true,
                    ["salary"] = 3400
                },
                new Dictionary<string, dynamic>(){
                    ["name"] = "ww",
                    ["age"] = 19,
                    ["isMan"] = true,
                    ["isSingle"] = false,
                    ["salary"] = 6000
                },
                new Dictionary<string, dynamic>(){
                    ["name"] = "zl",
                    ["age"] = 14,
                    ["isMan"] = false,
                    ["isSingle"] = true,
                    ["salary"] = 2000
                },
                new Dictionary<string, dynamic>(){
                    ["name"] = "sq",
                    ["age"] = 35,
                    ["isMan"] = true,
                    ["isSingle"] = false,
                    ["salary"] = 7000
                },
                new Dictionary<string, dynamic>(){
                    ["name"] = "zb",
                    ["age"] = 27,
                    ["isMan"] = false,
                    ["isSingle"] = true,
                    ["salary"] = 2900
                },
            };

            //var res=list.Where(item => item["isSingle"]);
            //foreach(var item in res)
            //{
            //    Console.WriteLine($"name={item["name"]}--age={item["age"]}--salary={item["salary"]}--isSingle={item["isSingle"]}");
            //}

            //var res = list.Where(item => item["age"]>=18).Select(item=>
            //    {
            //        return new Dictionary<string, dynamic>()
            //        {
            //            ["name"] = item["name"],
            //            ["age"] = item["age"],
            //        };
            //    });
            //foreach (var  item in res) Console.WriteLine($"name={item["name"]}--age={item["age"]}");
            //var res = list.Where(item => item["age"] >= 18).Select(item =>
            //{
            //    return item["name"];
            //});
            //foreach (var item in res) Console.WriteLine(item);

            //var res = list.Where(item => item["age"] >= 18).Select(item =>
            //{
            //    return item["name"] + item["age"];
            //});
            //foreach (var item in res) Console.WriteLine(item);

            //List<object> objs = [10, 20, "abc", true, 10, 12.3];
            //var res = objs.OfType<int>();
            //foreach (var item in res) Console.WriteLine(item);

            //var res=list.OrderBy(item => item["age"]);
            //foreach(var item in res) Console.WriteLine($"name={item["name"]}--age={item["age"]}--salary={item["salary"]}");

            //var res = list.OrderByDescending(item => item["age"]);
            //foreach (var item in res) Console.WriteLine($"name={item["name"]}--age={item["age"]}--salary={item["salary"]}");

            List<Dictionary<string, dynamic>> arr = new() {
                new Dictionary<string, dynamic>() {
                    ["name"] = "zs",
                    ["age"] = 19,
                    ["salary"] = 3888
                },
                new Dictionary<string, dynamic>() {
                    ["name"] = "ls",
                    ["age"] = 14,
                    ["salary"] = 3500
                },
                new Dictionary<string, dynamic>() {
                    ["name"] = "ww",
                    ["age"] = 14,
                    ["salary"] = 3000
                },
                new Dictionary<string, dynamic>() {
                    ["name"] = "zl",
                    ["age"] = 22,
                    ["salary"] = 4000
                },
            };
            //var res = arr.OrderBy(item => item["age"]).ThenBy(item => item["salary"]);
            //foreach (var item in res) Console.WriteLine($"name={item["name"]}--age={item["age"]}--salary={item["salary"]}");

            //var res=arr.DistinctBy(item => item["age"]);
            //foreach(var  item in res) Console.WriteLine($"name={item["name"]}--age={item["age"]}");

            List<Dictionary<string, dynamic>> arr1 = new() {
                new Dictionary<string, dynamic>(){
                    ["name"] = "手机",
                    ["type"] = "电子产品"
                },
                new Dictionary<string, dynamic>(){
                    ["name"] = "香蕉",
                    ["type"] = "水果"
                },
                new Dictionary<string, dynamic>(){
                    ["name"] = "苹果",
                    ["type"] = "水果"
                },
                new Dictionary<string, dynamic>(){
                    ["name"] = "平板",
                    ["type"] = "电子产品"
                },
                new Dictionary<string, dynamic>(){
                    ["name"] = "耳机",
                    ["type"] = "电子产品"
                },
                new Dictionary<string, dynamic>(){
                    ["name"] = "水蜜桃",
                    ["type"] = "水果"
                },
            };

            //var res=arr1.GroupBy(item => item["type"]);
            //foreach(var item in res) {
            //    Console.WriteLine(item.Key);
            //    foreach (var item2 in item) {
            //        Console.WriteLine($"{item2["name"]}--{item2["type"]}");
            //    }
            //};

            //var res=list.FirstOrDefault(item => item["age"] > 18);
            //Console.WriteLine($"name={res["name"]}--age={res["age"]}");

            //var res = list.LastOrDefault(item => item["age"] > 18);
            //Console.WriteLine($"name={res["name"]}--age={res["age"]}");

            //bool r = list.Any(item => item["age"] < 10);
            //Console.WriteLine(r);

            //bool r = list.All(item => item["salary"] > 500);
            //Console.WriteLine(r);

            //int count = list.Count;
            //Console.WriteLine(count);

            list.Sum();

            int sum = list.Sum(item => item["salary"]);




            //Console.WriteLine( sum);

            //double avg = list.Average(item => item["salary"]);
            //Console.WriteLine(avg);

            //double max = list.Max(item => item["salary"]);
            //Console.WriteLine(max);
            //double min = list.Min(item => item["salary"]);
            //Console.WriteLine(min);
        }
    }
}
