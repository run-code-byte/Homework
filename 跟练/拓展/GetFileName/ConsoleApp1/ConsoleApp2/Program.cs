using System;
using System.IO;
using System.Collections.Generic;
namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string parentDir = "";
            // 父目录路径，改成你自己的
            for (int i = 3; i <= 4; i++)
            {
                parentDir = @"D:\桌面\老师发\正课\04阶段联合编程\day0" + i + @"\03-视频";
                //=====第一步：把子文件夹(上午、下午)里面的文件全部移动到父目录，然后删除子文件夹=====
                //string[] subDirs = Directory.GetDirectories(parentDir);
                //foreach (string subFolder in subDirs)
                //{
                //    string[] files = Directory.GetFiles(subFolder);
                //    foreach (string fileFullPath in files)
                //    {
                //        string fileName = Path.GetFileName(fileFullPath);
                //        string targetPath = Path.Combine(parentDir, fileName);

                //        if (File.Exists(targetPath))
                //        {
                //            Console.WriteLine($"【跳过】同名文件：{fileName}");
                //        }
                //        else
                //        {
                //            File.Move(fileFullPath, targetPath);
                //            Console.WriteLine($"已移动：{fileName}");
                //        }
                //    }
                //    //删除上午、下午文件夹
                //    Directory.Delete(subFolder, true);
                //    Console.WriteLine($"删除文件夹：{subFolder}");
                //}
                //=====第二步：读取合并后的全部文件，去除后缀，一行、空格分隔输出=====
                List<string> nameList = new List<string>();
                string[] allFiles = Directory.GetFiles(parentDir);
                foreach (var fullPath in allFiles)
                {
                    string nameNoExt = Path.GetFileNameWithoutExtension(fullPath);
                    nameList.Add(nameNoExt);
                }
                string outputStr = string.Join(" ", nameList);
                Console.WriteLine(outputStr);
            }
            
         

           
        }
    }
}
