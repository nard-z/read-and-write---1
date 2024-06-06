using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DisDemo
{
    public sealed class EPC_data : System.IComparable
    {
        public string epc;
        public int count;
        public int devNo;
        public byte antNo;
        public string temp;
        public string host;
        public string readTagTime;


        public int CompareTo(object obj)
        {
            EPC_data temp = (EPC_data)obj;
            {
                return string.Compare(this.epc, temp.epc);
            }
        }
    }
}
