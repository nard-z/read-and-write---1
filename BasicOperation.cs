using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace DisDemo
{
    public class BasicOperation
    {
        public static void InitTableInfoColumns(System.Windows.Forms.ListView listView)
        {
            listView.Columns.Clear();
            listView.Columns.Add("序号", 45, HorizontalAlignment.Center);
            listView.Columns.Add("EPC/TID", 300, HorizontalAlignment.Center);
            listView.Columns.Add("次数", 60, HorizontalAlignment.Center);
            listView.Columns.Add("天线号", 60, HorizontalAlignment.Center);
            listView.Columns.Add("设备", 60, HorizontalAlignment.Center);
            listView.Columns.Add("串口/IP", 150, HorizontalAlignment.Center);
            listView.Columns.Add("读卡时间", 200, HorizontalAlignment.Center);
        }
        
        private static void GetSerialPortList(ref ComboBox comboBoxSP)
        {
            comboBoxSP.Items.Clear();
            comboBoxSP.Items.AddRange(SerialPort.GetPortNames());
            if (comboBoxSP.Items.Count > 0)
            {
                comboBoxSP.SelectedIndex = 0;
            }
        }

        public static void InitalConnectType(ComboBox cbbSerialPort, ComboBox cbbBaudRate)
        {
            GetSerialPortList(ref cbbSerialPort);
            cbbSerialPort.SelectedIndex = 0;
            cbbBaudRate.Items.Clear();
            cbbBaudRate.Items.Add("9600");
            cbbBaudRate.Items.Add("19200");
            cbbBaudRate.Items.Add("38400");
            cbbBaudRate.Items.Add("57600");
            cbbBaudRate.Items.Add("115200");
            cbbBaudRate.SelectedIndex = 0;
        }
    }
}
