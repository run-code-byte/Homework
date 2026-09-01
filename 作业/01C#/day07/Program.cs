namespace day07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 数据加密
            //string text = "清风漫过湖畔，午间薄雾缓缓消散，夜色悄然而至，河水静静流淌，渡船缓缓靠岸，渡口游人往来，相逢知己相交，互换见闻感受，留心世间风情，记录山河晚报。";
            //string salt = "7-16-30-38-49-52-63-70";
            //string result = ""; // 最终获取到的情报
            //// 先将salt 转为数组
            //string[] nums = salt.Split("-");
            //// 遍历nums获取每个数字(字符串), 作为text的索引 
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    //nums[i] // 转换为整数 才能作为下标使用
            //    int index = int.Parse(nums[i]);
            //    result += text[index];
            //}
            //Console.WriteLine(result); // 午夜渡口交换情报


            //string text = "清风漫过湖畔，午间薄雾缓缓消散，夜色悄然而至，河水静静流淌，渡船缓缓靠岸，渡口游人往来，相逢知己相交，互换见闻感受，留心世间风情，记录山河晚报。";
            //string salt = "午夜渡口交换情报";
            //List<int> nums = []; // 创建一个list 用于未来的密文索引存储
            //// 遍历salt 字符串
            //for (int i = 0; i < salt.Length; i++)
            //{
            //    //  根据 salt[i] 去text中查找对应的下标
            //    int index = text.IndexOf(salt[i]) - 1;
            //    nums.Add(index);// 将获取的下标 添加到 nums list集合中
            //}
            //string result = string.Join("-", nums);
            //// 最终的下标
            //Console.WriteLine(result); // "6-15-29-37-48-51-62-69"

            //// 解密
            //string res = ""; // 最终获取到的情报
            //// 先将result密文 转为数组
            //string[] nums1 = result.Split("-");
            //// 遍历nums获取每个数字(字符串), 作为text的索引 
            //for (int i = 0; i < nums1.Length; i++)
            //{
            //    //nums[i] // 转换为整数 才能作为下标使用
            //    int index = int.Parse(nums1[i]) + 1;
            //    res += text[index];
            //}
            //Console.WriteLine(res); // 午夜渡口交换情报

            //// 奇偶数处理 生成密文的时候，奇数就-1，偶数就+1：
            //string text = "清风漫过湖畔，午间薄雾缓缓消散，夜色悄然而至，河水静静流淌，渡船缓缓靠岸，渡口游人往来，相逢知己相交，互换见闻感受，留心世间风情，记录山河晚报。";
            //string salt = "午夜渡口交换情报";
            //List<int> nums = []; // 创建一个list 用于未来的密文索引存储
            //// 遍历salt 字符串
            //for (int i = 0; i < salt.Length; i++)
            //{
            //    //  根据 salt[i] 去text中查找对应的下标
            //    int index = text.IndexOf(salt[i]);
            //    // 处理index  奇数就-1，偶数就+1：
            //    index += index % 2 == 0 ? 1 : -1;
            //    nums.Add(index);// 将获取的下标 添加到 nums list集合中
            //}
            //string result = string.Join("-", nums);
            //// 最终的下标
            //Console.WriteLine(result); // "6-17-31-39-48-53-62-71"


            ////找到情报的时候，也要判断下标是奇数还是偶数，奇数就 -1，偶数就 +1：
            //// 解密
            //string res = ""; // 最终获取到的情报
            //// 先将result密文 转为数组
            //string[] nums1 = result.Split("-");
            //// 遍历nums获取每个数字(字符串), 作为text的索引 
            //for (int i = 0; i < nums1.Length; i++)
            //{
            //    //nums[i] // 转换为整数 才能作为下标使用
            //    int index = int.Parse(nums1[i]);
            //    // 判断下标是奇数还是偶数，奇数就 -1，偶数就 +1：
            //    index += index % 2 == 0 ? 1 : -1;
            //    res += text[index];
            //}
            //Console.WriteLine(res); // 午夜渡口交换情报

            //// 数字转汉字

            ////int money = 555666;
            ////int money = 56;
            //int money = 1000086;
            ////int money = 1086000;
            ////int money = 123456;
            //// 壹拾贰萬叁仟肆佰伍拾陆
            //// 将money转为字符串,方便后续获取单个数字
            //string str = money.ToString();

            //string result = "";// 最终数字 转汉字的结果
            //// 创建汉字数组
            //string[] arr = ["零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖"];
            //// 数字中的单个数字就是 arr中的下标

            //// 创建单位数组
            //string[] units = ["", "拾", "佰", "仟", "萬", "拾", "佰", "仟", "亿"];
            //// 为了获取数字对应的单位,最好从后往前拿数字 和单位进行匹配

            //// 567   /  100086     /  111000086
            //// 遍历数字字符串,拿到每一个数字, 拼接汉字
            //for (int i = str.Length - 1; i >= 0; i--) // 为了更好的获取到单位 倒序遍历
            //{
            //    //str[i] // 作为arr的下标使用就必须是整数
            //    int idx = int.Parse(str[i].ToString());

            //    /*
            //       举例说明: 567  长度是3
            //       i       index       ===> i + index = 长度-1
            //       2         0    
            //       1         1
            //       0         2
            //     */
            //    // 数字对应单位的索引下标
            //    //int index = str.Length - 1 - i;
            //    //if (idx != 0)
            //    //{
            //    //    result = arr[idx] + units[index] + result;
            //    //}
            //    //else
            //    //{
            //    //    //// 数字是0 但是卡在萬单位上的时候,则不能省略萬单位
            //    //    //// str长度 减去 萬位置0的下标  一定是 5
            //    //    //if (str.Length - 5 == i)
            //    //    //{
            //    //    //    result = arr[idx] + units[4] + result;
            //    //    //}
            //    //    //else
            //    //    //{
            //    //    //    result = arr[idx] + result;
            //    //    //}
            //    //    // 判断单位是萬则单位保留
            //    //    if (units[index] == "萬")
            //    //    {
            //    //        result = arr[idx] + units[4] + result;
            //    //    }
            //    //    else
            //    //    {
            //    //        result = arr[idx] + result;
            //    //    }
            //    //}


            //    // 如果数字不是0 或则单位是萬  则单位都保留
            //    int index = str.Length - 1 - i;
            //    if (idx != 0 || units[index] == "萬")
            //    {
            //        result = arr[idx] + units[index] + result;
            //    }
            //    else
            //    { // 数字是0且单位不是萬则 不保留单位
            //        result = arr[idx] + result;
            //    }

            //}

            //// 正则处理 零+萬问题
            //result = Regex.Replace(result, @"零+萬", "萬");
            //// 正则处理 多个连续零问题
            //result = Regex.Replace(result, @"零+", "零");

            //// 处理结尾是0 的问题            
            //if (result.EndsWith("零"))
            //{
            //    result = result.Substring(0, result.Length - 1);
            //}
            //Console.WriteLine(result);
        }
    }
}
