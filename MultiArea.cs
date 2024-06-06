using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DisDemo
{
    public class MultiArea
    {
        public byte bank { get; set; }
        public byte startAdd { get; set; }
        public byte len { get; set; }
        public bool writeSuccess { get; set; }
        public string writeData { get; set; }
        public string startStr { get; set; }
        public string currentStr { get; set; }
        public byte step { get; set;}
        public byte startValue { get; set; }


        public MultiArea(byte bank, byte startAdd, byte len)
        {
            writeData = "";
            this.bank = bank;
            this.startAdd = startAdd;
            this.len = len;
            writeSuccess = false;
            startValue = 0;
        }

        public MultiArea()
        {
            writeData = "";
            writeSuccess = false;
        }

        public bool Legality()
        {
            if (bank == 1)
            {
                if (startAdd < 2)
                {
                    return false;
                }
            }
            else
            {
                if (startAdd < 0 || len < 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
