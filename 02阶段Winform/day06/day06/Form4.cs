using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using day06.myControl;

namespace day06
{
    public partial class Form4 : Form
    {
        public Form4()
        {
           

            InitializeComponent();
            bookList.ForEach(item =>
            {
                UCText uct = new UCText(item["书名"], item["作者"], item["简介"]);
                flowLayoutPanel1.Controls.Add(uct);
            });
           

         }
        private List<Dictionary<string, string>> bookList = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>()
                {
                    ["书名"] = "三国演义",
                    ["作者"] = "罗贯中",
                    ["简介"] = "东汉末年分三国……曹操"
                },
                new Dictionary<string, string>()
                {
                    ["书名"] = "水浒传",
                    ["作者"] = "施耐庵",
                    ["简介"] = "北宋末年，一百零八位好汉聚义梁山"
                },
                new Dictionary<string, string>()
                {
                    ["书名"] = "西游记",
                    ["作者"] = "吴承恩",
                    ["简介"] = "唐僧师徒四人西天取经，一路降妖除魔"
                },
                new Dictionary<string, string>()
                {
                    ["书名"] = "红楼梦",
                    ["作者"] = "曹雪芹",
                    ["简介"] = "讲述贾史王薛四大家族兴衰，宝黛爱情悲剧"
                },
                new Dictionary<string, string>()
                {
                    ["书名"] = "朝花夕拾",
                    ["作者"] = "鲁迅",
                    ["简介"] = "鲁迅先生回忆性散文集，记录童年与青年往事"
                }
            };

    }
}
