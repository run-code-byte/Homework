namespace day09
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region 作业
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

            // 作业1
            // Find: 要求查找年龄小于20的
            //var person = list.Find(item => {
            //    return item["age"] < 20;
            //});
            //foreach(var i in person) Console.WriteLine(i);

            // FindLast: 要求查找年龄大于25的
            //var person = list.FindLast(item => { return item["age"] > 25; });
            //foreach(var i in person) Console.WriteLine(i);

            // FindAll: 找出性别男的
            //var person = list.FindAll(item => { return item["isMan"] ==true; });
            //foreach (var i in person) Console.WriteLine(i["name"]);

            // FindIndex: 找出薪水大于5000
            //var person = list.FindIndex(item => { return item["salary"] >5000; });
            //Console.WriteLine(person);

            // FindLastIndex: 找出薪水小于3000
            //var person = list.FindLastIndex(item => { return item["salary"] <3000; });
            //Console.WriteLine(person);

            // Exists: 判断是否有薪水大于5000
            //bool resBool = list.Exists(item => { return item["salary"] > 5000; });
            //Console.WriteLine(resBool);

            // ForEach: 输出每个的 名字-年龄-薪水
            //Action<Dictionary<string, dynamic>> fn = n => Console.WriteLine($"{n["name"]}-{n["age"]}-{n["salary"]}");
            //list.ForEach(fn);

            // ConvertAll: 映射得到一个薪水的list
            //List<dynamic> salaryList = list.ConvertAll(item => item["salary"] * 1.2);
            //foreach(var i in salaryList) Console.WriteLine(i);

            //TrueForAll: 判断是否都成年
            //bool isAdaul = list.TrueForAll(item => item["age"] >= 18);
            //Console.WriteLine(isAdaul);


            //作业2: 封装一个函数 接收一个字符串; 返回一个字典,键是字符串的每个字符,键值是这个字符在字符串中出现的次数
            //string str = "asdfoigwerkla";
            //Func<string,Dictionary<string,int>> dic = str =>
            //{
            //    Dictionary<string, dynamic> newDic = new Dictionary<string, dynamic>();
            //    int count = 1;
            //    for (int i = 0; i < str.Length; i++)
            //    {
            //        newDic.Add(str.Substring(i, 1), count);
            //        count++;
            //    }
            //    return newDic;
            //};
            //dynamic t= dic(str);
            //foreach(dynamic i in t) Console.WriteLine( i);

            // Func<输入类型,返回类型>
            Func<string, Dictionary<char, int>> countFunc = s =>
            {
                Dictionary<char, int> dict = new Dictionary<char, int>();
                foreach (char c in s)
                {
                    if (dict.ContainsKey(c)) dict[c]++;
                    else dict[c] = 1;
                }
                return dict;
            };

       
                string str = "asdfoigwerkla";
                var result = countFunc(str);
                foreach (var item in result)
                {
                    Console.WriteLine($"{item.Key} → {item.Value}");
                }
            



            #endregion
        }
    }
}
