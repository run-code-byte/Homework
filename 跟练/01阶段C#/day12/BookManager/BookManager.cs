using System;
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
        public string path {  get;  }
        public JsonSerializerOptions JsonOpts { get; }

        //- 新增数据：强制要求 ==> 将list写入文件中
        public string AddBook(Dictionary<string,dynamic> bookDic)
        {
            List<Dictionary<string, dynamic>> bookList = new();

            if (File.Exists(path))
            {
                var json=File.ReadAllText(path);
                bookList=JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(json);
            }
         
                bookList.Add(bookDic);
                string jsonStr=JsonSerializer.Serialize(bookList, JsonOpts);
                File.WriteAllText(path, jsonStr );

            return "新增数据成功！！！";
        }

        //- 编辑数据
        public string EditBook(Dictionary<string, dynamic> bookDic)
        {

            return "ok";
        }


        //- 删除数据
        public string RemoveBook(string bookName)
        {

            return "ok";
        }


        //- 查询所有数据
        public List<Dictionary<string, dynamic>> SearchBook()
        {
            List<Dictionary<string, dynamic>> list = new();
            if (!File.Exists(path)) return list;
            var json=File.ReadAllText(path);
            list=JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(json);
            return list;
        }


        //- 根据图书名称查询当前图书数据：强制要求
        public string SearchBook(string bookName)
        {

            return "ok";
        }

        public BookManager(string bookPath,JsonSerializerOptions Opts)
        {
            path = bookPath;
            JsonOpts= Opts;
        }

    }
}
