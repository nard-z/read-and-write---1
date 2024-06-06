using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DisDemo
{
   public class EnglishLanguage
    {


       public static void language(ComboBox cbbLockBank, ComboBox cbbTrigSwitch, 
                            ComboBox cbbSingOrMulti, ComboBox cbbFreqModeUS,
                            ComboBox cboBand,
                            ComboBox cbbBeepControl,ComboBox cbbUsbFormat,
                            ComboBox cbbEPCDataFormat)
       {
           cbbLockBank.Items.Add("User");
           cbbLockBank.Items.Add("EPC");
           cbbLockBank.Items.Add("AccessPwd");
           cbbLockBank.Items.Add("KillPwd");
           cbbLockBank.Items.Add("All");
           // 工作模式
           //cbbWorkMode.Items.Add("Master/Slave");
           //cbbWorkMode.Items.Add("Timing");
           //cbbWorkMode.Items.Add("Trigger");
           // 触发模式
           cbbTrigSwitch.Items.Add("Off");
           cbbTrigSwitch.Items.Add("High level");

           // 通信方式
           //cbbCommMode.Items.Add("RS485/RJ45");
           //cbbCommMode.Items.Add("Wiegand");
           //cbbCommMode.Items.Add("RS232");
           // 读卡模式
           cbbSingOrMulti.Items.Add("Single Tag");
           cbbSingOrMulti.Items.Add("Multi Tag");
           // 频率设置
           cbbFreqModeUS.Items.Clear();
           cbbFreqModeUS.Items.Add("Freq Hopping");
           cbbFreqModeUS.Items.Add("Fixed Freq");

           // 频率标名
           cboBand.Items.Add("US Band");
           cboBand.Items.Add("EU Band");
           cboBand.Items.Add("Korea Band");
           //cboBand.Items.Add("Chinese Band");

           // 读卡声音控制
           cbbBeepControl.Items.Add("Off");
           cbbBeepControl.Items.Add("Continuous");
           cbbBeepControl.Items.Add("Only once");
           // USB输出格式
           cbbUsbFormat.Items.Add("Wiegand26 (1B+2B) 8bits(Dec) ");
           cbbUsbFormat.Items.Add("Wiegand26 3B 8bits(Dec)");
           cbbUsbFormat.Items.Add("00+3Bytes(Hex)");
           cbbUsbFormat.Items.Add("4Bytes(Hex)");
           cbbUsbFormat.Items.Add("12Bytes(Hex)");
           cbbUsbFormat.Items.Add("12Bytes(TID)");
           cbbUsbFormat.Items.Add("0000+3Bytes(Front) ");
           cbbUsbFormat.Items.Add("Raw data (ensure that the original data is Ascii)");
           cbbUsbFormat.Items.Add("Bar Code Output");
           cbbEPCDataFormat.Items.Add("Non-standard length EPC");
           cbbEPCDataFormat.Items.Add("Standard 12-byte EPC");
           cbbEPCDataFormat.SelectedIndex = 1;
       }
    }
}
