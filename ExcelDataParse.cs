using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Resources;
using System.Net;
using System.Net.Sockets;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO.Ports;
using System.Configuration;
using System.Data.OleDb;

namespace DisDemo
{
    public class ExcelDataParse
    {
        internal static DataTable GetTagInfo()
        {
            string strPath = "TagInfo.xlsx";//文件完整的路径名
            DataTable dt = new DataTable();
            try
            {
                RegistryKey reg_TypeGuessRows = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Jet\4.0\Engines\Excel");
                reg_TypeGuessRows.SetValue("TypeGuessRows", 5000);
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
            return dt;
        }


        /// <summary>
        /// 根据C#值把它转换成Excel值
        /// 2015-11-9
        /// hz
        /// </summary>
        /// <param name="Value">值</param>
        /// <returns>Excel样式，数据类型，文本</returns>
        public static object[] ExcelContent(object Value)
        {
            object[] strValue = new object[3];
            System.Type rowType = Value.GetType();
            switch (rowType.ToString())
            {
                case "System.String":
                case "System.Guid":
                    string XMLstring = Value.ToString();
                    XMLstring = XMLstring.Trim();
                    XMLstring = XMLstring.Replace("&", "&");
                    XMLstring = XMLstring.Replace(">", ">");
                    XMLstring = XMLstring.Replace("<", "<");
                    strValue[0] = "StringLiteral";
                    strValue[1] = "String";
                    strValue[2] = XMLstring;
                    break;
                case "System.DateTime":
                    DateTime XMLDate = (DateTime)Value;
                    string XMLDatetoString = ""; //Excel Converted Date
                    //把日期时间转化为：“yyyy-MM-ddTHH:mm:ss”这种Excel中的格式
                    XMLDatetoString = XMLDate.ToString(System.Globalization.DateTimeFormatInfo.CurrentInfo.SortableDateTimePattern);
                    strValue[0] = "DateLiteral";
                    strValue[1] = "DateTime";
                    if (XMLDate < Convert.ToDateTime("1900-1-1"))
                    {
                        strValue[0] = "StringLiteral";
                        strValue[1] = "String";
                        XMLDatetoString = string.Empty;
                    }
                    strValue[2] = XMLDatetoString;
                    break;
                case "System.Boolean":
                    strValue[0] = "StringLiteral";
                    strValue[1] = "String";
                    strValue[2] = Value.ToString();
                    break;
                case "System.Int16":
                case "System.Int32":
                case "System.Int64":
                case "System.Byte":
                    strValue[0] = "Integer";
                    strValue[1] = "Number";
                    strValue[2] = Value.ToString();
                    break;
                case "System.Byte[]":
                    strValue[0] = "StringLiteral";
                    strValue[1] = "String";
                    strValue[2] = (byte[])Value;
                    break;
                case "System.Decimal":
                case "System.Double":
                    strValue[0] = "Decimal";
                    strValue[1] = "Number";
                    strValue[2] = Value.ToString();
                    break;
                case "System.DBNull":
                    strValue[0] = "StringLiteral";
                    strValue[1] = "String";
                    strValue[2] = "";
                    break;
                default:
                    throw (new Exception(rowType.ToString() + " not handled."));
            }
            return strValue;
        }


        /// <summary>
        /// SaveExcel
        /// hz
        /// 2015-11-9
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="filePath"></param>
        private int SaveExcel(System.Data.DataTable dt, string filePath)
        {
            int reg = 0;
            try
            {
                //将要生成的Excel文件                
                StreamWriter writer = new StreamWriter(filePath, false);
                writer.WriteLine("<?xml version=\"1.0\"?>");
                writer.WriteLine("<?mso-application progid=\"Excel.Sheet\"?>");
                //Excel工作薄开始
                writer.WriteLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
                writer.WriteLine(" xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
                writer.WriteLine(" xmlns:x=\"urn:schemas-microsoft-com:office:excel\"");
                writer.WriteLine(" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\"");
                //writer.WriteLine(" xmlns:html=\"http://www.w3.org/TR/REC-html40//">");
                writer.WriteLine(" <DocumentProperties xmlns=\"urn:schemas-microsoft-com:office:office\">");
                writer.WriteLine(" <Author>Mrluo735</Author>");
                writer.WriteLine(string.Format("  <Created>{0}T{1}Z</Created>", DateTime.Now.ToString("yyyy-mm-dd"), DateTime.Now.ToString("HH:MM:SS")));
                writer.WriteLine(" <Company>Mrluo735</Company>");
                writer.WriteLine(" <Version>11.6408</Version>");
                writer.WriteLine(" </DocumentProperties>");
                writer.WriteLine(" <ExcelWorkbook xmlns=\"urn:schemas-microsoft-com:office:excel\">");
                writer.WriteLine("  <WindowHeight>8955</WindowHeight>");
                writer.WriteLine("  <WindowWidth>11355</WindowWidth>");
                writer.WriteLine("  <WindowTopX>480</WindowTopX>");
                writer.WriteLine("  <WindowTopY>15</WindowTopY>");
                writer.WriteLine("  <ProtectStructure>False</ProtectStructure>");
                writer.WriteLine("  <ProtectWindows>False</ProtectWindows>");
                writer.WriteLine(" </ExcelWorkbook>");
                //Excel工作薄结束
                //工作薄样式
                writer.WriteLine("<Styles>");
                writer.WriteLine("<Style ss:ID=\"Default\" ss:Name=\"Normal\">");
                writer.WriteLine("  <Alignment ss:Vertical=\"Center\" ss:WrapText=\"1\"/>");
                //writer.WriteLine("  <Borders>");
                //writer.WriteLine("      <Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
                //writer.WriteLine("      <Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
                //writer.WriteLine("      <Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/> ");
                //writer.WriteLine("      <Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
                //writer.WriteLine("  </Borders>");
                writer.WriteLine(string.Format("<Font ss:FontName=\"{0}\" x:CharSet=\"{1}\" ss:Size=\"{2}\"/>", "宋体", 134, 12));
                writer.WriteLine("  <Interior/>");
                writer.WriteLine("  <Protection/>");
                writer.WriteLine("</Style>");
                writer.WriteLine("  <Style ss:ID=\"s21\">");
                writer.WriteLine("   <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Center\" ss:WrapText=\"1\"/>");
                writer.WriteLine("  </Style>");
                writer.WriteLine("<Style ss:ID=\"BoldColumn\">");
                writer.WriteLine("  <Font ss:FontName=\"宋体\" ss:Bold=\"1\" ss:Size=\"14\"/>");
                writer.WriteLine("  <Borders>");
                writer.WriteLine("      <Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
                writer.WriteLine("      <Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
                writer.WriteLine("      <Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
                writer.WriteLine("      <Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
                writer.WriteLine("      <Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
                writer.WriteLine("  </Borders>");
                writer.WriteLine("</Style>");
                writer.WriteLine("<Style ss:ID=\"DataColumn\">");
                writer.WriteLine("  <Font ss:FontName=\"宋体\" ss:WrapText=\"1\"/>");
                writer.WriteLine("  <Borders>");
                writer.WriteLine("      <Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
                writer.WriteLine("      <Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
                writer.WriteLine("      <Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
                writer.WriteLine("      <Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/>");
                writer.WriteLine("  </Borders>");
                writer.WriteLine("</Style>");
                //文本样式
                writer.WriteLine("<Style ss:ID=\"StringLiteral\">");
                writer.WriteLine("  <NumberFormat ss:Format=\"@\"/>");
                writer.WriteLine("</Style>");
                //浮点型样式
                writer.WriteLine("<Style ss:ID=\"Decimal\">");
                writer.WriteLine("  <NumberFormat ss:Format=\"0.00\"/>");
                writer.WriteLine("</Style>");
                //整型样式
                writer.WriteLine("<Style ss:ID=\"Integer\">");
                writer.WriteLine("  <NumberFormat ss:Format=\"0\"/>");
                writer.WriteLine("</Style>");
                //日期样式
                writer.WriteLine("<Style ss:ID=\"DateLiteral\">");
                writer.WriteLine("  <NumberFormat ss:Format=\"yyyy/mm/dd;@\"/>");
                writer.WriteLine("</Style>");
                writer.WriteLine(" </Styles>");

                int rows = dt.Rows.Count + 1;
                int cols = dt.Columns.Count;
                //第i个工作表
                writer.WriteLine(string.Format("<Worksheet ss:Name=\"{0}\">", dt.TableName));
                writer.WriteLine(string.Format("    <Table ss:ExpandedColumnCount=\"{0}\" ss:ExpandedRowCount=\"{1}\" x:FullColumns=\"1\"", cols.ToString(), rows.ToString()));
                writer.WriteLine("   x:FullRows=\"1\">");

                int width = 80;
                //指定每一列的宽度
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    if (c == 1) width = 245; else width = 80;
                    writer.WriteLine(string.Format("<Column ss:Index=\"{0}\" ss:AutoFitWidth=\"{1}\" ss:Width=\"{2}\"/> ", c + 1, 1, width));
                }

                //生成标题
                writer.WriteLine(string.Format("<Row ss:AutoFitHeight=\"{0}\" ss:Height=\"{1}\">", 0, 28.5));
                foreach (DataColumn eachCloumn in dt.Columns)
                {
                    //writer.Write("<Cell ss:StyleID=\"s21\"><Data ss:Type=\"String\">");
                    writer.Write("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">");
                    writer.Write(eachCloumn.ColumnName.ToString());
                    writer.WriteLine("</Data></Cell>");
                }
                writer.WriteLine("</Row>");

                //生成数据记录
                foreach (DataRow eachRow in dt.Rows)
                {
                    writer.WriteLine("<Row ss:AutoFitHeight=\"0\">");
                    for (int currentRow = 0; currentRow != cols; currentRow++)
                    {
                        object[] getValue = ExcelContent(eachRow[currentRow]);

                        //writer.Write(string.Format("<Cell ss:StyleID=\"{0}\"><Data ss:Type=\"{1}\">", getValue[0], getValue[1]));
                        writer.Write("<Cell ss:StyleID=\"DataColumn\"><Data ss:Type=\"String\">");
                        writer.Write(getValue[2]);
                        writer.WriteLine("</Data></Cell>");
                    }
                    writer.WriteLine("</Row>");
                }
                writer.WriteLine("</Table>");
                writer.WriteLine("<WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\">");
                writer.WriteLine("<Selected/>");
                writer.WriteLine("<Panes>");
                writer.WriteLine("<Pane>");
                writer.WriteLine("  <Number>3</Number>");
                writer.WriteLine("  <ActiveRow>1</ActiveRow>");
                writer.WriteLine("</Pane>");
                writer.WriteLine("</Panes>");
                writer.WriteLine("<ProtectObjects>False</ProtectObjects>");
                writer.WriteLine("<ProtectScenarios>False</ProtectScenarios>");
                writer.WriteLine("</WorksheetOptions>");
                writer.WriteLine("</Worksheet>");

                writer.WriteLine("</Workbook>");
                writer.Close();
            }
            catch (Exception)
            {
                reg = -1;
            }
            return reg;
        }

        public static void WriteFileSeparator(string strTxt, string path)
        {
            using (StreamWriter wlog = File.AppendText(path))
            {
                wlog.Write("{0}", strTxt);
            }
        }
    }
}
