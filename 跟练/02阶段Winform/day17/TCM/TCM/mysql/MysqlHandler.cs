using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCM.mysql
{
    internal static class MysqlHandler
    {
        private static MysqlBase myBase = new MysqlBase("test");
        internal async static Task<DataTable> SearchAll()
        {
            string sql = "select *from DeviceTempRecord order by CollectTime DESC";
            return await myBase.SearchData(sql);
        }

        internal async static Task<DataTable> SearchByTime(DateTime t1,DateTime t2 )
        {
            string sql = "select *from DeviceTempRecord where CollecTime between '{t1}' and '{t2}' order by CollectTime DESC";
            return await myBase.SearchData(sql);
        }

        internal async static Task<bool> InserOne(ushort[] data)
        {
            var CollectTimeVal = DateTime.Now;
            var DeviceStatusVal = data[0];
            var SetTempVal = data[1];
            var RealTempVal = data[2];
            var FaultCodeVal = data[3];
            string sql = $"insert into DeviceTempRecord(CollectTime,DeviceStatus,SetTemp,RealTemp,FaultCode) value('{CollectTimeVal}','{DeviceStatusVal}','{SetTempVal}','{RealTempVal}','{FaultCodeVal}')";
            //Console.WriteLine(sql);
            return await myBase.Handler(sql);
        }
    }
}
