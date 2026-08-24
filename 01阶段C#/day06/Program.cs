using System.Text.RegularExpressions;

namespace day06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 昨天作业跟打
            // 商品数据
            //List<Dictionary<string, dynamic>> goodsList = new List<Dictionary<string, dynamic>>
            //{
            //    new Dictionary<string, dynamic>
            //    {
            //        {"name", "机械键盘"},
            //        {"price", 299.99},
            //        {"code", "G001"},
            //        {"stock", 120}
            //    },
            //    new Dictionary<string, dynamic>
            //    {
            //        {"name", "无线鼠标"},
            //        {"price", 89.50},
            //        {"code", "G002"},
            //        {"stock", 356}
            //    },
            //    new Dictionary<string, dynamic>
            //    {
            //        {"name", "27寸显示器"},
            //        {"price", 1299.00},
            //        {"code", "G003"},
            //        {"stock", 48}
            //    },
            //    new Dictionary<string, dynamic>
            //    {
            //        {"name", "电竞耳机"},
            //        {"price", 199.00},
            //        {"code", "G004"},
            //        {"stock", 85}
            //    },
            //    new Dictionary<string, dynamic>
            //    {
            //        {"name", "电脑支架"},
            //        {"price", 69.90},
            //        {"code", "G005"},
            //        {"stock", 210}
            //    }
            //};
            //提示输入的 是price还是stock  排序类型
            //提示输入的是 ASC 还是DSC     排序顺序(ASC升序, DSC降序)
            // 根据输入完成数据排序
            //Console.WriteLine("请输入排序类型(price/stock )");
            //string sortType = Console.ReadLine();
            //Console.WriteLine("请输入排序方式(ASC升序，DEC降序 )");
            //string sortMethod = Console.ReadLine();
            //if (sortType == "price" || sortType == "stock")
            //{
            //    for (int i = 0; i < goodsList.Count - 1; i++)
            //    {
            //        if (sortMethod == "ASC")
            //        {
            //            for (int j = 0; j < goodsList.Count - 1 - i; j++)
            //            {
            //                if (goodsList[j][sortType] > goodsList[j + 1][sortType])
            //                {
            //                    var tmp= goodsList[j];
            //                    goodsList[j]=goodsList[j + 1];
            //                    goodsList[j+1]=tmp;
            //                }
            //            }
            //        }
            //        else if (sortMethod == "DEC")
            //        {
            //            for (int j = 0; j < goodsList.Count - 1 - i; j++)
            //            {
            //                if (goodsList[j][sortType] < goodsList[j + 1][sortType])
            //                {
            //                    var tmp = goodsList[j];
            //                    goodsList[j] = goodsList[j + 1];
            //                    goodsList[j + 1] = tmp;
            //                }
            //            }
            //        }
            //        else Console.WriteLine("输入排序方式有误！");
            //    }


            //}
            //else Console.WriteLine("输入排序类型有误！");
            //foreach(var item in goodsList) Console.WriteLine($"{item["name"]}--price:{item["price"]}--stock:{item["stock"]}");

            // 作业2
            //List<Dictionary<string, dynamic>> singerList = new()
            //{
            //    new Dictionary<string, dynamic>
            //    {
            //        {"singerId", 1001},
            //        {"singerName", "周杰伦"},
            //        {"genre", "流行"}
            //    },
            //    new Dictionary<string, dynamic>
            //    {
            //        {"singerId", 1002},
            //        {"singerName", "林俊杰"},
            //        {"genre", "华语流行"}
            //    },
            //    new Dictionary<string, dynamic>
            //    {
            //        {"singerId", 1003},
            //        {"singerName", "邓紫棋"},
            //        {"genre", "流行、摇滚"}
            //    },
            //    new Dictionary<string, dynamic>
            //    {
            //        {"singerId", 1004},
            //        {"singerName", "薛之谦"},
            //        {"genre", "抒情流行"}
            //    },
            //    new Dictionary<string, dynamic>
            //    {
            //        {"singerId", 1005},
            //        {"singerName", "毛不易"},
            //        {"genre", "民谣流行"}
            //    }
            //};
            //List<Dictionary<string, dynamic>> songList = new()
            //{
            //    new Dictionary<string, dynamic>
            //    {
            //        {"songId", 10001},
            //        {"singerId", 1001},
            //        {"songName", "青花瓷"},
            //        {"duration", 239}
            //    },
            //    new Dictionary<string, dynamic>
            //    {
            //        {"songId", 10002},
            //        {"singerId", 1001},
            //        {"songName", "发如雪"},
            //        {"duration", 253}
            //    },
            //    new Dictionary<string, dynamic>
            //    {
            //        {"songId", 10003},
            //        {"singerId", 1001},
            //        {"songName", "东风破"},
            //        {"duration", 215}
            //    },
            //    new Dictionary<string, dynamic>
            //    {
            //        {"songId", 1004},
            //        {"singerId", 3002},
            //        {"songName", "不为谁而作的歌"},
            //        {"duration", 296}
            //    },
            //    new Dictionary<string, dynamic>
            //    {
            //        {"songId", 1005},
            //        {"singerId", 1002},
            //        {"songName", "背对背拥抱"},
            //        {"duration", 262}
            //    }
            //};
            //// 通过歌曲查找歌手
            //Console.WriteLine("输入歌曲名:");
            //string song=Console.ReadLine();
            //int singerId = 0;
            //string singerName = "";
            //for(int i=0; i<songList.Count; i++)
            //{
            //    if (song == songList[i]["songName"])singerId = songList[i]["singerId"];
            //}
            //foreach(var singer in singerList)
            //{
            //    if (singerId == singer["singerId"]) singerName = singer["singerName"];
            //}
            //if (singerName != "")
            //{
            //    Console.WriteLine($"{song}是{singerName}演唱的");
            //}
            //else
            //{
            //    Console.WriteLine($"{singerName}演唱者找不到");
            //}
            #endregion


            #region 课堂跟练
            // Replace：将字符串中指定的子串都替换成的新的子串
            //string str = "abacdaeafeeg";
            ////Console.WriteLine(str.Replace("a","0"));
            //Console.WriteLine(str.Replace("ee","**"));

            // 敏感词替换为 * , 而且个数要保持一致
            //string str = "生活总会有大麻烦, 黑夜总会过去";
            //// 假设list存储敏感词
            //List<string> mgc = ["大麻", "夜总会"];
            //string res = "";
            //Console.WriteLine(res=str.Replace(mgc[0],"**"));
            //Console.WriteLine(res.Replace(mgc[1], "**"));

            //foreach(string s in mgc)
            //{
            //    string newStr = "";
            //    for (int i = 0; i < s.Length; i++) newStr += "*";
            //    str=str.Replace(s, newStr);
            //}
            //Console.WriteLine(str);

            // 生活总会有**烦, 黑***过去



            //分割字符串 Split
            //例：`"you love i"`转成`"I Love You"`
            //string oldStr = "you love i";
            //string[] strArr = oldStr.Split();
            //List<string> list = new();
            //foreach(string str in strArr) list.Add(str);
            //list.Reverse();
            //string resStr = "";
            //foreach(string str1 in list)
            //{

            //    string first=str1.Substring(0,1).ToUpper();
            //    string last =str1.Substring(1).ToLower();
            //    resStr+= first+last+" ";
            //}
            //Console.WriteLine(resStr.Substring(0,resStr.Length-1));

            #endregion

            #region 今天作业
            //-提取一句话中所有的中文姓名
            //string str = "hello, I am 刘德华,your name is 黎明?";
            //var reg = @"[\u4e00-\u9fa5]{2,4}";
            //var res = Regex.Matches(str, reg);
            //foreach (var item in res) Console.WriteLine(item);

            //-替换所有多余空格
            //string str = "abc  dd  ee  ff  gg  HH  h j k";
            //string reg = @"\s{2,5}";
            //var res = Regex.Replace(str, reg, " ");
            //Console.WriteLine(res);

            //-身份证号码
            //string str = "我的身份证号是: 360731200111052112,你的身份证是: 42108320041119211X";
            //// 书写正则, 找到字符串中的身份证号及 出生年,月,日
            ////string reg = @"\d{6}(\d{4})(\d{2})(\d{2})\d{4}";
            //string reg = @"\d{6}(\d{4})(\d{2})(\d{2})\d{3}[\dXx]";
            ////var rss=Regex.Matches(str, reg);
            ////foreach (var r in rss) Console.WriteLine(r.);
            //MatchCollection rss = Regex.Matches(str, reg);
            //foreach (Match r in rss)
            //{
            //    Console.WriteLine($"完整身份证：{r.Value}");
            //    // 捕获组：Group[1]年，Group[2]月，Group[3]日
            //    Console.WriteLine($"出生年：{r.Groups[1].Value}");
            //    Console.WriteLine($"出生月：{r.Groups[2].Value}");
            //    Console.WriteLine($"出生日：{r.Groups[3].Value}");
            //    Console.WriteLine("----------");
            //}

            //-密码强度检测：强中弱（字母、数字、特殊符号）
            // 请输入密码（字母、数字、特殊符号）
            //密码中可以有数字,字母,特殊符号;长度要求8~15 
            //如果只有一种则 强度为弱
            //如果只有两种则 强度为中
            //如果两种都有则 强度为强

            //验证密码长度是否符合,并输出密码强度
            //Console.WriteLine("请输入密码：");
            //string password = Console.ReadLine();
            //if (Regex.IsMatch(password, @".{8,15}"))
            //{
            //    int n = 0;
            //    var reg1 = @"\d{8,15}";
            //    var reg2 = @"\d{8,15}";
            //    var reg3 = @"\d{8,15}";

            //}

            //Console.WriteLine("请输入密码：");
            //string password = Console.ReadLine();

            //// 第一步：判断长度 8~15位
            //if (!Regex.IsMatch(password, @"^.{8,15}$"))
            //{
            //    Console.WriteLine("密码长度不符合！需要8‑15位");
            //    return;
            //}

            //int count = 0;

            //// 判断是否包含数字
            //if (Regex.IsMatch(password, @"\d"))
            //    count++;

            //// 判断是否包含字母(大小写)
            //if (Regex.IsMatch(password, @"[a-zA-Z]"))
            //    count++;

            //// 判断是否包含特殊符号：非数字、非字母就是特殊符号
            //if (Regex.IsMatch(password, @"[^0-9a-zA-Z]"))
            //    count++;

            //string level = "";
            //if (count == 1)
            //    level = "弱";
            //else if (count == 2)
            //    level = "中";
            //else if (count == 3)
            //    level = "强";

            //Console.WriteLine($"密码强度：{level}");


            #endregion
        }
    }
}
