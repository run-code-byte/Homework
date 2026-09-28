namespace Car
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string num = "";

            while (num != "0")
            {
                Tips();

                num = Console.ReadLine();
                CarManager CM = new CarManager();
                UserManager UM = new UserManager();
                RentReturnClass RRC = new RentReturnClass();
                switch (num)
                {
                    case "1":
                        // 车辆输入
                        Console.WriteLine("请输入车牌号：");
                        string Card = Console.ReadLine();
                        Console.WriteLine("请输入车类型：");
                        string Type = Console.ReadLine();
                        Console.WriteLine("请输入时租费：");
                        string Price = Console.ReadLine();
                        string resAdd = CM.Add(Card, Type, Price);
                        Console.WriteLine(resAdd);
                        break;
                    case "2":
                        Console.WriteLine("查看所有车辆信息");
                        CM.SearchAll();
                        break;
                    case "3":
                        Console.WriteLine("查看某辆车");
                        int id=int.Parse(Console.ReadLine());
                        CM.SearchOne(id);
                        break;
                    case "4":
                        Console.WriteLine("查看所有空闲车辆");
                        CM.SearchFree();
                        break;
                    case "5":
                        UM.Add();
                        break;
                    case "6":
                        UM.SearchAll();
                        break;
                    case "7":
                        UM.SearchOne();
                        break;
                    case "8":
                        RRC.RentCar();
                        break;
                    case "9":
                        RRC.ReturnCar();
                        break;
                    case "10":
                        RRC.SearchAll();
                        break;
                    case "0":
                        Console.WriteLine("退出系统");
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
            Console.WriteLine("==欢迎来到神车系统==");
            Console.WriteLine("请选择操作编号：");
            Console.WriteLine("0：退出系统");
            Console.WriteLine("1：新增车辆");
            Console.WriteLine("2：查看所有车辆信息");
            Console.WriteLine("3：查看某辆车");
            Console.WriteLine("4：查看所有空闲车辆");
            Console.WriteLine("5：新增客户");
            Console.WriteLine("6：查看所有客户");
            Console.WriteLine("7：查看某个客户");
            Console.WriteLine("8：租车");
            Console.WriteLine("9：还车");
            Console.WriteLine("10：查看所有租车记录");
        }

    }
}
