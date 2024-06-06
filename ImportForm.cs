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
using System.Threading;
using System.Threading.Tasks;

namespace DisDemo
{
    public partial class ImportForm : Form
    {
        private ResourceManager rm;
        SynchronizationContext m_SyncContext = null;
        private string NoArea;
        public ImportForm()
        {
            InitializeComponent();
        }

        public ImportForm(ResourceManager rm, int number)
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
            this.rm = rm;
            InitParaAndUI(number);
            this.ChangeLanguage(rm);
        }


        private void InitParaAndUI(int number)
        {
            this.Number = number;
            numStr.Text = this.Number.ToString();
            foreach (string key in WriteTagDataFormat.tables.Keys)
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
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (AreaCB.SelectedIndex == 0)
            {

                if (WriteTagDataFormat.tables.ContainsKey("RFU"))
                {
                    WriteTagDataFormat.tables["RFU"].startStr = startStrTb.Text.Replace(" ", "");
                    WriteTagDataFormat.tables["RFU"].step = byte.Parse(stepTb.Text);
                    WriteTagDataFormat.tables["RFU"].startValue = byte.Parse(startValueTb.Text);
                    cfa.AppSettings.Settings["StartValueRFU"].Value = WriteTagDataFormat.tables["RFU"].startStr;
                    cfa.AppSettings.Settings["StepValueRFU"].Value = WriteTagDataFormat.tables["RFU"].step.ToString();

                }
            }
            if (AreaCB.SelectedIndex == 1)
            {
                if (WriteTagDataFormat.tables.ContainsKey("EPC"))
                {
                    WriteTagDataFormat.tables["EPC"].startStr = startStrTb.Text.Replace(" ","");
                    WriteTagDataFormat.tables["EPC"].step = byte.Parse(stepTb.Text);
                    WriteTagDataFormat.tables["EPC"].startValue = byte.Parse(startValueTb.Text);
                    cfa.AppSettings.Settings["StartValueEPC"].Value = WriteTagDataFormat.tables["EPC"].startStr;
                    cfa.AppSettings.Settings["StepValueEPC"].Value = WriteTagDataFormat.tables["EPC"].step.ToString();
                }
            }
            if (AreaCB.SelectedIndex == 2)
            {
                if (WriteTagDataFormat.tables.ContainsKey("USER"))
                {
                    WriteTagDataFormat.tables["USER"].startStr = startStrTb.Text.Replace(" ", "");
                    WriteTagDataFormat.tables["USER"].step = byte.Parse(stepTb.Text);
                    WriteTagDataFormat.tables["USER"].startValue = byte.Parse(startValueTb.Text);
                    cfa.AppSettings.Settings["StartValueUSR"].Value = WriteTagDataFormat.tables["USER"].startStr;
                    cfa.AppSettings.Settings["StepValueUSR"].Value = WriteTagDataFormat.tables["USER"].step.ToString();
                }
            }
            cfa.Save();
            new Task(() => {
                m_SyncContext.Post(UpdatePicture, Convert.ToString((char)8730));
                Thread.Sleep(500);
                m_SyncContext.Post(UpdatePicture," ");
            }).Start();
        }


        private void UpdatePicture(object state)
        {
            label5.Text = state as string;
        }


        public int epcFormate { get; set; }

        public byte epcLen { get; set; }

        public int Number { get; set; }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        internal void ChangeLanguage(ResourceManager rm)
        {
            label7.Text = rm.GetString("areaStr");
            label1.Text = rm.GetString("areaStr");
            resultPicL.Text = rm.GetString("btnAntSet");
            button2.Text = rm.GetString("sureStr");
            NumberL.Text = rm.GetString("NumberStr");
            StartValueL.Text = rm.GetString("StartValueStr");
            IncreaseL.Text = rm.GetString("IncreaseStr");
            areaSampleL.Text = rm.GetString("SampleStr");
            startAddSampleLb.Text = rm.GetString("SampleStr");
            groupBox1.Text = rm.GetString("imporDataFormatStr");
            label2.Text = rm.GetString("startValue");
            this.Text = rm.GetString("imporDataFormatSetStr");

            NoArea = rm.GetString("NoArea");
        }

        private void ImportForm_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Number = int.Parse(numStr.Text);
        }

        private void AreaCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            byte sample = 1;
            switch (AreaCB.SelectedIndex)
            {
                case 0:
                    if (WriteTagDataFormat.tables.ContainsKey("RFU"))
                    {
                        startStrTb.Text = PageFun.AddSpace(WriteTagDataFormat.tables["RFU"].startStr);
                        stepTb.Text = WriteTagDataFormat.tables["RFU"].step.ToString();
                        startAddSampleTb.Text = PageFun.AddSpace(string.Format("{0}", sample.ToString("D" + WriteTagDataFormat.tables["RFU"].len * 4)));
                        areaSampleL.Text = "";
                    }
                    else
                    {
                        areaSampleL.Text = NoArea;
                    }
                    break;
                case 1:
                    if (WriteTagDataFormat.tables.ContainsKey("EPC"))
                    {
                        startStrTb.Text = PageFun.AddSpace(WriteTagDataFormat.tables["EPC"].startStr);
                        stepTb.Text = WriteTagDataFormat.tables["EPC"].step.ToString();
                        startAddSampleTb.Text = PageFun.AddSpace(string.Format("{0}", sample.ToString("D" + WriteTagDataFormat.tables["EPC"].len * 4)));
                        areaSampleL.Text = "";
                    }
                    else
                    {
                        areaSampleL.Text = NoArea;
                    }
                    break;
                case 2:
                    if (WriteTagDataFormat.tables.ContainsKey("USER"))
                    {
                        startStrTb.Text = PageFun.AddSpace(WriteTagDataFormat.tables["USER"].startStr);
                        stepTb.Text = WriteTagDataFormat.tables["USER"].step.ToString();
                        startAddSampleTb.Text = PageFun.AddSpace(string.Format("{0}", sample.ToString("D" + WriteTagDataFormat.tables["USER"].len * 4)));
                        areaSampleL.Text = "";
                    }
                    else
                    {
                        areaSampleL.Text = NoArea;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
