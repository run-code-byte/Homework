namespace day09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<Dictionary<string, dynamic>> list = new() {
            //    new Dictionary<string, dynamic>(){
            //        ["name"] = "zs",
            //        ["age"] = 29,
            //        ["isMan"] = true,
            //        ["isSingle"] = true,
            //        ["salary"] = 4200
            //    },
            //    new Dictionary<string, dynamic>(){
            //        ["name"] = "ls",
            //        ["age"] = 20,
            //        ["isMan"] = false,
            //        ["isSingle"] = true,
            //        ["salary"] = 3400
            //    },
            //    new Dictionary<string, dynamic>(){
            //        ["name"] = "ww",
            //        ["age"] = 19,
            //        ["isMan"] = true,
            //        ["isSingle"] = false,
            //        ["salary"] = 6000
            //    },
            //    new Dictionary<string, dynamic>(){
            //        ["name"] = "zl",
            //        ["age"] = 14,
            //        ["isMan"] = false,
            //        ["isSingle"] = true,
            //        ["salary"] = 2000
            //    },
            //    new Dictionary<string, dynamic>(){
            //        ["name"] = "sq",
            //        ["age"] = 35,
            //        ["isMan"] = true,
            //        ["isSingle"] = false,
            //        ["salary"] = 7000
            //    },
            //    new Dictionary<string, dynamic>(){
            //        ["name"] = "zb",
            //        ["age"] = 27,
            //        ["isMan"] = false,
            //        ["isSingle"] = true,
            //        ["salary"] = 2900
            //    },
            //};
            // 作业1
            // Find: 要求查找年龄小于20的
            //var r1 = list.Find(item => item["age"] < 20);
            //Console.WriteLine($"{r1["name"]}-{r1["age"]}");

            // FindLast: 要求查找年龄大于25的
            //var r2 = list.FindLast(i => i["age"] > 25);
            //Console.WriteLine($"{r2["name"]}-{r2["age"]}");

            // FindAll: 找出性别男的
            //var r3 = list.FindAll(i => i["isMan"]);
            //foreach (var i in r3) Console.WriteLine($"{i["name"]}-{i["isMan"]}");

            // FindIndex: 找出薪水大于5000
            //var r4 = list.FindIndex(i => i["salary"] > 5000);
            //Console.WriteLine(r4);

            // FindLastIndex: 找出薪水小于3000
            //var r5 = list.FindIndex(i => i["salary"] < 3000);
            //Console.WriteLine(r5);

            // Exists: 判断是否有薪水大于5000
            //var r6 = list.Exists(i => i["salary"] > 5000);
            //Console.WriteLine(r6);

            // ForEach: 输出每个的 名字-年龄-薪水
            //list.ForEach(x => Console.WriteLine($"名字{x["name"]}-年龄{x["age"]}-薪水{x["salary"]}"));

            // ConvertAll: 映射得到一个所以薪水的list
            //var r8 = list.ConvertAll(x => x["salary"]);
            //Console.WriteLine(string.Join("-", r8));

            //TrueForAll: 判断是否都成年
            //var r9 = list.TrueForAll(x => x["age"] > 18);
            //Console.WriteLine(r9);


            //作业2: 封装一个函数 接收一个字符串; 返回一个字典,键是字符串的每个字符,键值是这个字符在字符串中出现的次数
            //Func<string, Dictionary<char, int>> getCount = str =>
            //{
            //    Dictionary<char, int> resDic = new Dictionary<char, int>();
            //    for(int i = 0; i < str.Length; i++)
            //    {
            //        if (resDic.ContainsKey(str[i])) resDic[str[i]]++;
            //        else resDic[str[i]] = 1;
            //    }
            //    return resDic;
            //};
            //var res = getCount("afaaaaaaaafefeasfffffffefieegeogioewieiowowojgoiwnjfnnxckxnkcjxk");
            //foreach(var item in res) Console.WriteLine($"{item.Key}-{item.Value}");
        }
    }
}
