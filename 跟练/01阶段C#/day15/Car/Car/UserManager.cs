using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Car
{
    internal class UserManager
    {
        private string Path { get; } = "./user.json";
        private JsonSerializerOptions JsonOpt { get; } = new JsonSerializerOptions()
        {
            WriteIndented = true,
            AllowTrailingCommas = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        //新增客户
        public void Add()
        {
            Console.WriteLine("请输入客户姓名：");
            string userName = Console.ReadLine();
            Console.WriteLine("请输入身份证号：");
            string userCardId = Console.ReadLine();
            Console.WriteLine("请输入性别：");
            string gender = Console.ReadLine();
            Console.WriteLine("请输入手机号：");
            string telNum = Console.ReadLine();
            Console.WriteLine("请输入座右铭：");
            string motto = Console.ReadLine();

            if (!Regex.IsMatch(telNum, @"^1\d{10}$"))
            {
                Console.WriteLine("输入手机格式错误！！！");
                return;
            }

            List<User> list = new List<User>();
            if (File.Exists(this.Path))
            {
                string jsonStr = File.ReadAllText(this.Path);
                list = JsonSerializer.Deserialize<List<User>>(jsonStr);
                if (list.Exists(item => item.IdCard == userCardId))
                {
                    Console.WriteLine("客户已存在，请勿重复添加！");
                    return;
                }
            }
            int id = list.Count == 0 ? 1 : list[list.Count - 1].Id + 1;
            string regTime = DateTime.Now.ToString();
            User userObj = new User(id, userName, userCardId, regTime, gender, telNum, motto);
            list.Add(userObj);
            string resStr = JsonSerializer.Serialize(list, JsonOpt);
            File.WriteAllText(this.Path, resStr);
            Console.WriteLine("-------------------");
            Console.WriteLine("新增客户成功！！！");
            Console.WriteLine("-------------------");
        }
        //查看所有客户
        public void SearchAll()
        {
            if(!File.Exists(this.Path))
            {
                Console.WriteLine("暂无客户信息，请先添加");
                return;
            }
            string jsonStr = File.ReadAllText(this.Path);
            List<User> list = JsonSerializer.Deserialize<List<User>>(jsonStr);
            Console.WriteLine("=================所有客户信息=================");
            list.ForEach(item => Console.WriteLine($"ID：{item.Id} -- 姓名：{item.Name} -- 身份证：{item.IdCard} -- 性别：{item.Gender} -- 手机号：{item.PhoneNo} -- 座右铭：{item.Motto}"));
            Console.WriteLine("=================所有客户信息=================");

        }
        //查看某个客户
        public void SearchOne()
        {
            Console.WriteLine("请输入客户ID：");
            int userId = int.Parse(Console.ReadLine());
            if (!File.Exists(this.Path))
            {
                Console.WriteLine("暂无客户信息，请先添加");
                return;
            }
            string jsonStr = File.ReadAllText(this.Path);
            List<User> list = JsonSerializer.Deserialize<List<User>>(jsonStr);
            User usrObj=list.Find(item => item.Id == userId);
            if(usrObj == null)
            {
                Console.WriteLine("暂无该客户信息，请先添加");
                return;
            }
            Console.WriteLine("===============================所有客户信息===============================");
            Console.WriteLine($"姓名：{usrObj.Name} -- 身份证：{usrObj.IdCard} -- 性别：{usrObj.Gender} -- 手机号：{usrObj.PhoneNo} -- 座右铭：{usrObj.Motto}");
            Console.WriteLine("===============================所有客户信息===============================");
        }

        public bool SearchOneById(int id)
        {
           
            if (!File.Exists(this.Path)) return false;
           
            string jsonStr = File.ReadAllText(this.Path);
            List<User> list = JsonSerializer.Deserialize<List<User>>(jsonStr);
            User usrObj = list.Find(item => item.Id == id);
            if (usrObj == null) return false;
            return true;
        }
    }
}
