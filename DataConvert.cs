using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DisDemo
{
    public class DataConvert
    {
        public static bool IsValidIP(string strIP)
        {
            // 先检查有无非数字字符
            if (!Regex.IsMatch(strIP, "^[0-9.]+$"))
            {
                return false;
            }
            // 再检查数据范围是否合理
            string[] strNumArray = strIP.Split('.');
            if (strNumArray.Length != 4)
            {
                return false;
            }
            int n = 0;
            for (int i = 0; i < 4; ++i)
            {
                n = int.Parse(strNumArray[i]);
                if (n > 255)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsHexCharacter(string str)
        {
            return Regex.IsMatch(str, "^[0-9A-Fa-f]+$");
        }

        // 大小端转换
        public static UInt16 ReverseByte(UInt16 value)
        {
            return (UInt16)((value & 0xFFU) << 8 | (value & 0xFF00U) >> 8);
        }

        public static bool IsDecNumber(string str)
        {
            return Regex.IsMatch(str, "^[0-9]+$");
        }
    }
}
