using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    internal class Mysql
    {
        // 连接数据 属性
        public string Server { get; set; } = "127.0.0.1";
        public string Port { get; set; } = "3306";
        public string Database { get; set; }
        public string Uid { get; set; } = "root";
        public string Password { get; set; } = "root";
        public string Charset { get; set; } = "utf8";
        // 连接数据库字符串
        private string ConnStr { get; set; }

        public Mysql(string database)
        {
            this.Database = database;
        }

        // 数据库连接 及 操作
        //public void ConAndHandler(string sql, Action<MySqlCommand> handlerCall)
        //{
        //    // 拼接 数据库连接字符串
        //    ConnStr = $"server={Server};port={Port};database={Database};uid={Uid};password={Password};charset={Charset}";
        //    // 连接数据库
        //    using (MySqlConnection Conn = new MySqlConnection(ConnStr))
        //    {
        //        // 打开连接
        //        await Conn.OpenAsync();
        //        // 创建命令对象
        //        using (MySqlCommand Cmd = new MySqlCommand(sql, Conn))
        //        {
        //            handlerCall(Cmd); // 执行后续操作
        //        }
        //    }
        //}



        public async Task<bool> ConAndHandler(string sql, Func<MySqlCommand,bool> handlerCall)
        {
            // 拼接 数据库连接字符串
            ConnStr = $"server={Server};port={Port};database={Database};uid={Uid};password={Password};charset={Charset}";
            // 连接数据库
            using (MySqlConnection Conn = new MySqlConnection(ConnStr))
            {
                // 打开连接
                await Conn.OpenAsync();
                // 创建命令对象
                using (MySqlCommand Cmd = new MySqlCommand(sql, Conn))
                {
                    return handlerCall(Cmd); // 执行后续操作
                }
            }
        }

    }
}
