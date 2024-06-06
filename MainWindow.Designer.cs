using DisDemo;
namespace DisDemo
{
    partial class MainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Serial Port");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("TCP Client");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("TCP Server");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("On Line", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.cbbLangSwitch = new System.Windows.Forms.ComboBox();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.TagTID = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.panel16 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.OtherOpreation = new System.Windows.Forms.TabPage();
            this.gbSerialNumber = new System.Windows.Forms.GroupBox();
            this.btnSetSerialNumber = new System.Windows.Forms.Button();
            this.btnReadSerialNumber = new System.Windows.Forms.Button();
            this.tbSerialNumber = new System.Windows.Forms.TextBox();
            this.gbDevNo = new System.Windows.Forms.GroupBox();
            this.btnSetDeviceId = new System.Windows.Forms.Button();
            this.btnReadDeviceId = new System.Windows.Forms.Button();
            this.tbNewDevNo = new System.Windows.Forms.TextBox();
            this.gbSingleOrMulti = new System.Windows.Forms.GroupBox();
            this.btnSetReadMode = new System.Windows.Forms.Button();
            this.btnGetReadMode = new System.Windows.Forms.Button();
            this.cbbSingOrMulti = new System.Windows.Forms.ComboBox();
            this.gbPower = new System.Windows.Forms.GroupBox();
            this.btnSetPower = new System.Windows.Forms.Button();
            this.btnReadPower = new System.Windows.Forms.Button();
            this.tbPower = new System.Windows.Forms.TextBox();
            this.gbDataOutputFormat = new System.Windows.Forms.GroupBox();
            this.gbUsbFormat = new System.Windows.Forms.GroupBox();
            this.btnReadUsbFormat = new System.Windows.Forms.Button();
            this.btnSetUsbFormat = new System.Windows.Forms.Button();
            this.cbbUsbFormat = new System.Windows.Forms.ComboBox();
            this.gbNotDoubleUSBDevice = new System.Windows.Forms.GroupBox();
            this.btnSetEPCDataFormat = new System.Windows.Forms.Button();
            this.cbbEPCDataFormat = new System.Windows.Forms.ComboBox();
            this.EpcFormatLB = new System.Windows.Forms.Label();
            this.btnReadEPCDataFormat = new System.Windows.Forms.Button();
            this.GopRelayControl = new System.Windows.Forms.GroupBox();
            this.tbRelayMode = new System.Windows.Forms.TabControl();
            this.tpInitiative = new System.Windows.Forms.TabPage();
            this.lblCloseTime = new System.Windows.Forms.Label();
            this.cbbRelayTime = new System.Windows.Forms.ComboBox();
            this.tpPassivity = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdoOpen2 = new System.Windows.Forms.RadioButton();
            this.rdoClose2 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoClose1 = new System.Windows.Forms.RadioButton();
            this.rdoOpen1 = new System.Windows.Forms.RadioButton();
            this.btnSetRelayTime = new System.Windows.Forms.Button();
            this.gbTagAuth = new System.Windows.Forms.GroupBox();
            this.btnQueryAuthorization = new System.Windows.Forms.Button();
            this.btnAutoAuthorization = new System.Windows.Forms.Button();
            this.labNewAuthPwd = new System.Windows.Forms.Label();
            this.labAuthPwd = new System.Windows.Forms.Label();
            this.tbNewAuthPwd = new System.Windows.Forms.TextBox();
            this.tbAuthPwd = new System.Windows.Forms.TextBox();
            this.btnTagAuth = new System.Windows.Forms.Button();
            this.btnModifyAuthPwd = new System.Windows.Forms.Button();
            this.grpAntSet = new System.Windows.Forms.GroupBox();
            this.chkAnt8 = new System.Windows.Forms.CheckBox();
            this.chkAnt7 = new System.Windows.Forms.CheckBox();
            this.chkAnt6 = new System.Windows.Forms.CheckBox();
            this.chkAnt5 = new System.Windows.Forms.CheckBox();
            this.chkAnt4 = new System.Windows.Forms.CheckBox();
            this.chkAnt3 = new System.Windows.Forms.CheckBox();
            this.chkAnt2 = new System.Windows.Forms.CheckBox();
            this.chkAnt1 = new System.Windows.Forms.CheckBox();
            this.btnAntSet = new System.Windows.Forms.Button();
            this.btnAntRead = new System.Windows.Forms.Button();
            this.gbBeepControl = new System.Windows.Forms.GroupBox();
            this.btnReadDataArea = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSetDataArea = new System.Windows.Forms.Button();
            this.cbbDataArea = new System.Windows.Forms.ComboBox();
            this.lblReadVoice = new System.Windows.Forms.Label();
            this.btnReadBeep = new System.Windows.Forms.Button();
            this.btnSetBeep = new System.Windows.Forms.Button();
            this.cbbBeepControl = new System.Windows.Forms.ComboBox();
            this.SetReaderParam = new System.Windows.Forms.TabPage();
            this.gbFreq = new System.Windows.Forms.GroupBox();
            this.cbbFixFrequency = new System.Windows.Forms.ComboBox();
            this.cbbFrequency_Mode = new System.Windows.Forms.ComboBox();
            this.lblFrequencyArea = new System.Windows.Forms.Label();
            this.tbHoppingFrequency = new System.Windows.Forms.TabControl();
            this.tpUSA_Band = new System.Windows.Forms.TabPage();
            this.chkFreqUSAll5 = new System.Windows.Forms.CheckBox();
            this.chkFreqUSAll4 = new System.Windows.Forms.CheckBox();
            this.chkFreqUSAll3 = new System.Windows.Forms.CheckBox();
            this.chkFreqUSAll2 = new System.Windows.Forms.CheckBox();
            this.chkFreqUSAll1 = new System.Windows.Forms.CheckBox();
            this.cbFp50 = new System.Windows.Forms.CheckBox();
            this.cbFp24 = new System.Windows.Forms.CheckBox();
            this.cbFp49 = new System.Windows.Forms.CheckBox();
            this.cbFp25 = new System.Windows.Forms.CheckBox();
            this.cbFp23 = new System.Windows.Forms.CheckBox();
            this.cbFp48 = new System.Windows.Forms.CheckBox();
            this.cbFp26 = new System.Windows.Forms.CheckBox();
            this.cbFp22 = new System.Windows.Forms.CheckBox();
            this.cbFp47 = new System.Windows.Forms.CheckBox();
            this.cbFp27 = new System.Windows.Forms.CheckBox();
            this.cbFp1 = new System.Windows.Forms.CheckBox();
            this.cbFp21 = new System.Windows.Forms.CheckBox();
            this.cbFp46 = new System.Windows.Forms.CheckBox();
            this.cbFp28 = new System.Windows.Forms.CheckBox();
            this.cbFp2 = new System.Windows.Forms.CheckBox();
            this.cbFp20 = new System.Windows.Forms.CheckBox();
            this.cbFp45 = new System.Windows.Forms.CheckBox();
            this.cbFp29 = new System.Windows.Forms.CheckBox();
            this.cbFp3 = new System.Windows.Forms.CheckBox();
            this.cbFp19 = new System.Windows.Forms.CheckBox();
            this.cbFp44 = new System.Windows.Forms.CheckBox();
            this.cbFp30 = new System.Windows.Forms.CheckBox();
            this.cbFp4 = new System.Windows.Forms.CheckBox();
            this.cbFp18 = new System.Windows.Forms.CheckBox();
            this.cbFp43 = new System.Windows.Forms.CheckBox();
            this.cbFp31 = new System.Windows.Forms.CheckBox();
            this.cbFp5 = new System.Windows.Forms.CheckBox();
            this.cbFp17 = new System.Windows.Forms.CheckBox();
            this.cbFp42 = new System.Windows.Forms.CheckBox();
            this.cbFp32 = new System.Windows.Forms.CheckBox();
            this.cbFp6 = new System.Windows.Forms.CheckBox();
            this.cbFp16 = new System.Windows.Forms.CheckBox();
            this.cbFp41 = new System.Windows.Forms.CheckBox();
            this.cbFp33 = new System.Windows.Forms.CheckBox();
            this.cbFp7 = new System.Windows.Forms.CheckBox();
            this.cbFp15 = new System.Windows.Forms.CheckBox();
            this.cbFp8 = new System.Windows.Forms.CheckBox();
            this.cbFp34 = new System.Windows.Forms.CheckBox();
            this.cbFp40 = new System.Windows.Forms.CheckBox();
            this.cbFp14 = new System.Windows.Forms.CheckBox();
            this.cbFp9 = new System.Windows.Forms.CheckBox();
            this.cbFp35 = new System.Windows.Forms.CheckBox();
            this.cbFp39 = new System.Windows.Forms.CheckBox();
            this.cbFp13 = new System.Windows.Forms.CheckBox();
            this.cbFp10 = new System.Windows.Forms.CheckBox();
            this.cbFp36 = new System.Windows.Forms.CheckBox();
            this.cbFp38 = new System.Windows.Forms.CheckBox();
            this.cbFp12 = new System.Windows.Forms.CheckBox();
            this.cbFp11 = new System.Windows.Forms.CheckBox();
            this.cbFp37 = new System.Windows.Forms.CheckBox();
            this.tpEU_Band = new System.Windows.Forms.TabPage();
            this.chkFreqEUAll2 = new System.Windows.Forms.CheckBox();
            this.chkFreqEUAll1 = new System.Windows.Forms.CheckBox();
            this.chkFp12 = new System.Windows.Forms.CheckBox();
            this.chkFp11 = new System.Windows.Forms.CheckBox();
            this.chkFp1 = new System.Windows.Forms.CheckBox();
            this.chkFp8 = new System.Windows.Forms.CheckBox();
            this.chkFp2 = new System.Windows.Forms.CheckBox();
            this.chkFp10 = new System.Windows.Forms.CheckBox();
            this.chkFp4 = new System.Windows.Forms.CheckBox();
            this.chkFp9 = new System.Windows.Forms.CheckBox();
            this.chkFp5 = new System.Windows.Forms.CheckBox();
            this.chkFp7 = new System.Windows.Forms.CheckBox();
            this.chkFp3 = new System.Windows.Forms.CheckBox();
            this.chkFp6 = new System.Windows.Forms.CheckBox();
            this.tpKorea_Band = new System.Windows.Forms.TabPage();
            this.chkFreqKoreanAll = new System.Windows.Forms.CheckBox();
            this.chkFreqKorean1 = new System.Windows.Forms.CheckBox();
            this.chkFreqKorean2 = new System.Windows.Forms.CheckBox();
            this.chkFreqKorean4 = new System.Windows.Forms.CheckBox();
            this.chkFreqKorean5 = new System.Windows.Forms.CheckBox();
            this.chkFreqKorean3 = new System.Windows.Forms.CheckBox();
            this.chkFreqKorean6 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnClearFreq = new System.Windows.Forms.Button();
            this.btnDefaultFreq = new System.Windows.Forms.Button();
            this.btnReadFreq = new System.Windows.Forms.Button();
            this.labFreq = new System.Windows.Forms.Label();
            this.cbbFrequencyBand = new System.Windows.Forms.ComboBox();
            this.labSetParam = new System.Windows.Forms.Label();
            this.btnSetFreq = new System.Windows.Forms.Button();
            this.gbCommModeParam = new System.Windows.Forms.GroupBox();
            this.tbCommMode = new System.Windows.Forms.TabControl();
            this.tpRS485_RJ45 = new System.Windows.Forms.TabPage();
            this.tpWiegand = new System.Windows.Forms.TabPage();
            this.labPulseWidthUnit = new System.Windows.Forms.Label();
            this.labPulseWidth = new System.Windows.Forms.Label();
            this.labPulseCycleUnit = new System.Windows.Forms.Label();
            this.lblWigginsTakePlaceValue = new System.Windows.Forms.Label();
            this.tbPulseWidth = new System.Windows.Forms.TextBox();
            this.cbbWigginsTakePlaceValue = new System.Windows.Forms.ComboBox();
            this.labWiegandProtocol = new System.Windows.Forms.Label();
            this.tbPulseCycle = new System.Windows.Forms.TextBox();
            this.labPulseCycle = new System.Windows.Forms.Label();
            this.cbbWiegandProtocol = new System.Windows.Forms.ComboBox();
            this.tpSerialPorts = new System.Windows.Forms.TabPage();
            this.cbbBaud_Rate = new System.Windows.Forms.ComboBox();
            this.lbl_rate = new System.Windows.Forms.Label();
            this.btnDefaultCommMode = new System.Windows.Forms.Button();
            this.btnReadCommMode = new System.Windows.Forms.Button();
            this.btnSetCommMode = new System.Windows.Forms.Button();
            this.gbWorkMode = new System.Windows.Forms.GroupBox();
            this.tbWorkMode = new System.Windows.Forms.TabControl();
            this.tpMaster = new System.Windows.Forms.TabPage();
            this.tpTiming = new System.Windows.Forms.TabPage();
            this.cbbReadSpeed = new System.Windows.Forms.ComboBox();
            this.labTimingUnit = new System.Windows.Forms.Label();
            this.labTimingParam = new System.Windows.Forms.Label();
            this.tbTiming = new System.Windows.Forms.TextBox();
            this.tpTrigger = new System.Windows.Forms.TabPage();
            this.labDelayUnit = new System.Windows.Forms.Label();
            this.labTrigParam = new System.Windows.Forms.Label();
            this.tbDelay = new System.Windows.Forms.TextBox();
            this.cbbTrigSwitch = new System.Windows.Forms.ComboBox();
            this.labTrigSwitch = new System.Windows.Forms.Label();
            this.chkAjaDisc = new System.Windows.Forms.CheckBox();
            this.btnDefaultWorkMode = new System.Windows.Forms.Button();
            this.btnReadWorkMode = new System.Windows.Forms.Button();
            this.btnSetWorkMode = new System.Windows.Forms.Button();
            this.tbNeighJudge = new System.Windows.Forms.TextBox();
            this.SetCommParam = new System.Windows.Forms.TabPage();
            this.gbSPParams = new System.Windows.Forms.GroupBox();
            this.labDataBits = new System.Windows.Forms.Label();
            this.labCheckBits = new System.Windows.Forms.Label();
            this.labBaudRate = new System.Windows.Forms.Label();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.comboBoxCheckBits = new System.Windows.Forms.ComboBox();
            this.comboBoxDataBits = new System.Windows.Forms.ComboBox();
            this.gbNetParams = new System.Windows.Forms.GroupBox();
            this.cbbDestIP = new System.Windows.Forms.ComboBox();
            this.labPromotion = new System.Windows.Forms.Label();
            this.labDestPort = new System.Windows.Forms.Label();
            this.labDestIP = new System.Windows.Forms.Label();
            this.labGateway = new System.Windows.Forms.Label();
            this.labPort = new System.Windows.Forms.Label();
            this.labMask = new System.Windows.Forms.Label();
            this.labIPAdd = new System.Windows.Forms.Label();
            this.labIPMode = new System.Windows.Forms.Label();
            this.labNetMode = new System.Windows.Forms.Label();
            this.textBoxDestPort = new System.Windows.Forms.TextBox();
            this.tbDestIP = new System.Windows.Forms.TextBox();
            this.textBoxGateway = new System.Windows.Forms.TextBox();
            this.textBoxPortNo = new System.Windows.Forms.TextBox();
            this.textBoxNetMask = new System.Windows.Forms.TextBox();
            this.textBoxIPAdd = new System.Windows.Forms.TextBox();
            this.comboBoxIPMode = new System.Windows.Forms.ComboBox();
            this.comboBoxNetMode = new System.Windows.Forms.ComboBox();
            this.btnSetParams = new System.Windows.Forms.Button();
            this.btnDefaultParams = new System.Windows.Forms.Button();
            this.btnModifyDev = new System.Windows.Forms.Button();
            this.btnSearchDev = new System.Windows.Forms.Button();
            this.lvZl = new System.Windows.Forms.ListView();
            this.columnHeaderNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderIPAdd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMAC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TagAccess = new System.Windows.Forms.TabPage();
            this.gbKillTag = new System.Windows.Forms.GroupBox();
            this.tbKillKillPwd = new System.Windows.Forms.TextBox();
            this.btnKillTag = new System.Windows.Forms.Button();
            this.labDestroyPwd = new System.Windows.Forms.Label();
            this.gbTagInitialize = new System.Windows.Forms.GroupBox();
            this.btnInitTag = new System.Windows.Forms.Button();
            this.gbTagLockAndUnlock = new System.Windows.Forms.GroupBox();
            this.labLockBank = new System.Windows.Forms.Label();
            this.btnUnlockTag = new System.Windows.Forms.Button();
            this.cbbLockBank = new System.Windows.Forms.ComboBox();
            this.btnLockTag = new System.Windows.Forms.Button();
            this.labLockAccessPwd = new System.Windows.Forms.Label();
            this.tbLockAccessPwd = new System.Windows.Forms.TextBox();
            this.gbFastWrite = new System.Windows.Forms.GroupBox();
            this.btnReadFastTag = new System.Windows.Forms.Button();
            this.chkZD = new System.Windows.Forms.CheckBox();
            this.labFWPromo = new System.Windows.Forms.Label();
            this.btnClearFWData = new System.Windows.Forms.Button();
            this.btnFastWrite = new System.Windows.Forms.Button();
            this.labFWData = new System.Windows.Forms.Label();
            this.tbFWData = new System.Windows.Forms.TextBox();
            this.gbRWData = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rbAnt1 = new System.Windows.Forms.RadioButton();
            this.rbAnt2 = new System.Windows.Forms.RadioButton();
            this.rbAnt3 = new System.Windows.Forms.RadioButton();
            this.rbAnt8 = new System.Windows.Forms.RadioButton();
            this.rbAnt4 = new System.Windows.Forms.RadioButton();
            this.rbAnt7 = new System.Windows.Forms.RadioButton();
            this.rbAnt5 = new System.Windows.Forms.RadioButton();
            this.rbAnt6 = new System.Windows.Forms.RadioButton();
            this.chkDesignatedAntWrite = new System.Windows.Forms.CheckBox();
            this.chkDesignatedAntRead = new System.Windows.Forms.CheckBox();
            this.btnWeigandConvert = new System.Windows.Forms.Button();
            this.rbWeigand26_3_0 = new System.Windows.Forms.RadioButton();
            this.rbWeigand26_1_2 = new System.Windows.Forms.RadioButton();
            this.wiegandTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdvancedAccess = new System.Windows.Forms.Button();
            this.btn_stoptimer = new System.Windows.Forms.Button();
            this.btn_connRead = new System.Windows.Forms.Button();
            this.labData = new System.Windows.Forms.Label();
            this.labLength = new System.Windows.Forms.Label();
            this.labStartAdd = new System.Windows.Forms.Label();
            this.labOprBank = new System.Windows.Forms.Label();
            this.btnWriteData = new System.Windows.Forms.Button();
            this.btnClearData = new System.Windows.Forms.Button();
            this.btnReadData = new System.Windows.Forms.Button();
            this.tbRWData = new System.Windows.Forms.TextBox();
            this.cbbLength = new System.Windows.Forms.ComboBox();
            this.cbbStartAdd = new System.Windows.Forms.ComboBox();
            this.cbbRWBank = new System.Windows.Forms.ComboBox();
            this.General = new System.Windows.Forms.TabPage();
            this.btnReadOnce = new System.Windows.Forms.Button();
            this.btnStartReadData = new System.Windows.Forms.Button();
            this.btnStopReadData = new System.Windows.Forms.Button();
            this.cbSaveFile = new System.Windows.Forms.CheckBox();
            this.btnClearListView = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblTagCount = new System.Windows.Forms.Label();
            this.labReadCount = new System.Windows.Forms.Label();
            this.labTagCount = new System.Windows.Forms.Label();
            this.rbDesc = new System.Windows.Forms.RadioButton();
            this.rbAsc = new System.Windows.Forms.RadioButton();
            this.labelVersion = new System.Windows.Forms.Label();

            //this.listView = new ListViewContrl.DoubleBufferListView();
            this.listView = new System.Windows.Forms.ListView();

            this.tabControl = new System.Windows.Forms.TabControl();
            this.gbVersionInfo = new System.Windows.Forms.GroupBox();
            this.btnBrushVersion = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnReadVersion = new System.Windows.Forms.Button();
            this.gbConnectType = new System.Windows.Forms.GroupBox();
            this.tbConnect = new System.Windows.Forms.TabControl();
            this.tpSerialPort = new System.Windows.Forms.TabPage();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.cbbBaudRate = new System.Windows.Forms.ComboBox();
            this.lblSerialPort = new System.Windows.Forms.Label();
            this.cbbSerialPort = new System.Windows.Forms.ComboBox();
            this.btnUpdateSerialPort = new System.Windows.Forms.Button();
            this.btnSerialPortDisconnect = new System.Windows.Forms.Button();
            this.btnSerialPortConnect = new System.Windows.Forms.Button();
            this.tpTCPClient = new System.Windows.Forms.TabPage();
            this.btnUpdateTCPClient = new System.Windows.Forms.Button();
            this.tbTCPClientPort = new System.Windows.Forms.TextBox();
            this.lblTCPClientPort = new System.Windows.Forms.Label();
            this.lblTCPClientIP = new System.Windows.Forms.Label();
            this.cbbTCPClientIP = new System.Windows.Forms.ComboBox();
            this.btnTCPClientDisconnect = new System.Windows.Forms.Button();
            this.btnTCPClientConnect = new System.Windows.Forms.Button();
            this.tpTCPServer = new System.Windows.Forms.TabPage();
            this.tbTCPServerPort = new System.Windows.Forms.TextBox();
            this.lblTCPServerPort = new System.Windows.Forms.Label();
            this.lblTCPServerIP = new System.Windows.Forms.Label();
            this.btnUpdateTCPServer = new System.Windows.Forms.Button();
            this.cbbTCPServerIP = new System.Windows.Forms.ComboBox();
            this.btnStopMonitor = new System.Windows.Forms.Button();
            this.btnStartMonitor = new System.Windows.Forms.Button();
            this.tvConnectList = new System.Windows.Forms.TreeView();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMessageHit = new System.Windows.Forms.Label();
            this.lblInfoShow = new System.Windows.Forms.Label();
            this.timerConnRead = new System.Windows.Forms.Timer(this.components);
            this.cmsMenu.SuspendLayout();
            this.OtherOpreation.SuspendLayout();
            this.gbSerialNumber.SuspendLayout();
            this.gbDevNo.SuspendLayout();
            this.gbSingleOrMulti.SuspendLayout();
            this.gbPower.SuspendLayout();
            this.gbDataOutputFormat.SuspendLayout();
            this.gbUsbFormat.SuspendLayout();
            this.gbNotDoubleUSBDevice.SuspendLayout();
            this.GopRelayControl.SuspendLayout();
            this.tbRelayMode.SuspendLayout();
            this.tpInitiative.SuspendLayout();
            this.tpPassivity.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbTagAuth.SuspendLayout();
            this.grpAntSet.SuspendLayout();
            this.gbBeepControl.SuspendLayout();
            this.SetReaderParam.SuspendLayout();
            this.gbFreq.SuspendLayout();
            this.tbHoppingFrequency.SuspendLayout();
            this.tpUSA_Band.SuspendLayout();
            this.tpEU_Band.SuspendLayout();
            this.tpKorea_Band.SuspendLayout();
            this.gbCommModeParam.SuspendLayout();
            this.tbCommMode.SuspendLayout();
            this.tpWiegand.SuspendLayout();
            this.tpSerialPorts.SuspendLayout();
            this.gbWorkMode.SuspendLayout();
            this.tbWorkMode.SuspendLayout();
            this.tpTiming.SuspendLayout();
            this.tpTrigger.SuspendLayout();
            this.SetCommParam.SuspendLayout();
            this.gbSPParams.SuspendLayout();
            this.gbNetParams.SuspendLayout();
            this.TagAccess.SuspendLayout();
            this.gbKillTag.SuspendLayout();
            this.gbTagInitialize.SuspendLayout();
            this.gbTagLockAndUnlock.SuspendLayout();
            this.gbFastWrite.SuspendLayout();
            this.gbRWData.SuspendLayout();
            this.panel4.SuspendLayout();
            this.General.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.gbVersionInfo.SuspendLayout();
            this.gbConnectType.SuspendLayout();
            this.tbConnect.SuspendLayout();
            this.tpSerialPort.SuspendLayout();
            this.tpTCPClient.SuspendLayout();
            this.tpTCPServer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsMenu
            // 
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSave});
            this.cmsMenu.Name = "contextMenuStrip1";
            this.cmsMenu.Size = new System.Drawing.Size(101, 26);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(100, 22);
            this.tsmiSave.Text = "保存";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // cbbLangSwitch
            // 
            this.cbbLangSwitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLangSwitch.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbLangSwitch.FormattingEnabled = true;
            this.cbbLangSwitch.Items.AddRange(new object[] {
            "简体中文",
            "English"});
            this.cbbLangSwitch.Location = new System.Drawing.Point(143, 12);
            this.cbbLangSwitch.Name = "cbbLangSwitch";
            this.cbbLangSwitch.Size = new System.Drawing.Size(105, 24);
            this.cbbLangSwitch.TabIndex = 1;
            this.cbbLangSwitch.SelectedIndexChanged += new System.EventHandler(this.cbbLangSwitch_SelectedIndexChanged);
            // 
            // panel15
            // 
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(4, 86);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(78, 34);
            this.panel15.TabIndex = 10;
            // 
            // label14
            // 
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(0, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 34);
            this.label14.TabIndex = 2;
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(4, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(78, 34);
            this.panel5.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 34);
            this.label4.TabIndex = 0;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(89, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(330, 34);
            this.panel6.TabIndex = 1;
            // 
            // TagTID
            // 
            this.TagTID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TagTID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TagTID.Location = new System.Drawing.Point(0, 0);
            this.TagTID.Name = "TagTID";
            this.TagTID.Size = new System.Drawing.Size(330, 34);
            this.TagTID.TabIndex = 1;
            this.TagTID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(4, 45);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(78, 34);
            this.panel7.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 34);
            this.label7.TabIndex = 1;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(89, 45);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(330, 34);
            this.panel8.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(330, 34);
            this.label6.TabIndex = 1;
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(4, 127);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(78, 271);
            this.panel9.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 271);
            this.label9.TabIndex = 1;
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(89, 127);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(330, 271);
            this.panel10.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(330, 271);
            this.label10.TabIndex = 1;
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel13
            // 
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(4, 405);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(78, 34);
            this.panel13.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 34);
            this.label13.TabIndex = 1;
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel14
            // 
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(89, 405);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(330, 34);
            this.panel14.TabIndex = 9;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(124, 1);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 30);
            this.button6.TabIndex = 0;
            this.button6.Text = "查询";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // panel16
            // 
            this.panel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel16.Location = new System.Drawing.Point(89, 86);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(330, 34);
            this.panel16.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(0, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(330, 34);
            this.label15.TabIndex = 2;
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OtherOpreation
            // 
            this.OtherOpreation.Controls.Add(this.gbSerialNumber);
            this.OtherOpreation.Controls.Add(this.gbDevNo);
            this.OtherOpreation.Controls.Add(this.gbSingleOrMulti);
            this.OtherOpreation.Controls.Add(this.gbPower);
            this.OtherOpreation.Controls.Add(this.gbDataOutputFormat);
            this.OtherOpreation.Controls.Add(this.GopRelayControl);
            this.OtherOpreation.Controls.Add(this.gbTagAuth);
            this.OtherOpreation.Controls.Add(this.grpAntSet);
            this.OtherOpreation.Controls.Add(this.gbBeepControl);
            this.OtherOpreation.Location = new System.Drawing.Point(4, 22);
            this.OtherOpreation.Name = "OtherOpreation";
            this.OtherOpreation.Padding = new System.Windows.Forms.Padding(3);
            this.OtherOpreation.Size = new System.Drawing.Size(757, 546);
            this.OtherOpreation.TabIndex = 4;
            this.OtherOpreation.Text = "其它操作";
            this.OtherOpreation.UseVisualStyleBackColor = true;
            this.OtherOpreation.Enter += new System.EventHandler(this.OtherOpreation_Enter_Fun);
            // 
            // gbSerialNumber
            // 
            this.gbSerialNumber.Controls.Add(this.btnSetSerialNumber);
            this.gbSerialNumber.Controls.Add(this.btnReadSerialNumber);
            this.gbSerialNumber.Controls.Add(this.tbSerialNumber);
            this.gbSerialNumber.Location = new System.Drawing.Point(422, 460);
            this.gbSerialNumber.Name = "gbSerialNumber";
            this.gbSerialNumber.Size = new System.Drawing.Size(331, 58);
            this.gbSerialNumber.TabIndex = 101;
            this.gbSerialNumber.TabStop = false;
            this.gbSerialNumber.Text = "读写器序列号";
            // 
            // btnSetSerialNumber
            // 
            this.btnSetSerialNumber.Location = new System.Drawing.Point(213, 20);
            this.btnSetSerialNumber.Name = "btnSetSerialNumber";
            this.btnSetSerialNumber.Size = new System.Drawing.Size(60, 30);
            this.btnSetSerialNumber.TabIndex = 40;
            this.btnSetSerialNumber.Text = "设置";
            this.btnSetSerialNumber.UseVisualStyleBackColor = true;
            this.btnSetSerialNumber.Click += new System.EventHandler(this.btnSetSerialNumber_Click);
            // 
            // btnReadSerialNumber
            // 
            this.btnReadSerialNumber.Location = new System.Drawing.Point(147, 20);
            this.btnReadSerialNumber.Name = "btnReadSerialNumber";
            this.btnReadSerialNumber.Size = new System.Drawing.Size(60, 30);
            this.btnReadSerialNumber.TabIndex = 38;
            this.btnReadSerialNumber.Text = "读取";
            this.btnReadSerialNumber.UseVisualStyleBackColor = true;
            this.btnReadSerialNumber.Click += new System.EventHandler(this.btnReadSerialNumber_Click);
            // 
            // tbSerialNumber
            // 
            this.tbSerialNumber.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbSerialNumber.Location = new System.Drawing.Point(7, 22);
            this.tbSerialNumber.Name = "tbSerialNumber";
            this.tbSerialNumber.Size = new System.Drawing.Size(134, 26);
            this.tbSerialNumber.TabIndex = 16;
            this.tbSerialNumber.Text = "202103180009";
            this.tbSerialNumber.TextChanged += new System.EventHandler(this.tbSerialNumber_TextChanged);
            // 
            // gbDevNo
            // 
            this.gbDevNo.Controls.Add(this.btnSetDeviceId);
            this.gbDevNo.Controls.Add(this.btnReadDeviceId);
            this.gbDevNo.Controls.Add(this.tbNewDevNo);
            this.gbDevNo.Location = new System.Drawing.Point(9, 396);
            this.gbDevNo.Name = "gbDevNo";
            this.gbDevNo.Size = new System.Drawing.Size(223, 58);
            this.gbDevNo.TabIndex = 100;
            this.gbDevNo.TabStop = false;
            this.gbDevNo.Text = "设备号";
            // 
            // btnSetDeviceId
            // 
            this.btnSetDeviceId.Location = new System.Drawing.Point(150, 20);
            this.btnSetDeviceId.Name = "btnSetDeviceId";
            this.btnSetDeviceId.Size = new System.Drawing.Size(60, 30);
            this.btnSetDeviceId.TabIndex = 40;
            this.btnSetDeviceId.Text = "设置";
            this.btnSetDeviceId.UseVisualStyleBackColor = true;
            this.btnSetDeviceId.Click += new System.EventHandler(this.btnSetDeviceId_Click);
            // 
            // btnReadDeviceId
            // 
            this.btnReadDeviceId.Location = new System.Drawing.Point(84, 20);
            this.btnReadDeviceId.Name = "btnReadDeviceId";
            this.btnReadDeviceId.Size = new System.Drawing.Size(60, 30);
            this.btnReadDeviceId.TabIndex = 38;
            this.btnReadDeviceId.Text = "读取";
            this.btnReadDeviceId.UseVisualStyleBackColor = true;
            this.btnReadDeviceId.Click += new System.EventHandler(this.btnReadDeviceId_Click);
            // 
            // tbNewDevNo
            // 
            this.tbNewDevNo.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbNewDevNo.Location = new System.Drawing.Point(8, 20);
            this.tbNewDevNo.Name = "tbNewDevNo";
            this.tbNewDevNo.Size = new System.Drawing.Size(70, 30);
            this.tbNewDevNo.TabIndex = 0;
            // 
            // gbSingleOrMulti
            // 
            this.gbSingleOrMulti.Controls.Add(this.btnSetReadMode);
            this.gbSingleOrMulti.Controls.Add(this.btnGetReadMode);
            this.gbSingleOrMulti.Controls.Add(this.cbbSingOrMulti);
            this.gbSingleOrMulti.Location = new System.Drawing.Point(8, 460);
            this.gbSingleOrMulti.Name = "gbSingleOrMulti";
            this.gbSingleOrMulti.Size = new System.Drawing.Size(408, 58);
            this.gbSingleOrMulti.TabIndex = 99;
            this.gbSingleOrMulti.TabStop = false;
            this.gbSingleOrMulti.Text = "读卡方式";
            // 
            // btnSetReadMode
            // 
            this.btnSetReadMode.Location = new System.Drawing.Point(216, 20);
            this.btnSetReadMode.Name = "btnSetReadMode";
            this.btnSetReadMode.Size = new System.Drawing.Size(60, 30);
            this.btnSetReadMode.TabIndex = 40;
            this.btnSetReadMode.Text = "设置";
            this.btnSetReadMode.UseVisualStyleBackColor = true;
            this.btnSetReadMode.Click += new System.EventHandler(this.btnSetReadMode_Click);
            // 
            // btnGetReadMode
            // 
            this.btnGetReadMode.Location = new System.Drawing.Point(152, 20);
            this.btnGetReadMode.Name = "btnGetReadMode";
            this.btnGetReadMode.Size = new System.Drawing.Size(60, 30);
            this.btnGetReadMode.TabIndex = 38;
            this.btnGetReadMode.Text = "读取";
            this.btnGetReadMode.UseVisualStyleBackColor = true;
            this.btnGetReadMode.Click += new System.EventHandler(this.btnGetReadMode_Click);
            // 
            // cbbSingOrMulti
            // 
            this.cbbSingOrMulti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSingOrMulti.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbSingOrMulti.FormattingEnabled = true;
            this.cbbSingOrMulti.Location = new System.Drawing.Point(6, 23);
            this.cbbSingOrMulti.Name = "cbbSingOrMulti";
            this.cbbSingOrMulti.Size = new System.Drawing.Size(139, 24);
            this.cbbSingOrMulti.TabIndex = 34;
            // 
            // gbPower
            // 
            this.gbPower.Controls.Add(this.btnSetPower);
            this.gbPower.Controls.Add(this.btnReadPower);
            this.gbPower.Controls.Add(this.tbPower);
            this.gbPower.Location = new System.Drawing.Point(238, 396);
            this.gbPower.Name = "gbPower";
            this.gbPower.Size = new System.Drawing.Size(215, 58);
            this.gbPower.TabIndex = 98;
            this.gbPower.TabStop = false;
            this.gbPower.Text = "功率";
            // 
            // btnSetPower
            // 
            this.btnSetPower.Location = new System.Drawing.Point(149, 20);
            this.btnSetPower.Name = "btnSetPower";
            this.btnSetPower.Size = new System.Drawing.Size(60, 30);
            this.btnSetPower.TabIndex = 40;
            this.btnSetPower.Text = "设置";
            this.btnSetPower.UseVisualStyleBackColor = true;
            this.btnSetPower.Click += new System.EventHandler(this.btnSetPower_Click);
            // 
            // btnReadPower
            // 
            this.btnReadPower.Location = new System.Drawing.Point(83, 20);
            this.btnReadPower.Name = "btnReadPower";
            this.btnReadPower.Size = new System.Drawing.Size(60, 30);
            this.btnReadPower.TabIndex = 38;
            this.btnReadPower.Text = "读取";
            this.btnReadPower.UseVisualStyleBackColor = true;
            this.btnReadPower.Click += new System.EventHandler(this.btnReadPower_Click);
            // 
            // tbPower
            // 
            this.tbPower.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPower.Location = new System.Drawing.Point(7, 20);
            this.tbPower.Name = "tbPower";
            this.tbPower.Size = new System.Drawing.Size(70, 30);
            this.tbPower.TabIndex = 16;
            // 
            // gbDataOutputFormat
            // 
            this.gbDataOutputFormat.Controls.Add(this.gbUsbFormat);
            this.gbDataOutputFormat.Controls.Add(this.gbNotDoubleUSBDevice);
            this.gbDataOutputFormat.Location = new System.Drawing.Point(8, 15);
            this.gbDataOutputFormat.Name = "gbDataOutputFormat";
            this.gbDataOutputFormat.Size = new System.Drawing.Size(745, 124);
            this.gbDataOutputFormat.TabIndex = 97;
            this.gbDataOutputFormat.TabStop = false;
            this.gbDataOutputFormat.Text = "输出格式";
            // 
            // gbUsbFormat
            // 
            this.gbUsbFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUsbFormat.Controls.Add(this.btnReadUsbFormat);
            this.gbUsbFormat.Controls.Add(this.btnSetUsbFormat);
            this.gbUsbFormat.Controls.Add(this.cbbUsbFormat);
            this.gbUsbFormat.Location = new System.Drawing.Point(8, 22);
            this.gbUsbFormat.Name = "gbUsbFormat";
            this.gbUsbFormat.Size = new System.Drawing.Size(378, 91);
            this.gbUsbFormat.TabIndex = 5;
            this.gbUsbFormat.TabStop = false;
            this.gbUsbFormat.Text = "仅限双U口发卡器";
            // 
            // btnReadUsbFormat
            // 
            this.btnReadUsbFormat.Location = new System.Drawing.Point(199, 47);
            this.btnReadUsbFormat.Name = "btnReadUsbFormat";
            this.btnReadUsbFormat.Size = new System.Drawing.Size(80, 30);
            this.btnReadUsbFormat.TabIndex = 11;
            this.btnReadUsbFormat.Text = "查询";
            this.btnReadUsbFormat.UseVisualStyleBackColor = true;
            this.btnReadUsbFormat.Click += new System.EventHandler(this.btnReadUsbFormat_Click);
            // 
            // btnSetUsbFormat
            // 
            this.btnSetUsbFormat.Location = new System.Drawing.Point(285, 47);
            this.btnSetUsbFormat.Name = "btnSetUsbFormat";
            this.btnSetUsbFormat.Size = new System.Drawing.Size(80, 30);
            this.btnSetUsbFormat.TabIndex = 10;
            this.btnSetUsbFormat.Text = "设置";
            this.btnSetUsbFormat.UseVisualStyleBackColor = true;
            this.btnSetUsbFormat.Click += new System.EventHandler(this.btnSetUsbFormat_Click);
            // 
            // cbbUsbFormat
            // 
            this.cbbUsbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUsbFormat.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbUsbFormat.FormattingEnabled = true;
            this.cbbUsbFormat.Location = new System.Drawing.Point(5, 20);
            this.cbbUsbFormat.Name = "cbbUsbFormat";
            this.cbbUsbFormat.Size = new System.Drawing.Size(360, 21);
            this.cbbUsbFormat.TabIndex = 2;
            // 
            // gbNotDoubleUSBDevice
            // 
            this.gbNotDoubleUSBDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbNotDoubleUSBDevice.Controls.Add(this.btnSetEPCDataFormat);
            this.gbNotDoubleUSBDevice.Controls.Add(this.cbbEPCDataFormat);
            this.gbNotDoubleUSBDevice.Controls.Add(this.EpcFormatLB);
            this.gbNotDoubleUSBDevice.Controls.Add(this.btnReadEPCDataFormat);
            this.gbNotDoubleUSBDevice.Location = new System.Drawing.Point(392, 22);
            this.gbNotDoubleUSBDevice.Name = "gbNotDoubleUSBDevice";
            this.gbNotDoubleUSBDevice.Size = new System.Drawing.Size(336, 91);
            this.gbNotDoubleUSBDevice.TabIndex = 96;
            this.gbNotDoubleUSBDevice.TabStop = false;
            this.gbNotDoubleUSBDevice.Text = "非双USB设备";
            // 
            // btnSetEPCDataFormat
            // 
            this.btnSetEPCDataFormat.Location = new System.Drawing.Point(250, 47);
            this.btnSetEPCDataFormat.Name = "btnSetEPCDataFormat";
            this.btnSetEPCDataFormat.Size = new System.Drawing.Size(80, 30);
            this.btnSetEPCDataFormat.TabIndex = 40;
            this.btnSetEPCDataFormat.Text = "设置";
            this.btnSetEPCDataFormat.UseVisualStyleBackColor = true;
            this.btnSetEPCDataFormat.Click += new System.EventHandler(this.btnSetEPCDataFormat_Click);
            // 
            // cbbEPCDataFormat
            // 
            this.cbbEPCDataFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbEPCDataFormat.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbEPCDataFormat.FormattingEnabled = true;
            this.cbbEPCDataFormat.Items.AddRange(new object[] {
            "非标准长度",
            "标准12字节"});
            this.cbbEPCDataFormat.Location = new System.Drawing.Point(105, 20);
            this.cbbEPCDataFormat.Name = "cbbEPCDataFormat";
            this.cbbEPCDataFormat.Size = new System.Drawing.Size(225, 23);
            this.cbbEPCDataFormat.TabIndex = 95;
            // 
            // EpcFormatLB
            // 
            this.EpcFormatLB.Location = new System.Drawing.Point(6, 18);
            this.EpcFormatLB.Name = "EpcFormatLB";
            this.EpcFormatLB.Size = new System.Drawing.Size(93, 27);
            this.EpcFormatLB.TabIndex = 94;
            this.EpcFormatLB.Text = "EPC长度";
            this.EpcFormatLB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnReadEPCDataFormat
            // 
            this.btnReadEPCDataFormat.Location = new System.Drawing.Point(164, 47);
            this.btnReadEPCDataFormat.Name = "btnReadEPCDataFormat";
            this.btnReadEPCDataFormat.Size = new System.Drawing.Size(80, 30);
            this.btnReadEPCDataFormat.TabIndex = 38;
            this.btnReadEPCDataFormat.Text = "读取";
            this.btnReadEPCDataFormat.UseVisualStyleBackColor = true;
            this.btnReadEPCDataFormat.Click += new System.EventHandler(this.btnReadEPCDataFormat_Click);
            // 
            // GopRelayControl
            // 
            this.GopRelayControl.Controls.Add(this.tbRelayMode);
            this.GopRelayControl.Controls.Add(this.btnSetRelayTime);
            this.GopRelayControl.Location = new System.Drawing.Point(474, 145);
            this.GopRelayControl.Name = "GopRelayControl";
            this.GopRelayControl.Size = new System.Drawing.Size(279, 170);
            this.GopRelayControl.TabIndex = 33;
            this.GopRelayControl.TabStop = false;
            this.GopRelayControl.Text = "继电器自动闭合使能";
            // 
            // tbRelayMode
            // 
            this.tbRelayMode.Controls.Add(this.tpInitiative);
            this.tbRelayMode.Controls.Add(this.tpPassivity);
            this.tbRelayMode.Location = new System.Drawing.Point(6, 20);
            this.tbRelayMode.Name = "tbRelayMode";
            this.tbRelayMode.SelectedIndex = 0;
            this.tbRelayMode.Size = new System.Drawing.Size(260, 110);
            this.tbRelayMode.TabIndex = 0;
            // 
            // tpInitiative
            // 
            this.tpInitiative.Controls.Add(this.lblCloseTime);
            this.tpInitiative.Controls.Add(this.cbbRelayTime);
            this.tpInitiative.Location = new System.Drawing.Point(4, 22);
            this.tpInitiative.Name = "tpInitiative";
            this.tpInitiative.Padding = new System.Windows.Forms.Padding(3);
            this.tpInitiative.Size = new System.Drawing.Size(252, 84);
            this.tpInitiative.TabIndex = 0;
            this.tpInitiative.Text = "主动";
            this.tpInitiative.UseVisualStyleBackColor = true;
            // 
            // lblCloseTime
            // 
            this.lblCloseTime.Location = new System.Drawing.Point(3, 28);
            this.lblCloseTime.Name = "lblCloseTime";
            this.lblCloseTime.Size = new System.Drawing.Size(123, 27);
            this.lblCloseTime.TabIndex = 3;
            this.lblCloseTime.Text = "闭合时间";
            this.lblCloseTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbRelayTime
            // 
            this.cbbRelayTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbRelayTime.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbRelayTime.FormattingEnabled = true;
            this.cbbRelayTime.Items.AddRange(new object[] {
            "1",
            "5",
            "10"});
            this.cbbRelayTime.Location = new System.Drawing.Point(132, 28);
            this.cbbRelayTime.Name = "cbbRelayTime";
            this.cbbRelayTime.Size = new System.Drawing.Size(114, 28);
            this.cbbRelayTime.TabIndex = 2;
            // 
            // tpPassivity
            // 
            this.tpPassivity.Controls.Add(this.panel2);
            this.tpPassivity.Controls.Add(this.panel1);
            this.tpPassivity.Location = new System.Drawing.Point(4, 22);
            this.tpPassivity.Name = "tpPassivity";
            this.tpPassivity.Padding = new System.Windows.Forms.Padding(3);
            this.tpPassivity.Size = new System.Drawing.Size(252, 84);
            this.tpPassivity.TabIndex = 1;
            this.tpPassivity.Text = "被动";
            this.tpPassivity.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdoOpen2);
            this.panel2.Controls.Add(this.rdoClose2);
            this.panel2.Location = new System.Drawing.Point(122, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(127, 78);
            this.panel2.TabIndex = 101;
            // 
            // rdoOpen2
            // 
            this.rdoOpen2.AccessibleName = "rdo2";
            this.rdoOpen2.AutoSize = true;
            this.rdoOpen2.Location = new System.Drawing.Point(10, 15);
            this.rdoOpen2.Name = "rdoOpen2";
            this.rdoOpen2.Size = new System.Drawing.Size(59, 16);
            this.rdoOpen2.TabIndex = 0;
            this.rdoOpen2.Text = "打开 2";
            this.rdoOpen2.UseVisualStyleBackColor = true;
            // 
            // rdoClose2
            // 
            this.rdoClose2.AccessibleName = "rdo2";
            this.rdoClose2.AutoSize = true;
            this.rdoClose2.Checked = true;
            this.rdoClose2.Location = new System.Drawing.Point(10, 50);
            this.rdoClose2.Name = "rdoClose2";
            this.rdoClose2.Size = new System.Drawing.Size(59, 16);
            this.rdoClose2.TabIndex = 1;
            this.rdoClose2.TabStop = true;
            this.rdoClose2.Text = "闭合 2";
            this.rdoClose2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdoClose1);
            this.panel1.Controls.Add(this.rdoOpen1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(114, 78);
            this.panel1.TabIndex = 101;
            // 
            // rdoClose1
            // 
            this.rdoClose1.AccessibleName = "rdo1";
            this.rdoClose1.AutoSize = true;
            this.rdoClose1.Checked = true;
            this.rdoClose1.Location = new System.Drawing.Point(18, 50);
            this.rdoClose1.Name = "rdoClose1";
            this.rdoClose1.Size = new System.Drawing.Size(59, 16);
            this.rdoClose1.TabIndex = 1;
            this.rdoClose1.TabStop = true;
            this.rdoClose1.Text = "闭合 1";
            this.rdoClose1.UseVisualStyleBackColor = true;
            // 
            // rdoOpen1
            // 
            this.rdoOpen1.AccessibleName = "rdo1";
            this.rdoOpen1.AutoSize = true;
            this.rdoOpen1.Location = new System.Drawing.Point(18, 15);
            this.rdoOpen1.Name = "rdoOpen1";
            this.rdoOpen1.Size = new System.Drawing.Size(59, 16);
            this.rdoOpen1.TabIndex = 0;
            this.rdoOpen1.Text = "打开 1";
            this.rdoOpen1.UseVisualStyleBackColor = true;
            // 
            // btnSetRelayTime
            // 
            this.btnSetRelayTime.Location = new System.Drawing.Point(178, 132);
            this.btnSetRelayTime.Name = "btnSetRelayTime";
            this.btnSetRelayTime.Size = new System.Drawing.Size(88, 30);
            this.btnSetRelayTime.TabIndex = 11;
            this.btnSetRelayTime.Text = "设置";
            this.btnSetRelayTime.UseVisualStyleBackColor = true;
            this.btnSetRelayTime.Click += new System.EventHandler(this.btnSetRelayTime_Click);
            // 
            // gbTagAuth
            // 
            this.gbTagAuth.Controls.Add(this.btnQueryAuthorization);
            this.gbTagAuth.Controls.Add(this.btnAutoAuthorization);
            this.gbTagAuth.Controls.Add(this.labNewAuthPwd);
            this.gbTagAuth.Controls.Add(this.labAuthPwd);
            this.gbTagAuth.Controls.Add(this.tbNewAuthPwd);
            this.gbTagAuth.Controls.Add(this.tbAuthPwd);
            this.gbTagAuth.Controls.Add(this.btnTagAuth);
            this.gbTagAuth.Controls.Add(this.btnModifyAuthPwd);
            this.gbTagAuth.Location = new System.Drawing.Point(8, 144);
            this.gbTagAuth.Name = "gbTagAuth";
            this.gbTagAuth.Size = new System.Drawing.Size(444, 141);
            this.gbTagAuth.TabIndex = 6;
            this.gbTagAuth.TabStop = false;
            this.gbTagAuth.Text = "标签加密";
            // 
            // btnQueryAuthorization
            // 
            this.btnQueryAuthorization.Location = new System.Drawing.Point(350, 20);
            this.btnQueryAuthorization.Name = "btnQueryAuthorization";
            this.btnQueryAuthorization.Size = new System.Drawing.Size(88, 32);
            this.btnQueryAuthorization.TabIndex = 16;
            this.btnQueryAuthorization.Text = "查询授权码";
            this.btnQueryAuthorization.UseVisualStyleBackColor = true;
            this.btnQueryAuthorization.Click += new System.EventHandler(this.btnQueryAuthorization_Click);
            // 
            // btnAutoAuthorization
            // 
            this.btnAutoAuthorization.Location = new System.Drawing.Point(350, 61);
            this.btnAutoAuthorization.Name = "btnAutoAuthorization";
            this.btnAutoAuthorization.Size = new System.Drawing.Size(88, 32);
            this.btnAutoAuthorization.TabIndex = 13;
            this.btnAutoAuthorization.Text = "开始自动授权";
            this.btnAutoAuthorization.UseVisualStyleBackColor = true;
            this.btnAutoAuthorization.Click += new System.EventHandler(this.btnAutoAuthorization_Click);
            // 
            // labNewAuthPwd
            // 
            this.labNewAuthPwd.Location = new System.Drawing.Point(18, 64);
            this.labNewAuthPwd.Name = "labNewAuthPwd";
            this.labNewAuthPwd.Size = new System.Drawing.Size(180, 27);
            this.labNewAuthPwd.TabIndex = 12;
            this.labNewAuthPwd.Text = "新授权码";
            this.labNewAuthPwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labAuthPwd
            // 
            this.labAuthPwd.Location = new System.Drawing.Point(18, 23);
            this.labAuthPwd.Name = "labAuthPwd";
            this.labAuthPwd.Size = new System.Drawing.Size(180, 27);
            this.labAuthPwd.TabIndex = 11;
            this.labAuthPwd.Text = "原授权码";
            this.labAuthPwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbNewAuthPwd
            // 
            this.tbNewAuthPwd.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbNewAuthPwd.Location = new System.Drawing.Point(229, 62);
            this.tbNewAuthPwd.Name = "tbNewAuthPwd";
            this.tbNewAuthPwd.Size = new System.Drawing.Size(100, 30);
            this.tbNewAuthPwd.TabIndex = 10;
            // 
            // tbAuthPwd
            // 
            this.tbAuthPwd.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbAuthPwd.Location = new System.Drawing.Point(229, 23);
            this.tbAuthPwd.Name = "tbAuthPwd";
            this.tbAuthPwd.Size = new System.Drawing.Size(100, 30);
            this.tbAuthPwd.TabIndex = 9;
            // 
            // btnTagAuth
            // 
            this.btnTagAuth.Location = new System.Drawing.Point(241, 99);
            this.btnTagAuth.Name = "btnTagAuth";
            this.btnTagAuth.Size = new System.Drawing.Size(88, 32);
            this.btnTagAuth.TabIndex = 8;
            this.btnTagAuth.Text = "标签授权";
            this.btnTagAuth.UseVisualStyleBackColor = true;
            this.btnTagAuth.Click += new System.EventHandler(this.btnTagAuth_Click);
            // 
            // btnModifyAuthPwd
            // 
            this.btnModifyAuthPwd.Location = new System.Drawing.Point(350, 99);
            this.btnModifyAuthPwd.Name = "btnModifyAuthPwd";
            this.btnModifyAuthPwd.Size = new System.Drawing.Size(88, 32);
            this.btnModifyAuthPwd.TabIndex = 7;
            this.btnModifyAuthPwd.Text = "修改授权码";
            this.btnModifyAuthPwd.UseVisualStyleBackColor = true;
            this.btnModifyAuthPwd.Click += new System.EventHandler(this.btnModifyAuthPwd_Click);
            // 
            // grpAntSet
            // 
            this.grpAntSet.Controls.Add(this.chkAnt8);
            this.grpAntSet.Controls.Add(this.chkAnt7);
            this.grpAntSet.Controls.Add(this.chkAnt6);
            this.grpAntSet.Controls.Add(this.chkAnt5);
            this.grpAntSet.Controls.Add(this.chkAnt4);
            this.grpAntSet.Controls.Add(this.chkAnt3);
            this.grpAntSet.Controls.Add(this.chkAnt2);
            this.grpAntSet.Controls.Add(this.chkAnt1);
            this.grpAntSet.Controls.Add(this.btnAntSet);
            this.grpAntSet.Controls.Add(this.btnAntRead);
            this.grpAntSet.Location = new System.Drawing.Point(474, 321);
            this.grpAntSet.Name = "grpAntSet";
            this.grpAntSet.Size = new System.Drawing.Size(279, 133);
            this.grpAntSet.TabIndex = 93;
            this.grpAntSet.TabStop = false;
            this.grpAntSet.Text = "天线设置";
            // 
            // chkAnt8
            // 
            this.chkAnt8.AutoSize = true;
            this.chkAnt8.Location = new System.Drawing.Point(210, 63);
            this.chkAnt8.Name = "chkAnt8";
            this.chkAnt8.Size = new System.Drawing.Size(54, 16);
            this.chkAnt8.TabIndex = 66;
            this.chkAnt8.Text = "Ant 8";
            this.chkAnt8.UseVisualStyleBackColor = true;
            // 
            // chkAnt7
            // 
            this.chkAnt7.AutoSize = true;
            this.chkAnt7.Location = new System.Drawing.Point(148, 63);
            this.chkAnt7.Name = "chkAnt7";
            this.chkAnt7.Size = new System.Drawing.Size(54, 16);
            this.chkAnt7.TabIndex = 65;
            this.chkAnt7.Text = "Ant 7";
            this.chkAnt7.UseVisualStyleBackColor = true;
            // 
            // chkAnt6
            // 
            this.chkAnt6.AutoSize = true;
            this.chkAnt6.Location = new System.Drawing.Point(86, 63);
            this.chkAnt6.Name = "chkAnt6";
            this.chkAnt6.Size = new System.Drawing.Size(54, 16);
            this.chkAnt6.TabIndex = 64;
            this.chkAnt6.Text = "Ant 6";
            this.chkAnt6.UseVisualStyleBackColor = true;
            // 
            // chkAnt5
            // 
            this.chkAnt5.AutoSize = true;
            this.chkAnt5.Location = new System.Drawing.Point(24, 63);
            this.chkAnt5.Name = "chkAnt5";
            this.chkAnt5.Size = new System.Drawing.Size(54, 16);
            this.chkAnt5.TabIndex = 63;
            this.chkAnt5.Text = "Ant 5";
            this.chkAnt5.UseVisualStyleBackColor = true;
            // 
            // chkAnt4
            // 
            this.chkAnt4.AutoSize = true;
            this.chkAnt4.Location = new System.Drawing.Point(210, 31);
            this.chkAnt4.Name = "chkAnt4";
            this.chkAnt4.Size = new System.Drawing.Size(54, 16);
            this.chkAnt4.TabIndex = 62;
            this.chkAnt4.Text = "Ant 4";
            this.chkAnt4.UseVisualStyleBackColor = true;
            // 
            // chkAnt3
            // 
            this.chkAnt3.AutoSize = true;
            this.chkAnt3.Location = new System.Drawing.Point(148, 31);
            this.chkAnt3.Name = "chkAnt3";
            this.chkAnt3.Size = new System.Drawing.Size(54, 16);
            this.chkAnt3.TabIndex = 61;
            this.chkAnt3.Text = "Ant 3";
            this.chkAnt3.UseVisualStyleBackColor = true;
            // 
            // chkAnt2
            // 
            this.chkAnt2.AutoSize = true;
            this.chkAnt2.Location = new System.Drawing.Point(86, 31);
            this.chkAnt2.Name = "chkAnt2";
            this.chkAnt2.Size = new System.Drawing.Size(54, 16);
            this.chkAnt2.TabIndex = 60;
            this.chkAnt2.Text = "Ant 2";
            this.chkAnt2.UseVisualStyleBackColor = true;
            // 
            // chkAnt1
            // 
            this.chkAnt1.AutoSize = true;
            this.chkAnt1.Location = new System.Drawing.Point(24, 31);
            this.chkAnt1.Name = "chkAnt1";
            this.chkAnt1.Size = new System.Drawing.Size(54, 16);
            this.chkAnt1.TabIndex = 59;
            this.chkAnt1.Text = "Ant 1";
            this.chkAnt1.UseVisualStyleBackColor = true;
            // 
            // btnAntSet
            // 
            this.btnAntSet.Location = new System.Drawing.Point(213, 95);
            this.btnAntSet.Name = "btnAntSet";
            this.btnAntSet.Size = new System.Drawing.Size(60, 30);
            this.btnAntSet.TabIndex = 58;
            this.btnAntSet.Text = "设置";
            this.btnAntSet.UseVisualStyleBackColor = true;
            this.btnAntSet.Click += new System.EventHandler(this.btnAntSet_Click);
            // 
            // btnAntRead
            // 
            this.btnAntRead.Location = new System.Drawing.Point(147, 95);
            this.btnAntRead.Name = "btnAntRead";
            this.btnAntRead.Size = new System.Drawing.Size(60, 30);
            this.btnAntRead.TabIndex = 58;
            this.btnAntRead.Text = "读取";
            this.btnAntRead.UseVisualStyleBackColor = true;
            this.btnAntRead.Click += new System.EventHandler(this.btnAntRead_Click);
            // 
            // gbBeepControl
            // 
            this.gbBeepControl.Controls.Add(this.btnReadDataArea);
            this.gbBeepControl.Controls.Add(this.label2);
            this.gbBeepControl.Controls.Add(this.btnSetDataArea);
            this.gbBeepControl.Controls.Add(this.cbbDataArea);
            this.gbBeepControl.Controls.Add(this.lblReadVoice);
            this.gbBeepControl.Controls.Add(this.btnReadBeep);
            this.gbBeepControl.Controls.Add(this.btnSetBeep);
            this.gbBeepControl.Controls.Add(this.cbbBeepControl);
            this.gbBeepControl.Location = new System.Drawing.Point(9, 293);
            this.gbBeepControl.Name = "gbBeepControl";
            this.gbBeepControl.Size = new System.Drawing.Size(444, 97);
            this.gbBeepControl.TabIndex = 4;
            this.gbBeepControl.TabStop = false;
            this.gbBeepControl.Text = "读卡控制";
            // 
            // btnReadDataArea
            // 
            this.btnReadDataArea.Location = new System.Drawing.Point(272, 54);
            this.btnReadDataArea.Name = "btnReadDataArea";
            this.btnReadDataArea.Size = new System.Drawing.Size(80, 30);
            this.btnReadDataArea.TabIndex = 16;
            this.btnReadDataArea.Text = "读取";
            this.btnReadDataArea.UseVisualStyleBackColor = true;
            this.btnReadDataArea.Click += new System.EventHandler(this.btnReadDataArea_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 27);
            this.label2.TabIndex = 15;
            this.label2.Text = "读卡数据区域";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSetDataArea
            // 
            this.btnSetDataArea.Location = new System.Drawing.Point(358, 54);
            this.btnSetDataArea.Name = "btnSetDataArea";
            this.btnSetDataArea.Size = new System.Drawing.Size(80, 30);
            this.btnSetDataArea.TabIndex = 14;
            this.btnSetDataArea.Text = "设置";
            this.btnSetDataArea.UseVisualStyleBackColor = true;
            this.btnSetDataArea.Click += new System.EventHandler(this.btnSetDataArea_Click);
            // 
            // cbbDataArea
            // 
            this.cbbDataArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDataArea.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbDataArea.FormattingEnabled = true;
            this.cbbDataArea.Items.AddRange(new object[] {
            "EPC",
            "TID",
            "USER"});
            this.cbbDataArea.Location = new System.Drawing.Point(106, 57);
            this.cbbDataArea.Name = "cbbDataArea";
            this.cbbDataArea.Size = new System.Drawing.Size(150, 24);
            this.cbbDataArea.TabIndex = 13;
            // 
            // lblReadVoice
            // 
            this.lblReadVoice.Location = new System.Drawing.Point(20, 22);
            this.lblReadVoice.Name = "lblReadVoice";
            this.lblReadVoice.Size = new System.Drawing.Size(80, 27);
            this.lblReadVoice.TabIndex = 12;
            this.lblReadVoice.Text = "蜂鸣器声音";
            this.lblReadVoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnReadBeep
            // 
            this.btnReadBeep.Location = new System.Drawing.Point(272, 20);
            this.btnReadBeep.Name = "btnReadBeep";
            this.btnReadBeep.Size = new System.Drawing.Size(80, 30);
            this.btnReadBeep.TabIndex = 9;
            this.btnReadBeep.Text = "读取";
            this.btnReadBeep.UseVisualStyleBackColor = true;
            this.btnReadBeep.Click += new System.EventHandler(this.btnReadBeep_Click);
            // 
            // btnSetBeep
            // 
            this.btnSetBeep.Location = new System.Drawing.Point(358, 20);
            this.btnSetBeep.Name = "btnSetBeep";
            this.btnSetBeep.Size = new System.Drawing.Size(80, 30);
            this.btnSetBeep.TabIndex = 9;
            this.btnSetBeep.Text = "设置";
            this.btnSetBeep.UseVisualStyleBackColor = true;
            this.btnSetBeep.Click += new System.EventHandler(this.btnSetBeep_Click);
            // 
            // cbbBeepControl
            // 
            this.cbbBeepControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBeepControl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbBeepControl.FormattingEnabled = true;
            this.cbbBeepControl.Location = new System.Drawing.Point(106, 23);
            this.cbbBeepControl.Name = "cbbBeepControl";
            this.cbbBeepControl.Size = new System.Drawing.Size(150, 24);
            this.cbbBeepControl.TabIndex = 2;
            // 
            // SetReaderParam
            // 
            this.SetReaderParam.Controls.Add(this.gbFreq);
            this.SetReaderParam.Controls.Add(this.gbCommModeParam);
            this.SetReaderParam.Controls.Add(this.gbWorkMode);
            this.SetReaderParam.Location = new System.Drawing.Point(4, 22);
            this.SetReaderParam.Name = "SetReaderParam";
            this.SetReaderParam.Padding = new System.Windows.Forms.Padding(3);
            this.SetReaderParam.Size = new System.Drawing.Size(757, 546);
            this.SetReaderParam.TabIndex = 3;
            this.SetReaderParam.Text = "读写器参数";
            this.SetReaderParam.UseVisualStyleBackColor = true;
            this.SetReaderParam.Enter += new System.EventHandler(this.SetReaderParam_Enter);
            // 
            // gbFreq
            // 
            this.gbFreq.Controls.Add(this.cbbFixFrequency);
            this.gbFreq.Controls.Add(this.cbbFrequency_Mode);
            this.gbFreq.Controls.Add(this.lblFrequencyArea);
            this.gbFreq.Controls.Add(this.tbHoppingFrequency);
            this.gbFreq.Controls.Add(this.label8);
            this.gbFreq.Controls.Add(this.btnClearFreq);
            this.gbFreq.Controls.Add(this.btnDefaultFreq);
            this.gbFreq.Controls.Add(this.btnReadFreq);
            this.gbFreq.Controls.Add(this.labFreq);
            this.gbFreq.Controls.Add(this.cbbFrequencyBand);
            this.gbFreq.Controls.Add(this.labSetParam);
            this.gbFreq.Controls.Add(this.btnSetFreq);
            this.gbFreq.Location = new System.Drawing.Point(14, 234);
            this.gbFreq.Name = "gbFreq";
            this.gbFreq.Size = new System.Drawing.Size(727, 306);
            this.gbFreq.TabIndex = 92;
            this.gbFreq.TabStop = false;
            this.gbFreq.Text = "频率及其它参数";
            // 
            // cbbFixFrequency
            // 
            this.cbbFixFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFixFrequency.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbFixFrequency.FormattingEnabled = true;
            this.cbbFixFrequency.Items.AddRange(new object[] {
            "跳频",
            "定频"});
            this.cbbFixFrequency.Location = new System.Drawing.Point(254, 49);
            this.cbbFixFrequency.Name = "cbbFixFrequency";
            this.cbbFixFrequency.Size = new System.Drawing.Size(120, 24);
            this.cbbFixFrequency.TabIndex = 103;
            // 
            // cbbFrequency_Mode
            // 
            this.cbbFrequency_Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFrequency_Mode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbFrequency_Mode.FormattingEnabled = true;
            this.cbbFrequency_Mode.Items.AddRange(new object[] {
            "跳频",
            "定频"});
            this.cbbFrequency_Mode.Location = new System.Drawing.Point(124, 49);
            this.cbbFrequency_Mode.Name = "cbbFrequency_Mode";
            this.cbbFrequency_Mode.Size = new System.Drawing.Size(120, 24);
            this.cbbFrequency_Mode.TabIndex = 102;
            this.cbbFrequency_Mode.SelectedIndexChanged += new System.EventHandler(this.cbbFrequency_Mode_SelectedIndexChanged);
            // 
            // lblFrequencyArea
            // 
            this.lblFrequencyArea.Location = new System.Drawing.Point(8, 20);
            this.lblFrequencyArea.Name = "lblFrequencyArea";
            this.lblFrequencyArea.Size = new System.Drawing.Size(100, 22);
            this.lblFrequencyArea.TabIndex = 98;
            this.lblFrequencyArea.Text = "频率区域";
            this.lblFrequencyArea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbHoppingFrequency
            // 
            this.tbHoppingFrequency.Controls.Add(this.tpUSA_Band);
            this.tbHoppingFrequency.Controls.Add(this.tpEU_Band);
            this.tbHoppingFrequency.Controls.Add(this.tpKorea_Band);
            this.tbHoppingFrequency.Location = new System.Drawing.Point(6, 82);
            this.tbHoppingFrequency.Name = "tbHoppingFrequency";
            this.tbHoppingFrequency.SelectedIndex = 0;
            this.tbHoppingFrequency.Size = new System.Drawing.Size(709, 185);
            this.tbHoppingFrequency.TabIndex = 97;
            this.tbHoppingFrequency.SelectedIndexChanged += new System.EventHandler(this.tbHoppingFrequency_SelectedIndexChanged);
            // 
            // tpUSA_Band
            // 
            this.tpUSA_Band.Controls.Add(this.chkFreqUSAll5);
            this.tpUSA_Band.Controls.Add(this.chkFreqUSAll4);
            this.tpUSA_Band.Controls.Add(this.chkFreqUSAll3);
            this.tpUSA_Band.Controls.Add(this.chkFreqUSAll2);
            this.tpUSA_Band.Controls.Add(this.chkFreqUSAll1);
            this.tpUSA_Band.Controls.Add(this.cbFp50);
            this.tpUSA_Band.Controls.Add(this.cbFp24);
            this.tpUSA_Band.Controls.Add(this.cbFp49);
            this.tpUSA_Band.Controls.Add(this.cbFp25);
            this.tpUSA_Band.Controls.Add(this.cbFp23);
            this.tpUSA_Band.Controls.Add(this.cbFp48);
            this.tpUSA_Band.Controls.Add(this.cbFp26);
            this.tpUSA_Band.Controls.Add(this.cbFp22);
            this.tpUSA_Band.Controls.Add(this.cbFp47);
            this.tpUSA_Band.Controls.Add(this.cbFp27);
            this.tpUSA_Band.Controls.Add(this.cbFp1);
            this.tpUSA_Band.Controls.Add(this.cbFp21);
            this.tpUSA_Band.Controls.Add(this.cbFp46);
            this.tpUSA_Band.Controls.Add(this.cbFp28);
            this.tpUSA_Band.Controls.Add(this.cbFp2);
            this.tpUSA_Band.Controls.Add(this.cbFp20);
            this.tpUSA_Band.Controls.Add(this.cbFp45);
            this.tpUSA_Band.Controls.Add(this.cbFp29);
            this.tpUSA_Band.Controls.Add(this.cbFp3);
            this.tpUSA_Band.Controls.Add(this.cbFp19);
            this.tpUSA_Band.Controls.Add(this.cbFp44);
            this.tpUSA_Band.Controls.Add(this.cbFp30);
            this.tpUSA_Band.Controls.Add(this.cbFp4);
            this.tpUSA_Band.Controls.Add(this.cbFp18);
            this.tpUSA_Band.Controls.Add(this.cbFp43);
            this.tpUSA_Band.Controls.Add(this.cbFp31);
            this.tpUSA_Band.Controls.Add(this.cbFp5);
            this.tpUSA_Band.Controls.Add(this.cbFp17);
            this.tpUSA_Band.Controls.Add(this.cbFp42);
            this.tpUSA_Band.Controls.Add(this.cbFp32);
            this.tpUSA_Band.Controls.Add(this.cbFp6);
            this.tpUSA_Band.Controls.Add(this.cbFp16);
            this.tpUSA_Band.Controls.Add(this.cbFp41);
            this.tpUSA_Band.Controls.Add(this.cbFp33);
            this.tpUSA_Band.Controls.Add(this.cbFp7);
            this.tpUSA_Band.Controls.Add(this.cbFp15);
            this.tpUSA_Band.Controls.Add(this.cbFp8);
            this.tpUSA_Band.Controls.Add(this.cbFp34);
            this.tpUSA_Band.Controls.Add(this.cbFp40);
            this.tpUSA_Band.Controls.Add(this.cbFp14);
            this.tpUSA_Band.Controls.Add(this.cbFp9);
            this.tpUSA_Band.Controls.Add(this.cbFp35);
            this.tpUSA_Band.Controls.Add(this.cbFp39);
            this.tpUSA_Band.Controls.Add(this.cbFp13);
            this.tpUSA_Band.Controls.Add(this.cbFp10);
            this.tpUSA_Band.Controls.Add(this.cbFp36);
            this.tpUSA_Band.Controls.Add(this.cbFp38);
            this.tpUSA_Band.Controls.Add(this.cbFp12);
            this.tpUSA_Band.Controls.Add(this.cbFp11);
            this.tpUSA_Band.Controls.Add(this.cbFp37);
            this.tpUSA_Band.Location = new System.Drawing.Point(4, 22);
            this.tpUSA_Band.Name = "tpUSA_Band";
            this.tpUSA_Band.Padding = new System.Windows.Forms.Padding(3);
            this.tpUSA_Band.Size = new System.Drawing.Size(701, 159);
            this.tpUSA_Band.TabIndex = 0;
            this.tpUSA_Band.Text = "美标";
            this.tpUSA_Band.UseVisualStyleBackColor = true;
            // 
            // chkFreqUSAll5
            // 
            this.chkFreqUSAll5.AutoSize = true;
            this.chkFreqUSAll5.Location = new System.Drawing.Point(642, 129);
            this.chkFreqUSAll5.Name = "chkFreqUSAll5";
            this.chkFreqUSAll5.Size = new System.Drawing.Size(42, 16);
            this.chkFreqUSAll5.TabIndex = 93;
            this.chkFreqUSAll5.Text = "All";
            this.chkFreqUSAll5.UseVisualStyleBackColor = true;
            this.chkFreqUSAll5.CheckedChanged += new System.EventHandler(this.chkFreqUSAll5_CheckedChanged);
            // 
            // chkFreqUSAll4
            // 
            this.chkFreqUSAll4.AutoSize = true;
            this.chkFreqUSAll4.Location = new System.Drawing.Point(642, 101);
            this.chkFreqUSAll4.Name = "chkFreqUSAll4";
            this.chkFreqUSAll4.Size = new System.Drawing.Size(42, 16);
            this.chkFreqUSAll4.TabIndex = 93;
            this.chkFreqUSAll4.Text = "All";
            this.chkFreqUSAll4.UseVisualStyleBackColor = true;
            this.chkFreqUSAll4.CheckedChanged += new System.EventHandler(this.chkFreqUSAll4_CheckedChanged);
            // 
            // chkFreqUSAll3
            // 
            this.chkFreqUSAll3.AutoSize = true;
            this.chkFreqUSAll3.Location = new System.Drawing.Point(642, 73);
            this.chkFreqUSAll3.Name = "chkFreqUSAll3";
            this.chkFreqUSAll3.Size = new System.Drawing.Size(42, 16);
            this.chkFreqUSAll3.TabIndex = 93;
            this.chkFreqUSAll3.Text = "All";
            this.chkFreqUSAll3.UseVisualStyleBackColor = true;
            this.chkFreqUSAll3.CheckedChanged += new System.EventHandler(this.chkFreqUSAll3_CheckedChanged);
            // 
            // chkFreqUSAll2
            // 
            this.chkFreqUSAll2.AutoSize = true;
            this.chkFreqUSAll2.Location = new System.Drawing.Point(642, 45);
            this.chkFreqUSAll2.Name = "chkFreqUSAll2";
            this.chkFreqUSAll2.Size = new System.Drawing.Size(42, 16);
            this.chkFreqUSAll2.TabIndex = 93;
            this.chkFreqUSAll2.Text = "All";
            this.chkFreqUSAll2.UseVisualStyleBackColor = true;
            this.chkFreqUSAll2.CheckedChanged += new System.EventHandler(this.chkFreqUSAll2_CheckedChanged);
            // 
            // chkFreqUSAll1
            // 
            this.chkFreqUSAll1.AutoSize = true;
            this.chkFreqUSAll1.Location = new System.Drawing.Point(642, 17);
            this.chkFreqUSAll1.Name = "chkFreqUSAll1";
            this.chkFreqUSAll1.Size = new System.Drawing.Size(42, 16);
            this.chkFreqUSAll1.TabIndex = 92;
            this.chkFreqUSAll1.Text = "All";
            this.chkFreqUSAll1.UseVisualStyleBackColor = true;
            this.chkFreqUSAll1.CheckedChanged += new System.EventHandler(this.chkFreqUSAll1_CheckedChanged);
            // 
            // cbFp50
            // 
            this.cbFp50.AutoSize = true;
            this.cbFp50.Location = new System.Drawing.Point(579, 129);
            this.cbFp50.Name = "cbFp50";
            this.cbFp50.Size = new System.Drawing.Size(54, 16);
            this.cbFp50.TabIndex = 91;
            this.cbFp50.Text = "927.0";
            this.cbFp50.UseVisualStyleBackColor = true;
            this.cbFp50.CheckedChanged += new System.EventHandler(this.cbFp41_CheckedChanged);
            // 
            // cbFp24
            // 
            this.cbFp24.AutoSize = true;
            this.cbFp24.Location = new System.Drawing.Point(201, 73);
            this.cbFp24.Name = "cbFp24";
            this.cbFp24.Size = new System.Drawing.Size(54, 16);
            this.cbFp24.TabIndex = 64;
            this.cbFp24.Text = "914.0";
            this.cbFp24.UseVisualStyleBackColor = true;
            this.cbFp24.CheckedChanged += new System.EventHandler(this.cbFp21_CheckedChanged);
            // 
            // cbFp49
            // 
            this.cbFp49.AutoSize = true;
            this.cbFp49.Location = new System.Drawing.Point(516, 129);
            this.cbFp49.Name = "cbFp49";
            this.cbFp49.Size = new System.Drawing.Size(54, 16);
            this.cbFp49.TabIndex = 90;
            this.cbFp49.Text = "926.5";
            this.cbFp49.UseVisualStyleBackColor = true;
            this.cbFp49.CheckedChanged += new System.EventHandler(this.cbFp41_CheckedChanged);
            // 
            // cbFp25
            // 
            this.cbFp25.AutoSize = true;
            this.cbFp25.Location = new System.Drawing.Point(264, 73);
            this.cbFp25.Name = "cbFp25";
            this.cbFp25.Size = new System.Drawing.Size(54, 16);
            this.cbFp25.TabIndex = 65;
            this.cbFp25.Text = "914.5";
            this.cbFp25.UseVisualStyleBackColor = true;
            this.cbFp25.CheckedChanged += new System.EventHandler(this.cbFp21_CheckedChanged);
            // 
            // cbFp23
            // 
            this.cbFp23.AutoSize = true;
            this.cbFp23.Location = new System.Drawing.Point(138, 73);
            this.cbFp23.Name = "cbFp23";
            this.cbFp23.Size = new System.Drawing.Size(54, 16);
            this.cbFp23.TabIndex = 63;
            this.cbFp23.Text = "913.5";
            this.cbFp23.UseVisualStyleBackColor = true;
            this.cbFp23.CheckedChanged += new System.EventHandler(this.cbFp21_CheckedChanged);
            // 
            // cbFp48
            // 
            this.cbFp48.AutoSize = true;
            this.cbFp48.Location = new System.Drawing.Point(453, 129);
            this.cbFp48.Name = "cbFp48";
            this.cbFp48.Size = new System.Drawing.Size(54, 16);
            this.cbFp48.TabIndex = 89;
            this.cbFp48.Text = "926.0";
            this.cbFp48.UseVisualStyleBackColor = true;
            this.cbFp48.CheckedChanged += new System.EventHandler(this.cbFp41_CheckedChanged);
            // 
            // cbFp26
            // 
            this.cbFp26.AutoSize = true;
            this.cbFp26.Location = new System.Drawing.Point(327, 73);
            this.cbFp26.Name = "cbFp26";
            this.cbFp26.Size = new System.Drawing.Size(54, 16);
            this.cbFp26.TabIndex = 66;
            this.cbFp26.Text = "915.0";
            this.cbFp26.UseVisualStyleBackColor = true;
            this.cbFp26.CheckedChanged += new System.EventHandler(this.cbFp21_CheckedChanged);
            // 
            // cbFp22
            // 
            this.cbFp22.AutoSize = true;
            this.cbFp22.Location = new System.Drawing.Point(75, 73);
            this.cbFp22.Name = "cbFp22";
            this.cbFp22.Size = new System.Drawing.Size(54, 16);
            this.cbFp22.TabIndex = 62;
            this.cbFp22.Text = "913.0";
            this.cbFp22.UseVisualStyleBackColor = true;
            this.cbFp22.CheckedChanged += new System.EventHandler(this.cbFp21_CheckedChanged);
            // 
            // cbFp47
            // 
            this.cbFp47.AutoSize = true;
            this.cbFp47.Location = new System.Drawing.Point(390, 129);
            this.cbFp47.Name = "cbFp47";
            this.cbFp47.Size = new System.Drawing.Size(54, 16);
            this.cbFp47.TabIndex = 88;
            this.cbFp47.Text = "925.5";
            this.cbFp47.UseVisualStyleBackColor = true;
            this.cbFp47.CheckedChanged += new System.EventHandler(this.cbFp41_CheckedChanged);
            // 
            // cbFp27
            // 
            this.cbFp27.AutoSize = true;
            this.cbFp27.Location = new System.Drawing.Point(390, 73);
            this.cbFp27.Name = "cbFp27";
            this.cbFp27.Size = new System.Drawing.Size(54, 16);
            this.cbFp27.TabIndex = 67;
            this.cbFp27.Text = "915.5";
            this.cbFp27.UseVisualStyleBackColor = true;
            this.cbFp27.CheckedChanged += new System.EventHandler(this.cbFp21_CheckedChanged);
            // 
            // cbFp1
            // 
            this.cbFp1.AutoSize = true;
            this.cbFp1.Location = new System.Drawing.Point(12, 17);
            this.cbFp1.Name = "cbFp1";
            this.cbFp1.Size = new System.Drawing.Size(54, 16);
            this.cbFp1.TabIndex = 38;
            this.cbFp1.Text = "902.5";
            this.cbFp1.UseVisualStyleBackColor = true;
            this.cbFp1.CheckedChanged += new System.EventHandler(this.cbFp1_CheckedChanged);
            // 
            // cbFp21
            // 
            this.cbFp21.AutoSize = true;
            this.cbFp21.Location = new System.Drawing.Point(12, 73);
            this.cbFp21.Name = "cbFp21";
            this.cbFp21.Size = new System.Drawing.Size(54, 16);
            this.cbFp21.TabIndex = 61;
            this.cbFp21.Text = "912.5";
            this.cbFp21.UseVisualStyleBackColor = true;
            this.cbFp21.CheckedChanged += new System.EventHandler(this.cbFp21_CheckedChanged);
            // 
            // cbFp46
            // 
            this.cbFp46.AutoSize = true;
            this.cbFp46.Location = new System.Drawing.Point(327, 129);
            this.cbFp46.Name = "cbFp46";
            this.cbFp46.Size = new System.Drawing.Size(54, 16);
            this.cbFp46.TabIndex = 87;
            this.cbFp46.Text = "925.0";
            this.cbFp46.UseVisualStyleBackColor = true;
            this.cbFp46.CheckedChanged += new System.EventHandler(this.cbFp41_CheckedChanged);
            // 
            // cbFp28
            // 
            this.cbFp28.AutoSize = true;
            this.cbFp28.Location = new System.Drawing.Point(453, 73);
            this.cbFp28.Name = "cbFp28";
            this.cbFp28.Size = new System.Drawing.Size(54, 16);
            this.cbFp28.TabIndex = 68;
            this.cbFp28.Text = "916.0";
            this.cbFp28.UseVisualStyleBackColor = true;
            this.cbFp28.CheckedChanged += new System.EventHandler(this.cbFp21_CheckedChanged);
            // 
            // cbFp2
            // 
            this.cbFp2.AutoSize = true;
            this.cbFp2.Location = new System.Drawing.Point(75, 17);
            this.cbFp2.Name = "cbFp2";
            this.cbFp2.Size = new System.Drawing.Size(54, 16);
            this.cbFp2.TabIndex = 39;
            this.cbFp2.Text = "903.0";
            this.cbFp2.UseVisualStyleBackColor = true;
            this.cbFp2.CheckedChanged += new System.EventHandler(this.cbFp1_CheckedChanged);
            // 
            // cbFp20
            // 
            this.cbFp20.AutoSize = true;
            this.cbFp20.Location = new System.Drawing.Point(579, 45);
            this.cbFp20.Name = "cbFp20";
            this.cbFp20.Size = new System.Drawing.Size(54, 16);
            this.cbFp20.TabIndex = 57;
            this.cbFp20.Text = "912.0";
            this.cbFp20.UseVisualStyleBackColor = true;
            this.cbFp20.CheckedChanged += new System.EventHandler(this.cbFp11_CheckedChanged);
            // 
            // cbFp45
            // 
            this.cbFp45.AutoSize = true;
            this.cbFp45.Location = new System.Drawing.Point(264, 129);
            this.cbFp45.Name = "cbFp45";
            this.cbFp45.Size = new System.Drawing.Size(54, 16);
            this.cbFp45.TabIndex = 86;
            this.cbFp45.Text = "924.5";
            this.cbFp45.UseVisualStyleBackColor = true;
            this.cbFp45.CheckedChanged += new System.EventHandler(this.cbFp41_CheckedChanged);
            // 
            // cbFp29
            // 
            this.cbFp29.AutoSize = true;
            this.cbFp29.Location = new System.Drawing.Point(516, 73);
            this.cbFp29.Name = "cbFp29";
            this.cbFp29.Size = new System.Drawing.Size(54, 16);
            this.cbFp29.TabIndex = 69;
            this.cbFp29.Text = "916.5";
            this.cbFp29.UseVisualStyleBackColor = true;
            this.cbFp29.CheckedChanged += new System.EventHandler(this.cbFp21_CheckedChanged);
            // 
            // cbFp3
            // 
            this.cbFp3.AutoSize = true;
            this.cbFp3.Location = new System.Drawing.Point(138, 17);
            this.cbFp3.Name = "cbFp3";
            this.cbFp3.Size = new System.Drawing.Size(54, 16);
            this.cbFp3.TabIndex = 40;
            this.cbFp3.Text = "903.5";
            this.cbFp3.UseVisualStyleBackColor = true;
            this.cbFp3.CheckedChanged += new System.EventHandler(this.cbFp1_CheckedChanged);
            // 
            // cbFp19
            // 
            this.cbFp19.AutoSize = true;
            this.cbFp19.Location = new System.Drawing.Point(516, 45);
            this.cbFp19.Name = "cbFp19";
            this.cbFp19.Size = new System.Drawing.Size(54, 16);
            this.cbFp19.TabIndex = 56;
            this.cbFp19.Text = "911.5";
            this.cbFp19.UseVisualStyleBackColor = true;
            this.cbFp19.CheckedChanged += new System.EventHandler(this.cbFp11_CheckedChanged);
            // 
            // cbFp44
            // 
            this.cbFp44.AutoSize = true;
            this.cbFp44.Location = new System.Drawing.Point(201, 129);
            this.cbFp44.Name = "cbFp44";
            this.cbFp44.Size = new System.Drawing.Size(54, 16);
            this.cbFp44.TabIndex = 85;
            this.cbFp44.Text = "924.0";
            this.cbFp44.UseVisualStyleBackColor = true;
            this.cbFp44.CheckedChanged += new System.EventHandler(this.cbFp41_CheckedChanged);
            // 
            // cbFp30
            // 
            this.cbFp30.AutoSize = true;
            this.cbFp30.Location = new System.Drawing.Point(579, 73);
            this.cbFp30.Name = "cbFp30";
            this.cbFp30.Size = new System.Drawing.Size(54, 16);
            this.cbFp30.TabIndex = 70;
            this.cbFp30.Text = "917.0";
            this.cbFp30.UseVisualStyleBackColor = true;
            this.cbFp30.CheckedChanged += new System.EventHandler(this.cbFp21_CheckedChanged);
            // 
            // cbFp4
            // 
            this.cbFp4.AutoSize = true;
            this.cbFp4.Location = new System.Drawing.Point(201, 17);
            this.cbFp4.Name = "cbFp4";
            this.cbFp4.Size = new System.Drawing.Size(54, 16);
            this.cbFp4.TabIndex = 41;
            this.cbFp4.Text = "904.0";
            this.cbFp4.UseVisualStyleBackColor = true;
            this.cbFp4.CheckedChanged += new System.EventHandler(this.cbFp1_CheckedChanged);
            // 
            // cbFp18
            // 
            this.cbFp18.AutoSize = true;
            this.cbFp18.Location = new System.Drawing.Point(453, 45);
            this.cbFp18.Name = "cbFp18";
            this.cbFp18.Size = new System.Drawing.Size(54, 16);
            this.cbFp18.TabIndex = 55;
            this.cbFp18.Text = "911.0";
            this.cbFp18.UseVisualStyleBackColor = true;
            this.cbFp18.CheckedChanged += new System.EventHandler(this.cbFp11_CheckedChanged);
            // 
            // cbFp43
            // 
            this.cbFp43.AutoSize = true;
            this.cbFp43.Location = new System.Drawing.Point(138, 129);
            this.cbFp43.Name = "cbFp43";
            this.cbFp43.Size = new System.Drawing.Size(54, 16);
            this.cbFp43.TabIndex = 84;
            this.cbFp43.Text = "923.5";
            this.cbFp43.UseVisualStyleBackColor = true;
            this.cbFp43.CheckedChanged += new System.EventHandler(this.cbFp41_CheckedChanged);
            // 
            // cbFp31
            // 
            this.cbFp31.AutoSize = true;
            this.cbFp31.Location = new System.Drawing.Point(12, 101);
            this.cbFp31.Name = "cbFp31";
            this.cbFp31.Size = new System.Drawing.Size(54, 16);
            this.cbFp31.TabIndex = 71;
            this.cbFp31.Text = "917.5";
            this.cbFp31.UseVisualStyleBackColor = true;
            this.cbFp31.CheckedChanged += new System.EventHandler(this.cbFp31_CheckedChanged);
            // 
            // cbFp5
            // 
            this.cbFp5.AutoSize = true;
            this.cbFp5.Location = new System.Drawing.Point(264, 17);
            this.cbFp5.Name = "cbFp5";
            this.cbFp5.Size = new System.Drawing.Size(54, 16);
            this.cbFp5.TabIndex = 42;
            this.cbFp5.Text = "904.5";
            this.cbFp5.UseVisualStyleBackColor = true;
            this.cbFp5.CheckedChanged += new System.EventHandler(this.cbFp1_CheckedChanged);
            // 
            // cbFp17
            // 
            this.cbFp17.AutoSize = true;
            this.cbFp17.Location = new System.Drawing.Point(390, 45);
            this.cbFp17.Name = "cbFp17";
            this.cbFp17.Size = new System.Drawing.Size(54, 16);
            this.cbFp17.TabIndex = 54;
            this.cbFp17.Text = "910.5";
            this.cbFp17.UseVisualStyleBackColor = true;
            this.cbFp17.CheckedChanged += new System.EventHandler(this.cbFp11_CheckedChanged);
            // 
            // cbFp42
            // 
            this.cbFp42.AutoSize = true;
            this.cbFp42.Location = new System.Drawing.Point(75, 129);
            this.cbFp42.Name = "cbFp42";
            this.cbFp42.Size = new System.Drawing.Size(54, 16);
            this.cbFp42.TabIndex = 83;
            this.cbFp42.Text = "923.0";
            this.cbFp42.UseVisualStyleBackColor = true;
            this.cbFp42.CheckedChanged += new System.EventHandler(this.cbFp41_CheckedChanged);
            // 
            // cbFp32
            // 
            this.cbFp32.AutoSize = true;
            this.cbFp32.Location = new System.Drawing.Point(75, 101);
            this.cbFp32.Name = "cbFp32";
            this.cbFp32.Size = new System.Drawing.Size(54, 16);
            this.cbFp32.TabIndex = 72;
            this.cbFp32.Text = "918.0";
            this.cbFp32.UseVisualStyleBackColor = true;
            this.cbFp32.CheckedChanged += new System.EventHandler(this.cbFp31_CheckedChanged);
            // 
            // cbFp6
            // 
            this.cbFp6.AutoSize = true;
            this.cbFp6.Location = new System.Drawing.Point(327, 17);
            this.cbFp6.Name = "cbFp6";
            this.cbFp6.Size = new System.Drawing.Size(54, 16);
            this.cbFp6.TabIndex = 43;
            this.cbFp6.Text = "905.0";
            this.cbFp6.UseVisualStyleBackColor = true;
            this.cbFp6.CheckedChanged += new System.EventHandler(this.cbFp1_CheckedChanged);
            // 
            // cbFp16
            // 
            this.cbFp16.AutoSize = true;
            this.cbFp16.Location = new System.Drawing.Point(327, 45);
            this.cbFp16.Name = "cbFp16";
            this.cbFp16.Size = new System.Drawing.Size(54, 16);
            this.cbFp16.TabIndex = 53;
            this.cbFp16.Text = "910.0";
            this.cbFp16.UseVisualStyleBackColor = true;
            this.cbFp16.CheckedChanged += new System.EventHandler(this.cbFp11_CheckedChanged);
            // 
            // cbFp41
            // 
            this.cbFp41.AutoSize = true;
            this.cbFp41.Location = new System.Drawing.Point(12, 129);
            this.cbFp41.Name = "cbFp41";
            this.cbFp41.Size = new System.Drawing.Size(54, 16);
            this.cbFp41.TabIndex = 82;
            this.cbFp41.Text = "922.5";
            this.cbFp41.UseVisualStyleBackColor = true;
            this.cbFp41.CheckedChanged += new System.EventHandler(this.cbFp41_CheckedChanged);
            // 
            // cbFp33
            // 
            this.cbFp33.AutoSize = true;
            this.cbFp33.Location = new System.Drawing.Point(138, 101);
            this.cbFp33.Name = "cbFp33";
            this.cbFp33.Size = new System.Drawing.Size(54, 16);
            this.cbFp33.TabIndex = 73;
            this.cbFp33.Text = "918.5";
            this.cbFp33.UseVisualStyleBackColor = true;
            this.cbFp33.CheckedChanged += new System.EventHandler(this.cbFp31_CheckedChanged);
            // 
            // cbFp7
            // 
            this.cbFp7.AutoSize = true;
            this.cbFp7.Location = new System.Drawing.Point(390, 17);
            this.cbFp7.Name = "cbFp7";
            this.cbFp7.Size = new System.Drawing.Size(54, 16);
            this.cbFp7.TabIndex = 44;
            this.cbFp7.Text = "905.5";
            this.cbFp7.UseVisualStyleBackColor = true;
            this.cbFp7.CheckedChanged += new System.EventHandler(this.cbFp1_CheckedChanged);
            // 
            // cbFp15
            // 
            this.cbFp15.AutoSize = true;
            this.cbFp15.Location = new System.Drawing.Point(264, 45);
            this.cbFp15.Name = "cbFp15";
            this.cbFp15.Size = new System.Drawing.Size(54, 16);
            this.cbFp15.TabIndex = 52;
            this.cbFp15.Text = "909.5";
            this.cbFp15.UseVisualStyleBackColor = true;
            this.cbFp15.CheckedChanged += new System.EventHandler(this.cbFp11_CheckedChanged);
            // 
            // cbFp8
            // 
            this.cbFp8.AutoSize = true;
            this.cbFp8.Location = new System.Drawing.Point(453, 17);
            this.cbFp8.Name = "cbFp8";
            this.cbFp8.Size = new System.Drawing.Size(54, 16);
            this.cbFp8.TabIndex = 45;
            this.cbFp8.Text = "906.0";
            this.cbFp8.UseVisualStyleBackColor = true;
            this.cbFp8.CheckedChanged += new System.EventHandler(this.cbFp1_CheckedChanged);
            // 
            // cbFp34
            // 
            this.cbFp34.AutoSize = true;
            this.cbFp34.Location = new System.Drawing.Point(201, 101);
            this.cbFp34.Name = "cbFp34";
            this.cbFp34.Size = new System.Drawing.Size(54, 16);
            this.cbFp34.TabIndex = 74;
            this.cbFp34.Text = "919.0";
            this.cbFp34.UseVisualStyleBackColor = true;
            this.cbFp34.CheckedChanged += new System.EventHandler(this.cbFp31_CheckedChanged);
            // 
            // cbFp40
            // 
            this.cbFp40.AutoSize = true;
            this.cbFp40.Location = new System.Drawing.Point(579, 101);
            this.cbFp40.Name = "cbFp40";
            this.cbFp40.Size = new System.Drawing.Size(54, 16);
            this.cbFp40.TabIndex = 80;
            this.cbFp40.Text = "922.0";
            this.cbFp40.UseVisualStyleBackColor = true;
            this.cbFp40.CheckedChanged += new System.EventHandler(this.cbFp31_CheckedChanged);
            // 
            // cbFp14
            // 
            this.cbFp14.AutoSize = true;
            this.cbFp14.Location = new System.Drawing.Point(201, 45);
            this.cbFp14.Name = "cbFp14";
            this.cbFp14.Size = new System.Drawing.Size(54, 16);
            this.cbFp14.TabIndex = 51;
            this.cbFp14.Text = "909.0";
            this.cbFp14.UseVisualStyleBackColor = true;
            this.cbFp14.CheckedChanged += new System.EventHandler(this.cbFp11_CheckedChanged);
            // 
            // cbFp9
            // 
            this.cbFp9.AutoSize = true;
            this.cbFp9.Location = new System.Drawing.Point(516, 17);
            this.cbFp9.Name = "cbFp9";
            this.cbFp9.Size = new System.Drawing.Size(54, 16);
            this.cbFp9.TabIndex = 46;
            this.cbFp9.Text = "906.5";
            this.cbFp9.UseVisualStyleBackColor = true;
            this.cbFp9.CheckedChanged += new System.EventHandler(this.cbFp1_CheckedChanged);
            // 
            // cbFp35
            // 
            this.cbFp35.AutoSize = true;
            this.cbFp35.Location = new System.Drawing.Point(264, 101);
            this.cbFp35.Name = "cbFp35";
            this.cbFp35.Size = new System.Drawing.Size(54, 16);
            this.cbFp35.TabIndex = 75;
            this.cbFp35.Text = "919.5";
            this.cbFp35.UseVisualStyleBackColor = true;
            this.cbFp35.CheckedChanged += new System.EventHandler(this.cbFp31_CheckedChanged);
            // 
            // cbFp39
            // 
            this.cbFp39.AutoSize = true;
            this.cbFp39.Location = new System.Drawing.Point(516, 101);
            this.cbFp39.Name = "cbFp39";
            this.cbFp39.Size = new System.Drawing.Size(54, 16);
            this.cbFp39.TabIndex = 79;
            this.cbFp39.Text = "921.5";
            this.cbFp39.UseVisualStyleBackColor = true;
            this.cbFp39.CheckedChanged += new System.EventHandler(this.cbFp31_CheckedChanged);
            // 
            // cbFp13
            // 
            this.cbFp13.AutoSize = true;
            this.cbFp13.Location = new System.Drawing.Point(138, 45);
            this.cbFp13.Name = "cbFp13";
            this.cbFp13.Size = new System.Drawing.Size(54, 16);
            this.cbFp13.TabIndex = 50;
            this.cbFp13.Text = "908.5";
            this.cbFp13.UseVisualStyleBackColor = true;
            this.cbFp13.CheckedChanged += new System.EventHandler(this.cbFp11_CheckedChanged);
            // 
            // cbFp10
            // 
            this.cbFp10.AutoSize = true;
            this.cbFp10.Location = new System.Drawing.Point(579, 17);
            this.cbFp10.Name = "cbFp10";
            this.cbFp10.Size = new System.Drawing.Size(54, 16);
            this.cbFp10.TabIndex = 47;
            this.cbFp10.Text = "907.0";
            this.cbFp10.UseVisualStyleBackColor = true;
            this.cbFp10.CheckedChanged += new System.EventHandler(this.cbFp1_CheckedChanged);
            // 
            // cbFp36
            // 
            this.cbFp36.AutoSize = true;
            this.cbFp36.Location = new System.Drawing.Point(327, 101);
            this.cbFp36.Name = "cbFp36";
            this.cbFp36.Size = new System.Drawing.Size(54, 16);
            this.cbFp36.TabIndex = 76;
            this.cbFp36.Text = "920.0";
            this.cbFp36.UseVisualStyleBackColor = true;
            this.cbFp36.CheckedChanged += new System.EventHandler(this.cbFp31_CheckedChanged);
            // 
            // cbFp38
            // 
            this.cbFp38.AutoSize = true;
            this.cbFp38.Location = new System.Drawing.Point(453, 101);
            this.cbFp38.Name = "cbFp38";
            this.cbFp38.Size = new System.Drawing.Size(54, 16);
            this.cbFp38.TabIndex = 78;
            this.cbFp38.Text = "921.0";
            this.cbFp38.UseVisualStyleBackColor = true;
            this.cbFp38.CheckedChanged += new System.EventHandler(this.cbFp31_CheckedChanged);
            // 
            // cbFp12
            // 
            this.cbFp12.AutoSize = true;
            this.cbFp12.Location = new System.Drawing.Point(75, 45);
            this.cbFp12.Name = "cbFp12";
            this.cbFp12.Size = new System.Drawing.Size(54, 16);
            this.cbFp12.TabIndex = 49;
            this.cbFp12.Text = "908.0";
            this.cbFp12.UseVisualStyleBackColor = true;
            this.cbFp12.CheckedChanged += new System.EventHandler(this.cbFp11_CheckedChanged);
            // 
            // cbFp11
            // 
            this.cbFp11.AutoSize = true;
            this.cbFp11.Location = new System.Drawing.Point(12, 45);
            this.cbFp11.Name = "cbFp11";
            this.cbFp11.Size = new System.Drawing.Size(54, 16);
            this.cbFp11.TabIndex = 48;
            this.cbFp11.Text = "907.5";
            this.cbFp11.UseVisualStyleBackColor = true;
            this.cbFp11.CheckedChanged += new System.EventHandler(this.cbFp11_CheckedChanged);
            // 
            // cbFp37
            // 
            this.cbFp37.AutoSize = true;
            this.cbFp37.Location = new System.Drawing.Point(390, 101);
            this.cbFp37.Name = "cbFp37";
            this.cbFp37.Size = new System.Drawing.Size(54, 16);
            this.cbFp37.TabIndex = 77;
            this.cbFp37.Text = "920.5";
            this.cbFp37.UseVisualStyleBackColor = true;
            this.cbFp37.CheckedChanged += new System.EventHandler(this.cbFp31_CheckedChanged);
            // 
            // tpEU_Band
            // 
            this.tpEU_Band.Controls.Add(this.chkFreqEUAll2);
            this.tpEU_Band.Controls.Add(this.chkFreqEUAll1);
            this.tpEU_Band.Controls.Add(this.chkFp12);
            this.tpEU_Band.Controls.Add(this.chkFp11);
            this.tpEU_Band.Controls.Add(this.chkFp1);
            this.tpEU_Band.Controls.Add(this.chkFp8);
            this.tpEU_Band.Controls.Add(this.chkFp2);
            this.tpEU_Band.Controls.Add(this.chkFp10);
            this.tpEU_Band.Controls.Add(this.chkFp4);
            this.tpEU_Band.Controls.Add(this.chkFp9);
            this.tpEU_Band.Controls.Add(this.chkFp5);
            this.tpEU_Band.Controls.Add(this.chkFp7);
            this.tpEU_Band.Controls.Add(this.chkFp3);
            this.tpEU_Band.Controls.Add(this.chkFp6);
            this.tpEU_Band.Location = new System.Drawing.Point(4, 22);
            this.tpEU_Band.Name = "tpEU_Band";
            this.tpEU_Band.Padding = new System.Windows.Forms.Padding(3);
            this.tpEU_Band.Size = new System.Drawing.Size(701, 159);
            this.tpEU_Band.TabIndex = 1;
            this.tpEU_Band.Text = "欧标";
            this.tpEU_Band.UseVisualStyleBackColor = true;
            // 
            // chkFreqEUAll2
            // 
            this.chkFreqEUAll2.AutoSize = true;
            this.chkFreqEUAll2.Location = new System.Drawing.Point(390, 45);
            this.chkFreqEUAll2.Name = "chkFreqEUAll2";
            this.chkFreqEUAll2.Size = new System.Drawing.Size(42, 16);
            this.chkFreqEUAll2.TabIndex = 51;
            this.chkFreqEUAll2.Text = "All";
            this.chkFreqEUAll2.UseVisualStyleBackColor = true;
            this.chkFreqEUAll2.CheckedChanged += new System.EventHandler(this.chkFreqEUAll2_CheckedChanged);
            // 
            // chkFreqEUAll1
            // 
            this.chkFreqEUAll1.AutoSize = true;
            this.chkFreqEUAll1.Location = new System.Drawing.Point(390, 17);
            this.chkFreqEUAll1.Name = "chkFreqEUAll1";
            this.chkFreqEUAll1.Size = new System.Drawing.Size(42, 16);
            this.chkFreqEUAll1.TabIndex = 50;
            this.chkFreqEUAll1.Text = "All";
            this.chkFreqEUAll1.UseVisualStyleBackColor = true;
            this.chkFreqEUAll1.CheckedChanged += new System.EventHandler(this.chkFreqEUAll1_CheckedChanged);
            // 
            // chkFp12
            // 
            this.chkFp12.AutoSize = true;
            this.chkFp12.Location = new System.Drawing.Point(327, 45);
            this.chkFp12.Name = "chkFp12";
            this.chkFp12.Size = new System.Drawing.Size(60, 16);
            this.chkFp12.TabIndex = 49;
            this.chkFp12.Text = "868.05";
            this.chkFp12.UseVisualStyleBackColor = true;
            this.chkFp12.CheckedChanged += new System.EventHandler(this.chkFp7_CheckedChanged);
            // 
            // chkFp11
            // 
            this.chkFp11.AutoSize = true;
            this.chkFp11.Location = new System.Drawing.Point(264, 45);
            this.chkFp11.Name = "chkFp11";
            this.chkFp11.Size = new System.Drawing.Size(60, 16);
            this.chkFp11.TabIndex = 48;
            this.chkFp11.Text = "867.80";
            this.chkFp11.UseVisualStyleBackColor = true;
            this.chkFp11.CheckedChanged += new System.EventHandler(this.chkFp7_CheckedChanged);
            // 
            // chkFp1
            // 
            this.chkFp1.AutoSize = true;
            this.chkFp1.Location = new System.Drawing.Point(12, 17);
            this.chkFp1.Name = "chkFp1";
            this.chkFp1.Size = new System.Drawing.Size(60, 16);
            this.chkFp1.TabIndex = 38;
            this.chkFp1.Text = "865.30";
            this.chkFp1.UseVisualStyleBackColor = true;
            this.chkFp1.CheckedChanged += new System.EventHandler(this.chkFp1_CheckedChanged);
            // 
            // chkFp8
            // 
            this.chkFp8.AutoSize = true;
            this.chkFp8.Location = new System.Drawing.Point(75, 45);
            this.chkFp8.Name = "chkFp8";
            this.chkFp8.Size = new System.Drawing.Size(60, 16);
            this.chkFp8.TabIndex = 45;
            this.chkFp8.Text = "867.05";
            this.chkFp8.UseVisualStyleBackColor = true;
            this.chkFp8.CheckedChanged += new System.EventHandler(this.chkFp7_CheckedChanged);
            // 
            // chkFp2
            // 
            this.chkFp2.AutoSize = true;
            this.chkFp2.Location = new System.Drawing.Point(75, 17);
            this.chkFp2.Name = "chkFp2";
            this.chkFp2.Size = new System.Drawing.Size(60, 16);
            this.chkFp2.TabIndex = 39;
            this.chkFp2.Text = "865.55";
            this.chkFp2.UseVisualStyleBackColor = true;
            this.chkFp2.CheckedChanged += new System.EventHandler(this.chkFp1_CheckedChanged);
            // 
            // chkFp10
            // 
            this.chkFp10.AutoSize = true;
            this.chkFp10.Location = new System.Drawing.Point(201, 45);
            this.chkFp10.Name = "chkFp10";
            this.chkFp10.Size = new System.Drawing.Size(60, 16);
            this.chkFp10.TabIndex = 47;
            this.chkFp10.Text = "867.55";
            this.chkFp10.UseVisualStyleBackColor = true;
            this.chkFp10.CheckedChanged += new System.EventHandler(this.chkFp7_CheckedChanged);
            // 
            // chkFp4
            // 
            this.chkFp4.AutoSize = true;
            this.chkFp4.Location = new System.Drawing.Point(201, 17);
            this.chkFp4.Name = "chkFp4";
            this.chkFp4.Size = new System.Drawing.Size(60, 16);
            this.chkFp4.TabIndex = 41;
            this.chkFp4.Text = "866.05";
            this.chkFp4.UseVisualStyleBackColor = true;
            this.chkFp4.CheckedChanged += new System.EventHandler(this.chkFp1_CheckedChanged);
            // 
            // chkFp9
            // 
            this.chkFp9.AutoSize = true;
            this.chkFp9.Location = new System.Drawing.Point(138, 45);
            this.chkFp9.Name = "chkFp9";
            this.chkFp9.Size = new System.Drawing.Size(60, 16);
            this.chkFp9.TabIndex = 46;
            this.chkFp9.Text = "867.30";
            this.chkFp9.UseVisualStyleBackColor = true;
            this.chkFp9.CheckedChanged += new System.EventHandler(this.chkFp7_CheckedChanged);
            // 
            // chkFp5
            // 
            this.chkFp5.AutoSize = true;
            this.chkFp5.Location = new System.Drawing.Point(264, 17);
            this.chkFp5.Name = "chkFp5";
            this.chkFp5.Size = new System.Drawing.Size(60, 16);
            this.chkFp5.TabIndex = 42;
            this.chkFp5.Text = "866.30";
            this.chkFp5.UseVisualStyleBackColor = true;
            this.chkFp5.CheckedChanged += new System.EventHandler(this.chkFp1_CheckedChanged);
            // 
            // chkFp7
            // 
            this.chkFp7.AutoSize = true;
            this.chkFp7.Location = new System.Drawing.Point(12, 45);
            this.chkFp7.Name = "chkFp7";
            this.chkFp7.Size = new System.Drawing.Size(60, 16);
            this.chkFp7.TabIndex = 44;
            this.chkFp7.Text = "866.80";
            this.chkFp7.UseVisualStyleBackColor = true;
            this.chkFp7.CheckedChanged += new System.EventHandler(this.chkFp7_CheckedChanged);
            // 
            // chkFp3
            // 
            this.chkFp3.AutoSize = true;
            this.chkFp3.Location = new System.Drawing.Point(138, 17);
            this.chkFp3.Name = "chkFp3";
            this.chkFp3.Size = new System.Drawing.Size(60, 16);
            this.chkFp3.TabIndex = 40;
            this.chkFp3.Text = "865.80";
            this.chkFp3.UseVisualStyleBackColor = true;
            this.chkFp3.CheckedChanged += new System.EventHandler(this.chkFp1_CheckedChanged);
            // 
            // chkFp6
            // 
            this.chkFp6.AutoSize = true;
            this.chkFp6.Location = new System.Drawing.Point(327, 17);
            this.chkFp6.Name = "chkFp6";
            this.chkFp6.Size = new System.Drawing.Size(60, 16);
            this.chkFp6.TabIndex = 43;
            this.chkFp6.Text = "866.55";
            this.chkFp6.UseVisualStyleBackColor = true;
            this.chkFp6.CheckedChanged += new System.EventHandler(this.chkFp1_CheckedChanged);
            // 
            // tpKorea_Band
            // 
            this.tpKorea_Band.Controls.Add(this.chkFreqKoreanAll);
            this.tpKorea_Band.Controls.Add(this.chkFreqKorean1);
            this.tpKorea_Band.Controls.Add(this.chkFreqKorean2);
            this.tpKorea_Band.Controls.Add(this.chkFreqKorean4);
            this.tpKorea_Band.Controls.Add(this.chkFreqKorean5);
            this.tpKorea_Band.Controls.Add(this.chkFreqKorean3);
            this.tpKorea_Band.Controls.Add(this.chkFreqKorean6);
            this.tpKorea_Band.Location = new System.Drawing.Point(4, 22);
            this.tpKorea_Band.Name = "tpKorea_Band";
            this.tpKorea_Band.Padding = new System.Windows.Forms.Padding(3);
            this.tpKorea_Band.Size = new System.Drawing.Size(701, 159);
            this.tpKorea_Band.TabIndex = 2;
            this.tpKorea_Band.Text = "韩标";
            this.tpKorea_Band.UseVisualStyleBackColor = true;
            // 
            // chkFreqKoreanAll
            // 
            this.chkFreqKoreanAll.AutoSize = true;
            this.chkFreqKoreanAll.Location = new System.Drawing.Point(390, 17);
            this.chkFreqKoreanAll.Name = "chkFreqKoreanAll";
            this.chkFreqKoreanAll.Size = new System.Drawing.Size(42, 16);
            this.chkFreqKoreanAll.TabIndex = 51;
            this.chkFreqKoreanAll.Text = "All";
            this.chkFreqKoreanAll.UseVisualStyleBackColor = true;
            this.chkFreqKoreanAll.CheckedChanged += new System.EventHandler(this.chkFreqKoreanAll_CheckedChanged);
            // 
            // chkFreqKorean1
            // 
            this.chkFreqKorean1.AutoSize = true;
            this.chkFreqKorean1.Location = new System.Drawing.Point(12, 17);
            this.chkFreqKorean1.Name = "chkFreqKorean1";
            this.chkFreqKorean1.Size = new System.Drawing.Size(54, 16);
            this.chkFreqKorean1.TabIndex = 44;
            this.chkFreqKorean1.Text = "917.3";
            this.chkFreqKorean1.UseVisualStyleBackColor = true;
            this.chkFreqKorean1.CheckedChanged += new System.EventHandler(this.chkFreqKorean1_CheckedChanged);
            // 
            // chkFreqKorean2
            // 
            this.chkFreqKorean2.AutoSize = true;
            this.chkFreqKorean2.Location = new System.Drawing.Point(75, 17);
            this.chkFreqKorean2.Name = "chkFreqKorean2";
            this.chkFreqKorean2.Size = new System.Drawing.Size(54, 16);
            this.chkFreqKorean2.TabIndex = 45;
            this.chkFreqKorean2.Text = "917.9";
            this.chkFreqKorean2.UseVisualStyleBackColor = true;
            this.chkFreqKorean2.CheckedChanged += new System.EventHandler(this.chkFreqKorean1_CheckedChanged);
            // 
            // chkFreqKorean4
            // 
            this.chkFreqKorean4.AutoSize = true;
            this.chkFreqKorean4.Location = new System.Drawing.Point(201, 17);
            this.chkFreqKorean4.Name = "chkFreqKorean4";
            this.chkFreqKorean4.Size = new System.Drawing.Size(54, 16);
            this.chkFreqKorean4.TabIndex = 47;
            this.chkFreqKorean4.Text = "919.1";
            this.chkFreqKorean4.UseVisualStyleBackColor = true;
            this.chkFreqKorean4.CheckedChanged += new System.EventHandler(this.chkFreqKorean1_CheckedChanged);
            // 
            // chkFreqKorean5
            // 
            this.chkFreqKorean5.AutoSize = true;
            this.chkFreqKorean5.Location = new System.Drawing.Point(264, 17);
            this.chkFreqKorean5.Name = "chkFreqKorean5";
            this.chkFreqKorean5.Size = new System.Drawing.Size(54, 16);
            this.chkFreqKorean5.TabIndex = 48;
            this.chkFreqKorean5.Text = "919.7";
            this.chkFreqKorean5.UseVisualStyleBackColor = true;
            this.chkFreqKorean5.CheckedChanged += new System.EventHandler(this.chkFreqKorean1_CheckedChanged);
            // 
            // chkFreqKorean3
            // 
            this.chkFreqKorean3.AutoSize = true;
            this.chkFreqKorean3.Location = new System.Drawing.Point(138, 17);
            this.chkFreqKorean3.Name = "chkFreqKorean3";
            this.chkFreqKorean3.Size = new System.Drawing.Size(54, 16);
            this.chkFreqKorean3.TabIndex = 46;
            this.chkFreqKorean3.Text = "918.5";
            this.chkFreqKorean3.UseVisualStyleBackColor = true;
            this.chkFreqKorean3.CheckedChanged += new System.EventHandler(this.chkFreqKorean1_CheckedChanged);
            // 
            // chkFreqKorean6
            // 
            this.chkFreqKorean6.AutoSize = true;
            this.chkFreqKorean6.Location = new System.Drawing.Point(327, 17);
            this.chkFreqKorean6.Name = "chkFreqKorean6";
            this.chkFreqKorean6.Size = new System.Drawing.Size(54, 16);
            this.chkFreqKorean6.TabIndex = 49;
            this.chkFreqKorean6.Text = "920.3";
            this.chkFreqKorean6.UseVisualStyleBackColor = true;
            this.chkFreqKorean6.CheckedChanged += new System.EventHandler(this.chkFreqKorean1_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 12);
            this.label8.TabIndex = 81;
            // 
            // btnClearFreq
            // 
            this.btnClearFreq.Location = new System.Drawing.Point(453, 269);
            this.btnClearFreq.Name = "btnClearFreq";
            this.btnClearFreq.Size = new System.Drawing.Size(82, 30);
            this.btnClearFreq.TabIndex = 60;
            this.btnClearFreq.Text = "清除频点";
            this.btnClearFreq.UseVisualStyleBackColor = true;
            this.btnClearFreq.Click += new System.EventHandler(this.btnClearFreq_Click);
            // 
            // btnDefaultFreq
            // 
            this.btnDefaultFreq.Location = new System.Drawing.Point(365, 269);
            this.btnDefaultFreq.Name = "btnDefaultFreq";
            this.btnDefaultFreq.Size = new System.Drawing.Size(82, 30);
            this.btnDefaultFreq.TabIndex = 59;
            this.btnDefaultFreq.Text = "默认参数";
            this.btnDefaultFreq.UseVisualStyleBackColor = true;
            this.btnDefaultFreq.Click += new System.EventHandler(this.btnDefaultFreq_Click);
            // 
            // btnReadFreq
            // 
            this.btnReadFreq.Location = new System.Drawing.Point(541, 269);
            this.btnReadFreq.Name = "btnReadFreq";
            this.btnReadFreq.Size = new System.Drawing.Size(82, 30);
            this.btnReadFreq.TabIndex = 58;
            this.btnReadFreq.Text = "读取";
            this.btnReadFreq.UseVisualStyleBackColor = true;
            this.btnReadFreq.Click += new System.EventHandler(this.btnReadFreq_Click);
            // 
            // labFreq
            // 
            this.labFreq.AutoEllipsis = true;
            this.labFreq.Location = new System.Drawing.Point(20, 51);
            this.labFreq.Name = "labFreq";
            this.labFreq.Size = new System.Drawing.Size(87, 22);
            this.labFreq.TabIndex = 37;
            this.labFreq.Text = "频率模式";
            this.labFreq.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbFrequencyBand
            // 
            this.cbbFrequencyBand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFrequencyBand.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbFrequencyBand.FormattingEnabled = true;
            this.cbbFrequencyBand.Location = new System.Drawing.Point(124, 20);
            this.cbbFrequencyBand.Name = "cbbFrequencyBand";
            this.cbbFrequencyBand.Size = new System.Drawing.Size(250, 24);
            this.cbbFrequencyBand.TabIndex = 35;
            this.cbbFrequencyBand.SelectedIndexChanged += new System.EventHandler(this.cboBand_SelectedIndexChanged);
            // 
            // labSetParam
            // 
            this.labSetParam.AutoSize = true;
            this.labSetParam.Location = new System.Drawing.Point(34, 174);
            this.labSetParam.Name = "labSetParam";
            this.labSetParam.Size = new System.Drawing.Size(0, 12);
            this.labSetParam.TabIndex = 14;
            // 
            // btnSetFreq
            // 
            this.btnSetFreq.Location = new System.Drawing.Point(629, 270);
            this.btnSetFreq.Name = "btnSetFreq";
            this.btnSetFreq.Size = new System.Drawing.Size(82, 30);
            this.btnSetFreq.TabIndex = 8;
            this.btnSetFreq.Text = "设置";
            this.btnSetFreq.UseVisualStyleBackColor = true;
            this.btnSetFreq.Click += new System.EventHandler(this.btnSetFreq_Click);
            // 
            // gbCommModeParam
            // 
            this.gbCommModeParam.Controls.Add(this.tbCommMode);
            this.gbCommModeParam.Controls.Add(this.btnDefaultCommMode);
            this.gbCommModeParam.Controls.Add(this.btnReadCommMode);
            this.gbCommModeParam.Controls.Add(this.btnSetCommMode);
            this.gbCommModeParam.Location = new System.Drawing.Point(406, 6);
            this.gbCommModeParam.Name = "gbCommModeParam";
            this.gbCommModeParam.Size = new System.Drawing.Size(335, 222);
            this.gbCommModeParam.TabIndex = 15;
            this.gbCommModeParam.TabStop = false;
            this.gbCommModeParam.Text = "通信方式";
            // 
            // tbCommMode
            // 
            this.tbCommMode.Controls.Add(this.tpRS485_RJ45);
            this.tbCommMode.Controls.Add(this.tpWiegand);
            this.tbCommMode.Controls.Add(this.tpSerialPorts);
            this.tbCommMode.Location = new System.Drawing.Point(10, 16);
            this.tbCommMode.Name = "tbCommMode";
            this.tbCommMode.SelectedIndex = 0;
            this.tbCommMode.Size = new System.Drawing.Size(309, 162);
            this.tbCommMode.TabIndex = 97;
            // 
            // tpRS485_RJ45
            // 
            this.tpRS485_RJ45.Location = new System.Drawing.Point(4, 22);
            this.tpRS485_RJ45.Name = "tpRS485_RJ45";
            this.tpRS485_RJ45.Padding = new System.Windows.Forms.Padding(3);
            this.tpRS485_RJ45.Size = new System.Drawing.Size(301, 136);
            this.tpRS485_RJ45.TabIndex = 0;
            this.tpRS485_RJ45.Text = "RS485/RJ45";
            this.tpRS485_RJ45.UseVisualStyleBackColor = true;
            // 
            // tpWiegand
            // 
            this.tpWiegand.Controls.Add(this.labPulseWidthUnit);
            this.tpWiegand.Controls.Add(this.labPulseWidth);
            this.tpWiegand.Controls.Add(this.labPulseCycleUnit);
            this.tpWiegand.Controls.Add(this.lblWigginsTakePlaceValue);
            this.tpWiegand.Controls.Add(this.tbPulseWidth);
            this.tpWiegand.Controls.Add(this.cbbWigginsTakePlaceValue);
            this.tpWiegand.Controls.Add(this.labWiegandProtocol);
            this.tpWiegand.Controls.Add(this.tbPulseCycle);
            this.tpWiegand.Controls.Add(this.labPulseCycle);
            this.tpWiegand.Controls.Add(this.cbbWiegandProtocol);
            this.tpWiegand.Location = new System.Drawing.Point(4, 22);
            this.tpWiegand.Name = "tpWiegand";
            this.tpWiegand.Padding = new System.Windows.Forms.Padding(3);
            this.tpWiegand.Size = new System.Drawing.Size(301, 136);
            this.tpWiegand.TabIndex = 1;
            this.tpWiegand.Text = "韦根";
            this.tpWiegand.UseVisualStyleBackColor = true;
            // 
            // labPulseWidthUnit
            // 
            this.labPulseWidthUnit.AutoEllipsis = true;
            this.labPulseWidthUnit.Location = new System.Drawing.Point(219, 8);
            this.labPulseWidthUnit.Name = "labPulseWidthUnit";
            this.labPulseWidthUnit.Size = new System.Drawing.Size(80, 27);
            this.labPulseWidthUnit.TabIndex = 25;
            this.labPulseWidthUnit.Text = "*10微秒";
            this.labPulseWidthUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labPulseWidth
            // 
            this.labPulseWidth.AutoEllipsis = true;
            this.labPulseWidth.Location = new System.Drawing.Point(9, 8);
            this.labPulseWidth.Name = "labPulseWidth";
            this.labPulseWidth.Size = new System.Drawing.Size(102, 27);
            this.labPulseWidth.TabIndex = 26;
            this.labPulseWidth.Text = "脉冲宽度";
            this.labPulseWidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labPulseCycleUnit
            // 
            this.labPulseCycleUnit.AutoEllipsis = true;
            this.labPulseCycleUnit.Location = new System.Drawing.Point(221, 40);
            this.labPulseCycleUnit.Name = "labPulseCycleUnit";
            this.labPulseCycleUnit.Size = new System.Drawing.Size(78, 27);
            this.labPulseCycleUnit.TabIndex = 33;
            this.labPulseCycleUnit.Text = "*100微秒";
            this.labPulseCycleUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWigginsTakePlaceValue
            // 
            this.lblWigginsTakePlaceValue.AutoEllipsis = true;
            this.lblWigginsTakePlaceValue.Location = new System.Drawing.Point(9, 101);
            this.lblWigginsTakePlaceValue.Name = "lblWigginsTakePlaceValue";
            this.lblWigginsTakePlaceValue.Size = new System.Drawing.Size(102, 27);
            this.lblWigginsTakePlaceValue.TabIndex = 31;
            this.lblWigginsTakePlaceValue.Text = "韦根取位值";
            this.lblWigginsTakePlaceValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPulseWidth
            // 
            this.tbPulseWidth.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPulseWidth.Location = new System.Drawing.Point(115, 10);
            this.tbPulseWidth.Name = "tbPulseWidth";
            this.tbPulseWidth.Size = new System.Drawing.Size(98, 23);
            this.tbPulseWidth.TabIndex = 25;
            // 
            // cbbWigginsTakePlaceValue
            // 
            this.cbbWigginsTakePlaceValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbWigginsTakePlaceValue.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbWigginsTakePlaceValue.FormattingEnabled = true;
            this.cbbWigginsTakePlaceValue.Location = new System.Drawing.Point(115, 102);
            this.cbbWigginsTakePlaceValue.Name = "cbbWigginsTakePlaceValue";
            this.cbbWigginsTakePlaceValue.Size = new System.Drawing.Size(98, 24);
            this.cbbWigginsTakePlaceValue.TabIndex = 30;
            // 
            // labWiegandProtocol
            // 
            this.labWiegandProtocol.AutoEllipsis = true;
            this.labWiegandProtocol.Location = new System.Drawing.Point(9, 69);
            this.labWiegandProtocol.Name = "labWiegandProtocol";
            this.labWiegandProtocol.Size = new System.Drawing.Size(102, 30);
            this.labWiegandProtocol.TabIndex = 31;
            this.labWiegandProtocol.Text = "韦根协议";
            this.labWiegandProtocol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPulseCycle
            // 
            this.tbPulseCycle.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPulseCycle.Location = new System.Drawing.Point(115, 42);
            this.tbPulseCycle.Name = "tbPulseCycle";
            this.tbPulseCycle.Size = new System.Drawing.Size(98, 23);
            this.tbPulseCycle.TabIndex = 32;
            // 
            // labPulseCycle
            // 
            this.labPulseCycle.AutoEllipsis = true;
            this.labPulseCycle.Location = new System.Drawing.Point(9, 40);
            this.labPulseCycle.Name = "labPulseCycle";
            this.labPulseCycle.Size = new System.Drawing.Size(102, 27);
            this.labPulseCycle.TabIndex = 29;
            this.labPulseCycle.Text = "脉冲周期";
            this.labPulseCycle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbWiegandProtocol
            // 
            this.cbbWiegandProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbWiegandProtocol.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbWiegandProtocol.FormattingEnabled = true;
            this.cbbWiegandProtocol.Location = new System.Drawing.Point(115, 72);
            this.cbbWiegandProtocol.Name = "cbbWiegandProtocol";
            this.cbbWiegandProtocol.Size = new System.Drawing.Size(98, 24);
            this.cbbWiegandProtocol.TabIndex = 30;
            // 
            // tpSerialPorts
            // 
            this.tpSerialPorts.Controls.Add(this.cbbBaud_Rate);
            this.tpSerialPorts.Controls.Add(this.lbl_rate);
            this.tpSerialPorts.Location = new System.Drawing.Point(4, 22);
            this.tpSerialPorts.Name = "tpSerialPorts";
            this.tpSerialPorts.Padding = new System.Windows.Forms.Padding(3);
            this.tpSerialPorts.Size = new System.Drawing.Size(301, 136);
            this.tpSerialPorts.TabIndex = 2;
            this.tpSerialPorts.Text = "串口";
            this.tpSerialPorts.UseVisualStyleBackColor = true;
            // 
            // cbbBaud_Rate
            // 
            this.cbbBaud_Rate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBaud_Rate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbBaud_Rate.FormattingEnabled = true;
            this.cbbBaud_Rate.Location = new System.Drawing.Point(100, 36);
            this.cbbBaud_Rate.Name = "cbbBaud_Rate";
            this.cbbBaud_Rate.Size = new System.Drawing.Size(95, 24);
            this.cbbBaud_Rate.TabIndex = 36;
            // 
            // lbl_rate
            // 
            this.lbl_rate.Location = new System.Drawing.Point(8, 35);
            this.lbl_rate.Name = "lbl_rate";
            this.lbl_rate.Size = new System.Drawing.Size(86, 27);
            this.lbl_rate.TabIndex = 37;
            this.lbl_rate.Text = "波特率";
            this.lbl_rate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDefaultCommMode
            // 
            this.btnDefaultCommMode.Location = new System.Drawing.Point(57, 184);
            this.btnDefaultCommMode.Name = "btnDefaultCommMode";
            this.btnDefaultCommMode.Size = new System.Drawing.Size(82, 30);
            this.btnDefaultCommMode.TabIndex = 26;
            this.btnDefaultCommMode.Text = "默认参数";
            this.btnDefaultCommMode.UseVisualStyleBackColor = true;
            this.btnDefaultCommMode.Click += new System.EventHandler(this.btnDefaultCommMode_Click);
            // 
            // btnReadCommMode
            // 
            this.btnReadCommMode.Location = new System.Drawing.Point(145, 184);
            this.btnReadCommMode.Name = "btnReadCommMode";
            this.btnReadCommMode.Size = new System.Drawing.Size(82, 30);
            this.btnReadCommMode.TabIndex = 27;
            this.btnReadCommMode.Text = "读取";
            this.btnReadCommMode.UseVisualStyleBackColor = true;
            this.btnReadCommMode.Click += new System.EventHandler(this.btnReadCommMode_Click);
            // 
            // btnSetCommMode
            // 
            this.btnSetCommMode.Location = new System.Drawing.Point(233, 184);
            this.btnSetCommMode.Name = "btnSetCommMode";
            this.btnSetCommMode.Size = new System.Drawing.Size(82, 30);
            this.btnSetCommMode.TabIndex = 25;
            this.btnSetCommMode.Text = "设置";
            this.btnSetCommMode.UseVisualStyleBackColor = true;
            this.btnSetCommMode.Click += new System.EventHandler(this.btnSetCommMode_Click);
            // 
            // gbWorkMode
            // 
            this.gbWorkMode.Controls.Add(this.tbWorkMode);
            this.gbWorkMode.Controls.Add(this.chkAjaDisc);
            this.gbWorkMode.Controls.Add(this.btnDefaultWorkMode);
            this.gbWorkMode.Controls.Add(this.btnReadWorkMode);
            this.gbWorkMode.Controls.Add(this.btnSetWorkMode);
            this.gbWorkMode.Controls.Add(this.tbNeighJudge);
            this.gbWorkMode.Location = new System.Drawing.Point(14, 6);
            this.gbWorkMode.Name = "gbWorkMode";
            this.gbWorkMode.Size = new System.Drawing.Size(315, 222);
            this.gbWorkMode.TabIndex = 13;
            this.gbWorkMode.TabStop = false;
            this.gbWorkMode.Text = "工作模式";
            // 
            // tbWorkMode
            // 
            this.tbWorkMode.Controls.Add(this.tpMaster);
            this.tbWorkMode.Controls.Add(this.tpTiming);
            this.tbWorkMode.Controls.Add(this.tpTrigger);
            this.tbWorkMode.Location = new System.Drawing.Point(22, 47);
            this.tbWorkMode.Name = "tbWorkMode";
            this.tbWorkMode.SelectedIndex = 0;
            this.tbWorkMode.Size = new System.Drawing.Size(280, 124);
            this.tbWorkMode.TabIndex = 97;
            this.tbWorkMode.SelectedIndexChanged += new System.EventHandler(this.tbWorkMode_SelectedIndexChanged);
            // 
            // tpMaster
            // 
            this.tpMaster.Location = new System.Drawing.Point(4, 22);
            this.tpMaster.Name = "tpMaster";
            this.tpMaster.Padding = new System.Windows.Forms.Padding(3);
            this.tpMaster.Size = new System.Drawing.Size(272, 98);
            this.tpMaster.TabIndex = 0;
            this.tpMaster.Text = "主从模式";
            this.tpMaster.UseVisualStyleBackColor = true;
            // 
            // tpTiming
            // 
            this.tpTiming.Controls.Add(this.cbbReadSpeed);
            this.tpTiming.Controls.Add(this.labTimingUnit);
            this.tpTiming.Controls.Add(this.labTimingParam);
            this.tpTiming.Controls.Add(this.tbTiming);
            this.tpTiming.Location = new System.Drawing.Point(4, 22);
            this.tpTiming.Name = "tpTiming";
            this.tpTiming.Padding = new System.Windows.Forms.Padding(3);
            this.tpTiming.Size = new System.Drawing.Size(272, 98);
            this.tpTiming.TabIndex = 1;
            this.tpTiming.Text = "定时模式";
            this.tpTiming.UseVisualStyleBackColor = true;
            // 
            // cbbReadSpeed
            // 
            this.cbbReadSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbReadSpeed.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbReadSpeed.FormattingEnabled = true;
            this.cbbReadSpeed.Items.AddRange(new object[] {
            "1",
            "10"});
            this.cbbReadSpeed.Location = new System.Drawing.Point(113, 46);
            this.cbbReadSpeed.Name = "cbbReadSpeed";
            this.cbbReadSpeed.Size = new System.Drawing.Size(61, 24);
            this.cbbReadSpeed.TabIndex = 25;
            // 
            // labTimingUnit
            // 
            this.labTimingUnit.Location = new System.Drawing.Point(180, 45);
            this.labTimingUnit.Name = "labTimingUnit";
            this.labTimingUnit.Size = new System.Drawing.Size(39, 27);
            this.labTimingUnit.TabIndex = 21;
            this.labTimingUnit.Text = "毫秒";
            this.labTimingUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labTimingParam
            // 
            this.labTimingParam.AutoEllipsis = true;
            this.labTimingParam.Location = new System.Drawing.Point(3, 11);
            this.labTimingParam.Name = "labTimingParam";
            this.labTimingParam.Size = new System.Drawing.Size(104, 27);
            this.labTimingParam.TabIndex = 14;
            this.labTimingParam.Text = "定时间隔";
            this.labTimingParam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbTiming
            // 
            this.tbTiming.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbTiming.Location = new System.Drawing.Point(21, 45);
            this.tbTiming.Name = "tbTiming";
            this.tbTiming.Size = new System.Drawing.Size(86, 26);
            this.tbTiming.TabIndex = 19;
            // 
            // tpTrigger
            // 
            this.tpTrigger.Controls.Add(this.labDelayUnit);
            this.tpTrigger.Controls.Add(this.labTrigParam);
            this.tpTrigger.Controls.Add(this.tbDelay);
            this.tpTrigger.Controls.Add(this.cbbTrigSwitch);
            this.tpTrigger.Controls.Add(this.labTrigSwitch);
            this.tpTrigger.Location = new System.Drawing.Point(4, 22);
            this.tpTrigger.Name = "tpTrigger";
            this.tpTrigger.Padding = new System.Windows.Forms.Padding(3);
            this.tpTrigger.Size = new System.Drawing.Size(272, 98);
            this.tpTrigger.TabIndex = 2;
            this.tpTrigger.Text = "触发模式";
            this.tpTrigger.UseVisualStyleBackColor = true;
            // 
            // labDelayUnit
            // 
            this.labDelayUnit.Location = new System.Drawing.Point(220, 19);
            this.labDelayUnit.Name = "labDelayUnit";
            this.labDelayUnit.Size = new System.Drawing.Size(45, 27);
            this.labDelayUnit.TabIndex = 22;
            this.labDelayUnit.Text = "秒";
            this.labDelayUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labTrigParam
            // 
            this.labTrigParam.AutoEllipsis = true;
            this.labTrigParam.Location = new System.Drawing.Point(8, 19);
            this.labTrigParam.Name = "labTrigParam";
            this.labTrigParam.Size = new System.Drawing.Size(78, 27);
            this.labTrigParam.TabIndex = 16;
            this.labTrigParam.Text = "触发延时";
            this.labTrigParam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbDelay
            // 
            this.tbDelay.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbDelay.Location = new System.Drawing.Point(92, 19);
            this.tbDelay.Name = "tbDelay";
            this.tbDelay.Size = new System.Drawing.Size(121, 26);
            this.tbDelay.TabIndex = 20;
            // 
            // cbbTrigSwitch
            // 
            this.cbbTrigSwitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTrigSwitch.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbTrigSwitch.FormattingEnabled = true;
            this.cbbTrigSwitch.Location = new System.Drawing.Point(92, 51);
            this.cbbTrigSwitch.Name = "cbbTrigSwitch";
            this.cbbTrigSwitch.Size = new System.Drawing.Size(121, 24);
            this.cbbTrigSwitch.TabIndex = 17;
            // 
            // labTrigSwitch
            // 
            this.labTrigSwitch.AutoEllipsis = true;
            this.labTrigSwitch.Location = new System.Drawing.Point(8, 50);
            this.labTrigSwitch.Name = "labTrigSwitch";
            this.labTrigSwitch.Size = new System.Drawing.Size(78, 27);
            this.labTrigSwitch.TabIndex = 15;
            this.labTrigSwitch.Text = "触发开关";
            this.labTrigSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAjaDisc
            // 
            this.chkAjaDisc.Location = new System.Drawing.Point(22, 20);
            this.chkAjaDisc.Name = "chkAjaDisc";
            this.chkAjaDisc.Size = new System.Drawing.Size(90, 22);
            this.chkAjaDisc.TabIndex = 24;
            this.chkAjaDisc.Text = "相邻判定";
            this.chkAjaDisc.UseVisualStyleBackColor = true;
            this.chkAjaDisc.CheckedChanged += new System.EventHandler(this.chkAjaDisc_CheckedChanged);
            // 
            // btnDefaultWorkMode
            // 
            this.btnDefaultWorkMode.Location = new System.Drawing.Point(32, 184);
            this.btnDefaultWorkMode.Name = "btnDefaultWorkMode";
            this.btnDefaultWorkMode.Size = new System.Drawing.Size(82, 30);
            this.btnDefaultWorkMode.TabIndex = 15;
            this.btnDefaultWorkMode.Text = "默认参数";
            this.btnDefaultWorkMode.UseVisualStyleBackColor = true;
            this.btnDefaultWorkMode.Click += new System.EventHandler(this.btnDefaultWorkMode_Click);
            // 
            // btnReadWorkMode
            // 
            this.btnReadWorkMode.Location = new System.Drawing.Point(126, 184);
            this.btnReadWorkMode.Name = "btnReadWorkMode";
            this.btnReadWorkMode.Size = new System.Drawing.Size(82, 30);
            this.btnReadWorkMode.TabIndex = 23;
            this.btnReadWorkMode.Text = "读取";
            this.btnReadWorkMode.UseVisualStyleBackColor = true;
            this.btnReadWorkMode.Click += new System.EventHandler(this.btnReadWorkMode_Click);
            // 
            // btnSetWorkMode
            // 
            this.btnSetWorkMode.Location = new System.Drawing.Point(220, 184);
            this.btnSetWorkMode.Name = "btnSetWorkMode";
            this.btnSetWorkMode.Size = new System.Drawing.Size(82, 30);
            this.btnSetWorkMode.TabIndex = 12;
            this.btnSetWorkMode.Text = "设置";
            this.btnSetWorkMode.UseVisualStyleBackColor = true;
            this.btnSetWorkMode.Click += new System.EventHandler(this.btnSetWorkMode_Click);
            // 
            // tbNeighJudge
            // 
            this.tbNeighJudge.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbNeighJudge.Location = new System.Drawing.Point(124, 20);
            this.tbNeighJudge.Name = "tbNeighJudge";
            this.tbNeighJudge.Size = new System.Drawing.Size(96, 23);
            this.tbNeighJudge.TabIndex = 1;
            // 
            // SetCommParam
            // 
            this.SetCommParam.Controls.Add(this.gbSPParams);
            this.SetCommParam.Controls.Add(this.gbNetParams);
            this.SetCommParam.Controls.Add(this.btnSetParams);
            this.SetCommParam.Controls.Add(this.btnDefaultParams);
            this.SetCommParam.Controls.Add(this.btnModifyDev);
            this.SetCommParam.Controls.Add(this.btnSearchDev);
            this.SetCommParam.Controls.Add(this.lvZl);
            this.SetCommParam.Location = new System.Drawing.Point(4, 22);
            this.SetCommParam.Name = "SetCommParam";
            this.SetCommParam.Padding = new System.Windows.Forms.Padding(3);
            this.SetCommParam.Size = new System.Drawing.Size(757, 546);
            this.SetCommParam.TabIndex = 2;
            this.SetCommParam.Text = "设置通信参数";
            this.SetCommParam.UseVisualStyleBackColor = true;
            // 
            // gbSPParams
            // 
            this.gbSPParams.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSPParams.Controls.Add(this.labDataBits);
            this.gbSPParams.Controls.Add(this.labCheckBits);
            this.gbSPParams.Controls.Add(this.labBaudRate);
            this.gbSPParams.Controls.Add(this.comboBoxBaudRate);
            this.gbSPParams.Controls.Add(this.comboBoxCheckBits);
            this.gbSPParams.Controls.Add(this.comboBoxDataBits);
            this.gbSPParams.Location = new System.Drawing.Point(399, 434);
            this.gbSPParams.Name = "gbSPParams";
            this.gbSPParams.Size = new System.Drawing.Size(339, 103);
            this.gbSPParams.TabIndex = 28;
            this.gbSPParams.TabStop = false;
            this.gbSPParams.Text = "串口参数";
            // 
            // labDataBits
            // 
            this.labDataBits.AutoSize = true;
            this.labDataBits.Location = new System.Drawing.Point(17, 70);
            this.labDataBits.Name = "labDataBits";
            this.labDataBits.Size = new System.Drawing.Size(41, 12);
            this.labDataBits.TabIndex = 27;
            this.labDataBits.Text = "数据位";
            // 
            // labCheckBits
            // 
            this.labCheckBits.AutoSize = true;
            this.labCheckBits.Location = new System.Drawing.Point(204, 26);
            this.labCheckBits.Name = "labCheckBits";
            this.labCheckBits.Size = new System.Drawing.Size(41, 12);
            this.labCheckBits.TabIndex = 26;
            this.labCheckBits.Text = "校验位";
            // 
            // labBaudRate
            // 
            this.labBaudRate.AutoSize = true;
            this.labBaudRate.Location = new System.Drawing.Point(14, 26);
            this.labBaudRate.Name = "labBaudRate";
            this.labBaudRate.Size = new System.Drawing.Size(41, 12);
            this.labBaudRate.TabIndex = 25;
            this.labBaudRate.Text = "波特率";
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaudRate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Location = new System.Drawing.Point(82, 20);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(102, 24);
            this.comboBoxBaudRate.TabIndex = 7;
            // 
            // comboBoxCheckBits
            // 
            this.comboBoxCheckBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCheckBits.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxCheckBits.FormattingEnabled = true;
            this.comboBoxCheckBits.Location = new System.Drawing.Point(254, 20);
            this.comboBoxCheckBits.Name = "comboBoxCheckBits";
            this.comboBoxCheckBits.Size = new System.Drawing.Size(74, 24);
            this.comboBoxCheckBits.TabIndex = 6;
            // 
            // comboBoxDataBits
            // 
            this.comboBoxDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataBits.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxDataBits.FormattingEnabled = true;
            this.comboBoxDataBits.Location = new System.Drawing.Point(82, 64);
            this.comboBoxDataBits.Name = "comboBoxDataBits";
            this.comboBoxDataBits.Size = new System.Drawing.Size(102, 24);
            this.comboBoxDataBits.TabIndex = 5;
            // 
            // gbNetParams
            // 
            this.gbNetParams.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbNetParams.Controls.Add(this.cbbDestIP);
            this.gbNetParams.Controls.Add(this.labPromotion);
            this.gbNetParams.Controls.Add(this.labDestPort);
            this.gbNetParams.Controls.Add(this.labDestIP);
            this.gbNetParams.Controls.Add(this.labGateway);
            this.gbNetParams.Controls.Add(this.labPort);
            this.gbNetParams.Controls.Add(this.labMask);
            this.gbNetParams.Controls.Add(this.labIPAdd);
            this.gbNetParams.Controls.Add(this.labIPMode);
            this.gbNetParams.Controls.Add(this.labNetMode);
            this.gbNetParams.Controls.Add(this.textBoxDestPort);
            this.gbNetParams.Controls.Add(this.tbDestIP);
            this.gbNetParams.Controls.Add(this.textBoxGateway);
            this.gbNetParams.Controls.Add(this.textBoxPortNo);
            this.gbNetParams.Controls.Add(this.textBoxNetMask);
            this.gbNetParams.Controls.Add(this.textBoxIPAdd);
            this.gbNetParams.Controls.Add(this.comboBoxIPMode);
            this.gbNetParams.Controls.Add(this.comboBoxNetMode);
            this.gbNetParams.Location = new System.Drawing.Point(399, 15);
            this.gbNetParams.Name = "gbNetParams";
            this.gbNetParams.Size = new System.Drawing.Size(339, 374);
            this.gbNetParams.TabIndex = 25;
            this.gbNetParams.TabStop = false;
            this.gbNetParams.Text = "网络参数";
            // 
            // cbbDestIP
            // 
            this.cbbDestIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbDestIP.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbDestIP.FormattingEnabled = true;
            this.cbbDestIP.Location = new System.Drawing.Point(181, 287);
            this.cbbDestIP.Name = "cbbDestIP";
            this.cbbDestIP.Size = new System.Drawing.Size(142, 24);
            this.cbbDestIP.TabIndex = 42;
            // 
            // labPromotion
            // 
            this.labPromotion.AutoSize = true;
            this.labPromotion.Location = new System.Drawing.Point(46, 259);
            this.labPromotion.Name = "labPromotion";
            this.labPromotion.Size = new System.Drawing.Size(185, 12);
            this.labPromotion.TabIndex = 24;
            this.labPromotion.Text = "以下设置仅适用于TCP Client模式";
            // 
            // labDestPort
            // 
            this.labDestPort.AutoSize = true;
            this.labDestPort.Location = new System.Drawing.Point(48, 330);
            this.labDestPort.Name = "labDestPort";
            this.labDestPort.Size = new System.Drawing.Size(53, 12);
            this.labDestPort.TabIndex = 23;
            this.labDestPort.Text = "目的端口";
            // 
            // labDestIP
            // 
            this.labDestIP.Location = new System.Drawing.Point(6, 286);
            this.labDestIP.Name = "labDestIP";
            this.labDestIP.Size = new System.Drawing.Size(169, 27);
            this.labDestIP.TabIndex = 22;
            this.labDestIP.Text = "目的IP(单击获本机IP)";
            this.labDestIP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labDestIP.Click += new System.EventHandler(this.labDestIP_Click);
            // 
            // labGateway
            // 
            this.labGateway.AutoSize = true;
            this.labGateway.Location = new System.Drawing.Point(48, 219);
            this.labGateway.Name = "labGateway";
            this.labGateway.Size = new System.Drawing.Size(29, 12);
            this.labGateway.TabIndex = 21;
            this.labGateway.Text = "网关";
            // 
            // labPort
            // 
            this.labPort.AutoSize = true;
            this.labPort.Location = new System.Drawing.Point(48, 178);
            this.labPort.Name = "labPort";
            this.labPort.Size = new System.Drawing.Size(41, 12);
            this.labPort.TabIndex = 20;
            this.labPort.Text = "端口号";
            // 
            // labMask
            // 
            this.labMask.AutoSize = true;
            this.labMask.Location = new System.Drawing.Point(48, 142);
            this.labMask.Name = "labMask";
            this.labMask.Size = new System.Drawing.Size(53, 12);
            this.labMask.TabIndex = 19;
            this.labMask.Text = "子网掩码";
            // 
            // labIPAdd
            // 
            this.labIPAdd.AutoSize = true;
            this.labIPAdd.Location = new System.Drawing.Point(48, 101);
            this.labIPAdd.Name = "labIPAdd";
            this.labIPAdd.Size = new System.Drawing.Size(41, 12);
            this.labIPAdd.TabIndex = 18;
            this.labIPAdd.Text = "IP地址";
            // 
            // labIPMode
            // 
            this.labIPMode.AutoSize = true;
            this.labIPMode.Location = new System.Drawing.Point(48, 66);
            this.labIPMode.Name = "labIPMode";
            this.labIPMode.Size = new System.Drawing.Size(41, 12);
            this.labIPMode.TabIndex = 17;
            this.labIPMode.Text = "IP模式";
            // 
            // labNetMode
            // 
            this.labNetMode.AutoSize = true;
            this.labNetMode.Location = new System.Drawing.Point(48, 31);
            this.labNetMode.Name = "labNetMode";
            this.labNetMode.Size = new System.Drawing.Size(53, 12);
            this.labNetMode.TabIndex = 16;
            this.labNetMode.Text = "工作模式";
            // 
            // textBoxDestPort
            // 
            this.textBoxDestPort.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxDestPort.Location = new System.Drawing.Point(181, 327);
            this.textBoxDestPort.Name = "textBoxDestPort";
            this.textBoxDestPort.Size = new System.Drawing.Size(142, 26);
            this.textBoxDestPort.TabIndex = 13;
            // 
            // tbDestIP
            // 
            this.tbDestIP.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbDestIP.Location = new System.Drawing.Point(181, 286);
            this.tbDestIP.Name = "tbDestIP";
            this.tbDestIP.Size = new System.Drawing.Size(142, 26);
            this.tbDestIP.TabIndex = 12;
            this.tbDestIP.Visible = false;
            // 
            // textBoxGateway
            // 
            this.textBoxGateway.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxGateway.Location = new System.Drawing.Point(181, 215);
            this.textBoxGateway.Name = "textBoxGateway";
            this.textBoxGateway.Size = new System.Drawing.Size(142, 26);
            this.textBoxGateway.TabIndex = 11;
            // 
            // textBoxPortNo
            // 
            this.textBoxPortNo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPortNo.Location = new System.Drawing.Point(181, 175);
            this.textBoxPortNo.Name = "textBoxPortNo";
            this.textBoxPortNo.Size = new System.Drawing.Size(142, 26);
            this.textBoxPortNo.TabIndex = 10;
            // 
            // textBoxNetMask
            // 
            this.textBoxNetMask.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxNetMask.Location = new System.Drawing.Point(181, 138);
            this.textBoxNetMask.Name = "textBoxNetMask";
            this.textBoxNetMask.Size = new System.Drawing.Size(142, 26);
            this.textBoxNetMask.TabIndex = 9;
            // 
            // textBoxIPAdd
            // 
            this.textBoxIPAdd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxIPAdd.Location = new System.Drawing.Point(181, 98);
            this.textBoxIPAdd.Name = "textBoxIPAdd";
            this.textBoxIPAdd.Size = new System.Drawing.Size(142, 26);
            this.textBoxIPAdd.TabIndex = 8;
            // 
            // comboBoxIPMode
            // 
            this.comboBoxIPMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIPMode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxIPMode.FormattingEnabled = true;
            this.comboBoxIPMode.Location = new System.Drawing.Point(182, 63);
            this.comboBoxIPMode.Name = "comboBoxIPMode";
            this.comboBoxIPMode.Size = new System.Drawing.Size(142, 24);
            this.comboBoxIPMode.TabIndex = 4;
            // 
            // comboBoxNetMode
            // 
            this.comboBoxNetMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNetMode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxNetMode.FormattingEnabled = true;
            this.comboBoxNetMode.Location = new System.Drawing.Point(181, 28);
            this.comboBoxNetMode.Name = "comboBoxNetMode";
            this.comboBoxNetMode.Size = new System.Drawing.Size(142, 24);
            this.comboBoxNetMode.TabIndex = 3;
            // 
            // btnSetParams
            // 
            this.btnSetParams.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetParams.Location = new System.Drawing.Point(622, 396);
            this.btnSetParams.Name = "btnSetParams";
            this.btnSetParams.Size = new System.Drawing.Size(100, 35);
            this.btnSetParams.TabIndex = 15;
            this.btnSetParams.Text = "设置参数";
            this.btnSetParams.UseVisualStyleBackColor = true;
            this.btnSetParams.Click += new System.EventHandler(this.btnSetParams_Click);
            // 
            // btnDefaultParams
            // 
            this.btnDefaultParams.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDefaultParams.Location = new System.Drawing.Point(468, 397);
            this.btnDefaultParams.Name = "btnDefaultParams";
            this.btnDefaultParams.Size = new System.Drawing.Size(100, 35);
            this.btnDefaultParams.TabIndex = 14;
            this.btnDefaultParams.Text = "默认参数";
            this.btnDefaultParams.UseVisualStyleBackColor = true;
            this.btnDefaultParams.Click += new System.EventHandler(this.btnDefaultParams_Click);
            // 
            // btnModifyDev
            // 
            this.btnModifyDev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModifyDev.Location = new System.Drawing.Point(187, 505);
            this.btnModifyDev.Name = "btnModifyDev";
            this.btnModifyDev.Size = new System.Drawing.Size(100, 35);
            this.btnModifyDev.TabIndex = 2;
            this.btnModifyDev.Text = "编辑设备";
            this.btnModifyDev.UseVisualStyleBackColor = true;
            this.btnModifyDev.Visible = false;
            this.btnModifyDev.Click += new System.EventHandler(this.btnModifyDev_Click);
            // 
            // btnSearchDev
            // 
            this.btnSearchDev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchDev.Location = new System.Drawing.Point(293, 504);
            this.btnSearchDev.Name = "btnSearchDev";
            this.btnSearchDev.Size = new System.Drawing.Size(100, 35);
            this.btnSearchDev.TabIndex = 1;
            this.btnSearchDev.Text = "搜索设备";
            this.btnSearchDev.UseVisualStyleBackColor = true;
            this.btnSearchDev.Click += new System.EventHandler(this.btnSearchDev_Click);
            // 
            // lvZl
            // 
            this.lvZl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvZl.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNo,
            this.columnHeaderIPAdd,
            this.columnHeaderPort,
            this.columnHeaderMAC});
            this.lvZl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvZl.FullRowSelect = true;
            this.lvZl.GridLines = true;
            this.lvZl.Location = new System.Drawing.Point(6, 26);
            this.lvZl.Name = "lvZl";
            this.lvZl.Size = new System.Drawing.Size(387, 466);
            this.lvZl.TabIndex = 0;
            this.lvZl.UseCompatibleStateImageBehavior = false;
            this.lvZl.View = System.Windows.Forms.View.Details;
            this.lvZl.ItemActivate += new System.EventHandler(this.listViewDev_ItemActivate);
            this.lvZl.SelectedIndexChanged += new System.EventHandler(this.lvZl_SelectedIndexChanged);
            // 
            // columnHeaderNo
            // 
            this.columnHeaderNo.Text = "序号";
            // 
            // columnHeaderIPAdd
            // 
            this.columnHeaderIPAdd.Text = "IP地址";
            this.columnHeaderIPAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderIPAdd.Width = 120;
            // 
            // columnHeaderPort
            // 
            this.columnHeaderPort.Text = "端口";
            this.columnHeaderPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeaderMAC
            // 
            this.columnHeaderMAC.Text = "MAC地址";
            this.columnHeaderMAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderMAC.Width = 130;
            // 
            // TagAccess
            // 
            this.TagAccess.Controls.Add(this.gbKillTag);
            this.TagAccess.Controls.Add(this.gbTagInitialize);
            this.TagAccess.Controls.Add(this.gbTagLockAndUnlock);
            this.TagAccess.Controls.Add(this.gbFastWrite);
            this.TagAccess.Controls.Add(this.gbRWData);
            this.TagAccess.Location = new System.Drawing.Point(4, 22);
            this.TagAccess.Name = "TagAccess";
            this.TagAccess.Padding = new System.Windows.Forms.Padding(3);
            this.TagAccess.Size = new System.Drawing.Size(757, 546);
            this.TagAccess.TabIndex = 1;
            this.TagAccess.Text = "标签访问";
            this.TagAccess.UseVisualStyleBackColor = true;
            // 
            // gbKillTag
            // 
            this.gbKillTag.Controls.Add(this.tbKillKillPwd);
            this.gbKillTag.Controls.Add(this.btnKillTag);
            this.gbKillTag.Controls.Add(this.labDestroyPwd);
            this.gbKillTag.Location = new System.Drawing.Point(308, 389);
            this.gbKillTag.Name = "gbKillTag";
            this.gbKillTag.Size = new System.Drawing.Size(173, 139);
            this.gbKillTag.TabIndex = 44;
            this.gbKillTag.TabStop = false;
            this.gbKillTag.Text = "销毁标签";
            // 
            // tbKillKillPwd
            // 
            this.tbKillKillPwd.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbKillKillPwd.Location = new System.Drawing.Point(13, 58);
            this.tbKillKillPwd.Name = "tbKillKillPwd";
            this.tbKillKillPwd.Size = new System.Drawing.Size(142, 30);
            this.tbKillKillPwd.TabIndex = 23;
            // 
            // btnKillTag
            // 
            this.btnKillTag.Location = new System.Drawing.Point(72, 94);
            this.btnKillTag.Name = "btnKillTag";
            this.btnKillTag.Size = new System.Drawing.Size(83, 30);
            this.btnKillTag.TabIndex = 21;
            this.btnKillTag.Text = "销毁";
            this.btnKillTag.UseVisualStyleBackColor = true;
            this.btnKillTag.Click += new System.EventHandler(this.btnKillTag_Click);
            // 
            // labDestroyPwd
            // 
            this.labDestroyPwd.AutoEllipsis = true;
            this.labDestroyPwd.Location = new System.Drawing.Point(13, 25);
            this.labDestroyPwd.Name = "labDestroyPwd";
            this.labDestroyPwd.Size = new System.Drawing.Size(142, 27);
            this.labDestroyPwd.TabIndex = 24;
            this.labDestroyPwd.Text = "注销密码";
            this.labDestroyPwd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbTagInitialize
            // 
            this.gbTagInitialize.Controls.Add(this.btnInitTag);
            this.gbTagInitialize.Location = new System.Drawing.Point(483, 389);
            this.gbTagInitialize.Name = "gbTagInitialize";
            this.gbTagInitialize.Size = new System.Drawing.Size(157, 139);
            this.gbTagInitialize.TabIndex = 43;
            this.gbTagInitialize.TabStop = false;
            this.gbTagInitialize.Text = "标签初始化";
            // 
            // btnInitTag
            // 
            this.btnInitTag.Location = new System.Drawing.Point(15, 94);
            this.btnInitTag.Name = "btnInitTag";
            this.btnInitTag.Size = new System.Drawing.Size(83, 30);
            this.btnInitTag.TabIndex = 26;
            this.btnInitTag.Text = "初始化";
            this.btnInitTag.UseVisualStyleBackColor = true;
            this.btnInitTag.Click += new System.EventHandler(this.btnInitTag_Click);
            // 
            // gbTagLockAndUnlock
            // 
            this.gbTagLockAndUnlock.Controls.Add(this.labLockBank);
            this.gbTagLockAndUnlock.Controls.Add(this.btnUnlockTag);
            this.gbTagLockAndUnlock.Controls.Add(this.cbbLockBank);
            this.gbTagLockAndUnlock.Controls.Add(this.btnLockTag);
            this.gbTagLockAndUnlock.Controls.Add(this.labLockAccessPwd);
            this.gbTagLockAndUnlock.Controls.Add(this.tbLockAccessPwd);
            this.gbTagLockAndUnlock.Location = new System.Drawing.Point(24, 389);
            this.gbTagLockAndUnlock.Name = "gbTagLockAndUnlock";
            this.gbTagLockAndUnlock.Size = new System.Drawing.Size(278, 139);
            this.gbTagLockAndUnlock.TabIndex = 42;
            this.gbTagLockAndUnlock.TabStop = false;
            this.gbTagLockAndUnlock.Text = "标签锁定和解锁";
            // 
            // labLockBank
            // 
            this.labLockBank.AutoEllipsis = true;
            this.labLockBank.Location = new System.Drawing.Point(15, 25);
            this.labLockBank.Name = "labLockBank";
            this.labLockBank.Size = new System.Drawing.Size(97, 27);
            this.labLockBank.TabIndex = 17;
            this.labLockBank.Text = "操作区域";
            this.labLockBank.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnUnlockTag
            // 
            this.btnUnlockTag.Location = new System.Drawing.Point(177, 94);
            this.btnUnlockTag.Name = "btnUnlockTag";
            this.btnUnlockTag.Size = new System.Drawing.Size(83, 30);
            this.btnUnlockTag.TabIndex = 25;
            this.btnUnlockTag.Text = "解锁";
            this.btnUnlockTag.UseVisualStyleBackColor = true;
            this.btnUnlockTag.Click += new System.EventHandler(this.btnUnlockTag_Click);
            // 
            // cbbLockBank
            // 
            this.cbbLockBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLockBank.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbLockBank.FormattingEnabled = true;
            this.cbbLockBank.Location = new System.Drawing.Point(118, 24);
            this.cbbLockBank.Name = "cbbLockBank";
            this.cbbLockBank.Size = new System.Drawing.Size(142, 28);
            this.cbbLockBank.TabIndex = 3;
            // 
            // btnLockTag
            // 
            this.btnLockTag.Location = new System.Drawing.Point(88, 94);
            this.btnLockTag.Name = "btnLockTag";
            this.btnLockTag.Size = new System.Drawing.Size(83, 30);
            this.btnLockTag.TabIndex = 20;
            this.btnLockTag.Text = "锁定";
            this.btnLockTag.UseVisualStyleBackColor = true;
            this.btnLockTag.Click += new System.EventHandler(this.btnLockTag_Click);
            // 
            // labLockAccessPwd
            // 
            this.labLockAccessPwd.AutoEllipsis = true;
            this.labLockAccessPwd.Location = new System.Drawing.Point(17, 60);
            this.labLockAccessPwd.Name = "labLockAccessPwd";
            this.labLockAccessPwd.Size = new System.Drawing.Size(95, 27);
            this.labLockAccessPwd.TabIndex = 16;
            this.labLockAccessPwd.Text = "访问密码";
            this.labLockAccessPwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbLockAccessPwd
            // 
            this.tbLockAccessPwd.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbLockAccessPwd.Location = new System.Drawing.Point(118, 58);
            this.tbLockAccessPwd.Name = "tbLockAccessPwd";
            this.tbLockAccessPwd.Size = new System.Drawing.Size(142, 30);
            this.tbLockAccessPwd.TabIndex = 15;
            // 
            // gbFastWrite
            // 
            this.gbFastWrite.Controls.Add(this.btnReadFastTag);
            this.gbFastWrite.Controls.Add(this.chkZD);
            this.gbFastWrite.Controls.Add(this.labFWPromo);
            this.gbFastWrite.Controls.Add(this.btnClearFWData);
            this.gbFastWrite.Controls.Add(this.btnFastWrite);
            this.gbFastWrite.Controls.Add(this.labFWData);
            this.gbFastWrite.Controls.Add(this.tbFWData);
            this.gbFastWrite.Location = new System.Drawing.Point(25, 18);
            this.gbFastWrite.Name = "gbFastWrite";
            this.gbFastWrite.Size = new System.Drawing.Size(726, 121);
            this.gbFastWrite.TabIndex = 27;
            this.gbFastWrite.TabStop = false;
            this.gbFastWrite.Text = "快写";
            // 
            // btnReadFastTag
            // 
            this.btnReadFastTag.Location = new System.Drawing.Point(441, 83);
            this.btnReadFastTag.Name = "btnReadFastTag";
            this.btnReadFastTag.Size = new System.Drawing.Size(83, 30);
            this.btnReadFastTag.TabIndex = 6;
            this.btnReadFastTag.Text = "读取";
            this.btnReadFastTag.UseVisualStyleBackColor = true;
            this.btnReadFastTag.Click += new System.EventHandler(this.btnReadFastTag_Click);
            // 
            // chkZD
            // 
            this.chkZD.Location = new System.Drawing.Point(99, 83);
            this.chkZD.Name = "chkZD";
            this.chkZD.Size = new System.Drawing.Size(130, 27);
            this.chkZD.TabIndex = 5;
            this.chkZD.Text = "自动增1";
            this.chkZD.UseVisualStyleBackColor = true;
            // 
            // labFWPromo
            // 
            this.labFWPromo.Location = new System.Drawing.Point(6, 20);
            this.labFWPromo.Name = "labFWPromo";
            this.labFWPromo.Size = new System.Drawing.Size(708, 27);
            this.labFWPromo.TabIndex = 4;
            this.labFWPromo.Text = "数据有效提示";
            this.labFWPromo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClearFWData
            // 
            this.btnClearFWData.Location = new System.Drawing.Point(631, 83);
            this.btnClearFWData.Name = "btnClearFWData";
            this.btnClearFWData.Size = new System.Drawing.Size(83, 30);
            this.btnClearFWData.TabIndex = 3;
            this.btnClearFWData.Text = "清空";
            this.btnClearFWData.UseVisualStyleBackColor = true;
            this.btnClearFWData.Click += new System.EventHandler(this.btnClearFWData_Click);
            // 
            // btnFastWrite
            // 
            this.btnFastWrite.Location = new System.Drawing.Point(537, 83);
            this.btnFastWrite.Name = "btnFastWrite";
            this.btnFastWrite.Size = new System.Drawing.Size(83, 30);
            this.btnFastWrite.TabIndex = 2;
            this.btnFastWrite.Text = "快写";
            this.btnFastWrite.UseVisualStyleBackColor = true;
            this.btnFastWrite.Click += new System.EventHandler(this.btnFastWrite_Click);
            // 
            // labFWData
            // 
            this.labFWData.Location = new System.Drawing.Point(6, 53);
            this.labFWData.Name = "labFWData";
            this.labFWData.Size = new System.Drawing.Size(88, 27);
            this.labFWData.TabIndex = 1;
            this.labFWData.Text = "数据";
            this.labFWData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbFWData
            // 
            this.tbFWData.Location = new System.Drawing.Point(99, 50);
            this.tbFWData.Multiline = true;
            this.tbFWData.Name = "tbFWData";
            this.tbFWData.Size = new System.Drawing.Size(615, 27);
            this.tbFWData.TabIndex = 0;
            // 
            // gbRWData
            // 
            this.gbRWData.Controls.Add(this.panel4);
            this.gbRWData.Controls.Add(this.chkDesignatedAntWrite);
            this.gbRWData.Controls.Add(this.chkDesignatedAntRead);
            this.gbRWData.Controls.Add(this.btnWeigandConvert);
            this.gbRWData.Controls.Add(this.rbWeigand26_3_0);
            this.gbRWData.Controls.Add(this.rbWeigand26_1_2);
            this.gbRWData.Controls.Add(this.wiegandTb);
            this.gbRWData.Controls.Add(this.label3);
            this.gbRWData.Controls.Add(this.btnAdvancedAccess);
            this.gbRWData.Controls.Add(this.btn_stoptimer);
            this.gbRWData.Controls.Add(this.btn_connRead);
            this.gbRWData.Controls.Add(this.labData);
            this.gbRWData.Controls.Add(this.labLength);
            this.gbRWData.Controls.Add(this.labStartAdd);
            this.gbRWData.Controls.Add(this.labOprBank);
            this.gbRWData.Controls.Add(this.btnWriteData);
            this.gbRWData.Controls.Add(this.btnClearData);
            this.gbRWData.Controls.Add(this.btnReadData);
            this.gbRWData.Controls.Add(this.tbRWData);
            this.gbRWData.Controls.Add(this.cbbLength);
            this.gbRWData.Controls.Add(this.cbbStartAdd);
            this.gbRWData.Controls.Add(this.cbbRWBank);
            this.gbRWData.Location = new System.Drawing.Point(25, 145);
            this.gbRWData.Name = "gbRWData";
            this.gbRWData.Size = new System.Drawing.Size(726, 238);
            this.gbRWData.TabIndex = 21;
            this.gbRWData.TabStop = false;
            this.gbRWData.Text = "标签读写";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rbAnt1);
            this.panel4.Controls.Add(this.rbAnt2);
            this.panel4.Controls.Add(this.rbAnt3);
            this.panel4.Controls.Add(this.rbAnt8);
            this.panel4.Controls.Add(this.rbAnt4);
            this.panel4.Controls.Add(this.rbAnt7);
            this.panel4.Controls.Add(this.rbAnt5);
            this.panel4.Controls.Add(this.rbAnt6);
            this.panel4.Location = new System.Drawing.Point(30, 14);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(590, 31);
            this.panel4.TabIndex = 71;
            // 
            // rbAnt1
            // 
            this.rbAnt1.AutoSize = true;
            this.rbAnt1.Checked = true;
            this.rbAnt1.Location = new System.Drawing.Point(12, 9);
            this.rbAnt1.Name = "rbAnt1";
            this.rbAnt1.Size = new System.Drawing.Size(53, 16);
            this.rbAnt1.TabIndex = 61;
            this.rbAnt1.TabStop = true;
            this.rbAnt1.Text = "Ant 1";
            this.rbAnt1.UseVisualStyleBackColor = true;
            // 
            // rbAnt2
            // 
            this.rbAnt2.AutoSize = true;
            this.rbAnt2.Location = new System.Drawing.Point(80, 9);
            this.rbAnt2.Name = "rbAnt2";
            this.rbAnt2.Size = new System.Drawing.Size(53, 16);
            this.rbAnt2.TabIndex = 62;
            this.rbAnt2.Text = "Ant 2";
            this.rbAnt2.UseVisualStyleBackColor = true;
            // 
            // rbAnt3
            // 
            this.rbAnt3.AutoSize = true;
            this.rbAnt3.Location = new System.Drawing.Point(146, 9);
            this.rbAnt3.Name = "rbAnt3";
            this.rbAnt3.Size = new System.Drawing.Size(53, 16);
            this.rbAnt3.TabIndex = 63;
            this.rbAnt3.Text = "Ant 3";
            this.rbAnt3.UseVisualStyleBackColor = true;
            // 
            // rbAnt8
            // 
            this.rbAnt8.AutoSize = true;
            this.rbAnt8.Location = new System.Drawing.Point(496, 9);
            this.rbAnt8.Name = "rbAnt8";
            this.rbAnt8.Size = new System.Drawing.Size(53, 16);
            this.rbAnt8.TabIndex = 68;
            this.rbAnt8.Text = "Ant 8";
            this.rbAnt8.UseVisualStyleBackColor = true;
            // 
            // rbAnt4
            // 
            this.rbAnt4.AutoSize = true;
            this.rbAnt4.Location = new System.Drawing.Point(216, 9);
            this.rbAnt4.Name = "rbAnt4";
            this.rbAnt4.Size = new System.Drawing.Size(53, 16);
            this.rbAnt4.TabIndex = 64;
            this.rbAnt4.Text = "Ant 4";
            this.rbAnt4.UseVisualStyleBackColor = true;
            // 
            // rbAnt7
            // 
            this.rbAnt7.AutoSize = true;
            this.rbAnt7.Location = new System.Drawing.Point(426, 9);
            this.rbAnt7.Name = "rbAnt7";
            this.rbAnt7.Size = new System.Drawing.Size(53, 16);
            this.rbAnt7.TabIndex = 67;
            this.rbAnt7.Text = "Ant 7";
            this.rbAnt7.UseVisualStyleBackColor = true;
            // 
            // rbAnt5
            // 
            this.rbAnt5.AutoSize = true;
            this.rbAnt5.Location = new System.Drawing.Point(284, 9);
            this.rbAnt5.Name = "rbAnt5";
            this.rbAnt5.Size = new System.Drawing.Size(53, 16);
            this.rbAnt5.TabIndex = 65;
            this.rbAnt5.Text = "Ant 5";
            this.rbAnt5.UseVisualStyleBackColor = true;
            // 
            // rbAnt6
            // 
            this.rbAnt6.AutoSize = true;
            this.rbAnt6.Location = new System.Drawing.Point(355, 9);
            this.rbAnt6.Name = "rbAnt6";
            this.rbAnt6.Size = new System.Drawing.Size(53, 16);
            this.rbAnt6.TabIndex = 66;
            this.rbAnt6.Text = "Ant 6";
            this.rbAnt6.UseVisualStyleBackColor = true;
            // 
            // chkDesignatedAntWrite
            // 
            this.chkDesignatedAntWrite.Location = new System.Drawing.Point(624, 124);
            this.chkDesignatedAntWrite.Name = "chkDesignatedAntWrite";
            this.chkDesignatedAntWrite.Size = new System.Drawing.Size(84, 27);
            this.chkDesignatedAntWrite.TabIndex = 70;
            this.chkDesignatedAntWrite.Text = "指定天线写";
            this.chkDesignatedAntWrite.UseVisualStyleBackColor = true;
            this.chkDesignatedAntWrite.Visible = false;
            // 
            // chkDesignatedAntRead
            // 
            this.chkDesignatedAntRead.Location = new System.Drawing.Point(622, 52);
            this.chkDesignatedAntRead.Name = "chkDesignatedAntRead";
            this.chkDesignatedAntRead.Size = new System.Drawing.Size(84, 27);
            this.chkDesignatedAntRead.TabIndex = 69;
            this.chkDesignatedAntRead.Text = "指定天线读";
            this.chkDesignatedAntRead.UseVisualStyleBackColor = true;
            this.chkDesignatedAntRead.Visible = false;
            // 
            // btnWeigandConvert
            // 
            this.btnWeigandConvert.Location = new System.Drawing.Point(537, 158);
            this.btnWeigandConvert.Name = "btnWeigandConvert";
            this.btnWeigandConvert.Size = new System.Drawing.Size(83, 30);
            this.btnWeigandConvert.TabIndex = 21;
            this.btnWeigandConvert.Text = "转换";
            this.btnWeigandConvert.UseVisualStyleBackColor = true;
            this.btnWeigandConvert.Click += new System.EventHandler(this.btnWeigandConvert_Click);
            // 
            // rbWeigand26_3_0
            // 
            this.rbWeigand26_3_0.Location = new System.Drawing.Point(435, 163);
            this.rbWeigand26_3_0.Name = "rbWeigand26_3_0";
            this.rbWeigand26_3_0.Size = new System.Drawing.Size(89, 27);
            this.rbWeigand26_3_0.TabIndex = 20;
            this.rbWeigand26_3_0.Text = "韦根26(3+0)";
            this.rbWeigand26_3_0.UseVisualStyleBackColor = true;
            // 
            // rbWeigand26_1_2
            // 
            this.rbWeigand26_1_2.Location = new System.Drawing.Point(320, 163);
            this.rbWeigand26_1_2.Name = "rbWeigand26_1_2";
            this.rbWeigand26_1_2.Size = new System.Drawing.Size(89, 27);
            this.rbWeigand26_1_2.TabIndex = 19;
            this.rbWeigand26_1_2.Text = "韦根26(1+2)";
            this.rbWeigand26_1_2.UseVisualStyleBackColor = true;
            // 
            // wiegandTb
            // 
            this.wiegandTb.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wiegandTb.Location = new System.Drawing.Point(103, 161);
            this.wiegandTb.Name = "wiegandTb";
            this.wiegandTb.Size = new System.Drawing.Size(212, 30);
            this.wiegandTb.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(34, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 27);
            this.label3.TabIndex = 17;
            this.label3.Text = "韦根格式：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAdvancedAccess
            // 
            this.btnAdvancedAccess.Location = new System.Drawing.Point(99, 197);
            this.btnAdvancedAccess.Name = "btnAdvancedAccess";
            this.btnAdvancedAccess.Size = new System.Drawing.Size(100, 30);
            this.btnAdvancedAccess.TabIndex = 16;
            this.btnAdvancedAccess.Text = "批量读写";
            this.btnAdvancedAccess.UseVisualStyleBackColor = true;
            this.btnAdvancedAccess.Visible = false;
            this.btnAdvancedAccess.Click += new System.EventHandler(this.btnAdvancedAccess_Click);
            // 
            // btn_stoptimer
            // 
            this.btn_stoptimer.Location = new System.Drawing.Point(424, 197);
            this.btn_stoptimer.Name = "btn_stoptimer";
            this.btn_stoptimer.Size = new System.Drawing.Size(100, 30);
            this.btn_stoptimer.TabIndex = 15;
            this.btn_stoptimer.Text = "停止";
            this.btn_stoptimer.UseVisualStyleBackColor = true;
            this.btn_stoptimer.Click += new System.EventHandler(this.btn_stoptimer_Click);
            // 
            // btn_connRead
            // 
            this.btn_connRead.Location = new System.Drawing.Point(257, 197);
            this.btn_connRead.Name = "btn_connRead";
            this.btn_connRead.Size = new System.Drawing.Size(100, 30);
            this.btn_connRead.TabIndex = 14;
            this.btn_connRead.Text = "连续读取";
            this.btn_connRead.UseVisualStyleBackColor = true;
            this.btn_connRead.Click += new System.EventHandler(this.btn_connRead_Click);
            // 
            // labData
            // 
            this.labData.Location = new System.Drawing.Point(6, 86);
            this.labData.Name = "labData";
            this.labData.Size = new System.Drawing.Size(90, 27);
            this.labData.TabIndex = 13;
            this.labData.Text = "数据";
            this.labData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labLength
            // 
            this.labLength.AutoEllipsis = true;
            this.labLength.Location = new System.Drawing.Point(386, 52);
            this.labLength.Name = "labLength";
            this.labLength.Size = new System.Drawing.Size(49, 27);
            this.labLength.TabIndex = 12;
            this.labLength.Text = "长度";
            this.labLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labStartAdd
            // 
            this.labStartAdd.AutoEllipsis = true;
            this.labStartAdd.Location = new System.Drawing.Point(193, 52);
            this.labStartAdd.Name = "labStartAdd";
            this.labStartAdd.Size = new System.Drawing.Size(85, 27);
            this.labStartAdd.TabIndex = 11;
            this.labStartAdd.Text = "起始地址";
            this.labStartAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labOprBank
            // 
            this.labOprBank.AutoEllipsis = true;
            this.labOprBank.Location = new System.Drawing.Point(6, 53);
            this.labOprBank.Name = "labOprBank";
            this.labOprBank.Size = new System.Drawing.Size(90, 27);
            this.labOprBank.TabIndex = 10;
            this.labOprBank.Text = "操作区域";
            this.labOprBank.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnWriteData
            // 
            this.btnWriteData.Location = new System.Drawing.Point(537, 122);
            this.btnWriteData.Name = "btnWriteData";
            this.btnWriteData.Size = new System.Drawing.Size(83, 30);
            this.btnWriteData.TabIndex = 8;
            this.btnWriteData.Text = "写入";
            this.btnWriteData.UseVisualStyleBackColor = true;
            this.btnWriteData.Click += new System.EventHandler(this.btnWriteData_Click);
            // 
            // btnClearData
            // 
            this.btnClearData.Location = new System.Drawing.Point(537, 86);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(83, 30);
            this.btnClearData.TabIndex = 7;
            this.btnClearData.Text = "清空";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
            // 
            // btnReadData
            // 
            this.btnReadData.Location = new System.Drawing.Point(537, 50);
            this.btnReadData.Name = "btnReadData";
            this.btnReadData.Size = new System.Drawing.Size(83, 30);
            this.btnReadData.TabIndex = 6;
            this.btnReadData.Text = "读取";
            this.btnReadData.UseVisualStyleBackColor = true;
            this.btnReadData.Click += new System.EventHandler(this.btnReadData_Click);
            // 
            // tbRWData
            // 
            this.tbRWData.Location = new System.Drawing.Point(100, 86);
            this.tbRWData.Multiline = true;
            this.tbRWData.Name = "tbRWData";
            this.tbRWData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbRWData.Size = new System.Drawing.Size(424, 71);
            this.tbRWData.TabIndex = 5;
            // 
            // cbbLength
            // 
            this.cbbLength.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbLength.FormattingEnabled = true;
            this.cbbLength.Location = new System.Drawing.Point(441, 51);
            this.cbbLength.Name = "cbbLength";
            this.cbbLength.Size = new System.Drawing.Size(88, 28);
            this.cbbLength.TabIndex = 2;
            // 
            // cbbStartAdd
            // 
            this.cbbStartAdd.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbStartAdd.FormattingEnabled = true;
            this.cbbStartAdd.Location = new System.Drawing.Point(280, 51);
            this.cbbStartAdd.Name = "cbbStartAdd";
            this.cbbStartAdd.Size = new System.Drawing.Size(88, 28);
            this.cbbStartAdd.TabIndex = 1;
            this.cbbStartAdd.SelectedIndexChanged += new System.EventHandler(this.cbbStartAdd_SelectedIndexChanged);
            // 
            // cbbRWBank
            // 
            this.cbbRWBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbRWBank.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbRWBank.FormattingEnabled = true;
            this.cbbRWBank.Location = new System.Drawing.Point(100, 52);
            this.cbbRWBank.Name = "cbbRWBank";
            this.cbbRWBank.Size = new System.Drawing.Size(88, 28);
            this.cbbRWBank.TabIndex = 0;
            this.cbbRWBank.SelectedIndexChanged += new System.EventHandler(this.cbbRWBank_SelectedIndexChanged);
            // 
            // General
            // 
            this.General.Controls.Add(this.btnReadOnce);
            this.General.Controls.Add(this.btnStartReadData);
            this.General.Controls.Add(this.btnStopReadData);
            this.General.Controls.Add(this.cbSaveFile);
            this.General.Controls.Add(this.btnClearListView);
            this.General.Controls.Add(this.lblCount);
            this.General.Controls.Add(this.lblTagCount);
            this.General.Controls.Add(this.labReadCount);
            this.General.Controls.Add(this.labTagCount);
            this.General.Controls.Add(this.rbDesc);
            this.General.Controls.Add(this.rbAsc);
            this.General.Controls.Add(this.labelVersion);
            this.General.Controls.Add(this.listView);
            this.General.Location = new System.Drawing.Point(4, 22);
            this.General.Margin = new System.Windows.Forms.Padding(1);
            this.General.Name = "General";
            this.General.Padding = new System.Windows.Forms.Padding(1);
            this.General.Size = new System.Drawing.Size(757, 546);
            this.General.TabIndex = 0;
            this.General.Text = "基本操作";
            this.General.UseVisualStyleBackColor = true;
            // 
            // btnReadOnce
            // 
            this.btnReadOnce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadOnce.Location = new System.Drawing.Point(160, 504);
            this.btnReadOnce.Name = "btnReadOnce";
            this.btnReadOnce.Size = new System.Drawing.Size(93, 38);
            this.btnReadOnce.TabIndex = 1;
            this.btnReadOnce.Text = "寻卡一次";
            this.btnReadOnce.UseVisualStyleBackColor = true;
            this.btnReadOnce.Click += new System.EventHandler(this.btnReadOnce_Click);
            // 
            // btnStartReadData
            // 
            this.btnStartReadData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartReadData.Location = new System.Drawing.Point(266, 504);
            this.btnStartReadData.Name = "btnStartReadData";
            this.btnStartReadData.Size = new System.Drawing.Size(93, 38);
            this.btnStartReadData.TabIndex = 2;
            this.btnStartReadData.Text = "开始连续寻卡";
            this.btnStartReadData.UseVisualStyleBackColor = true;
            this.btnStartReadData.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStopReadData
            // 
            this.btnStopReadData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopReadData.Location = new System.Drawing.Point(372, 504);
            this.btnStopReadData.Name = "btnStopReadData";
            this.btnStopReadData.Size = new System.Drawing.Size(93, 38);
            this.btnStopReadData.TabIndex = 3;
            this.btnStopReadData.Text = "停止连续寻卡";
            this.btnStopReadData.UseVisualStyleBackColor = true;
            this.btnStopReadData.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // cbSaveFile
            // 
            this.cbSaveFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSaveFile.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbSaveFile.Location = new System.Drawing.Point(615, 504);
            this.cbSaveFile.Name = "cbSaveFile";
            this.cbSaveFile.Size = new System.Drawing.Size(134, 38);
            this.cbSaveFile.TabIndex = 41;
            this.cbSaveFile.Text = "自动保存为文件";
            this.cbSaveFile.UseVisualStyleBackColor = true;
            this.cbSaveFile.CheckedChanged += new System.EventHandler(this.cbSaveFile_CheckedChanged);
            // 
            // btnClearListView
            // 
            this.btnClearListView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearListView.Location = new System.Drawing.Point(478, 504);
            this.btnClearListView.Name = "btnClearListView";
            this.btnClearListView.Size = new System.Drawing.Size(93, 38);
            this.btnClearListView.TabIndex = 4;
            this.btnClearListView.Text = "清空";
            this.btnClearListView.UseVisualStyleBackColor = true;
            this.btnClearListView.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCount.Location = new System.Drawing.Point(302, 15);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(110, 30);
            this.lblCount.TabIndex = 37;
            this.lblCount.Text = "0";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTagCount
            // 
            this.lblTagCount.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTagCount.ForeColor = System.Drawing.Color.Red;
            this.lblTagCount.Location = new System.Drawing.Point(110, 14);
            this.lblTagCount.Name = "lblTagCount";
            this.lblTagCount.Size = new System.Drawing.Size(80, 30);
            this.lblTagCount.TabIndex = 36;
            this.lblTagCount.Text = "0";
            this.lblTagCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labReadCount
            // 
            this.labReadCount.AutoEllipsis = true;
            this.labReadCount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labReadCount.Location = new System.Drawing.Point(196, 15);
            this.labReadCount.Name = "labReadCount";
            this.labReadCount.Size = new System.Drawing.Size(100, 30);
            this.labReadCount.TabIndex = 35;
            this.labReadCount.Text = "读取次数:";
            this.labReadCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labTagCount
            // 
            this.labTagCount.AutoEllipsis = true;
            this.labTagCount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTagCount.Location = new System.Drawing.Point(4, 15);
            this.labTagCount.Name = "labTagCount";
            this.labTagCount.Size = new System.Drawing.Size(100, 30);
            this.labTagCount.TabIndex = 34;
            this.labTagCount.Text = "标签数:";
            this.labTagCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbDesc
            // 
            this.rbDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbDesc.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbDesc.Location = new System.Drawing.Point(659, 12);
            this.rbDesc.Name = "rbDesc";
            this.rbDesc.Size = new System.Drawing.Size(90, 30);
            this.rbDesc.TabIndex = 32;
            this.rbDesc.TabStop = true;
            this.rbDesc.Text = "降序";
            this.rbDesc.UseVisualStyleBackColor = true;
            this.rbDesc.CheckedChanged += new System.EventHandler(this.rbDesc_CheckedChanged);
            // 
            // rbAsc
            // 
            this.rbAsc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbAsc.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbAsc.Location = new System.Drawing.Point(563, 12);
            this.rbAsc.Name = "rbAsc";
            this.rbAsc.Size = new System.Drawing.Size(90, 30);
            this.rbAsc.TabIndex = 31;
            this.rbAsc.TabStop = true;
            this.rbAsc.Text = "升序";
            this.rbAsc.UseVisualStyleBackColor = true;
            this.rbAsc.CheckedChanged += new System.EventHandler(this.rbAsc_CheckedChanged);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(40, 407);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(0, 12);
            this.labelVersion.TabIndex = 30;
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.ContextMenuStrip = this.cmsMenu;
            this.listView.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(6, 48);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(743, 450);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.General);
            this.tabControl.Controls.Add(this.TagAccess);
            this.tabControl.Controls.Add(this.SetCommParam);
            this.tabControl.Controls.Add(this.SetReaderParam);
            this.tabControl.Controls.Add(this.OtherOpreation);
            this.tabControl.Location = new System.Drawing.Point(264, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(1);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(765, 572);
            this.tabControl.TabIndex = 0;
            // 
            // gbVersionInfo
            // 
            this.gbVersionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbVersionInfo.Controls.Add(this.btnBrushVersion);
            this.gbVersionInfo.Controls.Add(this.lblVersion);
            this.gbVersionInfo.Controls.Add(this.btnReadVersion);
            this.gbVersionInfo.Location = new System.Drawing.Point(7, 576);
            this.gbVersionInfo.Name = "gbVersionInfo";
            this.gbVersionInfo.Size = new System.Drawing.Size(250, 52);
            this.gbVersionInfo.TabIndex = 41;
            this.gbVersionInfo.TabStop = false;
            this.gbVersionInfo.Text = "版本信息";
            // 
            // btnBrushVersion
            // 
            this.btnBrushVersion.Location = new System.Drawing.Point(184, 16);
            this.btnBrushVersion.Name = "btnBrushVersion";
            this.btnBrushVersion.Size = new System.Drawing.Size(60, 30);
            this.btnBrushVersion.TabIndex = 40;
            this.btnBrushVersion.Text = "刷新";
            this.btnBrushVersion.UseVisualStyleBackColor = true;
            this.btnBrushVersion.Click += new System.EventHandler(this.btnBrushVersion_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblVersion.ForeColor = System.Drawing.Color.Blue;
            this.lblVersion.Location = new System.Drawing.Point(6, 16);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(108, 30);
            this.lblVersion.TabIndex = 39;
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReadVersion
            // 
            this.btnReadVersion.Location = new System.Drawing.Point(120, 16);
            this.btnReadVersion.Name = "btnReadVersion";
            this.btnReadVersion.Size = new System.Drawing.Size(60, 30);
            this.btnReadVersion.TabIndex = 38;
            this.btnReadVersion.Text = "读取";
            this.btnReadVersion.UseVisualStyleBackColor = true;
            this.btnReadVersion.Click += new System.EventHandler(this.btnReadVersion_Click);
            // 
            // gbConnectType
            // 
            this.gbConnectType.Controls.Add(this.tbConnect);
            this.gbConnectType.Location = new System.Drawing.Point(7, 40);
            this.gbConnectType.Name = "gbConnectType";
            this.gbConnectType.Size = new System.Drawing.Size(253, 159);
            this.gbConnectType.TabIndex = 42;
            this.gbConnectType.TabStop = false;
            this.gbConnectType.Text = "连接方式";
            // 
            // tbConnect
            // 
            this.tbConnect.Controls.Add(this.tpSerialPort);
            this.tbConnect.Controls.Add(this.tpTCPClient);
            this.tbConnect.Controls.Add(this.tpTCPServer);
            this.tbConnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbConnect.Location = new System.Drawing.Point(3, 17);
            this.tbConnect.Name = "tbConnect";
            this.tbConnect.SelectedIndex = 0;
            this.tbConnect.Size = new System.Drawing.Size(247, 139);
            this.tbConnect.TabIndex = 0;
            this.tbConnect.SelectedIndexChanged += new System.EventHandler(this.tbConnect_SelectedIndexChanged);
            // 
            // tpSerialPort
            // 
            this.tpSerialPort.Controls.Add(this.lblBaudRate);
            this.tpSerialPort.Controls.Add(this.cbbBaudRate);
            this.tpSerialPort.Controls.Add(this.lblSerialPort);
            this.tpSerialPort.Controls.Add(this.cbbSerialPort);
            this.tpSerialPort.Controls.Add(this.btnUpdateSerialPort);
            this.tpSerialPort.Controls.Add(this.btnSerialPortDisconnect);
            this.tpSerialPort.Controls.Add(this.btnSerialPortConnect);
            this.tpSerialPort.Location = new System.Drawing.Point(4, 22);
            this.tpSerialPort.Name = "tpSerialPort";
            this.tpSerialPort.Padding = new System.Windows.Forms.Padding(3);
            this.tpSerialPort.Size = new System.Drawing.Size(239, 113);
            this.tpSerialPort.TabIndex = 0;
            this.tpSerialPort.Text = "Serial Port";
            this.tpSerialPort.UseVisualStyleBackColor = true;
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.Location = new System.Drawing.Point(6, 41);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(71, 24);
            this.lblBaudRate.TabIndex = 39;
            this.lblBaudRate.Text = "Baud Rate";
            this.lblBaudRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbBaudRate
            // 
            this.cbbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBaudRate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbBaudRate.FormattingEnabled = true;
            this.cbbBaudRate.Location = new System.Drawing.Point(90, 41);
            this.cbbBaudRate.Name = "cbbBaudRate";
            this.cbbBaudRate.Size = new System.Drawing.Size(77, 24);
            this.cbbBaudRate.TabIndex = 40;
            // 
            // lblSerialPort
            // 
            this.lblSerialPort.Location = new System.Drawing.Point(6, 10);
            this.lblSerialPort.Name = "lblSerialPort";
            this.lblSerialPort.Size = new System.Drawing.Size(71, 24);
            this.lblSerialPort.TabIndex = 34;
            this.lblSerialPort.Text = "Serial Port";
            this.lblSerialPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbSerialPort
            // 
            this.cbbSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSerialPort.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbSerialPort.IntegralHeight = false;
            this.cbbSerialPort.Items.AddRange(new object[] {
            "192.168.100.100"});
            this.cbbSerialPort.Location = new System.Drawing.Point(90, 10);
            this.cbbSerialPort.Name = "cbbSerialPort";
            this.cbbSerialPort.Size = new System.Drawing.Size(77, 24);
            this.cbbSerialPort.TabIndex = 37;
            // 
            // btnUpdateSerialPort
            // 
            this.btnUpdateSerialPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateSerialPort.Location = new System.Drawing.Point(173, 7);
            this.btnUpdateSerialPort.Name = "btnUpdateSerialPort";
            this.btnUpdateSerialPort.Size = new System.Drawing.Size(60, 30);
            this.btnUpdateSerialPort.TabIndex = 38;
            this.btnUpdateSerialPort.Text = "刷新";
            this.btnUpdateSerialPort.UseVisualStyleBackColor = true;
            this.btnUpdateSerialPort.Click += new System.EventHandler(this.btnUpdateSerialPort_Click);
            // 
            // btnSerialPortDisconnect
            // 
            this.btnSerialPortDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSerialPortDisconnect.Location = new System.Drawing.Point(133, 75);
            this.btnSerialPortDisconnect.Name = "btnSerialPortDisconnect";
            this.btnSerialPortDisconnect.Size = new System.Drawing.Size(100, 30);
            this.btnSerialPortDisconnect.TabIndex = 36;
            this.btnSerialPortDisconnect.Text = "断开";
            this.btnSerialPortDisconnect.UseVisualStyleBackColor = true;
            this.btnSerialPortDisconnect.Click += new System.EventHandler(this.btnSerialPortDisconnect_Click);
            // 
            // btnSerialPortConnect
            // 
            this.btnSerialPortConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSerialPortConnect.Location = new System.Drawing.Point(6, 75);
            this.btnSerialPortConnect.Name = "btnSerialPortConnect";
            this.btnSerialPortConnect.Size = new System.Drawing.Size(100, 30);
            this.btnSerialPortConnect.TabIndex = 35;
            this.btnSerialPortConnect.Text = "连接";
            this.btnSerialPortConnect.UseVisualStyleBackColor = true;
            this.btnSerialPortConnect.Click += new System.EventHandler(this.btnSerialPortConnect_Click);
            // 
            // tpTCPClient
            // 
            this.tpTCPClient.Controls.Add(this.btnUpdateTCPClient);
            this.tpTCPClient.Controls.Add(this.tbTCPClientPort);
            this.tpTCPClient.Controls.Add(this.lblTCPClientPort);
            this.tpTCPClient.Controls.Add(this.lblTCPClientIP);
            this.tpTCPClient.Controls.Add(this.cbbTCPClientIP);
            this.tpTCPClient.Controls.Add(this.btnTCPClientDisconnect);
            this.tpTCPClient.Controls.Add(this.btnTCPClientConnect);
            this.tpTCPClient.Location = new System.Drawing.Point(4, 22);
            this.tpTCPClient.Name = "tpTCPClient";
            this.tpTCPClient.Padding = new System.Windows.Forms.Padding(3);
            this.tpTCPClient.Size = new System.Drawing.Size(239, 113);
            this.tpTCPClient.TabIndex = 1;
            this.tpTCPClient.Text = "TCP Client";
            this.tpTCPClient.UseVisualStyleBackColor = true;
            // 
            // btnUpdateTCPClient
            // 
            this.btnUpdateTCPClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateTCPClient.Location = new System.Drawing.Point(153, 38);
            this.btnUpdateTCPClient.Name = "btnUpdateTCPClient";
            this.btnUpdateTCPClient.Size = new System.Drawing.Size(80, 30);
            this.btnUpdateTCPClient.TabIndex = 46;
            this.btnUpdateTCPClient.Text = "刷新";
            this.btnUpdateTCPClient.UseVisualStyleBackColor = true;
            this.btnUpdateTCPClient.Click += new System.EventHandler(this.btnUpdateTCPClient_Click);
            // 
            // tbTCPClientPort
            // 
            this.tbTCPClientPort.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbTCPClientPort.Location = new System.Drawing.Point(52, 40);
            this.tbTCPClientPort.Name = "tbTCPClientPort";
            this.tbTCPClientPort.Size = new System.Drawing.Size(74, 26);
            this.tbTCPClientPort.TabIndex = 40;
            this.tbTCPClientPort.Text = "4196";
            // 
            // lblTCPClientPort
            // 
            this.lblTCPClientPort.Location = new System.Drawing.Point(6, 41);
            this.lblTCPClientPort.Name = "lblTCPClientPort";
            this.lblTCPClientPort.Size = new System.Drawing.Size(40, 24);
            this.lblTCPClientPort.TabIndex = 39;
            this.lblTCPClientPort.Text = "Port";
            this.lblTCPClientPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTCPClientIP
            // 
            this.lblTCPClientIP.Location = new System.Drawing.Point(6, 10);
            this.lblTCPClientIP.Name = "lblTCPClientIP";
            this.lblTCPClientIP.Size = new System.Drawing.Size(40, 24);
            this.lblTCPClientIP.TabIndex = 34;
            this.lblTCPClientIP.Text = "IP";
            this.lblTCPClientIP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbTCPClientIP
            // 
            this.cbbTCPClientIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbTCPClientIP.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbTCPClientIP.FormattingEnabled = true;
            this.cbbTCPClientIP.Location = new System.Drawing.Point(52, 10);
            this.cbbTCPClientIP.Name = "cbbTCPClientIP";
            this.cbbTCPClientIP.Size = new System.Drawing.Size(178, 24);
            this.cbbTCPClientIP.TabIndex = 5;
            // 
            // btnTCPClientDisconnect
            // 
            this.btnTCPClientDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTCPClientDisconnect.Location = new System.Drawing.Point(133, 75);
            this.btnTCPClientDisconnect.Name = "btnTCPClientDisconnect";
            this.btnTCPClientDisconnect.Size = new System.Drawing.Size(100, 30);
            this.btnTCPClientDisconnect.TabIndex = 36;
            this.btnTCPClientDisconnect.Text = "断开";
            this.btnTCPClientDisconnect.UseVisualStyleBackColor = true;
            this.btnTCPClientDisconnect.Click += new System.EventHandler(this.btnTCPClientDisconnect_Click);
            // 
            // btnTCPClientConnect
            // 
            this.btnTCPClientConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTCPClientConnect.Location = new System.Drawing.Point(6, 75);
            this.btnTCPClientConnect.Name = "btnTCPClientConnect";
            this.btnTCPClientConnect.Size = new System.Drawing.Size(100, 30);
            this.btnTCPClientConnect.TabIndex = 35;
            this.btnTCPClientConnect.Text = "连接";
            this.btnTCPClientConnect.UseVisualStyleBackColor = true;
            this.btnTCPClientConnect.Click += new System.EventHandler(this.btnTCPClientConnect_Click);
            // 
            // tpTCPServer
            // 
            this.tpTCPServer.Controls.Add(this.tbTCPServerPort);
            this.tpTCPServer.Controls.Add(this.lblTCPServerPort);
            this.tpTCPServer.Controls.Add(this.lblTCPServerIP);
            this.tpTCPServer.Controls.Add(this.btnUpdateTCPServer);
            this.tpTCPServer.Controls.Add(this.cbbTCPServerIP);
            this.tpTCPServer.Controls.Add(this.btnStopMonitor);
            this.tpTCPServer.Controls.Add(this.btnStartMonitor);
            this.tpTCPServer.Location = new System.Drawing.Point(4, 22);
            this.tpTCPServer.Name = "tpTCPServer";
            this.tpTCPServer.Padding = new System.Windows.Forms.Padding(3);
            this.tpTCPServer.Size = new System.Drawing.Size(239, 113);
            this.tpTCPServer.TabIndex = 2;
            this.tpTCPServer.Text = "TCP Server";
            this.tpTCPServer.UseVisualStyleBackColor = true;
            // 
            // tbTCPServerPort
            // 
            this.tbTCPServerPort.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbTCPServerPort.Location = new System.Drawing.Point(52, 40);
            this.tbTCPServerPort.Name = "tbTCPServerPort";
            this.tbTCPServerPort.Size = new System.Drawing.Size(74, 26);
            this.tbTCPServerPort.TabIndex = 47;
            this.tbTCPServerPort.Text = "4196";
            // 
            // lblTCPServerPort
            // 
            this.lblTCPServerPort.Location = new System.Drawing.Point(6, 41);
            this.lblTCPServerPort.Name = "lblTCPServerPort";
            this.lblTCPServerPort.Size = new System.Drawing.Size(40, 24);
            this.lblTCPServerPort.TabIndex = 46;
            this.lblTCPServerPort.Text = "Port";
            this.lblTCPServerPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTCPServerIP
            // 
            this.lblTCPServerIP.Location = new System.Drawing.Point(6, 10);
            this.lblTCPServerIP.Name = "lblTCPServerIP";
            this.lblTCPServerIP.Size = new System.Drawing.Size(40, 24);
            this.lblTCPServerIP.TabIndex = 42;
            this.lblTCPServerIP.Text = "IP";
            this.lblTCPServerIP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnUpdateTCPServer
            // 
            this.btnUpdateTCPServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateTCPServer.Location = new System.Drawing.Point(153, 38);
            this.btnUpdateTCPServer.Name = "btnUpdateTCPServer";
            this.btnUpdateTCPServer.Size = new System.Drawing.Size(80, 30);
            this.btnUpdateTCPServer.TabIndex = 45;
            this.btnUpdateTCPServer.Text = "刷新";
            this.btnUpdateTCPServer.UseVisualStyleBackColor = true;
            this.btnUpdateTCPServer.Click += new System.EventHandler(this.btnUpdateTCPServer_Click);
            // 
            // cbbTCPServerIP
            // 
            this.cbbTCPServerIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbTCPServerIP.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbTCPServerIP.FormattingEnabled = true;
            this.cbbTCPServerIP.Location = new System.Drawing.Point(52, 10);
            this.cbbTCPServerIP.Name = "cbbTCPServerIP";
            this.cbbTCPServerIP.Size = new System.Drawing.Size(178, 24);
            this.cbbTCPServerIP.TabIndex = 41;
            // 
            // btnStopMonitor
            // 
            this.btnStopMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopMonitor.Location = new System.Drawing.Point(133, 75);
            this.btnStopMonitor.Name = "btnStopMonitor";
            this.btnStopMonitor.Size = new System.Drawing.Size(100, 30);
            this.btnStopMonitor.TabIndex = 44;
            this.btnStopMonitor.Text = "停止监听";
            this.btnStopMonitor.UseVisualStyleBackColor = true;
            this.btnStopMonitor.Click += new System.EventHandler(this.btnStopMonitor_Click);
            // 
            // btnStartMonitor
            // 
            this.btnStartMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStartMonitor.Location = new System.Drawing.Point(6, 75);
            this.btnStartMonitor.Name = "btnStartMonitor";
            this.btnStartMonitor.Size = new System.Drawing.Size(100, 30);
            this.btnStartMonitor.TabIndex = 43;
            this.btnStartMonitor.Text = "启动监听";
            this.btnStartMonitor.UseVisualStyleBackColor = true;
            this.btnStartMonitor.Click += new System.EventHandler(this.btnStartMonitor_Click);
            // 
            // tvConnectList
            // 
            this.tvConnectList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tvConnectList.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvConnectList.Location = new System.Drawing.Point(10, 205);
            this.tvConnectList.Name = "tvConnectList";
            treeNode1.Name = "tdSerialPort";
            treeNode1.Text = "Serial Port";
            treeNode2.Name = "tnTCPClient";
            treeNode2.Text = "TCP Client";
            treeNode3.Name = "tnTCPServer";
            treeNode3.Text = "TCP Server";
            treeNode4.Name = "tnOnLine";
            treeNode4.Text = "On Line";
            this.tvConnectList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.tvConnectList.Size = new System.Drawing.Size(247, 365);
            this.tvConnectList.TabIndex = 43;
            this.tvConnectList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvConnectList_AfterSelect);
            // 
            // lblLanguage
            // 
            this.lblLanguage.Location = new System.Drawing.Point(7, 10);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(121, 28);
            this.lblLanguage.TabIndex = 44;
            this.lblLanguage.Text = "Language(语言设置)";
            this.lblLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblMessageHit);
            this.groupBox1.Controls.Add(this.lblInfoShow);
            this.groupBox1.Location = new System.Drawing.Point(260, 576);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(765, 52);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            // 
            // lblMessageHit
            // 
            this.lblMessageHit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessageHit.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMessageHit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMessageHit.Location = new System.Drawing.Point(168, 17);
            this.lblMessageHit.Name = "lblMessageHit";
            this.lblMessageHit.Size = new System.Drawing.Size(589, 30);
            this.lblMessageHit.TabIndex = 40;
            this.lblMessageHit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInfoShow
            // 
            this.lblInfoShow.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfoShow.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblInfoShow.Location = new System.Drawing.Point(6, 16);
            this.lblInfoShow.Name = "lblInfoShow";
            this.lblInfoShow.Size = new System.Drawing.Size(154, 30);
            this.lblInfoShow.TabIndex = 39;
            this.lblInfoShow.Text = "信息提示:";
            this.lblInfoShow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerConnRead
            // 
            this.timerConnRead.Tick += new System.EventHandler(this.btn_connRead_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1029, 632);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.tvConnectList);
            this.Controls.Add(this.gbConnectType);
            this.Controls.Add(this.gbVersionInfo);
            this.Controls.Add(this.cbbLangSwitch);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DisDemo_C#_V2.82";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.cmsMenu.ResumeLayout(false);
            this.OtherOpreation.ResumeLayout(false);
            this.gbSerialNumber.ResumeLayout(false);
            this.gbSerialNumber.PerformLayout();
            this.gbDevNo.ResumeLayout(false);
            this.gbDevNo.PerformLayout();
            this.gbSingleOrMulti.ResumeLayout(false);
            this.gbPower.ResumeLayout(false);
            this.gbPower.PerformLayout();
            this.gbDataOutputFormat.ResumeLayout(false);
            this.gbUsbFormat.ResumeLayout(false);
            this.gbNotDoubleUSBDevice.ResumeLayout(false);
            this.GopRelayControl.ResumeLayout(false);
            this.tbRelayMode.ResumeLayout(false);
            this.tpInitiative.ResumeLayout(false);
            this.tpPassivity.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbTagAuth.ResumeLayout(false);
            this.gbTagAuth.PerformLayout();
            this.grpAntSet.ResumeLayout(false);
            this.grpAntSet.PerformLayout();
            this.gbBeepControl.ResumeLayout(false);
            this.SetReaderParam.ResumeLayout(false);
            this.gbFreq.ResumeLayout(false);
            this.gbFreq.PerformLayout();
            this.tbHoppingFrequency.ResumeLayout(false);
            this.tpUSA_Band.ResumeLayout(false);
            this.tpUSA_Band.PerformLayout();
            this.tpEU_Band.ResumeLayout(false);
            this.tpEU_Band.PerformLayout();
            this.tpKorea_Band.ResumeLayout(false);
            this.tpKorea_Band.PerformLayout();
            this.gbCommModeParam.ResumeLayout(false);
            this.tbCommMode.ResumeLayout(false);
            this.tpWiegand.ResumeLayout(false);
            this.tpWiegand.PerformLayout();
            this.tpSerialPorts.ResumeLayout(false);
            this.gbWorkMode.ResumeLayout(false);
            this.gbWorkMode.PerformLayout();
            this.tbWorkMode.ResumeLayout(false);
            this.tpTiming.ResumeLayout(false);
            this.tpTiming.PerformLayout();
            this.tpTrigger.ResumeLayout(false);
            this.tpTrigger.PerformLayout();
            this.SetCommParam.ResumeLayout(false);
            this.gbSPParams.ResumeLayout(false);
            this.gbSPParams.PerformLayout();
            this.gbNetParams.ResumeLayout(false);
            this.gbNetParams.PerformLayout();
            this.TagAccess.ResumeLayout(false);
            this.gbKillTag.ResumeLayout(false);
            this.gbKillTag.PerformLayout();
            this.gbTagInitialize.ResumeLayout(false);
            this.gbTagLockAndUnlock.ResumeLayout(false);
            this.gbTagLockAndUnlock.PerformLayout();
            this.gbFastWrite.ResumeLayout(false);
            this.gbFastWrite.PerformLayout();
            this.gbRWData.ResumeLayout(false);
            this.gbRWData.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.General.ResumeLayout(false);
            this.General.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.gbVersionInfo.ResumeLayout(false);
            this.gbConnectType.ResumeLayout(false);
            this.tbConnect.ResumeLayout(false);
            this.tpSerialPort.ResumeLayout(false);
            this.tpTCPClient.ResumeLayout(false);
            this.tpTCPClient.PerformLayout();
            this.tpTCPServer.ResumeLayout(false);
            this.tpTCPServer.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbLangSwitch;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label TagTID;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage OtherOpreation;
        private System.Windows.Forms.GroupBox GopRelayControl;
        private System.Windows.Forms.RadioButton rdoOpen1;
        private System.Windows.Forms.RadioButton rdoClose1;
        private System.Windows.Forms.Label lblCloseTime;
        private System.Windows.Forms.ComboBox cbbRelayTime;
        private System.Windows.Forms.RadioButton rdoOpen2;
        private System.Windows.Forms.RadioButton rdoClose2;
        private System.Windows.Forms.Button btnSetRelayTime;
        private System.Windows.Forms.GroupBox gbTagAuth;
        private System.Windows.Forms.Button btnQueryAuthorization;
        private System.Windows.Forms.Button btnAutoAuthorization;
        private System.Windows.Forms.Label labNewAuthPwd;
        private System.Windows.Forms.Label labAuthPwd;
        private System.Windows.Forms.TextBox tbNewAuthPwd;
        private System.Windows.Forms.TextBox tbAuthPwd;
        private System.Windows.Forms.Button btnTagAuth;
        private System.Windows.Forms.Button btnModifyAuthPwd;
        private System.Windows.Forms.GroupBox gbUsbFormat;
        private System.Windows.Forms.Button btnReadUsbFormat;
        private System.Windows.Forms.Button btnSetUsbFormat;
        private System.Windows.Forms.ComboBox cbbUsbFormat;
        private System.Windows.Forms.GroupBox gbBeepControl;
        private System.Windows.Forms.Button btnReadDataArea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSetDataArea;
        private System.Windows.Forms.ComboBox cbbDataArea;
        private System.Windows.Forms.Label lblReadVoice;
        private System.Windows.Forms.Button btnReadBeep;
        private System.Windows.Forms.Button btnSetBeep;
        private System.Windows.Forms.ComboBox cbbBeepControl;
        private System.Windows.Forms.TabPage SetReaderParam;
        private System.Windows.Forms.GroupBox grpAntSet;


        //private System.Windows.Forms.CheckBox chkAnt8;
        //private System.Windows.Forms.CheckBox chkAnt4;
        //private System.Windows.Forms.CheckBox chkAnt7;
        //private System.Windows.Forms.CheckBox chkAnt6;
        //private System.Windows.Forms.CheckBox chkAnt3;
        //private System.Windows.Forms.CheckBox chkAnt5;
        //private System.Windows.Forms.CheckBox chkAnt2;
        //private System.Windows.Forms.CheckBox chkAnt1;

        private System.Windows.Forms.Button btnAntSet;
        private System.Windows.Forms.Button btnAntRead;
        private System.Windows.Forms.GroupBox gbFreq;
        private System.Windows.Forms.ComboBox cbbEPCDataFormat;
        private System.Windows.Forms.Label EpcFormatLB;
        private System.Windows.Forms.CheckBox chkFp12;
        private System.Windows.Forms.CheckBox chkFp11;
        private System.Windows.Forms.CheckBox chkFp8;
        private System.Windows.Forms.CheckBox chkFp10;
        private System.Windows.Forms.CheckBox chkFp9;
        private System.Windows.Forms.CheckBox chkFp7;
        private System.Windows.Forms.CheckBox chkFp6;
        private System.Windows.Forms.CheckBox chkFp3;
        private System.Windows.Forms.CheckBox chkFp5;
        private System.Windows.Forms.CheckBox chkFp4;
        private System.Windows.Forms.CheckBox chkFp2;
        private System.Windows.Forms.CheckBox chkFp1;
        private System.Windows.Forms.CheckBox cbFp50;
        private System.Windows.Forms.CheckBox cbFp49;
        private System.Windows.Forms.CheckBox cbFp48;
        private System.Windows.Forms.Label labFreq;
        private System.Windows.Forms.CheckBox cbFp47;
        private System.Windows.Forms.CheckBox cbFp46;
        private System.Windows.Forms.CheckBox cbFp2;
        private System.Windows.Forms.CheckBox cbFp45;
        private System.Windows.Forms.CheckBox cbFp3;
        private System.Windows.Forms.CheckBox cbFp44;
        private System.Windows.Forms.CheckBox cbFp4;
        private System.Windows.Forms.CheckBox cbFp43;
        private System.Windows.Forms.CheckBox cbFp5;
        private System.Windows.Forms.CheckBox cbFp42;
        private System.Windows.Forms.CheckBox cbFp6;
        private System.Windows.Forms.CheckBox cbFp41;
        private System.Windows.Forms.CheckBox cbFp7;
        private System.Windows.Forms.CheckBox cbFp8;
        private System.Windows.Forms.CheckBox cbFp40;
        private System.Windows.Forms.CheckBox cbFp9;
        private System.Windows.Forms.CheckBox cbFp39;
        private System.Windows.Forms.CheckBox cbFp10;
        private System.Windows.Forms.CheckBox cbFp38;
        private System.Windows.Forms.CheckBox cbFp11;
        private System.Windows.Forms.CheckBox cbFp37;
        private System.Windows.Forms.CheckBox cbFp12;
        private System.Windows.Forms.CheckBox cbFp36;
        private System.Windows.Forms.CheckBox cbFp13;
        private System.Windows.Forms.CheckBox cbFp35;
        private System.Windows.Forms.CheckBox cbFp14;
        private System.Windows.Forms.CheckBox cbFp34;
        private System.Windows.Forms.CheckBox cbFp15;
        private System.Windows.Forms.CheckBox cbFp33;
        private System.Windows.Forms.CheckBox cbFp16;
        private System.Windows.Forms.CheckBox cbFp32;
        private System.Windows.Forms.CheckBox cbFp17;
        private System.Windows.Forms.CheckBox cbFp31;
        private System.Windows.Forms.CheckBox cbFp18;
        private System.Windows.Forms.CheckBox cbFp30;
        private System.Windows.Forms.CheckBox cbFp19;
        private System.Windows.Forms.CheckBox cbFp29;
        private System.Windows.Forms.CheckBox cbFp20;
        private System.Windows.Forms.CheckBox cbFp28;
        private System.Windows.Forms.CheckBox cbFp21;
        private System.Windows.Forms.CheckBox cbFp27;
        private System.Windows.Forms.CheckBox cbFp22;
        private System.Windows.Forms.CheckBox cbFp26;
        private System.Windows.Forms.CheckBox cbFp23;
        private System.Windows.Forms.CheckBox cbFp25;
        private System.Windows.Forms.CheckBox cbFp24;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnClearFreq;
        private System.Windows.Forms.Button btnDefaultFreq;
        private System.Windows.Forms.Button btnReadFreq;
        private System.Windows.Forms.ComboBox cbbFrequencyBand;
        private System.Windows.Forms.Label labSetParam;
        private System.Windows.Forms.Button btnSetFreq;
        private System.Windows.Forms.GroupBox gbCommModeParam;
        private System.Windows.Forms.Label lbl_rate;
        private System.Windows.Forms.ComboBox cbbBaud_Rate;
        private System.Windows.Forms.Button btnDefaultCommMode;
        private System.Windows.Forms.Button btnReadCommMode;
        private System.Windows.Forms.Label labPulseCycleUnit;
        private System.Windows.Forms.Button btnSetCommMode;
        private System.Windows.Forms.Label labPulseWidthUnit;
        private System.Windows.Forms.TextBox tbPulseCycle;
        private System.Windows.Forms.TextBox tbPulseWidth;
        private System.Windows.Forms.Label lblWigginsTakePlaceValue;
        private System.Windows.Forms.Label labWiegandProtocol;
        private System.Windows.Forms.ComboBox cbbWigginsTakePlaceValue;
        private System.Windows.Forms.ComboBox cbbWiegandProtocol;
        private System.Windows.Forms.Label labPulseCycle;
        private System.Windows.Forms.Label labPulseWidth;
        private System.Windows.Forms.GroupBox gbWorkMode;
        private System.Windows.Forms.ComboBox cbbReadSpeed;
        private System.Windows.Forms.CheckBox chkAjaDisc;
        private System.Windows.Forms.Button btnDefaultWorkMode;
        private System.Windows.Forms.Label labDelayUnit;
        private System.Windows.Forms.Button btnReadWorkMode;
        private System.Windows.Forms.Label labTimingUnit;
        private System.Windows.Forms.TextBox tbTiming;
        private System.Windows.Forms.TextBox tbDelay;
        private System.Windows.Forms.ComboBox cbbTrigSwitch;
        private System.Windows.Forms.Label labTrigSwitch;
        private System.Windows.Forms.Label labTimingParam;
        private System.Windows.Forms.Label labTrigParam;
        private System.Windows.Forms.Button btnSetWorkMode;
        private System.Windows.Forms.TextBox tbNeighJudge;
        private System.Windows.Forms.TabPage SetCommParam;
        private System.Windows.Forms.GroupBox gbSPParams;
        private System.Windows.Forms.Label labDataBits;
        private System.Windows.Forms.Label labCheckBits;
        private System.Windows.Forms.Label labBaudRate;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.ComboBox comboBoxCheckBits;
        private System.Windows.Forms.ComboBox comboBoxDataBits;
        private System.Windows.Forms.GroupBox gbNetParams;
        private System.Windows.Forms.Label labPromotion;
        private System.Windows.Forms.Label labDestPort;
        private System.Windows.Forms.Label labDestIP;
        private System.Windows.Forms.Label labGateway;
        private System.Windows.Forms.Label labPort;
        private System.Windows.Forms.Label labMask;
        private System.Windows.Forms.Label labIPAdd;
        private System.Windows.Forms.Label labIPMode;
        private System.Windows.Forms.Label labNetMode;
        private System.Windows.Forms.TextBox textBoxDestPort;
        private System.Windows.Forms.TextBox tbDestIP;
        private System.Windows.Forms.TextBox textBoxGateway;
        private System.Windows.Forms.TextBox textBoxPortNo;
        private System.Windows.Forms.TextBox textBoxNetMask;
        private System.Windows.Forms.TextBox textBoxIPAdd;
        private System.Windows.Forms.ComboBox comboBoxIPMode;
        private System.Windows.Forms.ComboBox comboBoxNetMode;
        private System.Windows.Forms.Button btnSetParams;
        private System.Windows.Forms.Button btnDefaultParams;
        private System.Windows.Forms.Button btnModifyDev;
        private System.Windows.Forms.Button btnSearchDev;
        private System.Windows.Forms.ListView lvZl;
        private System.Windows.Forms.ColumnHeader columnHeaderNo;
        private System.Windows.Forms.ColumnHeader columnHeaderIPAdd;
        private System.Windows.Forms.ColumnHeader columnHeaderPort;
        private System.Windows.Forms.ColumnHeader columnHeaderMAC;
        protected internal System.Windows.Forms.TabPage TagAccess;
        private System.Windows.Forms.GroupBox gbFastWrite;
        private System.Windows.Forms.CheckBox chkZD;
        private System.Windows.Forms.Label labFWPromo;
        private System.Windows.Forms.Button btnClearFWData;
        private System.Windows.Forms.Button btnFastWrite;
        private System.Windows.Forms.Label labFWData;
        private System.Windows.Forms.TextBox tbFWData;
        private System.Windows.Forms.Button btnInitTag;
        private System.Windows.Forms.Button btnUnlockTag;
        private System.Windows.Forms.Button btnLockTag;
        private System.Windows.Forms.Button btnKillTag;
        private System.Windows.Forms.Label labLockBank;
        private System.Windows.Forms.Label labLockAccessPwd;
        private System.Windows.Forms.Label labDestroyPwd;
        private System.Windows.Forms.TextBox tbLockAccessPwd;
        private System.Windows.Forms.TextBox tbKillKillPwd;
        private System.Windows.Forms.ComboBox cbbLockBank;
        private System.Windows.Forms.GroupBox gbRWData;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rbAnt1;
        private System.Windows.Forms.RadioButton rbAnt2;
        private System.Windows.Forms.RadioButton rbAnt3;
        private System.Windows.Forms.RadioButton rbAnt8;
        private System.Windows.Forms.RadioButton rbAnt4;
        private System.Windows.Forms.RadioButton rbAnt7;
        private System.Windows.Forms.RadioButton rbAnt5;
        private System.Windows.Forms.RadioButton rbAnt6;
        private System.Windows.Forms.CheckBox chkDesignatedAntWrite;
        private System.Windows.Forms.CheckBox chkDesignatedAntRead;
        private System.Windows.Forms.Button btnWeigandConvert;
        private System.Windows.Forms.RadioButton rbWeigand26_3_0;
        private System.Windows.Forms.RadioButton rbWeigand26_1_2;
        private System.Windows.Forms.TextBox wiegandTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdvancedAccess;
        private System.Windows.Forms.Button btn_stoptimer;
        private System.Windows.Forms.Button btn_connRead;
        private System.Windows.Forms.Label labData;
        private System.Windows.Forms.Label labLength;
        private System.Windows.Forms.Label labStartAdd;
        private System.Windows.Forms.Label labOprBank;
        private System.Windows.Forms.Button btnWriteData;
        private System.Windows.Forms.Button btnClearData;
        private System.Windows.Forms.Button btnReadData;
        private System.Windows.Forms.TextBox tbRWData;
        private System.Windows.Forms.ComboBox cbbLength;
        private System.Windows.Forms.ComboBox cbbStartAdd;
        private System.Windows.Forms.ComboBox cbbRWBank;
        private System.Windows.Forms.TabPage General;
        private System.Windows.Forms.CheckBox cbSaveFile;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblTagCount;
        private System.Windows.Forms.Label labReadCount;
        private System.Windows.Forms.Label labTagCount;
        private System.Windows.Forms.RadioButton rbDesc;
        private System.Windows.Forms.RadioButton rbAsc;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Button btnClearListView;
        private System.Windows.Forms.Button btnStopReadData;
        private System.Windows.Forms.Button btnStartReadData;
        private System.Windows.Forms.Button btnReadOnce;
        //private ListViewContrl.DoubleBufferListView listView;     //2021-03-06
        private System.Windows.Forms.ListView listView;        //2021-03-06

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.GroupBox gbVersionInfo;
        private System.Windows.Forms.GroupBox gbConnectType;
        private System.Windows.Forms.Button btnReadVersion;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.TabControl tbConnect;
        private System.Windows.Forms.TabPage tpSerialPort;
        private System.Windows.Forms.TabPage tpTCPClient;
        private System.Windows.Forms.TabPage tpTCPServer;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.ComboBox cbbBaudRate;
        private System.Windows.Forms.Label lblSerialPort;
        private System.Windows.Forms.ComboBox cbbSerialPort;
        private System.Windows.Forms.Button btnUpdateSerialPort;
        private System.Windows.Forms.Button btnSerialPortDisconnect;
        private System.Windows.Forms.Button btnSerialPortConnect;
        private System.Windows.Forms.TextBox tbTCPClientPort;
        private System.Windows.Forms.Label lblTCPClientPort;
        private System.Windows.Forms.Label lblTCPClientIP;
        private System.Windows.Forms.ComboBox cbbTCPClientIP;
        private System.Windows.Forms.Button btnTCPClientDisconnect;
        private System.Windows.Forms.Button btnTCPClientConnect;
        private System.Windows.Forms.TextBox tbTCPServerPort;
        private System.Windows.Forms.Label lblTCPServerPort;
        private System.Windows.Forms.Label lblTCPServerIP;
        private System.Windows.Forms.Button btnUpdateTCPServer;
        private System.Windows.Forms.ComboBox cbbTCPServerIP;
        private System.Windows.Forms.Button btnStopMonitor;
        private System.Windows.Forms.Button btnStartMonitor;
        private System.Windows.Forms.TreeView tvConnectList;
        private System.Windows.Forms.Button btnBrushVersion;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.Button btnUpdateTCPClient;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblInfoShow;
        private System.Windows.Forms.Label lblMessageHit;
        private System.Windows.Forms.TabControl tbRelayMode;
        private System.Windows.Forms.TabPage tpInitiative;
        private System.Windows.Forms.TabPage tpPassivity;
        private System.Windows.Forms.GroupBox gbTagLockAndUnlock;
        private System.Windows.Forms.GroupBox gbTagInitialize;
        private System.Windows.Forms.GroupBox gbKillTag;
        private System.Windows.Forms.GroupBox gbNotDoubleUSBDevice;
        private System.Windows.Forms.Button btnSetEPCDataFormat;
        private System.Windows.Forms.Button btnReadEPCDataFormat;
        private System.Windows.Forms.GroupBox gbDataOutputFormat;
        private System.Windows.Forms.TabControl tbWorkMode;
        private System.Windows.Forms.TabPage tpMaster;
        private System.Windows.Forms.TabPage tpTiming;
        private System.Windows.Forms.TabPage tpTrigger;
        private System.Windows.Forms.TabControl tbCommMode;
        private System.Windows.Forms.TabPage tpRS485_RJ45;
        private System.Windows.Forms.TabPage tpWiegand;
        private System.Windows.Forms.TabPage tpSerialPorts;
        private System.Windows.Forms.TabControl tbHoppingFrequency;
        private System.Windows.Forms.TabPage tpUSA_Band;
        private System.Windows.Forms.TabPage tpEU_Band;
        private System.Windows.Forms.GroupBox gbDevNo;
        private System.Windows.Forms.Button btnSetDeviceId;
        private System.Windows.Forms.Button btnReadDeviceId;
        private System.Windows.Forms.TextBox tbNewDevNo;
        private System.Windows.Forms.GroupBox gbSingleOrMulti;
        private System.Windows.Forms.Button btnSetReadMode;
        private System.Windows.Forms.Button btnGetReadMode;
        private System.Windows.Forms.ComboBox cbbSingOrMulti;
        private System.Windows.Forms.GroupBox gbPower;
        private System.Windows.Forms.Button btnSetPower;
        private System.Windows.Forms.Button btnReadPower;
        private System.Windows.Forms.TextBox tbPower;
        private System.Windows.Forms.CheckBox chkAnt1;
        private System.Windows.Forms.CheckBox chkAnt2;
        private System.Windows.Forms.CheckBox chkAnt4;
        private System.Windows.Forms.CheckBox chkAnt3;
        private System.Windows.Forms.CheckBox chkAnt8;
        private System.Windows.Forms.CheckBox chkAnt7;
        private System.Windows.Forms.CheckBox chkAnt6;
        private System.Windows.Forms.CheckBox chkAnt5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnReadFastTag;
        private System.Windows.Forms.GroupBox gbSerialNumber;
        private System.Windows.Forms.Button btnSetSerialNumber;
        private System.Windows.Forms.Button btnReadSerialNumber;
        private System.Windows.Forms.TextBox tbSerialNumber;
        private System.Windows.Forms.Label lblFrequencyArea;
        private System.Windows.Forms.CheckBox chkFreqEUAll1;
        private System.Windows.Forms.CheckBox chkFreqEUAll2;
        private System.Windows.Forms.CheckBox chkFreqUSAll1;
        private System.Windows.Forms.CheckBox chkFreqUSAll5;
        private System.Windows.Forms.CheckBox chkFreqUSAll4;
        private System.Windows.Forms.CheckBox chkFreqUSAll3;
        private System.Windows.Forms.CheckBox chkFreqUSAll2;
        private System.Windows.Forms.TabPage tpKorea_Band;
        private System.Windows.Forms.CheckBox chkFreqKoreanAll;
        private System.Windows.Forms.CheckBox chkFreqKorean1;
        private System.Windows.Forms.CheckBox chkFreqKorean2;
        private System.Windows.Forms.CheckBox chkFreqKorean4;
        private System.Windows.Forms.CheckBox chkFreqKorean5;
        private System.Windows.Forms.CheckBox chkFreqKorean3;
        private System.Windows.Forms.CheckBox chkFreqKorean6;
        private System.Windows.Forms.ComboBox cbbFrequency_Mode;
        private System.Windows.Forms.ComboBox cbbFixFrequency;
        private System.Windows.Forms.CheckBox cbFp1;
        private System.Windows.Forms.Timer timerConnRead;
        private System.Windows.Forms.ComboBox cbbDestIP;

        public System.EventHandler OtherOpreation_Enter { get; set; }
    }
}

