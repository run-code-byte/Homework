using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCM.mysql
{
    internal class MysqlBase
    {
        private string IP = "127.0.0.1";
        private int Port = 3306;
        private string DataBase;
        private string Uid = "root";
        private string Password = "root";
        private string Charset="UTF-8";
        private string ConnStr = "";
        internal MysqlBase(string db)
        {
            DataBase=db;
            ConnStr = $"server={IP};port={Port};database={DataBase};uid={Uid};password={Password};charset={Charset}";
        }
        internal async Task<DataTable> SearchData(string sql)
        {
            DataTable dt = new DataTable();
            using(MySqlConnection Conn = new MySqlConnection(ConnStr))
            {
                await Conn.OpenAsync();
                using (MySqlCommand CMD = new MySqlCommand(sql,Conn))
                {
                    MySqlDataAdapter Ada = new MySqlDataAdapter(CMD);
                    Ada.Fill(dt);
                } 
            }
            return dt;
        }

        internal async Task<bool> Handler(string sql)
        {
            using (MySqlConnection Conn = new MySqlConnection(ConnStr))
            {
                await Conn.OpenAsync();
                using (MySqlCommand CMD = new MySqlCommand(sql, Conn))
                {
                    int row=CMD.ExecuteNonQuery();
                    if (row > 0) return true;
                    return false;
                }
            }
        }

    }
}
