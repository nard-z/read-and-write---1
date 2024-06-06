using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DisDemo
{
    public class ClsoeState
    {
        private int _Timeout;

        /// <summary>
        /// In millisecond
        /// </summary>
        public int Timeout
        {
            get
            {
                return _Timeout;
            }
        }

        private string _Caption;

        /// <summary>
        /// Caption of dialog
        /// </summary>
        public string Caption
        {
            get
            {
                return _Caption;
            }
        }

        public ClsoeState(string caption, int timeout)
        {
            _Timeout = timeout;
            _Caption = caption;
        }
    }
}
