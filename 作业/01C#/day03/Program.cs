using System.Reflection.Metadata;

namespace day03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //小明择偶标准：要么资产在300w以上，要么颜值大于9.5。输入小红的资产和颜值
            //Console.WriteLine("请输入资产：");
            //int money=int.Parse(Console.ReadLine());
            //Console.WriteLine("请输入颜值：");
            //int yz=int.Parse(Console.ReadLine());
            //bool res = money > 300 || yz > 9.5;
            //Console.WriteLine(res);

            //小红想做车模，车模条件年龄16~22
            //Console.WriteLine("输入年龄：");
            //int age=int.Parse(Console.ReadLine());
            //bool res = age  >= 16 &&  age  <= 22;
            //Console.WriteLine(res);

            //输入年份，判断是否是闰年(普通闰年：能被4整除但不能被100整除/世纪闰年：可以被400整除)
            //Console.WriteLine("请输入年份：");
            //int year=int.Parse(Console.ReadLine());
            //if (year %4==0&&!(year%100==0)||year%400==0))
            //{
            //    Console.WriteLine("是闰年");
            //}
            //else
            //{
            //    Console.WriteLine("不是闰年");
            //}

            //根据输入的成绩判断是不及格(小于60),及格(大于60小于80), 良好(大于80小于90),优秀(大于90小于100)
            //Console.WriteLine("请输入成绩：");
            //int score=int.Parse(Console.ReadLine());
            //if (score > 60)
            //{
            //    Console.WriteLine("不及格");
            //}
            //else if (score < 80)
            //{
            //    Console.WriteLine("及格");
            //}
            //else if (score < 90)
            //{
            //    Console.WriteLine("良好");
            //}
            //else if (score <= 100)
            //{
            //    Console.WriteLine("优秀");
            //}

            //输出星期几
            //Console.WriteLine("请输入1~7数字：");
            //int num=int.Parse(Console.ReadLine());
            //switch (num) {
            //    case 1:
            //        Console.WriteLine("星期一");
            //        break;
            //    case 2:
            //        Console.WriteLine("星期一");
            //        break;
            //    case 3:
            //        Console.WriteLine("星期二");
            //        break;
            //    case 4:
            //        Console.WriteLine("星期三");
            //        break;
            //    case 5:
            //        Console.WriteLine("星期四");
            //        break;
            //    case 6:
            //        Console.WriteLine("星期五");
            //        break;
            //    case 7:
            //        Console.WriteLine("星期六");
            //        break;
            //    default:
            //        Console.WriteLine("请输入1~7数字");
            //        break;
            //     }


            //// 输入分数 1~100
            // 判断等级输出
            // 分数90~100  输出A  ===> 分数的十位9 / 10
            // 分数80~90   输出B  ===> 分数的十位8
            // 分数70~80   输出C  ===> 分数的十位7
            // 分数60~70   输出D  ===> 分数的十位6
            // 分数1~60    输出F  ===> 分数的十位0/1/2/3/4/5
            //Console.WriteLine("输入1~100分数");
            //int score=int.Parse(Console.ReadLine());
            //if (score>0&&score<=100)
            //{
            //    double n = score / 10;
            //    switch (n)
            //    {
            //        case 0:
            //            Console.WriteLine($"分数为：{score}，等级为：F");
            //            break;
            //        case 1:
            //            Console.WriteLine($"分数为：{score}，等级为：F");
            //            break;
            //        case 2:
            //            Console.WriteLine($"分数为：{score}，等级为：F");
            //            break;
            //        case 3:
            //            Console.WriteLine($"分数为：{score}，等级为：F");
            //            break;
            //        case 4:
            //            Console.WriteLine($"分数为：{score}，等级为：F");
            //            break;
            //        case 5:
            //            Console.WriteLine($"分数为：{score}，等级为：F");
            //            break;
            //        case 6:
            //            Console.WriteLine($"分数为：{score}，等级为：D");
            //            break;
            //        case 7:
            //            Console.WriteLine($"分数为：{score}，等级为：C");
            //            break;
            //        case 8:
            //            Console.WriteLine($"分数为：{score}，等级为：B");
            //            break;
            //        case 9:
            //            Console.WriteLine($"分数为：{score}，等级为：A");
            //            break;
            //        case 10:
            //            Console.WriteLine($"分数为：{score}，等级为：A");
            //            break;
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("请重新输入1`100的数字");
            //}


            //输出星期几  6-7输出周末  穿透写法
            //Console.WriteLine("请输入1~7数字：");
            //int num = int.Parse(Console.ReadLine());
            //switch (num)
            //{
            //    case 1: Console.WriteLine("星期一"); break;
            //    case 2: Console.WriteLine("星期二"); break;
            //    case 3: Console.WriteLine("星期三"); break;
            //    case 4: Console.WriteLine("星期四"); break;
            //    case 5: Console.WriteLine("星期五"); break;
            //    case 6: 
            //    case 7: Console.WriteLine("周末"); break;
            //    default: Console.WriteLine("请输入1~7数字"); break;
            //}

            //成绩等级输出 switch 简写
            // 判断等级输出
            // 分数90~100  输出A  ===> 分数的十位9 / 10
            // 分数80~90   输出B  ===> 分数的十位8
            // 分数70~80   输出C  ===> 分数的十位7
            // 分数60~70   输出D  ===> 分数的十位6
            // 分数1~60    输出F  ===> 分数的十位0/1/2/3/4/5
            //Console.WriteLine("输入1~100分数");
            //int score = int.Parse(Console.ReadLine());
            //if (score > 0 && score <= 100)
            //{
            //    String res = score switch
            //    {
            //        >= 90 => "A",
            //        >= 80 => "B",
            //        >= 70 => "C",
            //        >= 60 => "D",
            //        _ => "F"
            //    };
            //    Console.WriteLine(res);
            //}
            //else
            //{
            //    Console.WriteLine("输入有误");
            //}

            //三元表达式:判断 成年了/ 未成年
            //Console.WriteLine("输入年龄：");
            //int age = int.Parse(Console.ReadLine());
            //string res = (age >= 18) ? "成年了" : "未成年";
            //Console.WriteLine(res);

            //三元表达式: 判断 闰年(能被4整除但不能被100整除,能被400整除) 平年
            //Console.WriteLine("请输入年份：");
            //int year = int.Parse(Console.ReadLine());
            //string res = ((year % 4 == 0 && !(year % 100 == 0 ))|| year % 400 == 0) ? "闰年":"平年";
            //Console.WriteLine(res);

            //案例

            //奇数偶数判断
            //Console.WriteLine("输入一个数");
            //int n=int.Parse(Console.ReadLine());
            //string res = n % 2 == 0 ? "偶数" : "奇数";
            //Console.WriteLine($"该数{n}是{res}");

            //是否在线
            //int n = 1;
            //Console.WriteLine(n==1?"在线":"离线");


            //文件大小单位不同（1024以下kb / 以上MB）
            //Console.WriteLine("输入一个数");
            //int n = int.Parse(Console.ReadLine());
            //if( n > 1024 )
            //{
            //    int r = n / 1024;
            //    Console.WriteLine($"文件{r}MB");
            //}
            //else
            //{
            //    Console.WriteLine($"文件{n}KB");
            //}

            //数学运算计算器：让用户输入两个数字，再输入一个运算符(+-* /)，判断输入的运算符是什么，对两个数字进行对应的数学运算，将结果输出
            //Console.WriteLine("请输入第一个数：");
            //int n=int.Parse(Console.ReadLine());
            //Console.WriteLine("请输入第二个数：");
            //int m = int.Parse(Console.ReadLine());
            //Console.WriteLine("输入一个运算符(+-* /)：");
            //string opt=Console.ReadLine();

            //switch (opt)
            //{
            //    case "+": Console.WriteLine($"{n}{opt}{m}={n+m}");break;
            //    case "-": Console.WriteLine($"{n}{opt}{m}={n-m}");break;
            //    case "*": Console.WriteLine($"{n}{opt}{m}={n*m}");break;
            //    case "/": Console.WriteLine($"{n}{opt}{m}={n/m}");break;
            //    default: Console.WriteLine("输入有误");break;
            //}


            //不同血型不同性格：输入血型，当血型为A时，输出"细心稳重"；当血型为B时，输出"乐观自由"；当血型为AB时，输出"思维多变"；当血型为O时，输出"热情外向"
            //Console.WriteLine("输入血型：");
            //string b = Console.ReadLine();
            //string res = b switch
            //{
            //    "A" => "细心稳重",
            //    "B" => "乐观自由",
            //    "AB" => "思维多变",
            //    "O" => "热情外向"
            //};
            //Console.WriteLine(res);


            //作业

            //-账号密码验证（练习分支嵌套）：账号规定是"admin"，密码规定是"123456"。让用户输入账号和密码，判断账号和密码是否正确，账号和密码都正确就输出登入成功；账号不对，就输出账号不存在；密码不对，就输出密码错误。
            //Console.WriteLine("请输入账号：");
            //string user =Console.ReadLine();
            //Console.WriteLine("请输入密码：");
            //string password =Console.ReadLine();
            //if(user == "admin"  )
            //{
            //    if(password == "123456")
            //    {
            //        Console.WriteLine("登入成功");
            //    }
            //    else
            //    {
            //        Console.WriteLine("密码错误");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("账号不存在");
            //}

            //-选择菜单（add / edit / del）执行操作（练习多分支和switch）：提示用户选择菜单（add / edit / del），判断输入的是add，就输出新增成功；输入的是edit，就输出编辑成功；输入的是del，就输出删除成功。
            //Console.WriteLine("请选择菜单（add / edit / del）");
            //string opt=Console.ReadLine();
            //string res = opt switch
            //{
            //    "add" => "新增成功",
            //    "edit" => "编辑成功",
            //    "del" => "删除成功"
            //};
            //Console.WriteLine(res);


            //-会员打折满1000打9折，普通用户满2000打9.5折（练习多分支和分支嵌套）：让用户输入自己的类型（VIP / USER）和消费金额，如果是VIP，判断消费金额是否达到1000，如果达到了，就输出他应该支付的金额，如果没有达到，也输出他应该支付的金额；如果是USER，判断消费金额是否达到2000，如果达到了和没有达到，都输出他应该支付的金额。
            //Console.WriteLine("请输入类型（VIP / USER）：");
            //string user=Console.ReadLine();
            //Console.WriteLine("消费金额：");
            //int money = int.Parse(Console.ReadLine());
            //if(user== "VIP")
            //{
            //    if (money >= 1000)
            //    {
            //        Console.WriteLine($"VIP满1000打9折，应支付：{money*0.9}");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"VIP未满1000，应支付：{money}");
            //    }
            //}else if (user == "USER")
            //{
            //    if (money >= 2000)
            //    {
            //        Console.WriteLine($"USER满2000打9折，应支付：{money * 0.95}");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"USER未满2000，应支付：{money}");
            //    }
            //}

            //-通过月份判断季节（练习switch的穿透写法）：用户输入月份，判断月份如果是3、4、5月份，就输出这是春季；如果是6、7、8月份，就输出这是夏季；如果是9、10、11月份，就输出这是秋季，如果是12、1、2月份，就输出这是冬季。
            //Console.WriteLine("请输入月份：");
            //int month=int.Parse(Console.ReadLine());
            //switch (month)
            //{
            //    case 3: 
            //    case 4: 
            //    case 5: Console.WriteLine( $"{month}月是春季");break;
            //    case 6: 
            //    case 7: 
            //    case 8: Console.WriteLine( $"{month}月是夏季");break;
            //    case 9: 
            //    case 10:
            //    case 11: Console.WriteLine( $"{month}月是秋季");break;
            //    case 12:
            //    case 1: 
            //    case 2: Console.WriteLine( $"{month}月是冬季");break;
            //    default: Console.WriteLine("输入有误");break;
            //}


            //-快递运费（练习多分支）：输入快递重量，单位是Kg，如果重量小于1Kg，输出快递费10元；如果重量在1Kg~5Kg之间，就输出快递费20元；如果重量超过5Kg，就输出快递费50元。
            //Console.WriteLine("请输入快递重量，单位是Kg");
            //double weight=double.Parse(Console.ReadLine());
            //if (weight > 0)
            //{
            //    if (weight > 1)
            //    {
            //        if (weight < 5)
            //        {
            //            Console.WriteLine($"{weight}Kg快递费：20元");

            //        }
            //        else
            //        {
            //            Console.WriteLine($"{weight}Kg快递费：50元");
            //        }
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("{weight}Kg快递费：10元");
            //}

            //-会员等级优惠（练习多分支和switch）：输入会员等级，等级是3~5的整数，判断等级如果是5，输出终身免运费；等级是4，输出每月可领优惠券；等级是3，输出购物打9折，否则没有福利。
            //Console.WriteLine("请输入会员等级(3~5的整数)：");
            //int grade=int.Parse(Console.ReadLine());
            //switch (grade)
            //{
            //    case 3: Console.WriteLine("购物打9折");break;
            //    case 4: Console.WriteLine("每月可领优惠券");break;
            //    case 5: Console.WriteLine("终身免运费");break;
            //    default: Console.WriteLine("没有福利");break;
            //}

            //-自动售货机选商品（练习多分支和switch）：输入商品编号整数，1就输出已购买可乐；2输出已购买雪碧；3输出已购买矿泉水；否则输出无此商品。
            //Console.WriteLine("请输入商品编号整数(1`3)：");
            //int n=int.Parse(Console.ReadLine());
            //switch (n)
            //{
            //    case 1: Console.WriteLine("已购买可乐"); break;
            //    case 2: Console.WriteLine("已购买雪碧"); break;
            //    case 3: Console.WriteLine("已购买矿泉水");break;
            //    default: Console.WriteLine("无此商品");break;
            //}

            //-速度分级（练习多分支）：输入当前速度，如果在0~30，输出低速通过；30~60输出中速通过；60~100输出高速通过；100~120输出超速通过。
            //Console.WriteLine("请输入当前速度：");
            //int speed=int.Parse(Console.ReadLine());
            //if(speed > 0 )
            //{
            //    if(speed <= 30 )
            //    {
            //        Console.WriteLine($"速度：{speed}，低速通过");

            //    }
            //    else if (speed <= 60)
            //    {
            //        Console.WriteLine($"速度：{speed}，中速通过");

            //    }
            //    else if (speed <= 100)
            //    {
            //        Console.WriteLine($"速度：{speed}，高速通过");

            //    }
            //   else if (speed <= 120)
            //    {
            //        Console.WriteLine($"速度：{speed}，超速通过");
            //    }
            //}

        }
    }
}
