using System.Collections.Generic;

namespace day05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 课堂跟练
            //List去重
            //思路1：遍历每个元素，让这个元素跟他后面的每一个元素都做比较，相等就删掉
            //List<int> ints = [1, 3, 3, 3, 3, 4, 5, 6, 7, 7, 8, 6, 4, 2, 3];
            //for (int i = 0; i < ints.Count; i++)
            //{
            //  for(int j = i+1;j< ints.Count; j++)
            //    {
            //        if (ints[i] == ints[j])
            //        {
            //            ints.RemoveAt(j);
            //            j--;
            //        }
            //    }
            //}
            //foreach (int i in ints) Console.WriteLine(i);


            //思路2：找元素最后一次出现的下标，跟第一次出现的下标是否相等，相等就表示元素没有重复，不相等就表示有重复，要删除掉最后一个重复元素。
            //List<int> ints = [1, 3, 3, 3, 3, 4, 5, 6, 7, 7, 8, 9, 6, 4, 2, 3];
            //for (int i = 0; i < ints.Count; i++)
            //{
            //    while (true)
            //    {
            //        int index = ints.LastIndexOf(ints[i]);
            //        if (ints.LastIndexOf(ints[i]) != i) ints.RemoveAt(index);
            //        else break;
            //    }
            //}
            //foreach (int i in ints) Console.WriteLine(i);

            //思路3：利用字典中的键是唯一的，将List中每个数据都作为字典的键，最终在字典中的键都是唯一的，将所有键放在一个新的List中
            //List<int> ints = [1, 3, 3, 3, 3, 4, 5, 6, 7, 7, 8, 6, 4, 2, 3];
            //Dictionary<int, dynamic> tmpDic = new();
            //foreach (int i in ints)
            //{
            //    tmpDic[i] = "无所谓";

            //}
            //List<int> newList = tmpDic.Keys.ToList();
            //foreach (int i in newList) Console.WriteLine(i);


            //思路4：创建一个新的List，遍历原本的List，原本List中的每一个元素，放在新的List中进行判断是否存在，如果不存在就添加到新的List中，如果存在就不添加
            //List<int> ints = [1, 3, 3, 3, 3, 4, 5, 6, 7, 7, 8, 6, 4, 2, 3];
            //List<int> newInts = [];
            //foreach (int i in ints) {
            //    if (!(newInts.Contains(i))) {
            //        newInts.Add(i); 
            //    }
            //}
            //foreach (int i in newInts) Console.WriteLine(i);

            //让每相邻的两个元素比较大小，如果不满足顺序，就交换他俩的位置。小到大
            //List<int> list = [5, 3, 4, 6, 7, 8, 9, 1, 2];
            //for(int j=0; j<list.Count-1; j++)
            //{
            //    for(int i=0; i<list.Count-1-j; i++)
            //    {
            //        if (list[i] > list[i + 1])
            //        {
            //            int tmp=list[i];
            //            list[i]=list[i+1];
            //            list[i+1]=tmp;
            //        }
            //    }
            //}
            //foreach(int i in list) Console.WriteLine(i);


            //例子：商品按照价格排序：
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
            // 按照价格做排序
            //for(int i = 0; i < goodsList.Count-1; i++)
            //{
            //    for(int j = 0; j < goodsList.Count-1-i; j++)
            //    {
            //        if (goodsList[j]["price"] > goodsList[j + 1]["price"])
            //        {
            //            dynamic tmp = goodsList[j];
            //            goodsList[j]=goodsList[j + 1];
            //            goodsList[j+1]=tmp;
            //        }
            //    }
            //}
            //foreach(dynamic good in goodsList) Console.WriteLine($"{good["name"]}-{good["price"]}");


            //1、通过歌手查找歌曲集合
            //List<Dictionary<string, dynamic>> singerList = new List<Dictionary<string, dynamic>>
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

            //List<Dictionary<string, dynamic>> songList = new List<Dictionary<string, dynamic>>
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

            //Console.WriteLine("请输入歌手姓名");
            //string singer=Console.ReadLine();
            //int singerId = 0;
            //foreach(Dictionary<string,dynamic> item in singerList)
            //{
            //    if (item["singerName"] == singer) singerId = item["singerId"];
            //}
            //var singerSongs = new List<Dictionary<string, dynamic>>();
            //foreach(Dictionary<string,dynamic> item in songList)
            //{
            //    if (item["singerId"] == singerId) singerSongs.Add(item);
            //}
            //foreach(dynamic item in singerSongs)
            //{
            //    Console.WriteLine(item["songName"]);
            //}




            #endregion



            #region 05day作业
            // 提示输入的 是price还是stock  排序类型 
            // 提示输入的是 ASC 还是DSC     排序顺序(ASC升序,DSC降序)
            // 根据输入完成数据排序
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
            //Console.WriteLine("输入排序类型（price/stock)：" );
            //string type =Console.ReadLine();
            //if (type == "price" || type == "stock") 
            //{
            //    Console.WriteLine("输入的排序类型（price/stock)：" + type);
            //    Console.WriteLine("输入排序顺序(ASC/DSC)：");
            //    string xu = Console.ReadLine();
            //    if (type == "price")
            //    {
            //        if (xu == "ASC" || xu == "DSC")
            //        {
            //            Console.WriteLine("输入的排序类型（price/stock)：" + type);
            //            if (xu == "ASC")
            //            {
            //                Console.WriteLine($"{type}数据{xu}排序:");
            //                for (int i = 0; i < goodsList.Count - 1; i++)
            //                {
            //                    for (int j = 0; j < goodsList.Count - 1 - i; j++)
            //                    {
            //                        if (goodsList[j]["price"] > goodsList[j + 1]["price"])
            //                        {
            //                            dynamic tmp = goodsList[j];
            //                            goodsList[j] = goodsList[j + 1];
            //                            goodsList[j + 1] = tmp;
            //                        }
            //                    }
            //                }
            //                foreach (dynamic good in goodsList) Console.WriteLine($"{good["name"]}-{good["price"]}");
            //            }
            //            else
            //            {
            //                Console.WriteLine($"{type}数据{xu}排序:");
            //                for (int i = 0; i < goodsList.Count - 1; i++)
            //                {
            //                    for (int j = 0; j < goodsList.Count - 1 - i; j++)
            //                    {
            //                        if (goodsList[j]["price"] < goodsList[j + 1]["price"])
            //                        {
            //                            dynamic tmp = goodsList[j];
            //                            goodsList[j] = goodsList[j + 1];
            //                            goodsList[j + 1] = tmp;
            //                        }
            //                    }
            //                }
            //                foreach (dynamic good in goodsList) Console.WriteLine($"{good["name"]}-{good["price"]}");
            //            }
            //        }
            //        else Console.WriteLine("输入有误");
            //    }
            //    else
            //    {
            //        if (xu == "ASC" || xu == "DSC")
            //        {
            //            Console.WriteLine("输入的排序类型（price/stock)：" + type);
            //            if (xu == "ASC")
            //            {
            //                Console.WriteLine($"{type}数据{xu}排序:");
            //                for (int i = 0; i < goodsList.Count - 1; i++)
            //                {
            //                    for (int j = 0; j < goodsList.Count - 1 - i; j++)
            //                    {
            //                        if (goodsList[j]["stock"] > goodsList[j + 1]["stock"])
            //                        {
            //                            dynamic tmp = goodsList[j];
            //                            goodsList[j] = goodsList[j + 1];
            //                            goodsList[j + 1] = tmp;
            //                        }
            //                    }
            //                }
            //                foreach (dynamic good in goodsList) Console.WriteLine($"{good["name"]}-{good["stock"]}");
            //            }
            //            else
            //            {
            //                Console.WriteLine($"{type}数据{xu}排序:");
            //                for (int i = 0; i < goodsList.Count - 1; i++)
            //                {
            //                    for (int j = 0; j < goodsList.Count - 1 - i; j++)
            //                    {
            //                        if (goodsList[j]["stock"] < goodsList[j + 1]["stock"])
            //                        {
            //                            dynamic tmp = goodsList[j];
            //                            goodsList[j] = goodsList[j + 1];
            //                            goodsList[j + 1] = tmp;
            //                        }
            //                    }
            //                }
            //                foreach (dynamic good in goodsList) Console.WriteLine($"{good["name"]}-{good["stock"]}");
            //            }
            //        }
            //        else Console.WriteLine("输入有误");
            //    }
            //} 
            //else Console.WriteLine("输入有误");


            // 通过歌曲查找歌手
            //List<Dictionary<string, dynamic>> singerList = new List<Dictionary<string, dynamic>>
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

            //List<Dictionary<string, dynamic>> songList = new List<Dictionary<string, dynamic>>
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

            //Console.WriteLine("输入歌曲名称：");
            //string song = Console.ReadLine();
            //int singerId = 0;
            //foreach (Dictionary<string, dynamic> item in songList)
            //{
            //    if (item["songName"] == song) singerId = item["singerId"];
            //}
            //var singerNames = new List<Dictionary<string, dynamic>>();
            //foreach (Dictionary<string, dynamic> item in singerList)
            //{
            //    if (item["singerId"] == singerId) singerNames.Add(item);
            //}
            //foreach (dynamic item in singerNames)
            //{
            //    Console.WriteLine(item["singerName"]);
            //}
            


            #endregion
        }

    }
}
