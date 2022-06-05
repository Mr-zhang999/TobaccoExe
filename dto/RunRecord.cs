using System;
using System.Collections.Generic;
using System.Text;

namespace TobaccoApp.dto
{
    class RunRecord
    {
        private int RR_TYPE;
        private int RR_VALUE;
        private DateTime RR_TIME;

        public RunRecord()
        {
        }

        public int RR_TYPE1 { get => RR_TYPE; set => RR_TYPE = value; }
        public int RR_VALUE1 { get => RR_VALUE; set => RR_VALUE = value; }
        public DateTime RR_TIME1 { get => RR_TIME; set => RR_TIME = value; }
    }
}
