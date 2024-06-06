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
    public partial class MainWindow : Form
    {
        static List<EPC_data> Tag_data = new List<EPC_data>();
        static Dictionary<string, EPC_data> Tag_datas = new Dictionary<string, EPC_data>();
        static int nItemNo = 0; // 记录需要更新的EPC数据索引
        int addStart = 0;
        int addEnd = 0;
        int counts = 1;
        // 加载字符串资源
        static ResourceManager[] rmArray = new ResourceManager[2]{
                        new ResourceManager("DisDemo.SimpChinese", typeof(MainWindow).Assembly),
                        new ResourceManager("DisDemo.English", typeof(MainWindow).Assembly)};

        public static ResourceManager rm = rmArray[0];
        static byte deviceNo = 0;
        // 数据产生时，触发此事件，更新ListView控件
        public delegate void UpdateControlEventHandler();
        public static event UpdateControlEventHandler UpdateControl;
        //private static SynchronizationContext m_SyncContext = null;

        public delegate void UpdateConnectEventHandler(string key,int hDev);
        public static event UpdateConnectEventHandler UpdateConnect;

        static string epc;

        public  Discrete.FUN_SOCKET_CB socket_callback = new Discrete.FUN_SOCKET_CB(SocketCallBack);

        public static Discrete.FUN_DATA_CB data_callback = new Discrete.FUN_DATA_CB(DataCallBack);

        //存放已连接的对象
        public Dictionary<string, int> hashMap = new Dictionary<string, int>();

        private static string getDeviceKey(string host,int hDev)
        {
            byte device_id = 0;
            int result = Discrete.QueryDeviceId(hDev,out device_id);
            string device = "null";
            if(result > 0){
                device = device_id.ToString().PadLeft(5, '0');
            }
            return host + "_(" + hDev + ")_" + device;
        }

        public static void SocketCallBack(ref SocketInfoStruct socketInfo)
        {
            try
            {
                string host = Encoding.Default.GetString(socketInfo.IP);//IP地址
                int baudrateOrPort = socketInfo.port; //端口号
                host = host.Replace("\0", "");
                //Console.WriteLine("IP: " + host + " PORT: " + baudrateOrPort);
                int hDev = 0;
                int result = Discrete.TCPServerConnect(ref hDev, socketInfo.socket, data_callback, host, baudrateOrPort);//添加连接的对象;
                if (result > 0)
                {
                    //string keys = host + "_(" + hDev + ")";// "_已连接";
                    string keys = getDeviceKey(host,hDev);
                    mainWindow.BeginInvoke(UpdateConnect,keys, hDev);
                }
            }
            catch (Exception e)
            {
                mainWindow.lblMessageHit.Text = e.Message;
            }
        }

        private void UpdateTreeListView(string keys,int hDev){
            try{
                lock (hashMap)
                {
                    hashMap.Add(keys, hDev);
                    TreeNode node1 = new TreeNode(keys);
                    tvConnectList.Nodes[0].Nodes[2].Nodes.Add(node1);
                    tvConnectList.ExpandAll();
                    tvConnectList.SelectedNode = node1;
                    //lblMessageHit.Text = keys;
                }
            }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }

        private static void networkException(int hDevs, OutputInfoStruct outputInfo) 
        {
            try
            {
                Discrete.DisconnectDev(hDevs);//掉线了进行销毁
                int type = outputInfo.connect_type;
                string message = "";
                switch (type)
                {
                    case 0: //串口
                        message = rm.GetString("strMessageSerialportConnectException");
                        connectException(hDevs, outputInfo, 0);
                        break;
                    case 1:  //TCP Client
                        message = rm.GetString("strMessageTCPClientConnectException");
                        connectException(hDevs, outputInfo, 1);
                        break;
                    case 2:  //监听端口TCP Server
                        message = rm.GetString("strMessageTCPServerConnectException");
                        connectException(hDevs, outputInfo, 2);
                        break;
                }
                message += " " + outputInfo.host;
                mainWindow.lblMessageHit.Text = message;
            }
            catch (Exception e)
            {
                mainWindow.lblMessageHit.Text = e.Message;
            }
        }

        private static void connectException(int hDevs, OutputInfoStruct outputInfo,int type) {
            string value = outputInfo.host;
            string key = value + "_(" + hDevs + ")";// "_已连接";
            string findKey = "";
            foreach (string item in mainWindow.hashMap.Keys)
            {
                int index = item.LastIndexOf(')');
                if(index > 0){
                    string temp = item.Substring(0, index + 1);
                    if (temp == key)
                    {
                        findKey = item;
                        break;
                    }
                }
            }
            if (findKey.Length < 1)
            {
                return;
            }
            mainWindow.hashMap.Remove(findKey);
            TreeNode node = null;
            lock (mainWindow.tvConnectList)
            {
                foreach (TreeNode item in mainWindow.tvConnectList.Nodes[0].Nodes[type].Nodes)
                {
                    if (item.Text == findKey)
                    {
                        node = item;
                        mainWindow.tvConnectList.Nodes[0].Nodes[type].Nodes.Remove(node);
                        break;
                    }
                }
            }
            if (mainWindow.hashMap.Count == 0 && type != 2)
            {
                mainWindow.btnTCPClientConnect.Enabled = true;
                mainWindow.btnSerialPortConnect.Enabled = true;
                mainWindow.btnStartMonitor.Enabled = true;
                mainWindow.btnStopMonitor.Enabled = true;
            }
        }

        public static void DataCallBack(int hDevs, ref OutputInfoStruct outputInfo)
        {
            if (outputInfo.connect_exception > 0)//Network Excpetion
            {
                networkException(hDevs, outputInfo);
            }
            else
            {
                updateTagData(hDevs, outputInfo);
            }
        }

        #region Main

        public static MainWindow mainWindow;

        static string IniFilePath = Application.StartupPath + "\\Config.ini";
        static int index = 0;

        /// <summary>
        /// 加载序列号(仅生产人员使用,对外不公开)
        /// </summary>
        private static void loadSerialNumber() {
            try
            {
                StringBuilder sb = new StringBuilder();
                string curretnTime = DateTime.Now.ToString("yyyyMMdd");
            
                string date = index.ToString().PadLeft(4, '0');
                sb.Append(curretnTime);
                sb.Append(date);

                string outString = "";
                FileOperation.GetValue("Config", "snTime", out outString, IniFilePath);

                string value = null;
                if (outString == curretnTime)
                {
                    FileOperation.GetValue("Config", "snIndex", out outString, IniFilePath);
                    if (!Regex.IsMatch(outString, @"^-?[1-9]\d*$|^0$"))
                    {
                        outString = index.ToString();
                    }
                    index = int.Parse(outString);
                    value = curretnTime;
                    value += index.ToString().PadLeft(4, '0');
                }
                else
                {
                    value = sb.ToString();
                    FileOperation.WritePrivateProfileString("Config", "snTime", curretnTime, IniFilePath);
                    FileOperation.WritePrivateProfileString("Config", "snIndex", index.ToString(), IniFilePath);
                }
                mainWindow.tbSerialNumber.TextChanged -= new System.EventHandler(mainWindow.tbSerialNumber_TextChanged);
                mainWindow.tbSerialNumber.Text = value;
                mainWindow.tbSerialNumber.TextChanged += new System.EventHandler(mainWindow.tbSerialNumber_TextChanged);
            }
            catch (Exception e)
            {
                mainWindow.lblMessageHit.Text = e.Message;
            }
        }

        /******************************************************  Main  Start ********************************************************************************************/
        public MainWindow()
        {
            try
            {
                InitializeComponent();

                //SetStyle(
                //  ControlStyles.AllPaintingInWmPaint |  //全部在窗口绘制消息中绘图
                //  ControlStyles.OptimizedDoubleBuffer, true); //使用双缓冲
                //this.SetStyle(ControlStyles.EnableNotifyMessage, true);
                //UpdateStyles();
                //DoubleBuffered = true;

                // 允许跨线程更新窗口控件
                Control.CheckForIllegalCrossThreadCalls = false;
                InitalContrl();
                UpdateControl = new UpdateControlEventHandler(UpdateListView);  //订阅UpdateControl事件
                UpdateConnect = new UpdateConnectEventHandler(UpdateTreeListView);
                mainWindow = this;
                loadSerialNumber();

                tvConnectList.HideSelection = false;
                tvConnectList.DrawMode = TreeViewDrawMode.OwnerDrawText;
                tvConnectList.DrawNode += new DrawTreeNodeEventHandler(tvConnectList_DrawNode);
            }
            catch (Exception e)
            {
                lblMessageHit.Text = "MainWindow " + e.Message;
            }
        }

        protected override void OnNotifyMessage(Message m)
        {
            //Filter out the WM_ERASEBKGND message
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }
        /******************************************************  Main  End ********************************************************************************************/


        /// <summary>
        /// 绘制颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvConnectList_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = true; //我这里用默认颜色即可，只需要在TreeView失去焦点时选中节点仍然突显
            return;

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            tvConnectList.ExpandAll();
            tvConnectList.HideSelection = false;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.D0)
            {
            }
            else if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.D1)
            {
            }
        }

        #endregion Main

        /// <summary>
        /// 关闭
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(rm.GetString("MainWindowFormClosing"), rm.GetString("ClosePrompt"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        #region 初始化值
        /*********************************** 以下是初始化值和不常变动的 2021-03-06 Start **************************************************************/

        static int hServerSocket = 0;

        private void btnStartMonitor_Click(object sender, EventArgs e)
        {
            if (tbTCPServerPort.Text == "")
            {
                MessageBox.Show(rm.GetString("strMsgSelectRates"));
                return;
            }
            int port = Convert.ToInt32(tbTCPServerPort.Text);
            int result = Discrete.StartListening(ref hServerSocket, socket_callback, (short)port);
            if (result > 0)
            {
                lblMessageHit.Text = rm.GetString("strMessageStartMonitorSuccessed");
                btnStartMonitor.Enabled = false;
                btnSerialPortConnect.Enabled = false;
                btnTCPClientConnect.Enabled = false;
            }
            else
            {
                lblMessageHit.Text = rm.GetString("strMessageStartMonitorFailure");
            }
        }

        private void btnStopMonitor_Click(object sender, EventArgs e)
        {
            if (hServerSocket < 1)
            {
                lblMessageHit.Text = rm.GetString("strMessagePleaseStartMonitor");
                return;
            }
            int index = 2;
            int result = Discrete.StopListening(hServerSocket);
            if (result < 1)
            {
                lblMessageHit.Text = rm.GetString("strMessageStopMonitorFailure");
                return;
            }
            lblMessageHit.Text = rm.GetString("strMessageStopMonitorSuccessed");
            btnStartMonitor.Enabled = true;
            btnSerialPortConnect.Enabled = true;
            btnTCPClientConnect.Enabled = true;
            lock (hashMap)
            {
                for (int i = 0; i < hashMap.Count; i++)
                {
                    TreeNode node = null;
                    string key = hashMap.ElementAt(i).Key;
                    Console.WriteLine(key);
                    lock (tvConnectList.Nodes[0].Nodes[2])
                    {
                        foreach (TreeNode item in tvConnectList.Nodes[0].Nodes[index].Nodes)
                        {
                            if (item.Text == key)
                            {
                                node = item;
                                tvConnectList.Nodes[0].Nodes[index].Nodes.Remove(node);
                                break;
                            }
                        }
                    }
                    Discrete.DisconnectDev(hashMap[key]);
                }  
            }
            hashMap.Clear();
            //Console.WriteLine("断开监听*****************************************************************");
        }

      
        /*********************************** 以下是初始化值和不常变动的 2021-03-06 End **************************************************************/
        #endregion 初始化值

        public static void SaveTxt()
        {
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "txt";
            saveDialog.Filter = "文本文件(*.txt)|*.txt";
            saveDialog.FileName = DateTime.Now.ToString("yyyyMMddHHmmss");
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消

            foreach (EPC_data epc in Tag_data)
            {
               ExcelDataParse.WriteFileSeparator(epc.epc.Replace(" ", "") + ",", saveFileName);
            }
        }
        /*********************************** 连接方式 2021-03-06 Start **************************************************************/
 
        /*********************************** 连接方式 2021-03-06 End **************************************************************/

        /// <summary>
        /// 通信连接
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {

            //else // SerialCommPort
            //{
            //    if (comboBoxSerialCommPort.SelectedIndex >= 0)
            //    {
            //        CommPort = int.Parse(comboBoxSerialCommPort.Text.Trim("COM".ToCharArray()));
            //        //PortOrBaudRate = 9600;
            //        if (cmb_rates.Text == "")
            //        {
            //            MessageBox.Show(rm.GetString("strMsgSelectRates"));
            //        }
            //        else
            //        {
            //            //PortOrBaudRate = Convert.ToInt32(cmb_rates.Text);
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show(rm.GetString("strMsgSelectPort"));
            //        return;
            //    }
            //}
            //if (!Regex.IsMatch(tbDeviceNo.Text, "^[0-9]+$"))
            //{
            //    MessageBox.Show(rm.GetString("strMsgNotDigit"));
            //    return;
            //}
        }

        private void UpdateListEPC(object state)
        {
            UpdateEPC updateEPC = state as UpdateEPC;
        }

        public static void WriteFile(string strTxt, string path)
        {
            using (StreamWriter wlog = File.AppendText(path))
            {
                wlog.Write("{0}", strTxt);
                wlog.Write(wlog.NewLine);
            }
        }

        private void txtTemperature2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符
                }
            }
        }

        /// <summary>
        /// 闭合时间
        /// 2016-01-08
        /// hz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbRelayTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
            if ((e.KeyChar == 0x2D) && (((ComboBox)sender).Text.Length == 0)) return;   //处理负数
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((ComboBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符
                }
            }
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            lock (Tag_data)
            {
                SaveTxt();
            }
        }

        private void tabControl_Click(object sender, EventArgs e)
        {
                /* if (tabControl.SelectedTab.Name != "TagAccess" || tabControl.SelectedTab.Name != "SetCommParam" || tabControl.SelectedTab.Name != "SetReaderParam" || tabControl.SelectedTab.Name != "OtherOpreation")
                 {
                     tabControl.SelectedIndex = 0;
                     DialogResult dr = MessageBox.Show(rm.GetString("strReadStopTips"), rm.GetString("Tips"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                     if (dr == DialogResult.OK)
                     {
                         tabControl.SelectTab(General);
                     }
                 }*/
                tabControl.SelectedIndex = 0;
                DialogResult dr = MessageBox.Show(rm.GetString("strReadStopTips"), rm.GetString("Tips"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        DataTable tabInfo = null;

        private void button6_Click(object sender, EventArgs e)
        {
            byte[] byteArray = new byte[256];
            TagTID.Text = "";
            byte data_len = 0;
            if (1 == Discrete.ReadTagData(deviceNo, (byte)2, (byte)0, 6, byteArray,out data_len))
            {
                for (int i = 3; i < 2 * 6 + 3; i++) // 前面３个字节为输入的参数
                {
                    TagTID.Text += string.Format("{0:X2} ", byteArray[i]);
                }
                if (tabInfo == null)
                {
                    tabInfo = ExcelDataParse.GetTagInfo();
                }
                bool noValue = true;
                for (int row = 0; row < tabInfo.Rows.Count; row++)
                {
                    if (tabInfo.Rows[row][0].ToString() == TagTID.Text.Replace(" ","").Substring(0, 8))
                    {
                        noValue = false;
                        label6.Text = tabInfo.Rows[row][1].ToString();
                        label15.Text = tabInfo.Rows[row][2].ToString();
                        label10.Text = tabInfo.Rows[row][3].ToString().Replace(" ", "");
                    }
                }
                if (noValue)
                {
                    label6.Text = "/";
                    label15.Text = "/";
                    label10.Text = "/";
                }
            }
        }

        #region 基本操作
        /********************************************基本操作 2021-03-09 Start**************************************************************/
        private void btnUpdateSerialPort_Click(object sender, EventArgs e)
        {
            // 获得串口列表
            GetSerialPortList(ref cbbSerialPort);
            cbbSerialPort.SelectedIndex = 0;
        }

        private void btnReadOnce_Click(object sender, EventArgs e){
            singleReadTag();
        }

        private void btnUpdateTCPClient_Click(object sender, EventArgs e)
        {
            try
            {
                cbbTCPClientIP.Items.Clear();
                cbbTCPClientIP.Text = "";
                cbbTCPClientIP.SelectedIndex = -1;
                int result = 0;
                result = JTDM.StartSearchDev(out JTDM.m_DevCnt);
                if (result > 0)
                {
                    for (int i = 0; i < JTDM.m_DevCnt; i++)
                    {
                        byte mode = 0;
                        result = JTDM.QueryNetworkMode((byte)i, out mode);
                        if (result > 0 && mode == 0)
                        {
                            byte[] IP = new byte[50];
                            result = JTDM.QueryIP((byte)i, IP);
                            if (result > 0)
                            {
                                string IP_address = System.Text.Encoding.ASCII.GetString(IP);
                                cbbTCPClientIP.Items.Add(IP_address);
                            }
                        }
                    }
                    if (cbbTCPClientIP.Items.Count > 0)
                    {
                        cbbTCPClientIP.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception e2)
            {
                lblMessageHit.Text = e2.Message;
            }
        }

        private void btnTCPClientConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if ((!Regex.IsMatch(cbbTCPClientIP.Text, "^[0-9.]+$")) || cbbTCPClientIP.Text.Length < 7 || cbbTCPClientIP.Text.Length > 15)
                {
                    lblMessageHit.Text = rm.GetString("strMsgInvalidIPAdd");
                    return;
                }
                if (!Regex.IsMatch(tbTCPClientPort.Text, "^[0-9]+$") || tbTCPClientPort.Text.Length > 5)
                {
                    lblMessageHit.Text = rm.GetString("strMsgInvalidPort");
                    return;
                }
                string IP = cbbTCPClientIP.Text;
                int port = Convert.ToInt32(tbTCPClientPort.Text);
                foreach (string keys in hashMap.Keys)
                {
                    int index = keys.IndexOf('_');
                    if (index != -1)
                    {
                        string temp = keys.Substring(0, index);
                        if (IP == temp)
                        {
                            lblMessageHit.Text = rm.GetString("strMessageRepeatedConnection");
                            return;
                        }
                    }
                }
                int device = 0;
                int result = Discrete.ConnectDev(ref device, data_callback, IP, port);
                if (result < 1)
                {
                    lblMessageHit.Text = rm.GetString("strMsgConnectFailure");
                    return;
                }
                lblMessageHit.Text = rm.GetString("strMsgConnectSuccessed");
                //string key = IP + "_(" + device + ")";// "_已连接";
                string key = getDeviceKey(IP, device);
                hashMap.Add(key, device);
                TreeNode node1 = new TreeNode(key);
                tvConnectList.Nodes[0].Nodes[1].Nodes.Add(node1);
                tvConnectList.ExpandAll();
                tvConnectList.SelectedNode = node1;
                btnStartMonitor.Enabled = false;
                btnStopMonitor.Enabled = false;
            }
            catch (Exception e2)
            {
                lblMessageHit.Text = e2.Message;
            }
        }

        private void btnTCPClientDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];
                int result = Discrete.DisconnectDev(device);
                if (result < 1)
                {
                    lblMessageHit.Text = rm.GetString("strMsgDisconnectConnectFailure");
                    return;
                }
                hashMap.Remove(key);
                lblMessageHit.Text = rm.GetString("strMsgDisconnectConnectSuccessed");
                TreeNode node = tvConnectList.SelectedNode;
                tvConnectList.Nodes[0].Nodes[1].Nodes.Remove(node);
                if (hashMap.Count == 0)
                {
                    btnStartMonitor.Enabled = true;
                    btnStopMonitor.Enabled = true;
                }
            //Console.WriteLine(key + " : " + "断开*******************************************************************************");
            }
            catch (Exception e2)
            {
                lblMessageHit.Text = e2.Message;
            }
        }

        private void btnUpdateTCPServer_Click(object sender, EventArgs e)
        {
            try
            {
                cbbTCPServerIP.Items.Clear();
                cbbTCPServerIP.Text = "";

                byte[] IP = new byte[50];
                byte count = 0;
                int result = JTDM.QueryLocalHosts(IP, out count);
                string[] host = (System.Text.Encoding.ASCII.GetString(IP)).Replace("\0", "").Split(',');
                for (int i = 0; i < count; i++)
                {
                    cbbTCPServerIP.Items.Add(host[i]);
                }
                if (count > 0)
                {
                    cbbTCPServerIP.SelectedIndex = 0;
                }
            }
            catch (Exception e2)
            {
                lblMessageHit.Text = e2.Message;
            }
        }

        private void btnSerialPortConnect_Click(object sender, EventArgs e){
            try
            {
                if (cbbSerialPort.SelectedIndex == -1)
                {
                    return;
                }
                if (!Regex.IsMatch(cbbBaudRate.Text, "^[0-9]+$"))
                {
                    lblMessageHit.Text = rm.GetString("strMsgSelectBaudRate");
                    return;
                }
                String serialport = cbbSerialPort.Text;
                foreach (string keys in hashMap.Keys)
                {
                    int index = keys.IndexOf('_');
                    if (index != -1)
                    {
                        string temp = keys.Substring(0, index);
                        if (serialport == temp)
                        {
                            lblMessageHit.Text = rm.GetString("strMessageRepeatedConnection");
                            return;
                        }
                    }
                }
                int baudRate = Convert.ToInt32(cbbBaudRate.Text);
                int device = 0;
                int result = Discrete.ConnectDev(ref device, data_callback, serialport, baudRate);
                if (result < 1)
                {
                    lblMessageHit.Text = rm.GetString("strMsgConnectFailure");
                    return;
                }
                lblMessageHit.Text = rm.GetString("strMsgConnectSuccessed");
                //string key = serialport + "_(" + device + ")";// "_已连接";
                string key = getDeviceKey(serialport, device);
                hashMap.Add(key, device);
                TreeNode node1 = new TreeNode(key);
                tvConnectList.Nodes[0].Nodes[0].Nodes.Add(node1);
                tvConnectList.ExpandAll();
                tvConnectList.SelectedNode = node1;
                if (hashMap.Count > 0)
                {
                    btnStartMonitor.Enabled = false;
                    btnStopMonitor.Enabled = false;
                }
            }
            catch (Exception e2)
            {
                lblMessageHit.Text = e2.Message;
            }
        }

        private static void updateTagData(int hDevs, OutputInfoStruct outputInfo)
        {
            try
            {
                bool bNewTag = true;
                lock (Tag_data)
                {
                    epc = "";
                    byte[] data = new byte[32];
                    for (int i = 0; i < outputInfo.data_len; ++i)
                    {
                        epc += string.Format("{0:X2} ", outputInfo.id_data[i]);
                    }
                    //Console.WriteLine(outputInfo.host + ": " + epc);
                    for (int i = 0; i < Tag_data.Count; ++i)
                    {
                        if (epc == Tag_data[i].epc)
                        {
                            Tag_data[i].count++;
                            Tag_data[i].epc = epc;

                            string antNo = outputInfo.antNo;
                            byte value = 0;
                            if (null == antNo || "" == antNo)
                            {
                                value = 1;
                            }
                            else
                            {
                                value = byte.Parse(outputInfo.antNo);
                            }
                            Tag_data[i].antNo = value;
                            Tag_data[i].devNo = byte.Parse(outputInfo.device_id);
                            Tag_data[i].host = outputInfo.host;
                            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                            Tag_data[i].readTagTime = time;
                            bNewTag = false;     // 不是新标签
                            nItemNo = i;         //记录数据索引值，用于更新listView表
                            break;
                        }
                    }
                    if (bNewTag)
                    {
                        EPC_data epcdata = new EPC_data();
                        epcdata.epc = epc;
                        string antNo = outputInfo.antNo;
                        byte value = 0;
                        if (null == antNo || "" == antNo)
                        {
                            value = 1;
                        }
                        else
                        {
                            value = byte.Parse(outputInfo.antNo);
                        }
                        epcdata.antNo = value;// data[length - 1];
                        epcdata.devNo = byte.Parse(outputInfo.device_id); //data[length - 2];
                        epcdata.host = outputInfo.host;// System.Text.Encoding.ASCII.GetString(outputInfo.host);
                        string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        epcdata.readTagTime = time;
                        epcdata.count = 1;
                        Tag_data.Add(epcdata);
                    }
                }
                UpdateControl(); // 有新数据产生，更新listView
            }
            catch (Exception)
            {
                //mainWindow.lblMessageHit.Text = e.Message;
            }
        }

        public string selecteDevice()
        {
            lblMessageHit.Text = "";
            TreeNode node = tvConnectList.SelectedNode;
            if (node == null || node.Text == ConnectType.online || node.Parent.Text == ConnectType.online)
            {
                lblMessageHit.Text = rm.GetString("MsgChoosebtnConnect");
                return null;
            }
            string ipText = node.Text;
            foreach (var item in hashMap)
            {
                if (item.Key == ipText)
                {
                    return ipText;
                }
            }
            return null;
        }
        
        private void btnSerialPortDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];
                int result = Discrete.DisconnectDev(device);
                if (result < 1)
                {
                    lblMessageHit.Text = rm.GetString("strMsgDisconnectConnectFailure");
                    return;
                }
                hashMap.Remove(key);
                lblMessageHit.Text = rm.GetString("strMsgDisconnectConnectSuccess");
                TreeNode node = tvConnectList.SelectedNode;
                tvConnectList.Nodes[0].Nodes[0].Nodes.Remove(node);
                if (hashMap.Count == 0)
                {
                    btnStartMonitor.Enabled = true;
                    btnStopMonitor.Enabled = true;
                }
            }
            catch (Exception e2)
            {
                lblMessageHit.Text = e2.Message;
            }
        }
        
        private void tvConnectList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                //MessageBox.Show(e.Node.Text);
                int index = 0;
                string value = e.Node.Text;
                string key = value.Substring(0,1);
                if (key != "S" && key != "T" && key != "O")
                {
                   value = e.Node.Parent.Text;
                   //MessageBox.Show(value);
                }
                switch (value)
                {
                    case ConnectType.serialport:
                        index = 0;
                        break;
                    case ConnectType.TCPClient:
                        index = 1;
                        break;
                    case ConnectType.TCPServer:
                        index = 2;
                        break;
                    default:
                        index = 3;
                        break;
                }
                if (index < 3)
                {
                    tbConnect.SelectedIndexChanged -= new System.EventHandler(this.tbConnect_SelectedIndexChanged);
                    tbConnect.SelectedIndex = index;
                    tbConnect.SelectedIndexChanged += new System.EventHandler(this.tbConnect_SelectedIndexChanged);
                }
            }
            catch (Exception e2)
            {
                lblMessageHit.Text = e2.Message;
            }
        }

        private void tbConnect_SelectedIndexChanged(object sender, EventArgs e)
        {
            tvConnectList.SelectedNode = null;
        }

        private void btnBrushVersion_Click(object sender, EventArgs e)
        {
            lblVersion.Text = "";
            lblMessageHit.Text = "";
        }

        private void btnReadVersion_Click(object sender, EventArgs e)
        {
            queryVersion();
        }

        private void queryVersion()
        {
            try
            {
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];
                byte[] version = new byte[100];
                int result = Discrete.QueryVersion(device, version);
                string showInfo = "";
                lblVersion.Text = "";
                lblMessageHit.Text = "";
                if (result > 0)
                {
                    string ver = System.Text.Encoding.ASCII.GetString(version);
                    lblVersion.Text = ver;
                    showInfo = rm.GetString("strMsgQueryVersionSuccessed");
                }
                else
                {
                    showInfo = rm.GetString("strMsgQueryVersionFailure");
                }
                lblMessageHit.Text = showInfo;
            }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }

        #region 数据添加到Table
        static void InsertTag(byte[] data, int length, byte antNo, byte device_no, byte[] IP_or_com)
        {
            try
            {
                string epc = "";
                for (int i = 0; i < length; ++i)
                {
                    epc += string.Format("{0:X2} ", data[i]);
                }
                bool bNewTag = true;
                string host = System.Text.Encoding.ASCII.GetString(IP_or_com);
                lock (Tag_data)
                {
                    for (int i = 0; i < Tag_data.Count; ++i)
                    {
                        if (epc == Tag_data[i].epc)
                        {
                            Tag_data[i].count++;
                            Tag_data[i].antNo = antNo;
                            Tag_data[i].devNo = device_no;
                            Tag_data[i].host = host;
                            bNewTag = false;     // 不是新标签
                            nItemNo = i;             //记录数据索引值，用于更新listView表
                            break;
                        }
                    }
                    if (bNewTag)
                    {
                        EPC_data epcdata = new EPC_data();
                        epcdata.epc = epc;
                        epcdata.antNo = antNo;
                        epcdata.devNo = device_no;
                        epcdata.host = host;
                        epcdata.count = 1;
                        Tag_data.Add(epcdata);
                    }
                    UpdateControl(); // 有新数据产生，更新listView
                }
            }
            catch (Exception e2)
            {
                mainWindow.lblMessageHit.Text = e2.Message;
            }
        }

        private void UpdateListView()
        {
            listView.BeginUpdate();//防listview闪烁开始
            if (rbAsc.Checked)
            {
                lock (Tag_data)
                {
                    Tag_data.Sort();
                }
            }
            else if (rbDesc.Checked)
            {
                lock (Tag_data)
                {
                    Tag_data.Sort();
                    Tag_data.Reverse();
                }
            }
            try
            {
                bool isNewData = true;
                lblCount.Text = (int.Parse(lblCount.Text) + 1).ToString();
                lock (Tag_data)
                {
                    lock (listView.Items)
                    {
                        lock (lblTagCount)
                        {
                            
                            foreach (EPC_data epc in Tag_data)
                            {
                                isNewData = true;
                                for (int index = 0; index < listView.Items.Count; index++)
                                {
                                    if (listView.Items[index].SubItems[1].Text == epc.epc)
                                    {
                                        listView.Items[index].SubItems[2].Text = epc.count.ToString();
                                        listView.Items[index].SubItems[3].Text = epc.antNo.ToString();
                                        listView.Items[index].SubItems[4].Text = epc.devNo.ToString();
                                        listView.Items[index].SubItems[5].Text = epc.host;
                                        listView.Items[index].SubItems[6].Text = epc.readTagTime;
                                        isNewData = false;
                                        break;
                                    }
                                }
                                if (isNewData)
                                {
                                    // 更新读取次数
                                    //Console.WriteLine("次数: " + lblTagCount + " EPC : " + epc.epc);
                                    int count = int.Parse(lblTagCount.Text) + 1;
                                    lblTagCount.Text = "" + count;// string.Format("{0:D} ", count);// 更新标签计数
                                    ListViewItem lvi = new ListViewItem();
                                    int no = Tag_data.Count;
                                    lvi.Text = no.ToString();
                                    lvi.SubItems.Add(epc.epc);
                                    lvi.SubItems.Add(epc.count.ToString());
                                    lvi.SubItems.Add(epc.antNo.ToString());
                                    lvi.SubItems.Add(epc.devNo.ToString());
                                    lvi.SubItems.Add(epc.host);
                                    lvi.SubItems.Add(epc.readTagTime);
                                    listView.Items.Add(lvi);
                                    if (cbSaveFile.Checked)
                                    {
                                        //WriteFile(epc.epc, "tag.txt");
                                        export(Tag_data);
                                    }
                                    isNewData = false;
                                    break;
                                }
                            }
                        }
                    }
                }
                listView.EndUpdate();//防listview闪烁结束
            }
            catch (Exception)
            {
                //MessageBox.Show("由于操作不当导致软件关闭，请重新打开！", "提示");
            }
        }

        private void export(List<EPC_data> list)
        {
            //string path = AppDomain.CurrentDomain.BaseDirectory + "url_" + Guid.NewGuid().ToString() + ".xls";
            string dateTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_fff");
            string path = AppDomain.CurrentDomain.BaseDirectory + dateTime + ".xls";
            StringBuilder sb = new StringBuilder();
            int index = 0;
            foreach (EPC_data data in list)
            {
                if (index == 0)
                {
                    sb.Append("No.\t");
                    sb.Append("EPC/TID\t");
                    sb.Append("Count\t");
                    sb.Append("Antenna\t");
                    sb.Append("DeviceNo\t");
                    sb.Append("Uart/IP\t");
                    sb.AppendLine("DateTime\t");;
                }
                index++;
                sb.Append(index);
                sb.Append("\t");
                sb.Append(data.epc);
                sb.Append("\t");
                sb.Append(data.count);
                sb.Append("\t");
                sb.Append(data.antNo);
                sb.Append("\t");
                sb.Append(data.devNo);
                sb.Append("\t");
                sb.Append(data.host);
                sb.Append("\t");
                sb.Append(" " + data.readTagTime);
                sb.AppendLine("\t");
            }
            System.IO.File.WriteAllText(path, sb.ToString(), Encoding.ASCII);
            lblMessageHit.BeginInvoke(new Action(() =>
            {
                string temp = path;
                //string temp = "File Name: " + path;
                lblMessageHit.Text = temp;
           }));
        }

        private void UpdateLV()
        {
            try
            {
                lock (listView.Items)
                {
                    listView.BeginUpdate();
                    listView.Items.Clear();
                    for (int i = 1; i <= Tag_data.Count; ++i)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = i.ToString();
                        lvi.SubItems.Add(Tag_data[i - 1].epc);
                        lvi.SubItems.Add(Tag_data[i - 1].count.ToString());
                        lvi.SubItems.Add(Tag_data[i - 1].antNo.ToString());
                        lvi.SubItems.Add(Tag_data[i - 1].devNo.ToString());
                        lvi.SubItems.Add(Tag_data[i - 1].host);
                        lvi.SubItems.Add(Tag_data[i - 1].readTagTime);
                        listView.Items.Add(lvi);
                    }
                    listView.EndUpdate();//防listview闪烁结束
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void beginInv()
        {
            try
            {
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];

                int result = Discrete.BeginInv(device);
                if (result > 0)
                {
                    lblMessageHit.Text = rm.GetString("strMessageContinueReadTagSuccessed");
                    return;
                }
                else
                {
                    lblMessageHit.Text = rm.GetString("strMessageContinueReadTagFailure");
                }
            }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }

        /// <summary>
        /// 开始连续寻卡
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            beginInv();
        }

        private void stopInv()
        {
            try
            {
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];

                int result = Discrete.StopInv(device);
                if (result < 0)
                {
                    lblMessageHit.Text = rm.GetString("strMessageStopContinueReadTagFailure");
                    return;
                }
                else
                {
                    lblMessageHit.Text = rm.GetString("strMessageStopContinueReadTagSuccessed");
                }
            }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }

        /// <summary>
        /// 停止连续寻卡
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            stopInv();
        }

        /// <summary>
        /// 清空
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            lock (listView)
            {
                lblTagCount.Text = "0";
                lblCount.Text = "0";
                lock (Tag_data)
                {
                    Tag_data.Clear();
                }
                lock (listView)
                {
                    listView.Items.Clear();
                }
            }
        }

        /// <summary>
        /// 升序
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbAsc_CheckedChanged(object sender, EventArgs e)
        {
            lock (Tag_data)
            {
                Tag_data.Sort();
                UpdateLV();
            }
        }

        /// <summary>
        /// 降序
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbDesc_CheckedChanged(object sender, EventArgs e)
        {
            lock (Tag_data)
            {
                Tag_data.Sort();
                Tag_data.Reverse();
                UpdateLV();
            }
        }


        #endregion 数据添加到Table

        #region 更新串口列表
        public void GetSerialPortList(ref ComboBox comboBoxSP)
        {
            comboBoxSP.Items.Clear();
            string [] uart = SerialPort.GetPortNames();
            for (int i = uart.Length - 1 ; i >= 0 ; i--)
            {
                comboBoxSP.Items.Add(uart[i]);
            }
            //comboBoxSP.Items.AddRange();
            if (comboBoxSP.Items.Count > 0)
            {
                comboBoxSP.SelectedIndex = 0;
            }
        }
        #endregion 更新串口列表

        /********************************************基本操作 2021-03-09 End**************************************************************/
        #endregion 基本操作

        #region 标签操作
        /********************************************标签操作 2021-03-09 Start**************************************************************/
        private void btnClearData_Click(object sender, EventArgs e)
        {
            tbRWData.Text = "";
            counts = 1;
            tbRWData.Focus();
        }
        
        private void cbbStartAdd_SelectedIndexChanged(object sender, EventArgs e)
        { // 根据起始地址，确定长度选项
            int nItem = cbbStartAdd.SelectedIndex; // 取出起始地址索引值
            int maxLength = addEnd - addStart - nItem + 1;
            cbbLength.Items.Clear();
            for (int i = 1; i <= maxLength; ++i)
            {
                cbbLength.Items.Add(i.ToString());
            }
            cbbLength.SelectedIndex = maxLength - 1;
        }
        
        private void cbbRWBank_SelectedIndexChanged(object sender, EventArgs e)
        {   // 根据操作区域，确定有效的起始地址
            if (cbbRWBank.SelectedIndex == 0) // 保留区
            {
                addStart = 0;
                addEnd = 3;
            }
            else if (cbbRWBank.SelectedIndex == 1) // EPC区
            {
                addStart = 2;
                addEnd = 7;
            }
            else if (cbbRWBank.SelectedIndex == 2) // TID
            {
                addStart = 0;
                addEnd = 5;
            }
            else if (cbbRWBank.SelectedIndex == 3) // User
            {
                addStart = 0;
                addEnd = 31;
                //addEnd = 128;
            }
            cbbStartAdd.Items.Clear();
            for (int i = addStart; i <= addEnd; ++i)
            {
                cbbStartAdd.Items.Add(i.ToString());
            }
            cbbStartAdd.SelectedIndex = 0;
        }

        private void singleReadTag()
        {
            string key = selecteDevice();
            if (null == key)
            {
                return;
            }
            int device = hashMap[key];
            byte[] outData = new byte[50];
            byte data_len = 0;
            byte device_no = 0;
            byte antenna_no = 0;
            byte[] IP_or_comm = new byte[50];
            int result = Discrete.ReadSingleTag(device, outData, out data_len, out device_no, out antenna_no, IP_or_comm);
            if (result < 1)
            {
                lblMessageHit.Text = rm.GetString("strMessageReadOnceFailure");
                return;
            }
            else
            {
                lblMessageHit.Text = rm.GetString("strMessageReadOnceSuccessed");
            }
            InsertTag(outData, data_len, antenna_no, device_no, IP_or_comm);
        }

        private void btnReadFastTag_Click(object sender, EventArgs e)
        {
            readFastTag();
        }

        private void btnFastWrite_Click(object sender, EventArgs e)
        {
            fastWriteTag();
        }
        private void btnClearFWData_Click(object sender, EventArgs e)
        {
            tbFWData.Text = "";
            tbFWData.Focus();
        }

        private void btnReadData_Click(object sender, EventArgs e)
        {
            tagReadData();
        }

        private void btnWriteData_Click(object sender, EventArgs e)
        {
            tagWrietData();
        }
 
        private void btn_connRead_Click(object sender, EventArgs e)
        {
            connReadTag();
        }

        private void btn_stoptimer_Click(object sender, EventArgs e)
        {
            timerConnRead.Enabled = false;   //停止连续读取定时器
        }

        private void btnInitTag_Click(object sender, EventArgs e)
        {
            initTag();
        }

        private void btnKillTag_Click(object sender, EventArgs e)
        {
            killTag();
        }

        private void btnLockTag_Click(object sender, EventArgs e)
        {
            lockTag();
        }

        private void btnUnlockTag_Click(object sender, EventArgs e)
        {
            unLockTag();
        }

        BathReadWrite bathReadWrite;

        private void btnAdvancedAccess_Click(object sender, EventArgs e)
        {
            string keys = selecteDevice();
            if (null == keys)
            {
                return;
            }
            int device = hashMap[keys];
            bathReadWrite = new BathReadWrite(device, rm);
            bathReadWrite.Show();
        }

        private void btnWeigandConvert_Click(object sender, EventArgs e)
        {
            string str = wiegandTb.Text.ToString();
            str = str.PadLeft(8, '0');
            if (rbWeigand26_1_2.Checked) 
            {
                tbRWData.Text = PageFun.weigandStrTostr1(str);
            }
            else if (rbWeigand26_3_0.Checked) 
            {
                tbRWData.Text = PageFun.weigandStrTostr2(str);
            }
        }

        private void unLockTag()
        {
            string strpwd = tbLockAccessPwd.Text.Replace(" ", "");
            if (strpwd.Length != 8)
            {
                lblMessageHit.Text = rm.GetString("strMsgPwdMustEight");
                return;
            }
            if (!DataConvert.IsHexCharacter(strpwd))
            {
                lblMessageHit.Text = rm.GetString("strMsgPwdInvalidChar");
                return;
            }
            string key = selecteDevice();
            if (null == key)
            {
                return;
            }
            int device = hashMap[key];
            byte[] pwd = new byte[4];
            for (int i = 0; i < 4; ++i)
            {
                pwd[i] = Convert.ToByte(strpwd.Substring(i * 2, 2), 16); // 把字符串的子串转为16进制的8位无符号整数
            }
            int unlockBank = cbbLockBank.SelectedIndex;
            if (-1 == unlockBank)
            {
                lblMessageHit.Text = rm.GetString("strMsgSelecOprBank");
                return;
            }
            if (1 == Discrete.UnLockTag(device, (byte)unlockBank, pwd))
            {
                lblMessageHit.Text = rm.GetString("strMsgSucceedUnlock");
            }
            else
            {
                lblMessageHit.Text = rm.GetString("strMsgFailedUnlock");
            }
        }

        private void lockTag() 
        {
            int lockBank = -1;
            lblMessageHit.Text = "";

            string strpwd = tbLockAccessPwd.Text.Replace(" ", "");
            if (strpwd.Length != 8)
            {
                lblMessageHit.Text = rm.GetString("strMsgPwdMustEight");
                return;
            }
            if (!DataConvert.IsHexCharacter(strpwd))
            {
                lblMessageHit.Text = rm.GetString("strMsgPwdInvalidChar");
                return;
            }
            if ((lockBank = cbbLockBank.SelectedIndex) == -1)
            {
                lblMessageHit.Text = rm.GetString("strMsgSelecOprBank");
                return;
            }
            string key = selecteDevice();
            if (null == key)
            {
                return;
            }
            int device = hashMap[key];
            byte[] pwd = new byte[4];
            for (int i = 0; i < 4; ++i)
            {
                pwd[i] = Convert.ToByte(strpwd.Substring(i * 2, 2), 16); // 把字符串的子串转为16进制的8位无符号整数
            }
            if (1 == Discrete.LockTag(device, (byte)lockBank, pwd))
            {
                lblMessageHit.Text = rm.GetString("strMsgSucceedLock");
            }
            else
            {
                lblMessageHit.Text = rm.GetString("strMsgFailedLock");
            }
            return;
        }

        private void killTag() 
        {
            string strKillPwd = tbKillKillPwd.Text.Replace(" ", "");
            if (strKillPwd.Length != 8)
            {
                lblMessageHit.Text = rm.GetString("strMsgPwdMustEight");
                return;
            }
            if (!DataConvert.IsHexCharacter(strKillPwd))
            {
                lblMessageHit.Text = rm.GetString("strMsgPwdInvalidChar");
                return;
            }
            string key = selecteDevice();
            if (null == key)
            {
                return;
            }
            int device = hashMap[key];
            byte[] byteAccessPwd = new byte[4];
            byte[] byteKillPwd = new byte[4];
            for (int i = 0; i < 4; ++i)
            {
                byteKillPwd[i] = Convert.ToByte(strKillPwd.Substring(i * 2, 2), 16);
            }
            if (1 == Discrete.KillTag(device, byteKillPwd))
            {
                lblMessageHit.Text = rm.GetString("strMsgSucceedDes");
            }
            else
            {
                lblMessageHit.Text = rm.GetString("strMsgFailedDes");
            }
        }

        private void connReadTag()
        {
            int RWBank = -1;
            int StartAdd = -1;
            int Length = -1;
            if ((RWBank = cbbRWBank.SelectedIndex) == -1)
            {
                lblMessageHit.Text = rm.GetString("strMsgSelectRWBank");
                return;
            }
            if ((StartAdd = cbbStartAdd.SelectedIndex) == -1)
            {
                lblMessageHit.Text = rm.GetString("strMsgSelectStartAdd");
                return;
            }
            StartAdd = int.Parse(cbbStartAdd.Text);
            if ((Length = cbbLength.SelectedIndex) == -1)
            {
                lblMessageHit.Text = rm.GetString("strMsgSelectLength");
                return;
            }
            Length = int.Parse(cbbLength.Text);
            byte[] byteArray = new byte[100];
            string key = selecteDevice();
            if (null == key)
            {
                return;
            }
            int device = hashMap[key];
            byte data_len = 0;
            timerConnRead.Enabled = true;   //开启连续读取定时器
            timerConnRead.Interval = 1500;
            //tbRWData.Text = string.Empty;
            int result = Discrete.ReadTagData(device, (byte)RWBank, (byte)StartAdd, (byte)Length, byteArray, out data_len);
            if (0 == result)
            {
                lblMessageHit.Text = rm.GetString("strMsgFailedReadData");
                return;
            }
            string tags = string.Empty;
            for (int i = 0; i < data_len; i++) // 前面３个字节为输入的参数
            {
                tags += string.Format("{0:X2} ", byteArray[i]);
            }
            if (tbRWData.Text == "")
            {
                tbRWData.Text = counts + "." + " " + tags;
                counts = counts + 1;
                //tbRWData.Text = tags;
            }
            else
            {
                //tbRWData.Text =tbRWData.Text +"\r"+"\n"+ tags;
                tbRWData.Text = tbRWData.Text + "\r" + "\n" + counts + "." + " " + tags;
                counts = counts + 1;
            }
            tbRWData.Focus();
            this.tbRWData.Select(this.tbRWData.TextLength, 0);//光标定位到文本最后
            this.tbRWData.ScrollToCaret();//滚动到光标处
            lblMessageHit.Text = rm.GetString("strMsgSussecReadData");
        }

        private void tagWrietData() 
        {
            int RWBank = -1;
            int StartAdd = -1;
            int Length = -1;
            if ((RWBank = cbbRWBank.SelectedIndex) == -1)
            {
                lblMessageHit.Text = rm.GetString("strMsgSelectRWBank");
                return;
            }
            StartAdd = int.Parse(cbbStartAdd.Text);
            Length = int.Parse(cbbLength.Text);

            string strData = tbRWData.Text.Replace(" ", "");// 去空格
            if (strData.Length % 4 != 0 || strData.Length / 4 != Length)
            {
                lblMessageHit.Text = rm.GetString("strMsgLengthDiff");
                return;
            }
            if (!DataConvert.IsHexCharacter(strData))
            {
                lblMessageHit.Text = rm.GetString("strMsgPwdInvalidChar");
                return;
            }

            byte[] byteArray = new byte[256];
            for (int i = 0; i < 2 * Length; ++i)
            {
                byteArray[i] = Convert.ToByte(strData.Substring(2 * i, 2), 16);
            }
            string key = selecteDevice();
            if (null == key)
            {
                return;
            }
            int device = hashMap[key];
            if (chkDesignatedAntWrite.Checked)
            {
                //if (1 == Dis.WriteEpcByAnt(deviceNo, (byte)RWBank, (byte)StartAdd, (byte)Length, GetAnt(), 01, byteArray))
                //{
                //    lblMessageHit.Text = rm.GetString("strMsgSucceedWrite");
                //}
                //else
                //{
                //    lblMessageHit.Text = rm.GetString("strMsgFailedWrite");
                //}
                return;
            }
            int result = Discrete.WriteTagData(device, (byte)RWBank, (byte)StartAdd, (byte)Length, byteArray);
            if (0 == result)
            {
                lblMessageHit.Text = rm.GetString("strMsgFailedWrite");
                return;
            }
            lblMessageHit.Text = rm.GetString("strMsgSucceedWrite");
        }

        private void tagReadData() 
        {
            try
            {
                int RWBank = -1;
                int StartAdd = -1;
                int Length = -1;
                if ((RWBank = cbbRWBank.SelectedIndex) == -1)
                {
                    lblMessageHit.Text = rm.GetString("strMsgSelectRWBank");
                    return;
                }
                StartAdd = int.Parse(cbbStartAdd.Text);
                Length = int.Parse(cbbLength.Text);
                byte[] byteArray = new byte[100];
                tbRWData.Text = "";
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];
                if (chkDesignatedAntRead.Checked)
                {
                    //if (1 == Dis.ReadEpcByAnt(deviceNo, (byte)RWBank, (byte)StartAdd, Length, GetAnt(), byteArray))
                    //{
                    //    for (int i = 3; i < 2 * Length + 3; i++) // 前面３个字节为输入的参数
                    //    {
                    //        tbRWData.Text += string.Format("{0:X2} ", byteArray[i]);
                    //    }
                    //    lblMessageHit.Text = rm.GetString("strMsgSussecReadData");
                    //}
                    return;
                }
                byte data_len = 0;
                tbRWData.Text = string.Empty;
                int result = Discrete.ReadTagData(device, (byte)RWBank, (byte)StartAdd, (byte)Length, byteArray, out data_len);
                if (0 == result)
                {
                    lblMessageHit.Text = rm.GetString("strMsgFailedReadData");
                    return;
                }
                for (int i = 0; i < data_len; i++) // 前面３个字节为输入的参数
                {
                    tbRWData.Text += string.Format("{0:X2} ", byteArray[i]);
                }
                lblMessageHit.Text = rm.GetString("strMsgSussecReadData");
            }
            catch
            {
                lblMessageHit.Text = rm.GetString("strMsgFailedReadData");
            }
        }

        private void fastWriteTag() 
        {
            try { 
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];
                string strData = tbFWData.Text.Replace(" ", "");
                if (strData.Length == 0)
                {
                    lblMessageHit.Text = rm.GetString("strMsgDataNotEmpty");
                    return;
                }
                if (!Regex.IsMatch(strData, "^[0-9A-Fa-f]+$"))
                {
                    lblMessageHit.Text = rm.GetString("strMsgPwdInvalidChar");
                    return;
                }
                if (strData.Length % 4 != 0)
                {
                    lblMessageHit.Text = rm.GetString("strMsgDataMustFourTimes");
                    return;
                }
                int leng = strData.Length / 2;
                byte[] byteArray = new byte[64];
                for (int i = 0; i < leng; ++i)
                {
                    byteArray[i] = Convert.ToByte(strData.Substring(2 * i, 2), 16);
                }
                string strEpc = strData;
                int result = Discrete.FastWriteTag(device, byteArray, (byte)leng);
                if (1 > result)
                {
                    lblMessageHit.Text = rm.GetString("strMsgFailedWrite");
                    return;
                }
                lblMessageHit.Text = rm.GetString("strMsgSucceedWrite");
                if (chkZD.Checked)//自动增1 2016-04-08 hz
                {
                    strEpc = PageFun.AddStr(strData, 1, 0);
                    for (int i = 0; i < leng - 1; ++i)
                    {
                        // strEpc += string.Format("{0:X2} ", byteArray[i]);
                        strEpc = PageFun.AddStr(strData, 1, 0);
                    }
                }
                for (int i = 0; i < leng; ++i)
                {
                    byteArray[i] = Convert.ToByte(strEpc.Substring(2 * i, 2), 16);
                }
                strEpc = "";
                for (int i = 0; i < leng; ++i)
                {
                    strEpc += string.Format("{0:X2} ", byteArray[i]);
                }
                tbFWData.Text = strEpc;
            }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }

        private void readFastTag() 
        {
            string key = selecteDevice();
            if (null == key)
            {
                return;
            }
            int device = hashMap[key];
            byte bank = 1;
            byte begin = 2;
            byte length = 6;
            byte [] data = new byte[12];
            byte data_len = 0;
            tbFWData.Text = string.Empty;
            int result = Discrete.ReadTagData(device,bank, begin,length,data,out data_len);
            if (0 < result)
            {
                for (int i = 0; i < data_len; i++) // 前面３个字节为输入的参数
                {
                     tbFWData.Text += string.Format("{0:X2} ", data[i]);
                }
                lblMessageHit.Text = rm.GetString("strMsgSussecReadData");
            }
            else
            {
                lblMessageHit.Text = rm.GetString("strMsgFailedReadData");
            }
        }

        private void initTag() 
        {
            string key = selecteDevice();
            if (null == key)
            {
                return;
            }
            int device = hashMap[key];
            int result = Discrete.InitializeTag(device);
            if (0 < result)
            {
                lblMessageHit.Text = rm.GetString("strMsgSucceedInit");
            }
            else
            {
                lblMessageHit.Text = rm.GetString("strMsgFailedInit");
            }
        }
        /********************************************标签操作 2021-03-09 End**************************************************************/
        #endregion 标签操作

        #region 读写器参数设置
        /********************************************读写器参数设置 2021-03-09 Start**************************************************************/
        private void SetReaderParam_Enter(object sender, EventArgs e)
        {
            //btnReadWorkMode_Click(null, null);
            //btnReadCommMode_Click(null, null);
            //btnReadFreq_Click(null, null);
            //btnAntRead_Click(null, null);
            //btnReadWorkMode_Click(null, null);
        }

        private void btnDefaultWorkMode_Click(object sender, EventArgs e)
        {
            tbWorkMode.SelectedIndex = 1;
            tbTiming.Text = "20";
            cbbReadSpeed.SelectedIndex = 1;
            tbDelay.Text = "10";
            cbbTrigSwitch.SelectedIndex = 1;
        }

        private void tbWorkMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbNeighJudge.Visible = chkAjaDisc.Checked;
            switch (tbWorkMode.SelectedIndex)
            {
                case 0: // 主从
                    break;
                case 1:// 定时
                    cbbReadSpeed.SelectedIndex = 1;
                    tbTiming.Text = "20";
                    break;
                case 2: // 触发
                    tbTiming.Text = "5";
                    tbDelay.Text = "10";
                    tbNeighJudge.Text = "5";
                    cbbTrigSwitch.SelectedIndex = 1;
                    break;
            }
        }

        private void btnDefaultCommMode_Click(object sender, EventArgs e)
        {
            tbCommMode.SelectedIndex = 2;
            cbbBaud_Rate.SelectedIndex = 0;
            tbPulseWidth.Text = "10";
            tbPulseCycle.Text = "16";
            cbbWiegandProtocol.SelectedIndex = 0;
            cbbWigginsTakePlaceValue.SelectedIndex = 9;
        }

        private void btnReadWorkMode_Click(object sender, EventArgs e)
        {
            queryWorkMode();
        }

        private void chkAjaDisc_CheckedChanged(object sender, EventArgs e)
        {
            tbNeighJudge.Visible = chkAjaDisc.Checked;
        }

        private void btnSetWorkMode_Click(object sender, EventArgs e)
        {
            updateWorkMode();
        }

        private void btnReadCommMode_Click(object sender, EventArgs e)
        {
            queryCommMode();
        }

        private void btnSetCommMode_Click(object sender, EventArgs e)
        {
            updateCommMode();
        }

        private void updateCommMode() 
        {
            // 通信模式参数变量
            int commMode = 0;
            //通信方式
            if ((commMode = tbCommMode.SelectedIndex) == -1)
            {
                lblMessageHit.Text = rm.GetString("strMsgInvalidCommMode");
                return;
            }
            string key = selecteDevice();
            if (null == key)
            {
                return;
            }
            int device = hashMap[key];
            int result = 0;
            switch (commMode)
            {
                case 0://RS485 | RJ45

                    break;
                case 1: //韦根
                    // 韦根协议
                    int wiegandProto = 0;
                    int pulseWidth = 0;
                    int pulseCycle = 0;
                    int wiegandValue = 0;
                    if ((wiegandProto = cbbWiegandProtocol.SelectedIndex) == -1)
                    {
                        lblMessageHit.Text = rm.GetString("strMsgInvalidWiegandProto");
                        return;
                    }
                    // 韦根脉冲宽度
                    if (!int.TryParse(tbPulseWidth.Text, out pulseWidth))
                    {
                        lblMessageHit.Text = rm.GetString("strMsgInvalidPulseWidth");
                        return;
                    }
                    // 脉冲周期
                    if (!int.TryParse(tbPulseCycle.Text, out pulseCycle))
                    {
                        lblMessageHit.Text = rm.GetString("strMsgInvalidPulseCycle");
                        return;
                    }
                    // 韦根取位值
                    if ((wiegandValue = cbbWigginsTakePlaceValue.SelectedIndex) == -1)
                    {
                        lblMessageHit.Text = rm.GetString("strMsgInvalidWiegandValue");
                        return;
                    }
                    result = Discrete.UpdateWiegandPulseWidth(device, (byte)pulseWidth);
                    if (result == 0)
                    {
                        lblMessageHit.Text = rm.GetString("strMsgFailedReadCommMode");
                        return;
                    }
                    result = Discrete.UpdateWiegandPulseCycle(device, (byte)pulseCycle);
                    if (result == 0)
                    {
                        lblMessageHit.Text = rm.GetString("strMsgFailedReadCommMode");
                        return;
                    }
                    result = Discrete.UpdateWiegandProto(device, (byte)wiegandProto);
                    if (result == 0)
                    {
                        lblMessageHit.Text = rm.GetString("strMsgFailedReadCommMode");
                        return;
                    }
                    result = Discrete.UpdateWiegandValue(device, (byte)wiegandValue);
                    if (result == 0)
                    {
                        lblMessageHit.Text = rm.GetString("strMsgFailedReadCommMode");
                        return;
                    }

                    break;
                case 2://串口RS232
                    int baudRate = 0;
                    if ((baudRate = cbbBaud_Rate.SelectedIndex) == -1)
                    {
                        lblMessageHit.Text = rm.GetString("strSetRate");
                        return;
                    }
                    result = Discrete.UpdateBaudRate(device, (byte)baudRate);
                    if (result == 0)
                    {
                        lblMessageHit.Text = rm.GetString("strMsgFailedReadCommMode");
                        return;
                    }
                    break;
            }
            result = Discrete.UpdateOutputMode(device, (byte)commMode);
            if (0 == result)
            {
                lblMessageHit.Text = rm.GetString("strMsgFailedSetCommMode");
                return;
            }
            lblMessageHit.Text = rm.GetString("strMsgSucceedSetCommMode");
        }

        private void queryCommMode() 
        {
            try
            {
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];
                byte output_mode = 0;
                int result = 0;
                result = Discrete.QueryOutputMode(device, out output_mode);
                if (result == 0)
                {
                    lblMessageHit.Text = rm.GetString("strMsgFailedReadCommMode");
                    return;
                }
                tbCommMode.SelectedIndex = output_mode;
                switch (output_mode)
                {
                    case 0://RS485 | RJ45
                        break;
                    case 1: //韦根
                        byte width = 0;
                        byte cycle = 0;
                        byte proto = 0;
                        byte value = 0;
                        result = Discrete.QueryWiegandPulseWidth(device, out width);
                        if (result == 0)
                        {
                            lblMessageHit.Text = rm.GetString("strMsgFailedReadCommMode");
                            return;
                        }
                        result = Discrete.QueryWiegandPulseCycle(device, out cycle);
                        if (result == 0)
                        {
                            lblMessageHit.Text = rm.GetString("strMsgFailedReadCommMode");
                            return;
                        }
                        result = Discrete.QueryWiegandProto(device, out proto);
                        if (result == 0)
                        {
                            lblMessageHit.Text = rm.GetString("strMsgFailedReadCommMode");
                            return;
                        }
                        result = Discrete.QueryWiegandValue(device, out value);
                        if (result == 0)
                        {
                            lblMessageHit.Text = rm.GetString("strMsgFailedReadCommMode");
                            return;
                        }
                        proto = (byte)(proto > 3 ? -1 : proto);
                        cbbWigginsTakePlaceValue.SelectedIndex = value > 61 ? 61 : value;
                        cbbWiegandProtocol.SelectedIndex = proto;
                        tbPulseCycle.Text = string.Format("{0:d}", cycle);
                        tbPulseWidth.Text = string.Format("{0:d}",width);
                        break;
                    case 2: //串口RS232
                        byte baudRate = 0;
                        result = Discrete.QueryBaudRate(device, out baudRate);
                        if (result == 0)
                        {
                            lblMessageHit.Text = rm.GetString("strMsgFailedReadCommMode");
                            return;
                        }
                        cbbBaud_Rate.SelectedIndex = baudRate;
                        break;
                }
                lblMessageHit.Text = rm.GetString("strMsgSucceedReadCommMode");
            }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }

        private void updateWorkMode() {
            try
            {
                int workMode = 0;
                int timingInterval = 0;
                int delayTime = 0;
                int trigSwitch = 0;
                int adjaDisTime = 0;
                // 工作模式
                if ((workMode = tbWorkMode.SelectedIndex) == -1)
                {
                    lblMessageHit.Text = rm.GetString("strMsgInvalidWordMode");
                    return;
                }
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];
                byte mode = (byte)tbWorkMode.SelectedIndex;
                int result = 0;
                switch (mode)
                {
                    case 0://主从模式

                        break;
                    case 1: //定时模式
                        if (tbWorkMode.SelectedIndex == 1)
                        {
                            // 定时参数
                            if (!int.TryParse(tbTiming.Text, out timingInterval))
                            {
                                lblMessageHit.Text = rm.GetString("strMsgInvalidTimingParam");
                                return;
                            }
                            else
                            {
                                if (timingInterval < 2 || timingInterval > 100)
                                {
                                    lblMessageHit.Text = rm.GetString("strMsgInvalidTimingParam");
                                    return;
                                }
                            }
                        }
                        result = Discrete.UpdateTimeInterval(device, (byte)timingInterval);
                        if (0 == result)
                        {
                            lblMessageHit.Text = rm.GetString("strMsgFailedSetWorkMode");
                            return;
                        }
                        result = Discrete.UpdateTimeIntervalSpeed(device, (byte)cbbReadSpeed.SelectedIndex);
                        if (0 == result)
                        {
                            lblMessageHit.Text = rm.GetString("strMsgFailedSetWorkMode");
                            return;
                        }
                        break;
                    case 2: //触发模式
                        // 触发开关参数
                        if ((trigSwitch = cbbTrigSwitch.SelectedIndex) == -1)
                        {
                            lblMessageHit.Text = rm.GetString("strMsgInvalidTrigSwitch");
                            return;
                        }
                        if (tbWorkMode.SelectedIndex == 2)
                        {
                            // 触发延时参数
                            if (!int.TryParse(tbDelay.Text, out delayTime))
                            {
                                lblMessageHit.Text = rm.GetString("strMsgInvalidDelayTime");
                                return;
                            }
                            else
                            {
                                if (delayTime < 0 || delayTime > 300)
                                {
                                    lblMessageHit.Text = rm.GetString("strMsgInvalidDelayTime");
                                    return;
                                }
                            }
                        }
                        result = Discrete.UpdateTriggerDelayTime(device, (byte)delayTime);
                        if (0 == result)
                        {
                            lblMessageHit.Text = rm.GetString("strMsgFailedSetWorkMode");
                            return;
                        }
                        result = Discrete.UpdateTriggerSwitch(device, (byte)trigSwitch);
                        if (0 == result)
                        {
                            lblMessageHit.Text = rm.GetString("strMsgFailedSetWorkMode");
                            return;
                        }
                        break;
                }
                byte status = (byte)(chkAjaDisc.Checked ? 1 : 0);
                result = Discrete.UpdateAdjacentDiscriminantStatus(device, (byte)status);
                if (0 == result)
                {
                    lblMessageHit.Text = rm.GetString("strMsgFailedSetWorkMode");
                    return;
                }
                if (chkAjaDisc.Checked)
                {
                    // 相邻判别时间
                    if (!int.TryParse(tbNeighJudge.Text, out adjaDisTime))
                    {
                        lblMessageHit.Text = rm.GetString("strMsgInvalidNJ");
                        return;
                    }
                    else
                    {
                        if (adjaDisTime > 255 || adjaDisTime < 0)
                        {
                            lblMessageHit.Text = rm.GetString("stMsgNJValid");
                            return;
                        }
                    }
                    result = Discrete.UpdateAdjacentDiscriminantTime(device, (byte)adjaDisTime);
                    if (0 == result)
                    {
                        lblMessageHit.Text = rm.GetString("strMsgFailedSetWorkMode");
                        return;
                    }
                }
                Discrete.UpdateWorkMode(device, mode);
                if (0 == result)
                {
                    lblMessageHit.Text = rm.GetString("strMsgFailedSetWorkMode");
                    return;
                }
                lblMessageHit.Text = rm.GetString("strMsgSucceedSetWorkMode");
            }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }
        
        private void queryWorkMode() 
        {
            try
            {
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];
                byte mode = 0;
                int result = Discrete.QueryWorkMode(device,out mode);
                if (0 == result)
                {
                    lblMessageHit.Text = rm.GetString("strMsgFailedReadCommMode");
                    return;
                }
                tbWorkMode.SelectedIndex = mode;
                switch (mode)
                {
                    case 0://主从模式
                        break;
                    case 1://定时模式
                        byte time = 0;
                        byte speed = 0;
                        result = Discrete.QueryTimeInterval(device,out time);
                        if (0 == result)
                        {
                            lblMessageHit.Text = rm.GetString("strMsgFailedReadCommMode");
                            return;
                        }
                        result = Discrete.QueryTimeIntervalSpeed(device, out speed);
                        if (0 == result)
                        {
                            lblMessageHit.Text = rm.GetString("strMsgFailedReadCommMode");
                            return;
                        }
                        tbTiming.Text = string.Format("{0:d}", time);
                        cbbReadSpeed.SelectedIndex = speed;
                        break;
                    case 2://触发模式
                        byte delayTime = 0;
                        byte triggerSwitch = 0;
                        result = Discrete.QueryTriggerDelayTime(device, out delayTime);
                        if (0 == result)
                        {
                            lblMessageHit.Text = rm.GetString("strMsgFailedReadCommMode");
                            return;
                        }
                        result = Discrete.QueryTriggerSwitch(device, out triggerSwitch);
                        if (0 == result)
                        {
                            lblMessageHit.Text = rm.GetString("strMsgFailedReadCommMode");
                            return;
                        }
                        cbbTrigSwitch.SelectedIndex = triggerSwitch;
                        tbDelay.Text = string.Format("{0:d}",delayTime);
                        break;
                    default:
                        break;

                }
                byte stataus = 0;
                byte adjacentDiscriminantTime = 0;
                result = Discrete.QueryAdjacentDiscriminantStatus(device, out stataus);
                if (0 == result)
                {
                    lblMessageHit.Text = rm.GetString("strMsgFailedReadCommMode");
                    return;
                }
                result = Discrete.QueryAdjacentDiscriminantTime(device, out adjacentDiscriminantTime);
                if (0 == result)
                {
                    lblMessageHit.Text = rm.GetString("strMsgFailedReadCommMode");
                    return;
                }
                chkAjaDisc.Checked = stataus > 0 ? true : false;
                tbNeighJudge.Visible = chkAjaDisc.Checked;
                tbNeighJudge.Text = string.Format("{0:d}", adjacentDiscriminantTime);
                lblMessageHit.Text = rm.GetString("strMsgSucceedGetWorkMode");
            }
            catch
            {
                lblMessageHit.Text = rm.GetString("strMsgFailedReadCommMode");
            }
        }

        /********************************************读写器参数设置 2021-03-09 End**************************************************************/
        #endregion 读写器参数设置

        #region 通讯参数设置

        private void labDestIP_Click(object sender, EventArgs e)
        {
            cbbDestIP.Items.Clear();
            cbbDestIP.Text = "";

            byte[] IP = new byte[50];
            byte count = 0;
            int result = JTDM.QueryLocalHosts(IP, out count);
            string[] host = (System.Text.Encoding.ASCII.GetString(IP)).Replace("\0", "").Split(',');
            for (int i = 0; i < count; i++)
            {
                cbbDestIP.Items.Add(host[i]);
            }
            if (count > 0)
            {
                cbbDestIP.SelectedIndex = 0;
            }
        }

        private void lvZl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvZl.Items.Count > 0)
            {
                JTDM.m_SelectedDevNo = (byte)(lvZl.Items.IndexOf(lvZl.FocusedItem));
                UpdateCommParamControl(JTDM.m_SelectedDevNo);
            }
        }

        /// <summary>
        /// 搜索设备
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchDev_Click(object sender, EventArgs e)
        {
            try
            {
                lvZl.Items.Clear();
                JTDM.StartSearchDev(out JTDM.m_DevCnt);
                lock (lvZl.Items)
                {
                    for (byte i = 0; i < JTDM.m_DevCnt; ++i)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = (i + 1).ToString();
                        byte[] IP = new byte[100];
                        byte[] deviceId = new byte[100];
                        int port = 0;

                        JTDM.QueryIP(i, IP);
                        JTDM.QueryPort(i, out port);
                        JTDM.QueryDevID(i, deviceId);

                        string IP_Address = System.Text.Encoding.ASCII.GetString(IP);
                        string ID = System.Text.Encoding.ASCII.GetString(deviceId);
                        string port_data = port + "";
                        lvi.SubItems.Add(IP_Address);
                        lvi.SubItems.Add(port_data);
                        lvi.SubItems.Add(ID);
                        lvZl.Items.Add(lvi);
                    }
                }
                if (JTDM.m_DevCnt > 0)
                {
                    JTDM.m_SelectedDevNo = 0;
                    UpdateCommParamControl(JTDM.m_SelectedDevNo); // 更新页面控件           
                    lvZl.FocusedItem = lvZl.Items[0];// 设置第一项为焦点项
                }

            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// 编辑设备
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyDev_Click(object sender, EventArgs e)
        {
            if (lvZl.SelectedItems != null)
            {
                listViewDev_ItemActivate(sender, e);
            }
        }

        /// <summary>
        /// 设置默认参数
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDefaultParams_Click(object sender, EventArgs e)
        {
            comboBoxNetMode.SelectedIndex = 0;
            comboBoxIPMode.SelectedIndex = 0;
            textBoxIPAdd.Text = "192.168.1.200";
            textBoxNetMask.Text = "255.255.255.0";
            textBoxPortNo.Text = "4196";
            textBoxGateway.Text = "192.168.1.1";
            tbDestIP.Text = "192.168.1.100";
            cbbDestIP.Text = "192.168.1.100";

            textBoxDestPort.Text = "4196";
            comboBoxBaudRate.SelectedIndex = 4;
            comboBoxDataBits.SelectedIndex = 0;
            comboBoxCheckBits.SelectedIndex = 0;
        }

        /// <summary>
        /// 设置通信参数
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetParams_Click(object sender, EventArgs e)
        {
            if (-1 == comboBoxNetMode.SelectedIndex)
            {
                lblMessageHit.Text = rm.GetString("strMsgSelectNetMode");
                return;
            }
            if (-1 == comboBoxIPMode.SelectedIndex)
            {
                lblMessageHit.Text = rm.GetString("strMsgSelectIPMode");
                return;
            }
            if (-1 == comboBoxBaudRate.SelectedIndex)
            {
                lblMessageHit.Text = rm.GetString("strMsgSelectBaudRate");
                return;
            }
            if (-1 == comboBoxDataBits.SelectedIndex)
            {
                lblMessageHit.Text = rm.GetString("strMsgSelectDataBits");
                return;
            }
            if (-1 == comboBoxDataBits.SelectedIndex)
            {
                lblMessageHit.Text = rm.GetString("strMsgSelectParity");
                return;
            }
            // 检查IP地址
            if (!DataConvert.IsValidIP(textBoxIPAdd.Text))
            {
                lblMessageHit.Text = rm.GetString("strMsgInvalidIP");
                return;
            }
            // 检查掩码
            if (!DataConvert.IsValidIP(textBoxNetMask.Text))
            {
                lblMessageHit.Text = rm.GetString("strMsgInvalidMask");
                return;
            }
            // 检查网关
            if (!DataConvert.IsValidIP(textBoxGateway.Text))
            {
                lblMessageHit.Text = rm.GetString("strMsgInvalidGateway");
                return;
            }
            // 检查目标IP
            //if (!DataConvert.IsValidIP(tbDestIP.Text))
            //{
            //    MessageBox.Show(rm.GetString("strMsgInvalidDestIP"));
            //    return;
            //}
            if (!DataConvert.IsValidIP(cbbDestIP.Text))
            {
                lblMessageHit.Text = rm.GetString("strMsgInvalidDestIP");
                return;
            }


            // 检查端口号
            int value = int.Parse(textBoxPortNo.Text);
            if (value < 1000 || value > 65535)
            {
                lblMessageHit.Text = rm.GetString("strMsgInvalidPort");
                return;
            }
            value = int.Parse(textBoxDestPort.Text);
            if (value < 1000 || value > 65535)
            {
                lblMessageHit.Text = rm.GetString("strMsgInvalidDestPort");
                return;
            }
             ushort port = DataConvert.ReverseByte(ushort.Parse(textBoxPortNo.Text));
             ushort destport = DataConvert.ReverseByte(ushort.Parse(textBoxDestPort.Text));

             byte[] ip = new byte[32];
             byte[] netmask = new byte[32];
             byte[] gateway = new byte[32];
             byte[] destip = new byte[32];

             ip = Encoding.ASCII.GetBytes(textBoxIPAdd.Text);
             netmask = Encoding.ASCII.GetBytes(textBoxNetMask.Text);
             gateway = Encoding.ASCII.GetBytes(textBoxGateway.Text);

             destip = Encoding.ASCII.GetBytes(tbDestIP.Text);

             destip = Encoding.ASCII.GetBytes(cbbDestIP.Text);

             JTDM.UpdateNetworkMode(JTDM.m_SelectedDevNo, (byte)comboBoxNetMode.SelectedIndex);
             JTDM.UpdateIPMode(JTDM.m_SelectedDevNo, (byte)comboBoxIPMode.SelectedIndex);
             JTDM.UpdateIP(JTDM.m_SelectedDevNo, ip);
             JTDM.UpdateSubnetMask(JTDM.m_SelectedDevNo, netmask);
             JTDM.UpdatePort(JTDM.m_SelectedDevNo, port);
             JTDM.UpdateGateWay(JTDM.m_SelectedDevNo, gateway);
             JTDM.UpdateDestName(JTDM.m_SelectedDevNo, destip);
             JTDM.UpdateDestPort(JTDM.m_SelectedDevNo, destport);
             JTDM.UpdateBaudrateIndex(JTDM.m_SelectedDevNo, (byte)comboBoxBaudRate.SelectedIndex);
             JTDM.UpdateDataBits(JTDM.m_SelectedDevNo, (byte)comboBoxDataBits.SelectedIndex);
             JTDM.UpdateParity(JTDM.m_SelectedDevNo, (byte)comboBoxCheckBits.SelectedIndex);

             int res = JTDM.UpdateParam(JTDM.m_SelectedDevNo);
             if (res == 1)
             {
                 lblMessageHit.Text = rm.GetString("strMsgSucceedSetCommParam");
             }
             else
             {
                 lblMessageHit.Text = rm.GetString("strMsgFailedSetCommParam");
             }
        }

        private void listViewDev_ItemActivate(object sender, EventArgs e)
        {
            if (lvZl.Items.Count > 0)
            {
                JTDM.m_SelectedDevNo = (byte)(lvZl.Items.IndexOf(lvZl.FocusedItem));
                UpdateCommParamControl(JTDM.m_SelectedDevNo);
            }
        }

        private void UpdateCommParamControl(byte index)
        {
            if (JTDM.m_DevCnt > 0)
            {
                byte networkMode = 0;
                byte IPMode = 0;
                byte [] IPAdd = new byte[100];
                byte[] NetMask = new byte[100];
                int PortNo = 0;
                byte[] Gateway = new byte[100];
                byte[] DestIP = new byte[100];
                ushort DestPort = 0;
                byte BaudRate = 0;
                byte DataBits = 0;
                byte CheckBits = 0;

                JTDM.QueryNetworkMode(index, out networkMode);
                JTDM.QueryIPMode(index, out IPMode);
                JTDM.QueryIP(index, IPAdd);
                JTDM.QuerySubnetMask(index, NetMask);
                JTDM.QueryPort(index, out PortNo);
                JTDM.QueryGateWay(index, Gateway);
                JTDM.QueryDestName(index, DestIP);
                JTDM.QueryDestPort(index, out DestPort);
                JTDM.QueryBaudrateIndex(index, out BaudRate);
                JTDM.QueryDataBits(index, out DataBits);
                JTDM.QueryParity(index, out CheckBits);

                comboBoxNetMode.SelectedIndex = networkMode;
                comboBoxIPMode.SelectedIndex = IPMode;
                textBoxIPAdd.Text = System.Text.Encoding.ASCII.GetString(IPAdd);
                textBoxNetMask.Text = System.Text.Encoding.ASCII.GetString(NetMask);
                textBoxPortNo.Text = PortNo.ToString();
                textBoxGateway.Text = System.Text.Encoding.ASCII.GetString(Gateway);

                cbbDestIP.Items.Clear();
                tbDestIP.Text = System.Text.Encoding.ASCII.GetString(DestIP);
                cbbDestIP.Text = System.Text.Encoding.ASCII.GetString(DestIP);


                textBoxDestPort.Text = DestPort.ToString();
                comboBoxBaudRate.SelectedIndex = BaudRate;
                comboBoxDataBits.SelectedIndex = DataBits;
                comboBoxCheckBits.SelectedIndex = CheckBits;
            }
        }

        #endregion 通讯参数设置

        #region 其它操作
        /********************************************其化参数设置 2021-03-09 Start**************************************************************/
        private byte GetAnt()
        {
            if (rbAnt1.Checked) return 1;
            if (rbAnt2.Checked) return 2;
            if (rbAnt3.Checked) return 3;
            if (rbAnt4.Checked) return 4;
            if (rbAnt5.Checked) return 5;
            if (rbAnt6.Checked) return 6;
            if (rbAnt7.Checked) return 7;
            if (rbAnt8.Checked) return 8;
            return 0;
        }


        private void btnReadSerialNumber_Click(object sender, EventArgs e)
        {
            string key = selecteDevice();
            if (null == key)
            {
                return;
            }
            int device = hashMap[key];
            byte[] serialNumber = new byte[100];
            byte len = 0;
            int result = Discrete.QueryDeviceSerialNumber(device, serialNumber, out  len);
            if (result < 1)
            {
                lblMessageHit.Text = rm.GetString("strMessageQueryDeviceSerialNumberFailure");
                return;
            }
            lblMessageHit.Text = rm.GetString("strMessageQueryDeviceSerialNumberSuccessed");
            lblMessageHit.Text += System.Text.Encoding.ASCII.GetString(serialNumber);
        }

        static string value = null;

        private static void addSerialNumber()
        {
            StringBuilder sb = new StringBuilder();
            string curretnTime = DateTime.Now.ToString("yyyyMMdd");
            sb.Append(curretnTime);

            string outString = "";
            string outIndex = "";
            FileOperation.GetValue("Config", "snTime", out outString, IniFilePath);
            FileOperation.GetValue("Config", "snIndex", out outIndex, IniFilePath);
            if (outString == curretnTime)
            {
                value = curretnTime;
                if (!Regex.IsMatch(outIndex, @"^-?[1-9]\d*$|^0$"))
                {
                    outIndex = index.ToString();
                }
                index = int.Parse(outIndex);
                value += index.ToString().PadLeft(4, '0');
                value = (long.Parse(value)).ToString();
            }
            else
            {
                index = 0;
                string date = index.ToString().PadLeft(4, '0');
                sb.Append(date);
                value = sb.ToString();
            }
            mainWindow.tbSerialNumber.TextChanged -= new System.EventHandler(mainWindow.tbSerialNumber_TextChanged);
            mainWindow.tbSerialNumber.Text = value;
            mainWindow.tbSerialNumber.TextChanged += new System.EventHandler(mainWindow.tbSerialNumber_TextChanged);

        }

        private void btnSetSerialNumber_Click(object sender, EventArgs e)
        {
            try
            {
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];
                byte[] serialNumber = new byte[100];
                if (changed == 0)
                {
                    addSerialNumber();
                }
                string number = tbSerialNumber.Text;
                if (number.Length < 8)
                {
                    lblMessageHit.Text = rm.GetString("strMessageUpdateDeviceSerialNumberFailure");
                    return;
                }
                int result = Discrete.UpdateDeviceSerialNumber(device, number.ToCharArray());
                if (result == 0)
                {
                    lblMessageHit.Text = rm.GetString("strMessageUpdateDeviceSerialNumberFailure");
                    return;
                }
                ++index;
                string date = number.Substring(0, 8);
                FileOperation.WritePrivateProfileString("Config", "snIndex", index.ToString(), IniFilePath);
                FileOperation.WritePrivateProfileString("Config", "snTime", date, IniFilePath);
                lblMessageHit.Text = rm.GetString("strMessageUpdateDeviceSerialNumberSuccessed");
                tbSerialNumber.TextChanged -= new System.EventHandler(this.tbSerialNumber_TextChanged);
                tbSerialNumber.Text = (date + index.ToString().PadLeft(4, '0')).ToString();
                tbSerialNumber.TextChanged += new System.EventHandler(this.tbSerialNumber_TextChanged);
            }
            catch (Exception)
            {
                lblMessageHit.Text = rm.GetString("strMessageUpdateDeviceSerialNumberFailure");
            }
        }

        static int changed = 0;

        private void tbSerialNumber_TextChanged(object sender, EventArgs e)
        {
            changed = 1;
        }

        private void OtherOpreation_Enter_Fun(object sender, EventArgs e)
        {
            //btnReadBeep_Click(null, null);
            //btnReadPower_Click(null, null);
            //btnReadDeviceId_Click(null, null);
            //btnReadUsbFormat_Click(null,null);
            //btnReadEPCDataFormat_Click(null, null);
            //btnAntRead_Click(null, null);
            //btnGetReadMode_Click(null, null);
            //btnReadDataArea_Click(null, null);
        }
        
        /// <summary>
        /// 查询设备号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadDeviceId_Click(object sender, EventArgs e)
        {
            queryDeviceId();
        }

        /// <summary>
        /// 设置设备号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetDeviceId_Click(object sender, EventArgs e)
        {
            updateDeviceId();
        }

        /// <summary>
        /// 设置功率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetPower_Click(object sender, EventArgs e)
        {
            updatePower();
        }

        /// <summary>
        /// 查询功率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadPower_Click(object sender, EventArgs e)
        {
            queryPower();
        }

        /// <summary>
        /// 查询读卡模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetReadMode_Click(object sender, EventArgs e)
        {
            querySingleOrMultiTag();
        }

        /// <summary>
        /// 设置读卡模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetReadMode_Click(object sender, EventArgs e)
        {
           updateSingleOrMultiTag();
        }

        /// <summary>
        /// 查询天线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAntRead_Click(object sender, EventArgs e)
        {
            queryAntParam();
        }

        /// <summary>
        /// 设置天线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAntSet_Click(object sender, EventArgs e)
        {
            updateAntParam();
        }

        /// <summary>
        /// 查询蜂鸣器(声音)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadBeep_Click(object sender, EventArgs e)
        {
            queryBuzzer();
        }

        /// <summary>
        /// 设置蜂鸣器(声音)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetBeep_Click(object sender, EventArgs e)
        {
            updateBuzzer();
        }

        /// <summary>
        /// 查询读数据区域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadDataArea_Click(object sender, EventArgs e)
        {
            queryDataArea();
        }

        /// <summary>
        /// 设置读数据区域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetDataArea_Click(object sender, EventArgs e)
        {
            updateDataArea();
        }

        /// <summary>
        /// 读取非USB数据输出格式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadEPCDataFormat_Click(object sender, EventArgs e)
        {
            queryNotUsbOutputFormat();
        }

        /// <summary>
        /// 设置非USB数据输出格式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetEPCDataFormat_Click(object sender, EventArgs e)
        {
            updateNotUsbOutputFormat();
        }

        /// <summary>
        /// 读取USB数据输出格式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadUsbFormat_Click(object sender, EventArgs e)
        {
            queryUsbOutputFormat();
        }

        /// <summary>
        /// 设置USB数据输出格式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetUsbFormat_Click(object sender, EventArgs e)
        {
            updateUsbOutputFormat();
        }

        /// <summary>
        /// 设置GPIO继电器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetRelayTime_Click(object sender, EventArgs e)
        {
            updateRelayContrl();
        }

        /// <summary>
        /// 标签授权
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTagAuth_Click(object sender, EventArgs e)
        {
            tagAuther();
        }

        /// <summary>
        /// 查询授权码头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQueryAuthorization_Click(object sender, EventArgs e)
        {
            queryTagAuthorization();
        }

        /// <summary>
        /// 修改授权码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyAuthPwd_Click(object sender, EventArgs e)
        {
            modifyAuthPwd();
        }

        /// <summary>
        /// 自动授权
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoAuthorization_Click(object sender, EventArgs e)
        {
            autoAuthorization();
        }

        Thread autoAuthorizationThread;
        string AuthorizationSuccess;
        string NoneAuthorizationTag;

        private void autoAuthorization() 
        {
            try
            {
                if (btnAutoAuthorization.Text == rm.GetString("startAutoAuthorization"))
                {
                    autoAuthorizationThread = new Thread(new ThreadStart(AuthorizationMethod));
                    autoAuthorizationThread.Start();
                    btnAutoAuthorization.Text = rm.GetString("stopAutoAuthorization");
                }
                else if (btnAutoAuthorization.Text == rm.GetString("stopAutoAuthorization"))
                {
                    autoAuthorizationThread.Abort();
                    btnAutoAuthorization.Text = rm.GetString("startAutoAuthorization");
                }
            }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }

        private void AuthorizationMethod()
        {
            try
            {
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];
                while (autoAuthorizationThread.IsAlive)
                {
                    if (0 < Discrete.TagAuther(device))
                    {
                        lblMessageHit.Text = rm.GetString("strMsgSucceedAuth");
                        lblMessageHit.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblMessageHit.Text = rm.GetString("NoneAuthorizationTag");
                        lblMessageHit.ForeColor = Color.Black;
                    }
                    Thread.Sleep(500);
                }
             }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }

        private void modifyAuthPwd() 
        {
            try
            {
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];

                string strAuthPwd = tbAuthPwd.Text.Replace(" ", "");
                string strNewAuthPwd = tbNewAuthPwd.Text.Replace(" ", "");
                if (tbAuthPwd.Text.Length != 4 || tbNewAuthPwd.Text.Length != 4)
                {
                    lblMessageHit.Text = rm.GetString("strMsgPwdMustFour");
                    return;
                }
                if (!Regex.IsMatch(tbAuthPwd.Text, "^[0-9A-Fa-f]+$") || !Regex.IsMatch(tbNewAuthPwd.Text, "^[0-9A-Fa-f]+$"))
                {
                    lblMessageHit.Text = rm.GetString("strMsgInvalidChar");
                    return;
                }

                byte[] oldPwd = new Byte[2];
                byte[] newPwd = new Byte[2];

                for (int i = 0; i < 2; i++)
                {
                    oldPwd[i] = Convert.ToByte(strAuthPwd.Substring(i * 2, 2), 16);
                    newPwd[i] = Convert.ToByte(strNewAuthPwd.Substring(i * 2, 2), 16);
                }

                byte[] pwd = new byte[10];
                byte pwd_len = 0;
                int result = Discrete.QueryAutherPwd(device, pwd, out pwd_len);
                if (0 < result)
                {
                    lblMessageHit.Text = rm.GetString("strMsgSuccedSetAuthPwd");
                }
                else
                {
                    lblMessageHit.Text = rm.GetString("strMsgFailedSetAuthPwd");
                    return;
                }
                if (pwd[0] == oldPwd[0] && pwd[1] == oldPwd[1])
                {
                    result = Discrete.UpdateAutherPwd(device, newPwd, (byte)newPwd.Length);
                    if (0 < result)
                    {
                        lblMessageHit.Text = rm.GetString("strMsgSuccedSetAuthPwd");
                    }
                    else
                    {
                        lblMessageHit.Text = rm.GetString("strMsgFailedSetAuthPwd");
                    }
                }
                else
                {
                    lblMessageHit.Text = rm.GetString("strMsgInvalidOldPwd");
                    return;
                }

            }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }

        private void tagAuther() 
        {
            try
            {
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];
                int result = Discrete.TagAuther(device);
                if (0 < result)
                {
                    lblMessageHit.Text = rm.GetString("strMsgSucceedAuth");
                }
                else
                {
                    lblMessageHit.Text = rm.GetString("strMsgFailedAuth");
                }
            }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }

        private void queryTagAuthorization() 
        {
            try
            {
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];
                byte [] pwd = new byte[10];
                byte pwd_len = 0;
                int result = Discrete.QueryAutherPwd(device, pwd,out pwd_len);
                if (0 < result)
                {
                    lblMessageHit.Text = rm.GetString("strGetAuthorizationCodeSuccessed");
                }
                else
                {
                    lblMessageHit.Text = rm.GetString("strGetAuthorizationCodeFailure");
                }
                tbAuthPwd.Text = pwd[0].ToString("X2") + pwd[1].ToString("X2");
            }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }

        private void updateRelayContrl()
        {
            try
            {
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];
                byte mode = (byte)tbRelayMode.SelectedIndex;
                int successCount = 0;
                int result = Discrete.UpdateRelayInitiativeOrPassivity(device, mode);
                if (0 < result)
                {
                    successCount++;
                }
                if (mode == 0)//GPIO主动模式
                {
                    int relayTime = 0;
                    if (!int.TryParse(cbbRelayTime.Text, out relayTime))
                    {
                        lblMessageHit.Text = rm.GetString("StrMsgcbbRelayTime");
                        return;
                    }
                    else
                    {
                        if (relayTime < 0)
                        {
                            lblMessageHit.Text = rm.GetString("StrMsgcbbRelayTime");
                            return;
                        }
                    }
                    result = Discrete.UpdateRelayInitiativeCloseTime(device, (byte)relayTime);
                    if (0 < result)
                    {
                        successCount++;
                    }
                }
                else //GPIO被动模式
                {
                    result = Discrete.UpdateRelay(device, rdoOpen1.Checked, rdoOpen2.Checked);
                    if (0 < result)
                    {
                        successCount++;
                    }
                }
                if (2 == successCount)
                {
                    lblMessageHit.Text = rm.GetString("strMsgSucceedInvalidbtnSetRelayTime");
                }
                else
                {
                    lblMessageHit.Text = rm.GetString("strMsgFailedInvalidbtnSetRelayTime");
                }
            }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }

        private void queryUsbOutputFormat()
        {
            try
            {
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];
                byte format = 0;
                int result = Discrete.QueryUsbOutputFormat(device, out format);
                if (result < 1)
                {
                    lblMessageHit.Text = rm.GetString("strMessageQueryUSB_DeviceOutputFormatFailure");
                    return;
                }
                lblMessageHit.Text = rm.GetString("strMessageQueryUSB_DeviceOutputFormatSuccessed");
                cbbUsbFormat.SelectedIndex = format > 9 ? -1 : format;
                //MessageBox.Show(rm.GetString("strGetDoubleUSBFailed"));
            }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }

        private void updateUsbOutputFormat()
        {
            try
            {
                if (-1 == cbbUsbFormat.SelectedIndex)
                {
                    lblMessageHit.Text = rm.GetString("strMsgInvalidUsbFormat");
                    return;
                }
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];
                byte format = (byte)cbbUsbFormat.SelectedIndex;
                int result = Discrete.UpdateUsbOutputFormat(device, format);
                if (result < 1)
                {
                    lblMessageHit.Text = rm.GetString("strMsgFailedSetUsbFormat");
                    return;
                }
                lblMessageHit.Text = rm.GetString("strMsgSucceedSetUsbFormat");
            }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }

        private void queryNotUsbOutputFormat() 
        {
            try
            {
                string key = selecteDevice();
                if (null == key)
                {
                    lblMessageHit.Text = rm.GetString("strMessagePleaseChoose");
                    return;
                }
                int device = hashMap[key];
                byte format = 0;
                int result = Discrete.QueryNotUsbOutputFormat(device, out format);
                if (result < 1)
                {
                    lblMessageHit.Text = rm.GetString("strMessageQueryNotUSB_DeviceOutputFormatFailure");
                    return;
                }
                lblMessageHit.Text = rm.GetString("strMessageQueryNotUSB_DeviceOutputFormatSuccessed");
                cbbEPCDataFormat.SelectedIndex = format > 2 ? -1 : format; 
            }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }

        private void updateNotUsbOutputFormat()
        {
            try
            {
                if (-1 == cbbEPCDataFormat.SelectedIndex)
                {
                    //lblMessageHit.Text = "下标有误";
                    return;
                }
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];
                byte format = (byte)cbbEPCDataFormat.SelectedIndex;
                int result = Discrete.UpdateNotUsbOutputFormat(device, format);
                if (result < 1)
                {
                    lblMessageHit.Text = rm.GetString("strMessageUpdateNotUSB_DeviceOutputFormatFailure");
                    return;
                }
                lblMessageHit.Text = rm.GetString("strMessageUpdateNotUSB_DeviceOutputFormatSuccessed");
            }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }

        private void queryDataArea() 
        {
            try
            {
                string key = selecteDevice();
                if (null == key)
                {
                    //lblMessageHit.Text = rm.GetString("strMessagePleaseChoose");
                    return;
                }
                int device = hashMap[key];
                byte operation_area = 0;
                int result = Discrete.QueryEpcOrTid(device, out operation_area);
                if (result < 1)
                {
                    lblMessageHit.Text = rm.GetString("strMessageQueryOperationAreaFailure");
                    return;
                }
                lblMessageHit.Text = rm.GetString("strMessageQueryOperationAreaSuccessed");
                int length = 3;
                cbbDataArea.SelectedIndex = operation_area > length ? -1 : operation_area; 
            }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }

        private void updateDataArea()
        {
            try 
	        {	        
                if (-1 == cbbDataArea.SelectedIndex)
                {
                    lblMessageHit.Text = rm.GetString("strMessagePleaseChoose");
                    return;
                }
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];
                byte operation_area = (byte)cbbDataArea.SelectedIndex;
                int result = Discrete.UpdateEpcOrTid(device, operation_area);
                if (result < 1)
                {
                    lblMessageHit.Text = rm.GetString("strMessageUpdateOperationAreaFailure");
                    return;
                }
                lblMessageHit.Text = rm.GetString("strMessageUpdateOperationAreaSuccessed");
            }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }

        private void queryBuzzer() 
        {
            try
            {
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];
                byte status = 0;
                int result = Discrete.QueryBuzzer(device, out status);
                if (result < 1)
                {
                    lblMessageHit.Text = rm.GetString("strGetBeepFailed");
                    return;
                }
                lblMessageHit.Text = rm.GetString("strGetBeepSuccessed");
                int length = 3;
                cbbBeepControl.SelectedIndex = status > length ? -1 : status;
             }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }

        private void updateBuzzer()
        {
            try
            {
                if (-1 == cbbBeepControl.SelectedIndex)
                {
                    lblMessageHit.Text = rm.GetString("strMsgInvalidBeepControl");
                    return;
                }

                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];
                byte status = (byte)cbbBeepControl.SelectedIndex;
                int result = Discrete.UpdateBuzzer(device, status);
                if (result < 1)
                {
                    lblMessageHit.Text = rm.GetString("strMsgFailedBeepControl");
                    return;
                }
                lblMessageHit.Text = rm.GetString("strMsgSucceedBeepControl");
            }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }

        private void queryAntParam() {
            try
            {
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];
                byte [] ants = new byte[8];
                byte antsLen = 0;
                int result = Discrete.QueryAntenna(device, ants, out antsLen);
                if (result < 1)
                {
                    lblMessageHit.Text = rm.GetString("strMsgFailedInvalidbtnAntRead");
                    return;
                }
                lblMessageHit.Text = rm.GetString("strMsgSucceedGetAnt");
                chkAnt1.Checked = ants[0] > 0 ? true : false;
                chkAnt2.Checked = ants[1] > 0 ? true : false;
                chkAnt3.Checked = ants[2] > 0 ? true : false;
                chkAnt4.Checked = ants[3] > 0 ? true : false;
                chkAnt5.Checked = ants[4] > 0 ? true : false;
                chkAnt6.Checked = ants[5] > 0 ? true : false;
                chkAnt7.Checked = ants[6] > 0 ? true : false;
                chkAnt8.Checked = ants[7] > 0 ? true : false;
            }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }

        private void updateAntParam()
        {
            try{
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];
                byte[] ants = new byte[8];

                ants[0] = (byte)(chkAnt1.Checked ? 1 : 0);
                ants[1] = (byte)(chkAnt2.Checked ? 1 : 0);
                ants[2] = (byte)(chkAnt3.Checked ? 1 : 0);
                ants[3] = (byte)(chkAnt4.Checked ? 1 : 0);
                ants[4] = (byte)(chkAnt5.Checked ? 1 : 0);
                ants[5] = (byte)(chkAnt6.Checked ? 1 : 0);
                ants[6] = (byte)(chkAnt7.Checked ? 1 : 0);
                ants[7] = (byte)(chkAnt8.Checked ? 1 : 0);
                int result = Discrete.UpdateAntenna(device, ants);
                if (result < 1)
                {
                    lblMessageHit.Text = rm.GetString("strMsgFailedSetAnt");
                    return;
                }
                lblMessageHit.Text = rm.GetString("strMsgSucceedSetAnt");
            }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }

        private void querySingleOrMultiTag() {
            try
            {
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];
                byte readingMode = 0;
                int result = Discrete.QuerySingleOrMultiTag(device, out readingMode);
                if (result < 1)
                {
                    lblMessageHit.Text = rm.GetString("strMessageQueryReadTagModeFailure");
                    return;
                }
                lblMessageHit.Text = rm.GetString("strMessageQueryReadTagModeSuccessed");
                int length = 2;
                cbbSingOrMulti.SelectedIndex = readingMode > length ? -1 : readingMode;
            }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }

        private void updateSingleOrMultiTag(){
            try
            {
                int readingMode = 0;
                // 检查单卡多卡模式
                if ((readingMode = cbbSingOrMulti.SelectedIndex) == -1)
                {
                    lblMessageHit.Text = rm.GetString("strMsgInvalidSingleOrMulti");
                    return;
                }
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];
                int result = Discrete.UpdateSingleOrMultiTag(device, (byte)readingMode);
                if (result < 1)
                {
                    lblMessageHit.Text = rm.GetString("strMessageUpdateReadTagModeFailure");
                    return;
                }
                lblMessageHit.Text = rm.GetString("strMessageUpdateReadTagModeSuccessed");
            }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }

        private void queryDeviceId() {
            try
            {
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];
                byte deviceid = 0;
                int result = Discrete.QueryDeviceId(device, out deviceid);
                if (result < 1)
                {
                    lblMessageHit.Text = rm.GetString("strMessageQueryDeviceNoFailure");
                    return;
                }
                lblMessageHit.Text = rm.GetString("strMessageQueryDeviceNoSuccessed");
                tbNewDevNo.Text = string.Format("{0:d}", deviceid);
            }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }

        private void updateDeviceId()
        {
            try
            {
                int deviceNo = 0;
                //  检查设备号
                if (!int.TryParse(tbNewDevNo.Text, out deviceNo))
                {
                    lblMessageHit.Text = rm.GetString("strMsgInvalidDevNo");
                    return;
                }
                else
                {
                    if (deviceNo > 255)
                    {
                        lblMessageHit.Text = rm.GetString("strMsgInvalidDevNo");
                        return;
                    }
                }
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];
                int result = Discrete.UpdateDeviceId(device, (byte)(deviceNo));
                if (result < 1)
                {
                    lblMessageHit.Text = rm.GetString("strMessageUpdateDeviceNoFailure");
                    return;
                }
                lblMessageHit.Text = rm.GetString("strMessageUpdateDeviceNoSuccessed");
            }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }

        private void queryPower() {
            try
            {
                string key = selecteDevice();
                if(null == key){
                    return;
                }
                int device = hashMap[key];
                byte power = 0;
                int result = Discrete.QueryPower(device, out power);
                tbPower.Text = string.Empty;
                if (result < 1)
                {
                    lblMessageHit.Text = rm.GetString("strMessageQueryPowerFailure");
                    return;
                }
                lblMessageHit.Text = rm.GetString("strMessageQueryPowerSuccessed");
                tbPower.Text = string.Format("{0:d}", power);
            }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }

        private void updatePower() {
            try
            {
                int power = 0;
                // 检查功率值
                if (!int.TryParse(tbPower.Text, out power))
                {
                    lblMessageHit.Text = rm.GetString("strMsgInvalidPower");
                    return;
                }
                else
                {
                    if (power < 1 || power > 150)
                    {
                        DialogResult drs = MessageBox.Show(rm.GetString("strMsgInvalidPower"));
                        if (drs == DialogResult.OK)
                        {
                            //power = 0;
                            tbPower.Text = "150";
                            return;
                        }
                    }
                }
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];
                int result = Discrete.UpdatePower(device, (byte)(power));
                if (result < 1)
                {
                    lblMessageHit.Text = rm.GetString("strMessageUpdatePowerFailure");
                    return;
                }
                lblMessageHit.Text = rm.GetString("strMessageUpdatePowerSuccessed");
            }
            catch (Exception e)
            {
                lblMessageHit.Text = e.Message;
            }
        }
        /********************************************其化参数设置 2021-03-09 End**************************************************************/
        #endregion 其它操作

        #region 国际化
        private void languageGeneral()
        {
            General.Text = rm.GetString("strTpGeneral");
            btnSerialPortConnect.Text = rm.GetString("strBtnConnect");
            btnSerialPortDisconnect.Text = rm.GetString("strBtnDisconnect");
            btnUpdateSerialPort.Text = rm.GetString("strBtnUpdate");
            lblSerialPort.Text = rm.GetString("strRbSerialPort");
            lblBaudRate.Text = rm.GetString("strDatas");
            gbConnectType.Text = rm.GetString("strGbCommMode");
            btnStartMonitor.Text = rm.GetString("btnStartMonitor");
            btnStopMonitor.Text = rm.GetString("btnStopMonitor");

            lblTCPClientPort.Text = rm.GetString("strLabCommPort");
            lblTCPServerPort.Text = rm.GetString("strLabCommPort");
            btnUpdateTCPClient.Text = rm.GetString("strBtnUpdate");
            btnUpdateTCPServer.Text = rm.GetString("strBtnUpdate");

            btnTCPClientConnect.Text = rm.GetString("strBtnConnect");
            btnTCPClientDisconnect.Text = rm.GetString("strBtnDisconnect");

            btnStartReadData.Text = rm.GetString("strBtnStartReadData");
            btnStopReadData.Text = rm.GetString("strBtnStopReadData");
            btnClearListView.Text = rm.GetString("strBtnClearListView");
            btnReadOnce.Text = rm.GetString("strBtnReadOnce");

            gbVersionInfo.Text = rm.GetString("gbVersionInfo");
            btnReadVersion.Text = rm.GetString("btnReadVersionInfo");
            btnBrushVersion.Text = rm.GetString("btnBrushVersion");

        }

        private void languageTagAccess() {
            TagAccess.Text = rm.GetString("strTpTagAccess");

            btnReadFastTag.Text = rm.GetString("btnReadFastTag");
            btnKillTag.Text = rm.GetString("strBtnKillTag");
            btnModifyDev.Text = rm.GetString("strBtnModifyDev");
            btnLockTag.Text = rm.GetString("strBtnLock");
            btnUnlockTag.Text = rm.GetString("strBtnUnlockTag");
            btnInitTag.Text = rm.GetString("strBtnInitTag");
            btnReadData.Text = rm.GetString("strBtnReadTagData");
            gbTagInitialize.Text = rm.GetString("gbTagInitialize");
            gbKillTag.Text = rm.GetString("gbKillTag");
            gbTagLockAndUnlock.Text = rm.GetString("gbTagLockAndUnlock");

        }

        private void cbbLangSwitch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //锁卡操作类型
            cbbLockBank.Items.Clear();
            cbbTrigSwitch.Items.Clear();
            cbbSingOrMulti.Items.Clear();
            //cbbFreqMode.Items.Clear();
            //cbbFreqModeEU.Items.Clear();
            cbbBeepControl.Items.Clear();
            cbbUsbFormat.Items.Clear();
            cbbFrequencyBand.Items.Clear();
            cbbEPCDataFormat.Items.Clear();

            if (cbbLangSwitch.SelectedIndex == 0)
            {
                ChineseLanguage.language(
                            cbbLockBank, cbbTrigSwitch,
                            cbbSingOrMulti, cbbFrequency_Mode,
                            cbbFrequencyBand,
                            cbbBeepControl, cbbUsbFormat,
                            cbbEPCDataFormat);
                
            }
            else
            {
                EnglishLanguage.language(
                            cbbLockBank, cbbTrigSwitch,
                            cbbSingOrMulti, cbbFrequency_Mode,
                            cbbFrequencyBand,
                            cbbBeepControl, cbbUsbFormat,
                            cbbEPCDataFormat);
                cbbEPCDataFormat.SelectedIndex = 1;
            }
            rm = rmArray[cbbLangSwitch.SelectedIndex];
            // Tab标签页标题
            
            
            SetCommParam.Text = rm.GetString("strTpSetCommParam");
            SetReaderParam.Text = rm.GetString("strTpSetReaderParam");
            OtherOpreation.Text = rm.GetString("strTpOtherOpr");

            languageGeneral();
            languageTagAccess();

            tpMaster.Text = rm.GetString("tpMaster");
            tpTiming.Text = rm.GetString("tpTiming");
            tpTrigger.Text = rm.GetString("tpTrigger");

            tpRS485_RJ45.Text = rm.GetString("tpRS485_RJ45");
            tpWiegand.Text = rm.GetString("tpWiegand");
            tpSerialPorts.Text = rm.GetString("tpSerialPorts");

            lblFrequencyArea.Text = rm.GetString("lblFrequencyArea");

            tpUSA_Band.Text = rm.GetString("tpUSA_Band");
            tpEU_Band.Text = rm.GetString("tpEU_Band");
            tpKorea_Band.Text = rm.GetString("tpKorea_Band");

            // 表头更新
            //listView.Columns[0].Text = rm.GetString("strLvHeadNo");
            //listView.Columns[1].Text = rm.GetString("strLvHeadEPC");
            //listView.Columns[2].Text = rm.GetString("strLvHeadCount");
            //listView.Columns[3].Text = rm.GetString("strLvHeadAntNo");
            //listView.Columns[4].Text = rm.GetString("strLvHeadDevNo");
            //listView.Columns[5].Text = rm.GetString("strLvUart_IP");

            listView.Columns.Clear();
            listView.Columns.Add(rm.GetString("strLvHeadNo"), 45, HorizontalAlignment.Center);
            listView.Columns.Add(rm.GetString("strLvHeadEPC"), 300, HorizontalAlignment.Center);
            listView.Columns.Add(rm.GetString("strLvHeadCount"), 60, HorizontalAlignment.Center);
            listView.Columns.Add(rm.GetString("strLvHeadAntNo"), 60, HorizontalAlignment.Center);
            listView.Columns.Add(rm.GetString("strLvHeadDevNo"), 60, HorizontalAlignment.Center);
            listView.Columns.Add(rm.GetString("strLvUart_IP"), 150, HorizontalAlignment.Center);
            listView.Columns.Add(rm.GetString("strLvCurrentTime"), 200, HorizontalAlignment.Center);

            lvZl.Columns[0].Text = rm.GetString("strZlHeadNo");
            lvZl.Columns[1].Text = rm.GetString("strZlHeadIP");
            lvZl.Columns[2].Text = rm.GetString("strZlHeadPort");
            lvZl.Columns[3].Text = rm.GetString("strZlHeadMAC");

            btnDefaultParams.Text = rm.GetString("strBtnDefaultParams");
            btnSearchDev.Text = rm.GetString("strBtnSearchDev");

            btnSetFreq.Text = rm.GetString("strBtnSetDevNo");
            btnSetWorkMode.Text = rm.GetString("strBtnSetNeighJudge");
            btnSetParams.Text = rm.GetString("strBtnSetParams");
            btnWriteData.Text = rm.GetString("strBtnWriteTagData");
            btnClearData.Text = rm.GetString("strBtnClearEditData");
            btnFastWrite.Text = rm.GetString("strBtnFastWrite");
            btnClearFWData.Text = rm.GetString("strBtnClearFWData");
            btnReadWorkMode.Text = rm.GetString("strBtnReadWorkMode");
            btnDefaultWorkMode.Text = rm.GetString("strBtnDefaultWorkMode");
            btnSetWorkMode.Text = rm.GetString("strBtnSetWorkMode");
            btnReadCommMode.Text = rm.GetString("strBtnReadCommMode");
            btnDefaultCommMode.Text = rm.GetString("strBtnDefaultCommMode");
            btnSetCommMode.Text = rm.GetString("strBtnSetCommMode");
            btnReadFreq.Text = rm.GetString("strBtnReadFreq");
            btnSetFreq.Text = rm.GetString("strBtnSetFreq");
            btnDefaultFreq.Text = rm.GetString("strBtnDefaultFreq");
            btnClearFreq.Text = rm.GetString("strBtnClearFreq");
            btnTagAuth.Text = rm.GetString("strBtnTagAuth");
            btnModifyAuthPwd.Text = rm.GetString("strBtnModAuthPwd");

            lblInfoShow.Text = rm.GetString("lblInfoShow");
            btnReadEPCDataFormat.Text = rm.GetString("btnReadEPCDataFormat");
            gbNotDoubleUSBDevice.Text = rm.GetString("gbNotDoubleUSBDevice");
            gbDataOutputFormat.Text = rm.GetString("gbDataOutputFormat");
            btnSetEPCDataFormat.Text = rm.GetString("btnSetEPCDataFormat");
            tpInitiative.Text = rm.GetString("tpInitiative");
            tpPassivity.Text = rm.GetString("tpPassivity");
            btnReadDeviceId.Text = rm.GetString("btnReadDeviceId");
            btnSetDeviceId.Text = rm.GetString("btnSetDeviceId");
            btnReadPower.Text = rm.GetString("btnReadPower");
            btnSetPower.Text = rm.GetString("btnSetPower");

            btnGetReadMode.Text = rm.GetString("btnGetReadMode");
            btnSetReadMode.Text = rm.GetString("btnSetReadMode");
            btnReadSerialNumber.Text = rm.GetString("btnReadSerialNumber");
            btnSetSerialNumber.Text = rm.GetString("btnSetSerialNumber");
            gbSerialNumber.Text = rm.GetString("gbSerialNumber");

            btnSetBeep.Text = rm.GetString("strBtnSetBeep");
            btnSetUsbFormat.Text = rm.GetString("strBtnSetUsbFormat");
            btnReadBeep.Text = rm.GetString("btnReadBeep");
            rdoOpen1.Text = rm.GetString("rdoOpen1");
            rdoClose1.Text = rm.GetString("rdoClose1");
            rdoOpen2.Text = rm.GetString("rdoOpen2");
            rdoClose2.Text = rm.GetString("rdoClose2");
            chkZD.Text = rm.GetString("chkZD");
            //lbl_ip.Text = rm.GetString("");
            btn_connRead.Text = rm.GetString("strBtnConnRead");
            btn_stoptimer.Text = rm.GetString("strStopRead");
            btnWeigandConvert.Text = rm.GetString("strSwitch");
            //反键菜单
            tsmiSave.Text = rm.GetString("saveStr");
            //读写界面
            chkDesignatedAntRead.Text = rm.GetString("strReadByAnt");
            chkDesignatedAntWrite.Text = rm.GetString("strWriteByAnt");
            rbAnt1.Text = rm.GetString("chkAnt1");
            rbAnt2.Text = rm.GetString("chkAnt2");
            rbAnt3.Text = rm.GetString("chkAnt3");
            rbAnt4.Text = rm.GetString("chkAnt4");
            rbAnt5.Text = rm.GetString("chkAnt5");
            rbAnt6.Text = rm.GetString("chkAnt6");
            rbAnt7.Text = rm.GetString("chkAnt7");
            rbAnt8.Text = rm.GetString("chkAnt8");
            // RadioButton标示
            //rbReadSingleTag.Text = rm.GetString("strRbReadSingleTag");
            //rbReadMultiTag.Text = rm.GetString("strRbReadMultiTag");
            rbAsc.Text = rm.GetString("strRbAsc");
            rbDesc.Text = rm.GetString("strRbDesc");
            label3.Text = rm.GetString("strWeigand");
            rbWeigand26_1_2.Text = rm.GetString("strWeigand21");
            rbWeigand26_3_0.Text = rm.GetString("strWeigand30");
            // CheckBox标示

            // GroupBox说明文字
            //gbReadMode.Text = rm.GetString("strGbReadMode");
            gbWorkMode.Text = rm.GetString("strGbDevParams");
            gbFastWrite.Text = rm.GetString("strGbFastWrite");
            gbNetParams.Text = rm.GetString("strGbNetParams");
            gbRWData.Text = rm.GetString("strGbRWData");
            gbSPParams.Text = rm.GetString("strGbSPParams");
            gbCommModeParam.Text = rm.GetString("strGbCommModeParam");
            gbFreq.Text = rm.GetString("strGbFreq");
            gbTagAuth.Text = rm.GetString("strGbTagAuth");
            gbBeepControl.Text = rm.GetString("strGbBeepControl");
            gbUsbFormat.Text = rm.GetString("strGbUsbFormat");

            chkAjaDisc.Text = rm.GetString("strChkAjaDis");
            cbSaveFile.Text = rm.GetString("strChkSaveFile");


            gbDevNo.Text = rm.GetString("strLabDevNo");

            //labDevNo.Text = rm.GetString("strLabDevNo");
            grpAntSet.Text = rm.GetString("grpAntSet");

            chkAnt1.Text = rm.GetString("chkAnt1");
            chkAnt2.Text = rm.GetString("chkAnt2");
            chkAnt3.Text = rm.GetString("chkAnt3");
            chkAnt4.Text = rm.GetString("chkAnt4");
            chkAnt5.Text = rm.GetString("chkAnt5");
            chkAnt6.Text = rm.GetString("chkAnt6");
            chkAnt7.Text = rm.GetString("chkAnt7");
            chkAnt8.Text = rm.GetString("chkAnt8");


            btnAntRead.Text = rm.GetString("btnAntRead");
            btnAntSet.Text = rm.GetString("btnAntSet");

            // Label标签
            labBaudRate.Text = rm.GetString("strLabBaudRate");
            labCheckBits.Text = rm.GetString("strLabCheckBits");
            labDataBits.Text = rm.GetString("strLabDataBits");
            labDestIP.Text = rm.GetString("strLabDestIP");
            labDestPort.Text = rm.GetString("strLabDestPort");
            labDestroyPwd.Text = rm.GetString("strLabDestrlyPwd");

            labGateway.Text = rm.GetString("strLabGateway");
            labIPAdd.Text = rm.GetString("strLabIPAdd");
            labIPMode.Text = rm.GetString("strLabIPMode");
            labLength.Text = rm.GetString("strLabLength");
            labLockAccessPwd.Text = rm.GetString("strLabLockAccessPwd");
            labLockBank.Text = rm.GetString("strLabLockBank");
            labMask.Text = rm.GetString("strLabMask");
            labNetMode.Text = rm.GetString("strLabNetMode");
            labPort.Text = rm.GetString("strLabPort");
            labPromotion.Text = rm.GetString("strLabPromotion");
            labOprBank.Text = rm.GetString("strLabRWBank");
            labData.Text = rm.GetString("strLabRWData");
            labStartAdd.Text = rm.GetString("strLabStartAdd");
            labReadCount.Text = rm.GetString("strLabCount");
            labTagCount.Text = rm.GetString("strLabTagCount");
            labFWData.Text = rm.GetString("strLabFWData");
            labFWPromo.Text = rm.GetString("strLabFWPromotion");
            //labWorkMode.Text = rm.GetString("strLabWorkMode");
            labTimingParam.Text = rm.GetString("strLabTimingParam");
            labTimingUnit.Text = rm.GetString("strLabTimingUnit");
            labTrigSwitch.Text = rm.GetString("strLabTrigSwitch");
            labTrigParam.Text = rm.GetString("strLabTrigParam");
            labDelayUnit.Text = rm.GetString("strLabDelayUnit");
            // labCommMode.Text = rm.GetString("strLabCommMode");
            labPulseWidth.Text = rm.GetString("strLabPulseWidth");
            labPulseWidthUnit.Text = rm.GetString("strLabPulseWidthUnit");
            labPulseCycle.Text = rm.GetString("strLabPulseCycle");
            labPulseCycleUnit.Text = rm.GetString("strLabPulseCycleUnit");
            labWiegandProtocol.Text = rm.GetString("strLabWiegandProtocol");

            gbPower.Text = rm.GetString("strLabPower");
            gbSingleOrMulti.Text = rm.GetString("strLabReadMode");

            //labPower.Text = rm.GetString("strLabPower");
            //labSingleOrMulti.Text = rm.GetString("strLabReadMode");

            labFreq.Text = rm.GetString("strLabFreqSet");
            //lblFreq.Text = rm.GetString("strLabFreqSet");
            labAuthPwd.Text = rm.GetString("strLabAuthPwd");
            labNewAuthPwd.Text = rm.GetString("strLabNewAuthPwd");
            lblWigginsTakePlaceValue.Text = rm.GetString("lblWigginsTakePlaceValue");
            lblReadVoice.Text = rm.GetString("lblReadVoice");

            //2017-2-21 ZW 新增波特率中英文
            lbl_rate.Text = rm.GetString("strLabBaudRate");
            
            // 语言切换后，清空左下角结果提示串
            lblMessageHit.Text = "";
            labelVersion.Text = "";
            labSetParam.Text = "";
            btnReadDataArea.Text = rm.GetString("strBtnReadTagData");
            btnReadUsbFormat.Text = rm.GetString("strBtnReadTagData");
            //继电器控制
            GopRelayControl.Text = rm.GetString("GopRelayControl");
            //rdoOpenRelay.Text = rm.GetString("rdoOpenRelay");
            //rdoCloseRelay.Text = rm.GetString("rdoCloseRelay");
            lblCloseTime.Text = rm.GetString("lblCloseTime");
            btnSetRelayTime.Text = rm.GetString("btnSetRelayTime");
            btnAdvancedAccess.Text = rm.GetString("advancedAccessStr");
            btnAutoAuthorization.Text = rm.GetString("startAutoAuthorization");
            btnAutoAuthorization.Text = rm.GetString("startAutoAuthorization");
            //label1.Text = rm.GetString("AuthorizationResult");
            //authorizationLb.Text = rm.GetString("NoneAuthorizationTag");
            label2.Text = rm.GetString("strLabRWBank");
            btnSetDataArea.Text = rm.GetString("strBtnSetAlive");
            EpcFormatLB.Text = rm.GetString("strFormatEPC");

            btnQueryAuthorization.Text = rm.GetString("strGetAuthorizationCode");
            AuthorizationSuccess = rm.GetString("authorizationSuccess");
            NoneAuthorizationTag = rm.GetString("NoneAuthorizationTag");
            if (bathReadWrite != null)
            {
                bathReadWrite.ChangeLanguage(rm);
            }
        }

        private void InitCommParamControl()
        {
            try
            {
                comboBoxNetMode.Items.Add("TCP Server");
                comboBoxNetMode.Items.Add("TCP Client");
                comboBoxNetMode.Items.Add("UDP");
                comboBoxNetMode.Items.Add("UDP Group");

                comboBoxIPMode.Items.Add("Static");
                comboBoxIPMode.Items.Add("Dynamic");

                comboBoxBaudRate.Items.Add("1200");
                comboBoxBaudRate.Items.Add("2400");
                comboBoxBaudRate.Items.Add("4800");
                comboBoxBaudRate.Items.Add("7200");
                comboBoxBaudRate.Items.Add("9600");
                comboBoxBaudRate.Items.Add("14400");
                comboBoxBaudRate.Items.Add("19200");
                comboBoxBaudRate.Items.Add("28800");
                comboBoxBaudRate.Items.Add("38400");
                comboBoxBaudRate.Items.Add("57600");
                comboBoxBaudRate.Items.Add("76800");
                comboBoxBaudRate.Items.Add("115200");
                comboBoxBaudRate.Items.Add("230400");

                #region  2017-2-21 ZW 参数设置界面新增速率设置
                cbbBaud_Rate.Items.Add("9600");
                cbbBaud_Rate.Items.Add("19200");
                cbbBaud_Rate.Items.Add("38400");
                cbbBaud_Rate.Items.Add("57600");
                cbbBaud_Rate.Items.Add("115200");
                #endregion

                comboBoxDataBits.Items.Add("8");
                comboBoxDataBits.Items.Add("7");
                comboBoxDataBits.Items.Add("6");
                comboBoxDataBits.Items.Add("5");

                comboBoxCheckBits.Items.Add("None");
                comboBoxCheckBits.Items.Add("Odd");
                comboBoxCheckBits.Items.Add("Even");
                comboBoxCheckBits.Items.Add("Marked");
                comboBoxCheckBits.Items.Add("Space");
            }
            catch (Exception e)
            {
                lblMessageHit.Text = "InitCommParamControl " + e.Message;
            }
        }
        #endregion 国际化

        #region 频率选取
        private void EU_hoppingFrequencyPoint(byte[] frequency_point, out byte frequency_point_len)
        {
            frequency_point_len = 12;
            //Group 1
            frequency_point[0] = (byte)(chkFp1.Checked ? 1 : 0);
            frequency_point[1] = (byte)(chkFp2.Checked ? 1 : 0);
            frequency_point[2] = (byte)(chkFp3.Checked ? 1 : 0);
            frequency_point[3] = (byte)(chkFp4.Checked ? 1 : 0);
            frequency_point[4] = (byte)(chkFp5.Checked ? 1 : 0);
            frequency_point[5] = (byte)(chkFp6.Checked ? 1 : 0);
            //Group 2
            frequency_point[6] = (byte)(chkFp7.Checked ? 1 : 0);
            frequency_point[7] = (byte)(chkFp8.Checked ? 1 : 0);
            frequency_point[8] = (byte)(chkFp9.Checked ? 1 : 0);
            frequency_point[9] = (byte)(chkFp10.Checked ? 1 : 0);
            frequency_point[10] = (byte)(chkFp11.Checked ? 1 : 0);
            frequency_point[11] = (byte)(chkFp12.Checked ? 1 : 0);
        }


        private void Korean_hoppingFrequencyPoint(byte[] frequency_point, out byte frequency_point_len)
        {
            frequency_point_len = 6;
            //Group 1
            frequency_point[0] = (byte)(chkFreqKorean1.Checked ? 1 : 0);
            frequency_point[1] = (byte)(chkFreqKorean2.Checked ? 1 : 0);
            frequency_point[2] = (byte)(chkFreqKorean3.Checked ? 1 : 0);
            frequency_point[3] = (byte)(chkFreqKorean4.Checked ? 1 : 0);
            frequency_point[4] = (byte)(chkFreqKorean5.Checked ? 1 : 0);
            frequency_point[5] = (byte)(chkFreqKorean6.Checked ? 1 : 0);
        }

        private void USA_hoppingFrequencyPoint(byte[] frequency_point, out byte frequency_point_len)
        {
            frequency_point_len = 50;
            //Group 1
            frequency_point[0] = (byte)(cbFp1.Checked ? 1 : 0);
            frequency_point[1] = (byte)(cbFp2.Checked ? 1 : 0);
            frequency_point[2] = (byte)(cbFp3.Checked ? 1 : 0);
            frequency_point[3] = (byte)(cbFp4.Checked ? 1 : 0);
            frequency_point[4] = (byte)(cbFp5.Checked ? 1 : 0);
            frequency_point[5] = (byte)(cbFp6.Checked ? 1 : 0);
            frequency_point[6] = (byte)(cbFp7.Checked ? 1 : 0);
            frequency_point[7] = (byte)(cbFp8.Checked ? 1 : 0);
            frequency_point[8] = (byte)(cbFp9.Checked ? 1 : 0);
            frequency_point[9] = (byte)(cbFp10.Checked ? 1 : 0);
            //Group 2
            frequency_point[10] = (byte)(cbFp11.Checked ? 1 : 0);
            frequency_point[11] = (byte)(cbFp12.Checked ? 1 : 0);
            frequency_point[12] = (byte)(cbFp13.Checked ? 1 : 0);
            frequency_point[13] = (byte)(cbFp14.Checked ? 1 : 0);
            frequency_point[14] = (byte)(cbFp15.Checked ? 1 : 0);
            frequency_point[15] = (byte)(cbFp16.Checked ? 1 : 0);
            frequency_point[16] = (byte)(cbFp17.Checked ? 1 : 0);
            frequency_point[17] = (byte)(cbFp18.Checked ? 1 : 0);
            frequency_point[18] = (byte)(cbFp19.Checked ? 1 : 0);
            frequency_point[19] = (byte)(cbFp20.Checked ? 1 : 0);
            //Group 3
            frequency_point[20] = (byte)(cbFp21.Checked ? 1 : 0);
            frequency_point[21] = (byte)(cbFp22.Checked ? 1 : 0);
            frequency_point[22] = (byte)(cbFp23.Checked ? 1 : 0);
            frequency_point[23] = (byte)(cbFp24.Checked ? 1 : 0);
            frequency_point[24] = (byte)(cbFp25.Checked ? 1 : 0);
            frequency_point[25] = (byte)(cbFp26.Checked ? 1 : 0);
            frequency_point[26] = (byte)(cbFp27.Checked ? 1 : 0);
            frequency_point[27] = (byte)(cbFp28.Checked ? 1 : 0);
            frequency_point[28] = (byte)(cbFp29.Checked ? 1 : 0);
            frequency_point[29] = (byte)(cbFp30.Checked ? 1 : 0);
            //Group 4
            frequency_point[30] = (byte)(cbFp31.Checked ? 1 : 0);
            frequency_point[31] = (byte)(cbFp32.Checked ? 1 : 0);
            frequency_point[32] = (byte)(cbFp33.Checked ? 1 : 0);
            frequency_point[33] = (byte)(cbFp34.Checked ? 1 : 0);
            frequency_point[34] = (byte)(cbFp35.Checked ? 1 : 0);
            frequency_point[35] = (byte)(cbFp36.Checked ? 1 : 0);
            frequency_point[36] = (byte)(cbFp37.Checked ? 1 : 0);
            frequency_point[37] = (byte)(cbFp38.Checked ? 1 : 0);
            frequency_point[38] = (byte)(cbFp39.Checked ? 1 : 0);
            frequency_point[39] = (byte)(cbFp40.Checked ? 1 : 0);
            //Group 5
            frequency_point[40] = (byte)(cbFp41.Checked ? 1 : 0);
            frequency_point[41] = (byte)(cbFp42.Checked ? 1 : 0);
            frequency_point[42] = (byte)(cbFp43.Checked ? 1 : 0);
            frequency_point[43] = (byte)(cbFp44.Checked ? 1 : 0);
            frequency_point[44] = (byte)(cbFp45.Checked ? 1 : 0);
            frequency_point[45] = (byte)(cbFp46.Checked ? 1 : 0);
            frequency_point[46] = (byte)(cbFp47.Checked ? 1 : 0);
            frequency_point[47] = (byte)(cbFp48.Checked ? 1 : 0);
            frequency_point[48] = (byte)(cbFp49.Checked ? 1 : 0);
            frequency_point[49] = (byte)(cbFp50.Checked ? 1 : 0);
        }


        /// <summary>
        ///  频率及其它参数设置
        ///  2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetFreq_Click(object sender, EventArgs e)
        {
            try
            {
                int band = cbbFrequencyBand.SelectedIndex;
                int mode = cbbFrequency_Mode.SelectedIndex;
                int fixFrequencyPoint = cbbFixFrequency.SelectedIndex;
                if (band == -1)
                {
                    lblMessageHit.Text = rm.GetString("strMsgInvalidFreqMode");
                    return;
                }
                if (mode == -1)
                {
                    lblMessageHit.Text = rm.GetString("strMsgInvalidFreqPoint");
                    return;
                }
                if (mode == 1 && fixFrequencyPoint == -1)
                {
                    lblMessageHit.Text = rm.GetString("strMsgInvalidFreqPoint");
                    return;
                }

                byte national_standard = (byte)band;
                byte fixed_or_hopping_freq = (byte)mode;
                byte[] frequency_point = new byte[100];
                byte frequency_point_len = 0;
                switch (band)
                {
                    case 0: //USA band
                        if (mode == 0) //跳频
                        {
                            USA_hoppingFrequencyPoint(frequency_point, out frequency_point_len);
                        }
                        else if (mode == 1)//定频
                        {
                            frequency_point[0] = (byte)cbbFixFrequency.SelectedIndex;
                            frequency_point_len = 1;//定频
                        }
                        break;
                    case 1: //EU band
                        if (mode == 0) //跳频
                        {
                            EU_hoppingFrequencyPoint(frequency_point, out frequency_point_len);
                        }
                        else if (mode == 1)//定频
                        {
                            frequency_point[0] = (byte)cbbFixFrequency.SelectedIndex;
                            frequency_point_len = 1;//定频
                        }
                        break;
                    case 2: //Koren band
                        if (mode == 0) //跳频
                        {
                            Korean_hoppingFrequencyPoint(frequency_point, out frequency_point_len);
                        }
                        else if (mode == 1)//定频
                        {
                            frequency_point[0] = (byte)cbbFixFrequency.SelectedIndex;
                            frequency_point_len = 1;//定频
                        }
                        break;
                }

                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];
                int result = Discrete.UpdateFrequencyPoints(device, national_standard, fixed_or_hopping_freq, frequency_point, frequency_point_len);
                if (0 == result)
                {
                    lblMessageHit.Text = rm.GetString("strMsgFailedSetFreq");
                    return;
                }
                lblMessageHit.Text = rm.GetString("strMsgSucceedSetFreq");
            }
            catch (Exception e2)
            {
                lblMessageHit.Text = e2.Message;
            }
        }

        private void EU_bandHoppingFrequency(byte[] frequency_point, byte frequency_point_len)
        {
            if (frequency_point_len != 12)
            {
                return;
            }
            //Group 1
            chkFp1.Checked = frequency_point[0] > 0 ? true : false;
            chkFp2.Checked = frequency_point[1] > 0 ? true : false;
            chkFp3.Checked = frequency_point[2] > 0 ? true : false;
            chkFp4.Checked = frequency_point[3] > 0 ? true : false;
            chkFp5.Checked = frequency_point[4] > 0 ? true : false;
            chkFp6.Checked = frequency_point[5] > 0 ? true : false;
            //Group 2
            chkFp7.Checked = frequency_point[6] > 0 ? true : false;
            chkFp8.Checked = frequency_point[7] > 0 ? true : false;
            chkFp9.Checked = frequency_point[8] > 0 ? true : false;
            chkFp10.Checked = frequency_point[9] > 0 ? true : false;
            chkFp11.Checked = frequency_point[10] > 0 ? true : false;
            chkFp12.Checked = frequency_point[11] > 0 ? true : false;
        }

        private void Korean_bandHoppingFrequency(byte[] frequency_point, byte frequency_point_len)
        {
            if (frequency_point_len != 6)
            {
                return;
            }
            //Group 1
            chkFreqKorean1.Checked = frequency_point[0] > 0 ? true : false;
            chkFreqKorean2.Checked = frequency_point[1] > 0 ? true : false;
            chkFreqKorean3.Checked = frequency_point[2] > 0 ? true : false;
            chkFreqKorean4.Checked = frequency_point[3] > 0 ? true : false;
            chkFreqKorean5.Checked = frequency_point[4] > 0 ? true : false;
            chkFreqKorean6.Checked = frequency_point[5] > 0 ? true : false;
        }

        /// <summary>
        /// 频率及其它参数读取
        /// 2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadFreq_Click(object sender, EventArgs e)
        {
            try
            {
                string key = selecteDevice();
                if (null == key)
                {
                    return;
                }
                int device = hashMap[key];
                byte national_standard = 0;
                byte fixed_or_hopping_freq;
                byte[] frequency_point = new byte[100];
                byte frequency_point_len = 0;
                int result = Discrete.QueryFrequencyPoints(device, out national_standard, out fixed_or_hopping_freq, frequency_point, out frequency_point_len);
                if (result < 1)
                {
                    lblMessageHit.Text = rm.GetString("strMsgFailureGetFreq");
                    return;
                }
                //lblMessageHit.Text = "读取频率成功!";
                cbbFrequencyBand.SelectedIndex = national_standard;
                cbbFrequency_Mode.SelectedIndex = fixed_or_hopping_freq;
                if (fixed_or_hopping_freq == 1) //定频
                {
                    cbbFixFrequency.SelectedIndex = frequency_point[0];
                    return;
                }
                switch (national_standard) //国家标准
                {
                    case 0://美标 USA band
                        if (fixed_or_hopping_freq == 0) //跳频
                        {
                            USA_bandHoppingFrequency(frequency_point, frequency_point_len);
                        }
                        break;
                    case 1: //欧标 EU band
                        if (fixed_or_hopping_freq == 0) //跳频
                        {
                            EU_bandHoppingFrequency(frequency_point, frequency_point_len);
                        }
                        break;
                    case 2: //韩标 Korean band
                        if (fixed_or_hopping_freq == 0) //跳频
                        {
                            Korean_bandHoppingFrequency(frequency_point, frequency_point_len);
                        }
                        break;
                    default:
                        break;
                }
                lblMessageHit.Text = rm.GetString("strMsgSucceedGetFreq");
            }
            catch
            {
                lblMessageHit.Text = rm.GetString("strMsgFailureGetFreq");
            }
        }

        private void USA_bandHoppingFrequency(byte[] frequency_point, byte frequency_point_len)
        {
            if (frequency_point_len != 50)
            {
                return;
            }
            // Group 1
            cbFp1.Checked = frequency_point[0] > 0 ? true : false;
            cbFp2.Checked = frequency_point[1] > 0 ? true : false;
            cbFp3.Checked = frequency_point[2] > 0 ? true : false;
            cbFp4.Checked = frequency_point[3] > 0 ? true : false;
            cbFp5.Checked = frequency_point[4] > 0 ? true : false;
            cbFp6.Checked = frequency_point[5] > 0 ? true : false;
            cbFp7.Checked = frequency_point[6] > 0 ? true : false;
            cbFp8.Checked = frequency_point[7] > 0 ? true : false;
            cbFp9.Checked = frequency_point[8] > 0 ? true : false;
            cbFp10.Checked = frequency_point[9] > 0 ? true : false;
            // Group 2
            cbFp11.Checked = frequency_point[10] > 0 ? true : false;
            cbFp12.Checked = frequency_point[11] > 0 ? true : false;
            cbFp13.Checked = frequency_point[12] > 0 ? true : false;
            cbFp14.Checked = frequency_point[13] > 0 ? true : false;
            cbFp15.Checked = frequency_point[14] > 0 ? true : false;
            cbFp16.Checked = frequency_point[15] > 0 ? true : false;
            cbFp17.Checked = frequency_point[16] > 0 ? true : false;
            cbFp18.Checked = frequency_point[17] > 0 ? true : false;
            cbFp19.Checked = frequency_point[18] > 0 ? true : false;
            cbFp20.Checked = frequency_point[19] > 0 ? true : false;
            // Group 3
            cbFp21.Checked = frequency_point[20] > 0 ? true : false;
            cbFp22.Checked = frequency_point[21] > 0 ? true : false;
            cbFp23.Checked = frequency_point[22] > 0 ? true : false;
            cbFp24.Checked = frequency_point[23] > 0 ? true : false;
            cbFp25.Checked = frequency_point[24] > 0 ? true : false;
            cbFp26.Checked = frequency_point[25] > 0 ? true : false;
            cbFp27.Checked = frequency_point[26] > 0 ? true : false;
            cbFp28.Checked = frequency_point[27] > 0 ? true : false;
            cbFp29.Checked = frequency_point[28] > 0 ? true : false;
            cbFp30.Checked = frequency_point[29] > 0 ? true : false;
            // Group 4
            cbFp31.Checked = frequency_point[30] > 0 ? true : false;
            cbFp32.Checked = frequency_point[31] > 0 ? true : false;
            cbFp33.Checked = frequency_point[32] > 0 ? true : false;
            cbFp34.Checked = frequency_point[33] > 0 ? true : false;
            cbFp35.Checked = frequency_point[34] > 0 ? true : false;
            cbFp36.Checked = frequency_point[35] > 0 ? true : false;
            cbFp37.Checked = frequency_point[36] > 0 ? true : false;
            cbFp38.Checked = frequency_point[37] > 0 ? true : false;
            cbFp39.Checked = frequency_point[38] > 0 ? true : false;
            cbFp40.Checked = frequency_point[39] > 0 ? true : false;
            // Group 5
            cbFp41.Checked = frequency_point[40] > 0 ? true : false;
            cbFp42.Checked = frequency_point[41] > 0 ? true : false;
            cbFp43.Checked = frequency_point[42] > 0 ? true : false;
            cbFp44.Checked = frequency_point[43] > 0 ? true : false;
            cbFp45.Checked = frequency_point[44] > 0 ? true : false;
            cbFp46.Checked = frequency_point[45] > 0 ? true : false;
            cbFp47.Checked = frequency_point[46] > 0 ? true : false;
            cbFp48.Checked = frequency_point[47] > 0 ? true : false;
            cbFp49.Checked = frequency_point[48] > 0 ? true : false;
            cbFp50.Checked = frequency_point[49] > 0 ? true : false;
        }
        
        private void cboBand_SelectedIndexChanged(object sender, EventArgs e)
        {
            int bandIndex = cbbFrequencyBand.SelectedIndex;
            int fixOrHopping = cbbFrequency_Mode.SelectedIndex;
            switch (bandIndex)
            {
                case -1:
                    break;
                case 0:  //美标
                    tbHoppingFrequency.SelectedIndex = 0;
                    if (fixOrHopping == 0) //跳频
                    {
                        tbHoppingFrequency.Visible = true;
                        cbbFixFrequency.Visible = false;
                    }
                    else if (fixOrHopping == 1)//定频
                    {
                        tbHoppingFrequency.Visible = false;
                        cbbFixFrequency.Visible = true;
                        ShowFixUSPoint(cbbFixFrequency);
                    }
                    break;
                case 1: //欧标
                    tbHoppingFrequency.SelectedIndex = 1;
                    if (fixOrHopping == 0) //跳频
                    {
                        tbHoppingFrequency.Visible = true;
                        cbbFixFrequency.Visible = false;
                    }
                    else if (fixOrHopping == 1)//定频
                    {
                        cbbFixFrequency.Visible = true;
                        tbHoppingFrequency.Visible = false;
                        ShowFreEU_FixPoint(cbbFixFrequency);
                    }
                    break;
                case 2: //韩标
                    tbHoppingFrequency.SelectedIndex = 2;
                    if (fixOrHopping == 0) //跳频
                    {
                        tbHoppingFrequency.Visible = true;
                        cbbFixFrequency.Visible = false;
                    }
                    else if (fixOrHopping == 1)//定频
                    {
                        cbbFixFrequency.Visible = true;
                        tbHoppingFrequency.Visible = false;
                        ShowFreqKoreaFixPoint(cbbFixFrequency);
                    }
                    break;
                default:
                    break;
            }
        }

        private void ShowFixUSPoint(ComboBox cbbFixFreq)
        {
            cbbFixFreq.Items.Clear();
            for (int i = 0; i < 50; ++i)
            {
                cbbFixFreq.Items.Add(string.Format("{0}-{1:F1}Mhz", i + 1, 902.5 + i * 0.5));
            }
        }

        private void ShowFreqKoreaFixPoint(ComboBox cbbFixFreq)
        {
            cbbFixFreq.Items.Clear();
            for (int i = 0; i < 32; ++i)
            {
                cbbFixFreq.Items.Add(string.Format("{0}-{1:F1}Mhz", i + 1, 917.1 + i * 0.2));
            }
        }

        private void ShowFreEU_FixPoint(ComboBox cbbFixFreq)
        {
            cbbFixFreq.Items.Clear();
            for (int i = 0; i < 5; ++i)
            {
                cbbFixFreq.Items.Add(string.Format("{0}-{1:F1}Mhz", i + 1, 865.5 + i * 0.5));
            }
        }

        /// <summary>
        ///  频率及其它参数默认参数
        ///  2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDefaultFreq_Click(object sender, EventArgs e)
        {
            cbbFrequencyBand.SelectedIndex = 0;
            tbNewDevNo.Text = "0";
            tbPower.Text = "150";
            cbbSingOrMulti.SelectedIndex = 0;
            cbbFrequency_Mode.SelectedIndex = 0;
            //cbbFreqMode.SelectedIndex = 0;
            //cbbFixFreqUS.SelectedIndex = 0;
            cbbEPCDataFormat.SelectedIndex = 0;

            hoppingFrequcyUSA_checkGroup1(false);
            hoppingFrequcyUSA_checkGroup2(false);
            hoppingFrequcyUSA_checkGroup3(false);
            hoppingFrequcyUSA_checkGroup4(false);
            hoppingFrequcyUSA_checkGroup5(false);

            cbFp1.Checked = true;
            cbFp11.Checked = true;
            cbFp21.Checked = true;
            cbFp31.Checked = true;
            cbFp41.Checked = true;
            cbFp50.Checked = true;
        }

        private void clearHoppingFrequency()
        {
            hoppingFrequcyUSA_checkGroup1(false);
            hoppingFrequcyUSA_checkGroup2(false);
            hoppingFrequcyUSA_checkGroup3(false);
            hoppingFrequcyUSA_checkGroup4(false);
            hoppingFrequcyUSA_checkGroup5(false);

            hoppingFrequcyEU_checkGroup1(false);
            hoppingFrequcyEU_checkGroup2(false);
        }

        /// <summary>
        ///  频率及其它参数清除频点
        ///  2015-11-9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearFreq_Click(object sender, EventArgs e)
        {
            clearHoppingFrequency();
        }

        private void tbHoppingFrequency_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbFrequencyBand.SelectedIndex = tbHoppingFrequency.SelectedIndex;
        }

        private void cbbFrequency_Mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboBand_SelectedIndexChanged(null, null);
        }

        /*******************************************美标 Start************************************************/
        #region 美标

        private void hoppingFrequcyUSA_checkGroup1(bool check)
        {
            cbFp1.Checked = check;
            cbFp2.Checked = check;
            cbFp3.Checked = check;
            cbFp4.Checked = check;
            cbFp5.Checked = check;
            cbFp6.Checked = check;
            cbFp7.Checked = check;
            cbFp8.Checked = check;
            cbFp9.Checked = check;
            cbFp10.Checked = check;
        }

        private void hoppingFrequcyUSA_checkGroup2(bool check)
        {
            cbFp11.Checked = check;
            cbFp12.Checked = check;
            cbFp13.Checked = check;
            cbFp14.Checked = check;
            cbFp15.Checked = check;
            cbFp16.Checked = check;
            cbFp17.Checked = check;
            cbFp18.Checked = check;
            cbFp19.Checked = check;
            cbFp20.Checked = check;
        }

        private void hoppingFrequcyUSA_checkGroup3(bool check)
        {
            cbFp21.Checked = check;
            cbFp22.Checked = check;
            cbFp23.Checked = check;
            cbFp24.Checked = check;
            cbFp25.Checked = check;
            cbFp26.Checked = check;
            cbFp27.Checked = check;
            cbFp28.Checked = check;
            cbFp29.Checked = check;
            cbFp30.Checked = check;
        }

        private void hoppingFrequcyUSA_checkGroup4(bool check)
        {
            cbFp31.Checked = check;
            cbFp32.Checked = check;
            cbFp33.Checked = check;
            cbFp34.Checked = check;
            cbFp35.Checked = check;
            cbFp36.Checked = check;
            cbFp37.Checked = check;
            cbFp38.Checked = check;
            cbFp39.Checked = check;
            cbFp40.Checked = check;
        }

        private void hoppingFrequcyUSA_checkGroup5(bool check)
        {
            cbFp41.Checked = check;
            cbFp42.Checked = check;
            cbFp43.Checked = check;
            cbFp44.Checked = check;
            cbFp45.Checked = check;
            cbFp46.Checked = check;
            cbFp47.Checked = check;
            cbFp48.Checked = check;
            cbFp49.Checked = check;
            cbFp50.Checked = check;
        }

        private void hoppingFreqCheckGroup1(bool check) {
            cbFp1.CheckedChanged -= new System.EventHandler(this.cbFp1_CheckedChanged);

            cbFp1.Checked = check;
            cbFp2.Checked = check;
            cbFp3.Checked = check;
            cbFp4.Checked = check;
            cbFp5.Checked = check;
            cbFp6.Checked = check;
            cbFp7.Checked = check;
            cbFp8.Checked = check;
            cbFp9.Checked = check;
            cbFp10.Checked = check;

            cbFp1.CheckedChanged += new System.EventHandler(this.cbFp1_CheckedChanged);
        }

        private void hoppingFreqCheckGroup2(bool check)
        {
            cbFp11.CheckedChanged -= new System.EventHandler(this.cbFp11_CheckedChanged);

            cbFp11.Checked = check;
            cbFp12.Checked = check;
            cbFp13.Checked = check;
            cbFp14.Checked = check;
            cbFp15.Checked = check;
            cbFp16.Checked = check;
            cbFp17.Checked = check;
            cbFp18.Checked = check;
            cbFp19.Checked = check;
            cbFp20.Checked = check;

            cbFp11.CheckedChanged += new System.EventHandler(this.cbFp11_CheckedChanged);
        }

        private void hoppingFreqCheckGroup3(bool check)
        {
            cbFp21.CheckedChanged -= new System.EventHandler(this.cbFp21_CheckedChanged);

            cbFp21.Checked = check;
            cbFp22.Checked = check;
            cbFp23.Checked = check;
            cbFp24.Checked = check;
            cbFp25.Checked = check;
            cbFp26.Checked = check;
            cbFp27.Checked = check;
            cbFp28.Checked = check;
            cbFp29.Checked = check;
            cbFp30.Checked = check;

            cbFp21.CheckedChanged += new System.EventHandler(this.cbFp21_CheckedChanged);
        }

        private void hoppingFreqCheckGroup4(bool check)
        {
            cbFp31.CheckedChanged -= new System.EventHandler(this.cbFp31_CheckedChanged);

            cbFp31.Checked = check;
            cbFp32.Checked = check;
            cbFp33.Checked = check;
            cbFp34.Checked = check;
            cbFp35.Checked = check;
            cbFp36.Checked = check;
            cbFp37.Checked = check;
            cbFp38.Checked = check;
            cbFp39.Checked = check;
            cbFp40.Checked = check;

            cbFp31.CheckedChanged += new System.EventHandler(this.cbFp31_CheckedChanged);
        }

        private void hoppingFreqCheckGroup5(bool check)
        {
            cbFp41.CheckedChanged -= new System.EventHandler(this.cbFp41_CheckedChanged);

            cbFp41.Checked = check;
            cbFp42.Checked = check;
            cbFp43.Checked = check;
            cbFp44.Checked = check;
            cbFp45.Checked = check;
            cbFp46.Checked = check;
            cbFp47.Checked = check;
            cbFp48.Checked = check;
            cbFp49.Checked = check;
            cbFp50.Checked = check;

            cbFp41.CheckedChanged += new System.EventHandler(this.cbFp41_CheckedChanged);
        }

        private void chkFreqUSAll1_CheckedChanged(object sender, EventArgs e)
        {
            hoppingFreqCheckGroup1(chkFreqUSAll1.Checked);
        }

        private void chkFreqUSAll2_CheckedChanged(object sender, EventArgs e)
        {
            hoppingFreqCheckGroup2(chkFreqUSAll2.Checked);
        }

        private void chkFreqUSAll3_CheckedChanged(object sender, EventArgs e)
        {
            hoppingFreqCheckGroup3(chkFreqUSAll3.Checked);
        }

        private void chkFreqUSAll4_CheckedChanged(object sender, EventArgs e)
        {
            hoppingFreqCheckGroup4(chkFreqUSAll4.Checked);
        }

        private void chkFreqUSAll5_CheckedChanged(object sender, EventArgs e)
        {
            hoppingFreqCheckGroup5(chkFreqUSAll5.Checked);
        }

        private void cbFp1_CheckedChanged(object sender, EventArgs e)
        {
           int count = cbFp1.Checked ? 1 : 0;
               count += cbFp2.Checked ? 1 : 0;
               count += cbFp3.Checked ? 1 : 0;
               count += cbFp4.Checked ? 1 : 0;
               count += cbFp5.Checked ? 1 : 0;
               count += cbFp6.Checked ? 1 : 0;
               count += cbFp7.Checked ? 1 : 0;
               count += cbFp8.Checked ? 1 : 0;
               count += cbFp9.Checked ? 1 : 0;
               count += cbFp10.Checked ? 1 : 0;

               chkFreqUSAll1.CheckedChanged -= new System.EventHandler(this.chkFreqUSAll1_CheckedChanged);
               if (count == 10)
               {
                   chkFreqUSAll1.Checked = true;
               }
               else 
               {
                   chkFreqUSAll1.Checked = false;
               }
               chkFreqUSAll1.CheckedChanged += new System.EventHandler(this.chkFreqUSAll1_CheckedChanged);
        }

        private void cbFp11_CheckedChanged(object sender, EventArgs e)
        {
            int count = cbFp11.Checked ? 1 : 0;
            count += cbFp12.Checked ? 1 : 0;
            count += cbFp13.Checked ? 1 : 0;
            count += cbFp14.Checked ? 1 : 0;
            count += cbFp15.Checked ? 1 : 0;
            count += cbFp16.Checked ? 1 : 0;
            count += cbFp17.Checked ? 1 : 0;
            count += cbFp18.Checked ? 1 : 0;
            count += cbFp19.Checked ? 1 : 0;
            count += cbFp20.Checked ? 1 : 0;

            chkFreqUSAll2.CheckedChanged -= new System.EventHandler(this.chkFreqUSAll2_CheckedChanged);
            if (count == 10)
            {
                chkFreqUSAll2.Checked = true;
            }
            else
            {
                chkFreqUSAll2.Checked = false;
            }
            chkFreqUSAll2.CheckedChanged += new System.EventHandler(this.chkFreqUSAll2_CheckedChanged);
        }

        private void cbFp21_CheckedChanged(object sender, EventArgs e)
        {
            int count = cbFp21.Checked ? 1 : 0;
            count += cbFp22.Checked ? 1 : 0;
            count += cbFp23.Checked ? 1 : 0;
            count += cbFp24.Checked ? 1 : 0;
            count += cbFp25.Checked ? 1 : 0;
            count += cbFp26.Checked ? 1 : 0;
            count += cbFp27.Checked ? 1 : 0;
            count += cbFp28.Checked ? 1 : 0;
            count += cbFp29.Checked ? 1 : 0;
            count += cbFp30.Checked ? 1 : 0;

            chkFreqUSAll3.CheckedChanged -= new System.EventHandler(this.chkFreqUSAll3_CheckedChanged);
            if (count == 10)
            {
                chkFreqUSAll3.Checked = true;
            }
            else
            {
                chkFreqUSAll3.Checked = false;
            }
            chkFreqUSAll3.CheckedChanged += new System.EventHandler(this.chkFreqUSAll3_CheckedChanged);
        }

        private void cbFp31_CheckedChanged(object sender, EventArgs e)
        {
            int count = cbFp31.Checked ? 1 : 0;
            count += cbFp32.Checked ? 1 : 0;
            count += cbFp33.Checked ? 1 : 0;
            count += cbFp34.Checked ? 1 : 0;
            count += cbFp35.Checked ? 1 : 0;
            count += cbFp36.Checked ? 1 : 0;
            count += cbFp37.Checked ? 1 : 0;
            count += cbFp38.Checked ? 1 : 0;
            count += cbFp39.Checked ? 1 : 0;
            count += cbFp40.Checked ? 1 : 0;

            chkFreqUSAll4.CheckedChanged -= new System.EventHandler(this.chkFreqUSAll4_CheckedChanged);
            if (count == 10)
            {
                chkFreqUSAll4.Checked = true;
            }
            else
            {
                chkFreqUSAll4.Checked = false;
            }
            chkFreqUSAll4.CheckedChanged += new System.EventHandler(this.chkFreqUSAll4_CheckedChanged);
        }

        private void cbFp41_CheckedChanged(object sender, EventArgs e)
        {
            int count = cbFp41.Checked ? 1 : 0;
            count += cbFp42.Checked ? 1 : 0;
            count += cbFp43.Checked ? 1 : 0;
            count += cbFp44.Checked ? 1 : 0;
            count += cbFp45.Checked ? 1 : 0;
            count += cbFp46.Checked ? 1 : 0;
            count += cbFp47.Checked ? 1 : 0;
            count += cbFp48.Checked ? 1 : 0;
            count += cbFp49.Checked ? 1 : 0;
            count += cbFp50.Checked ? 1 : 0;

            chkFreqUSAll5.CheckedChanged -= new System.EventHandler(this.chkFreqUSAll5_CheckedChanged);
            if (count == 10)
            {
                chkFreqUSAll5.Checked = true;
            }
            else
            {
                chkFreqUSAll5.Checked = false;
            }
            chkFreqUSAll5.CheckedChanged += new System.EventHandler(this.chkFreqUSAll5_CheckedChanged);
        }
        #endregion 美标
        /*******************************************美标 Start************************************************/

        /*******************************************欧标 Start************************************************/
        #region EU band

        private void hoppingFrequcyEU_checkGroup2(bool check)
        {
            chkFp7.Checked = check;
            chkFp8.Checked = check;
            chkFp9.Checked = check;
            chkFp10.Checked = check;
            chkFp11.Checked = check;
            chkFp12.Checked = check;
        }

        private void hoppingFrequcyEU_checkGroup1(bool check)
        {
            chkFp1.Checked = check;
            chkFp2.Checked = check;
            chkFp3.Checked = check;
            chkFp4.Checked = check;
            chkFp5.Checked = check;
            chkFp6.Checked = check;
        }

        private void hoppingFreqCheckEUGroup1(bool check)
        {
            chkFp1.CheckedChanged -= new System.EventHandler(this.chkFp1_CheckedChanged);

            chkFp1.Checked = check;
            chkFp2.Checked = check;
            chkFp3.Checked = check;
            chkFp4.Checked = check;
            chkFp5.Checked = check;
            chkFp6.Checked = check;

            chkFp1.CheckedChanged += new System.EventHandler(this.chkFp1_CheckedChanged);
        }

        private void hoppingFreqCheckEUGroup2(bool check)
        {
            chkFp7.CheckedChanged -= new System.EventHandler(this.chkFp7_CheckedChanged);

            chkFp7.Checked = check;
            chkFp8.Checked = check;
            chkFp9.Checked = check;
            chkFp10.Checked = check;
            chkFp11.Checked = check;
            chkFp12.Checked = check;

            chkFp7.CheckedChanged += new System.EventHandler(this.chkFp7_CheckedChanged);
        }

        private void chkFp7_CheckedChanged(object sender, EventArgs e)
        {
            int count = chkFp7.Checked ? 1 : 0;
            count += chkFp8.Checked ? 1 : 0;
            count += chkFp9.Checked ? 1 : 0;
            count += chkFp10.Checked ? 1 : 0;
            count += chkFp11.Checked ? 1 : 0;
            count += chkFp12.Checked ? 1 : 0;

            chkFreqEUAll2.CheckedChanged -= new System.EventHandler(this.chkFreqEUAll2_CheckedChanged);
            if (count == 6)
            {
                chkFreqEUAll2.Checked = true;
            }
            else
            {
                chkFreqEUAll2.Checked = false;
            }
            chkFreqEUAll2.CheckedChanged += new System.EventHandler(this.chkFreqEUAll2_CheckedChanged);
        }

        private void chkFreqEUAll1_CheckedChanged(object sender, EventArgs e)
        {
            hoppingFreqCheckEUGroup1(chkFreqEUAll1.Checked);
        }

        private void chkFreqEUAll2_CheckedChanged(object sender, EventArgs e)
        {
            hoppingFreqCheckEUGroup2(chkFreqEUAll2.Checked);
        }

        private void chkFp1_CheckedChanged(object sender, EventArgs e)
        {
            int count = chkFp1.Checked ? 1 : 0;
            count += chkFp2.Checked ? 1 : 0;
            count += chkFp3.Checked ? 1 : 0;
            count += chkFp4.Checked ? 1 : 0;
            count += chkFp5.Checked ? 1 : 0;
            count += chkFp6.Checked ? 1 : 0;

            chkFreqEUAll1.CheckedChanged -= new System.EventHandler(this.chkFreqEUAll1_CheckedChanged);
            if (count == 6)
            {
                chkFreqEUAll1.Checked = true;
            }
            else
            {
                chkFreqEUAll1.Checked = false;
            }
            chkFreqEUAll1.CheckedChanged += new System.EventHandler(this.chkFreqEUAll1_CheckedChanged);
        }
        #endregion EU band
        /*******************************************欧标 End************************************************/

        /*******************************************韩标 Start************************************************/
        #region Korean band
        private void hoppingFreqCheckKoreanGroup(bool check)
        {
            chkFreqKorean1.CheckedChanged -= new System.EventHandler(this.chkFreqKorean1_CheckedChanged);

            chkFreqKorean1.Checked = check;
            chkFreqKorean2.Checked = check;
            chkFreqKorean3.Checked = check;
            chkFreqKorean4.Checked = check;
            chkFreqKorean5.Checked = check;
            chkFreqKorean6.Checked = check;

            chkFreqKorean1.CheckedChanged += new System.EventHandler(this.chkFreqKorean1_CheckedChanged);
        }

        private void chkFreqKoreanAll_CheckedChanged(object sender, EventArgs e)
        {
             hoppingFreqCheckKoreanGroup(chkFreqKoreanAll.Checked);
        }

        private void chkFreqKorean1_CheckedChanged(object sender, EventArgs e)
        {
            int count = chkFreqKorean1.Checked ? 1 : 0;
            count += chkFreqKorean2.Checked ? 1 : 0;
            count += chkFreqKorean3.Checked ? 1 : 0;
            count += chkFreqKorean4.Checked ? 1 : 0;
            count += chkFreqKorean5.Checked ? 1 : 0;
            count += chkFreqKorean6.Checked ? 1 : 0;

            chkFreqKoreanAll.CheckedChanged -= new System.EventHandler(this.chkFreqKoreanAll_CheckedChanged);
            if (count == 6)
            {
                chkFreqKoreanAll.Checked = true;
            }
            else
            {
                chkFreqKoreanAll.Checked = false;
            }
            chkFreqKoreanAll.CheckedChanged += new System.EventHandler(this.chkFreqKoreanAll_CheckedChanged);
        }
        #endregion Korean band
        /*******************************************韩标 End************************************************/
        #endregion 频率选取

        #region 初始化控件
        private void InitalContrl()
        {
            try
            {
                BasicOperations();//基本操作
                TagOperations();//标签读写
                CommunicationParameterSetting();//通信参数设置
                ReaderParameterSetting();//读写器参数设置
                OtherOperation();
            }
            catch (Exception e)
            {
                lblMessageHit.Text = "InitalContrl" +  e.Message;
            }
        }

        /// <summary>
        /// 基本操作
        /// </summary>
        private void BasicOperations()
        {
            try
            {
                tbTCPClientPort.Text = "4196";
                tbTCPServerPort.Text = "4196";
                cbbLangSwitch.Items.Clear(); 
                cbbLangSwitch.Items.Add("简体中文");
                cbbLangSwitch.Items.Add("English");
                cbbLangSwitch.SelectedIndex = 0; // 默认中文
                rbAsc.Checked = true;
                BasicOperation.InitalConnectType(cbbSerialPort, cbbBaudRate);
                BasicOperation.InitTableInfoColumns(listView);
                tabControl.SelectedIndex = 0;
                cbbLangSwitch_SelectedIndexChanged(null, null);
            }
            catch (Exception e)
            {
                lblMessageHit.Text = "BasicOperations " + e.Message;
            }
        }

        /// <summary>
        ///  标签读写
        /// </summary>
        private void TagOperations()
        {
            try
            {
                cbbDataArea.SelectedIndex = 0;
                //cbbRWBank.SelectedIndex = 1;
                TagOperation.InitAccessTagControl(cbbRWBank, cbbLockBank);
            }
            catch (Exception e)
            {
                lblMessageHit.Text = "TagOperations " + e.Message;
            }
        }

        /// <summary>
        /// 通信参数设置
        /// </summary>
        private void CommunicationParameterSetting()
        {
            // 初始化各个页面控件
            InitCommParamControl();
        }

        /// <summary>
        /// 读写器参数设置
        /// </summary>
        private void ReaderParameterSetting()
        {
            try
            {
                cbbFrequency_Mode.SelectedIndex = 0;
                // 韦根取位值
                cbbWiegandProtocol.Items.Clear();
                cbbWiegandProtocol.Items.Add("Wiegand26");
                cbbWiegandProtocol.Items.Add("Wiegand34");
                cbbWiegandProtocol.Items.Add("Wiegand32");
                cbbWiegandProtocol.Items.Add("Wiegand66");
                for (int i = 0; i < 62; i++)
                {
                    cbbWigginsTakePlaceValue.Items.Add(i);
                }
                tbWorkMode.SelectedIndex = 1;
                tbCommMode.SelectedIndex = 0;
                cbbFrequencyBand.SelectedIndex = 0;
                cbbReadSpeed.SelectedIndex = 1;
            }
            catch (Exception e)
            {
                lblMessageHit.Text = "ReaderParameterSetting " + e.Message;
            }
        }

        /// <summary>
        /// 其它操作
        /// </summary>
        private void OtherOperation()
        {
            try
            {
                cbbBeepControl.SelectedIndex = 0;
                cbbUsbFormat.SelectedIndex = 4;
                cbbSingOrMulti.SelectedIndex = 0;
            }
            catch (Exception e)
            {
                lblMessageHit.Text = "OtherOperation " + e.Message;
            }
        }
        #endregion 初始化控件

        private void cbSaveFile_CheckedChanged(object sender, EventArgs e)
        {
            lock(hashMap){
                export(Tag_data);
            }
        }
    }

    // 解决插入数据表格闪烁的问题
    public class ListViewNF : System.Windows.Forms.ListView
    {
        public ListViewNF()
        {
            // 开启双缓冲
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            // Enable the OnNotifyMessage event so we get a chance to filter out 
            // Windows messages before they get to the form's WndProc
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);
        }

        protected override void OnNotifyMessage(Message m)
        {
            //Filter out the WM_ERASEBKGND message
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }
    }
}

