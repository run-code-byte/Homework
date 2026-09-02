using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace day09
{
    internal class MySql
    {
        public string Server { get; set; } = "127.0.0.1";
        public string Port { get; set; } = "3306";
        public string Database { get; set; }
        public string Uid { get; set; } = "root";
        public string Password { get; set; } = "root";
        public string Charset { get; set; } = "utf8";
        public string ConStr { get; set; }

        public MySql(string database)
        {
            this.Database = database;
        }
        public void ConAndHandler(string sql, Action<MySqlCommand> hadlercall)
        {
            ConStr = $"server={Server};port={Port};database={Database};uid={Uid};password={Password};charset={Charset}";
            using (MySqlConnection conn = new MySqlConnection(ConStr))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    hadlercall(cmd);
                }

            }
        }
    }
}

    
