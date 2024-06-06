using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using System.Configuration;
using System.Resources;
using Microsoft.Win32;

namespace DisDemo
{
    public partial class BathReadWrite : Form
    {

        [DllImport("user32.dll")]
        public static extern int MessageBoxTimeoutA(IntPtr hWnd, string msg, string Caps, int type, int Id, int time);//引用DLL

        [DllImport("user32.dll")]
        public static extern int MessageBoxEx(IntPtr hWnd, string lpText, string IpCaption, uint UType, ushort wLanguageld);

        private int device;
        private int currentRow;
        private ResourceManager rm;

        private string unWriteStr;
        private string checkResultStr;
        private string TIDStr;
        private string importErrorMsgStr;
        private string stateStr;
        private string beforeWriteDataStr;
        private string WriteSuccess;
        private string WriteFailed;
        private string finishWriteStr;
        private string excelCreatErrorStr;
        private string excelSaveSuccessStr;
        private string excelPathErrorStr;
        private string formStr;
        private string tipStr;


        private int ccurrentPage;
        private int csize;
        private int cmaxPage;
        private int cminPage;
        private int coffsetSize;
        private int cfixColumn;

        private DataTable[] tables;

        private static int number;

        public BathReadWrite()
        {
            InitializeComponent();
        }

        public BathReadWrite(int deviceNo, ResourceManager rm)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.device = deviceNo;
            this.rm = rm;
            currentRow = 0;
            InitForm();
            InitPara();
            m_SyncContext = SynchronizationContext.Current;
            this.ChangeLanguage(rm);
        }

        private void InitPara()
        {
            WriteTagDataFormat.tables = new Dictionary<string, MultiArea>();
            byte area = byte.Parse(ConfigurationManager.AppSettings["Area"]);
            byte bank = 0;
            byte startAdd = 0;
            byte len = 0;
            if (WriteTagDataFormat.tables.Count <= 0)
            {
                if ((area & 0x01) != 0)        //有epc
                {
                    bank = byte.Parse(ConfigurationManager.AppSettings["BankEPC"]);
                    startAdd = byte.Parse(ConfigurationManager.AppSettings["StartAddEPC"]);
                    len = byte.Parse(ConfigurationManager.AppSettings["LengthEPC"]);
                    MultiArea epc = new MultiArea(bank, startAdd, len);
                    epc.startStr = ConfigurationManager.AppSettings["StartValueEPC"];
                    epc.step = byte.Parse(ConfigurationManager.AppSettings["StepValueEPC"]);
                    WriteTagDataFormat.tables.Add("EPC", epc);
                }
                if ((area & 0x02) != 0)   //有密码
                {
                    bank = byte.Parse(ConfigurationManager.AppSettings["BankRFU"]);
                    startAdd = byte.Parse(ConfigurationManager.AppSettings["StartAddRFU"]);
                    len = byte.Parse(ConfigurationManager.AppSettings["LengthRFU"]);
                    MultiArea rfu = new MultiArea(bank, startAdd, len);
                    rfu.startStr = ConfigurationManager.AppSettings["StartValueRFU"];
                    rfu.step = byte.Parse(ConfigurationManager.AppSettings["StepValueRFU"]);
                    WriteTagDataFormat.tables.Add("RFU", rfu);
                }
                if ((area & 0x04) != 0)
                {
                    bank = byte.Parse(ConfigurationManager.AppSettings["BankUSR"]);
                    startAdd = byte.Parse(ConfigurationManager.AppSettings["StartAddUSR"]);
                    len = byte.Parse(ConfigurationManager.AppSettings["LengthUSR"]);
                    MultiArea usr = new MultiArea(bank, startAdd, len);
                    usr.startStr = ConfigurationManager.AppSettings["StartValueUSR"];
                    usr.step = byte.Parse(ConfigurationManager.AppSettings["StepValueUSR"]);
                    WriteTagDataFormat.tables.Add("USER", usr);
                }
            }

        }

        private void InitForm()
        {
            TIDStr = "TID";
            ccurrentPage = 0;
            csize = 100;
            coffsetSize = 20;
            try
            {
                this.historyPath = ConfigurationManager.AppSettings["FilePath"];
                BathReadWrite.number = int.Parse(ConfigurationManager.AppSettings["Number"]);
                mode = int.Parse(ConfigurationManager.AppSettings["Mode"]);
            }
            catch
            {

            }
            unWriteStr = rm.GetString("unWriteStr");
            checkResultStr = rm.GetString("checkResultStr");
            importErrorMsgStr = rm.GetString("NoInvaludeLine");
            stateStr = rm.GetString("stateStr");
            beforeWriteDataStr = rm.GetString("beforeWriteDataStr");
            WriteSuccess = rm.GetString("WriteSuccess");
            WriteFailed = rm.GetString("WriteFailed");
            finishWriteStr = rm.GetString("finishWriteStr");
            excelCreatErrorStr = rm.GetString("excelCreatErrorStr");
            excelSaveSuccessStr = rm.GetString("excelSaveSuccessStr");
            excelPathErrorStr = rm.GetString("excelPathErrorStr");
            formStr = rm.GetString("formStr");
            tipStr = rm.GetString("Tips");
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (mode == 0)                  //导入原始数据
            {
                InportDataSource(PageFun.GetTables(), this.dataGridView1, WriteTagDataFormat.tables);
            }
            else if (mode == 1)                //自动跳步方式
            {
                InportDataSource(PageFun.GetTables(WriteTagDataFormat.tables, number), this.dataGridView1, WriteTagDataFormat.tables);
            }
            else if (mode == 2)           //导入完整数据
            {
                InportDataSource(PageFun.GetTables(), this.dataGridView1);
            }

        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            /* for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
             {
                 DataGridViewRow r = this.dataGridView1.Rows[i];
                 r.HeaderCell.Value = string.Format("{0}", i + 1);
             }
             this.dataGridView1.Refresh();*/
        }

        private string backStr = "";
        SynchronizationContext m_SyncContext = null;
        private bool startCheck;
        private bool autoWrite;
        private byte startAdd;
        private byte bank;
        private byte length;
        private void btnStartAutoWrite_Click(object sender, EventArgs e)
        {
            if (btnStartAutoWrite.Text == rm.GetString("startStr"))
            {
                AutoWriteCardFilter(WriteTagDataFormat.tables);
                btnStartAutoWrite.Text = rm.GetString("strStopRead");
            }
            else if (btnStartAutoWrite.Text == rm.GetString("strStopRead"))
            {
                autoWrite = false;
                startCheck = false;
                backStr = "";
                btnStartAutoWrite.Text = rm.GetString("startStr");
            }

        }

        private void UpdataDataGrid(object state)
        {
            dataGridView1.DataSource = state as DataTable;
            dataGridView1.FirstDisplayedScrollingRowIndex = currentRow - ((currentRow / csize) * csize) - (currentRow % coffsetSize);
            if (ccurrentPage == currentRow / csize)
            {

            }
            else
            {
                label1.Text = (currentRow / csize).ToString();
                ccurrentPage = currentRow / csize;
                UpdateGridviewHeader(ccurrentPage, csize);
            }

        }

        private void UpdateGridviewHeader(int ccurrentPage, int csize)
        {
            throw new NotImplementedException();
        }

        private void UpdataOkImage(object state)
        {
            // pictureBox1.Image = Properties.Resources.yuandian;
            pictureBox1.Image = state as Image;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            /* if (CheckStartBtn.Text == rm.GetString("checkStartStr"))
             {
                 校验ToolStripMenuItem_Click(null, null);
                 CheckStartBtn.Text = rm.GetString("strStopRead");
                 startAutoWrite.Enabled = false;
             }
             else if (CheckStartBtn.Text == rm.GetString("strStopRead"))
             {
                 autoWrite = false;
                 startCheck = false;
                 backStr = "";
                 CheckStartBtn.Text = rm.GetString("checkStartStr");
                 startAutoWrite.Enabled = true;
             }
             */
        }


        private void CheckTag(byte startAdd, byte bank, byte length)
        {
            startCheck = true;
            new Task(() =>
            {
                DataTable source = dataGridView1.DataSource as DataTable;
                byte Length = (byte)(source.Rows[0][0].ToString().Length / 4);
                byte[] byteArray;
                string str;
                bool isCheckRight;
                int checkIndex = 0;
                while (startCheck)
                {
                    isCheckRight = false;
                    byteArray = new byte[64];
                    str = "";
                    byte data_len = 0;
                    if (1 == Discrete.ReadTagData(device, bank, startAdd, length, byteArray, out data_len))
                    {
                        for (int i = 0; i < data_len; i++) // 前面３个字节为输入的参数
                        {
                            str += string.Format("{0:X2}", byteArray[i]);
                        }

                        for (int index = 0; index < source.Rows.Count; index++)
                        {
                            if (str.IndexOf(source.Rows[index][0].ToString(), StringComparison.OrdinalIgnoreCase) >= 0)
                            //   if (source.Rows[index][0].ToString() == str)
                            {
                                isCheckRight = true;
                                source.Rows[index][checkResultStr] = Convert.ToString((char)8730);
                                m_SyncContext.Post(UpdataDataGrid, source);
                                m_SyncContext.Post(UpdataOkImage, Properties.Resources.ResourceManager.GetObject("yuandian_1"));
                                checkIndex = index;
                                break;
                            }
                        }
                        if (!isCheckRight)
                        {
                            MessageBoxTimeoutA((IntPtr)0, unWriteStr, checkResultStr, 0, 0, 1000);
                        }
                    }
                    Thread.Sleep(1000);
                    m_SyncContext.Post(UpdataOkImage, Properties.Resources.ResourceManager.GetObject("yuandian"));
                }
            }).Start();
        }

        private void 校验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckTag(startAdd, bank, length);
        }

        private void BathReadWrite_Load(object sender, EventArgs e)
        {

        }

        ImportForm importForm;
        private void importToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }


        DataTable tableCollection;
        private void InportDataSource(DataTable tableResult, DataGridView dataGridView, Dictionary<string, MultiArea> format)
        {
            if (tableResult != null)
            {
                if (tableResult.Columns.Contains("EPC") || tableResult.Columns.Contains("RFU") || tableResult.Columns.Contains("USER"))
                {
                    try
                    {
                        cmaxPage = tableResult.Rows.Count / csize;
                        cminPage = 0;
                        tableCollection = PageFun.PageDataTableClone(tableResult, cminPage, tableResult.Rows.Count, format); ;
                        tableCollection.Columns.Add(stateStr);
                        tableCollection.Columns.Add(checkResultStr);
                        tableCollection.Columns.Add(TIDStr);
                        cfixColumn = tableCollection.Columns.Count;
                        tables = new DataTable[cmaxPage + 1];
                        for (int i = cminPage; i < cmaxPage + 1; i++)
                        {
                            tables[i] = PageFun.PageDataTableClone(tableCollection, i, csize, format);
                        }
                        dataGridView.DataSource = tables[cminPage];
                        // m_SyncContext.Post(UpdataDataGrid, PageFun.PageDataTableClone(tableCollection, minPage, size));
                        UpdateGridviewHeader(cminPage, csize);
                        label1.Text = ccurrentPage.ToString();
                        label3.Text = cmaxPage.ToString();
                    }
                    catch
                    {
                        MessageBox.Show(importErrorMsgStr);
                    }

                }
                else
                {
                    MessageBox.Show(importErrorMsgStr);
                }
            }

        }

        private void InportDataSource(DataTable tableResult, DataGridView dataGridView)
        {
            if (tableResult != null)
            {
                if (tableResult.Columns.Contains("EPC") || tableResult.Columns.Contains("RFU") || tableResult.Columns.Contains("USER"))
                {
                    cmaxPage = tableResult.Rows.Count / csize;
                    cminPage = 0;
                    tableCollection = tableResult;
                    cfixColumn = tableCollection.Columns.Count;
                    tables = new DataTable[cmaxPage + 1];
                    for (int i = cminPage; i < cmaxPage + 1; i++)
                    {
                        tables[i] = PageFun.PageDataTableClone(tableCollection, i, csize);
                    }
                    dataGridView.DataSource = tables[cminPage];
                    // m_SyncContext.Post(UpdataDataGrid, PageFun.PageDataTableClone(tableCollection, minPage, size));
                    UpdateGridviewHeader(cminPage, csize);
                    label1.Text = ccurrentPage.ToString();
                    label3.Text = cmaxPage.ToString();
                }
                else
                {
                    MessageBox.Show(importErrorMsgStr);
                }
            }

        }


        /// <summary>
        /// 克隆表格 改变第一列的类属性
        /// </summary>
        /// <param name="tableCollection"></param>
        /// <returns></returns>
        private DataTable DataTableClone(DataTable tableCollection, Dictionary<string, MultiArea> format)
        {
            DataTable dtResult = new DataTable();
            dtResult = tableCollection.Clone();
            foreach (string key in format.Keys)
            {
                dtResult.Columns[key].DataType = typeof(string);
            }
            foreach (DataRow sourceRow in tableCollection.Rows)
            {
                DataRow rowNew = dtResult.NewRow();
                foreach (string key in format.Keys)
                {
                    rowNew[key] = sourceRow[key].ToString();
                }
                dtResult.Rows.Add(rowNew);
            }
            return dtResult;
        }

        private void BathReadWrite_FormClosed(object sender, FormClosedEventArgs e)
        {
            startCheck = false;
            autoWrite = false;
        }



        private void StopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autoWrite = false;
            startCheck = false;
            backStr = "";
        }



        private void ClearsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            currentRow = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*  if (button3.Text == "补卡")
              {
                  byte mode = 0x02;
                  AutoWriteCard(mode, startAdd, bank, length);
                  button3.Text = "停止补卡";
                  button2.Enabled = false;
                  startAutoWrite.Enabled = false;
              }
              else
              {
                  autoWrite = false;
                  startCheck = false;
                  backStr = "";
                  button3.Text = "补卡";
                  button2.Enabled = true;
                  startAutoWrite.Enabled = true;
              }*/

        }

        private void AutoWriteCard(byte startMode, byte startadd, byte bank, byte Length)
        {
            autoWrite = true;
            if (startMode == 0x00)
            {
                currentRow = 0x00;
            }
            Task autoWriteTask = new Task(() =>
            {
                byte[] byteArray;
                string str;
                while (currentRow < dataGridView1.Rows.Count - 1 && autoWrite)
                {
                    DataTable source = dataGridView1.DataSource as DataTable;
                    Length = (byte)(source.Rows[currentRow][0].ToString().Length / 4);
                    if (startMode == 0x02)
                    {
                        bool isExit = false;
                        for (int start = 0; start < source.Rows.Count; start++)
                        {
                            if (source.Rows[start][3].ToString() == "")
                            {
                                currentRow = start;
                                isExit = true;
                                break;
                            }
                        }
                        if (!isExit)
                        {
                            break;
                        }
                    }
                    byteArray = new byte[64];
                    str = "";
                    byte data_len = 0;
                    if (1 == Discrete.ReadTagData(device, bank, startadd, (byte)Length, byteArray, out data_len))
                    {
                        for (int i = 3; i < 2 * Length + 3; i++) // 前面３个字节为输入的参数
                        {
                            str += string.Format("{0:X2}", byteArray[i]);
                        }
                        if (currentRow < source.Rows.Count)
                        {
                            source.Rows[currentRow][1] = str;
                            m_SyncContext.Post(UpdataDataGrid, source);
                        }
                        else
                        {
                            break;
                        }
                        if (str != backStr)
                        {
                            str = source.Rows[currentRow][0].ToString();
                            Length = (byte)(str.Length / 2);
                            for (int i = 0; i < 64; ++i)
                            {
                                if (i < Length)
                                {
                                    byteArray[i] = Convert.ToByte(str.Substring(2 * i, 2), 16);
                                }
                                else
                                {
                                    byteArray[i] = 0;
                                }
                            }
                            Length = (byte)(Length / 2);
                            if (1 == Discrete.WriteTagData(device, bank, startadd, (byte)Length, byteArray))
                            {
                                source.Rows[currentRow][2] = WriteSuccess;
                                backStr = str;
                                if (startMode == 0x00 || startMode == 0x01)
                                {
                                    currentRow++;
                                }

                            }
                            else
                            {
                                source.Rows[currentRow][2] = WriteFailed;
                            }
                            m_SyncContext.Post(UpdataDataGrid, source);
                        }
                        else
                        {
                            source.Rows[currentRow][2] = WriteSuccess;
                        }

                    }
                    Thread.Sleep(1000);
                }
                if (autoWrite)
                {
                    MessageBox.Show(finishWriteStr);
                }
            });
            autoWriteTask.Start();
        }

        /// <summary>
        /// 单个区域标签读写
        /// </summary>
        /// <param name="startadd"></param>
        /// <param name="bank"></param>
        /// <param name="Length"></param>
        private void AutoWriteCardFilter(Dictionary<string, MultiArea> writeData)
        {
            autoWrite = true;
            Task autoWriteTask = new Task(() =>
            {
                byte[] byteArray;
                string writeStr;
                string strTID = "";
                int page = 0;
                int index = 0;
                int length = 0;
                bool writeFinish;
                byte reWriteTimes = 0;
                string successTimes = "";
                while (currentRow < tableCollection.Rows.Count && autoWrite)
                {
                    byteArray = new byte[100];
                    strTID = "";
                    bool isExit = false;
                    byte data_len = 0;
                    int result = Discrete.ReadTagData(device, (byte)2, (byte)0, (byte)6, byteArray, out data_len);
                    if (1 == result)
                    {
                        for (int i = 0; i < data_len; i++) // 前面３个字节为输入的参数
                        {
                            strTID += string.Format("{0:X2}", byteArray[i]);
                        }
                        for (int start = 0; start < tableCollection.Rows.Count; start++)
                        {
                            if (tableCollection.Rows[start][stateStr].ToString() == WriteSuccess)
                            {
                                if (strTID == tableCollection.Rows[start][TIDStr].ToString())
                                {
                                    isExit = true;
                                    currentRow = start;
                                    page = currentRow / csize;
                                    index = currentRow % csize;
                                    if (tableCollection.Rows[currentRow][checkResultStr].ToString() != "")
                                    {
                                        successTimes = (int.Parse(tableCollection.Rows[currentRow][checkResultStr].ToString()) + 1).ToString();
                                        tableCollection.Rows[currentRow][checkResultStr] = successTimes;
                                        tables[page].Rows[index][checkResultStr] = successTimes;
                                    }
                                    m_SyncContext.Post(UpdataDataGrid, tables[page]);
                                    // MessageBoxTimeoutA((IntPtr)0,"重复写入", tipStr, 0, 0, 1000);
                                    break;
                                }
                                else
                                {
                                    continue;
                                }

                            }
                            else
                            {
                                if (strTID == tableCollection.Rows[start][TIDStr].ToString() || tableCollection.Rows[start][TIDStr].ToString() == "")
                                {
                                    currentRow = start;
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                        m_SyncContext.Post(UpdataOkImage, Properties.Resources.ResourceManager.GetObject("yuandian_1"));
                        if (!isExit)
                        {
                            page = currentRow / csize;
                            index = currentRow % csize;
                            writeFinish = false;
                            tableCollection.Rows[currentRow][TIDStr] = strTID;
                            tables[page].Rows[index][TIDStr] = strTID;
                            reWriteTimes = 0;
                            foreach (string key in writeData.Keys)
                            {
                                writeData[key].writeSuccess = false;
                            }
                            while (!writeFinish && reWriteTimes < 3)  //连续三次写不成功则跳过
                            {
                                writeFinish = true;
                                reWriteTimes++;
                                foreach (string key in writeData.Keys)
                                {
                                    if (!writeData[key].writeSuccess)        //还未写入
                                    {
                                        writeStr = tableCollection.Rows[currentRow][key].ToString();
                                        if (writeStr != "")
                                        {
                                            length = (byte)(writeStr.Length / 2);
                                            for (int i = 0; i < 64; ++i)
                                            {
                                                if (i < length)
                                                {
                                                    byteArray[i] = Convert.ToByte(writeStr.Substring(2 * i, 2), 16);
                                                }
                                                else
                                                    byteArray[i] = 0;
                                                {
                                                }
                                            }
                                            length = (byte)(length / 2);
                                            length = 6;
                                            int total = Discrete.WriteTagData(device, writeData[key].bank, writeData[key].startAdd, (byte)length, byteArray);
                                            if (1 == total)
                                            {
                                                writeData[key].writeSuccess = true;
                                            }
                                            else
                                            {
                                                writeFinish = false;
                                                tableCollection.Rows[currentRow][stateStr] = WriteFailed;
                                                tables[page].Rows[index][stateStr] = WriteFailed;
                                            }
                                        }
                                        else
                                        {
                                            writeData[key].writeSuccess = true;
                                        }

                                    }
                                }
                            }
                            if (reWriteTimes >= 3)
                            {
                                writeFinish = false;
                            }
                            if (writeFinish)             //连续三次没写成功
                            {
                                // MessageBoxEx((IntPtr)0, "标签可能存在问题,请更换标签继续写入", tipStr, 0, 2);
                                // autoWrite = false;
                                tableCollection.Rows[currentRow][stateStr] = WriteSuccess;
                                tables[page].Rows[index][stateStr] = WriteSuccess;
                                tableCollection.Rows[currentRow][checkResultStr] = "0";
                                tables[page].Rows[index][checkResultStr] = "0";
                            }

                            m_SyncContext.Post(UpdataDataGrid, tables[page]);
                        }
                    }
                    Thread.Sleep(500);
                    m_SyncContext.Post(UpdataOkImage, Properties.Resources.ResourceManager.GetObject("yuandian"));
                }
                if (autoWrite)
                {
                    MessageBox.Show(finishWriteStr);
                }
            });
            autoWriteTask.Start();
        }



        private void 从起始位置开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoWriteCard(0x00, startAdd, bank, length);
        }

        private void 从停止位置开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoWriteCard(0x01, startAdd, bank, length);
        }

        private void 从校验缺失位置开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoWriteCard(0x02, startAdd, bank, length);
        }

        // WriteTagDataFormat writeTagDataFormat;
        private void WAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WriteTagDataFormat writeTagDataFormat = new WriteTagDataFormat(rm);
            if (writeTagDataFormat.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ;
            }
        }

        private void ClearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable source = dataGridView1.DataSource as DataTable;
            if (source != null)
            {
                for (int index = 0; index < source.Rows.Count; index++)
                {
                    source.Rows[index][1] = "";
                    source.Rows[index][2] = "";
                    source.Rows[index][3] = "";
                }
            }
        }

        private void imporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tableCollection != null)
            {
                SaveData(tableCollection, historyPath, 0);
            }

        }

        string historyPath = "";
        private int mode;

        private void SaveData(DataTable source, string path, byte Mode)
        {
            string fileName = "";
            string saveFileName = "";
            if (path == "")
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.DefaultExt = "xls";
                saveDialog.Filter = "Excel2007|*.xlsx";
                saveDialog.FileName = fileName;
                saveDialog.ShowDialog();
                saveFileName = saveDialog.FileName;
                if (saveFileName.IndexOf(":") < 0) return; //被点了取消
                Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                cfa.AppSettings.Settings["FilePath"].Value = historyPath = saveDialog.FileName.Substring(0, saveDialog.FileName.LastIndexOf("\\"));
                cfa.Save();
            }
        }

        private void UpdateGridviewHeader1(int page, int size)
        {
            lock (dataGridView1)
            {
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow r = this.dataGridView1.Rows[i];
                    r.HeaderCell.Value = string.Format("{0}", page * size + i + 1);
                }
                this.dataGridView1.Refresh();
            }
        }

        internal void ChangeLanguage(ResourceManager rm)
        {
            throw new NotImplementedException();
        }
    }
}
