using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace DisDemo
{
    /// <summary>
    /// 捷通网络模块管理
    /// </summary>
    public class JTDM
    {
        public static ushort m_DevCnt;    // 搜索到的设备数量
        public static byte  m_SelectedDevNo = 0;//当前选中的设备下标

        //注意: 执行更新操作UpdateParam(才更修改参数)

        /// <summary>
        /// 搜索设备
        /// </summary>
        /// <param name="devices"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "StartSearchDev", CallingConvention = CallingConvention.Cdecl)]
        public static extern int StartSearchDev(out ushort devices);

        /// <summary>
        /// 查询本机IP
        /// </summary>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "QueryLocalHosts", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryLocalHosts(byte[] value, out byte count);

        /// <summary>
        /// 查询版本号信息
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "QueryVersion", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryVersion(char[] version);

        /// <summary>
        /// 执行更新操作(才更修改参数)
        /// </summary>
        /// <param name="hDev"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "UpdateParam", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateParam(byte hDev);

        /// <summary>
        /// 查询MAC地址
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="device_id"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "QueryDevID", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryDevID(byte hDev, byte[] device_id);

        /// <summary>
        /// 查询设备名称
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="device_name"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "QueryDevName", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryDevName(byte hDev, byte[] device_name);

        /// <summary>
        /// 查询IP模式
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="IP_mode"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "QueryIPMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryIPMode(byte hDev, out byte IP_mode);

        /// <summary>
        /// 查询设备IP地址
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="IP"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "QueryIP", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryIP(byte hDev, byte[] IP);

        /// <summary>
        /// 查询设备端口号
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "QueryPort", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryPort(byte hDev, out int port);

        /// <summary>
        /// 查询网关
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="gate_way"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "QueryGateWay", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryGateWay(byte hDev, byte[] gate_way);

        /// <summary>
        /// 查询网络模式
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="work_mode"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "QueryNetworkMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryNetworkMode(byte hDev, out byte work_mode);

        /// <summary>
        /// 查询子网掩码
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="net_mask"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "QuerySubnetMask", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QuerySubnetMask(byte hDev, byte[] net_mask);

        /// <summary>
        /// 查询TCP Server模式下目的IP
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="dest_name"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "QueryDestName", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryDestName(byte hDev, byte[] dest_name);

        /// <summary>
        /// 查询TCP Server模式下目的端口
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="dest_port"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "QueryDestPort", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryDestPort(byte hDev, out ushort dest_port);

        /// <summary>
        /// 查询网口模块下的波特率
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="baudrate_index"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "QueryBaudrateIndex", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryBaudrateIndex(byte hDev, out byte baudrate_index);

        /// <summary>
        /// 查询网口模块下的校验和
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="parity"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "QueryParity", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryParity(byte hDev, out byte parity);

        /// <summary>
        /// 查询网口模块下的数据位
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="data_bits"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "QueryDataBits", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryDataBits(byte hDev, out byte data_bits);

        /// <summary>
        /// 更新设备名称
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="dev_name"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "UpdateDevName", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateDevName(byte hDev, char[] dev_name);

        /// <summary>
        /// 更新设备IP
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="IP"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "UpdateIP", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateIP(byte hDev, byte[] IP);

        /// <summary>
        /// 更新网关
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="gate_way"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "UpdateGateWay", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateGateWay(byte hDev, byte[] gate_way);

        /// <summary>
        /// 更新子网掩码
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="net_mask"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "UpdateSubnetMask", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateSubnetMask(byte hDev, byte[] net_mask);

        /// <summary>
        /// 更新目的IP
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="dest_name"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "UpdateDestName", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateDestName(byte hDev, byte[] dest_name);

        /// <summary>
        /// 更新IP模式
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="IP_mode"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "UpdateIPMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateIPMode(byte hDev, byte IP_mode);

        /// <summary>
        /// 更新设备端口
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="Port"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "UpdatePort", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdatePort(byte hDev, ushort Port);

        /// <summary>
        /// 更新网络模式
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="work_mode"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "UpdateNetworkMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateNetworkMode(byte hDev, byte work_mode);

        /// <summary>
        /// 更新目的端口
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="dest_port"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "UpdateDestPort", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateDestPort(byte hDev, ushort dest_port);

        /// <summary>
        /// 更新网口模块下的波特率
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="baudrate_Index"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "UpdateBaudrateIndex", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateBaudrateIndex(byte hDev, byte baudrate_Index);

        /// <summary>
        /// 网口模块下的校验和
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="parity"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "UpdateParity", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateParity(byte hDev, byte parity);

        /// <summary>
        /// 网口模块下的数据位
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="data_bits"></param>
        /// <returns></returns>
        [DllImport("libJTDevManage.dll", EntryPoint = "UpdateDataBits", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateDataBits(byte hDev, byte data_bits);
    }
}
