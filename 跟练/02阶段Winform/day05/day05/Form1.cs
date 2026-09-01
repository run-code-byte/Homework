using static System.ComponentModel.Design.ObjectSelectorEditor;

/*作业
 二级联动中数据组织方式将原来的list改为字典 实现

```C#
  {
    ["省份"]=["城市","城市",....],
    .....    
  }
 */
namespace day05
{
    public partial class Form1 : Form
    {
        //private List<Dictionary<string, dynamic>> data=new ();
        private Dictionary<string, List<string>> provinceCityDict = new Dictionary<string, List<string>>();
        public Form1()
        {
            InitializeComponent();
            #region list数据存储方式
            //data = new()
            //{
            //     new Dictionary<string, dynamic>()
            //    {
            //        ["id"] = 1,
            //        ["name"] = "广东省",
            //        ["parentId"] = 0,
            //    },
            //    new Dictionary<string, dynamic>()
            //    {
            //        ["id"] = 2,
            //        ["name"] = "广州市",
            //        ["parentId"] = 1,
            //    },
            //    new Dictionary<string, dynamic>()
            //    {
            //        ["id"] = 3,
            //        ["name"] = "深圳市",
            //        ["parentId"] = 1,
            //    },
            //     new Dictionary<string, dynamic>()
            //     {
            //         ["id"] = 4,
            //         ["name"] = "佛山市",
            //         ["parentId"] = 1,
            //     },
            //      new Dictionary<string, dynamic>()
            //    {
            //        ["id"] = 5,
            //        ["name"] = "湖南省",
            //        ["parentId"] = 0,
            //    },
            //    new Dictionary<string, dynamic>()
            //    {
            //        ["id"] = 6,
            //        ["name"] = "长沙市",
            //        ["parentId"] = 5,
            //    },
            //    new Dictionary<string, dynamic>()
            //    {
            //        ["id"] = 7,
            //        ["name"] = "湘潭市",
            //        ["parentId"] = 5,
            //    },
            //     new Dictionary<string, dynamic>()
            //     {
            //         ["id"] = 8,
            //         ["name"] = "永州市",
            //         ["parentId"] = 5,
            //     }
            //};
            #endregion
            provinceCityDict = new Dictionary<string, List<string>>()
            {
                { "广东省", new List<string> { "广州市", "深圳市", "佛山市" } },
                { "湖南省", new List<string> { "长沙市", "湘潭市", "永州市" } }
            };

            //List<Dictionary<string, dynamic>>  proList = data.FindAll(item => item["parentId"] == 0);
            //dynamic[] proName=proList.ConvertAll(item => item["name"]).ToArray();
            //ProvinceCb.Items.AddRange(proName);

            string[] provinceArr = provinceCityDict.Keys.ToArray();
            ProvinceCb.Items.AddRange(provinceArr);

            ProvinceCb.SelectedIndexChanged += proChanged;



        }

        private void proChanged(object? sender, EventArgs e)
        {
            string pro =(sender as ComboBox).SelectedItem.ToString();
            //int proId = data.Find(item => item["name"] == pro)["id"];
            //List<Dictionary<string, dynamic>> cityList = data.FindAll(item => item["parentId"] == proId);
            //dynamic[] cityName = cityList.ConvertAll(item => item["name"]).ToArray();


            CityCb.Items.Clear();
            CityCb.Text="请选择城市";
            if (provinceCityDict.ContainsKey(pro))
            {
                List<string> citys = provinceCityDict[pro];
                CityCb.Items.AddRange(citys.ToArray());
            }
            //CityCb.Items.AddRange(cityName);
        }
    }
}
