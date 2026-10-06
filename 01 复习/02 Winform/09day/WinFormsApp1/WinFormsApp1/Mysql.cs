using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    internal class Mysql
    {
        public string Server { get; set; } = "127.0.0.1";
        public string Port { get; set; } = "3306";
        public string Database { get; set; }
        public string Uid { get; set; } = "root";
        public string Password { get; set; } = "root";
        public string Charset { get; set; } = "utf8";

        private string ConnStr { get; set; }

        public Mysql(string database)
        {
            this.Database = database;
        }
        //public async void ConAndHandler(string sql,Action<MySqlCommand> handlerCall)
        //{
        //    ConnStr = $"server={Server};port={Port};database={Database};uid={Uid};password={Password};charset={Charset}";
        //    using(MySqlConnection Conn = new MySqlConnection(ConnStr))
        //    {
        //        await Conn.OpenAsync();
        //        using(MySqlCommand Cmd = new MySqlCommand(sql, Conn))
        //        {
        //            handlerCall(Cmd);
        //        }
        //    }
        //}
        public async Task<bool> ConAndHandler(string sql, Func<MySqlCommand, bool> handlerCall)
        {
            ConnStr = $"server={Server};port={Port};database={Database};uid={Uid};password={Password};charset={Charset}";
            using (MySqlConnection Conn = new MySqlConnection(ConnStr))
            {
                await Conn.OpenAsync();
                using (MySqlCommand Cmd = new MySqlCommand(sql, Conn))
                {
                    return handlerCall(Cmd);
                }
            }
        }

    }
}
