using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookManager
{
   
    internal class BookManager
    {
        

        //属性：
        //- 数据文件路径
        //- JSON序列化配置项
        public string path { get; }
        public JsonSerializerOptions JsonOpts { get; }

        //- 新增数据：强制要求 ==> 将list写入文件中
        public string AddBook(Dictionary<string, dynamic> bookDic)
        {
            List<Dictionary<string, dynamic>> bookList = new();

            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                bookList = JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(json);
                bool resBool = bookList.Exists(item => item["name"].ToString()==bookDic["name"].ToString());
                if (resBool) return "该书籍已存在！！！";
            }

            bookList.Add(bookDic);
            string jsonStr = JsonSerializer.Serialize(bookList, JsonOpts);
            File.WriteAllText(path, jsonStr);

            return "新增数据成功！！！";
        }

        //- 编辑数据
        public string EditBook(Dictionary<string, dynamic> bookDic)
        {
            if(!File.Exists(path)) return "暂时没有书籍，请先添加";
            string str=File.ReadAllText(this.path);
            List<Dictionary<string, dynamic>> list=JsonSerializer.Deserialize <List<Dictionary<string, dynamic>>>(str);
            Dictionary<string, dynamic> findBookDic= list.Find(item => item["name"].ToString() == bookDic["name"]);
            if (findBookDic == null) return "要修改的书籍不存在，请先添加";
            foreach(var item in bookDic)
            {
                findBookDic[item.Key] = bookDic[item.Key];
            }
            File.WriteAllText(this.path, JsonSerializer.Serialize(list, JsonOpts));
            return "编辑成功！！！";
        }


        //- 删除数据
        public string RemoveBook(string bookName)
        {
            if (!File.Exists(this.path)) return "暂时没有书籍，请先添加";
            var json = File.ReadAllText(path);
            List<Dictionary<string, dynamic>>  list = JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(json);
            int index=list.FindIndex(item => item["name"].ToString() == bookName);
            if (index == -1) return "要删除的书籍不存在，请先添加";
            list.RemoveAt(index);

            File.WriteAllText(this.path, JsonSerializer.Serialize(list, this.JsonOpts));

            return "删除成功";
        }


        //- 查询所有数据
        public List<Dictionary<string, dynamic>> SearchBook()
        {
            List<Dictionary<string, dynamic>> list = new();
            if (!File.Exists(path)) return list;
            var json = File.ReadAllText(path);
            list = JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(json);
            return list;
        }


        //- 根据图书名称查询当前图书数据：强制要求
        public Dictionary<string, dynamic> SearchBook(string bookName)
        {
            Dictionary<string, dynamic> bookDic = new();
            if (!File.Exists(path)) return bookDic;
            var json = File.ReadAllText(path);
            List<Dictionary<string, dynamic>> list = JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(json);
            Dictionary<string, dynamic> resDic=list.Find(item => item["name"].ToString() == bookName);
            if (resDic == null) return bookDic;
            return resDic;

        }

        public BookManager(string bookPath, JsonSerializerOptions Opts)
        {
            path = bookPath;
            JsonOpts = Opts;
        }
    }
}
