using System;
using System.Collections.Generic;
using System.Text;

namespace TobaccoApp.dto
{
    class SetPara
    {
        private int SET_TYPE;
        private int SET_VALUE;
        private DateTime TIME;
        private string OPER_NUMBER;

        public int SET_TYPE1 { get => SET_TYPE; set => SET_TYPE = value; }
        public int SET_VALUE1 { get => SET_VALUE; set => SET_VALUE = value; }
        public DateTime TIME1 { get => TIME; set => TIME = value; }
        public string OPER_NUMBER1 { get => OPER_NUMBER; set => OPER_NUMBER = value; }
    }
}
