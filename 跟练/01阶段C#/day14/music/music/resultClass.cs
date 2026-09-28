using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music
{
    // 根据歌名 请求 响应的json格式数据，将我们需要的数据 
    // 通过自定义类的方式 定义反序列化的数据类型
    public class Song
    {
        public long id { get; set; }
        public List<Artists> artists { get; set; }
    }

    public class Result
    {
        public List<Song> songs { get; set; }
    }

    public class Res
    {
        public Result result { get; set; }
    }

    public class Artists
    {
        public string name { get; set; }
    }
}
