using System.Text.Json;
using System.Text.RegularExpressions;

namespace day10HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 作业1
            /*
             作业:  使用读写文件配合命令行窗口  模拟实现注册功能
             要求输入用户名和密码,完成注册; (注册的用户信息记录在user.txt文件中,一行一个用户信息 数据之间通过===分隔)

             */
            //Action WriteLine = () =>
            //{
            //    Console.WriteLine("请输入用户名：");
            //    var username = Console.ReadLine();
            //    Console.WriteLine("请输入密码：");
            //    var password = Console.ReadLine();
            //    var str = username + "===" + password + "\n";

            //    File.AppendAllText("user.txt", str);
            //    Console.WriteLine("注册成功");
            //};
            //WriteLine();

            #endregion

            #region 作业2
            /*
            使用读写文件配合命令行窗口模拟实现注册登录功能
               进入就是菜单栏界面，1注册，2登录，0退出

               输入1进入注册，要求输入用户名，密码，用户输入用户名和密码则实  现注册功能，要求校验用户名和密码
               输入2进入登录，要求输入用户名，密码，输入后完成登录校验功能；              登录成功提示登录成功
               输入0退出程序，
               -用户注册成功的用户信息以文件的形式存储在userjson中（要求以json形式存储）

               - [username:",password:",datetime:"时间戳"}]
               - -用户操作日志user.log：用户每次操作都要有日志记录，记录操作，用户名，操作方式，时间，如果有异常的，记录异常
            */
            //string num = "";
            //string userReg = @"^[a-zA-Z][a-zA-Z0-9]{3,14}$";
            //string pwdReg = @"^\S{4,12}$";
            //string path = "./user.json";
            //var JsonOpt = new JsonSerializerOptions
            //{
            //    WriteIndented = true,
            //    AllowTrailingCommas = true,
            //};
            //string[] optArr = ["退出", "注册", "登录", "输入指令有误"];

            //Func<string, string, string> register = (userName, pwd) =>
            //{
            //    if (!Regex.IsMatch(userName, userReg) || !Regex.IsMatch(pwd, pwdReg)) 
            //        return "用户名或密码格式错误！";

            //    if (!File.Exists(path))
            //    {
            //        List<Dictionary<string, dynamic>> userList = new();
            //        Dictionary<string, dynamic> userDic = new Dictionary<string, dynamic>()
            //        {
            //            ["username"] = userName,
            //            ["password"] = pwd,
            //            ["dateTime"] = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
            //        };
            //        userList.Add(userDic);
            //        var jsonStr = JsonSerializer.Serialize(userList, JsonOpt);
            //        File.WriteAllText(path, jsonStr);
            //    }
            //    else
            //    {
            //        var jsonStr = File.ReadAllText(path);
            //        var userList = JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(jsonStr);
            //        bool isRegister = userList.Exists(i => i["username"].ToString() == userName);
            //        if (isRegister) return "用户已注册，请登录";
            //        Dictionary<string, dynamic> userDic = new Dictionary<string, dynamic>()
            //        {
            //            ["username"] = userName,
            //            ["password"] = pwd,
            //            ["dateTime"] = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
            //        };
            //        userList.Add(userDic);
            //        var newjsonStr = JsonSerializer.Serialize(userList, JsonOpt);
            //        File.WriteAllText(path, jsonStr);
            //    }
            //    return "注册成功";
            //};

            //Func<string, string, string> login = (userName, pwd) => {
            //    if (!Regex.IsMatch(userName, userReg) || !Regex.IsMatch(pwd, pwdReg))
            //        return "用户名或密码格式错误！";
            //    if (!File.Exists(path)) return "请先注册";
            //    var jsonStr = File.ReadAllText(path);
            //    var userList = JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(jsonStr);
            //    var resUser=userList.Find(item=> item["username"].ToString() == userName && item["password"].ToString()==pwd);
            //    if (resUser == null) return "用户名或密码错误";
            //    return "登录成功";
            //};

            //while (num != "0")
            //{
            //    Console.WriteLine("======欢迎来到用户管理======");
            //    Console.WriteLine("1：用户注册");
            //    Console.WriteLine("2：用户登录");
            //    Console.WriteLine("0：退出");
            //    num = Console.ReadLine();
            //    string username = "youke";
            //    string res = "";
            //    switch (num)
            //    {
            //        case "1":
            //            Console.WriteLine("---用户注册---");
            //            Console.WriteLine("请输入用户名(4`15)");
            //            username = Console.ReadLine();
            //            Console.WriteLine("请输入密码(4`12)");
            //            var password = Console.ReadLine();
            //            res = register(username, password);
            //            Console.WriteLine(res);
            //            break;
            //        case "2":
            //            Console.WriteLine("---用户登录---");
            //            Console.WriteLine("请输入用户名（4`15)");
            //            username = Console.ReadLine();
            //            Console.WriteLine("请输入密码（4`12)");
            //            var loginPassword= Console.ReadLine();
            //            res=login(username, loginPassword);
            //            Console.WriteLine(res);
            //            break;
            //        case "0":
            //            Console.WriteLine("---退出---");
            //            break;
            //        default:
            //            num = "3";
            //            Console.WriteLine("输入有误");
            //            break;
            //    }
            //    string optStr = $"{username}---{optArr[int.Parse(num)]}---{DateTime.Now}---{res}\n";
            //    File.AppendAllText("./user.log",optStr);

            //    File.ReadAllText("./user.log");
            //    Console.WriteLine("++++++++++++++++++++++++++++");
            //    Console.WriteLine(optStr);
            //    Console.WriteLine("++++++++++++++++++++++++++++");

            //}

            #endregion


        }
    }
}
