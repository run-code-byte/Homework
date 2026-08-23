using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ctest
{
    internal class Programming2
    {

        static void Main(string[] args)
        {
            /*
        • 使用字符串方法去除每个字符串的前后空格，将所有字母转换为小写；
        • 使用正则表达式判断每个字符串是否为合法手机号（11位数字，以13、14、15、17、18开头）；
           通过条件语句区分并打印：合法手机号、非法手机号、普通文本。
        */
            string[] arrStr = { "13877433787", "张三喜欢打球555", "hello world", "12352362473272", "世上无难事只怕有心人666" };
            string phoneReg = @"^1[34578]\d{9}$";
            foreach (string item in arrStr)
            {
                // 去除前后空格，转小写
                string str = item.Trim().ToLower();
                // 判断是否匹配手机号
                bool isPhone = Regex.IsMatch(str, phoneReg);
                if (isPhone)
                {
                    Console.WriteLine($"【{str}】->合法手机号");
                }
                else
                {
                    // 判断是否全部由数字组成
                    bool isAllnum = Regex.IsMatch(str, @"^\d+$");
                    if (isAllnum)
                    {
                        Console.WriteLine($"【{str}】->非法手机号");
                    }
                    else
                    {
                        Console.WriteLine($"【{str}】->普通文本");
                    }
                }
            }

        }

    }
}
