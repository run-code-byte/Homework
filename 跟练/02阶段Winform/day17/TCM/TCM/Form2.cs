using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCM.models;
using TCM.mysql;

namespace TCM
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.Shown += DataInit;
        }

        private void DataInit(object? sender, EventArgs e)
        {
            SetDataColumns();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;

            button1.Click += SearchData;
            button2.Click += SaveData;
            dateTimePicker1.ValueChanged += TimeChange;
            dateTimePicker2.ValueChanged += TimeChange;
        }

        private void TimeChange(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = dateTimePicker2.Value;
            dateTimePicker2.MinDate=dateTimePicker1.Value;
            dateTimePicker2.MaxDate = DateTime.Now;
        }

        private async void SaveData(object? sender, EventArgs e)
        {
            var dt=dataGridView1.DataSource as DataTable;
            if (dt.Rows.Count == 0) return;
            List<DeviceTempRecord> dtrs=dt.AsEnumerable().Select(row => new DeviceTempRecord()
            {
                CollectTime = row.Field<DateTime>("CollectTime"),
                DeviceStatus = row.Field<int>("DeviceStatus"),
                SetTemp = row.Field<int>("SetTemp"),
                RealTemp = row.Field<int>("RealTemp"),
                FaultCode = row.Field<int>("FaultCode"),

            }).ToList();

            string resStr=JsonSerializer.Serialize(dtrs, new JsonSerializerOptions()
            {
                WriteIndented = true,
                AllowTrailingCommas = true,
                Encoder=System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
            Console.WriteLine(resStr);
            using (SaveFileDialog Sf = new SaveFileDialog()){
                Sf.Title = "保存历史数据";
                Sf.Filter = "JSON文件|*.json";
                Sf.FileName = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
                if (Sf.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(Sf.FileName, resStr );
                }
            }

        }

        private  void TempCala(DataTable dt)
        {
            if(dt== null||dt.Rows.Count==0)
            {
                label4.Text = "最高温度：NaN";
                label5.Text = "最低温度：NaN";
                label6.Text = "平均温度：NaN";
                return;
            }
            var MaxTemp = dt.Compute("Max(RealTemp)", "");
            var MinTemp = dt.Compute("Min(RealTemp)", "");
            var AvgTemp = dt.Compute("Avg(RealTemp)", "");
            label4.Text = $"最高温度：{MaxTemp}°C";
            label5.Text = $"最低温度：{MinTemp}°C";
            label6.Text = $"平均温度：{AvgTemp}°C";

            //Console.WriteLine(dt.Compute("Max(RealTemp)", ""));
            //Console.WriteLine(dt.Compute("Min(RealTemp)", ""));
            //Console.WriteLine(dt.Compute("Avg(RealTemp)", ""));
            //Console.WriteLine(dt.Compute("Sum(RealTemp)", ""));
        }

        private async void SearchData(object? sender, EventArgs e)
        {
            DataTable SearchDt = await MysqlHandler.SearchByTime(dateTimePicker1.Value, dateTimePicker2.Value);
            dataGridView1.DataSource = SearchDt;
            TempCala(SearchDt);
        }

        private async void SetDataColumns()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "CollectTime",
                Name = "CollectTime",
                HeaderText = "采集时间",
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "yyyy-MM-dd hh:mm:ss",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "DeviceStatus",
                Name = "DeviceStatus",
                HeaderText = "设备状态",
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "SetTemp",
                Name = "SetTemp",
                HeaderText = "设定温度",
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "RealTemp",
                Name = "RealTemp",
                HeaderText = "实际温度",
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "FaultCode",
                Name = "FaultCode",
                HeaderText = "故障码",
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataTable dt=await MysqlHandler.SearchAll();
            dataGridView1.DataSource = dt;
            TempCala(dt);
        }
    }
}
