using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DisDemo
{
    public class TagOperation
    {
        public static void InitAccessTagControl(ComboBox cbbRWBank, ComboBox cbbLockBank)
        {

            // 读写区域
            cbbRWBank.Items.Clear();
            cbbRWBank.Items.Add("RFU");
            cbbRWBank.Items.Add("EPC");
            cbbRWBank.Items.Add("TID");
            cbbRWBank.Items.Add("User");

            // 锁卡区域
            //cbbLockBank.Items.Add("Kill");
            //cbbLockBank.Items.Add("Access");
            //cbbLockBank.Items.Add("EPC");
            //cbbLockBank.Items.Add("TID");
            //cbbLockBank.Items.Add("User");
        }
    }
}
