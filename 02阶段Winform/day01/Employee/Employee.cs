using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Encodings.Web;

namespace Employee
{
    internal class Employee
    {
        // 私有字段
        private int _empId;
        private string _empName;
        private string _department;
        private double _salary;

        // C#规范：属性大驼峰
        public int EmpId
        {
            get { return _empId; }
            set { _empId = value; }
        }
        public string EmpName
        {
            get { return _empName; }
            set { _empName = value; }
        }

        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }

        public double Salary
        {
            get { return _salary; }
            set { _salary = value; }
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
            Console.WriteLine($"员工编号 : {EmpId} -- 名字 : {EmpName} -- 部门 : {Department} -- 薪水 : {Salary} ");
        }

        // 文件路径与序列化配置，只初始化一次
        private readonly string _jsonPath = "./emp.json";
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            AllowTrailingCommas = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };

        #region 【封装重复IO辅助方法】
        /// <summary>
        /// 读取json文件，反序列化为员工集合，文件不存在返回空List
        /// </summary>
        private List<Employee> LoadEmployeeList()
        {
            if (!File.Exists(_jsonPath))
            {
                return new List<Employee>();
            }
            string jsonStr = File.ReadAllText(_jsonPath);
            // 防止文件为空反序列化得到null
            var list = JsonSerializer.Deserialize<List<Employee>>(jsonStr, _jsonOptions);
            return list ?? new List<Employee>();
        }

        /// <summary>
        /// 将员工集合保存写入json文件
        /// </summary>
        private void SaveEmployeeList(List<Employee> empList)
        {
            string jsonStr = JsonSerializer.Serialize(empList, _jsonOptions);
            File.WriteAllText(_jsonPath, jsonStr);
        }
        #endregion


        /// <summary>
        /// 新增员工
        /// </summary>
        public string Add(int empId, string empName, string department, double salary)
        {
            List<Employee> employees = LoadEmployeeList();

            Employee newEmp = new Employee(empId, empName, department, salary);
            employees.Add(newEmp);

            SaveEmployeeList(employees);
            return "新员工成功！！！";
        }


        /// <summary>
        /// 修改薪资
        /// </summary>
        public void Update()
        {
            List<Employee> employees = LoadEmployeeList();
            if (employees.Count == 0)
            {
                Console.WriteLine("无员工！！！！");
                return;
            }

            Console.WriteLine("请输入员工编号");
            int id = int.Parse(Console.ReadLine());

            Employee empObj = employees.Find(item => item.EmpId == id);
            if (empObj == null)
            {
                Console.WriteLine("未查询到该编号的员工");
                return;
            }

            Console.WriteLine("请输调整后的薪资");
            double newSalary = double.Parse(Console.ReadLine());
            empObj.Salary = newSalary;

            SaveEmployeeList(employees);
            Console.WriteLine("ok!!!");
        }


        /// <summary>
        /// 查询全部员工
        /// </summary>
        public void SearchAll()
        {
            List<Employee> employees = LoadEmployeeList();
            if (employees.Count == 0)
            {
                Console.WriteLine("暂无员工数据");
                return;
            }

            foreach (Employee item in employees)
            {
                item.ShowEmpInfo();
            }
        }


        /// <summary>
        /// 根据薪资条件筛选
        /// </summary>
        public void SearchFind()
        {
            Console.WriteLine("请输入薪资数值");
            double salary = double.Parse(Console.ReadLine());

            List<Employee> employees = LoadEmployeeList();
            if (employees.Count == 0)
            {
                Console.WriteLine("没有员工信息，请先添加");
                return;
            }

            List<Employee> resEmployees = employees.FindAll(item => item.Salary > salary);
            if (resEmployees.Count == 0)
            {
                Console.WriteLine("无对应薪资条件的员工");
                return;
            }

            foreach (Employee item in resEmployees)
            {
                item.ShowEmpInfo();
            }
        }


        /// <summary>
        /// 根据编号删除员工
        /// </summary>
        public void Remove()
        {
            List<Employee> employees = LoadEmployeeList();
            if (employees.Count == 0)
            {
                Console.WriteLine("无员工！！！！");
                return;
            }

            Console.WriteLine("请输入员工编号");
            int id = int.Parse(Console.ReadLine());

            int index = employees.FindIndex(item => item.EmpId == id);
            if (index == -1)
            {
                Console.WriteLine("未查询到该编号的员工，删除失败");
                return;
            }

            employees.RemoveAt(index);
            SaveEmployeeList(employees);
            Console.WriteLine("删除成功!!!");
        }
    }
}
