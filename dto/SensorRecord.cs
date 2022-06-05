using System;
using System.Collections.Generic;
using System.Text;

namespace TobaccoApp.dto
{
    class SensorRecord
    {
        //进口物料含水率
        private int STUFF_WET_IN;
        //出口物料含水率
        private int STUFF_WET_OUT;
        //进口物料重量
        private int STUFF_WEIGHT;
        //进口物料温度
        private int STUFF_TEMP_IN;
        //出口物料温度
        private int STUFF_TEMP_OUT;
        //进口热风温度
        private int AIR_TEMP_IN;
        //出口热风温度
        private int AIR_TEMP_OUT;
        //进口热风流量
        private int AIR_SPEED;

        //滚筒温度
        private int SECTION_TEMP1;
        private int SECTION_TEMP2;
        private int SECTION_TEMP3;
        private int SECTION_TEMP4;

        //滚筒段备用温度
        private int SR_SECTION_TEMP1_BAK;
        private int SR_SECTION_TEMP2_BAK;
        private int SR_SECTION_TEMP3_BAK;
        private int SR_SECTION_TEMP4_BAK;

        //环境温度
        private int ENVIRON_TEMP;
        //环境湿度
        private int ENVIRON_WET;

        private DateTime TIME;

        public SensorRecord()
        {
        }

        public int STUFF_WET_IN1 { get => STUFF_WET_IN; set => STUFF_WET_IN = value; }
        public int STUFF_WET_OUT1 { get => STUFF_WET_OUT; set => STUFF_WET_OUT = value; }
        public int STUFF_WEIGHT1 { get => STUFF_WEIGHT; set => STUFF_WEIGHT = value; }
        public int STUFF_TEMP_IN1 { get => STUFF_TEMP_IN; set => STUFF_TEMP_IN = value; }
        public int STUFF_TEMP_OUT1 { get => STUFF_TEMP_OUT; set => STUFF_TEMP_OUT = value; }
        public int AIR_TEMP_IN1 { get => AIR_TEMP_IN; set => AIR_TEMP_IN = value; }
        public int AIR_TEMP_OUT1 { get => AIR_TEMP_OUT; set => AIR_TEMP_OUT = value; }
        public int AIR_SPEED1 { get => AIR_SPEED; set => AIR_SPEED = value; }
        public int SECTION_TEMP11 { get => SECTION_TEMP1; set => SECTION_TEMP1 = value; }
        public int SECTION_TEMP21 { get => SECTION_TEMP2; set => SECTION_TEMP2 = value; }
        public int SECTION_TEMP31 { get => SECTION_TEMP3; set => SECTION_TEMP3 = value; }
        public int SECTION_TEMP41 { get => SECTION_TEMP4; set => SECTION_TEMP4 = value; }
        public int SR_SECTION_TEMP1_BAK1 { get => SR_SECTION_TEMP1_BAK; set => SR_SECTION_TEMP1_BAK = value; }
        public int SR_SECTION_TEMP2_BAK1 { get => SR_SECTION_TEMP2_BAK; set => SR_SECTION_TEMP2_BAK = value; }
        public int SR_SECTION_TEMP3_BAK1 { get => SR_SECTION_TEMP3_BAK; set => SR_SECTION_TEMP3_BAK = value; }
        public int SR_SECTION_TEMP4_BAK1 { get => SR_SECTION_TEMP4_BAK; set => SR_SECTION_TEMP4_BAK = value; }
        public int ENVIRON_TEMP1 { get => ENVIRON_TEMP; set => ENVIRON_TEMP = value; }
        public int ENVIRON_WET1 { get => ENVIRON_WET; set => ENVIRON_WET = value; }
        public DateTime TIME1 { get => TIME; set => TIME = value; }
    }
}
