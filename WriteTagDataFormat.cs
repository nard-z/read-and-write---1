using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Resources;
using System.Threading.Tasks;
using System.Threading;

namespace DisDemo
{
    public partial class WriteTagDataFormat : Form
    {
        private ResourceManager rm;
        SynchronizationContext m_SyncContext = null;
        private string formatError;
        public WriteTagDataFormat()
        {
            InitializeComponent();
        }

        public static Dictionary<string, MultiArea> tables; 

        public WriteTagDataFormat(ResourceManager rm)
        {
            InitializeComponent();
            this.rm = rm;
            m_SyncContext = SynchronizationContext.Current;
            InitPara();
            this.ChangeLanguage(rm);
        }

        private void InitPara()
        {
            foreach (string key in tables.Keys)
            {
                switch (key)
                {
                    case "EPC":
                        EPCcheck.Checked = true;
                        break;
                    case "RFU":
                        Reservecheck.Checked = true;
                        break;
                    case "USER":
                        Usercheck.Checked = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                byte sample = 1;
                byte  startAdd = byte.Parse(textBox1.Text);
                byte  bank = (byte)(AreaCb.SelectedIndex);
                if (bank == 2)
                {
                    bank = 3;
                }
                byte len = byte.Parse(textBox2.Text);
                MultiArea area = new MultiArea(bank,startAdd,len);
                Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                area.startStr = string.Format("{0}", sample.ToString("D" + len * 4));
                area.step = 1;
                if (bank == 1)
                {
                    cfa.AppSettings.Settings["StartAddEPC"].Value = startAdd.ToString();
                    cfa.AppSettings.Settings["BankEPC"].Value = bank.ToString();
                    cfa.AppSettings.Settings["LengthEPC"].Value = len.ToString();
                    cfa.AppSettings.Settings["StartValueEPC"].Value = area.startStr;
                    cfa.AppSettings.Settings["StepValueEPC"].Value = area.step.ToString();
                    if (tables.ContainsKey("EPC"))
                    {
                        tables["EPC"] = area;
                    }
                    else
                    {
                        cfa.AppSettings.Settings["Area"].Value = (byte.Parse(ConfigurationManager.AppSettings["Area"]) + 1).ToString(); 
                        tables.Add("EPC", area);
                    }
                }
                else if (bank == 0)
                {
                    cfa.AppSettings.Settings["StartAddRFU"].Value = startAdd.ToString();
                    cfa.AppSettings.Settings["BankRFU"].Value = bank.ToString();
                    cfa.AppSettings.Settings["LengthRFU"].Value = len.ToString();
                    cfa.AppSettings.Settings["StartValueRFU"].Value = area.startStr;
                    cfa.AppSettings.Settings["StepValueRFU"].Value = area.step.ToString(); ;
                    if (tables.ContainsKey("RFU"))
                    {
                        tables["RFU"] = area;
                    }
                    else
                    {
                        cfa.AppSettings.Settings["Area"].Value = (byte.Parse(ConfigurationManager.AppSettings["Area"]) + 2).ToString();
                        tables.Add("RFU", area);
                    }
                }
                else if (bank == 3)
                {
                    cfa.AppSettings.Settings["StartAddUSR"].Value = startAdd.ToString();
                    cfa.AppSettings.Settings["BankUSR"].Value = bank.ToString();
                    cfa.AppSettings.Settings["LengthUSR"].Value = len.ToString();
                    cfa.AppSettings.Settings["StartValueUSR"].Value = area.startStr;
                    cfa.AppSettings.Settings["StepValueUSR"].Value = area.step.ToString();
                    if (tables.ContainsKey("USER"))
                    {
                        tables["USER"] = area;
                    }
                    else
                    {
                        cfa.AppSettings.Settings["Area"].Value = (byte.Parse(ConfigurationManager.AppSettings["Area"]) + 4).ToString();
                        tables.Add("USER", area);
                    }
                }
                cfa.Save();
            }
            catch
            {
                MessageBox.Show(formatError);
            }
            new Task(() =>
            {
                m_SyncContext.Post(UpdatePicture, Convert.ToString((char)8730));
                Thread.Sleep(500);
                m_SyncContext.Post(UpdatePicture, " ");
            }).Start();
        }


        private void UpdatePicture(object state)
        {
            label7.Text = state as string;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal void ChangeLanguage(ResourceManager rm)
        {

            this.Text = rm.GetString("writeDataSetStr");

            label4.Text = rm.GetString("areaStr");
            groupBox1.Text = rm.GetString("btnSetReadSpeed");
            label1.Text = rm.GetString("areaStr");
            label2.Text = rm.GetString("strLabStartAdd");
            label3.Text = rm.GetString("LenStr");
            button1.Text = rm.GetString("AddStr");
            button2.Text = rm.GetString("sureStr");
            button3.Text = rm.GetString("DeleteStr");

            formatError = rm.GetString("StrFormatError");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte bank = (byte)(AreaCb.SelectedIndex);
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (bank == 1)
            {
                tables.Remove("EPC");
                cfa.AppSettings.Settings["Area"].Value = (byte.Parse(ConfigurationManager.AppSettings["Area"]) -1).ToString();
            }
            else if (bank == 0)
            {
                tables.Remove("RFU");
                cfa.AppSettings.Settings["Area"].Value = (byte.Parse(ConfigurationManager.AppSettings["Area"]) - 2).ToString();
            }
            else if (bank == 2)
            {
                tables.Remove("USER");
                cfa.AppSettings.Settings["Area"].Value = (byte.Parse(ConfigurationManager.AppSettings["Area"]) - 4).ToString();
            }
            cfa.Save();
            new Task(() =>
            {
                m_SyncContext.Post(UpdatePicture, Convert.ToString((char)8730));
                Thread.Sleep(500);
                m_SyncContext.Post(UpdatePicture, " ");
            }).Start();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (AreaCb.SelectedIndex)
            {
                case 0:
                    label5.Text = "(Len=2)";
                    label6.Text = "(Address=0,2)";
                    if (Reservecheck.Checked)
                    {
                        textBox1.Text = tables["RFU"].startAdd.ToString();
                        textBox2.Text = tables["RFU"].len.ToString();
                    }
                    else
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                    break;
                case 1:
                    label5.Text = "(Len=8-Address)";
                    label6.Text = "(Address=2)";
                    if (EPCcheck.Checked)
                    {
                        textBox1.Text = tables["EPC"].startAdd.ToString();
                        textBox2.Text = tables["EPC"].len.ToString();
                    }
                    else
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                    break;
                case 2:
                    label5.Text = "(Len>1)";
                    label6.Text = "(Address=0)";
                    if (Usercheck.Checked)
                    {
                        textBox1.Text = tables["USER"].startAdd.ToString();
                        textBox2.Text = tables["USER"].len.ToString();
                    }
                    else
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
