using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace DisDemo
{
    public struct OutputInfoStruct
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 200)]
        public byte[] id_data;              //id编号
        public byte data_len;                //id数据长度
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string host;                 //通信方式(例如：COM1 or 192.168.1.200)
        public byte host_len;                //通信方式名称的长度
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string baud_rate_or_port;    //波特率(串口)或端口(IP)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string antNo;                //天线号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string device_id;            //设备号
        public byte connect_exception;      //网络异常
        public byte connect_type;           //串口 (0) | TCP Client(1)  | TCP Server(2)监听  
    }

    public struct SocketInfoStruct
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] IP;               //通信方式(例如：COM1 or 192.168.1.200)
        public byte data_len;           //通信方式名称的长度
        public short port;              //端口
        public int socket;              //套字节
        //struct sockaddr_in srvaddr;
    }

    public class Discrete
    {
        /// <summary>
        /// 数据信息回调
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="outputInfo"></param>
        public delegate void FUN_DATA_CB(int hDev, ref OutputInfoStruct outputInfo);

        /// <summary>
        /// 监听后Socket回调信息
        /// </summary>
        /// <param name="outputInfo"></param>
        public delegate void FUN_SOCKET_CB(ref SocketInfoStruct outputInfo);

        /// <summary>
        /// 启动监听
        /// </summary>
        /// <param name="hServerSocket"></param>
        /// <param name="f"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "StartListening", CallingConvention = CallingConvention.Cdecl)]
        public static extern int StartListening(ref int hServerSocket, FUN_SOCKET_CB f, short port);

        /// <summary>
        /// 停止监听
        /// </summary>
        /// <param name="hServerSocket"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "StopListening", CallingConvention = CallingConvention.Cdecl)]
        public static extern int StopListening(int hServerSocket);

        /// <summary>
        /// TCP Server 连接(监听后在回调中调用)
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="socket"></param>
        /// <param name="f"></param>
        /// <param name="host"></param>
        /// <param name="baudrateOrPort"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "TCPServerConnect", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCPServerConnect(ref int hDev, int socket, FUN_DATA_CB f, string host, int baudrateOrPort);

        /// <summary>
        /// 断开设备连接
        /// </summary>
        /// <param name="hDev"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "DisconnectDev", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DisconnectDev(int hDev);

        /// <summary>
        /// 设备连接
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="f"></param>
        /// <param name="host"></param>
        /// <param name="baudrateOrPort"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "ConnectDev", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ConnectDev(ref int hDev, FUN_DATA_CB f, string host, int baudrateOrPort);

        /// <summary>
        /// 查询固件版本号
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "QueryVersion", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryVersion(int hDev,byte[] version);

        /// <summary>
        /// 单次读卡
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="data"></param>
        /// <param name="data_len"></param>
        /// <param name="device_no"></param>
        /// <param name="antenna_no"></param>
        /// <param name="IP_or_comm"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "ReadSingleTag", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadSingleTag(int hDev, byte[] data, out byte data_len, out byte device_no, out byte antenna_no, byte[] IP_or_comm);

        /// <summary>
        /// 连续读卡
        /// </summary>
        /// <param name="hDev"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "BeginInv", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BeginInv(int hDev);

        /// <summary>
        /// 停止连续读卡
        /// </summary>
        /// <param name="hDev"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "StopInv", CallingConvention = CallingConvention.Cdecl)]
        public static extern int StopInv(int hDev);


        #region 标签操作
        /// <summary>
        /// 快写标签
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="data"></param>
        /// <param name="length"></param>
        /// <returns></returns>
       [DllImport("libDiscrete.dll", EntryPoint = "FastWriteTag", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FastWriteTag(int hDev, byte [] data, byte length);

        /// <summary>
        /// 指定区域读标签
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="bank"></param>
        /// <param name="begin"></param>
        /// <param name="length"></param>
        /// <param name="data"></param>
        /// <param name="data_len"></param>
        /// <returns></returns>
       [DllImport("libDiscrete.dll", EntryPoint = "ReadTagData", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadTagData(int hDev, byte bank, byte begin,byte length, byte [] data,out byte data_len);

        /// <summary>
        /// 指定区域写标签
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="bank"></param>
        /// <param name="begin"></param>
        /// <param name="length"></param>
        /// <param name="data"></param>
        /// <returns></returns>
       [DllImport("libDiscrete.dll", EntryPoint = "WriteTagData", CallingConvention = CallingConvention.Cdecl)]
       public static extern int WriteTagData(int hDev, byte bank, byte begin, byte length, byte[] data);

        /// <summary>
        /// 标签加锁
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="unlock_type"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "LockTag", CallingConvention = CallingConvention.Cdecl)]
        public static extern int LockTag(int hDev, byte unlock_type, byte [] password);

        /// <summary>
        /// 标签解锁
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="unlock_type"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "UnLockTag", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UnLockTag(int hDev, byte unlock_type, byte [] password);

        /// <summary>
        /// 销毁标签
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "KillTag", CallingConvention = CallingConvention.Cdecl)]
        public static extern int KillTag(int hDev, byte[] password);

        /// <summary>
        /// 初始化标签
        /// </summary>
        /// <param name="hDev"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "InitializeTag", CallingConvention = CallingConvention.Cdecl)]
        public static extern int InitializeTag(int hDev);
        #endregion 标签操作

        /// <summary>
        /// 更新频点
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="national_standard"></param>
        /// <param name="fixed_or_hopping_freq"></param>
        /// <param name="frequency_point"></param>
        /// <param name="frequency_point_len"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "UpdateFrequencyPoints", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateFrequencyPoints(int hDev, byte national_standard, byte fixed_or_hopping_freq, byte[] frequency_point, byte frequency_point_len);

        /// <summary>
        /// 查询频点
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="national_standard"></param>
        /// <param name="fixed_or_hopping_freq"></param>
        /// <param name="frequency_point"></param>
        /// <param name="frequency_point_len"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "QueryFrequencyPoints", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryFrequencyPoints(int hDev, out byte national_standard, out byte fixed_or_hopping_freq, byte[] frequency_point, out byte frequency_point_len);


        #region 工作模式
        /// <summary>
        /// 更新工作模式
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "UpdateWorkMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateWorkMode(int hDev, byte mode);

        /// <summary>
        /// 查询工作模式
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "QueryWorkMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryWorkMode(int hDev, out byte mode);

        /// <summary>
        /// 更新相邻判别状态
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "UpdateAdjacentDiscriminantStatus", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateAdjacentDiscriminantStatus(int hDev, byte status);

        /// <summary>
        /// 查询相邻判别状态
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "QueryAdjacentDiscriminantStatus", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryAdjacentDiscriminantStatus(int hDev, out byte status);

        /// <summary>
        /// 更新相邻判别时间
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "UpdateAdjacentDiscriminantTime", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateAdjacentDiscriminantTime(int hDev, byte time);

        /// <summary>
        /// 查询相邻判别时间
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "QueryAdjacentDiscriminantTime", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryAdjacentDiscriminantTime(int hDev, out byte time);

        /// <summary>
        /// 更新触发延迟时间
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "UpdateTriggerDelayTime", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateTriggerDelayTime(int hDev, byte time);

        /// <summary>
        /// 查询触发延迟时间
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "QueryTriggerDelayTime", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryTriggerDelayTime(int hDev, out byte time);

        /// <summary>
        /// 查询定时间隔速度
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "QueryTimeIntervalSpeed", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryTimeIntervalSpeed(int hDev, out byte time);

        /// <summary>
        /// 更新定时间隔速度
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "UpdateTimeIntervalSpeed", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateTimeIntervalSpeed(int hDev, byte time);

        /// <summary>
        /// 更新定时间隔
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "UpdateTimeInterval", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateTimeInterval(int hDev, byte time);

        /// <summary>
        /// 查询定时间隔
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "QueryTimeInterval", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryTimeInterval(int hDev, out byte time);

        /// <summary>
        /// 更新触发开关
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "UpdateTriggerSwitch", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateTriggerSwitch(int hDev, byte status);

        /// <summary>
        /// 查询触发开关
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "QueryTriggerSwitch", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryTriggerSwitch(int hDev,out byte status);
        #endregion 工作模式

        #region 通讯方式
        /// <summary>
        /// 更新输出模式
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="output_mode"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "UpdateOutputMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateOutputMode(int hDev, byte output_mode);

        /// <summary>
        /// 查询输出模式
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="output_mode"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "QueryOutputMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryOutputMode(int hDev, out byte  output_mode);

        /// <summary>
        /// 更新波特率
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="baud_rate"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "UpdateBaudRate", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateBaudRate(int hDev, byte baud_rate);

        /// <summary>
        /// 查询波特率
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="baud_rate"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "QueryBaudRate", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryBaudRate(int hDev, out byte  baud_rate);

        /// <summary>
        /// 更新韦根协议
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="wiegand_proto"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "UpdateWiegandProto", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateWiegandProto(int hDev, byte wiegand_proto);

        /// <summary>
        /// 查询韦根协议
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="wiegand_proto"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "QueryWiegandProto", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryWiegandProto(int hDev,out byte  wiegand_proto);

        /// <summary>
        /// 更新韦根脉冲宽度
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="wiegand_pulse_width"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "UpdateWiegandPulseWidth", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateWiegandPulseWidth(int hDev, byte wiegand_pulse_width);

        /// <summary>
        /// 查询韦根脉冲宽度
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="wiegand_pulse_width"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "QueryWiegandPulseWidth", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryWiegandPulseWidth(int hDev,out byte  wiegand_pulse_width);

        /// <summary>
        /// 更新韦根脉冲周期
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="wiegand_pulse_cycle"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "UpdateWiegandPulseCycle", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateWiegandPulseCycle(int hDev, byte wiegand_pulse_cycle);

        /// <summary>
        /// 查询韦根脉冲周期
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="wiegand_pulse_cycle"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "QueryWiegandPulseCycle", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryWiegandPulseCycle(int hDev,out byte  wiegand_pulse_cycle);

        /// <summary>
        /// 查询韦根值
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="wiegand_value"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "UpdateWiegandValue", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateWiegandValue(int hDev, byte wiegand_value);

        /// <summary>
        /// 更新韦根值
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="wiegand_value"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "QueryWiegandValue", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryWiegandValue(int hDev,out byte  wiegand_value);

        #endregion 通讯方式

        #region 其他操作
        /// <summary>
        /// 标签授权
        /// </summary>
        /// <param name="hDev"></param>
        /// <returns></returns>

        [DllImport("libDiscrete.dll", EntryPoint = "TagAuther", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TagAuther(int hDev);

        /// <summary>
        /// 查询授权码
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="pwd"></param>
        /// <param name="pwd_len"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "QueryAutherPwd", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryAutherPwd(int hDev,byte [] pwd,out byte pwd_len);

        /// <summary>
        /// 更新授权码
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="newPwd"></param>
        /// <param name="pwd_len"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "UpdateAutherPwd", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateAutherPwd(int hDev, byte[] newPwd, byte pwd_len);

        /// <summary>
        /// GPIO设置被动模式下2路GPIO
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="on_or_off_1"></param>
        /// <param name="on_or_off_2"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "UpdateRelay", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateRelay(int hDev, bool on_or_off_1, bool on_or_off_2);

        /// <summary>
        /// GPIO设置模式(0:主动模式 1:被动模式)
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "UpdateRelayInitiativeOrPassivity", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateRelayInitiativeOrPassivity(int hDev, byte mode);

        /// <summary>
        /// GPIO设置主动模式下时间
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "UpdateRelayInitiativeCloseTime", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateRelayInitiativeCloseTime(int hDev, byte time);

        /// <summary>
        /// 查询非USB输出数据格式
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "QueryUsbOutputFormat", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryUsbOutputFormat(int hDev, out byte format);

        /// <summary>
        /// 更新非USB输出数据格式
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "UpdateUsbOutputFormat", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateUsbOutputFormat(int hDev, byte format);

        /// <summary>
        /// 查询非USB输出数据格式
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "QueryNotUsbOutputFormat", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryNotUsbOutputFormat(int hDev,out byte format);

        /// <summary>
        /// 更新非USB输出数据格式
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "UpdateNotUsbOutputFormat", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateNotUsbOutputFormat(int hDev, byte format);

        /// <summary>
        /// 查询读卡区域
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="operation_area"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "QueryEpcOrTid", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryEpcOrTid(int hDev,out byte operation_area);

        /// <summary>
        /// 更新读卡区域
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="operation_area"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "UpdateEpcOrTid", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateEpcOrTid(int hDev, byte operation_area);
        /// <summary>
        /// 更新蜂鸣器(声音)
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "UpdateBuzzer", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateBuzzer(int hDev, byte status);

        /// <summary>
        /// 查询蜂鸣器(声音)
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "QueryBuzzer", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryBuzzer(int hDev,out byte status);

        /// <summary>
        /// 更新天线参数
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="antenna"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "UpdateAntenna", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateAntenna(int hDev, byte[] antenna);

        /// <summary>
        /// 查询天线参数
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="antenna"></param>
        /// <param name="antenna_len"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "QueryAntenna", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryAntenna(int hDev, byte[] antenna,out byte antenna_len);

        /// <summary>
        /// 更新读卡模式 单标签或多标签
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="single_or_multi"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "UpdateSingleOrMultiTag", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateSingleOrMultiTag(int hDev,byte single_or_multi);

        /// <summary>
        /// 查询读卡模式 单标签或多标签
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="single_or_multi"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "QuerySingleOrMultiTag", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QuerySingleOrMultiTag(int hDev,out byte single_or_multi);


        /// <summary>
        /// 更新功率
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "UpdatePower", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdatePower(int hDev, byte power);

        /// <summary>
        /// 查询功率
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "QueryPower", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryPower(int hDev, out byte power);

        /// <summary>
        /// 更新设备号
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="device_id"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "UpdateDeviceId", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateDeviceId(int hDev, byte device_id);

        /// <summary>
        /// 查询设备号
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="device_id"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "QueryDeviceId", CallingConvention = CallingConvention.Cdecl)]
        public static extern int  QueryDeviceId(int hDev,out byte device_id);

        #endregion 其他操作

        /// <summary>
        /// 查询设备出厂序列号(仅设备厂商使用,不对外公开)
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="serial_number"></param>
        /// <param name="serial_number_len"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "QueryDeviceSerialNumber", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryDeviceSerialNumber(int hDev, byte[] serial_number,out byte serial_number_len);

        /// <summary>
        /// 设置设备出厂序列号(仅设备厂商使用,不对外公开)
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="serial_number"></param>
        /// <returns></returns>
        [DllImport("libDiscrete.dll", EntryPoint = "UpdateDeviceSerialNumber", CallingConvention = CallingConvention.Cdecl)]
        public static extern int  UpdateDeviceSerialNumber(int hDev,char [] serial_number);
    }
}
