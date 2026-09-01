/*
1. 将阶段考试项目代码自己写一遍
2. 将其中重复的代码 封装
3. 添加校验
    - id： int  
    - 薪资： double
*/
using System.Text.Json;

namespace Employee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string num = "";// 输入的操作编号  
            Employee EM = new Employee(1, "", "", 10.1);// 实例化车辆管理对象

            while (num != "6")
            {

                Tips();  // 提示界面
                // 提示输入
                num = Console.ReadLine();
                switch (num)
                {
                    case "1":
                        // 输入车辆信息提示
                        // 输入车辆信息提示
                        Console.WriteLine("请输员工编号：");
                        int EmpId = int.Parse(Console.ReadLine());
                        Console.WriteLine("请输入姓名：");
                        string EmpName = Console.ReadLine();
                        Console.WriteLine("请输入部门：");
                        string Department = Console.ReadLine();
                        Console.WriteLine("请输入薪水：");
                        double Salary = double.Parse(Console.ReadLine());
                        string resAdd = EM.Add(EmpId, EmpName, Department, Salary);
                        Console.WriteLine(resAdd);

                        break;
                    case "2":
                        EM.SearchAll();
                        break;
                    case "3":
                        EM.Update();
                        break;
                    case "4":
                        EM.Remove();
                        break;
                    case "5":
                        EM.SearchFind();
                        break;
                    default:
                        Console.WriteLine("输入编号有误，请重新输入！！！");
                        break;
                }
                Console.WriteLine();
            }
        }

        static void Tips()
        {
            // 提示界面
            Console.WriteLine("==欢迎来到员工薪资管理控制台系统==");
            Console.WriteLine("请选择操作编号：");
            Console.WriteLine("1：新增员工（增）");
            Console.WriteLine("2：查看全部员工（查-全部）");
            Console.WriteLine("3：根据编号调整薪资（改）");
            Console.WriteLine("4：根据编号删除员工（删）");
            Console.WriteLine("5：按薪资条件筛选员工（查-条件）");
            Console.WriteLine("6：退出系统");
        }

    }
}

