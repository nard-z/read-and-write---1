using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Data.OleDb;

namespace DisDemo
{
    public class PageFun
    {
        public static DataTable PageDataTableClone(DataTable dt, int index, int size, Dictionary<string, MultiArea> format)
        {
            DataTable dtResult = new DataTable();
            if (index * size + size > dt.Rows.Count)
            {
                dtResult = dt.Clone();
                foreach (string key in format.Keys)
                {
                    dtResult.Columns[key].DataType = typeof(string);
                }
                for (int i = index * size; i < dt.Rows.Count; i++)
                {
                    DataRow rowNew = dtResult.NewRow();
                    foreach (string key in format.Keys)
                    {
                        rowNew[key] = dt.Rows[i][key].ToString();
                    }
                    dtResult.Rows.Add(rowNew);
                }
                return dtResult;
            }
            else
            {
                dtResult = dt.Clone();
                foreach (string key in format.Keys)
                {
                    dtResult.Columns[key].DataType = typeof(string);
                }
                for (int i = index * size; i < index * size + size; i++)
                {
                    DataRow rowNew = dtResult.NewRow();
                    foreach (string key in format.Keys)
                    {
                        rowNew[key] = dt.Rows[i][key].ToString();
                    }
                    dtResult.Rows.Add(rowNew);
                }
                return dtResult;
            }
        }

        public static DataTable PageDataTableClone(DataTable dt, int index, int size)
        {
            DataTable dtResult = new DataTable();
            dtResult = dt.Clone();
            for (int i = 0; i < dtResult.Columns.Count; i++)
            {
                dtResult.Columns[i].DataType = typeof(string);
            }
            if (index * size + size > dt.Rows.Count)
            {
                for (int i = index * size; i < dt.Rows.Count; i++)
                {
                    DataRow rowNew = dtResult.NewRow();
                    for (int j = 0; j < dtResult.Columns.Count; j++)
                    {
                        rowNew[j] = dt.Rows[i][j].ToString();
                    }
                    dtResult.Rows.Add(rowNew);
                }
            }
            else
            {
                for (int i = index * size; i < index * size + size; i++)
                {
                    DataRow rowNew = dtResult.NewRow();
                    for (int j = 0; j < dtResult.Columns.Count; j++)
                    {
                        rowNew[j] = dt.Rows[i][j].ToString();
                    }
                    dtResult.Rows.Add(rowNew);
                }
            }

            return dtResult;
        }

        public static DataTable GetTables(Dictionary<string, MultiArea> format, int number)
        {
            DataTable dt = new DataTable();
            //   string result =  "0";
            foreach (string key in format.Keys)
            {
                dt.Columns.Add(key);
            }
            for (int i = 0; i < number; i++)
            {
                DataRow rowNew = dt.NewRow();
                foreach (string key in format.Keys)
                {
                    if (i == 0)
                    {
                        rowNew[key] = format[key].currentStr = format[key].startStr;
                    }
                    else
                    {
                        rowNew[key] = format[key].currentStr = AddStr(format[key].currentStr, format[key].step,format[key].startValue);
                    }

                }
                dt.Rows.Add(rowNew);
            }
            return dt;
        }

        public static string AddStr(string str, byte step,byte startValue)
        {
            byte[] byteArray = new byte[str.Length / 2];
            for (int i = 0; i < str.Length / 2; i++)
            {
                byteArray[i] = Convert.ToByte(str.Substring(2 * i, 2), 16);
            }
            if ((byteArray[(byteArray.Length-startValue) - 1] + step) > 0xFF)
            {
                byteArray[(byteArray.Length - startValue) - 1] = (byte)(byteArray[(byteArray.Length - startValue) - 1] + step);
                for (int j = (byteArray.Length - startValue) - 2; j >= 0; j--)
                {
                    if ((byteArray[j] + 1) > 0xFF)
                    {
                        byteArray[j] = (byte)(byteArray[j] + 1);
                        continue;
                    }
                    else
                    {
                        byteArray[j] = (byte)(byteArray[j] + 1);
                        break;
                    }
                }
            }
            else
            {
                byteArray[(byteArray.Length - startValue) - 1] = (byte)(byteArray[(byteArray.Length - startValue) - 1] + step);
            }
            

            string strResult = "";
            for (int i = 0; i < byteArray.Length; i++) // 前面３个字节为输入的参数
            {
                strResult += string.Format("{0:X2}", byteArray[i]);
            }
            return strResult;
        }

        internal static DataTable GetTables()
        {
            OpenFileDialog fd = new OpenFileDialog();//首先根据打开文件对话框，选择excel表格
            fd.Filter = "Form" + "|*.xls;*.xlsx";//打开文件对话框筛选器
            string strPath;//文件完整的路径名
            DataTable dt = new DataTable();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    RegistryKey reg_TypeGuessRows = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Jet\4.0\Engines\Excel");
                    reg_TypeGuessRows.SetValue("TypeGuessRows", 5000);
                    strPath = fd.FileName;
                    string strCon = "provider=Microsoft.Ace.OleDb.12.0;data source=" + strPath + ";extended properties='Excel 12.0;HDR=Yes;IMEX=1';";//关键是红色区域
                    OleDbConnection Con = new OleDbConnection(strCon);//建立连接
                    string strSql = "select * from [Sheet1$]";//表名的写法也应注意不同，对应的excel表为sheet1，在这里要在其后加美元符号$，并用中括号
                    OleDbCommand Cmd = new OleDbCommand(strSql, Con);//建立要执行的命令
                    OleDbDataAdapter da = new OleDbDataAdapter(Cmd);//建立数据适配器
                    DataSet ds = new DataSet();//新建数据集
                    da.Fill(ds, "shyman");//把数据适配器中的数据读到数据集中的一个表中（此处表名为shyman，可以任取表名）
                    //指定datagridview1的数据源为数据集ds的第一张表（也就是shyman表），也可以写ds.Table["shyman"]

                    //    dataGridView1.DataSource = ds.Tables[0];
                    dt = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);//捕捉异常
                }

            }
            return dt;
        }

        public static string AddSpace(string strSource)
        {
            if (strSource.Length % 2 != 0)
            {
                return "";
            }
            else
            {
                string strResult = "";
                byte[] byteArray = new byte[strSource.Length / 2];
                for (int i = 0; i < strSource.Length / 2; ++i)
                {
                    byteArray[i] = Convert.ToByte(strSource.Substring(2 * i, 2), 16);
                    strResult += string.Format("{0:X2} ", byteArray[i]);
                }
                return strResult;
            }

        }
        /// <summary>
        /// 2-1方式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        internal static string weigandStrTostr1(string str)
        {
            try
            {
                if (str.Length < 8)
                {
                    str = str.PadLeft(8, '0');
                }
                byte[] data = new byte[4];
                data[0] = 0;
                data[1] = byte.Parse(str.Substring(0, 3));
                data[2] = (byte)(ushort.Parse(str.Substring(3, str.Length - 3)) >> 8);
                data[3] = (byte)(ushort.Parse(str.Substring(3, str.Length - 3)));
                str = "";
                for (int i = 0; i < data.Length; ++i)
                {
                    str += string.Format("{0:X2} ", data[i]);
                }
                return str;
            }
            catch
            {
                return "";
            }

        }
        /// <summary>
        /// 3-0方式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        internal static string weigandStrTostr2(string str)
        {
            try
            {
                if (str.Length < 8)
                {
                    str = str.PadLeft(8, '0');
                }
                byte[] data = new byte[4];
                data[0] = 0;
                data[1] = (byte)(int.Parse(str) >> 16);
                data[2] = (byte)(int.Parse(str) >> 8);
                data[3] = (byte)(int.Parse(str));
                str = "";
                for (int i = 0; i < data.Length; ++i)
                {
                    str += string.Format("{0:X2} ", data[i]);
                }
                return str;
            }
            catch
            {
                return "";
            }

        }

        internal static string strToWeigandStr1(string str)
        {
            try
            {
                string strResult = "";
                if (str.Length != 8)
                {
                    return strResult;
                }
                byte[] data = new byte[4];
                for (int i = 0; i < str.Length / 2; ++i)
                {
                    data[i] = Convert.ToByte(str.Substring(2 * i, 2), 16);
                }
                strResult += data[1].ToString();
                ushort result = (ushort)(data[2] << 8 | data[3]);
                strResult += result.ToString();
                return strResult;
            }
            catch
            {
                return "";
            }

        }

        internal static string strToWeigandStr2(string str)
        {
            try
            {
                if (str.Length != 8)
                {
                    return "";
                }
                byte[] data = new byte[4];
                for (int i = 0; i < str.Length / 2; ++i)
                {
                    data[i] = Convert.ToByte(str.Substring(2 * i, 2), 16);
                }
                int result = (int)(data[1] << 16 | data[2] << 8 | data[3]);
                return result.ToString();
            }
            catch
            {
                return "";
            }

        }
    }
}
