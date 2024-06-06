using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace DisDemo
{
    public struct WSADATA
    {
        public short wVersion;
        public short wHighVersion;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
        public string szDescription;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
        public string szSystemStatus;
        [Obsolete] // Ignored for v2.0 and above 
        public int wMaxSockets;
        [Obsolete] // Ignored for v2.0 and above 
        public int wMAXUDPDG;
        public IntPtr dwVendorInfo;
    }

    public class SocketService
    {
        [DllImport("ws2_32.dll")]
        public static extern Int32 WSAStartup(UInt16 wVersionRequested, ref  WSADATA wsaData);
        [DllImport("ws2_32.dll")]
        public static extern Int32 WSACleanup();
    }
}
