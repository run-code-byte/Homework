using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            button2.Click += SaveData; ;
        }

        private void SaveData(object? sender, EventArgs e)
        {
            
        }

        private void SearchData(object? sender, EventArgs e)
        {
            
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
        }
    }
}
