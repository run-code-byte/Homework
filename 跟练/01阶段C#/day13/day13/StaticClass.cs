using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace day13
{
    internal static class Tool
    {
        public static double GetRanD()
        {
            return new Random().NextDouble();
        }
        public static int GetRanI(int n,int m=0)
        {
            return new Random().Next(m, n);
        }
        public static char GetRanL()
        {
            var str = "qdfsiqhrbjfjnjfsyttyio";
            int index = GetRanI( str.Length - 1);
            return str[index];
        }

        public static string JsonFn(List<Dictionary<string,dynamic>> data)
        {
            return JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                AllowTrailingCommas= true,
                WriteIndented = true,
            });
        }
    }
}
