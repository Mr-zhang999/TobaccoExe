using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TobaccoApp;

namespace TobaccoExe
{
    public partial class HistoryGraphical : Form
    {
        Boolean X_Minimum_FLAG = false;
        public HistoryGraphical()
        {
            InitializeComponent();
        }

        private void HistoryGraphical_Load(object sender, EventArgs e)
        {
            historyChart.ChartAreas[0].AxisY.Maximum = 200;
            historyChart.ChartAreas[0].AxisY.Interval = 20;
            historyChart.ChartAreas[0].AxisX.Title = "Time/s";
            historyChart.ChartAreas[0].AxisY.Title = "Temperature/℃";
            historyChart.ChartAreas[0].AxisY.Minimum = 20;
        }
        private void getData(DateTime start, DateTime end)
        {
            //select ID,Sensor1_Temp,Sensor2_Temp,Sensor3_Temp,RSensor4_Temp from tbl_timely where Time_now>'2021-03-25 16:24' and Time_now<'2021-03-30 14:47';
            //String str = "select top 1 ID,Sensor1_Temp,Sensor2_Temp,Sensor3_Temp,RSensor4_Temp from tbl_timely ORDER BY ID desc;";
            // String str = "select top 100 ID,Sensor1_Temp,Sensor2_Temp,Sensor3_Temp,RSensor4_Temp from tbl_timely";
            String str = "select SR_ID,SR_SECTION_TEMP1,SR_SECTION_TEMP2,SR_SECTION_TEMP3,SR_SECTION_TEMP4 from TBL_SENSOR_RECORD where SR_TIME>'" + start + "'and SR_TIME<'" + end + "' order by SR_ID asc";
            SqlDataReader dr = DataOperator.GetDataReaderChart(str);
            List<long> idList = new List<long>();
            List<float> roll_1_List = new List<float>();
            List<float> roll_2_List = new List<float>();
            List<float> roll_3_List = new List<float>();
            List<float> roll_4_List = new List<float>();
            int s;
           
            if (dr.Read() == false)
            {
                MessageBox.Show("该时间段无数据", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            while (dr.Read())
            {
                if (X_Minimum_FLAG == false)
                {                
                    historyChart.ChartAreas[0].AxisX.Minimum = (long) dr[0];                
                    X_Minimum_FLAG = true;
                }

                if (dr[1] is DBNull)
                { }
                else
                {
                    int tempdata = (int)dr[1];
                    roll_1_List.Add((float)tempdata/100);
                }
                if (dr[2] is DBNull)
                {
                }
                else
                {
                    int tempdata = (int)dr[2];
                    roll_2_List.Add((float)tempdata/100);
                }
                if (dr[3] is DBNull)
                { }
                else
                {
                    int tempdata = (int)dr[3];
                    roll_3_List.Add((float)tempdata/100);
                }
                if (dr[4] is DBNull)
                { }
                else
                {
                    int tempdata = (int)dr[4];
                    roll_4_List.Add((float)tempdata/100);
                }
                idList.Add((long)dr[0]);
            }
            dr.Close();
            int numX = roll_1_List.Count();
            historyChart.ChartAreas[0].AxisX.Maximum = historyChart.ChartAreas[0].AxisX.Minimum + numX + 20;
            historyChart.ChartAreas[0].AxisX.Interval = 10;
            //画图的函数
            drawLines_Roll_1(idList, roll_1_List);
            drawLines_Roll_2(idList, roll_2_List);
            drawLines_Roll_3(idList, roll_3_List);
            drawLines_Roll_4(idList, roll_4_List);

        }
        private void drawLines_Roll_1(List<long> list1, List<float> list2)
        {
            List<long> xData = list1;
            List<float> yData = list2;
            //线条颜色
            historyChart.Series[0].Color = Color.DeepSkyBlue;
            //线条粗细
            historyChart.Series[0].BorderWidth = 1;
            //标记点中心颜色
            //chart1.Series[0].MarkerColor = Color.DeepSkyBlue;
            //标记点大小
            //chart1.Series[0].MarkerSize = 5;
            //标记点类型     
            //chart1.Series[0].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            //绑定数据   
            historyChart.Series[0].Points.DataBindXY(xData, yData);

        }
        private void drawLines_Roll_2(List<long> list1, List<float> list2)
        {
            List<long> xData = list1;
            List<float> yData = list2;
            historyChart.Series[1].Color = Color.DeepPink;
            historyChart.Series[1].BorderWidth = 1;
            historyChart.Series[1].Points.DataBindXY(xData, yData);

        }
        private void drawLines_Roll_3(List<long> list1, List<float> list2)
        {
            List<long> xData = list1;
            List<float> yData = list2;
            historyChart.Series[2].Color = Color.Black;
            historyChart.Series[2].BorderWidth = 1;
            historyChart.Series[2].Points.DataBindXY(xData, yData);

        }
        private void drawLines_Roll_4(List<long> list1, List<float> list2)
        {
            List<long> xData = list1;
            List<float> yData = list2;
            historyChart.Series[3].Color = Color.YellowGreen;
            historyChart.Series[3].BorderWidth = 1;
            historyChart.Series[3].Points.DataBindXY(xData, yData);
        }
        private void queryChart_Click(object sender, EventArgs e)
        {
            DateTime start = startTime.Value;
            DateTime end = endTime.Value;
            getData(start, end);
        }
    }
}
