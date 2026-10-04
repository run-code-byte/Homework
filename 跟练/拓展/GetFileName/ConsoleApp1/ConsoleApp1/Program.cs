using static System.Net.WebRequestMethods;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            string path = @"D:\Desktop\老师发\正课\01阶段C#\03day\03-视频";

            string[] file = Directory.GetFiles(path);

            //foreach (string file in fileName)
            //{
            //    //拿到带后缀文件名
            //    string a = Path.GetFileName(file);
            //    //去除后缀
            //    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(a);
            //    Console.WriteLine(fileNameWithoutExt);

            //}

            List<string> nameList = new List<string>();
            foreach (var fullPath in file)
            {
                string fileName = Path.GetFileName(fullPath);
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
                nameList.Add(fileNameWithoutExt);
            }
            // 用空格连接所有名称，输出一行
            string result = string.Join(" ", nameList);
            Console.WriteLine(result);
        }
    }
}
