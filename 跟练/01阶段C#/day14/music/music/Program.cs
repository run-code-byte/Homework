using System.Text.Json;

namespace music
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // 根据用户输入歌曲名，调用网易云搜索接口获取歌曲id、歌手信息
            Console.WriteLine("---请输入歌曲名---");
            string songName = Console.ReadLine();

            // 实例化HttpClient
            var httpclient = new HttpClient();

            // URL 地址拼接
            string url = $"http://music.163.com/api/search/get/web?s={songName}&type=1&limit=10";

            // 发送GET异步http请求，获取接口返回的json字符串
            string json = await httpclient.GetStringAsync(url);

            // 将json字符串反序列化为自定义类 res 类型
            var ress = JsonSerializer.Deserialize<Res>(json);

            // 遍历输出搜索结果，展示序号、歌手、歌曲id                        
            List<Song> songsList = ress.result.songs;
            for (int i = 0; i < songsList.Count; i++)
            {
                var songSinger = songsList[i].artists[0].name; //获取歌手
                var songID = songsList[i].id;// 获取歌曲ID
                Console.WriteLine($"{i + 1} : {songSinger}  歌曲ID：{songID}");
            }

            // 代码要在 async Task 方法中

            // 选择序号
            Console.WriteLine("---请选择想要下载的歌手序号---");
            int index = int.Parse(Console.ReadLine()) - 1;

            // 取出歌曲ID
            long songId = songsList[index].id;

            // 拼接下载地址
            string downloadUrl = $"https://music.3e0.cn/?server=netease&type=url&id={songId}";

            // 拼接保存文件名   文件格式： 歌曲名-歌手.mp3
            string artistName = songsList[index].artists[0].name;
            string saveFileName = $"{songName}-{artistName}.mp3";

            // 请求下载地址 返回字节数组
            byte[] fileBytes = await httpclient.GetByteArrayAsync(downloadUrl);
            // 写入本地文件
            File.WriteAllBytes(saveFileName, fileBytes);

            Console.WriteLine($"下载成功！文件：{saveFileName}");
        }
    }
}
