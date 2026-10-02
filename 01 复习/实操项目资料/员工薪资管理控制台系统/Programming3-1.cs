using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ctest
{
    internal class Programming3_1
    {
        static void tips()
        {
            Console.WriteLine();
            Console.WriteLine("======员工薪资管理控制台系统======");
            Console.WriteLine("1 新增员工");
            Console.WriteLine("2 查看全部员工");
            Console.WriteLine("3 根据编号调整薪资");
            Console.WriteLine("4 根据编号删除员工");
            Console.WriteLine("5 按薪资条件筛选员工");
            Console.WriteLine("6 退出系统");
            Console.WriteLine("======员工薪资管理控制台系统======");
            Console.WriteLine("请输入数字进行功能选择：");
        }
        static void Main(string[] args)
        {
            EmployeeManager EM =new EmployeeManager();
            while (true)
            {
                tips();
                int n=int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        //新增员工
                        EM.Add();
                        break;
                    case 2:
                        //查看全部员工
                        EM.ShowAll();
                        break;
                    case 3:
                        //根据编号调整薪资
                        EM.EditSalaryById();
                        break;
                    case 4:
                        //根据编号删除员工
                        EM.DeleteEmpById();
                        break;
                    case 5:
                        //按薪资条件筛选员工
                        EM.FilterBySalary();
                        break;
                    case 6:
                        //退出系统
                        Console.WriteLine("系统退出，再见！");
                        return;
                    default:
                        Console.WriteLine("输入的数字有误！！！");
                        break;

                }
                    
            }


        }
    }

    internal class Employee
    {
        /*
            私有字段：员工编号（int EmpId）、员工姓名（string EmpName）、所属部门（string Department）、员工薪资（double Salary）
            为所有私有字段编写对应的public公开属性（get、set）
            编写有参构造方法，一次性初始化四个字段数据
            编写实例方法 ShowEmpInfo()：控制台格式化打印员工所有信息（编号、姓名、部门、薪资）
         */
        private int EmpId;
        private string EmpName;
        private string Department;
        private double Salary;
        public int Id
        {
            get { return EmpId; }
            set { EmpId = value; }
        }
        public string Name
        {
            get { return EmpName; }
            set { EmpName = value; }
        }
        public string Dept
        {
            get { return Department; }
            set { Department = value; }
        }
        public double Sal
        {
            get { return Salary; }
            set { Salary = value; }
        }
        public Employee()
        {

        }
        public Employee(int empId, string empName, string department, double salary)
        {
            EmpId = empId;
            EmpName = empName;
            Department = department;
            Salary = salary;
        }

        public void ShowEmpInfo()
        {
            Console.WriteLine($"员工编号：{Id}|姓名：{Name}|部门：{Dept}|薪资：{Sal:F2}");
        }
    }

    internal class EmployeeManager
    {
        /*
         * 数据持久化规则
            使用 List<Employee> 集合在内存中存储所有员工数据
            程序启动时：判断emp.json文件是否存在，存在则读取文件、反序列化加载所有员工数据到集合；不存在则创建空集合
            程序执行新增、修改、删除任意操作后，必须立即将最新集合数据序列化，覆盖写入emp.json文件，完成数据持久化
         * 
         * 功能1：新增员工（增）
            控制台依次提示用户输入：员工编号、姓名、部门、薪资，自动创建员工对象，添加到List集合，自动保存数据到emp.json。
            要求：编号为唯一标识，基础班不强制查重，正常新增即可。
            功能2：查看全部员工（查-全部）
            循环遍历List集合，调用员工ShowEmpInfo()方法，打印所有员工信息；若无员工数据，提示“暂无员工数据”。
            功能3：根据编号调整薪资（改）
            用户输入员工编号，程序遍历集合匹配数据：
            匹配成功：提示输入新薪资，修改对应员工的薪资数据，自动保存到JSON文件
            匹配失败：控制台提示“未查询到该编号的员工”
            功能4：根据编号删除员工（删）
            用户输入员工编号，遍历集合查找：
            查找成功：从List集合中移除该员工，自动保存最新数据到JSON文件，提示“删除成功”
            查找失败：提示“未查询到该编号的员工，删除失败”
            功能5：按薪资条件筛选员工（查-条件）
            用户输入一个薪资数值，程序筛选出薪资大于该数值的所有员工，打印其完整信息；无符合条件数据则提示“无对应薪资条件的员工”。
        */
        private readonly string jsonpath = "emp.json";
        private List<Employee> empList;
        private JsonSerializerOptions jsonopt { get; } = new JsonSerializerOptions
        {
            WriteIndented = true,
            AllowTrailingCommas = true,
            Encoder=System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };
        public EmployeeManager()
        {
            if(File.Exists(jsonpath))
            {
                string jsonStr = File.ReadAllText(jsonpath);
                empList = JsonSerializer.Deserialize<List<Employee>>(jsonStr) ?? new List<Employee>() ;
            }
            else
            {
                empList=new List<Employee>();
            }
        }
        private void SaveToJson()
        {
            string json = JsonSerializer.Serialize(empList, jsonopt);
            File.WriteAllText(jsonpath, json);
        }
        //功能1：新增员工
        internal void Add()
        {
            Console.WriteLine("---新增员工---");
            Console.Write("请输入员工编号：");
            int id = int.Parse(Console.ReadLine());

            Console.Write("请输入员工姓名：");
            string name = Console.ReadLine();

            Console.Write("请输入所属部门：");
            string dept = Console.ReadLine();

            Console.Write("请输入员工薪资：");
            double sal = double.Parse(Console.ReadLine());

            Employee emp = new Employee(id, name, dept, sal);
            empList.Add(emp);
            SaveToJson();
            Console.WriteLine("新增员工完成！"); 
        }
        //功能2：查看全部员工
        internal void ShowAll()
        {
            Console.WriteLine("\n---全部员工列表---");
            if (empList.Count == 0)
            {
                Console.WriteLine("暂无员工数据");
                return;
            }
            foreach (var e in empList)
            {
                e.ShowEmpInfo();
            }
        }

        //功能3：按编号修改薪资
        internal void EditSalaryById()
        {
            Console.WriteLine("---调整员工薪资---");
            Console.Write("请输入要修改的员工编号：");
            int inputId = int.Parse(Console.ReadLine());

            Employee target = empList.Find(item => item.Id == inputId);
            if (target == null)
            {
                Console.WriteLine("未查询到该编号的员工");
                return;
            }
            Console.Write("请输入新的薪资：");
            double newSal = double.Parse(Console.ReadLine());
            target.Sal = newSal;
            SaveToJson();
            Console.WriteLine("薪资修改成功！");
        }

        //功能4：按编号删除员工
        internal void DeleteEmpById()
        {
            Console.WriteLine("---删除员工---");
            Console.Write("请输入要删除的员工编号：");
            int delId = int.Parse(Console.ReadLine());

            Employee delEmp = empList.Find(e => e.Id == delId);
            if (delEmp == null)
            {
                Console.WriteLine("未查询到该编号的员工，删除失败");
                return;
            }
            empList.Remove(delEmp);
            SaveToJson();
            Console.WriteLine("删除成功");
        }

        //功能5：薪资条件筛选：大于输入数值
        internal void FilterBySalary()
        {
            Console.WriteLine("---薪资筛选（筛选薪资大于输入值）---");
            Console.Write("请输入薪资阈值：");
            double threshold = double.Parse(Console.ReadLine());

            var resultList = empList.FindAll(e => e.Sal > threshold);
            if (resultList.Count == 0)
            {
                Console.WriteLine("无对应薪资条件的员工");
                return;
            }
            foreach (var item in resultList)
            {
                item.ShowEmpInfo();
            }
        }
    }
}
