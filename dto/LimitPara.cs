using System;
using System.Collections.Generic;
using System.Text;

namespace TobaccoApp.dto
{
    class LimitPara
    {
        // 属性
        private int LP_TYPE;
        private int LP_VALUE;
        
        private DateTime MODEY_TIME;
        private string OPER_NUMBER;

        public int LP_VALUE1 { get => LP_VALUE; set => LP_VALUE = value; }
        public DateTime MODEY_TIME1 { get => MODEY_TIME; set => MODEY_TIME = value; }
        public string OPER_NUMBER1 { get => OPER_NUMBER; set => OPER_NUMBER = value; }
        public int LP_TYPE1 { get => LP_TYPE; set => LP_TYPE = value; }
    }
}
